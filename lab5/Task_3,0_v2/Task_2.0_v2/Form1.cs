using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2._0_v2
{
    public partial class Form1 : Form
    {
     
        RouteSwap routeSwap = new RouteSwap();
        Miulty miulty = new Miulty();
        string passwordVigener = "urevich";
        Chart chart = new Chart();
        public Form1()
        {
            
            InitializeComponent();
            richTextBox1.Text = richTextBox1.Text.ToUpper();
            chart.setDecrypt(richTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
               richTextBox2.Text = routeSwap.Snake(richTextBox1.Text, 3);
               chart.setEncrypt(richTextBox2.Text);
            }
            else
            {
                richTextBox2.Text = miulty.encrypt(richTextBox1.Text);
                chart.setEncrypt(richTextBox2.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                richTextBox2.Text = routeSwap.decrypt(richTextBox1.Text);
            }
            else
            {
                richTextBox2.Text = miulty.decrypt(richTextBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

    }
}
