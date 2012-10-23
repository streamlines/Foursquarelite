using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeoCoding;

namespace _4SquareLite
{
    public partial class frmGPS : Form
    {
        Access GPS = new Access();
        System.Windows.Forms.Timer _timer;

        public frmGPS()
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            this.Text = Program.strProgramName;
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

        private void frmGPS_Load(object sender, EventArgs e)
        {
            // GPS Stuff
            GPS.Start();

            lblLat.Text = GPS.Latitude;
            lblLon.Text = GPS.Longitude;
            lblSource.Text = GPS.source;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;

            btnTip.Enabled = false;
            btnVenue.Enabled = false;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            //This codes runs every 5 seconds and will update the map and global location variables
            
            if (lblLat.Text != GPS.Latitude)
            {
                //Location has changed
                lblSource.Text = GPS.source;
                lblLat.Text = GPS.Latitude;
                lblLon.Text = GPS.Longitude;
                Program.strGlobalLat = GPS.Latitude;
                Program.strGlobalLon = GPS.Longitude;

                // Now we have some data
                btnTip.Enabled = true;
                btnVenue.Enabled = true;

                string strURL = GoogleGeoCode.getGoogleMapURL(lblLat.Text, lblLon.Text, pbMap.Size, true);
                pbMap.Image = Program.getImageFromURL(strURL);
            }
        }


        private void miBack_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            GPS.Stop();
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void btnVenue_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            GPS.Stop();
            frmVenueList oForm = new frmVenueList(lblLat.Text, lblLon.Text, "Your Location");
            oForm.Show();
            this.Hide();
        }

        private void btnTip_Click(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            GPS.Stop();
            frmTipList oForm = new frmTipList(lblLat.Text, lblLon.Text, "Your Location");
            oForm.Show();
            this.Hide();
        }


    }
}