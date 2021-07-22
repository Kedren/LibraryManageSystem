using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library.DataAccess
{
    public class BorrowInfo
    {
        private SqlCommand cmd;
        public BorrowInfo()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
       public bool IsBorrowed(string bookid)
        {
            cmd.CommandText = "IsBorrowed";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;
     
                object o= DBAccess.GetScalar(cmd);

                if (o==null)        //从未借出
                {
                    return false;
                }
                else
           {
               if(Convert.ToInt32(o)>0)    //借了还了
               {
                   return false;
               }
               else             //借了未还
               {
                   return true;
               }
           }
        }
        public bool HasBook(string bookid)
        {
            cmd.CommandText = "HasThisBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;

                int num =Convert.ToInt32( DBAccess.GetScalar(cmd));
                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public bool BorrowBook(string bookid, string userid)
        {
            cmd.CommandText = "BorrowBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userid;

            try
            {
                int num =DBAccess.ExecuteSQL(cmd);
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
        public bool ReturnBook(string bookid)
        {
            cmd.CommandText = "ReturnBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;

            try
            {
                int num =DBAccess.ExecuteSQL(cmd);
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
        public bool ReBorrow(string bookid)
        {
            cmd.CommandText = "ReborrowBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;

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
        public DataSet GetBorrowInfoByBookID(string bookid)
        {
            cmd.CommandText = "GetBorrowInfoByBookID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetBorrowInfoByUserID(string userid)
        {
            cmd.CommandText = "GetBorrowInfoByUserID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 151).Value =userid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }     
    }
}
