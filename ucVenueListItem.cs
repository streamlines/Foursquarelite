using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _4SquareLite
{
    public partial class ucVenueListItem : UserControl
    {
        string _strVenueID;
        string _strVenueName;
        string _strIconURL;
        string _strCategory;
        string _strLat;
        string _strLon;

        public ucVenueListItem(DotNetSquare.NetSquare.FourSquareVenue xmlVenue)
        {
            InitializeComponent();

            LoadData(xmlVenue, "");
        }

        public ucVenueListItem(DotNetSquare.NetSquare.FourSquareVenue xmlVenue, string strCreated)
        {
            InitializeComponent();

            LoadData(xmlVenue, strCreated);
        }

        private void LoadData(DotNetSquare.NetSquare.FourSquareVenue xmlVenue, string strCreated)
        {
            //id
            _strVenueID = xmlVenue.id;

            //name
            _strVenueName = xmlVenue.name;
            lblName.Text = _strVenueName;

            //herenow
            if (strCreated == "")
            {
                DotNetSquare.NetSquare.FourSquareHereNow sqHereNow = xmlVenue.hereNow;

                if (sqHereNow != null)
                {
                    int iHereNow = sqHereNow.count;
                    if (iHereNow == 0)
                    {
                        lblHereNow.Text = "";
                    }
                    else if (iHereNow == 1)
                    {
                        lblHereNow.Text = "1 user here now";
                    }
                    else
                    {
                        lblHereNow.Text = iHereNow + " users here now";
                    }
                }
                else
                {
                    lblHereNow.Text = "";
                }
            }
            else
            {
                lblHereNow.Text = strCreated;
                lblHereNow.TextAlign = ContentAlignment.TopRight;
            }


            //primarycategory
            List<DotNetSquare.NetSquare.FourSquareCategory> xmlCategories = xmlVenue.categories;
            lblCategory.Text = "";
            foreach (DotNetSquare.NetSquare.FourSquareCategory xmlCategory in xmlCategories)
            {
                if (xmlCategory.primary)
                {
                    //nodename
                    _strCategory = xmlCategory.name;
                    lblCategory.Text = _strCategory;

                    //iconurl
                    _strIconURL = xmlCategory.icon;
                    pbIcon.Image = Program.getImageFromURL(_strIconURL);

                }
            }
            lblAddress.Text = Program.buildAddress(xmlVenue.location);

            _strLat = xmlVenue.location.Lat;
            _strLon = xmlVenue.location.Long;

            //distance
            string strDistance = xmlVenue.location.Distance;
            if (!String.IsNullOrEmpty(strDistance))
            {
                strDistance = Program.convertDistanceToKM(strDistance);
                strDistance = lblHereNow.Text + " " + strDistance + " away";
                lblHereNow.Text = strDistance.Trim();
            }
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            frmCheckin oForm = new frmCheckin(_strVenueID, _strVenueName, _strIconURL, _strCategory, _strLat, _strLon);
            oForm.Show();

            var oObject = this.Parent;
            while (!oObject.ToString().Contains("frm"))
            {
                oObject = oObject.Parent;
            }

            oObject.Hide();
        }

        private void ucVenueListItem_Click(object sender, EventArgs e)
        {
            frmVenueDetails oForm = new frmVenueDetails(_strVenueID);
            oForm.Show();

            var oObject = this.Parent;
            while (!oObject.ToString().Contains("frm"))
            {
                oObject = oObject.Parent;
            }

            oObject.Hide();
        }
    }
}
