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
    public class KeUser
    {
        private SqlCommand cmd;
        public KeUser()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public bool InsertKeUser(string userid, string photoPath)
        {
            cmd.CommandText = "InsertKeUser";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userid;
            cmd.Parameters.Add("@Photo", SqlDbType.Image).Value =Photo.ReadPhooto(photoPath);
            int num = DBAccess.ExecuteSQL(cmd);
            try
            {
                if(num>0)
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
        public bool InsertKeUserTwo(string userid)
        {
            cmd.CommandText = "InsertKeUserTwo";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userid;
            int num = DBAccess.ExecuteSQL(cmd);
            try
            {
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
        public DataSet GetKeUserByUserID(string userid)
        {
            cmd.CommandText = "GetKeUserByUserID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

    }
}
