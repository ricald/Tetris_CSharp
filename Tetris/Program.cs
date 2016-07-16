//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// プログラムクラス
    /// </summary>
    internal static class Program
    {
        /// <summary>メインフォーム</summary>
        private static Form mainForm;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new FormMain();
            Application.Run(mainForm);
        }

        /// <summary>
        /// メインフォームがアクティブかどうかを判断
        /// </summary>
        /// <returns>true：アクティブである、false：アクティブでない</returns>
        public static bool IsMainFormActive()
        {
            if (Form.ActiveForm == mainForm)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
