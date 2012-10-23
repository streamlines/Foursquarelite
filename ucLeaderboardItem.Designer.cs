namespace _4SquareLite
{
    partial class ucLeaderboardItem
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
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblMaxScoreTitle = new System.Windows.Forms.Label();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.lblMaxScore = new System.Windows.Forms.Label();
            this.lblRecent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbUser
            // 
            this.pbUser.BackColor = System.Drawing.Color.Black;
            this.pbUser.Location = new System.Drawing.Point(2, 2);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(58, 58);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(202, 43);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(37, 20);
            this.lblScore.Text = "999";
            // 
            // lblMaxScoreTitle
            // 
            this.lblMaxScoreTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxScoreTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMaxScoreTitle.Location = new System.Drawing.Point(66, 13);
            this.lblMaxScoreTitle.Name = "lblMaxScoreTitle";
            this.lblMaxScoreTitle.Size = new System.Drawing.Size(100, 13);
            this.lblMaxScoreTitle.Text = "Maximum Score";
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecentTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRecentTitle.Location = new System.Drawing.Point(66, 26);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(100, 13);
            this.lblRecentTitle.Text = "Recent Checkins";
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.Black;
            this.pnlGender.Location = new System.Drawing.Point(0, 0);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(62, 62);
            // 
            // lblScoreTitle
            // 
            this.lblScoreTitle.Location = new System.Drawing.Point(115, 43);
            this.lblScoreTitle.Name = "lblScoreTitle";
            this.lblScoreTitle.Size = new System.Drawing.Size(87, 20);
            this.lblScoreTitle.Text = "Score";
            // 
            // lblMaxScore
            // 
            this.lblMaxScore.Location = new System.Drawing.Point(166, 13);
            this.lblMaxScore.Name = "lblMaxScore";
            this.lblMaxScore.Size = new System.Drawing.Size(74, 13);
            this.lblMaxScore.Text = "999";
            // 
            // lblRecent
            // 
            this.lblRecent.Location = new System.Drawing.Point(166, 26);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(74, 13);
            this.lblRecent.Text = "999";
            // 
            // ucLeaderboardItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lblRecent);
            this.Controls.Add(this.lblMaxScore);
            this.Controls.Add(this.lblScoreTitle);
            this.Controls.Add(this.lblMaxScoreTitle);
            this.Controls.Add(this.lblRecentTitle);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbUser);
            this.Controls.Add(this.pnlGender);
            this.Name = "ucLeaderboardItem";
            this.Size = new System.Drawing.Size(240, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMaxScoreTitle;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.Label lblScoreTitle;
        private System.Windows.Forms.Label lblMaxScore;
        private System.Windows.Forms.Label lblRecent;
    }
}
