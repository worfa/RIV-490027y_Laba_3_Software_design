using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            label20.Text = "";
            double minOpN = 0;
            double langLevel = 0;
            try
            {
                 minOpN = double.Parse(textBox1.Text.Replace(".", ","));
                 langLevel = double.Parse(textBox2.Text.Replace(".", ","));
            } catch
            {
                label20.Text = "Недопустимые значения переменных";
            }
    
            double V = (minOpN + 2) * Math.Log(2, minOpN + 2);
            double B = (V * V) / (3000 * langLevel);
            textBox3.Text = Math.Round(V,3).ToString();
            textBox4.Text = Math.Round(B, 3).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label21.Text = "";
            double minOpN = 0;
            double numProg = 0;
            double productivity = 0;
            try
            {
                minOpN = double.Parse(textBox1.Text.Replace(".", ","));
                numProg = double.Parse(textBox5.Text.Replace(".", ","));
                productivity = double.Parse(textBox6.Text.Replace(".", ","));
            }
            catch
            {
                label21.Text = "Недопустимые значения переменных";
            }

            double K = minOpN / 8 + minOpN / (8 * 8);
            double N = 220*K+K*Math.Log(2, K);
            double V = K * 220 * Math.Log(2, 48);
            double P = 3 * N / 8;
            double T = 3 * N / (8 * numProg * productivity);
            double B = V / 3000;
            double t = T / 2 * Math.Log(10, B);

            textBox7.Text = Math.Round(K, 3).ToString();
            textBox8.Text = Math.Round(N, 3).ToString();
            textBox9.Text = Math.Round(V, 3).ToString();
            textBox10.Text = Math.Round(P, 3).ToString();
            textBox13.Text = Math.Round(T, 3).ToString();
            textBox12.Text = Math.Round(B, 3).ToString();
            textBox11.Text = Math.Round(t, 3).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label22.Text = "";
            double Vprog = 0;
            double numErr = 0;
            try
            {
                Vprog = double.Parse(textBox15.Text.Replace(".", ","));
                numErr = double.Parse(textBox16.Text.Replace(".", ","));
            }
            catch
            {
                label22.Text = "Недопустимые значения переменных";
            }
            int index = dataGridView1.Rows.Count;
            if (index < 6)this.dataGridView1.Rows.Add( index, Vprog, numErr);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Count - 1;
            double Ri = Rating(index);
            textBox19.Text = Math.Round(Ri, 3).ToString();
        }

        private double Rating(int index)
        {
            int i = index;
            if (i == 0) return 1000;

            double Vj = 0; 
            for(int j = 1; j <= index; j++)
            {
                Vj +=Convert.ToDouble(dataGridView1.Rows[j-1].Cells[1].Value.ToString());
            }

            double Bc =0; 
            for(int k = 1; k <=i; k++)
            {
                double v = 1/Rating(k - 1) + 1/double.Parse(textBox14.Text.Replace(".", ","));
                Bc += Convert.ToDouble(dataGridView1.Rows[k - 1].Cells[1].Value.ToString()) * v;
            }

            double Ri = Rating(i - 1) * (1 + 0.001 *(Vj - Bc));
            return Ri;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label22.Text = "";
            double Vprog = 0;
            double B = 0;
            double v = double.Parse(textBox14.Text.Replace(".", ","));
            double R = double.Parse(textBox19.Text.Replace(".", ","));

            try
            {
                Vprog = double.Parse(textBox17.Text.Replace(".", ","));
              
            }
            catch
            {
                label22.Text = "Недопустимые значения переменных";
            }
            B = Vprog* (1/v + 1/R);
            textBox18.Text = Math.Round(B, 2).ToString();
        }
    }
}
