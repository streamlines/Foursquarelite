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
    public partial class frmSearchVenue : Form
    {
        public frmSearchVenue()
        {
            InitializeComponent();
            Program.arrForm.Add(this);
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

        private void miSearch_Click(object sender, EventArgs e)
        {
            string strSearch = tbSearch.Text.Trim();
            string strCity = tbCity.Text.Trim();
            string strLat = Program.strGlobalLat;
            string strLon = Program.strGlobalLon;

            if (!String.IsNullOrEmpty(strSearch))
            {
                if (!String.IsNullOrEmpty(strCity))
                {
                    //geocode the city to get the latlon
                    GoogleGeoCode.GeoCode geoResult = GoogleGeoCode.GetGeoCode(System.Uri.EscapeDataString(strCity));

                    strLat = geoResult.Latitude;
                    strLon = geoResult.Longitude;
                }
                if ((String.IsNullOrEmpty(strLat)) || (String.IsNullOrEmpty(strLon)))
                {
                    MessageBox.Show("Oops! We're unable to determine your last known position. Please enter the nearest city / area.", Program.strProgramName,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    btnMore_Click(sender, e);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.SuspendLayout();

                    Int16 Limit = 50;
                    DotNetSquare.NetSquare.FourSquareVenues xmlVenues = DotNetSquare.NetSquare.VenueSearch(strLat + "," + strLon,"","","",System.Uri.EscapeDataString(strSearch),Limit.ToString(),"checkin","","","","",Program.AccessToken);
                    if (xmlVenues.count > 0)
                    {
                        int y = 0;
                        pnlResults.Controls.Clear();
                        foreach (DotNetSquare.NetSquare.FourSquareVenue xmlVenue in xmlVenues.venues)
                        {
                            ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                            oVenue.Location = new Point(0, y);
                            oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            oVenue.Width = pnlResults.Width;

                            pnlResults.Controls.Add(oVenue);
                            pnlResults.Height = oVenue.Location.Y + oVenue.Height;

                            y += oVenue.Height + 3;

                            Panel oLine = new Panel();
                            oLine.Location = new Point(0, y);
                            oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                            oLine.Width = pnlResults.Width;
                            oLine.Height = 1;
                            oLine.BackColor = Color.Black;

                            pnlResults.Controls.Add(oLine);
                            pnlResults.Height = oLine.Location.Y + oLine.Height + 3;

                            y += oLine.Height + 3;
                        }

                        lblNotWhatYoureLookingFor.Location = new Point(3, pnlResults.Location.Y + pnlResults.Height + 3);
                        btnAddVenue.Location = new Point(3, lblNotWhatYoureLookingFor.Location.Y + lblNotWhatYoureLookingFor.Height + 3);

                        pnlResults.Visible = true;
                        lblResults.Visible = true;
                        lblNotWhatYoureLookingFor.Visible = true;
                        btnAddVenue.Visible = true;

                        int i = xmlVenues.count;
                        if (i == 1)
                        {
                            lblResults.Text = "1 result";
                        }
                        else
                        {
                            lblResults.Text = i + " results";
                        }
                    }

                    this.ResumeLayout();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            btnMore.Visible = false;
            pnlMore.Visible = true;

            pnlMore.Location = new Point(3, btnMore.Location.Y);

            lblResults.Location = new Point(3, pnlMore.Location.Y + pnlMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);

            lblNotWhatYoureLookingFor.Location = new Point(3, pnlResults.Location.Y + pnlResults.Height + 3);
            btnAddVenue.Location = new Point(3, lblNotWhatYoureLookingFor.Location.Y + lblNotWhatYoureLookingFor.Height + 3);
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            btnMore.Visible = true;
            pnlMore.Visible = false;

            lblResults.Location = new Point(3, btnMore.Location.Y + btnMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);

            lblNotWhatYoureLookingFor.Location = new Point(3, pnlResults.Location.Y + pnlResults.Height + 3);
            btnAddVenue.Location = new Point(3, lblNotWhatYoureLookingFor.Location.Y + lblNotWhatYoureLookingFor.Height + 3);
        }

        private void frmSearchVenue_Load(object sender, EventArgs e)
        {
            pnlMore.Visible = false;
            lblResults.Visible = false;
            pnlResults.Visible = false;
            lblNotWhatYoureLookingFor.Visible = false;
            btnAddVenue.Visible = false;

            lblResults.Location = new Point(3, btnMore.Location.Y + btnMore.Height + 3);
            pnlResults.Location = new Point(3, lblResults.Location.Y + lblResults.Height + 3);
        }

        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            frmVenueInput oForm = new frmVenueInput("add");
            oForm.Show();
            this.Hide();
        }
    }
}