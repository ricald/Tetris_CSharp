//-----------------------------------------------------------------------
// <copyright file="BlockPanel.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// ブロックパネルクラス
    /// </summary>
    public partial class BlockPanel : UserControl
    {
        /// <summary>画面幅サイズ</summary>
        private const int ScreenWidth = 10;

        /// <summary>画面高さサイズ</summary>
        private const int ScreenHeight = 20;

        /// <summary>ブロックサイズ</summary>
        private const int BlockLength = 20;

        /// <summary>ブロックイメージ</summary>
        private Image blockImage;

        /// <summary>ブロック領域</summary>
        private Dictionary<BlockType, Rectangle> blockRect;

        /// <summary>ゲーム画面状態</summary>
        private BlockType[,] screenState;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BlockPanel()
        {
            // コンポーネントの初期化
            this.InitializeComponent();

            // ブロックイメージの初期化
            this.blockImage = Properties.Resources.Block;

            // ブロック領域の初期化
            this.blockRect = new Dictionary<BlockType, Rectangle>
            {
                { BlockType.None, new Rectangle(0 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.I,    new Rectangle(1 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.O,    new Rectangle(2 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.J,    new Rectangle(3 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.Z,    new Rectangle(4 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.L,    new Rectangle(5 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.S,    new Rectangle(6 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.T,    new Rectangle(7 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.H1,   new Rectangle(8 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.H2,   new Rectangle(9 * BlockLength,  0, BlockLength, BlockLength) },
                { BlockType.H3,   new Rectangle(10 * BlockLength, 0, BlockLength, BlockLength) },
                { BlockType.H4,   new Rectangle(11 * BlockLength, 0, BlockLength, BlockLength) },
            };

            // ゲーム画面状態の初期化
            this.screenState = new BlockType[ScreenWidth, ScreenHeight];
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    this.screenState[x, y] = BlockType.None;
                }
            }

            // 画面サイズの決定
            this.Size = new Size(ScreenWidth * BlockLength, ScreenHeight * BlockLength);
        }

        /// <summary>落下中テトロミノ</summary>
        public Tetromino FallingTetromino { get; set; }

        /// <summary>
        /// ゲーム開始
        /// </summary>
        /// <param name="tetromino">テトロミノ</param>
        public void GameStart(Tetromino tetromino)
        {
            // 落下テトロミノの決定
            this.FallingTetromino = tetromino;
        }

        /// <summary>
        /// ゲームオーバー
        /// </summary>
        public void GameOver()
        {
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    if (this.screenState[x, y] != BlockType.None)
                    {
                        var random = new Random();
                        this.screenState[x, y] = BlockType.Z;
                    }
                }
            }
        }

        /// <summary>
        /// テトロミノを左に移動する
        /// </summary>
        public void MoveTetorominoLeft()
        {
            if (this.FallingTetromino != null)
            {
                // テトロミノを左に移動する
                this.FallingTetromino.Move(-1, 0);
                if (this.IsHit())
                {
                    // 出来なければ戻す
                    this.FallingTetromino.Move(1, 0);
                }
            }
        }

        /// <summary>
        /// テトロミノを右に移動する
        /// </summary>
        public void MoveTetorominoRight()
        {
            if (this.FallingTetromino != null)
            {
                // テトロミノを左に移動する
                this.FallingTetromino.Move(1, 0);
                if (this.IsHit())
                {
                    // 出来なければ戻す
                    this.FallingTetromino.Move(-1, 0);
                }
            }
        }

        /// <summary>
        /// テトロミノを左回転する
        /// </summary>
        public void RotateTetorominoLeft()
        {
            if (this.FallingTetromino != null)
            {
                if (this.FallingTetromino.TetrominoType != TetrominoType.O)
                {
                    // テトロミノを左回転する
                    this.FallingTetromino.RotateLeft();
                    if (this.IsHit())
                    {
                        // 出来なければ戻す
                        this.FallingTetromino.RotateRight();
                    }
                }
            }
        }

        /// <summary>
        /// テトロミノをScreenに追加
        /// </summary>
        /// <param name="tetromino">テトロミノ</param>
        /// <returns>揃っている行リスト</returns>
        public List<int> PutTetromino(Tetromino tetromino)
        {
            // 揃った行
            List<int> fillLines = new List<int>();

            // テトロミノをScreenに追加
            foreach (var block in tetromino.Blocks)
            {
                this.screenState[tetromino.X + block.X, tetromino.Y + block.Y] = block.BlockType;
            }

            // 行のブロックが全て揃っているかをチェック
            for (int y = 0; y < ScreenHeight; y++)
            {
                bool fill = true;
                for (int x = 0; x < ScreenWidth; x++)
                {
                    if (this.screenState[x, y] == BlockType.None)
                    {
                        fill = false;
                        break;
                    }
                }

                // 揃っている行を記憶
                if (fill)
                {
                    fillLines.Add(y);
                }
            }

            return fillLines;
        }

        /// <summary>
        /// 行を消す
        /// </summary>
        /// <param name="fillLines">揃っている行リスト(昇順に整列済み)</param>
        public void DeleteLine(List<int> fillLines)
        {
            foreach (var fillLine in fillLines)
            {
                for (int x = 0; x < ScreenWidth; x++)
                {
                    // 揃った行から上段を下にずらす
                    for (int y = fillLine; y > 0; y--)
                    {
                        this.screenState[x, y] = this.screenState[x, y - 1];
                    }

                    // 最上段は無し状態で初期化
                    this.screenState[x, 0] = BlockType.None;
                }
            }
        }

        /// <summary>
        /// 当たり判定
        /// </summary>
        /// <returns>trie：接触あり、false：接触なし</returns>
        public bool IsHit()
        {
            foreach (var block in this.FallingTetromino.Blocks)
            {
                int x = this.FallingTetromino.X + block.X;
                int y = this.FallingTetromino.Y + block.Y;

                if (x < 0 || x >= ScreenWidth)
                {
                    return true;
                }

                if (y >= ScreenHeight)
                {
                    return true;
                }

                if (this.screenState[x, y] != BlockType.None)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// ブロックパネルのPaintイベントハンドラ
        /// </summary>
        /// <param name="sender">通知元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void BlockPanel_Paint(object sender, PaintEventArgs e)
        {
            // ブロックを描画
            for (int x = 0; x < ScreenWidth; x++)
            {
                for (int y = 0; y < ScreenHeight; y++)
                {
                    // 貼り付け先領域を決定
                    e.Graphics.DrawImage(this.blockImage, new Rectangle(x * BlockLength, y * BlockLength, BlockLength, BlockLength), this.blockRect[this.screenState[x, y]], GraphicsUnit.Pixel);
                }
            }

            // テトロミノの描画
            if (this.FallingTetromino != null)
            {
                foreach (var block in this.FallingTetromino.Blocks)
                {
                    // 貼り付け先領域を決定
                    int x = this.FallingTetromino.X + block.X;
                    int y = this.FallingTetromino.Y + block.Y;
                    e.Graphics.DrawImage(this.blockImage, new Rectangle(x * BlockLength, y * BlockLength, BlockLength, BlockLength), this.blockRect[block.BlockType], GraphicsUnit.Pixel);
                }
            }
        }
    }
}
