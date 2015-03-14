//-----------------------------------------------------------------------
// <copyright file="ViewRanking.cs" company="CompanyName">
//     Copyright © 2015 Ricald All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Tetris.Views
{
    using System.Windows.Forms;
    using System.Windows.Input;
    using Smart.Navigation;

    /// <summary>
    /// ランキング画面View
    /// </summary>
    [View(ViewId.Ranking)]
    public partial class ViewRanking : AppViewBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ViewRanking()
        {
            // コンポーネントの初期化
            this.InitializeComponent();
        }

        /// <summary>
        /// Viewオープン時のイベントハンドラ
        /// </summary>
        /// <param name="args">イベント引数</param>
        public override void OnViewOpen(ViewForwardEventArgs args)
        {
            for (int index = 0; index < 10; index++)
            {
                if (index == 0)
                {
                    this.LabelName01.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore01.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 1)
                {
                    this.LabelName02.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore02.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 2)
                {
                    this.LabelName03.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore03.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 3)
                {
                    this.LabelName04.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore04.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 4)
                {
                    this.LabelName05.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore05.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 5)
                {
                    this.LabelName06.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore06.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 6)
                {
                    this.LabelName07.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore07.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 7)
                {
                    this.LabelName08.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore08.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 8)
                {
                    this.LabelName09.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore09.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
                else if (index == 9)
                {
                    this.LabelName10.Text = RecordData.Instance.RecordDataInfoList[index].Name;
                    this.LabelScore10.Text = RecordData.Instance.RecordDataInfoList[index].Score.ToString();
                }
            }
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
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                //------------------------------
                // 「Enter」キー押下
                //------------------------------
                if (this.KeyInput.PressedFlames[Key.Enter] == 0)
                {
                    Navigator.Forward(ViewId.Title);
                }
            }
        }
    }
}
