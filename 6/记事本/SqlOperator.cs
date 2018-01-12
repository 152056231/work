using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 记事本
{
    class SqlOperator
    {
        public void Login(string a, string b)
        {
            SqlNote sql = new SqlNote();
            string c = "select count(*) from Login where Login_Name = '" + a + "'and Login_Password = '" + b + "'";
            if (sql.GetCount(c) > 0)
            {
                FormMain f = new FormMain();
                f.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("用户账号、密码错误！！！");
            }
        }
        public void Register(string a, string b)
        {
            SqlNote sql = new SqlNote();
            string c = "select count(*) from Login where Login_Name = '" + a + "'";
            if (sql.GetCount(c) > 0)
            {
                MessageBox.Show("用户名重复！！！");
            }
            else
            {
                string d = "insert into Login values ('" + a + "','" + b + "')";
                if (sql.ExecuteSQL(d))
                    MessageBox.Show("注册成功");
            }
        }
        public void Save(string a, string b)
        {
            SqlNote sql = new SqlNote();
            DateTime r = DateTime.Now.ToLocalTime();
            string d = "insert into Note values ('" + a + "','" + b + "','" + r + "')";
            if (sql.ExecuteSQL(d))
            {
                MessageBox.Show("同步上传到数据库成功！！！");
            }
        }
    }
}
