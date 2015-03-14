namespace Tetris.Views
{
    partial class ViewTitle
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelCopyright = new System.Windows.Forms.Label();
            this.LabelGameStart = new System.Windows.Forms.Label();
            this.LabelGameEnd = new System.Windows.Forms.Label();
            this.LabelGameStartSelected = new System.Windows.Forms.Label();
            this.LabelGameEndSelected = new System.Windows.Forms.Label();
            this.LabelRankingSelected = new System.Windows.Forms.Label();
            this.LabelRanking = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelTitle.ForeColor = System.Drawing.Color.White;
            this.LabelTitle.Location = new System.Drawing.Point(3, 50);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(470, 100);
            this.LabelTitle.TabIndex = 0;
            this.LabelTitle.Text = "ＴＥＴＲＩＳ";
            this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCopyright
            // 
            this.LabelCopyright.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelCopyright.ForeColor = System.Drawing.Color.White;
            this.LabelCopyright.Location = new System.Drawing.Point(3, 546);
            this.LabelCopyright.Name = "LabelCopyright";
            this.LabelCopyright.Size = new System.Drawing.Size(470, 30);
            this.LabelCopyright.TabIndex = 1;
            this.LabelCopyright.Text = "© 2015 M.SYSTEMS inc.";
            this.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGameStart
            // 
            this.LabelGameStart.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameStart.ForeColor = System.Drawing.Color.White;
            this.LabelGameStart.Location = new System.Drawing.Point(2, 400);
            this.LabelGameStart.Name = "LabelGameStart";
            this.LabelGameStart.Size = new System.Drawing.Size(470, 30);
            this.LabelGameStart.TabIndex = 2;
            this.LabelGameStart.Text = "GAME START";
            this.LabelGameStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGameEnd
            // 
            this.LabelGameEnd.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameEnd.ForeColor = System.Drawing.Color.White;
            this.LabelGameEnd.Location = new System.Drawing.Point(2, 460);
            this.LabelGameEnd.Name = "LabelGameEnd";
            this.LabelGameEnd.Size = new System.Drawing.Size(470, 30);
            this.LabelGameEnd.TabIndex = 3;
            this.LabelGameEnd.Text = "GAME END";
            this.LabelGameEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGameStartSelected
            // 
            this.LabelGameStartSelected.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameStartSelected.ForeColor = System.Drawing.Color.White;
            this.LabelGameStartSelected.Location = new System.Drawing.Point(140, 400);
            this.LabelGameStartSelected.Name = "LabelGameStartSelected";
            this.LabelGameStartSelected.Size = new System.Drawing.Size(30, 30);
            this.LabelGameStartSelected.TabIndex = 4;
            this.LabelGameStartSelected.Text = "▶";
            this.LabelGameStartSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelGameEndSelected
            // 
            this.LabelGameEndSelected.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelGameEndSelected.ForeColor = System.Drawing.Color.White;
            this.LabelGameEndSelected.Location = new System.Drawing.Point(140, 460);
            this.LabelGameEndSelected.Name = "LabelGameEndSelected";
            this.LabelGameEndSelected.Size = new System.Drawing.Size(30, 30);
            this.LabelGameEndSelected.TabIndex = 5;
            this.LabelGameEndSelected.Text = "▶";
            this.LabelGameEndSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelGameEndSelected.Visible = false;
            // 
            // LabelRankingSelected
            // 
            this.LabelRankingSelected.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelRankingSelected.ForeColor = System.Drawing.Color.White;
            this.LabelRankingSelected.Location = new System.Drawing.Point(140, 430);
            this.LabelRankingSelected.Name = "LabelRankingSelected";
            this.LabelRankingSelected.Size = new System.Drawing.Size(30, 30);
            this.LabelRankingSelected.TabIndex = 7;
            this.LabelRankingSelected.Text = "▶";
            this.LabelRankingSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelRankingSelected.Visible = false;
            // 
            // LabelRanking
            // 
            this.LabelRanking.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelRanking.ForeColor = System.Drawing.Color.White;
            this.LabelRanking.Location = new System.Drawing.Point(3, 430);
            this.LabelRanking.Name = "LabelRanking";
            this.LabelRanking.Size = new System.Drawing.Size(470, 30);
            this.LabelRanking.TabIndex = 6;
            this.LabelRanking.Text = "RANKING";
            this.LabelRanking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.LabelRankingSelected);
            this.Controls.Add(this.LabelRanking);
            this.Controls.Add(this.LabelGameEndSelected);
            this.Controls.Add(this.LabelGameStartSelected);
            this.Controls.Add(this.LabelGameEnd);
            this.Controls.Add(this.LabelGameStart);
            this.Controls.Add(this.LabelCopyright);
            this.Controls.Add(this.LabelTitle);
            this.Name = "ViewTitle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelCopyright;
        private System.Windows.Forms.Label LabelGameStart;
        private System.Windows.Forms.Label LabelGameEnd;
        private System.Windows.Forms.Label LabelGameStartSelected;
        private System.Windows.Forms.Label LabelGameEndSelected;
        private System.Windows.Forms.Label LabelRankingSelected;
        private System.Windows.Forms.Label LabelRanking;
    }
}
