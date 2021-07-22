using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Library.Comm;

namespace Library.DataAccess
{
    public class Admin
    {
        private Encrypt en;
        private SqlCommand cmd;

        public Admin()
        {
            en = new Encrypt();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public bool Login(string adminid, string password)
        {
            cmd.CommandText = "AdminLogin";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@AdminID", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@PassWord", SqlDbType.Binary, 20).Value = en.EncryptPassWord(password);

            try
            {
                object o = DBAccess.GetScalar(cmd);
                if ((int)o > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  //登录

        public bool ChangePassword(string adminid, string newpassword)   //修改密码
        {
            cmd.CommandText = "ChangeAdminPassword";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@AdminID", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@PassWord", SqlDbType.Binary, 20).Value = en.EncryptPassWord(newpassword);

            try
            {

                int num = DBAccess.ExecuteSQL(cmd);
                if ((int)num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public string GetAdminInfoByID(string adminid)   //按用户ID查询用户名字
        {
            cmd.CommandText = "GetAdminInfoByID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@AdminID", SqlDbType.Char, 10).Value = adminid;

            try
            {
                object o = DBAccess.GetScalar(cmd);
                return Convert.ToString(o);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertAdmin(string adminid, string adminname, string password, string email)  //插入新用户
        {
            cmd.CommandText = "InsertNewAdmin";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@AdminID", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@AdminName", SqlDbType.NVarChar, 30).Value = adminname;
            cmd.Parameters.Add("@PassWord", SqlDbType.Binary, 20).Value = en.EncryptPassWord(password);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 40).Value = email;

            try
            {

                int num = DBAccess.ExecuteSQL(cmd);
                if ((int)num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
