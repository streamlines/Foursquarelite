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
    public partial class ucTipListItem : UserControl
    {
        DotNetSquare.NetSquare.FourSquareTip _xmlTip;

        string _strTipID;
        string _strTip;
        string _strUserID;

        public ucTipListItem(DotNetSquare.NetSquare.FourSquareTip xmlTip)
        {
            InitializeComponent();

            _xmlTip = xmlTip;

            _strTipID = xmlTip.id;

            _strTip = xmlTip.text;
            lblText.Text = _strTip;

            //timestamp
            string strCreated = xmlTip.createdAt;
            lblTimestamp.Text = Program.convertAPITimeToCuteTime(strCreated);

            //distance
            string strDistance = xmlTip.venue.location.Distance;
            if (!String.IsNullOrEmpty(strDistance))
            {
                lblTimestamp.Text += " " + Program.convertDistanceToKM(strDistance) + " away";
            }

            DotNetSquare.NetSquare.FourSquareUser xmlUser = xmlTip.user;
            if (xmlUser != null)
            {
                _strUserID = xmlUser.id;

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

        }

        private void pbUser_Click(object sender, EventArgs e)
        {

        }

        private void ucTipListItem_Click(object sender, EventArgs e)
        {
            frmTipDetails oForm = new frmTipDetails(_xmlTip);
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
