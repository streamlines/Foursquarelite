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
    public partial class frmTipList : Form
    {
        string _strLat;
        string _strLon;
        string _strVenueName;

        public frmTipList(string strLat, string strLon, string strVenueName)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            
            _strLat = strLat;
            _strLon = strLon;
            _strVenueName = strVenueName;
        }

        private void frmTipList_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Tips Near " + _strVenueName;
            LoadData();
        }

        private void miRefresh_Click(object sender, EventArgs e)
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

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            Int16 Limit = 20;
            Int16 offset = 0;
            DotNetSquare.NetSquare.FourSquareTips xmlTips = DotNetSquare.NetSquare.TipSearch(_strLat + "," + _strLon, Limit.ToString(), offset.ToString(), "", "",Program.AccessToken);

            if (xmlTips.count > 0)
            {
                int y = 0;
                pnlList.Controls.Clear();
                foreach (DotNetSquare.NetSquare.FourSquareTip xmlTip in xmlTips.tips)
                {
                    DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlTip.venue;
                    if (xmlVenue != null)
                    {
                        ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);

                        oVenue.Location = new Point(0, y);
                        oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        oVenue.Width = pnlList.Width;

                        pnlList.Controls.Add(oVenue);
                        pnlList.Height = oVenue.Location.Y + oVenue.Height;

                        y += oVenue.Height + 3;
                    }

                    ucTipListItem oTip = new ucTipListItem(xmlTip);
                    oTip.Location = new Point(0, y);
                    oTip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oTip.Width = pnlList.Width;

                    pnlList.Controls.Add(oTip);
                    pnlList.Height = oTip.Location.Y + oTip.Height;

                    y += oTip.Height + 3;

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

                pnlList.Height += 3;
            }

            Cursor.Current = Cursors.Default;
        }
    }
}