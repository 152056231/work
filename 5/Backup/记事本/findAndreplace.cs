using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class findAndreplace : Form
    {
        public FrmMain mainForm;
        public string f1text; //要查找的文本内容
        public string ktext;  //查找的关键字
        bool oneF = true;

        public findAndreplace()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.richTextBox1.SelectionStart = 0;
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
                f1text=this.mainForm.richTextBox1.Text;
                ktext = textBox1.Text;
            }
            else  //不区分大小写
            {
                f1text = this.mainForm.richTextBox1.Text.ToLower();
                ktext = textBox1.Text.ToLower();
            }

            //开始查找
            int temp = f1text.IndexOf(ktext, mainForm.richTextBox1.SelectionStart + mainForm.richTextBox1.SelectedText.Length); //查找位置
           
            if (temp >= 0)
            {
                this.mainForm.richTextBox1.Select(temp, ktext.Length);
                this.mainForm.richTextBox1.ScrollToCaret();
                this.mainForm.Focus();
                oneF = true;
            }
            else
            {
                while (oneF)
                {
                    MessageBox.Show("向下找不到-\"" + ktext + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    oneF= false;
                    this.mainForm.richTextBox1.SelectionStart = 0;
                    temp = -1;
                    break;
                }
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)   //替换
        {
            
            if (textBox1.Text == this.mainForm.richTextBox1.SelectedText)  //如果文本框选定内容与关键字相同才替换
            {
                this.mainForm.richTextBox1.SelectedText = textBox2.Text;
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
                f1text = this.mainForm.richTextBox1.Text;
                ktext = textBox1.Text;
            }
            else  //不区分大小写
            {
                f1text = this.mainForm.richTextBox1.Text.ToLower();
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
                    try  //只好用异常
                    {
                        temp = f1text.IndexOf(ktext, this.mainForm.richTextBox1.SelectionStart + this.mainForm.richTextBox1.SelectedText.Length);
                    }
                    catch
                    {
                        temp = -1;
                    }
                }

                if (temp >= 0)
                {
                    this.mainForm.richTextBox1.Select(temp, ktext.Length);
                    this.mainForm.richTextBox1.ScrollToCaret();
                    this.mainForm.Focus();
                    i++;
                }


                if (this.mainForm.richTextBox1.SelectedText.Length > 0)
                {
                    
                    button2.PerformClick();  //替换
                }
                else
                {
                    break;
                }             
            }
            this.TopMost = false;
            MessageBox.Show("一共替换了" + i + "个位置", "替换结果", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            this.TopMost = true;
            
        }

    }
}