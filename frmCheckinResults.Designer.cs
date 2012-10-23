namespace _4SquareLite
{
    partial class frmCheckinResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckinResults));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlSpecials = new System.Windows.Forms.Panel();
            this.lblSpecials = new System.Windows.Forms.Label();
            this.pnlScores = new System.Windows.Forms.Panel();
            this.lblScores = new System.Windows.Forms.Label();
            this.pnlBadges = new System.Windows.Forms.Panel();
            this.lblBadges = new System.Windows.Forms.Label();
            this.pnlMayor = new System.Windows.Forms.Panel();
            this.lblMayorType = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblMayorCheckins = new System.Windows.Forms.Label();
            this.lblMayorMessage = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlVenue = new System.Windows.Forms.Panel();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblVenueName = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm.SuspendLayout();
            this.pnlSpecials.SuspendLayout();
            this.pnlScores.SuspendLayout();
            this.pnlBadges.SuspendLayout();
            this.pnlMayor.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.pnlVenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.miBack);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = " ";
            // 
            // miBack
            // 
            this.miBack.Text = "Back";
            this.miBack.Click += new System.EventHandler(this.miBack_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.SystemColors.Info;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMessage.Location = new System.Drawing.Point(3, 18);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(234, 64);
            this.lblMessage.Text = "123456789a123456789b123456789c123456789d123456789e123456789f123456789g123456789h1" +
                "23456789i123456789j123456789k123456789l123456789m123456789n123456789o123456789p1" +
                "23456789q";
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimestamp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimestamp.Location = new System.Drawing.Point(3, 3);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(234, 15);
            this.lblTimestamp.Text = "lblTimestamp";
            this.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.pnlSpecials);
            this.pnlForm.Controls.Add(this.pnlScores);
            this.pnlForm.Controls.Add(this.pnlBadges);
            this.pnlForm.Controls.Add(this.pnlMayor);
            this.pnlForm.Controls.Add(this.pnlVenue);
            this.pnlForm.Controls.Add(this.lblMessage);
            this.pnlForm.Controls.Add(this.lblTimestamp);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // pnlSpecials
            // 
            this.pnlSpecials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSpecials.Controls.Add(this.lblSpecials);
            this.pnlSpecials.Location = new System.Drawing.Point(3, 236);
            this.pnlSpecials.Name = "pnlSpecials";
            this.pnlSpecials.Size = new System.Drawing.Size(234, 14);
            // 
            // lblSpecials
            // 
            this.lblSpecials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpecials.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSpecials.Location = new System.Drawing.Point(0, 0);
            this.lblSpecials.Name = "lblSpecials";
            this.lblSpecials.Size = new System.Drawing.Size(234, 14);
            this.lblSpecials.Text = "Specials";
            // 
            // pnlScores
            // 
            this.pnlScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScores.Controls.Add(this.lblScores);
            this.pnlScores.Location = new System.Drawing.Point(3, 219);
            this.pnlScores.Name = "pnlScores";
            this.pnlScores.Size = new System.Drawing.Size(234, 14);
            // 
            // lblScores
            // 
            this.lblScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScores.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblScores.Location = new System.Drawing.Point(0, 0);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(234, 14);
            this.lblScores.Text = "Scores";
            // 
            // pnlBadges
            // 
            this.pnlBadges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBadges.Controls.Add(this.lblBadges);
            this.pnlBadges.Location = new System.Drawing.Point(3, 202);
            this.pnlBadges.Name = "pnlBadges";
            this.pnlBadges.Size = new System.Drawing.Size(234, 14);
            // 
            // lblBadges
            // 
            this.lblBadges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadges.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadges.Location = new System.Drawing.Point(0, 0);
            this.lblBadges.Name = "lblBadges";
            this.lblBadges.Size = new System.Drawing.Size(234, 14);
            this.lblBadges.Text = "Badges";
            // 
            // pnlMayor
            // 
            this.pnlMayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMayor.Controls.Add(this.lblMayorType);
            this.pnlMayor.Controls.Add(this.pnlGender);
            this.pnlMayor.Controls.Add(this.lblMayorCheckins);
            this.pnlMayor.Controls.Add(this.lblMayorMessage);
            this.pnlMayor.Controls.Add(this.lblUserName);
            this.pnlMayor.Location = new System.Drawing.Point(3, 120);
            this.pnlMayor.Name = "pnlMayor";
            this.pnlMayor.Size = new System.Drawing.Size(234, 79);
            // 
            // lblMayorType
            // 
            this.lblMayorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMayorType.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblMayorType.Location = new System.Drawing.Point(83, 24);
            this.lblMayorType.Name = "lblMayorType";
            this.lblMayorType.Size = new System.Drawing.Size(151, 14);
            this.lblMayorType.Text = "Long live the Mayor!";
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Controls.Add(this.pbUser);
            this.pnlGender.Location = new System.Drawing.Point(0, 0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(79, 79);
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(75, 75);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.Click += new System.EventHandler(this.pbUser_Click);
            // 
            // lblMayorCheckins
            // 
            this.lblMayorCheckins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMayorCheckins.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblMayorCheckins.Location = new System.Drawing.Point(83, 13);
            this.lblMayorCheckins.Name = "lblMayorCheckins";
            this.lblMayorCheckins.Size = new System.Drawing.Size(151, 11);
            this.lblMayorCheckins.Text = "999 check-ins here";
            // 
            // lblMayorMessage
            // 
            this.lblMayorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMayorMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMayorMessage.Location = new System.Drawing.Point(83, 38);
            this.lblMayorMessage.Name = "lblMayorMessage";
            this.lblMayorMessage.Size = new System.Drawing.Size(151, 44);
            this.lblMayorMessage.Text = "Dan M. is The Mayor of Bowery Wine Company.";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(83, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(151, 13);
            this.lblUserName.Text = "lblUserName";
            // 
            // pnlVenue
            // 
            this.pnlVenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVenue.Controls.Add(this.lblAddress);
            this.pnlVenue.Controls.Add(this.lblVenueName);
            this.pnlVenue.Controls.Add(this.pbIcon);
            this.pnlVenue.Location = new System.Drawing.Point(3, 85);
            this.pnlVenue.Name = "pnlVenue";
            this.pnlVenue.Size = new System.Drawing.Size(234, 32);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblAddress.Location = new System.Drawing.Point(38, 21);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(196, 11);
            this.lblAddress.Text = "lblAddress";
            // 
            // lblVenueName
            // 
            this.lblVenueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVenueName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblVenueName.Location = new System.Drawing.Point(38, 0);
            this.lblVenueName.Name = "lblVenueName";
            this.lblVenueName.Size = new System.Drawing.Size(196, 13);
            this.lblVenueName.Text = "lblVenueName";
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // inputPanel1
            // 
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel1_EnabledChanged);
            // 
            // frmCheckinResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Menu = this.mainMenu1;
            this.Name = "frmCheckinResults";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmCheckinResults_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlSpecials.ResumeLayout(false);
            this.pnlScores.ResumeLayout(false);
            this.pnlBadges.ResumeLayout(false);
            this.pnlMayor.ResumeLayout(false);
            this.pnlGender.ResumeLayout(false);
            this.pnlVenue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Panel pnlForm;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miBack;
        private System.Windows.Forms.Panel pnlVenue;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.Panel pnlMayor;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblVenueName;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblMayorMessage;
        private System.Windows.Forms.Label lblMayorCheckins;
        private System.Windows.Forms.Label lblMayorType;
        private System.Windows.Forms.Panel pnlBadges;
        private System.Windows.Forms.Label lblBadges;
        private System.Windows.Forms.Panel pnlScores;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Panel pnlSpecials;
        private System.Windows.Forms.Label lblSpecials;
    }
}