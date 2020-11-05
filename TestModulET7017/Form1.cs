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

        private void butRangeMax_Click(object sender, EventArgs e)
        {
            // Включает реле и изменяет диапазон измерения
            if (!et7017.VklHighRange())
            {
                MessageBox.Show("no connection to the module", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butRangeMin_Click(object sender, EventArgs e)
        {
            //Включает диапазон на 150 мВ
           if(!et7017.VklLowhRange())
            {
                MessageBox.Show("no connection to the module", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                checkBoxChanel1.Checked = et7017.DO01;
                checkBoxChanel2.Checked = et7017.DO02;
                checkBoxChanel3.Checked = et7017.DO03;
                checkBoxChanel4.Checked = et7017.DO04;

                label5.ForeColor = System.Drawing.Color.Black;
                label5.Text = String.Format(@"Состояние дискретных 
каналов:");
            }

            catch (MyExaption ex)
            {
                label5.ForeColor = System.Drawing.Color.Red;
                label5.Text = String.Format(@"Невозможно прочитать состояние выходов. 
               " + ex.Message);
            }
            try
            {
                textBoxMinRange.Text = Convert.ToString(et7017.RangeAI1[0]);
                textBoxMaxRange.Text = Convert.ToString(et7017.RangeAI1[1]);
                switch (et7017.RangeAI1[2])
                {
                    case 0:
                        label3.Text = "Мин. мА";
                        label4.Text = "Макс. мА";
                        break;
                    case 1:
                        label3.Text = "Мин. мВ";
                        label4.Text = "Макс. мВ";
                        break;
                    case 2:
                        label3.Text = "Мин. В";
                        label4.Text = "Макс. В";
                        break;
                    default:
                        label3.Text = "Unknown";
                        label4.Text = "Unknown";
                        break;
                }
            }
            catch (MyExaption ex)
            {
                label3.Text = "Unknown";
                label4.Text = "Unknown";
                textBoxMinRange.Text = "NaN";
                textBoxMaxRange.Text = "NaN";
                label2.ForeColor = System.Drawing.Color.Red;
            }

            try
            {
                textValue.Text = String.Format("{0:f3}", et7017.AI1);
            }
            catch (Exception ex)
            {

                textValue.Text = ex.Message;
            }
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
