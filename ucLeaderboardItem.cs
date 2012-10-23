using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace _4SquareLite
{
    public partial class ucLeaderboardItem : UserControl
    {
        public ucLeaderboardItem(DotNetSquare.NetSquare.FourSquareUser xmlUser, DotNetSquare.NetSquare.FourSquareScore xmlScore)
        {
            InitializeComponent();

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

            lblRecent.Text = xmlScore.checkinsCount.ToString();
            lblMaxScore.Text = xmlScore.max.ToString();
            lblScore.Text = xmlScore.recent.ToString();

        }

    }
}
