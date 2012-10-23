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
    public partial class ucScoreListItem : UserControl
    {
        public ucScoreListItem(DotNetSquare.NetSquare.FourSquareCheckinScore xmlScore)
        {
            InitializeComponent();

            lblScore.Text = xmlScore.Points.ToString();

            string strIconURL = xmlScore.icon;
            pbIcon.Image = Program.getImageFromURL(strIconURL);

            lblMessage.Text = xmlScore.message;
            
        }
    }
}
