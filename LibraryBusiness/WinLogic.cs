using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using System.Data;

namespace Library.LibraryBusiness
{
    public class WinLogic
    {
        private User us;
        private BorrowInfo bo;
        private BookInfo bk;
        private Admin ad;
        private KeUser ke;


        public WinLogic()
        {
            us = new User();
            bo = new BorrowInfo();
            bk = new BookInfo();
            ad = new Admin();
            ke = new KeUser();
        }

        public bool AdminLogin(string adminid, string password)    //用户登录
        {
            return ad.Login(adminid, password);
        }
        public DataSet GetUserInfo(string userid)
        {
            return us.GetUserInfo(userid);
        }
        public DataSet GetBorrowInfoByUserID(string userid)
        {
            return bo.GetBorrowInfoByUserID(userid);
        }
        public bool BorrowBook(string bookid, string userid)
        {
            if (!bo.HasBook(bookid))
            {
                throw new NoRecordException("没有这本书！");
            }
            if (bo.ReturnBook(bookid))
            {
                return false;
            }
            return bo.BorrowBook(bookid, userid);
        }
        public DataSet GetBookInfoByBookID(string bookid)
        {
            return bk.GetBookInfo(bookid);
        }
        public DataSet GetBorrowInfoByBookID(string bookid)
        {
            return bo.GetBorrowInfoByBookID(bookid);
        }
        public bool InsertNewBook(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            return bk.InsertNewBook(bookid, isbn, bookname, author, publishdate, bookversion, wordcount, pagecount, publisher, classid);
        }
        public DataSet GetBookInfo(string bookname, string classid)
        {
            return bk.GetBookInfo(bookname, classid);
        }
        public bool DeleteBook(string bookid)
        {
            return bk.DeleteBook(bookid);
        }
        public bool UpdateBookInfo(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            return bk.UpdateBookInfo(bookid, isbn, bookname, author, publishdate, bookversion, wordcount, pagecount, publisher, classid);
        }
        public bool ChangePassword(string adminid, string newpassword)    //修改用户密码
        {
            return ad.ChangePassword(adminid, newpassword);
        }
        public DataSet GetAllBookClass()
        {
            return bk.GetAllBookClass();
        }
        public bool ReturnBook(string bookid)
        {
            return bo.ReturnBook(bookid);
        }
        public bool ReBorrow(string bookid)
        {
            return bo.ReBorrow(bookid);
        }
        public DataSet GetBookStatisticInfo()
        {
            return bk.GetBookStatisticInfo();
        }
        public string GetAdminInfoByID(string adminid)   //按用户ID查询用户名字
        {
            return ad.GetAdminInfoByID(adminid);
        }
        public bool InsertAdmin(string adminid, string adminname, string password, string email)    //新建用户
        {
            return ad.InsertAdmin(adminid, adminname, password, email);
        }
        public bool InsertKeUser(string userid, string photoPath)
        {
            return ke.InsertKeUser(userid, photoPath);
        }
        public bool InsertKeUser(string userid)
        {
            return ke.InsertKeUserTwo(userid);
        }
        public DataSet GetKeUserByUserID(string userid)
        {
            return ke.GetKeUserByUserID(userid);
        }
        public DataSet ReadingStar()
        {
            return us.ReadingStar();
        }
        public DataSet TheMostPopularBook()
        {
            return bk.TheMostPopularBook();
        }
    }
}
