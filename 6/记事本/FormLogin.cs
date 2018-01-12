using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class FormLogin : Form
    {
        int i = 0;
        int j = 0;
        public FormLogin()
        {
            InitializeComponent();
            for (int count = 0; count <= 1; count++)
            {
                if (count == 0)
                {
                    if (textBox1.Text == "")
                    {
                        textBox1.Text = "Username";
                    }
                    if (textBox2.Text == "")
                    {
                        textBox2.Text = "Password";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlOperator sql = new SqlOperator();
            sql.Login(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlOperator sql = new SqlOperator();
            sql.Register(textBox1.Text, textBox2.Text);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (0 == i)
            {
                textBox1.Text = "";
                i += 1;
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (0 == j)
            {
                textBox2.Text = "";
                j += 1;
            }
        }
    }
}
