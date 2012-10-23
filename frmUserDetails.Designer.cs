namespace _4SquareLite
{
    partial class frmUserDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDetails));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miRefresh = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.lblBadge = new System.Windows.Forms.Label();
            this.pnlMayor = new System.Windows.Forms.Panel();
            this.lblMayor = new System.Windows.Forms.Label();
            this.pnlAcceptReject = new System.Windows.Forms.Panel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnViewFriends = new System.Windows.Forms.Button();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pbTwitter = new System.Windows.Forms.PictureBox();
            this.pbFacebook = new System.Windows.Forms.PictureBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.pnlBadge.SuspendLayout();
            this.pnlMayor.SuspendLayout();
            this.pnlAcceptReject.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miRefresh);
            this.mainMenu1.MenuItems.Add(this.miBack);
            // 
            // miRefresh
            // 
            this.miRefresh.Text = "Refresh";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // miBack
            // 
            this.miBack.Text = "Back";
            this.miBack.Click += new System.EventHandler(this.miBack_Click);
            // 
            // pnlBadge
            // 
            this.pnlBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBadge.Controls.Add(this.lblBadge);
            this.pnlBadge.Location = new System.Drawing.Point(3, 131);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Size = new System.Drawing.Size(234, 14);
            // 
            // lblBadge
            // 
            this.lblBadge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadge.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadge.Location = new System.Drawing.Point(0, 0);
            this.lblBadge.Name = "lblBadge";
            this.lblBadge.Size = new System.Drawing.Size(234, 14);
            this.lblBadge.Text = "Badges";
            // 
            // pnlMayor
            // 
            this.pnlMayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMayor.Controls.Add(this.lblMayor);
            this.pnlMayor.Location = new System.Drawing.Point(3, 151);
            this.pnlMayor.Name = "pnlMayor";
            this.pnlMayor.Size = new System.Drawing.Size(234, 14);
            // 
            // lblMayor
            // 
            this.lblMayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMayor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMayor.Location = new System.Drawing.Point(0, 0);
            this.lblMayor.Name = "lblMayor";
            this.lblMayor.Size = new System.Drawing.Size(234, 14);
            this.lblMayor.Text = "Mayorships";
            // 
            // pnlAcceptReject
            // 
            this.pnlAcceptReject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAcceptReject.Controls.Add(this.btnReject);
            this.pnlAcceptReject.Controls.Add(this.btnAccept);
            this.pnlAcceptReject.Location = new System.Drawing.Point(3, 171);
            this.pnlAcceptReject.Name = "pnlAcceptReject";
            this.pnlAcceptReject.Size = new System.Drawing.Size(234, 46);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Location = new System.Drawing.Point(0, 26);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(234, 20);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(0, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(234, 20);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnViewFriends
            // 
            this.btnViewFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewFriends.Location = new System.Drawing.Point(3, 105);
            this.btnViewFriends.Name = "btnViewFriends";
            this.btnViewFriends.Size = new System.Drawing.Size(234, 20);
            this.btnViewFriends.TabIndex = 8;
            this.btnViewFriends.Text = "View Friends";
            this.btnViewFriends.Click += new System.EventHandler(this.btnViewFriends_Click);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendRequest.Location = new System.Drawing.Point(3, 223);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(234, 20);
            this.btnSendRequest.TabIndex = 9;
            this.btnSendRequest.Text = "Send Friend Request";
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // inputPanel1
            // 
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel1_EnabledChanged);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.pbTwitter);
            this.pnlForm.Controls.Add(this.pbFacebook);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.pnlGender);
            this.pnlForm.Controls.Add(this.btnSendRequest);
            this.pnlForm.Controls.Add(this.pnlAcceptReject);
            this.pnlForm.Controls.Add(this.btnViewFriends);
            this.pnlForm.Controls.Add(this.pnlMayor);
            this.pnlForm.Controls.Add(this.pnlBadge);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // pbTwitter
            // 
            this.pbTwitter.Image = ((System.Drawing.Image)(resources.GetObject("pbTwitter.Image")));
            this.pbTwitter.Location = new System.Drawing.Point(110, 83);
            this.pbTwitter.Name = "pbTwitter";
            this.pbTwitter.Size = new System.Drawing.Size(16, 16);
            this.pbTwitter.Click += new System.EventHandler(this.pbTwitter_Click);
            // 
            // pbFacebook
            // 
            this.pbFacebook.Image = ((System.Drawing.Image)(resources.GetObject("pbFacebook.Image")));
            this.pbFacebook.Location = new System.Drawing.Point(88, 83);
            this.pbFacebook.Name = "pbFacebook";
            this.pbFacebook.Size = new System.Drawing.Size(16, 16);
            this.pbFacebook.Click += new System.EventHandler(this.pbFacebook_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPhone.Location = new System.Drawing.Point(86, 33);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(151, 13);
            this.lblPhone.Text = "lblPhone";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblEmail.Location = new System.Drawing.Point(86, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(151, 13);
            this.lblEmail.Text = "lblEmail";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(3, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(234, 14);
            this.lblName.Text = "lblName";
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Controls.Add(this.pbUser);
            this.pnlGender.Location = new System.Drawing.Point(3, 20);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(79, 79);
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(75, 75);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmUserDetails";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.pnlBadge.ResumeLayout(false);
            this.pnlMayor.ResumeLayout(false);
            this.pnlAcceptReject.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlGender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem miRefresh;
        private System.Windows.Forms.MenuItem miBack;
        private System.Windows.Forms.Panel pnlBadge;
        private System.Windows.Forms.Panel pnlMayor;
        private System.Windows.Forms.Panel pnlAcceptReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnViewFriends;
        private System.Windows.Forms.Button btnSendRequest;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.Label lblMayor;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.PictureBox pbTwitter;
        private System.Windows.Forms.PictureBox pbFacebook;
    }
}