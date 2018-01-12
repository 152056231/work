using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 记事本
{
    public partial class finder : Form
    {
        public FormMain mainForm;
        public string f1text; //要查找的文本内容
        public string ktext;  //查找的关键字

        public finder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)  //区分大小写
            {
                f1text = this.mainForm.richTextBox1.Text; 
                ktext = textBox1.Text;
                this.mainForm.f1ktext = textBox1.Text;
                this.mainForm.maxmin = true;
            }
            else  //不区分大小写
            {
                f1text = this.mainForm.richTextBox1.Text.ToLower(); 
                ktext = textBox1.Text.ToLower();
                this.mainForm.f1ktext = textBox1.Text;
                this.mainForm.maxmin = false;
            }

            if (radioButton2.Checked) //向下查找
            {
                int temp = f1text.IndexOf(ktext,mainForm.richTextBox1.SelectionStart+mainForm.richTextBox1.SelectedText.Length); //查找位置

                if (temp >= 0)
                {
                    this.mainForm.richTextBox1.Select(temp, ktext.Length);
                    this.mainForm.richTextBox1.ScrollToCaret();
                    this.mainForm.Focus();
                }
                else
                {
                    MessageBox.Show(" 找不到\""+ktext+"\" 可换一下方向.比如:向上或向下      ","提示",MessageBoxButtons.OK,MessageBoxIcon.Question);
                }

            }
            else  //向上查找
            {
                int temp = -1;
                if(mainForm.richTextBox1.SelectionStart>1)
                    temp = f1text.LastIndexOf(ktext, mainForm.richTextBox1.SelectionStart-1); //查找位置

                if (temp >= 0)
                {
                    this.mainForm.richTextBox1.Select(temp, ktext.Length);
                    this.mainForm.richTextBox1.ScrollToCaret();
                    this.mainForm.Focus();
                }
                else
                {
                    MessageBox.Show("找不到\"" + ktext + "\"可换一下方向.比如:向下或向上      ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }

        }

        private void finder_Load(object sender, EventArgs e)
        {

        }
    }
}