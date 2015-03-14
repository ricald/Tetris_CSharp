//-----------------------------------------------------------------------
// <copyright file="Block.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// ブロッククラス
    /// </summary>
    public class Block : MovableModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="position">位置</param>
        /// <param name="blockType">ブロック種別</param>
        public Block(Point position, BlockType blockType)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.BlockType = blockType;
        }

        /// <summary>ブロック種別</summary>
        public BlockType BlockType { get; set; }

        /// <summary>
        /// 左回りに回転
        /// </summary>
        public override void RotateLeft()
        {
            int x = this.X;
            this.X = -this.Y;
            this.Y = x;
        }

        /// <summary>
        /// 右回りに回転
        /// </summary>
        public override void RotateRight()
        {
            int x = this.X;
            this.X = this.Y;
            this.Y = -x;
        }

        /// <summary>
        /// オブジェクトの複製
        /// </summary>
        /// <returns>複製したオブジェクト</returns>
        public Block Clone()
        {
            return new Block(new Point(this.X, this.Y), this.BlockType);
        }
    }
}
