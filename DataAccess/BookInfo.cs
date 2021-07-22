using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library.DataAccess
{
    public class BookInfo
    {
        private SqlCommand cmd;
        public BookInfo()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool DeleteBook(string bookid)
        {
            cmd.CommandText = "DeleteBook";
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

        public DataSet GetBookInfo(string bookname, string classid)
        {
            cmd.CommandText = "GtBookInfoByClassIDAndBookName";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 100).Value = bookname;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 10).Value = classid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }

        public DataSet GetBookInfo(string bookid)
        {
            cmd.CommandText = "GetBookInfoByBookID";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@BookID", SqlDbType.Char, 10).Value = bookid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

        public DataSet GetBookInfo(string isbn, string bookname, string author, string classid)
        {
            cmd.CommandText = "GetBookInfoByCondition";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@ISBN", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 100).Value = bookname;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 10).Value = classid;


            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

        public bool InsertNewBook(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            cmd.CommandText = "InsertNewBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;
            cmd.Parameters.Add("@ISBN", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 100).Value = bookname;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = publishdate;
            cmd.Parameters.Add("@BookVersion", SqlDbType.NVarChar, 40).Value = bookversion;
            cmd.Parameters.Add("@WordCount", SqlDbType.Int).Value = wordcount;
            cmd.Parameters.Add("@PageCount", SqlDbType.SmallInt).Value = pagecount;
            cmd.Parameters.Add("@Publisher", SqlDbType.NVarChar, 40).Value = publisher;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 10).Value = classid;

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
        public bool UpdateBookInfo(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            cmd.CommandText = "UpdateBookInfo";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookid;
            cmd.Parameters.Add("@ISBN", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 100).Value = bookname;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = publishdate;
            cmd.Parameters.Add("@BookVersion", SqlDbType.NVarChar, 40).Value = bookversion;
            cmd.Parameters.Add("@WordCount", SqlDbType.Int).Value = wordcount;
            cmd.Parameters.Add("@PageCount", SqlDbType.SmallInt).Value = pagecount;
            cmd.Parameters.Add("@Publisher", SqlDbType.NVarChar, 40).Value = publisher;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 10).Value = classid;

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

        public DataSet GetAllBookClass()
        {
            cmd.CommandText = "GetAllBookClass";
            cmd.Parameters.Clear();

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }


        public DataSet GetBookStatisticInfo()
        {
            cmd.CommandText = "GetBookStatisticInfo";
            cmd.Parameters.Clear();

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet TheMostPopularBook()
        {
            cmd.CommandText = "TheMostPopularBook";
            cmd.Parameters.Clear();

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

    }
}
