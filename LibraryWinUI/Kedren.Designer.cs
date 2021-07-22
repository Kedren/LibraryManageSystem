namespace Library.LibraryWinUI
{
    partial class Kedren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnInsertUser = new System.Windows.Forms.Button();
            this.btnGetUser = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("宋体", 20F);
            this.lblUser.Location = new System.Drawing.Point(62, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 27);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "UserID:";
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("宋体", 20F);
            this.txtUserID.Location = new System.Drawing.Point(164, 60);
            this.txtUserID.Multiline = true;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(158, 37);
            this.txtUserID.TabIndex = 1;
            // 
            // btnInsertUser
            // 
            this.btnInsertUser.Location = new System.Drawing.Point(115, 310);
            this.btnInsertUser.Name = "btnInsertUser";
            this.btnInsertUser.Size = new System.Drawing.Size(121, 57);
            this.btnInsertUser.TabIndex = 3;
            this.btnInsertUser.Text = "插入读者信息";
            this.btnInsertUser.UseVisualStyleBackColor = true;
            this.btnInsertUser.Click += new System.EventHandler(this.btnInsertUser_Click);
            // 
            // btnGetUser
            // 
            this.btnGetUser.Location = new System.Drawing.Point(417, 310);
            this.btnGetUser.Name = "btnGetUser";
            this.btnGetUser.Size = new System.Drawing.Size(121, 57);
            this.btnGetUser.TabIndex = 4;
            this.btnGetUser.Text = "读取读者信息";
            this.btnGetUser.UseVisualStyleBackColor = true;
            this.btnGetUser.Click += new System.EventHandler(this.btnGetUser_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(400, 33);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(174, 217);
            this.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhoto.TabIndex = 2;
            this.pbPhoto.TabStop = false;
            this.toolTip1.SetToolTip(this.pbPhoto, "请单击这添加照片");
            this.pbPhoto.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Kedren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 415);
            this.Controls.Add(this.btnGetUser);
            this.Controls.Add(this.btnInsertUser);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblUser);
            this.Name = "Kedren";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kedren";
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.Button btnInsertUser;
        private System.Windows.Forms.Button btnGetUser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}