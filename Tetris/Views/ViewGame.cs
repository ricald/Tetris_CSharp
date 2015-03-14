//-----------------------------------------------------------------------
// <copyright file="ViewGame.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Microsoft.VisualBasic;
    using Smart.Navigation;

    /// <summary>
    /// ゲーム画面View
    /// </summary>
    [View(ViewId.Game)]
    public partial class ViewGame : AppViewBase
    {
        /// <summary>落下フレーム数初期値</summary>
        private const int DropFramesDefault = 30;

        /// <summary>落下カウント</summary>
        private int dropCount = 0;

        /// <summary>落下フレーム数</summary>
        private int dropFrames = DropFramesDefault;

        /// <summary>スコア</summary>
        private int score;

        /// <summary>レベル</summary>
        private int level;

        /// <summary>名前入力中</summary>
        private bool isInputName = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewGame()
        {
            // コンポーネントの初期化
            this.InitializeComponent();
        }

        /// <summary>スコア</summary>
        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value != this.score)
                {
                    // 値を変更
                    this.score = value;

                    // スコア表示を変更
                    this.LabelScoreValue.Text = this.score.ToString();

                    // レベルを変更
                    this.Level = (this.score / 500) + 1;
                }
            }
        }

        /// <summary>レベル</summary>
        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (value != this.level)
                {
                    // BGMを変更(レベル5を超えた)
                    if (this.level < 5 && 5 <= value)
                    {
                        Sound.Instance.Play(SoundId.Game2);
                    }

                    // 値を変更
                    this.level = value;

                    // レベル表示を変更
                    this.LabelLevelValue.Text = this.level.ToString();

                    // 落下速度を変更
                    this.dropFrames = DropFramesDefault - this.level;
                }
            }
        }

        /// <summary>
        /// Viewオープン時のイベントハンドラ
        /// </summary>
        /// <param name="args">イベント引数</param>
        public override void OnViewOpen(ViewForwardEventArgs args)
        {
            // スコア初期化
            this.Score = 0;

            // 音声再生
            Sound.Instance.Play(SoundId.Game1);

            // ゲーム開始
            this.NextBlockPanel3.Set(Tetromino.Get());
            System.Threading.Thread.Sleep(10);
            this.NextBlockPanel2.Set(Tetromino.Get());
            System.Threading.Thread.Sleep(10);
            this.NextBlockPanel1.Set(Tetromino.Get());
            System.Threading.Thread.Sleep(10);
            this.BlockPanel.GameStart(Tetromino.Get());
            base.OnViewOpen(args);
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        public override void OnExecute()
        {
            // キー入力処理
            this.ProcessInputKey();

            // テトロミノ落下処理
            this.dropCount++;
            if (this.dropCount >= this.dropFrames)
            {
                // 落下中テトロミノがある間だけ処理
                if (this.BlockPanel.FallingTetromino != null)
                {
                    // テトロミノ落下処理
                    if (this.ProcessDropTetromino() == false)
                    {
                        //------------------------------
                        // 落下できなかった
                        //------------------------------
                        // テトロミノを置く
                        List<int> fillLines = this.BlockPanel.PutTetromino(this.BlockPanel.FallingTetromino);

                        if (fillLines.Count > 0)
                        {
                            // スコア更新
                            if (fillLines.Count == 1)
                            {
                                // シングル
                                this.Score += 100;
                            }
                            else if (fillLines.Count == 2)
                            {
                                // ダブル
                                this.Score += 300;
                            }
                            else if (fillLines.Count == 3)
                            {
                                // トリプル
                                this.Score += 600;
                            }
                            else if (fillLines.Count >= 4)
                            {
                                // テトリス
                                this.Score += 1000;
                            }

                            // 音声を再生
                            Sound.Instance.Play(SoundId.Erase);
                        }
                        else
                        {
                            // 音声を再生
                            Sound.Instance.Play(SoundId.Put);
                        }

                        // 揃ったラインを消す
                        this.BlockPanel.DeleteLine(fillLines);

                        // 新しいテトロミノを取得
                        this.BlockPanel.FallingTetromino = this.NextBlockPanel1.Tetromino;
                        this.NextBlockPanel1.Set(this.NextBlockPanel2.Tetromino);
                        this.NextBlockPanel2.Set(this.NextBlockPanel3.Tetromino);
                        if (this.level >= 5)
                        {
                            // 新たなテトリミノをセット
                            this.NextBlockPanel3.Set(Tetromino.GetEx());
                        }
                        else
                        {
                            // 新たなテトリミノをセット
                            this.NextBlockPanel3.Set(Tetromino.Get());
                        }

                        // ゲームオーバー
                        if (this.BlockPanel.IsHit())
                        {
                            this.BlockPanel.FallingTetromino = null;

                            // ゲームオーバー
                            Sound.Instance.Stop();
                            Sound.Instance.Play(SoundId.GameOver);
                            this.BlockPanel.GameOver();

                            if (RecordData.Instance.IsNewRecord(this.Score))
                            {
                                this.isInputName = true;

                                // 名前入力
                                string name = Interaction.InputBox("名前を入力してください。", "New Record!", "名無しさん", -1, -1);

                                // 記録のセーブ
                                RecordData.Instance.Save(name, this.Score);

                                this.isInputName = false;
                            }
                        }
                    }
                }

                this.dropCount = 0;
            }

            this.BlockPanel.Invalidate();
            base.OnExecute();
        }

        /// <summary>
        /// テトロミノ落下処理
        /// </summary>
        /// <returns>true：落下可能、false：落下不可能</returns>
        private bool ProcessDropTetromino()
        {
            this.BlockPanel.FallingTetromino.Move(0, 1);
            if (this.BlockPanel.IsHit())
            {
                this.BlockPanel.FallingTetromino.Move(0, -1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// キー入力処理
        /// </summary>
        private void ProcessInputKey()
        {
            if (this.isInputName)
            {
                return;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                //------------------------------
                // 「←」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Left] != 2 && this.KeyInput.PressedFlames[Key.Left] != 4 && this.KeyInput.PressedFlames[Key.Left] % 2 == 0)
                {
                    // テトロミノを左に移動する
                    this.BlockPanel.MoveTetorominoLeft();
                }
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                //------------------------------
                // 「→」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Right] != 2 && this.KeyInput.PressedFlames[Key.Right] != 4 && this.KeyInput.PressedFlames[Key.Right] % 2 == 0)
                {
                    // テトロミノを右に移動する
                    this.BlockPanel.MoveTetorominoRight();
                }
            }

            if (Keyboard.IsKeyDown(Key.Up))
            {
                //------------------------------
                // 「↑」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Up] == 0)
                {
                    // テトロミノを左回転する
                    this.BlockPanel.RotateTetorominoLeft();
                }
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                //------------------------------
                // 「↓」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Down] % 2 == 0)
                {
                    if (this.BlockPanel.FallingTetromino != null)
                    {
                        // スコア更新
                        this.Score += 1;

                        // テトロミノを下に移動する
                        this.dropCount = this.dropFrames;
                    }
                }
            }

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //------------------------------
                // 「Enter」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Enter] == 0)
                {
                    // ゲームオーバー中ならタイトル画面に遷移
                    if (this.BlockPanel.FallingTetromino == null)
                    {
                        Navigator.Forward(ViewId.Title);
                    }
                }
            }
        }
    }
}
