namespace _4SquareLite
{
    partial class frmCheckin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckin));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miCheckin = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlCheckin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbShout = new System.Windows.Forms.TextBox();
            this.lblShoutCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlVenue = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.chkTwitter = new System.Windows.Forms.CheckBox();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.chkFacebook = new System.Windows.Forms.CheckBox();
            this.pnlForm.SuspendLayout();
            this.pnlCheckin.SuspendLayout();
            this.pnlVenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miCheckin);
            this.mainMenu1.MenuItems.Add(this.miBack);
            // 
            // miCheckin
            // 
            this.miCheckin.Text = "Check-in";
            this.miCheckin.Click += new System.EventHandler(this.miCheckin_Click);
            // 
            // miBack
            // 
            this.miBack.Text = "Cancel";
            this.miBack.Click += new System.EventHandler(this.miBack_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.pnlCheckin);
            this.pnlForm.Controls.Add(this.pnlVenue);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // pnlCheckin
            // 
            this.pnlCheckin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckin.Controls.Add(this.chkFacebook);
            this.pnlCheckin.Controls.Add(this.chkPublic);
            this.pnlCheckin.Controls.Add(this.chkTwitter);
            this.pnlCheckin.Controls.Add(this.label1);
            this.pnlCheckin.Controls.Add(this.tbShout);
            this.pnlCheckin.Controls.Add(this.lblShoutCounter);
            this.pnlCheckin.Controls.Add(this.label2);
            this.pnlCheckin.Location = new System.Drawing.Point(3, 58);
            this.pnlCheckin.Name = "pnlCheckin";
            this.pnlCheckin.Size = new System.Drawing.Size(234, 190);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 14);
            this.label1.Text = "Shout";
            // 
            // tbShout
            // 
            this.tbShout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShout.Location = new System.Drawing.Point(0, 17);
            this.tbShout.MaxLength = 140;
            this.tbShout.Multiline = true;
            this.tbShout.Name = "tbShout";
            this.tbShout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbShout.Size = new System.Drawing.Size(234, 75);
            this.tbShout.TabIndex = 1;
            this.tbShout.Text = "123456789a123456789b123456789c123456789d123456789e123456789f123456789g123456789h1" +
                "23456789i123456789j123456789k123456789l123456789m123456789nj";
            this.tbShout.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbShout_KeyUp);
            // 
            // lblShoutCounter
            // 
            this.lblShoutCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShoutCounter.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShoutCounter.Location = new System.Drawing.Point(123, 0);
            this.lblShoutCounter.Name = "lblShoutCounter";
            this.lblShoutCounter.Size = new System.Drawing.Size(111, 14);
            this.lblShoutCounter.Text = "(140 / 140)";
            this.lblShoutCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 14);
            this.label2.Text = "Privacy Settings";
            // 
            // pnlVenue
            // 
            this.pnlVenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVenue.Controls.Add(this.lblCategory);
            this.pnlVenue.Controls.Add(this.pbIcon);
            this.pnlVenue.Controls.Add(this.lblVenue);
            this.pnlVenue.Location = new System.Drawing.Point(3, 20);
            this.pnlVenue.Name = "pnlVenue";
            this.pnlVenue.Size = new System.Drawing.Size(234, 32);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCategory.Location = new System.Drawing.Point(38, 19);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(196, 13);
            this.lblCategory.Text = "Uncategorized";
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            // 
            // lblVenue
            // 
            this.lblVenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVenue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblVenue.Location = new System.Drawing.Point(38, 0);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(196, 13);
            this.lblVenue.Text = "lblVenue";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 14);
            this.lblTitle.Text = "Check-In";
            // 
            // inputPanel1
            // 
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel1_EnabledChanged);
            // 
            // chkTwitter
            // 
            this.chkTwitter.Location = new System.Drawing.Point(26, 134);
            this.chkTwitter.Name = "chkTwitter";
            this.chkTwitter.Size = new System.Drawing.Size(186, 26);
            this.chkTwitter.TabIndex = 8;
            this.chkTwitter.Text = "Post to Twitter";
            // 
            // chkPublic
            // 
            this.chkPublic.Location = new System.Drawing.Point(26, 113);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.Size = new System.Drawing.Size(185, 21);
            this.chkPublic.TabIndex = 9;
            this.chkPublic.Text = "Tell my friends";
            // 
            // chkFacebook
            // 
            this.chkFacebook.Location = new System.Drawing.Point(26, 160);
            this.chkFacebook.Name = "chkFacebook";
            this.chkFacebook.Size = new System.Drawing.Size(197, 22);
            this.chkFacebook.TabIndex = 10;
            this.chkFacebook.Text = "Post to Facebook";
            // 
            // frmCheckin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmCheckin";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmCheckin_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlCheckin.ResumeLayout(false);
            this.pnlVenue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem miCheckin;
        private System.Windows.Forms.MenuItem miBack;
        private System.Windows.Forms.Panel pnlForm;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbShout;
        private System.Windows.Forms.Label lblShoutCounter;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlVenue;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Panel pnlCheckin;
        private System.Windows.Forms.CheckBox chkFacebook;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.CheckBox chkTwitter;
    }
}