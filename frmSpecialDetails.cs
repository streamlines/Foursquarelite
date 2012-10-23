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
    public partial class frmSpecialDetails : Form
    {
       public frmSpecialDetails(DotNetSquare.NetSquare.FourSquareSpecial xmlSpecial)
        {
            InitializeComponent();
            Program.arrForm.Add(this);

            lblTitle.Text = "Special";

            int y = lblTitle.Location.Y + lblTitle.Height + 3;

            DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlSpecial.venue;
            if (xmlVenue != null)
            {
                ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                oVenue.Location = new Point(3, y);
                oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oVenue.Width = pnlForm.Width - 3 * 2;

                pnlForm.Controls.Add(oVenue);

                y = oVenue.Location.Y + oVenue.Height + 3;
            }

            pnlSpecial.Location = new Point(3, y);

            lblType.Text = xmlSpecial.type;
            lblKind.Text = xmlSpecial.message;
            tbMessage.Text = xmlSpecial.description;
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
    }
}