using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library.DataAccess
{
   public class User
    {
        //private IEncrypt encrypt;
        //public IEncrypt EncryptPWD;

        private SqlCommand cmd;
        public User()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public DataSet GetUserInfo(string userid)
        {
            cmd.CommandText = "GetUserInfoByID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }
        //public bool Login(string userid, string password)
        //{

        //}
        public bool InsertUser(string userid, string username, string password, int sex, string email, string classname)
        {
            cmd.CommandText = "InsertNewUser";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 15).Value = userid;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = username;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar,20).Value = password;
            cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = sex;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar,50).Value =email;
            cmd.Parameters.Add("@Class", SqlDbType.NVarChar,40).Value = classname;
          
            try
            {
                int num = DBAccess.ExecuteSQL(cmd);
                if (num > 0)
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
        public DataSet ReadingStar()
        {
            cmd.CommandText = "ReadingStar";
            cmd.Parameters.Clear();

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

    }
}
