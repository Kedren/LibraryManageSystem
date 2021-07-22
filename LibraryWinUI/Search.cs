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
using Sunisoft.IrisSkin;

namespace Library.LibraryWinUI
{  
    public partial class Search : Form
    {

        private WinLogic logic;
        public static SkinEngine skin;     
        public Search()
        {
            InitializeComponent();
            logic = new WinLogic();
            skin = new SkinEngine();
            skin.SkinFile = "ys\\DiamondBlue.ssk";
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {

            
            string adminID=txtAdminiID.Text.ToString();
            string adminPWD = txtPasswWord.Text.ToString();

             if(string.IsNullOrEmpty(adminID)||string.IsNullOrEmpty(adminPWD))
             {
                 MessageBox.Show("用户名和密码不能为空！");
                 return;
             }

           if(logic.AdminLogin(adminID,adminPWD))
           {
               LibrarySystem ls = new LibrarySystem(adminID);   
               this.Hide();
               ls.ShowDialog();
               this.Show();
               txtAdminiID.Clear(); 
               txtPasswWord.Clear();
               
           }
            
            else
           {
               txtPasswWord.Text = "";
               MessageBox.Show("用户名或密码不正确！");         
               txtPasswWord.Focus();            
           }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAdminiID.Clear(); 
            txtPasswWord.Clear();
            txtAdminiID.Focus();
        }
    }
}
