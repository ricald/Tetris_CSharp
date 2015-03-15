//-----------------------------------------------------------------------
// <copyright file="Model.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Models.Blocks
{
    /// <summary>
    /// モデルクラス
    /// </summary>
    public abstract class Model
    {
        /// <summary>Ｘ座標</summary>
        public int X { get; set; }
        
        /// <summary>Ｙ座標</summary>
        public int Y { get; set; }
    }
}
