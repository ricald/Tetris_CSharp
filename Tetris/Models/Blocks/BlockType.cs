//-----------------------------------------------------------------------
// <copyright file="BlockType.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Models.Blocks
{
    /// <summary>ブロックタイプ列挙体</summary>
    public enum BlockType
    {
        /// <summary>無し</summary>
        None,

        /// <summary>I-テトリミノ（水色）</summary>
        I,

        /// <summary>O-テトリミノ（黄色）</summary>
        O,

        /// <summary>J-テトリミノ（青）</summary>
        J,

        /// <summary>Z-テトリミノ（赤）</summary>
        Z,

        /// <summary>L-テトリミノ（オレンジ）</summary>
        L,

        /// <summary>S-テトリミノ（黄緑）</summary>
        S,

        /// <summary>T-テトリミノ（紫）</summary>
        T,

        /// <summary>H-テトリミノ（顔）</summary>
        H1,

        /// <summary>H-テトリミノ（胸）</summary>
        H2,

        /// <summary>H-テトリミノ（腰）</summary>
        H3,

        /// <summary>H-テトリミノ（脚）</summary>
        H4,
    }
}
