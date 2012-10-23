namespace _4SquareLite
{
    partial class frmVenueInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenueInput));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miSave = new System.Windows.Forms.MenuItem();
            this.miCancel = new System.Windows.Forms.MenuItem();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.ddlCategory = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlLatLon = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.tbLat = new System.Windows.Forms.TextBox();
            this.lblLat = new System.Windows.Forms.Label();
            this.tbLon = new System.Windows.Forms.TextBox();
            this.lblLon = new System.Windows.Forms.Label();
            this.btnReview = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBasic = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbCrossStreet = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCrossStreet = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblZip = new System.Windows.Forms.Label();
            this.tbZip = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.pnlForm.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.pnlLatLon.SuspendLayout();
            this.pnlBasic.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miSave);
            this.mainMenu1.MenuItems.Add(this.miCancel);
            // 
            // miSave
            // 
            this.miSave.Text = "Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miCancel
            // 
            this.miCancel.Text = "Cancel";
            this.miCancel.Click += new System.EventHandler(this.miCancel_Click);
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
            this.pnlForm.Controls.Add(this.pnlLatLon);
            this.pnlForm.Controls.Add(this.pnlBasic);
            this.pnlForm.Controls.Add(this.pnlCategory);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // pnlCategory
            // 
            this.pnlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategory.Controls.Add(this.ddlCategory);
            this.pnlCategory.Controls.Add(this.comboBox1);
            this.pnlCategory.Controls.Add(this.comboBox2);
            this.pnlCategory.Controls.Add(this.lblCategoryID);
            this.pnlCategory.Controls.Add(this.pbIcon);
            this.pnlCategory.Controls.Add(this.label8);
            this.pnlCategory.Location = new System.Drawing.Point(3, 72);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(234, 94);
            // 
            // ddlCategory
            // 
            this.ddlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCategory.Location = new System.Drawing.Point(78, 0);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(156, 22);
            this.ddlCategory.TabIndex = 33;
            this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Location = new System.Drawing.Point(78, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 22);
            this.comboBox1.TabIndex = 51;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.Location = new System.Drawing.Point(78, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(156, 22);
            this.comboBox2.TabIndex = 52;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategoryID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCategoryID.Location = new System.Drawing.Point(78, 81);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(156, 13);
            this.lblCategoryID.Text = "lblCategoryID";
            this.lblCategoryID.Visible = false;
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(3, 22);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.Text = "Category";
            // 
            // pnlLatLon
            // 
            this.pnlLatLon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLatLon.Controls.Add(this.btnPreview);
            this.pnlLatLon.Controls.Add(this.btnManual);
            this.pnlLatLon.Controls.Add(this.tbLat);
            this.pnlLatLon.Controls.Add(this.lblLat);
            this.pnlLatLon.Controls.Add(this.tbLon);
            this.pnlLatLon.Controls.Add(this.lblLon);
            this.pnlLatLon.Controls.Add(this.btnReview);
            this.pnlLatLon.Location = new System.Drawing.Point(3, 46);
            this.pnlLatLon.Name = "pnlLatLon";
            this.pnlLatLon.Size = new System.Drawing.Size(234, 20);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(0, 0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(234, 20);
            this.btnPreview.TabIndex = 29;
            this.btnPreview.Text = "Preview Map";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnManual
            // 
            this.btnManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManual.Location = new System.Drawing.Point(0, 26);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(234, 20);
            this.btnManual.TabIndex = 30;
            this.btnManual.Text = "Enter Coordinates Manually";
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // tbLat
            // 
            this.tbLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLat.Enabled = false;
            this.tbLat.Location = new System.Drawing.Point(78, 52);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(156, 21);
            this.tbLat.TabIndex = 34;
            // 
            // lblLat
            // 
            this.lblLat.Location = new System.Drawing.Point(0, 55);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(72, 15);
            this.lblLat.Text = "Latitude";
            // 
            // tbLon
            // 
            this.tbLon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLon.Enabled = false;
            this.tbLon.Location = new System.Drawing.Point(78, 79);
            this.tbLon.Name = "tbLon";
            this.tbLon.Size = new System.Drawing.Size(156, 21);
            this.tbLon.TabIndex = 35;
            // 
            // lblLon
            // 
            this.lblLon.Location = new System.Drawing.Point(0, 82);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(72, 15);
            this.lblLon.Text = "Longitude";
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReview.Enabled = false;
            this.btnReview.Location = new System.Drawing.Point(0, 106);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(234, 20);
            this.btnReview.TabIndex = 40;
            this.btnReview.Text = "Review Map";
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 14);
            this.lblTitle.Text = "lblTitle";
            // 
            // pnlBasic
            // 
            this.pnlBasic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBasic.Controls.Add(this.lblName);
            this.pnlBasic.Controls.Add(this.tbName);
            this.pnlBasic.Controls.Add(this.tbAddress);
            this.pnlBasic.Controls.Add(this.tbCrossStreet);
            this.pnlBasic.Controls.Add(this.lblAddress);
            this.pnlBasic.Controls.Add(this.lblCrossStreet);
            this.pnlBasic.Controls.Add(this.lblCity);
            this.pnlBasic.Controls.Add(this.tbCity);
            this.pnlBasic.Controls.Add(this.tbState);
            this.pnlBasic.Controls.Add(this.lblState);
            this.pnlBasic.Controls.Add(this.lblZip);
            this.pnlBasic.Controls.Add(this.tbZip);
            this.pnlBasic.Controls.Add(this.lblPhone);
            this.pnlBasic.Controls.Add(this.tbPhone);
            this.pnlBasic.Location = new System.Drawing.Point(3, 20);
            this.pnlBasic.Name = "pnlBasic";
            this.pnlBasic.Size = new System.Drawing.Size(234, 21);
            // 
            // lblName
            // 
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(0, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 15);
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BackColor = System.Drawing.SystemColors.Info;
            this.tbName.Location = new System.Drawing.Point(78, 0);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(156, 21);
            this.tbName.TabIndex = 1;
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(78, 27);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(156, 21);
            this.tbAddress.TabIndex = 2;
            // 
            // tbCrossStreet
            // 
            this.tbCrossStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCrossStreet.Location = new System.Drawing.Point(78, 54);
            this.tbCrossStreet.Name = "tbCrossStreet";
            this.tbCrossStreet.Size = new System.Drawing.Size(156, 21);
            this.tbCrossStreet.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(0, 30);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(72, 15);
            this.lblAddress.Text = "Address";
            // 
            // lblCrossStreet
            // 
            this.lblCrossStreet.Location = new System.Drawing.Point(0, 57);
            this.lblCrossStreet.Name = "lblCrossStreet";
            this.lblCrossStreet.Size = new System.Drawing.Size(72, 15);
            this.lblCrossStreet.Text = "Cross Street";
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(0, 84);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(72, 15);
            this.lblCity.Text = "City";
            // 
            // tbCity
            // 
            this.tbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCity.Location = new System.Drawing.Point(78, 81);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(156, 21);
            this.tbCity.TabIndex = 4;
            // 
            // tbState
            // 
            this.tbState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbState.Location = new System.Drawing.Point(78, 108);
            this.tbState.Name = "tbState";
            this.tbState.Size = new System.Drawing.Size(156, 21);
            this.tbState.TabIndex = 5;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(0, 111);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(72, 15);
            this.lblState.Text = "State";
            // 
            // lblZip
            // 
            this.lblZip.Location = new System.Drawing.Point(0, 138);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(72, 15);
            this.lblZip.Text = "Zip";
            // 
            // tbZip
            // 
            this.tbZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZip.Location = new System.Drawing.Point(78, 135);
            this.tbZip.Name = "tbZip";
            this.tbZip.Size = new System.Drawing.Size(156, 21);
            this.tbZip.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(0, 165);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(72, 15);
            this.lblPhone.Text = "Phone";
            // 
            // tbPhone
            // 
            this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhone.Location = new System.Drawing.Point(78, 162);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(156, 21);
            this.tbPhone.TabIndex = 7;
            // 
            // frmVenueInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmVenueInput";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmVenueInput_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.pnlLatLon.ResumeLayout(false);
            this.pnlBasic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.MenuItem miSave;
        private System.Windows.Forms.MenuItem miCancel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbZip;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbCrossStreet;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCrossStreet;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.TextBox tbLon;
        private System.Windows.Forms.TextBox tbLat;
        private System.Windows.Forms.ComboBox ddlCategory;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Panel pnlBasic;
        private System.Windows.Forms.Panel pnlLatLon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCategory;
    }
}