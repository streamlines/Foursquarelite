using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4SquareLite
{
    public partial class frmCheckin : Form
    {
        string _strVenueID;
        string _strVenueName;
        string _strIconURL;
        string _strCategory;
        string _strLat;
        string _strLon;

        public frmCheckin(string strVenueID, 
            string strVenueName,
            string strIconURL,
            string strCategory, 
            string strLat, 
            string strLon)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strVenueID = strVenueID;
            _strVenueName = strVenueName;
            _strIconURL = strIconURL;
            _strCategory = strCategory;
            _strLat = strLat;
            _strLon = strLon;

            Cursor.Current = Cursors.WaitCursor;

            lblVenue.Text = _strVenueName;
            
            if (!String.IsNullOrEmpty(_strIconURL))
            {
                pbIcon.Image = Program.getImageFromURL(_strIconURL);
            }

            if (!String.IsNullOrEmpty(_strCategory))
            {
                lblCategory.Text = _strCategory;
            }

            Cursor.Current = Cursors.Default;
        }

        public frmCheckin()
        {
            InitializeComponent();
            Program.arrForm.Add(this);

            pnlVenue.Visible = false;
            pnlCheckin.Location = pnlVenue.Location;
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

        private void frmCheckin_Load(object sender, EventArgs e)
        {
            /*
            vid - (optional, not necessary if you are 'shouting' or have a venue name). ID of the venue where you want to check-in
            venue - (optional, not necessary if you are 'shouting' or have a vid) if you don't have a venue ID or would rather prefer a 'venueless' checkin, pass the venue name as a string using this parameter. it will become an 'orphan' (no address or venueid but with geolat, geolong)
            shout - (optional) a message about your check-in. the maximum length of this field is 140 characters
            private - (optional). "1" means "don't show your friends". "0" means "show everyone"
            twitter - (optional, defaults to the user's setting). "1" means "send to Twitter". "0" means "don't send to Twitter"
            facebook - (optional, defaults to the user's setting). "1" means "send to Facebook". "0" means "don't send to Facebook"
            geolat - (optional, but recommended)
            geolong - (optional, but recommended)
            */

            tbShout.Text = "";
            lblShoutCounter.Text = "(0 / 140)";

            chkPublic.Checked = true;

            if (Program.bSendToTwitter)
            {
                chkTwitter.Checked = true;
            }
            else
            {
                chkTwitter.Checked = false;
            }

            if (Program.bSendToFacebook)
            {
                chkFacebook.Checked = true;
            }
            else
            {
                chkFacebook.Checked = false;
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

        private void miCheckin_Click(object sender, EventArgs e)
        {
            string strShout = tbShout.Text.Trim();

            if ((!String.IsNullOrEmpty(strShout)) || (!String.IsNullOrEmpty(_strVenueID)))
            {
                /*
                vid - (optional, not necessary if you are 'shouting' or have a venue name). ID of the venue where you want to check-in
                venue - (optional, not necessary if you are 'shouting' or have a vid) if you don't have a venue ID or would rather prefer a 'venueless' checkin, pass the venue name as a string using this parameter. it will become an 'orphan' (no address or venueid but with geolat, geolong)
                shout - (optional) a message about your check-in. the maximum length of this field is 140 characters
                private - (optional). "1" means "don't show your friends". "0" means "show everyone"
                twitter - (optional, defaults to the user's setting). "1" means "send to Twitter". "0" means "don't send to Twitter"
                facebook - (optional, defaults to the user's setting). "1" means "send to Facebook". "0" means "don't send to Facebook"
                geolat - (optional, but recommended)
                geolong - (optional, but recommended)
                */

                string strParameters = "";

                switch(chkPublic.Checked) 
                {
                    case true:
                        strParameters += "public";
                        break;
                    case false:
                        strParameters += "private";
                        break;
                }
                switch (chkTwitter.Checked)
                {
                    case true:
                        strParameters += ",twitter";
                        Program.bSendToTwitter = true;
                        break;
                    case false:
                        Program.bSendToTwitter = false;
                        break;
                    default:
                        break;
                }
                switch (chkFacebook.Checked)
                {
                    case true:
                        strParameters +=",facebook";
                        Program.bSendToFacebook = true;
                        break;
                    case false:
                        Program.bSendToFacebook = false;
                        break;
                    default:
                        break;
                }
                String strLL = "";
                if ((!String.IsNullOrEmpty(_strLat)) && (!String.IsNullOrEmpty(_strLon)))
                {
                    strLL = _strLat + "," + _strLon;
                }

                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin = null ;
                try
                {
                    xmlCheckin = DotNetSquare.NetSquare.CheckinAdd(_strVenueID, "", strShout, strParameters, strLL, "", "", "", Program.AccessToken);
                }
                catch
                {
                    //Ignore checkin by keeping xmlCheckin as Null;
                }
                Cursor.Current = Cursors.Default;

                if (xmlCheckin != null)
                {
                    if ((!String.IsNullOrEmpty(_strLat)) && (!String.IsNullOrEmpty(_strLon)))
                    {
                        Program.strGlobalLat = _strLat;
                        Program.strGlobalLon = _strLon;
                    }

                    frmCheckinResults oForm = new frmCheckinResults(xmlCheckin);
                    oForm.Show();

                    //close this form
                    int i = Program.arrForm.Count;
                    i--;
                    Program.arrForm.RemoveAt(i);
                    this.Close();
                }
            }
        }

        private void tbShout_KeyUp(object sender, KeyEventArgs e)
        {
            int iNoOfChars = tbShout.Text.Length;
            lblShoutCounter.Text = "(" + iNoOfChars + " / 140)";
        }
    }
}