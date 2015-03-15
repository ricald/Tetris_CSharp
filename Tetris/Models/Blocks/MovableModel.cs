//-----------------------------------------------------------------------
// <copyright file="MovableModel.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Models.Blocks
{
    /// <summary>
    /// 移動可能モデルクラス
    /// </summary>
    public abstract class MovableModel : Model
    {
        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="moveX">Ｘ座標の移動数</param>
        /// <param name="moveY">Ｙ座標の移動数</param>
        public void Move(int moveX, int moveY)
        {
            this.X += moveX;
            this.Y += moveY;
        }

        /// <summary>
        /// 左回転
        /// </summary>
        public abstract void RotateLeft();

        /// <summary>
        /// 右回転
        /// </summary>
        public abstract void RotateRight();
    }
}
