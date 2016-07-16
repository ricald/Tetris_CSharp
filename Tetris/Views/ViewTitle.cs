//-----------------------------------------------------------------------
// <copyright file="ViewTitle.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Views
{
    using System.Windows.Forms;
    using System.Windows.Input;
    using Smart.Navigation;

    /// <summary>
    /// タイトル画面View
    /// </summary>
    [View(ViewId.Title)]
    public partial class ViewTitle : AppViewBase
    {
        /// <summary>選択中インデックス</summary>
        private int selectedIndex;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewTitle()
        {
            // コンポーネントの初期化
            this.InitializeComponent();

            this.selectedIndex = 0;
        }

        /// <summary>選択中インデックス</summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                if (value != this.selectedIndex)
                {
                    this.selectedIndex = value;

                    if (this.selectedIndex == 0)
                    {
                        this.LabelGameStartSelected.Visible = true;
                        this.LabelRankingSelected.Visible = false;
                        this.LabelGameEndSelected.Visible = false;
                    }
                    else if (this.selectedIndex == 1)
                    {
                        this.LabelGameStartSelected.Visible = false;
                        this.LabelRankingSelected.Visible = true;
                        this.LabelGameEndSelected.Visible = false;
                    }
                    else
                    {
                        this.LabelGameStartSelected.Visible = false;
                        this.LabelRankingSelected.Visible = false;
                        this.LabelGameEndSelected.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Viewオープン時のイベントハンドラ
        /// </summary>
        /// <param name="args">イベント引数</param>
        public override void OnViewOpen(ViewForwardEventArgs args)
        {
            // 音声再生
            Sound.Instance.Play(SoundId.Title);
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        public override void OnExecute()
        {
            // キー入力処理
            this.ProcessInputKey();

            base.OnExecute();
        }

        /// <summary>
        /// キー入力処理
        /// </summary>
        private void ProcessInputKey()
        {
            // 「↑」キー押下
            if (this.KeyInput.PressedFlames[Key.Up] == 1)
            {
                if (this.selectedIndex > 0)
                {
                    this.SelectedIndex--;
                }
            }

            // 「↓」キー押下
            if (this.KeyInput.PressedFlames[Key.Down] == 1)
            {
                if (this.selectedIndex < 2)
                {
                    this.SelectedIndex++;
                }
            }

            // 「Enter」キー押下
            if (this.KeyInput.PressedFlames[Key.Enter] == 1)
            {
                if (this.SelectedIndex == 0)
                {
                    Navigator.Forward(ViewId.Game);
                }
                else if (this.selectedIndex == 1)
                {
                    Navigator.Forward(ViewId.Ranking);
                }
                else if (this.selectedIndex == 2)
                {
                    Navigator.Exit();
                }
            }
        }
    }
}
