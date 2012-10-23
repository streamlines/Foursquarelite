using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;

namespace _4SquareLite
{
    public partial class frmCheckinList : Form
    {
        string _strLat;
        string _strLon;
        string _strTitle;
        Int64 _TimeSinceEpoch;

        DotNetSquare.NetSquare.FourSquareCheckins _xmlCheckins;
        string _strVenueID;
        bool _bRefresh = false;

        public frmCheckinList(string strLat, string strLon, string strTitle)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strLat = strLat;
            _strLon = strLon;
            _strTitle = strTitle;
            _TimeSinceEpoch = Program.ToUnixTime(Program.SevenDaysAgo());
        }

        // checked in users at a venue
        public frmCheckinList(string strTitle, DotNetSquare.NetSquare.FourSquareCheckins xmlCheckins, string strVenueID)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strTitle = strTitle;
            _xmlCheckins = xmlCheckins;
            _strVenueID = strVenueID;
            _TimeSinceEpoch = Program.ToUnixTime(Program.SevenDaysAgo());
        }

        private void frmCheckins_Load(object sender, EventArgs e)
        {
            LoadData();
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
            _bRefresh = true;
        }

        private void LoadData()
        {
            lblTitle.Text = _strTitle;

            DotNetSquare.NetSquare.FourSquareCheckins xmlCheckins = null;

            if (String.IsNullOrEmpty(_strVenueID))
            {
                xmlCheckins = DotNetSquare.NetSquare.CheckinRecent(_strLat + "," + _strLon,"","",Program.AccessToken);
                int FriendCount = xmlCheckins.count;
            }
            else
            {
                if (_bRefresh)
                {
                    _bRefresh = false;
                    xmlCheckins = DotNetSquare.NetSquare.VenueHereNow(_strVenueID,"","","",Program.AccessToken);
                }
                else
                {
                    xmlCheckins = _xmlCheckins;
                }
            }

            //checkins
            int y = 0;
            for (int i = 0; i < xmlCheckins.count; i++)
            {
                DotNetSquare.NetSquare.FourSquareCheckin xmlCheckin = xmlCheckins.checkins[i];
                //checkin
                ucCheckinListItem oCheckin = new ucCheckinListItem(xmlCheckin);
                oCheckin.Location = new Point(0, y);
                oCheckin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oCheckin.Width = pnlList.Width;

                pnlList.Controls.Add(oCheckin);
                pnlList.Height = oCheckin.Location.Y + oCheckin.Height;

                y = oCheckin.Location.Y + oCheckin.Height + 3;

                Panel oLine = new Panel();
                oLine.Location = new Point(0, y);
                oLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oLine.Width = pnlList.Width;
                oLine.Height = 1;
                oLine.BackColor = Color.Black;

                pnlList.Controls.Add(oLine);
                pnlList.Height = oLine.Location.Y + oLine.Height;

                y = oLine.Location.Y + oLine.Height + 3;
            }

            Button oButton = new Button();
            oButton.Location = new Point(0, y);
            oButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            oButton.Width = pnlList.Width;
            oButton.Click += new EventHandler(oButton_Click);

            pnlList.Controls.Add(oButton);
            pnlList.Height = oButton.Location.Y + oButton.Height;

        }

        void oButton_Click(object sender, EventArgs e)
        {
            frmVenueFullMap oForm = new frmVenueFullMap(_strLat, _strLon);
            oForm.Show();

            MessageBox.Show(this.ToString());

            this.Hide();
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