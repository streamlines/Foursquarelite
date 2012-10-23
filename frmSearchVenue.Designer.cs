namespace _4SquareLite
{
    partial class frmSearchVenue
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.miSearch = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblNotWhatYoureLookingFor = new System.Windows.Forms.Label();
            this.btnAddVenue = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.btnMore = new System.Windows.Forms.Button();
            this.pnlMore = new System.Windows.Forms.Panel();
            this.btnLess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pnlForm.SuspendLayout();
            this.pnlMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.miSearch);
            this.mainMenu1.MenuItems.Add(this.miBack);
            // 
            // miSearch
            // 
            this.miSearch.Text = "Search";
            this.miSearch.Click += new System.EventHandler(this.miSearch_Click);
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
            this.pnlForm.Controls.Add(this.lblNotWhatYoureLookingFor);
            this.pnlForm.Controls.Add(this.btnAddVenue);
            this.pnlForm.Controls.Add(this.lblResults);
            this.pnlForm.Controls.Add(this.pnlResults);
            this.pnlForm.Controls.Add(this.btnMore);
            this.pnlForm.Controls.Add(this.pnlMore);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.tbSearch);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // lblNotWhatYoureLookingFor
            // 
            this.lblNotWhatYoureLookingFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotWhatYoureLookingFor.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNotWhatYoureLookingFor.Location = new System.Drawing.Point(3, 229);
            this.lblNotWhatYoureLookingFor.Name = "lblNotWhatYoureLookingFor";
            this.lblNotWhatYoureLookingFor.Size = new System.Drawing.Size(234, 13);
            this.lblNotWhatYoureLookingFor.Text = "Not what you\'re looking for?";
            // 
            // btnAddVenue
            // 
            this.btnAddVenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVenue.Location = new System.Drawing.Point(3, 245);
            this.btnAddVenue.Name = "btnAddVenue";
            this.btnAddVenue.Size = new System.Drawing.Size(234, 20);
            this.btnAddVenue.TabIndex = 2;
            this.btnAddVenue.Text = "Add Venue";
            this.btnAddVenue.Click += new System.EventHandler(this.btnAddVenue_Click);
            // 
            // lblResults
            // 
            this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResults.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblResults.Location = new System.Drawing.Point(3, 176);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(234, 11);
            this.lblResults.Text = "lblResults";
            // 
            // pnlResults
            // 
            this.pnlResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResults.Location = new System.Drawing.Point(3, 190);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(234, 36);
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.Location = new System.Drawing.Point(165, 47);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(72, 20);
            this.btnMore.TabIndex = 27;
            this.btnMore.Text = "more";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // pnlMore
            // 
            this.pnlMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMore.Controls.Add(this.btnLess);
            this.pnlMore.Controls.Add(this.label1);
            this.pnlMore.Controls.Add(this.tbCity);
            this.pnlMore.Controls.Add(this.label4);
            this.pnlMore.Location = new System.Drawing.Point(3, 73);
            this.pnlMore.Name = "pnlMore";
            this.pnlMore.Size = new System.Drawing.Size(234, 75);
            // 
            // btnLess
            // 
            this.btnLess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLess.Location = new System.Drawing.Point(162, 55);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(72, 20);
            this.btnLess.TabIndex = 26;
            this.btnLess.Text = "less";
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.Text = "Nowhere near your last check-in?";
            // 
            // tbCity
            // 
            this.tbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCity.Location = new System.Drawing.Point(0, 29);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(234, 21);
            this.tbCity.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(0, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 13);
            this.label4.Text = "City (optional)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 14);
            this.label2.Text = "Search Venues";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(3, 20);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(234, 21);
            this.tbSearch.TabIndex = 13;
            // 
            // frmSearchVenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmSearchVenue";
            this.Text = "4SquareLite";
            this.Load += new System.EventHandler(this.frmSearchVenue_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlMore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.MenuItem miSearch;
        private System.Windows.Forms.MenuItem miBack;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Panel pnlMore;
        private System.Windows.Forms.Button btnLess;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnAddVenue;
        private System.Windows.Forms.Label lblNotWhatYoureLookingFor;
    }
}