using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _4SquareLite
{
    public partial class frmSearchUser : Form
    {
        public frmSearchUser()
        {
            InitializeComponent();
            Program.arrForm.Add(this);
        }

        private void inputPanel1_EnabledChanged(object sender, EventArgs e)
        {
            if (inputPanel1.Enabled)
            {
                pnlForm.Height -= inputPanel1.Bounds.Height;
            }
            else
            {
                pnlForm.Height = this.Height;
            }
        }

        private void frmSearchUser_Load(object sender, EventArgs e)
        {
            ddlType.Items.Add("Name");
            ddlType.Items.Add("Phone");
            ddlType.Items.Add("Twitter");
            ddlType.SelectedIndex = 0;
            tbSearch.Focus();

            pnlMore.Visible = false;
            lblResults.Visible = false;
            pnlResults.Visible = false;

            lblResults.Location = new Point(3, btnMore.Location.Y + btnMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);
        }

        private void miBack_Click(object sender, EventArgs e)
        {
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void miSearch_Click(object sender, EventArgs e)
        {
            lblResults.Visible = true;
            pnlResults.Visible = true;
            pnlResults.Controls.Clear();
            LoadData();
        }

        private void LoadData()
        {
            string strCriteria = tbSearch.Text.Trim();
            if (!String.IsNullOrEmpty(strCriteria))
            {
                Cursor.Current = Cursors.WaitCursor;

                // build the API URL
                string phone = "";
                string name = "";
                string twitter = "";

                string strSearchType = ddlType.SelectedItem.ToString().ToLower();
                if (strSearchType.Equals("twitter"))
                {
                    twitter = System.Uri.EscapeDataString(strCriteria);
                }
                else if (strSearchType.Equals("phone"))
                {
                    phone = System.Uri.EscapeDataString(strCriteria);
                }
                else
                {
                    name = System.Uri.EscapeDataString(strCriteria);
                }
                DotNetSquare.NetSquare.FourSquareUsers xmlUsers = DotNetSquare.NetSquare.UserSearch(phone, "", twitter, "", "", name,Program.AccessToken);

                if (xmlUsers.count > 0)
                {
                    int y = 0;
                    pnlResults.Controls.Clear();
                    foreach (DotNetSquare.NetSquare.FourSquareUser xmlUser in xmlUsers.Users)
                    {
                        ucUserListItem oUser = new ucUserListItem(xmlUser);
                        oUser.Location = new Point(0, y);
                        oUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oUser.Width = pnlResults.Width;

                        pnlResults.Controls.Add(oUser);
                        pnlResults.Height = oUser.Location.Y + oUser.Height;

                        y = oUser.Location.Y + oUser.Height + 3;

                        Panel oLine = new Panel();
                        oLine.Location = new Point(0, y);
                        oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLine.Width = pnlResults.Width;
                        oLine.Height = 1;
                        oLine.BackColor = Color.Black;

                        pnlResults.Controls.Add(oLine);
                        pnlResults.Height = oLine.Location.Y + oLine.Height;

                        y = oLine.Location.Y + oLine.Height + 3;
                    }

                    if (xmlUsers.count == 1)
                    {
                        lblResults.Text = "1 result";
                    }
                    else
                    {
                        lblResults.Text = xmlUsers.count + " results";
                    }
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            btnMore.Visible = false;
            pnlMore.Visible = true;

            pnlMore.Location = new Point(3, btnMore.Location.Y);

            lblResults.Location = new Point(3, pnlMore.Location.Y + pnlMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            btnMore.Visible = true;
            pnlMore.Visible = false;

            lblResults.Location = new Point(3, btnMore.Location.Y + btnMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);
        }
    }
}