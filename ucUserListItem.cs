using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace _4SquareLite
{
    public partial class ucUserListItem : UserControl
    {
        string _strFacebookID;
        string _strTwitterID;

        public ucUserListItem(DotNetSquare.NetSquare.FourSquareUser xmlUser)
        {
            InitializeComponent();

            lblUserID.Text = xmlUser.id;

            string strName = xmlUser.firstName + " ";
            strName += xmlUser.lastName;
            lblName.Text = strName.Trim();

            string strPictureURL = xmlUser.photo;
            if (!String.IsNullOrEmpty(strPictureURL))
            {
                pbUser.Image = Program.getImageFromURL(strPictureURL);
            }

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

            lblPhone.Text = xmlUser.contact.phone;
            lblEmail.Text = xmlUser.contact.email;
        }

        private void pbUser_Click(object sender, EventArgs e)
        {
            frmUserDetails oUserDetails = new frmUserDetails(lblUserID.Text);
            oUserDetails.Show();

            var oObject = this.Parent;
            while (!oObject.ToString().Contains("frm"))
            {
                oObject = oObject.Parent;
            }

            oObject.Hide();
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
