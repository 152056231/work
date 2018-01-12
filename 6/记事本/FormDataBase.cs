using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace 记事本
{
    public partial class FormDataBase : Form
    {
        string a;
        //string z;
        public FormDataBase()
        {
            InitializeComponent();
            
        }

        private void FormDataBase_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“noteBookDataSet.Note”中。您可以根据需要移动或删除它。
            this.noteTableAdapter.Fill(this.noteBookDataSet.Note);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            a = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            richTextBox1.Text = a;         
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlNote sql = new SqlNote();
            //string f = "select Note_PathName from Note where Note_Notes = '" + a + "'";
            SqlConnection cn = new SqlConnection("Data Source=OPPAI;Initial Catalog=NoteBook;Integrated Security=True");
            SqlCommand com = new SqlCommand("select Note_PathName from Note where Note_Notes = '" + a + "'", cn);
            cn.Open();
            string g = com.ExecuteScalar().ToString();
            cn.Close();
            string b = "update Note set Note_Notes = '" + richTextBox1.Text + "' where Note_PathName = '" + g + "'";
            if (sql.ExecuteSQL(b))
            {
                string c = "select * from Note";
                dataGridView1.DataSource = sql.GetDataTable(c);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlNote sql = new SqlNote();
            SqlConnection cn = new SqlConnection("Data Source=OPPAI;Initial Catalog=NoteBook;Integrated Security=True");
            SqlCommand com = new SqlCommand("select Note_PathName from Note where Note_Notes = '" + a + "'", cn);
            cn.Open();
            string g = com.ExecuteScalar().ToString();
            cn.Close();
            string c = "delete from Note where Note_PathName = '" + g + "'";
            if (sql.ExecuteSQL(c))
            {
                string f = "select * from Note";
                dataGridView1.DataSource = sql.GetDataTable(f);
            }
        }
    }
}
