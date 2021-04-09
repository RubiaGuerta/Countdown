using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        System.Timers.Timer tempo;
        int hora, minuto, segundo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tempo = new System.Timers.Timer();
            tempo.Interval = 1000;
            tempo.Elapsed += tempoEvento;
        }

        private void tempoEvento(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                segundo += 1;
                if (segundo == 60)
                {
                    segundo = 0;
                    minuto += 1;
                }
                if (minuto == 60)
                {
                    minuto = 0;
                    hora += 1;
                }
                txtResult.Text = string.Format("{0}:{1}:{2}", hora.ToString().PadLeft(2, '0'), minuto.ToString().PadLeft(2, '0'), segundo.ToString().PadLeft(2, '0'));
            }
            ));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tempo.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tempo.Stop();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempo.Stop();
            Application.DoEvents();
        }
    }
}
