namespace _4SquareLite
{
    partial class ucCheckinListItem
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
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblShout = new System.Windows.Forms.Label();
            this.pnlGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimestamp.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblTimestamp.Location = new System.Drawing.Point(66, 51);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(174, 11);
            this.lblTimestamp.Text = "lblTimestamp";
            this.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(66, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(174, 13);
            this.lblName.Text = "lblDisplay";
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Controls.Add(this.pbUser);
            this.pnlGender.Location = new System.Drawing.Point(0, 0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(62, 62);
            // 
            // pbUser
            // 
            this.pbUser.Location = new System.Drawing.Point(2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(58, 58);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.Click += new System.EventHandler(this.ucCheckinListItem_Click);
            // 
            // lblVenue
            // 
            this.lblVenue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVenue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblVenue.Location = new System.Drawing.Point(66, 13);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(174, 13);
            this.lblVenue.Text = "lblVenue";
            // 
            // lblShout
            // 
            this.lblShout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShout.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShout.Location = new System.Drawing.Point(66, 26);
            this.lblShout.Name = "lblShout";
            this.lblShout.Size = new System.Drawing.Size(174, 13);
            this.lblShout.Text = "lblShout";
            // 
            // ucCheckinListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblShout);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.pnlGender);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTimestamp);
            this.Name = "ucCheckinListItem";
            this.Size = new System.Drawing.Size(240, 62);
            this.Click += new System.EventHandler(this.ucCheckinListItem_Click);
            this.pnlGender.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblShout;
    }
}
