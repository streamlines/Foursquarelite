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
    public partial class ucBadgeListItem : UserControl
    {
        public ucBadgeListItem(DotNetSquare.NetSquare.FourSquareBadge xmlBadge)
        {
            InitializeComponent();

            //name
            lblName.Text = xmlBadge.name;

            //icon
            string strIconURL = Program.GetSmallBadge(xmlBadge);
            pbBadge.Image = Program.getImageFromURL(strIconURL);

            //description
            lblDescription.Text = xmlBadge.description;
        }
    }
}
