using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace _4SquareLite
{
    public partial class frmUserDetails : Form
    {
        string _strUserID;
        string _strName;
        string _strFacebookID;
        string _strTwitterID;

        public frmUserDetails(string strUserID)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strUserID = strUserID;
        }

        void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool bIsSelf = false;

            DotNetSquare.NetSquare.FourSquareUser xmlUser = DotNetSquare.NetSquare.User(_strUserID,Program.AccessToken);

            if (xmlUser != null)
            {
                //////////////////////////////////
                // user

                //name
                _strName = xmlUser.firstName + " ";
                _strName += xmlUser.lastName;
                _strName = _strName.Trim();
                lblName.Text = _strName;

                //gender
                string strGender = xmlUser.gender;
                Color colorGender = Color.Black;
                switch (strGender)
                {
                    case "female":
                        colorGender = Color.PaleVioletRed;
                        break;

                    case "male":
                        colorGender = Color.SteelBlue;
                        break;
                }
                pnlGender.BackColor = colorGender;

                //photo
                string strPictureURL = xmlUser.photo;
                if (!String.IsNullOrEmpty(strPictureURL))
                {
                    pbUser.Image = Program.getImageFromURL(strPictureURL);
                }

                lblEmail.Text = xmlUser.contact.email;

                lblPhone.Text = xmlUser.contact.phone;

                _strFacebookID = xmlUser.contact.facebook;
                if (String.IsNullOrEmpty(_strFacebookID))
                {
                    pbFacebook.Visible = false;
                }

                _strTwitterID = xmlUser.contact.twitter;
                if (String.IsNullOrEmpty(_strTwitterID))
                {
                    pbTwitter.Visible = false;
                }

                ///////////////////////////////////////////////////////////////////////
                //settings block
                
                if (xmlUser.relationship == "self")
                {
                    bIsSelf = true;
                }

                ////////////////////////////////////////////////////////////////////////
                //friendstatus
                string strFriendStatus = xmlUser.relationship;
                switch (strFriendStatus)
                {
                    case "friend":
                        //the requested user is your friend

                        pnlAcceptReject.Visible = false;
                        btnSendRequest.Visible = false;
                        break;

                    case "pendingMe":
                        //the requested user sent you a friend request that you have not accepted

                        pnlAcceptReject.Visible = true;
                        btnSendRequest.Visible = false;
                        break;

                    case "pendingthem":
                        //you have sent a friend request to the requested user but they have not accepted

                        pnlAcceptReject.Visible = false;
                        btnSendRequest.Visible = true;
                        btnSendRequest.Enabled = false;
                        btnSendRequest.Text = "Friend Request Sent!";
                        break;

                    default:
                        //node absent - the requested user is not your friend (and neither party has made an attempt at connecting)

                        pnlAcceptReject.Visible = false;
                        btnSendRequest.Visible = true;
                        break;
                }

                ///////////////////////////////////////////////////////////////////////
                //badges
               DotNetSquare.NetSquare.FourSquareBadgesAndSets xmlBadges = DotNetSquare.NetSquare.UserBadges(xmlUser.id,Program.AccessToken);
                if (xmlBadges.Badges.Count > 0)
                {
                    int y = lblBadge.Location.Y + lblBadge.Height + 3;
                    if (xmlBadges.Badges.Count == 1)
                    {
                        lblBadge.Text = "1 Badge";
                    }
                    else
                    {
                        lblBadge.Text = xmlBadges.Badges.Count + " Badges";
                    }

                    foreach (DotNetSquare.NetSquare.FourSquareBadge xmlBadge in xmlBadges.Badges)
                    {
                        //badge
                        ucBadgeListItem oBadge = new ucBadgeListItem(xmlBadge);
                        oBadge.Location = new Point(0, y);
                        oBadge.Width = pnlBadge.Width;

                        pnlBadge.Controls.Add(oBadge);
                        pnlBadge.Height = oBadge.Location.Y + oBadge.Height;

                        y = oBadge.Location.Y + oBadge.Height + 3;

                        Panel oLine = new Panel();
                        oLine.Location = new Point(0, y);
                        oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLine.Width = pnlBadge.Width;
                        oLine.Height = 1;
                        oLine.BackColor = Color.Black;

                        pnlBadge.Controls.Add(oLine);
                        pnlBadge.Height = oLine.Location.Y + oLine.Height;

                        y += oLine.Height + 3;
                    }
                }
                else
                {
                    pnlBadge.Visible = false;
                    pnlBadge.Height = 0;
                }

                ////////////////////////////////////////////////////////////////////
                //mayor
                List<DotNetSquare.NetSquare.FourSquareVenue> xmlVenues = xmlUser.mayorshipItems;
                if (xmlVenues.Count > 0)
                {
                    int y = lblMayor.Location.Y + lblMayor.Height + 3;
                    if (xmlVenues.Count == 1)
                    {
                        lblMayor.Text = "1 Mayorship";
                    }
                    else
                    {
                        lblMayor.Text = xmlVenues.Count + " Mayorships";
                    }

                    foreach (DotNetSquare.NetSquare.FourSquareVenue xmlVenue in xmlVenues)
                    {
                        //venue
                        ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                        oVenue.Location = new Point(0, y);
                        oVenue.Width = pnlMayor.Width;

                        pnlMayor.Controls.Add(oVenue);
                        pnlMayor.Height = oVenue.Location.Y + oVenue.Height + 3;

                        y = oVenue.Location.Y + oVenue.Height + 3;

                        Panel oLine = new Panel();
                        oLine.Location = new Point(0, y);
                        oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLine.Width = pnlMayor.Width;
                        oLine.Height = 1;
                        oLine.BackColor = Color.Black;

                        pnlMayor.Controls.Add(oLine);
                        pnlMayor.Height = oLine.Location.Y + oLine.Height;

                        y += oLine.Height + 3;
                    }
                }
                else
                {
                    pnlMayor.Visible = false;
                    pnlMayor.Height = 0;
                }

                ////////////////////////////////////////////////////////
                //recalculate positions
                int iFormY = pnlGender.Location.Y + pnlGender.Height + 3;
                btnViewFriends.Location = new Point(3, iFormY);

                iFormY = btnViewFriends.Location.Y + btnViewFriends.Height + 3;
                pnlBadge.Location = new Point(3, iFormY);

                iFormY = pnlBadge.Location.Y + pnlBadge.Height + 3;
                pnlMayor.Location = new Point(3, iFormY);

                iFormY = pnlMayor.Location.Y + pnlMayor.Height + 3;
                pnlAcceptReject.Location = new Point(3, iFormY);

                iFormY = pnlAcceptReject.Location.Y + pnlAcceptReject.Height + 3;
                btnSendRequest.Location = new Point(3, iFormY);

                if (pnlAcceptReject.Visible == false)
                {
                    btnSendRequest.Location = pnlAcceptReject.Location;
                }

                if (bIsSelf)
                {
                    btnSendRequest.Visible = false;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void miRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnViewFriends_Click(object sender, EventArgs e)
        {
            frmUserList oForm = new frmUserList(_strName + "'s Friends", "friends", _strUserID);
            oForm.Show();
            this.Hide();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DotNetSquare.NetSquare.FourSquareUser xmlUser = DotNetSquare.NetSquare.UserDeny(_strUserID,Program.AccessToken);
            Cursor.Current = Cursors.Default;

            if (!(xmlUser.Equals(null)))
            {
                // read the xml
                string strName = (xmlUser.firstName + " " + xmlUser.lastName).Trim();

                MessageBox.Show("OK! You have rejected " + strName + "'s friend request", Program.strProgramName,
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

            LoadData();
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DotNetSquare.NetSquare.FourSquareUser xmlUser = DotNetSquare.NetSquare.UserRequest(_strUserID,Program.AccessToken);
            Cursor.Current = Cursors.Default;

            if (!(xmlUser.Equals(null)))
            {
                // read the xml
                string strName = (xmlUser.firstName + " " + xmlUser.lastName).Trim();

                MessageBox.Show("OK! You've sent a friend request to " + strName + "!", Program.strProgramName,
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DotNetSquare.NetSquare.FourSquareUser xmlUser = DotNetSquare.NetSquare.UserApprove(_strUserID, Program.AccessToken);
            Cursor.Current = Cursors.Default;

            if (!(xmlUser.Equals(null)))
            {
                // read the xml
                string strName = (xmlUser.firstName + " " + xmlUser.lastName).Trim();

                MessageBox.Show("OK! You have accepted " + strName + "'s friend request", Program.strProgramName,
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

            LoadData();
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

        private void pbFacebook_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://m.facebook.com/profile.php?id=" + _strFacebookID, null);
            Process.Start(sInfo);
        }

        private void pbTwitter_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://m.twitter.com/" + _strTwitterID, null);
            Process.Start(sInfo);
        }
    }
}