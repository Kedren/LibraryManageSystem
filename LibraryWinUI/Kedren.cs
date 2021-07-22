using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.LibraryBusiness;
using System.IO;

namespace Library.LibraryWinUI
{
    public partial class Kedren : Form
    {
        string fname = "";
        private WinLogic logic;
        public Kedren()
        {
            InitializeComponent();
            logic = new WinLogic();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG文件|*.jpg;*.jpeg|GIF文件|*.gif|BMP文件|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = "d:\\Kedren";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog1.FileName;
                if (fname != "")
                {
                    pbPhoto.Image = Image.FromFile(fname);
                }
            }
        }

        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            string userid = txtUserID.Text.Trim();
            if (userid == "")
            {
                MessageBox.Show("UserID不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(fname) || Path.GetFileName(fname) == "no.gif")
            {
                if (logic.InsertKeUser(userid))
                {
                    MessageBox.Show("插入成功！");
                }
                else
                {
                    MessageBox.Show("插入失败！");
                }
            }
            else
            {
                if (logic.InsertKeUser(userid, fname))
                {
                    MessageBox.Show("插入成功！");
                }
                else
                {
                    MessageBox.Show("插入失败！");
                }
            }

        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            string userid = txtUserID.Text.Trim();
            DataTable dt = logic.GetKeUserByUserID(userid).Tables[0];   
     
            if (dt.Rows.Count == 0)
            {
                pbPhoto.Image =null;
                MessageBox.Show("没有这个用户！");
                return;
            }

            DataRow dr = dt.Rows[0];

            if (dr["Photo"] == Convert.DBNull)
            {
                pbPhoto.Image = Image.FromFile("no.gif");
            }
            else
            {
                MemoryStream ms = new MemoryStream(dr["Photo"] as byte[]);
                pbPhoto.Image = Image.FromStream(ms);

            }
        }
    }
}
