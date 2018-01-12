using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class Next : Form
    {
        public FormMain mainForm;

        public Next()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
      try
       {
         if (int.Parse(textBox1.Text) > this.mainForm.richTextBox1.Lines.Length)
            {
                MessageBox.Show(int.Parse(textBox1.Text)+"行数超过范围   ", "记事本　－　跳行",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Focus();
                textBox1.SelectAll();
                
         
         }
            else
            {
                int temp=0;
                for (int i = 0; i < int.Parse(textBox1.Text) - 1; i++)
                {
                    temp = temp + this.mainForm.richTextBox1.Lines[i].Length+1;
                }
                temp = temp + 2;
                this.mainForm.richTextBox1.SelectionStart =temp;
                this.mainForm.Focus();

            }
         }
            catch (Exception)
            {
                textBox1.Text = "0";
                textBox1.Focus();
            }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            { 
                textBox1.Focus();
                textBox1.SelectAll();
                this.button1.Enabled = false;
                MessageBox.Show(e.KeyChar.ToString()+" 这是 行吗??,请输入一个合式的行数","错误",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                
                
               

            }
            else
            {
                this.button1.Enabled = true;
            }
            
        }

        private void Next_Load(object sender, EventArgs e)
        {

        }
    }
}