namespace Pr
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblRAM = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.pgbRAM = new System.Windows.Forms.ProgressBar();
            this.pgbCPU = new System.Windows.Forms.ProgressBar();
            this.timerResource = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(180, 106);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(58, 24);
            this.lblRAM.TabIndex = 0;
            this.lblRAM.Text = "RAM";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(180, 172);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(55, 24);
            this.lblCPU.TabIndex = 1;
            this.lblCPU.Text = "CPU";
            // 
            // pgbRAM
            // 
            this.pgbRAM.Location = new System.Drawing.Point(268, 106);
            this.pgbRAM.Name = "pgbRAM";
            this.pgbRAM.Size = new System.Drawing.Size(755, 41);
            this.pgbRAM.TabIndex = 2;
            // 
            // pgbCPU
            // 
            this.pgbCPU.Location = new System.Drawing.Point(268, 172);
            this.pgbCPU.Name = "pgbCPU";
            this.pgbCPU.Size = new System.Drawing.Size(755, 41);
            this.pgbCPU.TabIndex = 3;
            // 
            // timerResource
            // 
            this.timerResource.Enabled = true;
            this.timerResource.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 700);
            this.Controls.Add(this.pgbCPU);
            this.Controls.Add(this.pgbRAM);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.lblRAM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.ProgressBar pgbRAM;
        private System.Windows.Forms.ProgressBar pgbCPU;
        private System.Windows.Forms.Timer timerResource;
    }
}

