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
    public partial class ucCheckinListItem : UserControl
    {
        DotNetSquare.NetSquare.FourSquareCheckin _xmlCheckin;

        public ucCheckinListItem(DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin)
        {
            InitializeComponent();

            _xmlCheckin = xmlCheckin;

            DotNetSquare.NetSquare.FourSquareUser xmlUser = xmlCheckin.user;
            if (xmlUser != null)
            {
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

                string strPictureURL = xmlUser.photo;
                if (!String.IsNullOrEmpty(strPictureURL))
                {
                    pbUser.Image = Program.getImageFromURL(strPictureURL);
                }

                string strName = xmlUser.firstName + " ";
                strName += xmlUser.lastName;
                lblName.Text = strName.Trim();
            }

            if (xmlCheckin.venue != null)
            {
                lblVenue.Text = xmlCheckin.venue.name;
            }
            else
            {
                lblVenue.Text = "";
            }
            lblShout.Text = xmlCheckin.shout;

            //timestamp
            string strCreated = xmlCheckin.createdAt.ToString();
            lblTimestamp.Text = Program.convertAPITimeToCuteTime(strCreated);

            // distance
            string strDistance = "";
            
            if (xmlCheckin.venue != null)
            {
                strDistance = xmlCheckin.venue.location.Distance;
            }
            
            if ((!String.IsNullOrEmpty(strDistance)))
            {
                lblTimestamp.Text += " " + Program.convertDistanceToKM(strDistance) + " away";
            }
            
        }

        private void ucCheckinListItem_Click(object sender, EventArgs e)
        {
            OpenDetails();
        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            OpenDetails();
        }

        private void OpenDetails()
        {
            frmCheckinDetails oForm = new frmCheckinDetails(_xmlCheckin);
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
