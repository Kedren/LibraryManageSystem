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
    public class AdminTests : ServicedComponent
    {
        [TestCleanup]
        public void TransactionOptionTestCleanup()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

        Admin ad;
        public AdminTests()
        {
            ad = new Admin();
        }

        [TestMethod()]
        public void LoginTest()
        {
            bool bo = ad.Login("003", "12345678");
            Assert.IsTrue(bo);

        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            bool bo = ad.ChangePassword("003", "12345678");
            Assert.IsTrue(bo);
        }

        [TestMethod()]
        public void GetAdminInfoByIDTest()
        {
            object o = ad.GetAdminInfoByID("003");
            Assert.AreEqual("小七", Convert.ToString(o));
        }

        [TestMethod()]
        public void InsertAdminTest()
        {
            bool bo = ad.InsertAdmin("007", "Kedren", "12345678", "1696759698@qq.com");
            Assert.IsTrue(bo);
        }
    }
}
