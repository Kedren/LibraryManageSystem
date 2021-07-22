using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.EnterpriseServices;
using System.Data;

namespace Library.DataAccessTests
{
    [Transaction(TransactionOption.Required)]
    [TestClass()]
    public class BookInfoTests:ServicedComponent
    {
        [TestCleanup]
        public void TransactionOptionTestCleanup()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

        BookInfo bfo;
        public BookInfoTests()
        {
            bfo = new BookInfo();
        }
  
        [TestMethod()]
        public void DeleteBookTest()
        {
            //存在的书
            bool bo = bfo.DeleteBook("G634.7/251:2");
            Assert.IsTrue(bo);
  

        }

        [TestMethod()]
        public void GetBookInfoTest()
        {
            //存在的书          
            DataSet ds1 = bfo.GetBookInfo("三生三世", "T");

            Assert.IsNotNull(ds1);
            Assert.AreEqual(1, ds1.Tables[0].Rows.Count);
            Assert.AreEqual("666", ds1.Tables[0].Rows[0]["BookID"].ToString().Trim());

            
        }

        [TestMethod()]
        public void GetBookInfoTest1()
        {
           

            DataSet ds = bfo.GetBookInfo("666");

            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("三生三世", ds.Tables[0].Rows[0]["BookName"].ToString().Trim());


        }

        [TestMethod()]
        public void GetBookInfoTest2()
        {          
            DataSet ds = bfo.GetBookInfo("9-9-9", "三生三世", "安静", "T");

            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("666", ds.Tables[0].Rows[0]["BookID"].ToString().Trim());
        }

        [TestMethod()]
        public void InsertNewBookTest()
        {
           bool bo = bfo.InsertNewBook("123456789", "7-5633-4885-9", "Kedren", "安静",Convert.ToDateTime("1999-9-2"), "3.0", 666, 555, "清华出版社", "T");
           Assert.IsTrue(bo);
        }

        [TestMethod()]
        public void UpdateBookInfoTest()
        {
            bool bo = bfo.UpdateBookInfo("666", "7-5633-4885-9", "Kedren", "静", Convert.ToDateTime("1999-9-2"), "3.0", 666, 555, "清华出版社", "T");
            Assert.IsTrue(bo);
        }

        [TestMethod()]
        public void GetAllBookClassTest()
        {
            DataSet ds = bfo.GetAllBookClass();
            Assert.IsNotNull(ds);         
        }

        [TestMethod()]
        public void GetBookStatisticInfoTest()
        {
            DataSet ds = bfo.GetBookStatisticInfo();
            Assert.IsNotNull(ds);   

        }

        [TestMethod()]
        public void TheMostPopularBookTest()
        {
            DataSet ds = bfo.TheMostPopularBook();
            Assert.IsNotNull(ds);   
        }
    }
}
