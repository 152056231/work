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
    public partial class FormMain : Form
    {
        public string filename=null; //打开的文件名
        public int TextStyle = 0;
        public bool istext = false; //文本框是否改变
        public string f1ktext = null; //是否有关键字
        public bool maxmin; //区分大小
        public FormClosingEventArgs ee;//关闭事件存放
        public bool isclose=false; //是否关闭

        public FormMain()
        {
            InitializeComponent();
          
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlOperator sql = new SqlOperator();
            saveFileDialog1.Filter = "文本文档(*.txt)|*.txt|RichText文档(*.rtf)|*.rtf|所有文件(*.*)|*.*";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Title = "保存文件";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                TextStyle = saveFileDialog1.FilterIndex;

            if (saveFileDialog1.FilterIndex == 2)//如果设置filterindex=2，那么默认打开对话框中显示的文件是所有后缀名为txt的文本文档
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
            else
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
             
            

                string[] filename2 = saveFileDialog1.FileName.Split('\\');
                this.Text = filename2[filename2.Length - 1] + " - 记事本";
                this.istext = false;
            }
            sql.Save(ToolLabel1.Text, richTextBox1.Text);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog MyprintDg = new PrintDialog();
            MyprintDg.Document = MyPrintDc;
            if (MyprintDg.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    MyPrintDc.Print();
                }
                catch
                {
                    MyPrintDc.PrintController.OnEndPrint(MyPrintDc, new System.Drawing.Printing.PrintEventArgs());
                }

            }

        }

        private void 撤消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo==true )
            {
               richTextBox1.Undo();
            }
            
            
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            finder f2 = new finder();
            f2.mainForm = this;
            f2.Show();
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findAndreplace f3 = new findAndreplace();
            f3.mainForm = this;
            f3.Show();
            richTextBox1.SelectionStart = 0;
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
            try
            {
                   Application.Exit();//退出程序
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
           　　
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动换行ToolStripMenuItem.Checked ==false)  //是否自动换行
                richTextBox1.WordWrap = false;
            else
                richTextBox1.WordWrap = true ;
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();  //复制文本
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();　//粘贴文本
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";　　//删除文本
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)  //打开字体对话框
            {
                richTextBox1.Font = fontDialog1.Font;  //设置字体
                
            }

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.istext==false) //判断文本框是否改变
            {
                openFileDialog1.Filter = "文本文档(*.txt)|*.txt|RichText文档(*.rtf)|*.rtf|所有文件(*.*)|*.*";
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "打开文件";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    TextStyle = openFileDialog1.FilterIndex;
                    string[] filename2 = filename.Split('\\');  //只取文件名
                    try
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                    catch (Exception)
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    
                    this.istext = false;
                    this.Text = filename2[filename2.Length-1]+" - 记事本";
                }
            }
            else
            {
                DialogResult dr=MessageBox.Show("文本已更改，是否保存?","提示",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                
                if (dr==DialogResult.Yes)
                {
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
            SqlOperator sql = new SqlOperator();
            if (filename != null) //是否打开过文件？
            {   
            if (TextStyle==2)
            {
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.RichText);
            }
            else
            {
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
                     this.istext = false;           
            }
            else  //不然就另存为
            {
                this.另存为ToolStripMenuItem.PerformClick();              
            }
            sql.Save(ToolLabel1.Text, richTextBox1.Text);
        }
            
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            ToolLabel1.Text = "新建";
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
                    richTextBox1.Clear();
                    this.Text = "无标题 - 记事本";
                    this.istext = false;
                    this.filename = null;
                }
            }
            else
            {
                richTextBox1.Clear();
                this.Text = "无标题 - 记事本";
                this.istext = false;
                this.filename = null;
            }


        }

      

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("日期/时间:" + DateTime.Now.ToString()); //在文本框后面追加 时间日期
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.新建ToolStripMenuItem.PerformClick();
            tsStatusLabeltime.Text = "-->>日期/时间:"+DateTime.Now.ToString();
        }
        


        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))     //是否有可粘贴文本         
                this.粘贴ToolStripMenuItem.Enabled = true;
            else
                this.粘贴ToolStripMenuItem.Enabled = false;

            if (richTextBox1.CanUndo)                           //是否可以撤消
                this.撤消ToolStripMenuItem.Enabled = true;                
            else
                this.撤消ToolStripMenuItem.Enabled = false;////////
            if (richTextBox1.CanRedo)
            {
                this.重复RToolStripMenuItem.Enabled = true;

            }
            else
            {
                this.重复RToolStripMenuItem.Enabled = false;
            }

            if (richTextBox1.SelectedText.Length > 0)  //是否可以剪切、复制、删除
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


            if (richTextBox1.Text.Length > 0)   //没有文本的情况下查找、替换不可用
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
                        f1text = richTextBox1.Text;
                        ktext =f1ktext;
                        
                    }
                    else  //不区分大小写
                    {
                        f1text = richTextBox1.Text.ToLower();
                        ktext =f1ktext.ToLower();
                    
                    }

                //查找部分
                        int temp = f1text.IndexOf(ktext,richTextBox1.SelectionStart +richTextBox1.SelectedText.Length); //查找位置

                        if (temp >= 0)
                        {
                            richTextBox1.Select(temp, ktext.Length);
                            richTextBox1.ScrollToCaret();
                            
                        }
                        else
                        {
                            MessageBox.Show("找不到\"" + ktext + "\"", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }

            }


        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 转到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Next f4 = new Next();
            f4.mainForm= this;
            f4.Show();


        }

        private void 文本颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void 文本背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab1 = new about();
            ab1.Show();
        }

   
        private void 撤消toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void 全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 从右到左的阅读顺序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.从右到左的阅读顺序ToolStripMenuItem.Checked)
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
                this.contextMenuStrip1.RightToLeft = RightToLeft.No;
            }
            else
            {
                richTextBox1.RightToLeft = RightToLeft.No;
                this.contextMenuStrip1.RightToLeft = RightToLeft.No;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.istext)
            {
                DialogResult dr = MessageBox.Show("文本已更改，是否保存?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    isclose = true;
                    ee = e;
                    this.保存ToolStripMenuItem.PerformClick();
                }
                else if (dr == DialogResult.No)
                {
                    istext = false;
                    Close();
                }
                else
                {
                    e.Cancel=true;
                }
            }
        }

        private void 帮助主题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("不好意思,没有写帮助文档,请见谅!!!", "请见谅",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Help.ShowHelp(this, "notepad.chm");
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog MyPageSetupDg = new PageSetupDialog();
            MyPageSetupDg.Document = MyPrintDc;
                MyPageSetupDg.ShowDialog();
         


        }

        private void 工具栏TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (工具栏TToolStripMenuItem.Checked==true)
            {
                toolStrip1.Visible = true;
                
                richTextBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }
            else
            {
                toolStrip1.Visible = false;
                richTextBox1.Dock = DockStyle.Fill;
            }
        }



        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            新建ToolStripMenuItem_Click(sender,e);
        }

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {
            this.istext = true;
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            打开ToolStripMenuItem_Click(sender, e);
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            保存ToolStripMenuItem_Click(sender, e);
        }

        private void 打印PToolStripButton_Click(object sender, EventArgs e)
        {
            打印ToolStripMenuItem_Click(sender, e);
        }

        private void 剪切UToolStripButton_Click(object sender, EventArgs e)
        {
            剪切ToolStripMenuItem_Click(sender, e);
        }

        private void 复制CToolStripButton_Click(object sender, EventArgs e)
        {
            复制ToolStripMenuItem_Click(sender, e);
        }

        private void 粘贴PToolStripButton_Click(object sender, EventArgs e)
        {
            粘贴ToolStripMenuItem_Click(sender, e);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FontDialog Setfont = new FontDialog();
            if (Setfont.ShowDialog()==DialogResult.OK )
            {
                richTextBox1.SelectionFont = Setfont.Font;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog setColor = new ColorDialog();
            if (setColor.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionColor = setColor.Color;
            }
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 重复RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void 删除ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length>0)
            {
                richTextBox1.SelectedText = "";
            }
            else
            {
                richTextBox1.Clear();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                this.撤消toolStripMenuItem10.Enabled = true;
            }
            else
            {
                this.撤消toolStripMenuItem10.Enabled = false;
            }
            if (richTextBox1.CanRedo)
            {
                this.重复RToolStripMenuItem1.Enabled = true;
            }
            else
            {
                this.重复RToolStripMenuItem1.Enabled = false;
            }
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                this.粘贴ToolStripMenuItem1.Enabled = true;
            }
            else
            {
                this.粘贴ToolStripMenuItem1.Enabled = false;
            }
            if (richTextBox1.SelectedText.Length>0)
            {
                this.剪切ToolStripMenuItem1.Enabled = true ;
                this.复制ToolStripMenuItem1.Enabled = true;
            }
            else
            {
                this.剪切ToolStripMenuItem1.Enabled = false;
                this.复制ToolStripMenuItem1.Enabled = false;
            }
            if (richTextBox1.Text.Length>0)
            {
                this.查找与替换SToolStripMenuItem.Enabled = true;

            }
            else
            {
                this.查找与替换SToolStripMenuItem.Enabled = false;
            }
        }

        private void 重复RToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void 查找与替换SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.替换ToolStripMenuItem_Click(sender, e);
            richTextBox1.SelectionStart = 0;
        }

        private void richTextBox1_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width - 5;
            richTextBox1.Height = this.Height;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.istext = true;

        }

        private void 背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.文本背景ToolStripMenuItem.PerformClick();
        }

        private void 字体格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton1.PerformClick();
        }

        private void 字体颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripButton2.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("日期/时间:" + DateTime.Now.ToString());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))     //是否有可粘贴文本         
                this.粘贴PToolStripButton.Enabled = true;
            else
                this.粘贴PToolStripButton.Enabled = false;



            if (richTextBox1.SelectedText.Length > 0)  //是否可以剪切、复制、删除
            {
                this.剪切UToolStripButton.Enabled = true;
                this.复制CToolStripButton.Enabled = true;

            }
            else
            {
                this.剪切UToolStripButton.Enabled = false;
                this.复制CToolStripButton.Enabled = false;

            } 
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDataBase f = new FormDataBase();
            f.Show();
        }
    }
}