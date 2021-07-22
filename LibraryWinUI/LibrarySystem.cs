using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Library.DataAccess;
using Library.LibraryBusiness;
using Library.Comm;
using System.IO;

namespace Library.LibraryWinUI
{
    public partial class LibrarySystem : Form
    {
        private string borrowUID;  //借阅者的UserID
        private string reBookID;   //还书的图书编号
        private string reUID;      //还书的UserID
        private string tooBookID;  //续借的图书编号
        private string tooUID;     //续借的UserID
        private string deleteBookID;  //删除的图书编号
        private string adminID = "Administrator";       //从用户登录窗口传过来的用户ID
        private WinLogic logic;
        private IInputCheck inPutCheck;
        private bool flagB = true;   //还书选项卡标记
        private bool flagC = true;   //续借选项卡标记
        private int currentRowIndex;
        private Encrypt en;
        public LibrarySystem(string adminID)
        {
            InitializeComponent();
            this.adminID = adminID;
            logic = new WinLogic();
            en = new Encrypt();
            inPutCheck = new InputCheck();

        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //测试从配置文件中读取连接字符串
            //string ConString = ConfigurationManager.ConnectionStrings["LibraryConString"].ConnectionString;
            //MessageBox.Show(ConString);

            //测试连接字符串是否正确
            //SqlConnection conn = new SqlConnection(ConString);
            //try
            //{
            //    conn.Open();
            //    MessageBox.Show("Connetion success");
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //测试DBException异常类
            //DBException dbex = new DBException(new Exception());
            //MessageBox.Show(dbex.Message);

            //测试NoRecordExcept异常类
            //NoRecordException nexOne = new NoRecordException();
            //MessageBox.Show(nexOne.Message);

            //NoRecordException nexTwo = new NoRecordException("不存在的！");
            //MessageBox.Show(nexTwo.Message);

            //测试DBAccess命令类

            //方法ExecuteNonQuery
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "update TBL_User set Password=123";
            //cmd.CommandType = CommandType.Text;

            //int num=DBAccess.ExecuteSQL(cmd);
            //MessageBox.Show(num.ToString());

            //方法ExecuteScalar
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select UserName from TBL_User where UserID=20050402009";
            //cmd.CommandType = CommandType.Text;

            //object ob = DBAccess.GetScalar(cmd);
            //MessageBox.Show(ob.ToString());

            //方法DataSet
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from TBL_BookInfo";
            //cmd.CommandType = CommandType.Text;
            //dataTest.DataSource = DBAccess.QueryData(cmd).Tables[0];

            //测试BookInfo类

            BookInfo cd = new BookInfo();

            //方法DeleteBook


            //bool b = cd.DeleteBook("F27 ");
            //MessageBox.Show(b.ToString());

            ////方法InsertNewBook
            // bool b = cd.InsertNewBook("0039", "5-5-5", "安静的我", "安静", Convert.ToDateTime("2000-8-8"), "6", 500, 60, "中华出版社", "T");
            // MessageBox.Show(b.ToString());

            //方法UpdateBookInfo
            //bool b = cd.UpdateBookInfo("0039", "5-6-6", "安静我", "安静", Convert.ToDateTime("2000-3-8"), "6", 5000, 60, "出版社", "T");
            //MessageBox.Show(b.ToString());

            //方法 GetBookInfo,按bookname,classid查询
            //DataSet ds = cd.GetBookInfo("学", "");
            //dataTest.DataSource = ds.Tables[0];

            //方法 GetBookInfo,按bookid查询
            //DataSet ds = cd.GetBookInfo("666");
            //dataTest.DataSource = ds.Tables[0];

            //方法 GetBookInfo,按isbn,bookname,author,classid查询
            //DataSet ds = cd.GetBookInfo("", "学", "", "");
            //dataTest.DataSource = ds.Tables[0];

            //方法GetAllBookClass
            //DataSet ds = cd.GetAllBookClass();
            //dataTest.DataSource = ds.Tables[0];

            //方法GetBookStatisticInfo
            //DataSet ds = cd.GetBookStatisticInfo();
            //dataTest.DataSource = ds.Tables[0];

            //测试User类
            User us = new User();

            //方法GetUserInfo
            //DataSet ds = us.GetUserInfo("20160310039");
            //dataTest.DataSource = ds.Tables[0];

            //方法InsertUser
            //bool b = us.InsertUser("201116", "Kedren", "123",1, "1696758@qq.com", "2班");
            //MessageBox.Show(b.ToString());

            //测试BorrowInfo类
            BorrowInfo bo = new BorrowInfo();

            //方法IsBorrowed
            //bool b = bo.IsBorrowed("I227/145");
            //MessageBox.Show(b.ToString());

            ////方法HasBook
            //bool b = bo.HasBook("666");
            //MessageBox.Show(b.ToString());

            //方法BorrowBook
            //bool b = bo.BorrowBook("I227/145", "20070410008");
            //MessageBox.Show(b.ToString());

            //方法ReturnBook
            //bool b = bo.ReturnBook("I227/145");
            //MessageBox.Show(b.ToString());

            //方法ReBorrow
            //bool b = bo.ReBorrow("I227/145");
            //MessageBox.Show(b.ToString());

            //方法GetBorrowInfoByBookID
            //DataSet ds = bo.GetBorrowInfoByBookID("666");
            //dataTest.DataSource = ds.Tables[0];

            //方法GetBorrowInfoByUserID
            //DataSet ds = bo.GetBorrowInfoByUserID("20070410008");
            //dataTest.DataSource = ds.Tables[0];

            //测试Admin类
            Admin ad = new Admin();

            //方法InsertAdmin
            //bool b = ad.InsertAdmin("Administrator", "系统管理员", "12345678", "123456789@qq.com");
            //MessageBox.Show(b.ToString());


            //方法ChangePassword
            //bool  b =ad.ChangePassword("003","12345678");
            //MessageBox.Show(b.ToString());  

        }

        private void btnConfirmA1_Click(object sender, EventArgs e)  //借书选项卡”确定“按钮（单击事件）
        {
            //1.取出文本框信息
            borrowUID = txtIDA.Text.Trim();

            //2.查找借阅者信息并显示
            if (txtIDA.Text == "")
            {
                MessageBox.Show("读者编号不能为空！");
                return;
            }
            try
            {
                DataSet ds = logic.GetUserInfo(borrowUID); ;
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有这个用户");
                    btnConfirmA2.Enabled = false;
                    ClearConTxA1();
                    txtIDA.Focus();
                    return;
                }
                btnConfirmA2.Enabled = true;
                DataRow row = dt.Rows[0];
                txtNameA.Text = row["username"].ToString();
                txtClassA.Text = row["class"].ToString();
                if (Convert.ToInt32(row["sex"]) == 1)
                {
                    rbMaleA.Checked = true;
                }
                else
                {
                    rbFemaleA.Checked = true;
                }
                //显示照片
                DataRow dr = dt.Rows[0];
                if (dr["photo"] == Convert.DBNull)
                {
                    pictureBox1.Image = Image.FromFile("no.gif");
                }
                else
                {
                    MemoryStream ms = new MemoryStream(dr["Photo"] as byte[]);
                    pictureBox1.Image = Image.FromStream(ms);

                }

                //3.显示借阅信息
                dgBorrowInfoA.DataSource = logic.GetBorrowInfoByUserID(borrowUID).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnCanccelA1_Click(object sender, EventArgs e)   //借书选项卡”btnCanccelA1（取消）“按钮（单击事件）
        {
            ClearConTxA1();
        }

        private void ClearConTxA1()
        {
            txtIDA.Clear();
            txtNameA.Clear();
            rbFemaleA.Checked = false;
            txtClassA.Clear();
            rbMaleA.Checked = false;
            //清空照片
            dgBorrowInfoA.DataSource = null;
        }

        private void btnBorrow_Click(object sender, EventArgs e)   //还书选项卡”检索“按钮（单击事件）
        {
            //1.取出文本框信息
            reBookID = txtBookIDB.Text.Trim();
            if (reBookID == "")
            {
                MessageBox.Show("图书编号不能为空！");
                txtBookIDB.Focus();
                return;
            }
            if (flagB)  //检索              
            {
                try
                {
                    DataSet ds = logic.GetBorrowInfoByBookID(reBookID);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        lblAlertMessageB.Visible = true;
                        txtBookIDB.Focus();
                        return;
                    }
                    lblAlertMessageB.Visible = false;
                    DataRow row = dt.Rows[0];
                    txtISBNB.Text = row["ISBN"].ToString();
                    txtBookNameB.Text = row["BookName"].ToString();
                    txtPublisherB.Text = row["Publisher"].ToString();
                    txtAuthorB.Text = row["Author"].ToString();
                    txtNameB.Text = row["UserName"].ToString();
                    txtClassB.Text = row["Class"].ToString();

                    DateTime de = Convert.ToDateTime(row["BorrowDate"]);
                    System.DateTime nowde = System.DateTime.Now;
                    TimeSpan day = nowde.Subtract(de);
                    if (day.Days > 90)
                    {
                        rbOverTimeYB.Checked = true;
                        MessageBox.Show("已逾期" + (day.Days - 90).ToString() + "天，需交逾期费" + (day.Days * 0.5).ToString() + "元");
                    }
                    else
                    {
                        rbOverTimeNB.Checked = true;
                    }

                    if (Convert.ToInt32(row["Sex"]) == 0)
                    {
                        rbFemaleB.Select();
                    }
                    else
                    {
                        rbMaleB.Select();
                    }

                    reUID = row["UserID"].ToString().Trim();

                    dgBorrowInfoB.DataSource = logic.GetBorrowInfoByUserID(reUID).Tables[0];

                    btnBorrow.Text = "还书";
                    flagB = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else  //还书
            {
                try
                {
                    if (logic.ReturnBook(reBookID))
                    {
                        MessageBox.Show("还书成功");
                        dgBorrowInfoB.DataSource = logic.GetBorrowInfoByUserID(reUID).Tables[0];
                        flagB = true;
                    }

                    else
                    {
                        MessageBox.Show("还书失败");
                        flagB = true;
                    }
                    btnBorrow.Text = "检索";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnConfirmA2_Click(object sender, EventArgs e)   //借书选项卡”借书“按钮（单击事件）
        {
            //从文本框取出图书编号
            string bookid = txtBookIDA.Text.Trim();

            if (bookid == "")
            {
                MessageBox.Show("图书编号不能为空！");
                txtBookIDA.Focus();
                return;
            }
            //借书操作
            try
            {
                if (logic.BorrowBook(bookid, borrowUID))
                {
                    MessageBox.Show("借书成功");
                    dgBorrowInfoA.DataSource = logic.GetBorrowInfoByUserID(borrowUID);
                }
                else
                {

                    MessageBox.Show("借书失败");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelA2_Click(object sender, EventArgs e)   //借书选项卡”btnCanccelA2（取消）“按钮（单击事件）
        {
            txtBookIDA.Clear();

        }
        private void btnReborrow_Click(object sender, EventArgs e)   //续借选项卡”检索“按钮（单击事件）
        {
            //1.取出文本框信息
            tooBookID = txtBookIDC.Text.Trim();
            if (tooBookID == "")
            {
                MessageBox.Show("图书编号不能为空！");
                txtBookIDC.Focus();
                return;
            }
            if (flagC)  //检索              
            {
                try
                {
                    DataSet ds = logic.GetBorrowInfoByBookID(tooBookID);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        lblAlertMessageC.Visible = true;
                        txtBookIDC.Focus();
                        return;
                    }


                    lblAlertMessageC.Visible = false;
                    DataRow row = dt.Rows[0];
                    txtISBNC.Text = row["ISBN"].ToString();
                    txtBookNameC.Text = row["BookName"].ToString();
                    txtPublisherC.Text = row["Publisher"].ToString();
                    txtAuthorC.Text = row["Author"].ToString();
                    txtNameC.Text = row["UserName"].ToString();
                    txtClassC.Text = row["Class"].ToString();

                    DateTime de = Convert.ToDateTime(row["BorrowDate"]);
                    System.DateTime nowde = System.DateTime.Now;
                    TimeSpan day = nowde.Subtract(de);
                    if (day.Days > 90)
                    {
                        rbOverTimeYC.Checked = true;
                        MessageBox.Show("已逾期" + (day.Days - 90).ToString() + "天，需交逾期费" + (day.Days * 0.5).ToString() + "元");
                    }
                    else
                    {
                        rbOverTimeNC.Checked = true;
                    }

                    if (Convert.ToInt32(row["Sex"]) == 0)
                    {
                        rbFemaleC.Select();
                    }
                    else
                    {
                        rbMaleC.Select();
                    }

                    tooUID = row["UserID"].ToString().Trim();

                    dgBorrowInfoC.DataSource = logic.GetBorrowInfoByUserID(tooUID).Tables[0];

                    btnReborrow.Text = "续借";
                    flagC = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else  //续借
            {
                try
                {
                    if (logic.ReBorrow(tooBookID))
                    {
                        MessageBox.Show("续借成功");
                        dgBorrowInfoB.DataSource = logic.GetBorrowInfoByUserID(tooBookID).Tables[0];
                        flagC = true;
                    }

                    else
                    {
                        MessageBox.Show("续借失败");
                        flagC = true;
                    }
                    btnReborrow.Text = "检索";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnSearchD_Click(object sender, EventArgs e)   //图书管理检索按钮单击事件
        {
            try
            {
                string bookName = txtBookNameD2.Text.ToString();
                string classID = Convert.ToString(cbBookTypeD2.SelectedValue);
                DataTable dt = logic.GetBookInfo(bookName, classID).Tables[0];

                if (dt.Rows.Count == 0)
                {
                    dataGrid1.DataSource = null;
                    MessageBox.Show("没有您要查找的书！");
                    return;
                }

                dataGrid1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnCancelB_Click(object sender, EventArgs e)  //还书选项卡”取消“按钮（单击事件）
        {
            txtBookIDB.Clear();
            txtISBNB.Clear();
            txtPublisherB.Clear();
            txtAuthorB.Clear();
            txtBookNameB.Clear();
            txtNameB.Clear();
            txtClassB.Clear();
            rbMaleB.Checked = false;
            rbFemaleB.Checked = false;
            dgBorrowInfoB.DataSource = null;
            btnBorrow.Text = "检索";
            flagB = true;
        }
        private void btnCancelC_Click(object sender, EventArgs e)   //续借选项卡”取消“按钮（单击事件）
        {

            txtBookIDC.Clear();
            txtISBNC.Clear();
            txtPublisherC.Clear();
            txtAuthorC.Clear();
            txtBookNameC.Clear();
            txtNameC.Clear();
            txtClassC.Clear();
            rbMaleC.Checked = false;
            rbFemaleC.Checked = false;
            dgBorrowInfoC.DataSource = null;
            btnReborrow.Text = "检索";
            flagC = true;
        }

        private void dataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid1.CurrentRow.Selected = true;
            btnDelD.Enabled = true;
            txtBookIDD.Enabled = false;
            rbModify.Checked = true;
            DataTable dt = dataGrid1.DataSource as DataTable;
            currentRowIndex = dataGrid1.CurrentRow.Index;
            DataRow dr = dt.Rows[currentRowIndex];


            deleteBookID = dr["BookID"].ToString();
            txtBookIDD.Text = deleteBookID;
            txtBookNameD.Text = dr["BookName"].ToString();
            txtPublishDateD.Text = dr["PublishDate"].ToString();
            txtISBND.Text = dr["ISBN"].ToString();
            txtAuthorD.Text = dr["Author"].ToString();
            txtPublisherD.Text = dr["Publisher"].ToString();
            txtWordCountD.Text = dr["WordCount"].ToString();
            txtPageCountD.Text = dr["PageCount"].ToString();
            cbBookTypeD1.SelectedValue = dr["ClassID"];
            txtBookVersionD.Text = dr["BookVersion"].ToString();
        }

        private void rbNewBook_Click(object sender, EventArgs e)
        {
            txtBookIDD.Enabled = true;
        }

        private void rbModify_Click(object sender, EventArgs e)
        {
            txtBookIDD.Enabled = false;
        }

        private void btnConfirmD_Click(object sender, EventArgs e)   //图书管理选项卡”确认“按钮（单击事件）
        {
            string bookname = txtBookNameD2.Text.Trim();

            DateTime publishDate;
            int wordCount;
            int pageCount;

            foreach (Control con in gbInsertBook.Controls)
            {
                if (con is TextBox && con.Text.Trim() == "")
                {
                    MessageBox.Show("请输入所有内容！");
                    ((TextBox)con).Focus();
                    return;
                }
            }
            string bookid = txtBookIDD.Text.Trim();
            if (!inPutCheck.CheckBookID(bookid))
            {
                MessageBox.Show("图书编号不能少于6位字符！");
                return;
            }
            string bookName = txtBookNameD.Text.Trim();

            try
            {
                publishDate = Convert.ToDateTime(txtPublishDateD.Text.Trim());
            }
            catch
            {
                MessageBox.Show("您输入的日期不正确！");
                txtPublishDateD.Focus();
                return;
            }
            string isbn = txtISBND.Text.Trim().Replace("-", "");
            if (!inPutCheck.CheckISBN(isbn))
            {
                MessageBox.Show("无效的ISBN！");
                return;
            }
            string author = txtAuthorD.Text.Trim();
            string publisher = txtPublisherD.Text.Trim();

            try
            {
                wordCount = Convert.ToInt32(txtWordCountD.Text.Trim());
            }
            catch
            {
                MessageBox.Show("字数必须是数字！");
                txtWordCountD.Focus();
                return;
            }
            try
            {
                pageCount = Convert.ToInt32(txtPageCountD.Text.Trim());
            }
            catch
            {
                MessageBox.Show("页数数必须是数字！");
                txtPageCountD.Focus();
                return;
            }

            string classid = Convert.ToString(cbBookTypeD1.SelectedValue).Trim();
            string bookVersion = txtBookVersionD.Text.Trim();

            if (rbNewBook.Checked) //新书入库
            {
                if (logic.InsertNewBook(bookid, isbn, bookName, author, publishDate, bookVersion, wordCount, pageCount, publisher, classid))
                {
                    MessageBox.Show("入库成功！");
                    dataGrid1.DataSource = logic.GetBookInfoByBookID(bookid).Tables[0];
                    return;
                }
                else
                {
                    MessageBox.Show("入库失败！");
                }
            }
            else if (rbModify.Checked) //更新图书
            {
                try
                {

                    if (logic.UpdateBookInfo(bookid, isbn, bookName, author, publishDate, bookVersion, wordCount, pageCount, publisher, classid))
                    {
                        MessageBox.Show("更新成功！");
                        dataGrid1.DataSource = logic.GetBookInfo(bookname, classid).Tables[0];
                        dataGrid1.Rows[currentRowIndex].Selected = true;
                        dataGrid1.CurrentCell.Selected = false;
                        dataGrid1.CurrentCell = dataGrid1.Rows[currentRowIndex].Cells[0];
                        return;
                    }
                    else
                    {
                        MessageBox.Show("更新失败1");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnDelD_Click(object sender, EventArgs e)     //图书管理选项卡”删除“按钮（单击事件）
        {
           
                string classid = Convert.ToString(cbBookTypeD1.SelectedValue);
                string bookname = txtBookNameD2.Text.Trim();
                DialogResult result = MessageBox.Show("确认要删除吗?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (logic.DeleteBook(deleteBookID))
                    {
                        MessageBox.Show("删除成功！");
                        dataGrid1.DataSource = logic.GetBookInfo(bookname, classid).Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    return;
                }                     
       }

        private void btnCancelD_Click(object sender, EventArgs e)  //图书管理选项卡”取消“按钮（单击事件）
        {
            foreach (Control con in gbInsertBook.Controls)
            {
                if (con is TextBox)
                {
                    ((TextBox)con).Clear();
                }
            }
        }

        private void btnSearchE_Click(object sender, EventArgs e)
        {
            switch (cbSearchCondition.SelectedIndex)
            {
                case 0: dgResultE.DataSource = logic.GetBookStatisticInfo().Tables[0]; break;
                case 1: dgResultE.DataSource = logic.ReadingStar().Tables[0]; break;
                case 2: dgResultE.DataSource = logic.TheMostPopularBook().Tables[0]; break;

                default:
                    dgResultE.DataSource = null;
                    MessageBox.Show("请选择查询条件");
                    break;

            }
        }

        private void btnConfirmF_Click(object sender, EventArgs e)
        {

            string oldPassWord = txtOriginalPWD.Text.ToString();
            string newPassWord = txtNewPWD.Text.ToString();
            string confirmPassWoed = txtConfirmPWD.Text.ToString();

            foreach (Control con in groupBox12.Controls)
            {
                if (con is TextBox && con.Text.Trim() == "")
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }
            }

            if (!logic.AdminLogin(adminID, oldPassWord))
            {
                MessageBox.Show("原密码输入不正确！");
                return;
            }

            if (newPassWord != confirmPassWoed)
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            if (!inPutCheck.CheckPassWord(newPassWord))
            {
                MessageBox.Show("密码长度为8-16位字符！");
                return;
            }
            if (logic.AdminLogin(adminID, oldPassWord))
            {
                logic.ChangePassword(adminID, newPassWord);
                MessageBox.Show("密码修改成功！");
            }
            else
            {
                MessageBox.Show("密码修改失败！");
            }



        }

        private void btnCancelF_Click(object sender, EventArgs e)
        {
            txtOriginalPWD.Text = "";
            txtNewPWD.Text = "";
            txtConfirmPWD.Text = "";

        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 续借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void 报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void LibrarySystem_Load(object sender, EventArgs e)
        {

            try
            {
                lblAdminName.Text = logic.GetAdminInfoByID(adminID);

                DataSet dsOne = logic.GetAllBookClass();
                cbBookTypeD1.DataSource = dsOne.Tables[0];
                cbBookTypeD1.DisplayMember = "ClassName";
                cbBookTypeD1.ValueMember = "ClassID";

                DataSet dsTwo = logic.GetAllBookClass();
                cbBookTypeD2.DataSource = dsTwo.Tables[0];
                cbBookTypeD2.DisplayMember = "ClassName";
                cbBookTypeD2.ValueMember = "ClassID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
        }

        private void 默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\DiamondBlue.ssk";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\Eighteen.ssk";
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\Emerald.ssk";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\GlassBrown.ssk";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\Longhorn.ssk";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\MacOS.ssk";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\Midsummer.ssk";
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\MP10.ssk";
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\MSN.ssk";
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Search.skin.SkinFile = "ys\\OneBlue.ssk";
        }
    }
}
