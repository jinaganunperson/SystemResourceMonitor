namespace Pr
{
    public partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvwTopProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUptime = new System.Windows.Forms.Label();
            this.btnOpenTaskMgr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRAM
            // 
            this.lblRAM.AutoSize = true;
            this.lblRAM.Location = new System.Drawing.Point(53, 100);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(58, 24);
            this.lblRAM.TabIndex = 0;
            this.lblRAM.Text = "RAM";
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Location = new System.Drawing.Point(53, 166);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(55, 24);
            this.lblCPU.TabIndex = 1;
            this.lblCPU.Text = "CPU";
            // 
            // pgbRAM
            // 
            this.pgbRAM.Location = new System.Drawing.Point(335, 100);
            this.pgbRAM.MarqueeAnimationSpeed = 8192;
            this.pgbRAM.Name = "pgbRAM";
            this.pgbRAM.Size = new System.Drawing.Size(755, 41);
            this.pgbRAM.TabIndex = 2;
            // 
            // pgbCPU
            // 
            this.pgbCPU.Location = new System.Drawing.Point(335, 166);
            this.pgbCPU.Name = "pgbCPU";
            this.pgbCPU.Size = new System.Drawing.Size(755, 41);
            this.pgbCPU.TabIndex = 3;
            // 
            // timerResource
            // 
            this.timerResource.Enabled = true;
            this.timerResource.Interval = 1000;
            this.timerResource.Tick += new System.EventHandler(this.timerResource_Tick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "System Resource Monitor";
            // 
            // lvwTopProcesses
            // 
            this.lvwTopProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwTopProcesses.HideSelection = false;
            this.lvwTopProcesses.Location = new System.Drawing.Point(57, 244);
            this.lvwTopProcesses.Name = "lvwTopProcesses";
            this.lvwTopProcesses.Size = new System.Drawing.Size(1032, 303);
            this.lvwTopProcesses.TabIndex = 5;
            this.lvwTopProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwTopProcesses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "프로세스명";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CPU (%)";
            this.columnHeader2.Width = 80;
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(758, 32);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(106, 24);
            this.lblUptime.TabIndex = 6;
            this.lblUptime.Text = "가동시간";
            // 
            // btnOpenTaskMgr
            // 
            this.btnOpenTaskMgr.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenTaskMgr.Location = new System.Drawing.Point(580, 23);
            this.btnOpenTaskMgr.Name = "btnOpenTaskMgr";
            this.btnOpenTaskMgr.Size = new System.Drawing.Size(150, 43);
            this.btnOpenTaskMgr.TabIndex = 7;
            this.btnOpenTaskMgr.Text = "작업 관리자";
            this.btnOpenTaskMgr.UseVisualStyleBackColor = false;
            this.btnOpenTaskMgr.Click += new System.EventHandler(this.btnOpenTaskMgr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 563);
            this.Controls.Add(this.btnOpenTaskMgr);
            this.Controls.Add(this.lblUptime);
            this.Controls.Add(this.lvwTopProcesses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgbCPU);
            this.Controls.Add(this.pgbRAM);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.lblRAM);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.ProgressBar pgbRAM;
        private System.Windows.Forms.ProgressBar pgbCPU;
        private System.Windows.Forms.Timer timerResource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwTopProcesses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Button btnOpenTaskMgr;
    }
}

