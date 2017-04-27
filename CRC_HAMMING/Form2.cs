using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRC_HAMMING
{
    public partial class Form2 : Form
    {
        int generateTextCount = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                generateTextCount = Convert.ToInt16(textBox1.Text);
            }
            catch(Exception ee)
            {
                MessageBox.Show("Błąd. Wpisz poprawną liczbę");
            }
        }

        private String generateText(int count)
        {
            string txtToReturn = "";
            Random random = new Random();
            for(int i = 0; i < count; i++)
            {
                txtToReturn += random.Next(0, 2);
            }
            return txtToReturn;
        }
    }
}
