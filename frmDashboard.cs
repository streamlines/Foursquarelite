using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;

namespace _4SquareLite
{
    public partial class frmDashboard : Form
    {
        DotNetSquare.NetSquare.FourSquareUser _strLoggedInUserDetailXML;
        string _strUserID;

        public frmDashboard(DotNetSquare.NetSquare.FourSquareUser StrToken)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strLoggedInUserDetailXML = StrToken;
        }

        public frmDashboard()
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

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            DotNetSquare.NetSquare.FourSquareUser SelfUser = null;
            Cursor.Current = Cursors.WaitCursor;
            if (_strLoggedInUserDetailXML.Equals(SelfUser))
            {
                SelfUser = DotNetSquare.NetSquare.User(Program.AccessToken);
            }
            else
            {
                SelfUser = _strLoggedInUserDetailXML;
            }

            // userid
            _strUserID = "self" ;

            // get the no of pending friend requests            

                if (Convert.ToInt16(SelfUser.requests) == 0)
                {
                    btnPending.Enabled = false;
                }
                else if (Convert.ToInt16(SelfUser.requests) == 1)
                {
                    btnPending.Text = "1 Pending Request";
                }
                else
                {
                    btnPending.Text = SelfUser.requests + " Pending Requests";
                }

            // lblName
            string strName = SelfUser.firstName  + " " + SelfUser.lastName;
            lblName.Text = strName.Trim();

            //gender
            string strGender = SelfUser.gender;
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

            // pbUser
            string strURL = SelfUser.photo;
            pbUser.Image = Program.getImageFromURL(strURL);
            
            //////////////////////////////////////////////////////////////////////////////
            // Get Venue History Last 7 Days
            long SevenDays = Program.ToUnixTime(Program.SevenDaysAgo());
            DotNetSquare.NetSquare.FourSquareCheckins ListCheckins = DotNetSquare.NetSquare.UserCheckins("self",50,0,SevenDays,0,Program.AccessToken);

            if (ListCheckins.count != 0)
            {
                Program.strGlobalLat = "";
                Program.strGlobalLon = "";
                pnlHistory.Controls.Clear();
                int iHistoryY = 0;
                for (int i = 0; i < ListCheckins.checkins.Count; i++) 
                {
                    DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin = ListCheckins.checkins[i];
                    string strCreated = Program.convertAPITimeToCuteTime(xmlCheckin.createdAt.ToString());
                    DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlCheckin.venue;
                    if (xmlVenue != null)
                    {
                        if ((String.IsNullOrEmpty(Program.strGlobalLat)) || (String.IsNullOrEmpty(Program.strGlobalLon)))
                        {
                            Program.strGlobalLat = xmlVenue.location.Lat;
                            Program.strGlobalLon = xmlVenue.location.Long;
                        }

                        ucVenueListItem oVenue = new ucVenueListItem(xmlVenue, strCreated);
                        oVenue.Location = new Point(0, iHistoryY);
                        oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oVenue.Width = pnlHistory.Width;

                        pnlHistory.Controls.Add(oVenue);
                        pnlHistory.Height = oVenue.Location.Y + oVenue.Height;

                        iHistoryY += oVenue.Height + 3;

                        Panel oLine = new Panel();
                        oLine.Location = new Point(0, iHistoryY);
                        oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLine.Width = pnlHistory.Width;
                        oLine.Height = 1;
                        oLine.BackColor = Color.Black;

                        pnlHistory.Controls.Add(oLine);
                        pnlHistory.Height = oLine.Location.Y + oLine.Height;

                        iHistoryY += oLine.Height + 3;
                    }
                }
             }
                
            Cursor.Current = Cursors.Default;
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            frmUserList oForm = new frmUserList("Pending Friend Requests", "friendrequest");
            oForm.Show();
            this.Hide();
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            frmSearchVenue oForm = new frmSearchVenue();
            oForm.Show();
            this.Hide();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _strLoggedInUserDetailXML = DotNetSquare.NetSquare.User(Program.AccessToken);
            Cursor.Current = Cursors.Default;

            if (!(_strLoggedInUserDetailXML.Equals(null)))
            {
                frmDashboard_Load(sender, e);
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            LocalSettings.Save("GlobalLat", Program.strGlobalLat);
            LocalSettings.Save("GlobalLong", Program.strGlobalLon);
            LocalSettings.Save("Facebook", Program.bSendToFacebook);
            LocalSettings.Save("Twitter", Program.bSendToTwitter);

            Application.Exit();
        }

        private void miSearchUsers_Click(object sender, EventArgs e)
        {
            frmSearchUser oForm = new frmSearchUser();
            oForm.Show();
            this.Hide();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            // LocalSettings.Save("Authentication", "");

            int i = Program.arrForm.Count;
            if (i > 2) // if this is the 2nd form (eg: the 1st form is login)
            {
                i--;
                Program.arrForm.RemoveAt(i);
                i--;
                ((Form)Program.arrForm[i]).Show();
                this.Close();
            }
            else
            {
                frmLogin oForm = new frmLogin();
                oForm.Show();
                this.Hide();
            }
        }

        private void miCheckins_Click(object sender, EventArgs e)
        {
            frmCheckinList oForm = new frmCheckinList(Program.strGlobalLat, Program.strGlobalLon, "Friends' Check-Ins");
            oForm.Show();
            this.Hide();
        }

        private void miSearchVenues_Click(object sender, EventArgs e)
        {
            frmSearchVenue oForm = new frmSearchVenue();
            oForm.Show();
            this.Hide();
        }

        private void btnShout_Click(object sender, EventArgs e)
        {
            frmCheckin oForm = new frmCheckin();
            oForm.Show();
            this.Hide();
        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            frmUserDetails oForm = new frmUserDetails(_strUserID);
            oForm.Show();
            this.Hide();
        }

        private void btnGPS_Click(object sender, EventArgs e)
        {
            frmGPS oForm = new frmGPS();
            oForm.Show();
            this.Hide();
        }


        private void miTodos_Click(object sender, EventArgs e)
        {
            frmTodoList oForm = new frmTodoList(Program.strGlobalLat, Program.strGlobalLon, "");
            oForm.Show();
            this.Hide();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            // This provides a About Window
            MessageBox.Show("This is " + Program.strProgramName + " " + Program.strProgramVersion, "About", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void miLeaderboard_Click(object sender, EventArgs e)
        {
            frmLeaderboardList oForm = new frmLeaderboardList("Current Leaderboard");
            oForm.Show();
            this.Hide();

        }


    }
}