using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Library.DataAccess
{
    public class DBAccess
    {   
        private static string ConnString=ConfigurationManager.ConnectionStrings["LibraryConString"].ConnectionString;
        /// <summary>
        /// 执行命令（insert,update,delete），返回受影响的行数
        /// </summary>
        /// <param name="cmd">要执行的命令对象</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteSQL(SqlCommand cmd)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(ConnString);

           //创建命令对象
            cmd.Connection = conn;

            try
            {
                 //打开连接
            conn.Open();

            //执行命令
            int num = cmd.ExecuteNonQuery();
            return num;

            }
            catch(Exception ex)
            {
                throw new DBException(ex);
            }
          
              finally
                {
                    //关闭连接
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
                }
      
        }

        /// <summary>
        /// 执行命令（select），返回一项数据（第一行，第一列）
        /// </summary>
        /// <param name="cmd">要执行的命令对象</param>
        /// <returns返回一项数据></returns>
        public static object GetScalar(SqlCommand cmd)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(ConnString);
            //创建命令对象
            cmd.Connection = conn;

            try
            {
                //打开连接
                conn.Open();
                //执行命令
                object ob=cmd.ExecuteScalar();
                return ob;
            }
            catch(Exception ex)
            {
                throw new DBException(ex);
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    //关闭连接
                    conn.Close();
                }
            }


        }

        /// <summary>
        /// 执行命令（select），返回查询的数据集
        /// </summary>
        /// <param name="cmd">要执行的命令对象</param>
        /// <returns>返回查询到的数据集</returns>
        public static DataSet QueryData(SqlCommand cmd)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(ConnString);
            //创建命令对象
            cmd.Connection = conn;

            //创建数据适配器
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            //创建数据集
            DataSet ds = new DataSet();
            try
            {
                ada.Fill(ds);
                return ds;
            }
            catch(Exception ex)
            {
                throw new DBException(ex);
            }
        }

    }
}
