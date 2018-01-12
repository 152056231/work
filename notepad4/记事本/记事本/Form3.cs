using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class Form3 : Form
    {
        public Form1 mainForm;
        public string f1text; //要查找的文本内容
        public string ktext;  //查找的关键字

        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)  //如果关键字大于0，按钮可用
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else  //按钮不可用
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)   //退出
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e) //查找下一个
        {
           
            if (checkBox1.Checked)  //区分大小写
            {
                f1text=this.mainForm.textBox1.Text;
                ktext = textBox1.Text;
            }
            else  //不区分大小写
            {
                f1text = this.mainForm.textBox1.Text.ToLower();
                ktext = textBox1.Text.ToLower();
            }

            //开始查找
            int temp = f1text.IndexOf(ktext, mainForm.textBox1.SelectionStart + mainForm.textBox1.SelectedText.Length); //查找位置

            if (temp >= 0)
            {
                this.mainForm.textBox1.Select(temp, ktext.Length);
                this.mainForm.textBox1.ScrollToCaret();
                this.mainForm.Focus();
            }
            else
            {
                MessageBox.Show("找不到\"" + ktext + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            //
        }

        private void button2_Click(object sender, EventArgs e)   //替换
        {
            if (textBox1.Text == this.mainForm.textBox1.SelectedText)  //如果文本框选定内容与关键字相同才替换
            {
                this.mainForm.textBox1.SelectedText = textBox2.Text;
            }
            else        //不相同就重新查找
            {
                button1.PerformClick(); 
            }


        }

        private void button3_Click(object sender, EventArgs e) //全部替换
        {
            int i=0; //存替换了多少个            

            if (checkBox1.Checked)  //区分大小写
            {
                f1text = this.mainForm.textBox1.Text;
                ktext = textBox1.Text;
            }
            else  //不区分大小写
            {
                f1text = this.mainForm.textBox1.Text.ToLower();
                ktext = textBox1.Text.ToLower();
            }

            while (true) //开始替换
            {
                int temp=-1; //找到的位置

                if (i == 0)
                {
                    temp = f1text.IndexOf(ktext, 0);
                }
                else
                {
                    try  //～～只好用异常
                    {
                        temp = f1text.IndexOf(ktext, this.mainForm.textBox1.SelectionStart + this.mainForm.textBox1.SelectedText.Length);
                    }
                    catch
                    {
                        break;
                    }
                }

                if (temp >= 0)
                {
                    this.mainForm.textBox1.Select(temp, ktext.Length);
                    this.mainForm.textBox1.ScrollToCaret();
                    this.mainForm.Focus();
                    i++;
                }


                if (this.mainForm.textBox1.SelectedText.Length > 0)
                {
                    button2.PerformClick();  //替换
                }
                else
                {
                    break;
                }             
            }

            MessageBox.Show("一共替换了" + i + "个位置", "替换结果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

    }
}