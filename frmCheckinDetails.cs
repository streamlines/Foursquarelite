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
    public partial class frmCheckinDetails : Form
    {
        string _strUserID;
        string _strVenueID;

        public frmCheckinDetails(DotNetSquare.NetSquare.FourSquareCheckin  xmlCheckin)
        {
            InitializeComponent();
            Program.arrForm.Add(this);

            Cursor.Current = Cursors.WaitCursor;

            /////////////////////////////////////////////////////////////
            //timestamp
            string strCreated = xmlCheckin.createdAt.ToString();
            lblTimestamp.Text = Program.convertAPITimeToLocalTime(strCreated);

            // distance
            string strDistance = xmlCheckin.venue.location.Distance;
            strDistance = lblTimestamp.Text + " " + Program.convertDistanceToKM(strDistance) + " away";
            lblTimestamp.Text = strDistance.Trim();

            int y = lblTimestamp.Location.Y + lblTimestamp.Height + 3;

            /////////////////////////////////////////////////////////
            // venue
            DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlCheckin.venue;
            if (xmlVenue != null)
            {
                _strVenueID = xmlVenue.id;

                ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                oVenue.Location = new Point(3, y);
                oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oVenue.Width = pnlForm.Width - 3 * 2;

                pnlForm.Controls.Add(oVenue);

                y = oVenue.Location.Y + oVenue.Height + 3;
            }

            /////////////////////////////////////////////////////////////
            // user
            DotNetSquare.NetSquare.FourSquareUser xmlUser = xmlCheckin.user;
            if (xmlUser != null)
            {
                _strUserID = xmlUser.id;

                ucUserListItem oUser = new ucUserListItem(xmlUser);
                oUser.Location = new Point(3, y);
                oUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oUser.Width = pnlForm.Width - 3 * 2;

                pnlForm.Controls.Add(oUser);

                y = oUser.Location.Y + oUser.Height + 3;
            }

            ////////////////////////////////////////////////
            // shout
            pnlShout.Location = new Point(3, y);

            string strShout = xmlCheckin.shout;
            tbShout.Text = strShout;

            if (String.IsNullOrEmpty(strShout))
            {
                pnlShout.Visible = false;
                pnlShout.Height = 0;
            }
            else
            {
                y = pnlShout.Location.Y + pnlShout.Height + 3;
            }

            Cursor.Current = Cursors.Default;
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
    }
}