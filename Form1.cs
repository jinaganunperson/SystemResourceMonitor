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
        // 1. 클래스 바로 아래에 변수들을 선언합니다. (최상위문 오류 방지)
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private bool isDarkMode = false; // 다크모드 상태 저장

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

        // 메인 타이머 이벤트
        private void timerResource_Tick_1(object sender, EventArgs e)
        {
            float cpuUsage = cpuCounter.NextValue();
            float ramAvailable = ramCounter.NextValue();

            float totalRamMB = 8192;
            float ramUsed = totalRamMB - ramAvailable;
            float ramUsagePercent = (ramUsed / totalRamMB) * 100;

            lblCPU.Text = $"CPU 사용량: {cpuUsage:F1}%";
            lblRAM.Text = $"RAM 사용량: {ramUsagePercent:F1}% ({ramUsed:N0}MB / {totalRamMB:N0}MB)";

            pgbCPU.Value = (int)Math.Min(cpuUsage, 100);
            if (ramUsagePercent >= 0 && ramUsagePercent <= 100)
            {
                pgbRAM.Value = (int)ramUsagePercent;
            }

            // 기능들 호출
            UpdateTopProcessesByMemory();
            UpdateSystemUptime();
            CheckResourceDanger(cpuUsage, ramUsagePercent);
        }

        // [다크모드 버튼 클릭 이벤트]
        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode; // 상태 반전
            btnDarkMode.Text = isDarkMode ? "라이트 모드" : "다크 모드";
            ApplyDarkMode(isDarkMode);
        }

        // [테마 적용 함수]
        private void ApplyDarkMode(bool isDark)
        {
            Color backColor = isDark ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
            Color foreColor = isDark ? Color.White : Color.Black;

            this.BackColor = backColor;

            foreach (Control c in this.Controls)
            {
                if (c is ListView)
                {
                    c.BackColor = isDark ? Color.FromArgb(30, 30, 30) : Color.White;
                }
                else
                {
                    c.BackColor = backColor;
                }
                c.ForeColor = foreColor;
            }
        }

        // [가동 시간 업데이트]
        private void UpdateSystemUptime()
        {
            uint tickCount = (uint)Environment.TickCount;
            TimeSpan uptime = TimeSpan.FromMilliseconds(tickCount);
            lblUptime.Text = string.Format("가동 시간: {0}일 {1}시간 {2}분 {3}초",
                uptime.Days, uptime.Hours, uptime.Minutes, uptime.Seconds);
        }

        // [위험 감지 - 다크모드 대응 버전]
        private void CheckResourceDanger(float cpu, float ramPercent)
        {
            Color defaultColor = isDarkMode ? Color.White : Color.Black;

            lblCPU.ForeColor = (cpu >= 90) ? Color.Red : (cpu >= 70 ? Color.Orange : defaultColor);
            lblRAM.ForeColor = (ramPercent >= 90) ? Color.Red : defaultColor;

            if (cpu >= 90 || ramPercent >= 90)
                this.BackColor = Color.MistyRose;
            else
                this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : SystemColors.Control;
        }

        // [메모리 TOP 5]
        private void UpdateTopProcessesByMemory()
        {
            try
            {
                var topMemory = Process.GetProcesses()
                    .OrderByDescending(p => { try { return p.WorkingSet64; } catch { return 0; } })
                    .Take(5).ToList();

                lvwTopProcesses.BeginUpdate();
                lvwTopProcesses.Items.Clear();
                foreach (var p in topMemory)
                {
                    ListViewItem item = new ListViewItem(p.ProcessName);
                    item.SubItems.Add($"{(p.WorkingSet64 / 1024.0 / 1024.0):F1} MB");
                    lvwTopProcesses.Items.Add(item);
                }
                lvwTopProcesses.EndUpdate();
            }
            catch { }
        }

        // [작업 관리자 열기 버튼]
        private void btnOpenTaskMgr_Click(object sender, EventArgs e)
        {
            try { Process.Start("taskmgr.exe"); }
            catch { MessageBox.Show("작업 관리자를 실행할 수 없습니다."); }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 아무 내용도 적지 않아도 됩니다.
        }
    }
}