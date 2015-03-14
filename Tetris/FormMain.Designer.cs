namespace Tetris
{
    partial class FormMain
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerProcess = new System.Windows.Forms.Timer(this.components);
            this.PanelView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TimerProcess
            // 
            this.TimerProcess.Enabled = true;
            this.TimerProcess.Interval = 16;
            this.TimerProcess.Tick += new System.EventHandler(this.TimerProcess_Tick);
            // 
            // PanelView
            // 
            this.PanelView.Location = new System.Drawing.Point(12, 12);
            this.PanelView.Name = "PanelView";
            this.PanelView.Size = new System.Drawing.Size(476, 576);
            this.PanelView.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.PanelView);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Text = "Tetris";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerProcess;
        private System.Windows.Forms.Panel PanelView;
    }
}

