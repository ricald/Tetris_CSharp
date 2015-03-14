//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using Smart.Navigation;
    using Smart.Navigation.Windows.Forms;

    /// <summary>
    /// メインフォームクラス
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>画面遷移ナビゲータ</summary>
        private readonly Navigator navigator;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            // コンポーネントの初期化
            this.InitializeComponent();

            // ナビゲータ初期化
            this.navigator = new Navigator(new ControlViewProvider(this.PanelView));
            this.navigator.Forwarding += this.Navigator_Forwarding;
            this.navigator.Exited += this.Navigator_Exited;
            this.navigator.AutoRegister(Assembly.GetExecutingAssembly());

            // 記録のロード
            RecordData.Instance.Load();

            // 最初の画面へ遷移
            this.Show();
            this.navigator.Forward(ViewId.Title);
        }

        /// <summary>
        /// ナビゲータForwardingイベントハンドラ
        /// </summary>
        /// <param name="sender">通知元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Navigator_Forwarding(object sender, ViewForwardEventArgs e)
        {
        }

        /// <summary>
        /// ナビゲータExitedイベントハンドラ
        /// </summary>
        /// <param name="sender">通知元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Navigator_Exited(object sender, ViewExitEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// タイマーTickイベントハンドラ
        /// </summary>
        /// <param name="sender">通知元オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void TimerProcess_Tick(object sender, EventArgs e)
        {
            // 処理ディスパッチ
            IApplicationView view = this.navigator.CurrentView as IApplicationView;
            if (view != null)
            {
                view.OnExecute();
            }
        }
    }
}
