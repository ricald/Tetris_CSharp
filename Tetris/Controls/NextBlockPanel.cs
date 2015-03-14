//-----------------------------------------------------------------------
// <copyright file="NextBlockPanel.cs" company="CompanyName">
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
    /// 次ブロックパネルクラス
    /// </summary>
    public partial class NextBlockPanel : UserControl
    {
        /// <summary>画面幅サイズ</summary>
        private const int ScreenWidth = 5;

        /// <summary>画面高さサイズ</summary>
        private const int ScreenHeight = 5;

        /// <summary>ブロックサイズ</summary>
        private const int BlockLength = 20;

        /// <summary>ブロックイメージ</summary>
        private Image blockImage;

        /// <summary>ブロック領域</summary>
        private Dictionary<BlockType, Rectangle> blockRect;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NextBlockPanel()
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

            // 画面サイズの決定
            this.Size = new Size(ScreenWidth * BlockLength, ScreenHeight * BlockLength);

            // テトロミノの初期化
            this.Tetromino = Tetromino.Get();
        }

        /// <summary>テトロミノ</summary>
        public Tetromino Tetromino { get; private set; }

        /// <summary>
        /// 設定
        /// </summary>
        /// <param name="tetromino">テトロミノ</param>
        public void Set(Tetromino tetromino)
        {
            // テトロミノの設定
            this.Tetromino = tetromino;

            // 表示更新
            this.Invalidate();
        }

        /// <summary>
        /// ブロックパネルのPaintイベントハンドラ
        /// </summary>
        /// <param name="sender">通知元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void NextBlockPanel_Paint(object sender, PaintEventArgs e)
        {
            // テトロミノの描画
            if (this.Tetromino != null)
            {
                foreach (var block in this.Tetromino.Blocks)
                {
                    // 貼り付け先領域を決定
                    int x = 2 + block.X;
                    int y = 2 + block.Y;
                    e.Graphics.DrawImage(this.blockImage, new Rectangle(x * BlockLength, y * BlockLength, BlockLength, BlockLength), this.blockRect[block.BlockType], GraphicsUnit.Pixel);
                }
            }
        }
    }
}
