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
    public partial class frmVenueList : Form
    {
        string _strLat;
        string _strLon;
        string _strVenueName;

        public frmVenueList(string strLat, string strLon, string strVenueName)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strLat = strLat;
            _strLon = strLon;
            _strVenueName = strVenueName;
        }

        private void frmVenueList_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void miRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            Int16 Limit = 50;

            DotNetSquare.NetSquare.FourSquareVenues xmlVenues = DotNetSquare.NetSquare.VenueSearch(_strLat + ","+ _strLon,"","","","", Limit.ToString(),"","","","","",Program.AccessToken);

            if (xmlVenues.count > 0)
            {
                int y = 0;
                pnlList.Controls.Clear();

                foreach (DotNetSquare.NetSquare.FourSquareVenue xmlVenue in xmlVenues.venues)
                {
                    ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                    oVenue.Location = new Point(0, y);
                    oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oVenue.Width = pnlList.Width;

                    pnlList.Controls.Add(oVenue);
                    pnlList.Height = oVenue.Location.Y + oVenue.Height;

                    y = oVenue.Location.Y + oVenue.Height + 3;

                    Panel oLine = new Panel();
                    oLine.Location = new Point(0, y);
                    oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oLine.Width = pnlList.Width;
                    oLine.Height = 1;
                    oLine.BackColor = Color.Black;

                    pnlList.Controls.Add(oLine);
                    pnlList.Height = oLine.Location.Y + oLine.Height;

                    y += oLine.Height + 3;
                }

                y = pnlList.Location.Y + pnlList.Height + 3;

                lblNotWhatYoureLookingFor.Location = new Point(3, y);
                y += lblNotWhatYoureLookingFor.Height + 3;

                btnAddVenue.Location = new Point(3, y);
                pnlList.Height = btnAddVenue.Location.Y + btnAddVenue.Height + 3;

                int i = xmlVenues.count;
                if (i == 1)
                {
                    lblTitle.Text = "1 Venue Near " + _strVenueName;
                }
                else
                {
                    lblTitle.Text = i + " Venues Near " + _strVenueName;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            frmVenueInput oForm = new frmVenueInput("add");
            oForm.Show();
            this.Hide();
        }
    }
}