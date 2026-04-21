using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // CPU 카운터 설정 (전체 프로세서의 사용 시간 %)
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // RAM 카운터 설정 (사용 가능한 메가바이트 단위)
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        private void timerResource_Tick(object sender, EventArgs e)
        {
            // 1. 데이터 읽기
            float cpuUsage = cpuCounter.NextValue();
            float ramAvailable = ramCounter.NextValue();

            // 2. 화면 갱신 (숫자 표시)
            lblCPU.Text = $"CPU 사용량: {cpuUsage:F1}%";
            lblRAM.Text = $"사용 가능한 RAM: {ramAvailable:N0} MB";

            // 3. 프로그레스바 업데이트
            pgbCPU.Value = (int)cpuUsage;

            // RAM은 전체 용량 대비 남은 용량을 계산해야 하므로 일단 수치만 표시하거나 
            // 최대치를 설정해두고 사용량으로 환산해서 넣으세요.
        }

        private void timerResource_Tick_1(object sender, EventArgs e)
        {
            // 1. 데이터 읽기
            float cpuUsage = cpuCounter.NextValue();
            float ramAvailable = ramCounter.NextValue();

            // 2. 화면 갱신 (숫자 표시)
            lblCPU.Text = $"CPU 사용량: {cpuUsage:F1}%";
            lblRAM.Text = $"사용 가능한 RAM: {ramAvailable:N0} MB";

            // 3. 프로그레스바 업데이트
            pgbCPU.Value = (int)cpuUsage;

            // RAM은 전체 용량 대비 남은 용량을 계산해야 하므로 일단 수치만 표시하거나 
            // 최대치를 설정해두고 사용량으로 환산해서 넣으세요.
        }
    }
}
