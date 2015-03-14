//-----------------------------------------------------------------------
// <copyright file="AppViewBase.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System.Windows.Forms;
    using System.Windows.Input;
    using Smart.Navigation.Context;
    using Smart.Navigation.Windows.Forms;
    using Tetris.Context;

    /// <summary>
    /// アプリケーションView基底クラス
    /// </summary>
    public partial class AppViewBase : ControlViewBase, IApplicationView
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AppViewBase()
        {
            // コンポーネントの初期化
            this.InitializeComponent();
        }

        /// <summary>キー入力コンテキスト</summary>
        [ViewContext]
        protected KeyInputContext KeyInput { get; set; }

        /// <summary>
        /// ビューCloseイベントハンドラ
        /// </summary>
        public override void OnViewClose()
        {
            // 全ての音声を停止
            Sound.Instance.Stop();

            base.OnViewClose();
        } 

        /// <summary>
        /// 処理実行
        /// </summary>
        public virtual void OnExecute()
        {
            this.ProcessInputKey();

            // 画面の更新
            this.Invalidate();
        }

        /// <summary>
        /// キー入力処理
        /// </summary>
        private void ProcessInputKey()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                //------------------------------
                // 「←」キー押下
                //------------------------------
                // キー押下フレーム数加算
                this.KeyInput.PressedFlames[Key.Left]++;
            }
            else
            {
                // キー押下フレーム数初期化
                this.KeyInput.PressedFlames[Key.Left] = 0;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                //------------------------------
                // 「→」キー押下
                //------------------------------
                // キー押下フレーム数加算
                this.KeyInput.PressedFlames[Key.Right]++;
            }
            else
            {
                // キー押下フレーム数初期化
                this.KeyInput.PressedFlames[Key.Right] = 0;
            }

            if (Keyboard.IsKeyDown(Key.Up))
            {
                //------------------------------
                // 「↑」キー押下
                //------------------------------
                // キー押下フレーム数加算
                this.KeyInput.PressedFlames[Key.Up]++;
            }
            else
            {
                // キー押下フレーム数初期化
                this.KeyInput.PressedFlames[Key.Up] = 0;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                //------------------------------
                // 「↓」キー押下
                //------------------------------
                // キー押下フレーム数加算
                this.KeyInput.PressedFlames[Key.Down]++;
            }
            else
            {
                // キー押下フレーム数初期化
                this.KeyInput.PressedFlames[Key.Down] = 0;
            }

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //------------------------------
                // 「Enter」キー押下
                //------------------------------
                // キー押下フレーム数加算
                this.KeyInput.PressedFlames[Key.Enter]++;
            }
            else
            {
                // キー押下フレーム数初期化
                this.KeyInput.PressedFlames[Key.Enter] = 0;
            }
        }
    }
}
