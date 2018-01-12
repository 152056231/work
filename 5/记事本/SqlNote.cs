using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
namespace 记事本
{
    public class SqlNote
    {
        #region 构造函数
        public SqlNote()
        {

        }
        #endregion

        #region 配置数据库连接字符串
        public static string ConnectionString = "Data Source=OPPAI;Initial Catalog=NoteBook;Integrated Security=True";
        #endregion

        #region  执行SQL语句，返回Bool值

        public bool ExecuteSQL(string sql)
        {
            SqlConnection con = new SqlConnection(SqlNote.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
        }
        #endregion

        #region 执行SQL语句，返回SqlDataReader
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>返回SqlDataReader，需手工关闭连接</returns>
        public SqlDataReader GetReader(string sql)
        {
            SqlConnection con = new SqlConnection(SqlNote.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dr.Close();
                con.Dispose();
                cmd.Dispose();
                throw new Exception(ex.ToString());
            }
            return dr;
        }
        #endregion

        #region  执行SQL语句，返回DataSet
        /// <summary>
        /// 执行SQL语句，返回DataSet
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="tablename">DataSet中要填充的表名</param>
        /// <returns>返回dataSet类型的执行结果</returns>
        public DataSet GetDataSet(string sql, string tablename)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(SqlNote.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            try
            {
                da.Fill(ds, tablename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                da.Dispose();
            }
            return ds;
        }
        #endregion
        #region  执行SQL语句并返回受影响的行数
        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>返回Int类型的受影响的行数</returns>
        /// 
        public DataTable GetDataTable(string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(SqlNote.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            try
            {
                da.Fill(ds, "tb");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                da.Dispose();
            }
            DataTable result = ds.Tables["tb"];
            return result;
        }
        #endregion
        #region
        public int GetCount(string sql)
        {
            SqlConnection con = new SqlConnection(SqlNote.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
        }
        #endregion
    }
}