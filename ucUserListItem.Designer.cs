namespace _4SquareLite
{
    partial class ucUserListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserListItem));
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pbFacebook = new System.Windows.Forms.PictureBox();
            this.pbTwitter = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(58, 58);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.Click += new System.EventHandler(this.pbUser_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(66, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(174, 13);
            this.lblName.Text = "lblName";
            // 
            // pbFacebook
            // 
            this.pbFacebook.Image = ((System.Drawing.Image)(resources.GetObject("pbFacebook.Image")));
            this.pbFacebook.Location = new System.Drawing.Point(66, 42);
            this.pbFacebook.Name = "pbFacebook";
            this.pbFacebook.Size = new System.Drawing.Size(16, 16);
            this.pbFacebook.Click += new System.EventHandler(this.pbFacebook_Click);
            // 
            // pbTwitter
            // 
            this.pbTwitter.Image = ((System.Drawing.Image)(resources.GetObject("pbTwitter.Image")));
            this.pbTwitter.Location = new System.Drawing.Point(88, 42);
            this.pbTwitter.Name = "pbTwitter";
            this.pbTwitter.Size = new System.Drawing.Size(16, 16);
            this.pbTwitter.Click += new System.EventHandler(this.pbTwitter_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblUserID.Location = new System.Drawing.Point(110, 45);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(130, 13);
            this.lblUserID.Text = "lblUserID";
            this.lblUserID.Visible = false;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPhone.Location = new System.Drawing.Point(66, 26);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(174, 13);
            this.lblPhone.Text = "lblPhone";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblEmail.Location = new System.Drawing.Point(66, 13);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(174, 13);
            this.lblEmail.Text = "lblEmail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Controls.Add(this.pbUser);
            this.pnlGender.Location = new System.Drawing.Point(0, 0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(62, 62);
            // 
            // ucUserListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlGender);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.pbTwitter);
            this.Controls.Add(this.pbFacebook);
            this.Controls.Add(this.lblName);
            this.Name = "ucUserListItem";
            this.Size = new System.Drawing.Size(240, 62);
            this.pnlGender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbFacebook;
        private System.Windows.Forms.PictureBox pbTwitter;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel pnlGender;


    }
}
