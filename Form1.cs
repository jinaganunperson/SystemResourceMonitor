using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq; // LINQ는 맨 위에 있어야 합니다.
using System.Windows.Forms;

namespace Pr
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        public Form1()
        {
            InitializeComponent();
            SetupCounters();
        }

        private void SetupCounters()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            // 초기값 0 방지를 위해 한 번씩 미리 호출
            cpuCounter.NextValue();
            ramCounter.NextValue();
        }

        private void timerResource_Tick(object sender, EventArgs e)
        {
            
        }

        // 메모리 많이 쓰는 순서대로 TOP 5 가져오기
        private void UpdateTopProcessesByMemory()
        {
            try
            {
                var topMemory = Process.GetProcesses()
                    .OrderByDescending(p => {
                        try { return p.WorkingSet64; } // 메모리 사용량 기준
                        catch { return 0; }
                    })
                    .Take(5)
                    .ToList();

                lvwTopProcesses.BeginUpdate();
                lvwTopProcesses.Items.Clear(); // 리스트뷰 이름 확인하세요!
                foreach (var p in topMemory)
                {
                    double memMB = p.WorkingSet64 / (1024.0 * 1024.0);
                    ListViewItem item = new ListViewItem(p.ProcessName);
                    item.SubItems.Add($"{memMB:F1} MB");
                    lvwTopProcesses.Items.Add(item);
                }
                lvwTopProcesses.EndUpdate();
            }
            catch { /* 접근 거부된 프로세스는 무시 */ }
        }

        private void timerResource_Tick_1(object sender, EventArgs e)
        {
            // 1. 시스템 전체 리소스 데이터 읽기
            float cpuUsage = cpuCounter.NextValue();
            float ramAvailable = ramCounter.NextValue();

            // 8GB 기준 (윤서님 사양에 맞게 조정하세요)
            float totalRamMB = 8192;
            float ramUsed = totalRamMB - ramAvailable;
            float ramUsagePercent = (ramUsed / totalRamMB) * 100;

            // 2. UI 업데이트 (상단 숫자 및 프로그레스바)
            lblCPU.Text = $"CPU 사용량: {cpuUsage:F1}%";
            lblRAM.Text = $"RAM 사용량: {ramUsagePercent:F1}% ({ramUsed:N0}MB / {totalRamMB:N0}MB)";

            pgbCPU.Value = (int)Math.Min(cpuUsage, 100); // 100 초과 방지
            if (ramUsagePercent >= 0 && ramUsagePercent <= 100)
            {
                pgbRAM.Value = (int)ramUsagePercent;
            }

            // 3. 프로세스 TOP 5 업데이트 함수 호출
            UpdateTopProcessesByMemory();
        }

            private void CheckResourceDanger(float cpu, float ramPercent)
            {
            // CPU 위험 감지 (90% 이상)
            if (cpu >= 90)
            {
                lblCPU.ForeColor = Color.Red; // 글자색 빨강
                pgbCPU.ForeColor = Color.Red; // 프로그레스바 색상 (컴포넌트 설정에 따라 다름)
            }
            else if (cpu >= 70)
            {
                lblCPU.ForeColor = Color.Orange; // 주의 단계
            }
            else
            {
                lblCPU.ForeColor = Color.Black; // 정상
            }

            // RAM 위험 감지 (90% 이상)
            if (ramPercent >= 90)
            {
                lblRAM.ForeColor = Color.Red;
            }
            else
            {
                lblRAM.ForeColor = Color.Black;
            }

            if (cpu >= 90 || ramPercent >= 90)
            {
                // 배경색을 연한 빨강으로 변경하여 긴급 상황 표시
                this.BackColor = Color.MistyRose;
            }
            else
            {
                // 다시 기본 시스템 배경색으로 복구
                this.BackColor = SystemColors.Control;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}