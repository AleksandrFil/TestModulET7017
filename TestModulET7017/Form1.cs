using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestModulET7017
{
    public partial class Form1 : Form
    {
        Device_ET7017 et7017 = new Device_ET7017();

        public Form1()
        {
            InitializeComponent();
        }

        private void butDiapozon_Click(object sender, EventArgs e)
        {
            /// Включает реле и изменяет диапазон измерения
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (et7017.Connecting() >= 0)
            {
                //Включение таймера по опросу и выводу на панель.
                timerOprosa.Start();
            }
            else
            {
                Thread.Sleep(2000);
                timerOprosa.Start();
            }
        }

        private void timerOprosa_Tick(object sender, EventArgs e)
        {
            LoockMessage(Convert.ToString(et7017.MessageConnect));
        }

        private async void LoockMessage(string message)
        {
            if (message.Count() > 10)
            {
                await Task.Delay(1000);
                toolStripStatusLabelConnect.Text = message.Remove(0, 10);
                
            }
        }
    }
}
