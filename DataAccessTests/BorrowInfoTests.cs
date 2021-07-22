using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.EnterpriseServices;
using System.Data;

namespace Library.DataAccess.Tests
{
    [Transaction(TransactionOption.Required)]
    [TestClass()]
    public class BorrowInfoTests : ServicedComponent
    {

        [TestCleanup]
        public void TransactionOptionTestCleanup()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }
       
        BorrowInfo br;
        public BorrowInfoTests()
        {
            br = new BorrowInfo();
        }

        [TestMethod()]
        public void IsBorrowedTest()
        {
           bool bo= br.IsBorrowed("666");
           Assert.IsFalse(bo);
        }

        [TestMethod()]
        public void HasBookTest()
        {
            bool bo = br.HasBook("666");
            Assert.IsTrue(bo);
        }

        [TestMethod()]
        public void BorrowBookTest()
        {
            bool bo = br.BorrowBook("G634.67/21", "20160310039");
            Assert.IsTrue(bo);
        }

        [TestMethod()]
        public void ReturnBookTest()
        {
            bool bo = br.ReturnBook("G634.67/21");
            Assert.IsFalse(bo);
        }

        [TestMethod()]
        public void ReBorrowTest()
        {
            bool bo = br.ReBorrow("G634.67/21");
            Assert.IsFalse(bo);
        }

        [TestMethod()]
        public void GetBorrowInfoByBookIDTest()
        {
            DataSet ds = br.GetBorrowInfoByBookID("G634.67/21");
            Assert.IsNotNull(ds);    
        }

        [TestMethod()]
        public void GetBorrowInfoByUserIDTest()
        {
            DataSet ds = br.GetBorrowInfoByUserID("20160310039");
            Assert.IsNotNull(ds);  
        }
    }
}
