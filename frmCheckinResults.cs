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
    public partial class frmCheckinResults : Form
    {
        DotNetSquare.NetSquare.FourSquareCheckin _strXML;

        public frmCheckinResults(DotNetSquare.NetSquare.FourSquareCheckin strXML)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strXML = strXML;
        }

        private void frmCheckinResults_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin = _strXML;

            //timestamp
            string strCreated = xmlCheckin.createdAt.ToString();
            if (!String.IsNullOrEmpty(strCreated))
            {
                lblTimestamp.Text = Program.convertAPITimeToLocalTime(strCreated);
            }

            int NoteMessage = 0;
            int NoteMayorship = 0;
            int NoteBadge = 0;
            int NoteLeaderboard = 0;
            int NoteScore = 0;

            for (int i=0; i < xmlCheckin.Notifications.Count; i++)
            {
                switch (xmlCheckin.Notifications[i].Type)
                {
                    case("message"):
                        NoteMessage = i;
                        break;
                    case ("mayorship"):
                        NoteMayorship = i;
                        break;
                    case ("badge"):
                        NoteBadge = i;
                        break;
                    case ("leaderboard"):
                        NoteLeaderboard = i;
                        break;
                    case ("score"):
                        NoteScore = i;
                        break;
                }
            }
            
            // message
            lblMessage.Text = xmlCheckin.Notifications[NoteMessage].Message;
            lblMessage.Size = CFMeasureString.MeasureString(lblMessage, lblMessage.Text, lblMessage.ClientRectangle);

            ///////////////////////////////////////////////////////////////////////////
            // venue (may not exist)
            DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlCheckin.venue;
            if (xmlVenue != null)
            {
                foreach (DotNetSquare.NetSquare.FourSquareCategory xmlCategory in xmlVenue.categories)
                {
                    if (xmlCategory.primary)
                    {
                        string strURL = xmlCategory.icon;
                        pbIcon.Image = Program.getImageFromURL(strURL);
                    }
                }

                lblVenueName.Text = xmlVenue.name;

                string strLabel = "";
                string strItem = "";

                //address
                strItem = xmlVenue.location.Address;
                if (!String.IsNullOrEmpty(strItem))
                {
                    strLabel += strItem + " ";
                }

                //crossstreet
                strItem = xmlVenue.location.CrossStreet;
                if (!String.IsNullOrEmpty(strItem))
                {
                    strLabel += strItem + " ";
                }

                //city
                strItem = xmlVenue.location.City;
                if (!String.IsNullOrEmpty(strItem))
                {
                    strLabel += strItem + " ";
                }

                //state
                strItem = xmlVenue.location.State;
                if (!String.IsNullOrEmpty(strItem))
                {
                    strLabel += strItem + " ";
                }

                //zip
                strItem = xmlVenue.location.PostalCode;
                if (!String.IsNullOrEmpty(strItem))
                {
                    strLabel += strItem + " ";
                }

                lblAddress.Text = strLabel.Trim();
                pnlVenue.Location = new Point(3,lblMessage.Location.Y + lblMessage.Size.Height + 3);
                pnlVenue.Visible = true;
            }
            else
            {
                pnlVenue.Visible = false;
                pnlVenue.Height = 0;
            }

            int y = pnlVenue.Location.Y + pnlVenue.Height + 3;

            ///////////////////////////////////////////////////////////////////////////
            // mayor (may not exist)
            DotNetSquare.NetSquare.FourSquareMayorship xmlMayor = xmlCheckin.Notifications[NoteMayorship].Mayor;
            if (xmlMayor != null)
            {
                string strMayorType = xmlMayor.Type;
                switch (strMayorType)
                {
                    //node <type> which has the following values: 
                    //new (the user has been appointed mayorship), 
                    //nochange (the previous mayorship is still valid), 
                    //stolen (the user stole mayorship from the previous mayor)
                    case "new":
                        lblMayorType.Text = "You're the new Mayor!";
                        break;

                    case "stolen":
                        lblMayorType.Text = "You've overthrown the old Mayor!";
                        break;

                    case "nochange":
                        lblMayorType.Text = "Long live the Mayor!";
                        break;

                    default:
                        lblMayorType.Text = "";
                        break;
                }

                int iCheckins = 0;
                if (xmlMayor.Checkins != "") {
                    Convert.ToInt16(xmlMayor.Checkins.ToString());
                };
                if (iCheckins == 1)
                {
                    lblMayorCheckins.Text = iCheckins + " check-in here";
                }
                else
                {
                    lblMayorCheckins.Text = iCheckins + " check-ins here";
                }

                DotNetSquare.NetSquare.FourSquareUser xmlUser;

                if (xmlMayor.Message.StartsWith("You're still the Mayor"))
                {
                    xmlUser = Program.SelfUser;
                }
                else
                {
                    xmlUser = xmlMayor.User;
                }
                if (!(xmlUser == null))
                {
                    string strName = xmlUser.firstName + " " + xmlUser.lastName;
                    lblUserName.Text = strName.Trim();

                    string strGender = xmlUser.gender;
                    switch (strGender)
                    {
                        case "female":
                            pnlGender.BackColor = Color.PaleVioletRed;
                            break;

                        case "male":
                            pnlGender.BackColor = Color.SteelBlue;
                            break;

                        default:
                            pnlGender.BackColor = Color.Black;
                            break;
                    }

                    string strURL = xmlMayor.ImageURL;
                    pbUser.Image = Program.getImageFromURL(strURL);
                }
                else
                {
                    // collapse
                    pnlGender.Visible = false;
                    lblUserName.Visible = false;

                    lblMayorCheckins.Location = pnlGender.Location;
                    lblMayorCheckins.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    lblMayorCheckins.Width = pnlMayor.Width;

                    lblMayorType.Location = new Point(lblMayorCheckins.Location.X, lblMayorCheckins.Location.Y + lblMayorCheckins.Height);
                    lblMayorType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    lblMayorType.Width = pnlMayor.Width;

                    lblMayorMessage.Location = new Point(lblMayorType.Location.X, lblMayorType.Location.Y + lblMayorType.Height);
                    lblMayorMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    lblMayorMessage.Width = pnlMayor.Width;

                    pnlMayor.Height = lblMayorMessage.Location.Y + lblMayorMessage.Height;
                }


                string strMessage = xmlMayor.Message;
                lblMayorMessage.Text = strMessage;
                if (xmlMayor.DaysBehind != "")
                {
                    lblMayorMessage.Text += " - You are " + xmlMayor.DaysBehind + " days away from becoming the Mayor";
                }
                lblMayorMessage.Size = CFMeasureString.MeasureString(lblMayorMessage, lblMayorMessage.Text, lblMayorMessage.ClientRectangle);

                int Size = lblUserName.Height;
                Size += lblMayorCheckins.Height;
                Size += lblMayorType.Height;
                Size += lblMayorMessage.Height;

                if (Size > pbUser.Height)
                {
                    pnlMayor.Height = Size + 4;
                }
            }
            else
            {
                pnlMayor.Visible = false;
                pnlMayor.Height = 0;
            }

            pnlMayor.Location = new Point(3, y);
            y = pnlMayor.Location.Y + pnlMayor.Height + 3;
                
            ///////////////////////////////////////////////////////////////////////
            //badges (may not exist)
            int yBadge = lblBadges.Height + 3;
            if (NoteBadge != 0)
            {
                List<DotNetSquare.NetSquare.FourSquareBadge> xmlBadges = xmlCheckin.Notifications[NoteBadge].Badges;

                if (xmlBadges != null)
                {
                    foreach (DotNetSquare.NetSquare.FourSquareBadge xmlBadge in xmlBadges)
                    {
                        ucBadgeListItem oBadge = new ucBadgeListItem(xmlBadge);
                        oBadge.Location = new Point(0, yBadge);
                        oBadge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oBadge.Width = pnlBadges.Width - 3 * 2;

                        yBadge += oBadge.Height + 3;
                        pnlBadges.Controls.Add(oBadge);
                        pnlBadges.Height = oBadge.Location.Y + oBadge.Height;
                    }
                }
                if (xmlBadges.Count == 0)
                {
                    pnlBadges.Visible = false;
                    pnlBadges.Height = 0;
                }
            }
            else
            {
                pnlBadges.Visible = false;
                pnlBadges.Height = 0;
            }

            pnlBadges.Location = new Point(3, y);
            y = pnlBadges.Location.Y + pnlBadges.Height + 3;
            ////////////////////////////////////////////////////////////////////////
            //scores (may not exist)
            int yScore = lblScores.Height + 3;
            int TotalScore = 0;
            if (NoteScore != 0)
            {
                List<DotNetSquare.NetSquare.FourSquareCheckinScore> xmlScores = xmlCheckin.Notifications[NoteScore].Scores;
                if (xmlScores != null)
                {
                    foreach (DotNetSquare.NetSquare.FourSquareCheckinScore xmlScore in xmlScores)
                    {
                        ucScoreListItem oScore = new ucScoreListItem(xmlScore);
                        oScore.Location = new Point(0, yScore);
                        oScore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oScore.Width = pnlScores.Width - 3 * 2;

                        yScore += oScore.Height + 3;
                        pnlScores.Controls.Add(oScore);
                        pnlScores.Height = oScore.Location.Y + oScore.Height;

                        TotalScore += xmlScore.Points;
                    }
                }
            }

            if (TotalScore > 0)
            {
                Dictionary<string,object> Totaldic = new Dictionary<string,object>();
                Totaldic.Add("points",TotalScore);
                Totaldic.Add("message" , "Total Points for this Checkin!");
                Totaldic.Add("icon","https://foursquare.com/img/points/discovery.png");

                DotNetSquare.NetSquare.FourSquareCheckinScore Total = new DotNetSquare.NetSquare.FourSquareCheckinScore(Totaldic);
                
                ucScoreListItem oScore = new ucScoreListItem(Total);
                oScore.Location = new Point(0, yScore);
                oScore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oScore.Width = pnlScores.Width - 3 * 2;

                yScore += oScore.Height + 3;
                pnlScores.Controls.Add(oScore);
                pnlScores.Height = oScore.Location.Y + oScore.Height;
            }

            if (TotalScore == 0)
            {
                pnlScores.Visible = false;
                pnlScores.Height = 0;
            }

            pnlScores.Location = new Point(3, y);
            y = pnlScores.Location.Y + pnlScores.Height + 3;

            //////////////////////////////////////////////////////////////////////////
            //specials (may not exist)
            /*
            int ySpecial = lblSpecials.Height + 3;
            String ll = xmlVenue.location.Lat + "," + xmlVenue.location.Long;
            DotNetSquare.NetSquare.FourSquareSpecials xmlSpecials = DotNetSquare.NetSquare.SpecialSearch(ll,20,Program.AccessToken);
            for (int i = 0; i < 
                DotNetSquare.Special xmlSpecial in xmlSpecials)
            {
                DotNetSquare.Venue xmlThisVenue = xmlSpecial.venue;
                if (!(xmlThisVenue.Equals(new DotNetSquare.Venue())))
                {
                    ucVenueListItem oVenue = new ucVenueListItem(xmlThisVenue);
                    oVenue.Location = new Point(0, ySpecial);
                    oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oVenue.Width = pnlSpecials.Width;

                    ySpecial += oVenue.Height;
                    pnlSpecials.Controls.Add(oVenue);
                }

                ucSpecialListItem oSpecial = new ucSpecialListItem(xmlSpecial);
                oSpecial.Location = new Point(0, ySpecial);
                oSpecial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oSpecial.Width = pnlSpecials.Width;

                ySpecial += oSpecial.Height + 3;
                pnlSpecials.Controls.Add(oSpecial);
                pnlSpecials.Height = oSpecial.Location.Y + oSpecial.Height;

                ySpecial += 3;
            }

            if (xmlSpecials.Count == 0)
            {*/
                pnlSpecials.Visible = false;
                pnlSpecials.Height = 0;
            /*}

            pnlSpecials.Location = new Point(3, y);
            y = pnlSpecials.Location.Y + pnlSpecials.Height;
            */
            Cursor.Current = Cursors.Default;
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

        private void miBack_Click(object sender, EventArgs e)
        {
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void pbUser_Click(object sender, EventArgs e)
        {

        }
    }
}