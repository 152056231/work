using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 记事本
{
    class entrust
    {
        public string filename = null; //打开的文件名
        public int TextStyle = 0;
        public bool istext = false; //文本框是否改变
        public string f1ktext = null; //是否有关键字
        public bool maxmin; //区分大小
        public FormClosingEventArgs ee;//关闭事件存放
        public bool isclose = false; //是否关闭

        public void xinjian()
        { 
        
        }
    }
}
