//-----------------------------------------------------------------------
// <copyright file="KeyInputContext.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Context
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Smart.Navigation.Context;

    /// <summary>
    /// キー入力コンテキスト
    /// </summary>
    public class KeyInputContext : IContextSupport
    {
        /// <summary>押下フレーム数</summary>
        public Dictionary<Key, int> PressedFlames { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initilize()
        {
            // キー押下フレーム数の初期化
            this.PressedFlames = new Dictionary<Key, int>
            {
                { Key.Left,  0 },
                { Key.Right, 0 },
                { Key.Up,    0 },
                { Key.Down,  0 },
                { Key.Enter, 0 },
            };
        }

        /// <summary>
        /// 破棄処理
        /// </summary>
        public void Dispose()
        {
            // キー押下フレーム数の破棄
            this.PressedFlames.Clear();
        }
    }
}
