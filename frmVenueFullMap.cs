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
    public partial class frmVenueFullMap : Form
    {
        string _strLat;
        string _strLon;

//        XmlNodeList _xmlList;

        public frmVenueFullMap(string strLat, string strLon)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strLat = strLat;
            _strLon = strLon;
        }

 /*       public frmVenueFullMap(string strLat, string strLon, XmlNodeList xmlList)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            
            _strLat = strLat;
            _strLon = strLon;
           _xmlList = xmlList;
        }
*/
        private void frmVenueFullMap_Load(object sender, EventArgs e)
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

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

//            if (_xmlList != null)
//            {
                string strURL = GoogleGeoCode.getGoogleMapURL(_strLat, _strLon, pbMap.Size, false);
                pbMap.Image = Program.getImageFromURL(strURL);
//            }
//            else
//            {
//                string strURL = "http://maps.google.com/maps/api/staticmap?center=" + _strLat + "," + _strLon + "&zoom=10&size=" + pbMap.Width + "x" + pbMap.Height + "&maptype=roadmap&mobile=true&sensor=false&markers=size:small|color:blue|" + _strLat + "," + _strLon;
//            }
            
            Cursor.Current = Cursors.Default;
        }
    }
}