namespace Tetris.Views
{
    partial class ViewGame
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
            this.PanelScore = new System.Windows.Forms.Panel();
            this.LabelScoreValue = new System.Windows.Forms.Label();
            this.LabelScoreName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelLevelValue = new System.Windows.Forms.Label();
            this.LabelLevelTitle = new System.Windows.Forms.Label();
            this.blockPanel1 = new Tetris.Controls.BlockPanel();
            this.BlockPanel = new Tetris.Controls.BlockPanel();
            this.NextBlockPanel1 = new Tetris.Controls.NextBlockPanel();
            this.NextBlockPanel2 = new Tetris.Controls.NextBlockPanel();
            this.NextBlockPanel3 = new Tetris.Controls.NextBlockPanel();
            this.PanelNext = new System.Windows.Forms.Panel();
            this.LabelNext = new System.Windows.Forms.Label();
            this.PanelScore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelNext.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelScore
            // 
            this.PanelScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelScore.Controls.Add(this.LabelScoreValue);
            this.PanelScore.Controls.Add(this.LabelScoreName);
            this.PanelScore.ForeColor = System.Drawing.Color.White;
            this.PanelScore.Location = new System.Drawing.Point(110, 4);
            this.PanelScore.Name = "PanelScore";
            this.PanelScore.Size = new System.Drawing.Size(150, 70);
            this.PanelScore.TabIndex = 0;
            // 
            // LabelScoreValue
            // 
            this.LabelScoreValue.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelScoreValue.Location = new System.Drawing.Point(3, 39);
            this.LabelScoreValue.Name = "LabelScoreValue";
            this.LabelScoreValue.Size = new System.Drawing.Size(142, 29);
            this.LabelScoreValue.TabIndex = 1;
            this.LabelScoreValue.Text = "0";
            this.LabelScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelScoreName
            // 
            this.LabelScoreName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelScoreName.Location = new System.Drawing.Point(3, 0);
            this.LabelScoreName.Name = "LabelScoreName";
            this.LabelScoreName.Size = new System.Drawing.Size(142, 39);
            this.LabelScoreName.TabIndex = 0;
            this.LabelScoreName.Text = "SCORE";
            this.LabelScoreName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LabelLevelValue);
            this.panel1.Controls.Add(this.LabelLevelTitle);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(110, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 70);
            this.panel1.TabIndex = 2;
            // 
            // LabelLevelValue
            // 
            this.LabelLevelValue.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelLevelValue.Location = new System.Drawing.Point(3, 39);
            this.LabelLevelValue.Name = "LabelLevelValue";
            this.LabelLevelValue.Size = new System.Drawing.Size(142, 29);
            this.LabelLevelValue.TabIndex = 1;
            this.LabelLevelValue.Text = "1";
            this.LabelLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLevelTitle
            // 
            this.LabelLevelTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelLevelTitle.Location = new System.Drawing.Point(3, 9);
            this.LabelLevelTitle.Name = "LabelLevelTitle";
            this.LabelLevelTitle.Size = new System.Drawing.Size(142, 23);
            this.LabelLevelTitle.TabIndex = 0;
            this.LabelLevelTitle.Text = "LEVEL";
            this.LabelLevelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blockPanel1
            // 
            this.blockPanel1.FallingTetromino = null;
            this.blockPanel1.Location = new System.Drawing.Point(85, 75);
            this.blockPanel1.Name = "blockPanel1";
            this.blockPanel1.Size = new System.Drawing.Size(200, 400);
            this.blockPanel1.TabIndex = 3;
            // 
            // BlockPanel
            // 
            this.BlockPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlockPanel.FallingTetromino = null;
            this.BlockPanel.Location = new System.Drawing.Point(81, 163);
            this.BlockPanel.Margin = new System.Windows.Forms.Padding(10);
            this.BlockPanel.Name = "BlockPanel";
            this.BlockPanel.Size = new System.Drawing.Size(200, 400);
            this.BlockPanel.TabIndex = 3;
            // 
            // NextBlockPanel1
            // 
            this.NextBlockPanel1.Location = new System.Drawing.Point(6, 83);
            this.NextBlockPanel1.Name = "NextBlockPanel1";
            this.NextBlockPanel1.Size = new System.Drawing.Size(100, 100);
            this.NextBlockPanel1.TabIndex = 4;
            // 
            // NextBlockPanel2
            // 
            this.NextBlockPanel2.Location = new System.Drawing.Point(6, 189);
            this.NextBlockPanel2.Name = "NextBlockPanel2";
            this.NextBlockPanel2.Size = new System.Drawing.Size(100, 100);
            this.NextBlockPanel2.TabIndex = 5;
            // 
            // NextBlockPanel3
            // 
            this.NextBlockPanel3.Location = new System.Drawing.Point(6, 295);
            this.NextBlockPanel3.Name = "NextBlockPanel3";
            this.NextBlockPanel3.Size = new System.Drawing.Size(100, 100);
            this.NextBlockPanel3.TabIndex = 6;
            // 
            // PanelNext
            // 
            this.PanelNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelNext.Controls.Add(this.NextBlockPanel3);
            this.PanelNext.Controls.Add(this.LabelNext);
            this.PanelNext.Controls.Add(this.NextBlockPanel2);
            this.PanelNext.Controls.Add(this.NextBlockPanel1);
            this.PanelNext.ForeColor = System.Drawing.Color.White;
            this.PanelNext.Location = new System.Drawing.Point(294, 163);
            this.PanelNext.Name = "PanelNext";
            this.PanelNext.Size = new System.Drawing.Size(110, 400);
            this.PanelNext.TabIndex = 2;
            // 
            // LabelNext
            // 
            this.LabelNext.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelNext.Location = new System.Drawing.Point(3, 0);
            this.LabelNext.Name = "LabelNext";
            this.LabelNext.Size = new System.Drawing.Size(102, 39);
            this.LabelNext.TabIndex = 0;
            this.LabelNext.Text = "NEXT";
            this.LabelNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.PanelNext);
            this.Controls.Add(this.BlockPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelScore);
            this.Name = "ViewGame";
            this.PanelScore.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanelNext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelScore;
        private System.Windows.Forms.Label LabelScoreValue;
        private System.Windows.Forms.Label LabelScoreName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelLevelValue;
        private System.Windows.Forms.Label LabelLevelTitle;
        private Controls.BlockPanel blockPanel1;
        private Controls.BlockPanel BlockPanel;
        private Controls.NextBlockPanel NextBlockPanel1;
        private Controls.NextBlockPanel NextBlockPanel2;
        private Controls.NextBlockPanel NextBlockPanel3;
        private System.Windows.Forms.Panel PanelNext;
        private System.Windows.Forms.Label LabelNext;
    }
}
