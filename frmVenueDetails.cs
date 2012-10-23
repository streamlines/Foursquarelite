using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace _4SquareLite
{
    public partial class frmVenueDetails : Form
    {
        string _strVenueID;
        string _strVenueName;
        string _strIconURL;
        string _strCategory;
        string _strTwitterID;
        string _strLat;
        string _strLon;


        DotNetSquare.NetSquare.FourSquareCheckins _xmlCheckins = new DotNetSquare.NetSquare.FourSquareCheckins();

        public frmVenueDetails(string strVenueID)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strVenueID = strVenueID;
        }

        private void frmVenueDetails_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DotNetSquare.NetSquare.FourSquareVenue xmlVenue = DotNetSquare.NetSquare.Venue(_strVenueID, Program.AccessToken);

            if (xmlVenue.id != "")
            {

                //name
                _strVenueName = xmlVenue.name;
                lblName.Text = _strVenueName;

                //primarycategory
                List<DotNetSquare.NetSquare.FourSquareCategory> xmlCategories = xmlVenue.categories;
                lblCategory.Text = "Uncategorized";
                foreach (DotNetSquare.NetSquare.FourSquareCategory xmlCategory in xmlCategories)
                {
                    if (xmlCategory.primary)
                    {
                        ////nodename
                        _strCategory = xmlCategory.name;
                        lblCategory.Text = _strCategory;

                        ////iconurl
                        _strIconURL = xmlCategory.icon;
                        pbIcon.Image = Program.getImageFromURL(_strIconURL);
                    }
                }

                //twitter
                if (xmlVenue.contact != null)
                { _strTwitterID = xmlVenue.contact.twitter; }

                if (String.IsNullOrEmpty(_strTwitterID))
                {
                    pbTwitter.Visible = false;
                }
                else
                {
                    pbTwitter.Visible = true;
                }

                //geolat, geolong
                _strLat = xmlVenue.location.Lat;
                _strLon = xmlVenue.location.Long;
                if ((!String.IsNullOrEmpty(_strLat)) && (!String.IsNullOrEmpty(_strLon)))
                {
                    pbMap.Image = Program.getImageFromURL(GoogleGeoCode.getGoogleMapURL(_strLat, _strLon, pbMap.Size, false));
                }

                // address
                lblAddress.Text = Program.buildAddress(xmlVenue.location);
                if (String.IsNullOrEmpty(lblAddress.Text))
                {
                    lblAddress.Visible = false;
                    lblAddress.Height = 0;
                }

                ///////////////////////////////////////////////////////
                // stats
                DotNetSquare.NetSquare.FourSquareStats xmlStats = xmlVenue.stats;
                if (xmlStats != null)
                {
                    ////checkins
                    int iCheckins = Convert.ToInt32(xmlStats.checkinsCount);
                    if (iCheckins == 1)
                    {
                        lblCheckins.Text = "1 checkin";
                    }
                    else
                    {
                        lblCheckins.Text = iCheckins + " checkins";
                    }
                }

                ////herenow - TO BE COMPLETED
                int iHereNow = xmlVenue.hereNow.count;
                if (iHereNow == 0)
                {
                    btnViewUsers.Enabled = false;
                }
                else
                {
                    //////////////////////////////////////////////////////////////////////
                    // checkins
                    foreach (DotNetSquare.NetSquare.FourSquareHereNowGroup xmlHereNow in xmlVenue.hereNow.groups)
                    {
                        foreach (DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin in xmlHereNow.items)
                        {
                            _xmlCheckins.count += 1;
                            _xmlCheckins.checkins.Add(xmlCheckin);
                        }
                    }
                }


                if (iHereNow == 1)
                {
                    btnViewUsers.Text = "See The 1 User Here Now";
                }
                else
                {
                    btnViewUsers.Text = "See The " + iHereNow + " Users Here Now";
                }

                ////beenhere
                //////me
                if (xmlVenue.beenHere > 0)
                {
                    lblCheckins.Text += ", including yours!";
                }

                ////mayor
                DotNetSquare.NetSquare.FourSquareUser xmlMayorUser = xmlVenue.mayor.User;
                if (xmlMayorUser != null)
                {
                    ucUserListItem oMayor = new ucUserListItem(xmlMayorUser);
                    oMayor.Location = new Point(0, lblMayor.Location.Y + lblMayor.Height + 3);
                    oMayor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oMayor.Width = pnlMayor.Width;

                    pnlMayor.Controls.Add(oMayor);
                    pnlMayor.Height = oMayor.Location.Y + oMayor.Height;
                }
                else
                {
                    pnlMayor.Height = 0;
                    pnlMayor.Visible = false;
                }

                //////count
                string strCount = xmlVenue.mayor.Checkins;
                if (!String.IsNullOrEmpty(strCount))
                {
                    int iCount = Convert.ToInt32(strCount);
                    if (iCount == 1)
                    {
                        lblMayor.Text = "Mayor (with 1 checkin)";
                    }
                    else
                    {
                        lblMayor.Text = "Mayor (with " + iCount + " checkins)";
                    }
                }
                else
                {
                    pnlMayor.Height = 0;
                    pnlMayor.Visible = false;
                }


                //////////////////////////////////////////////////////////////////////
                //tips
                Dictionary<string, List<DotNetSquare.NetSquare.FourSquareTip>> xmlTips = xmlVenue.tips;
                int yTip = lblTips.Location.Y + lblTips.Height + 3;
                if (xmlTips.Count == 0)
                {
                    pnlTips.Visible = false;
                    pnlTips.Height = 0;
                }
                else
                {
                    foreach (List<DotNetSquare.NetSquare.FourSquareTip> TipList in xmlTips.Values)
                    {
                        foreach (DotNetSquare.NetSquare.FourSquareTip xmlTip in TipList)
                        {
                            //tip
                            xmlTip.venue = xmlVenue;
                            ucTipListItem oTip = new ucTipListItem(xmlTip);
                            oTip.Location = new Point(0, yTip);
                            oTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            oTip.Width = pnlTips.Width;

                            pnlTips.Controls.Add(oTip);
                            pnlTips.Height = oTip.Location.Y + oTip.Height;

                            yTip = oTip.Location.Y + oTip.Height + 3;

                            Panel oLine = new Panel();
                            oLine.Location = new Point(0, yTip);
                            oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            oLine.Width = pnlTips.Width;
                            oLine.Height = 1;
                            oLine.BackColor = Color.Black;

                            pnlTips.Controls.Add(oLine);
                            pnlTips.Height = oLine.Location.Y + oLine.Height;

                            yTip += oLine.Height + 3;
                        }
                    }
                }

                //////////////////////////////////////////////////////////////////////
                //tags - TO BE CONFIRMED
                /*
                String[] xmlTags = xmlVenue.tags;
                int yTag = lblTags.Location.Y + lblTags.Height + 3;
                if (xmlTags.Count == 0)
                {
                    pnlTags.Visible = false;
                    pnlTags.Height = 0;
                }
                else
                {
                    foreach (XmlNode xmlTag in xmlTags)
                    {
                        ////tag
                        Label oLabel = new Label();
                        oLabel.Location = new Point(0, yTag);
                        oLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLabel.Width = pnlTags.Width;
                        oLabel.Height = 13;
                        oLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
                        oLabel.Text = xmlTag.InnerText;

                        pnlTags.Controls.Add(oLabel);
                        pnlTags.Height = oLabel.Location.Y + oLabel.Height;

                        yTag = oLabel.Location.Y + oLabel.Height + 3;
                    }
                }
                */
                //////////////////////////////////////////////////////////////////////
                //specials
                List<DotNetSquare.NetSquare.FourSquareSpecial> xmlSpecials = xmlVenue.specials;
                int ySpecial = lblSpecials.Location.Y + lblSpecials.Height + 3;
                if (xmlSpecials.Count == 0)
                {
                    pnlSpecials.Visible = false;
                    pnlSpecials.Height = 0;
                }
                else
                {
                    foreach (DotNetSquare.NetSquare.FourSquareSpecial xmlSpecial in xmlSpecials)
                    {
                        ////special
                        //////id
                        //////type
                        //////kind
                        //////message
                        //////venue
                        ucSpecialListItem oSpecial = new ucSpecialListItem(xmlSpecial);
                        oSpecial.Location = new Point(0, ySpecial);
                        oSpecial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oSpecial.Width = pnlSpecials.Width;

                        pnlSpecials.Controls.Add(oSpecial);
                        pnlSpecials.Height = oSpecial.Location.Y + oSpecial.Height;

                        ySpecial = oSpecial.Location.Y + oSpecial.Height + 3;

                        Panel oLine = new Panel();
                        oLine.Location = new Point(0, ySpecial);
                        oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oLine.Width = pnlSpecials.Width;
                        oLine.Height = 1;
                        oLine.BackColor = Color.Black;

                        pnlSpecials.Controls.Add(oLine);
                        pnlSpecials.Height = oLine.Location.Y + oLine.Height;

                        ySpecial += oLine.Height + 3;
                    }
                }

                ///////////////////////////////
                // arrange stuff
                int y = pbMap.Location.Y + pbMap.Height + 3;
                lblAddress.Location = new Point(3, y);

                y = lblAddress.Location.Y + lblAddress.Height + 3;
                btnViewUsers.Location = new Point(3, y);

                y = btnViewUsers.Location.Y + btnViewUsers.Height + 3;
                pnlMayor.Location = new Point(3, y);

                y = pnlMayor.Location.Y + pnlMayor.Height + 3;
                pnlTips.Location = new Point(3, y);

                y = pnlTips.Location.Y + pnlTips.Height + 3;
                pnlTags.Location = new Point(3, y);

                y = pnlTags.Location.Y + pnlTags.Height + 3;
                pnlSpecials.Location = new Point(3, y);
            }

            pnlForm.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void pbTwitter_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://m.twitter.com/" + _strTwitterID, null);
            Process.Start(sInfo);
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

        private void miNearbyTips_Click(object sender, EventArgs e)
        {
            frmTipList oForm = new frmTipList(_strLat, _strLon, _strVenueName);
            oForm.Show();
            this.Hide();
        }

        private void miNearbyVenues_Click(object sender, EventArgs e)
        {
            frmVenueList oForm = new frmVenueList(_strLat, _strLon, _strVenueName);
            oForm.Show();
            this.Hide();
        }

        private void miAddTip_Click(object sender, EventArgs e)
        {
            frmAddTip oForm = new frmAddTip(_strVenueID, _strVenueName, _strIconURL, _strCategory, _strLat, _strLon);
            oForm.Show();
            this.Hide();
        }

        private void miFlagClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Once a venue is approved closed, it will no longer show up in search results. Proceed?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Boolean Result = DotNetSquare.NetSquare.VenueFlag(_strVenueID, "closed", Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Venue flagged to close", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void miFlagMislocated_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Allows you to flag a venue that is not located correctly on the map. Proceed?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Boolean Result = DotNetSquare.NetSquare.VenueFlag(_strVenueID, "closed", Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Venue flagged as mislocated", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void miFlagDuplicate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Allows you to flag a venue that might be a duplicate. Proceed?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                Boolean Result = DotNetSquare.NetSquare.VenueFlag(_strVenueID, "closed", Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Venue flagged as a duplicate", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void miAddVenue_Click(object sender, EventArgs e)
        {
            frmVenueInput oForm = new frmVenueInput("add");
            oForm.Show();
            this.Hide();
        }

        private void miProposeEdit_Click(object sender, EventArgs e)
        {
            frmVenueInput oForm = new frmVenueInput(_strVenueID);
            oForm.Show();
            this.Hide();
        }

        private void miCheckin_Click(object sender, EventArgs e)
        {
            frmCheckin oForm = new frmCheckin(_strVenueID, _strVenueName, _strIconURL, _strCategory, _strLat, _strLon);
            oForm.Show();
            this.Hide();
        }

        private void pbMap_Click(object sender, EventArgs e)
        {
            frmVenueFullMap oForm = new frmVenueFullMap(_strLat, _strLon);
            oForm.Show();
            this.Hide();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            frmCheckinList oForm = new frmCheckinList("Users Checked In @ " + _strVenueName, _xmlCheckins, _strVenueID);
            oForm.Show();
            this.Hide();
        }
    }
}