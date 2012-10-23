namespace _4SquareLite
{
    partial class frmCheckinDetails
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miBack = new System.Windows.Forms.MenuItem();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlShout = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbShout = new System.Windows.Forms.TextBox();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.pnlForm.SuspendLayout();
            this.pnlShout.SuspendLayout();
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
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.pnlShout);
            this.pnlForm.Controls.Add(this.lblTimestamp);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(240, 268);
            // 
            // pnlShout
            // 
            this.pnlShout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShout.Controls.Add(this.label1);
            this.pnlShout.Controls.Add(this.tbShout);
            this.pnlShout.Location = new System.Drawing.Point(3, 20);
            this.pnlShout.Name = "pnlShout";
            this.pnlShout.Size = new System.Drawing.Size(234, 92);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 14);
            this.label1.Text = "Shout";
            // 
            // tbShout
            // 
            this.tbShout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShout.Location = new System.Drawing.Point(0, 17);
            this.tbShout.Multiline = true;
            this.tbShout.Name = "tbShout";
            this.tbShout.ReadOnly = true;
            this.tbShout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbShout.Size = new System.Drawing.Size(234, 75);
            this.tbShout.TabIndex = 3;
            this.tbShout.Text = "Line 1\r\nLine 2\r\nLine 3\r\nLine 4\r\nLine 5";
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimestamp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimestamp.Location = new System.Drawing.Point(3, 3);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(234, 14);
            this.lblTimestamp.Text = "lblTimestamp";
            this.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // inputPanel1
            // 
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel1_EnabledChanged);
            // 
            // frmCheckinDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlForm);
            this.Menu = this.mainMenu1;
            this.Name = "frmCheckinDetails";
            this.Text = "4SquareLite";
            this.pnlForm.ResumeLayout(false);
            this.pnlShout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miBack;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbShout;
        private System.Windows.Forms.Panel pnlShout;
    }
}