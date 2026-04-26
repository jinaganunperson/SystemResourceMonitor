using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

            cpuCounter.NextValue();
            ramCounter.NextValue();
        }

        // 1초마다 실행되는 메인 타이머 함수
        private void timerResource_Tick_1(object sender, EventArgs e)
        {
            // 1. 데이터 읽기
            float cpuUsage = cpuCounter.NextValue();
            float ramAvailable = ramCounter.NextValue();

            // 8GB 기준 (필요시 수정)
            float totalRamMB = 8192;
            float ramUsed = totalRamMB - ramAvailable;
            float ramUsagePercent = (ramUsed / totalRamMB) * 100;

            // 2. UI 업데이트
            lblCPU.Text = $"CPU 사용량: {cpuUsage:F1}%";
            lblRAM.Text = $"RAM 사용량: {ramUsagePercent:F1}% ({ramUsed:N0}MB / {totalRamMB:N0}MB)";

            pgbCPU.Value = (int)Math.Min(cpuUsage, 100);
            if (ramUsagePercent >= 0 && ramUsagePercent <= 100)
            {
                pgbRAM.Value = (int)ramUsagePercent;
            }

            // 3. 추가 기능들 호출 (이름이 딱딱 맞아야 함)
            UpdateTopProcessesByMemory();
            UpdateSystemUptime();
            CheckResourceDanger(cpuUsage, ramUsagePercent);
        }

        // [기능 1] 메모리 TOP 5 업데이트
        private void UpdateTopProcessesByMemory()
        {
            try
            {
                var topMemory = Process.GetProcesses()
                    .OrderByDescending(p => {
                        try { return p.WorkingSet64; }
                        catch { return 0; }
                    })
                    .Take(5)
                    .ToList();

                lvwTopProcesses.BeginUpdate();
                lvwTopProcesses.Items.Clear();
                foreach (var p in topMemory)
                {
                    double memMB = p.WorkingSet64 / (1024.0 * 1024.0);
                    ListViewItem item = new ListViewItem(p.ProcessName);
                    item.SubItems.Add($"{memMB:F1} MB");
                    lvwTopProcesses.Items.Add(item);
                }
                lvwTopProcesses.EndUpdate();
            }
            catch { }
        }

        // [기능 2] 시스템 가동 시간 계산
        private void UpdateSystemUptime()
        {
            uint tickCount = (uint)Environment.TickCount;
            TimeSpan uptime = TimeSpan.FromMilliseconds(tickCount);

            lblUptime.Text = string.Format("가동 시간: {0}일 {1}시간 {2}분 {3}초",
                uptime.Days, uptime.Hours, uptime.Minutes, uptime.Seconds);
        }

        // [기능 3] 리소스 위험 감지 및 시각 경고
        private void CheckResourceDanger(float cpu, float ramPercent)
        {
            // CPU 색상 변경
            if (cpu >= 90) lblCPU.ForeColor = Color.Red;
            else if (cpu >= 70) lblCPU.ForeColor = Color.Orange;
            else lblCPU.ForeColor = Color.Black;

            // RAM 색상 변경
            if (ramPercent >= 90) lblRAM.ForeColor = Color.Red;
            else lblRAM.ForeColor = Color.Black;

            // 배경색 경고 (하나라도 90% 넘으면)
            if (cpu >= 90 || ramPercent >= 90)
                this.BackColor = Color.MistyRose;
            else
                this.BackColor = SystemColors.Control;
        }

        // 사용하지 않는 이벤트 (지워도 됨)
        private void Form1_Load(object sender, EventArgs e) { }
        private void timerResource_Tick(object sender, EventArgs e) { }
    }
}