using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Library.DataAccess;
using System.EnterpriseServices;

namespace UnitDataAccess
{
    [Transaction(TransactionOption.Required)]
    [TestClass]
    public class UnitTestBookInfo : ServicedComponent
    {
        [TestCleanup]
        public void TransactionOptionTestCleanup()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

        [TestMethod]
        public void GetBookInfoTest()
        {
            BookInfo bfo = new BookInfo();
            DataSet ds = bfo.GetBookInfo("I227/145");

            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("田间诗选", ds.Tables[0].Rows[0]["BookName"].ToString().Trim());


            //Assert.IsNotNull(ds);
            //Assert.AreEqual(0, ds.Tables[0].Rows.Count);

        }     

        [TestMethod]
        public void GetBookInfoTest2()
        {
            BookInfo bfo = new BookInfo();
            DataSet ds = bfo.GetBookInfo("田间诗选", "I");

            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("I227/145", ds.Tables[0].Rows[0]["BookID"].ToString().Trim());
        }

        [TestMethod]
        public void GetBookInfoTest3()
        {
            BookInfo bfo = new BookInfo();
            DataSet ds = bfo.GetBookInfo("田间诗选", "I");

            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.AreEqual("I227/145", ds.Tables[0].Rows[0]["BookID"].ToString().Trim());
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            BookInfo bfo = new BookInfo();

            Assert.AreEqual(true, bfo.DeleteBook("G634.41/85"));
        }

         [TestMethod]
        public void InsertNewBookTest()
        {

        }

         [TestMethod]
        public void UpdateBookInfoTest()
        {

        }

         [TestMethod]
        public void GetAllBookClassTest()
        {

        }

         public void GetBookStatisticInfoTest()
         {

         }

         public void TheMostPopularBookTest()
         {

         }
    }
}
