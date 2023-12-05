using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KRONOMETRE
{
    public partial class Form1 : Form
    {
        Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
        }
          
        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            stopWatch.Reset();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            Text = label1.Text;
            listBox1.Items.Add(Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopWatch.Elapsed);
        }

        private void btnDList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
