namespace _4SquareLite
{
    partial class frmVenueDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenueDetails));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miRefresh = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.miCheckin = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miNearbyTips = new System.Windows.Forms.MenuItem();
            this.miNearbyVenues = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.miAddTip = new System.Windows.Forms.MenuItem();
            this.miAddVenue = new System.Windows.Forms.MenuItem();
            this.miProposeEdit = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.miFlagClose = new System.Windows.Forms.MenuItem();
            this.miFlagMislocated = new System.Windows.Forms.MenuItem();
            this.miFlagDuplicate = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.pnlTips = new System.Windows.Forms.Panel();
            this.lblTips = new System.Windows.Forms.Label();
            this.pnlTags = new System.Windows.Forms.Panel();
            this.lblTags = new System.Windows.Forms.Label();
            this.pnlSpecials = new System.Windows.Forms.Panel();
            this.lblSpecials = new System.Windows.Forms.Label();
            this.lblCheckins = new System.Windows.Forms.Label();
            this.pnlMayor = new System.Windows.Forms.Panel();
            this.lblMayor = new System.Windows.Forms.Label();
            this.pbTwitter = new System.Windows.Forms.PictureBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlForm.SuspendLayout();
            this.pnlTips.SuspendLayout();
            this.pnlTags.SuspendLayout();
            this.pnlSpecials.SuspendLayout();
            this.pnlMayor.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miRefresh);
            this.mainMenu1.MenuItems.Add(this.menuItem4);
            // 
            // miRefresh
            // 
            this.miRefresh.Text = "Refresh";
            // 
            // menuItem4
            // 
            this.menuItem4.MenuItems.Add(this.miCheckin);
            this.menuItem4.MenuItems.Add(this.menuItem2);
            this.menuItem4.MenuItems.Add(this.menuItem3);
            this.menuItem4.MenuItems.Add(this.menuItem12);
            this.menuItem4.MenuItems.Add(this.miProposeEdit);
            this.menuItem4.MenuItems.Add(this.menuItem7);
            this.menuItem4.MenuItems.Add(this.menuItem8);
            this.menuItem4.MenuItems.Add(this.miBack);
            this.menuItem4.Text = "Menu";
            // 
            // miCheckin
            // 
            this.miCheckin.Text = "Check In Here";
            this.miCheckin.Click += new System.EventHandler(this.miCheckin_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.miNearbyTips);
            this.menuItem2.MenuItems.Add(this.miNearbyVenues);
            this.menuItem2.Text = "Nearby";
            // 
            // miNearbyTips
            // 
            this.miNearbyTips.Text = "Tips";
            this.miNearbyTips.Click += new System.EventHandler(this.miNearbyTips_Click);
            // 
            // miNearbyVenues
            // 
            this.miNearbyVenues.Text = "Venues";
            this.miNearbyVenues.Click += new System.EventHandler(this.miNearbyVenues_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.MenuItems.Add(this.miAddTip);
            this.menuItem12.MenuItems.Add(this.miAddVenue);
            this.menuItem12.Text = "Add";
            // 
            // miAddTip
            // 
            this.miAddTip.Text = "Tip";
            this.miAddTip.Click += new System.EventHandler(this.miAddTip_Click);
            // 
            // miAddVenue
            // 
            this.miAddVenue.Text = "Venue";
            this.miAddVenue.Click += new System.EventHandler(this.miAddVenue_Click);
            // 
            // miProposeEdit
            // 
            this.miProposeEdit.Text = "Propose Edit";
            this.miProposeEdit.Click += new System.EventHandler(this.miProposeEdit_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Enabled = false;
            this.menuItem7.MenuItems.Add(this.miFlagClose);
            this.menuItem7.MenuItems.Add(this.miFlagMislocated);
            this.menuItem7.MenuItems.Add(this.miFlagDuplicate);
            this.menuItem7.Text = "Flag As";
            // 
            // miFlagClose
            // 
            this.miFlagClose.Text = "Closed";
            this.miFlagClose.Click += new System.EventHandler(this.miFlagClose_Click);
            // 
            // miFlagMislocated
            // 
            this.miFlagMislocated.Text = "Mislocated";
            this.miFlagMislocated.Click += new System.EventHandler(this.miFlagMislocated_Click);
            // 
            // miFlagDuplicate
            // 
            this.miFlagDuplicate.Text = "Duplicate";
            this.miFlagDuplicate.Click += new System.EventHandler(this.miFlagDuplicate_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "-";
            // 
            // miBack
            // 
            this.miBack.Text = "Back";
            this.miBack.Click += new System.EventHandler(this.miBack_Click);
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
            this.pnlForm.Controls.Add(this.btnViewUsers);
            this.pnlForm.Controls.Add(this.pnlTips);
            this.pnlForm.Controls.Add(this.pnlTags);
            this.pnlForm.Controls.Add(this.pnlSpecials);
            this.pnlForm.Controls.Add(this.lblCheckins);
            this.pnlForm.Controls.Add(this.pnlMayor);
            this.pnlForm.Controls.Add(this.pbTwitter);
            this.pnlForm.Controls.Add(this.lblAddress);
            this.pnlForm.Controls.Add(this.pbMap);
            this.pnlForm.Controls.Add(this.lblCategory);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.pbIcon);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewUsers.Location = new System.Drawing.Point(3, 151);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(234, 20);
            this.btnViewUsers.TabIndex = 1;
            this.btnViewUsers.Text = "btnViewUsers";
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // pnlTips
            // 
            this.pnlTips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTips.Controls.Add(this.lblTips);
            this.pnlTips.Location = new System.Drawing.Point(3, 197);
            this.pnlTips.Name = "pnlTips";
            this.pnlTips.Size = new System.Drawing.Size(234, 14);
            // 
            // lblTips
            // 
            this.lblTips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTips.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTips.Location = new System.Drawing.Point(0, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(234, 14);
            this.lblTips.Text = "Tips";
            // 
            // pnlTags
            // 
            this.pnlTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTags.Controls.Add(this.lblTags);
            this.pnlTags.Location = new System.Drawing.Point(3, 217);
            this.pnlTags.Name = "pnlTags";
            this.pnlTags.Size = new System.Drawing.Size(234, 14);
            // 
            // lblTags
            // 
            this.lblTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTags.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTags.Location = new System.Drawing.Point(0, 0);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(234, 14);
            this.lblTags.Text = "Tags";
            // 
            // pnlSpecials
            // 
            this.pnlSpecials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSpecials.Controls.Add(this.lblSpecials);
            this.pnlSpecials.Location = new System.Drawing.Point(3, 237);
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
            // lblCheckins
            // 
            this.lblCheckins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckins.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCheckins.Location = new System.Drawing.Point(60, 39);
            this.lblCheckins.Name = "lblCheckins";
            this.lblCheckins.Size = new System.Drawing.Size(177, 13);
            this.lblCheckins.Text = "lblCheckins";
            this.lblCheckins.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlMayor
            // 
            this.pnlMayor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMayor.Controls.Add(this.lblMayor);
            this.pnlMayor.Location = new System.Drawing.Point(3, 177);
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
            this.lblMayor.Text = "Mayor";
            // 
            // pbTwitter
            // 
            this.pbTwitter.Image = ((System.Drawing.Image)(resources.GetObject("pbTwitter.Image")));
            this.pbTwitter.Location = new System.Drawing.Point(41, 36);
            this.pbTwitter.Name = "pbTwitter";
            this.pbTwitter.Size = new System.Drawing.Size(16, 16);
            this.pbTwitter.Click += new System.EventHandler(this.pbTwitter_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblAddress.Location = new System.Drawing.Point(3, 122);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(234, 26);
            this.lblAddress.Text = "lblAddress\r\nLine 2 j";
            // 
            // pbMap
            // 
            this.pbMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMap.Location = new System.Drawing.Point(3, 55);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(234, 64);
            this.pbMap.Click += new System.EventHandler(this.pbMap_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCategory.Location = new System.Drawing.Point(41, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(196, 15);
            this.lblCategory.Text = "Uncategorized";
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
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(3, 20);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            // 
            // frmVenueDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmVenueDetails";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmVenueDetails_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlTips.ResumeLayout(false);
            this.pnlTags.ResumeLayout(false);
            this.pnlSpecials.ResumeLayout(false);
            this.pnlMayor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCheckins;
        private System.Windows.Forms.Panel pnlMayor;
        private System.Windows.Forms.Panel pnlTags;
        private System.Windows.Forms.Panel pnlSpecials;
        private System.Windows.Forms.PictureBox pbTwitter;
        private System.Windows.Forms.MenuItem miRefresh;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Panel pnlTips;
        private System.Windows.Forms.MenuItem miCheckin;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem miNearbyTips;
        private System.Windows.Forms.MenuItem miNearbyVenues;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem miFlagClose;
        private System.Windows.Forms.MenuItem miFlagMislocated;
        private System.Windows.Forms.MenuItem miFlagDuplicate;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem miBack;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem miAddTip;
        private System.Windows.Forms.MenuItem miAddVenue;
        private System.Windows.Forms.MenuItem miProposeEdit;
        private System.Windows.Forms.Label lblMayor;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.Label lblSpecials;
        private System.Windows.Forms.Button btnViewUsers;
    }
}