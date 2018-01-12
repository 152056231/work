using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 记事本
{
    public partial class Form1 : Form
    {
        public string filename=null; //打开的文件名
        public bool istext = false; //文本框是否改变
        public string f1ktext = null; //是否有关键字
        public bool maxmin; //区分大小

        public Form1()
        {
            InitializeComponent();
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文档(*.txt)|*.txt";
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Title = "保存文件";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,false,Encoding.Default);
                sw.Write(textBox1.Text);
                sw.Close();

                string[] filename2 = saveFileDialog1.FileName.Split('\\');
                this.Text = filename2[filename2.Length - 1] + " - 记事本";
                this.istext = false;
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 撤消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
            
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.mainForm = this;
            f2.Show();
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.mainForm = this;
            f3.Show();
        }



        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked==true)  //是否显示状态栏
                statusStrip1.Visible = true;
            else
                statusStrip1.Visible =false;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();　　//退出程序
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动换行ToolStripMenuItem.Checked == true)  //是否自动换行
                textBox1.WordWrap = true;
            else
                textBox1.WordWrap = false;
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();  //复制文本
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();　//粘贴文本
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";　　//删除文本
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)  //打开字体对话框
            {
                textBox1.Font = fontDialog1.Font;  //设置字体
                
            }

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.istext==false) //判断文本框是否改变
            {
                openFileDialog1.Filter = "文本文档(*.txt)|*.txt|所有文件(*.*)|*.*";
                openFileDialog1.FileName = "*.txt";
                openFileDialog1.Title = "打开文件";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    string[] filename2 = filename.Split('\\');  //只取文件名
                    StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    this.istext = false;
                    this.Text = filename2[filename2.Length-1]+" - 记事本";
                }
            }
            else
            {
                DialogResult dr=MessageBox.Show("文本已更改，是否保存?","提示",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                
                if (dr==DialogResult.Yes)
                {
                   // MessageBox.Show(dr.ToString());
                    this.保存ToolStripMenuItem.PerformClick();
                    this.打开ToolStripMenuItem.PerformClick();
                }
                else if (dr == DialogResult.No)
                {
                    this.istext = false;
                    this.打开ToolStripMenuItem.PerformClick();
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != null) //是否打开过文件？
            {
                StreamWriter sw = new StreamWriter(filename,false,Encoding.Default);
                sw.Write(textBox1.Text);
                sw.Close();
                this.istext = false;                
            }
            else  //不然就另存为
            {
                this.另存为ToolStripMenuItem.PerformClick();
            }
        }
            
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.istext)
            {
                DialogResult dr = MessageBox.Show("文本已更改，是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    this.保存ToolStripMenuItem.PerformClick();
                    this.新建ToolStripMenuItem.PerformClick();
                }
                else if (dr == DialogResult.No)
                {
                    textBox1.Clear();
                    this.Text = "无标题 - 记事本";
                    this.istext = false;
                    this.filename = null;
                }
            }
            else
            {
                textBox1.Clear();
                this.Text = "无标题 - 记事本";
                this.istext = false;
                this.filename = null;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.istext = true;   //文本框改变
        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(DateTime.Now.ToString()); //在文本框后面追加 时间日期
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.新建ToolStripMenuItem.PerformClick();
        }
        


        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))     //是否有可粘贴文本         
                this.粘贴ToolStripMenuItem.Enabled = true;
            else
                this.粘贴ToolStripMenuItem.Enabled = false;

            if (textBox1.CanUndo)                           //是否可以撤消
                this.撤消ToolStripMenuItem.Enabled = true;                
            else
                this.撤消ToolStripMenuItem.Enabled = false;////////

            if (textBox1.SelectedText.Length > 0)  //是否可以剪切、复制、删除
            {
                this.剪切ToolStripMenuItem.Enabled = true;
                this.复制ToolStripMenuItem.Enabled = true;
                this.删除ToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.剪切ToolStripMenuItem.Enabled = false;
                this.复制ToolStripMenuItem.Enabled = false;
                this.删除ToolStripMenuItem.Enabled = false;

            } /////////////


            if (textBox1.Text.Length > 0)   //没有文本的情况下查找、替换不可用
            {
                this.查找ToolStripMenuItem.Enabled = true;
                this.查找下一个ToolStripMenuItem.Enabled = true;
                this.替换ToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.查找ToolStripMenuItem.Enabled = false;
                this.查找下一个ToolStripMenuItem.Enabled =false;
                this.替换ToolStripMenuItem.Enabled = false;
            }/////////////
        }

        private void 查找下一个ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f1ktext == null)
            {
                this.查找ToolStripMenuItem.PerformClick();
            }
            else
            {
                string f1text;
                string ktext;

                    if (maxmin)  //区分大小写
                    {
                        f1text = textBox1.Text;
                        ktext =f1ktext;
                        
                    }
                    else  //不区分大小写
                    {
                        f1text = textBox1.Text.ToLower();
                        ktext =f1ktext.ToLower();
                    
                    }

                //查找部分
                        int temp = f1text.IndexOf(ktext,textBox1.SelectionStart +textBox1.SelectedText.Length); //查找位置

                        if (temp >= 0)
                        {
                            textBox1.Select(temp, ktext.Length);
                            textBox1.ScrollToCaret();
                            
                        }
                        else
                        {
                            MessageBox.Show("找不到\"" + ktext + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }

            }


        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void 转到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.mainForm= this;
            f4.Show();


        }

        private void 文本颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void 文本背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1 = new AboutBox1();
            ab1.Show();
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void 撤消toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        private void 全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void 从右到左的阅读顺序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.从右到左的阅读顺序ToolStripMenuItem.Checked)
            {
                textBox1.RightToLeft = RightToLeft.Yes;
                this.contextMenuStrip1.RightToLeft = RightToLeft.No;
            }
            else
            {
                textBox1.RightToLeft = RightToLeft.No;
                this.contextMenuStrip1.RightToLeft = RightToLeft.No;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.istext)
            {
                DialogResult dr = MessageBox.Show("文本已更改，是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    this.保存ToolStripMenuItem.PerformClick();
                }
                else if (dr == DialogResult.No)
                {
                    istext = false;
                    Close();
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            istext = true;
        }



    }
}