using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GraWLiterki
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count>7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Koniec gry");
                timer1.Stop();
                DialogResult result = MessageBox.Show("Chcesz zagrac ponownie?", "Koniec gry", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                    stats.Correct = 0;
                    stats.Missed = 0;
                    stats.Total = 0;
                    stats.Accuracy = 0;
                    timer1.Interval = 800;
                    listBox1.Refresh();
                    timer1.Start();
                }
            }
            
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }
            correctLabel.Text = "Prawidłowych: " + stats.Correct;
            missedLabel.Text = "Błędów: " + stats.Missed;
            totalLabel.Text = "Wszystkich: " + stats.Total;
            accuracyLabel.Text = "Dokładność: " + stats.Accuracy + "%";


        }

        
    }
}
