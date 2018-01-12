using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class Form4 : Form
    {
        public Form1 mainForm;

        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           if (int.Parse(textBox1.Text) > this.mainForm.textBox1.Lines.Length)
            {
                MessageBox.Show("行数超过范围", "记事本　－　跳行");
                //MessageBox.Show(this.mainForm.textBox1.Lines.Length.ToString());
            }
            else
            {
                int temp=0;
                for (int i = 0; i < int.Parse(textBox1.Text) - 1; i++)
                {
                    temp = temp + this.mainForm.textBox1.Lines[i].Length+1;
                }
                temp = temp + 2;
                this.mainForm.textBox1.SelectionStart =temp;
                this.mainForm.Focus();

            }
        }
    }
}