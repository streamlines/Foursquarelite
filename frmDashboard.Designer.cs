namespace _4SquareLite
{
    partial class frmDashboard
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnGPS = new System.Windows.Forms.Button();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.btnShout = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miCheckins = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miSearchUsers = new System.Windows.Forms.MenuItem();
            this.miSearchVenues = new System.Windows.Forms.MenuItem();
            this.miTodos = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.miLogout = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.miRefresh = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.miLeaderboard = new System.Windows.Forms.MenuItem();
            this.pnlForm.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.btnGPS);
            this.pnlForm.Controls.Add(this.pnlGender);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.lblHistory);
            this.pnlForm.Controls.Add(this.btnCheckin);
            this.pnlForm.Controls.Add(this.pnlHistory);
            this.pnlForm.Controls.Add(this.btnShout);
            this.pnlForm.Controls.Add(this.btnPending);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // btnGPS
            // 
            this.btnGPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGPS.Location = new System.Drawing.Point(86, 76);
            this.btnGPS.Name = "btnGPS";
            this.btnGPS.Size = new System.Drawing.Size(151, 20);
            this.btnGPS.TabIndex = 33;
            this.btnGPS.Text = "Use GPS";
            this.btnGPS.Click += new System.EventHandler(this.btnGPS_Click);
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Controls.Add(this.pbUser);
            this.pnlGender.Location = new System.Drawing.Point(3, 43);
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
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(3, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(234, 14);
            this.lblName.Text = "lblName";
            // 
            // lblHistory
            // 
            this.lblHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(3, 125);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(234, 14);
            this.lblHistory.Text = "History";
            // 
            // btnCheckin
            // 
            this.btnCheckin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckin.Location = new System.Drawing.Point(86, 43);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(151, 27);
            this.btnCheckin.TabIndex = 29;
            this.btnCheckin.Text = "Check-In";
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.Location = new System.Drawing.Point(3, 142);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(234, 27);
            // 
            // btnShout
            // 
            this.btnShout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShout.Location = new System.Drawing.Point(86, 102);
            this.btnShout.Name = "btnShout";
            this.btnShout.Size = new System.Drawing.Size(151, 20);
            this.btnShout.TabIndex = 32;
            this.btnShout.Text = "Shout";
            this.btnShout.Click += new System.EventHandler(this.btnShout_Click);
            // 
            // btnPending
            // 
            this.btnPending.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPending.Location = new System.Drawing.Point(3, 3);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(234, 20);
            this.btnPending.TabIndex = 28;
            this.btnPending.Text = "0 Pending Requests";
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.miCheckins);
            this.menuItem2.MenuItems.Add(this.miLeaderboard);
            this.menuItem2.MenuItems.Add(this.menuItem8);
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.MenuItems.Add(this.menuItem11);
            this.menuItem2.MenuItems.Add(this.miLogout);
            this.menuItem2.MenuItems.Add(this.miExit);
            this.menuItem2.MenuItems.Add(this.miAbout);
            this.menuItem2.Text = "Menu";
            // 
            // miCheckins
            // 
            this.miCheckins.Text = "Friend Check-Ins";
            this.miCheckins.Click += new System.EventHandler(this.miCheckins_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.miSearchUsers);
            this.menuItem3.MenuItems.Add(this.miSearchVenues);
            this.menuItem3.MenuItems.Add(this.miTodos);
            this.menuItem3.Text = "Search";
            // 
            // miSearchUsers
            // 
            this.miSearchUsers.Text = "Users";
            this.miSearchUsers.Click += new System.EventHandler(this.miSearchUsers_Click);
            // 
            // miSearchVenues
            // 
            this.miSearchVenues.Text = "Venues";
            this.miSearchVenues.Click += new System.EventHandler(this.miSearchVenues_Click);
            // 
            // miTodos
            // 
            this.miTodos.Text = "Todo\'s";
            this.miTodos.Click += new System.EventHandler(this.miTodos_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Text = "-";
            // 
            // miLogout
            // 
            this.miLogout.Text = "Logout";
            this.miLogout.Click += new System.EventHandler(this.miLogout_Click);
            // 
            // miExit
            // 
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miAbout
            // 
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miRefresh
            // 
            this.miRefresh.Text = "Refresh";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miRefresh);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // inputPanel1
            // 
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel1_EnabledChanged);
            // 
            // miLeaderboard
            // 
            this.miLeaderboard.Text = "Leaderboard";
            this.miLeaderboard.Click += new System.EventHandler(this.miLeaderboard_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmDashboard";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlGender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem miRefresh;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem miCheckins;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem miLogout;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem miExit;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem miSearchUsers;
        private System.Windows.Forms.MenuItem miSearchVenues;
        private System.Windows.Forms.Button btnShout;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Button btnGPS;
        private System.Windows.Forms.MenuItem miAbout;
        private System.Windows.Forms.MenuItem miTodos;
        private System.Windows.Forms.MenuItem miLeaderboard;

    }
}