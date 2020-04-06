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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Chart chart = new Chart();
            string defaultAlphabet = "AÄBCDEFGHIJKLMNOÖPQRSßTUÜVWXYZ.,?!-()«»:;+/0123456789";
            string noEncrypt = chart.getDecrypt();
            string encrypt = chart.getEncrypt();
            for (int i = 0; i < defaultAlphabet.Length; i++)
                chart1.Series["No encrypt"].Points.AddXY($"{defaultAlphabet[i]}", noEncrypt.ToCharArray().Where(c => c == defaultAlphabet[i]).Count());
            for (int i = 0; i < defaultAlphabet.Length; i++)
                chart2.Series["Encrypt"].Points.AddXY($"{defaultAlphabet[i]}", encrypt.ToCharArray().Where(c => c == defaultAlphabet[i]).Count());
        }
    }
}
