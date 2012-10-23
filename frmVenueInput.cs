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
    public partial class frmVenueInput : Form
    {
        string _strFormType;
        DotNetSquare.NetSquare.FourSquareVenueCategories _strCategories;

        public frmVenueInput(string strFormType)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strFormType = strFormType;
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

        private void btnReview_Click(object sender, EventArgs e)
        {
            frmVenueFullMap oForm = new frmVenueFullMap(tbLat.Text, tbLon.Text);
            oForm.Show();
            this.Hide();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            /*
            name - the name of the venue
            address - (optional) the address of the venue (e.g., "202 1st Avenue")
            crossstreet - (optional) the cross streets (e.g., "btw Grand & Broome")
            city - (optional) the city name where this venue is
            state - (optional) the state where the city is
            zip - (optional) the ZIP code for the venue
            phone - (optional) the phone number for the venue
            geolat - (optional, but recommended)
            geolong - (optional, but recommended)
            primarycategoryid - (optional) the ID of the category to which you want to assign this venue
            */
            string strName = tbName.Text.Trim();
            string strAddress = tbAddress.Text.Trim();
            string strCrossStreet = tbCrossStreet.Text.Trim();
            string strCity = tbCity.Text.Trim();
            string strState = tbState.Text.Trim();
            string strZip = tbZip.Text.Trim();
            string strPhone = tbPhone.Text.Trim();
            string strLat = tbLat.Text.Trim();
            string strLon = tbLon.Text.Trim();
            string strCatID = lblCategoryID.Text.Trim();

            if (String.IsNullOrEmpty(strName))
            {
                MessageBox.Show("Oops! Name cannot be blank", Program.strProgramName,
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
                return;
            }

            if (!_strFormType.Equals("add"))
            {
                /*
                vid - (required) the venue for which you want to propose an edit
                name - (required) the name of the venue
                address - (required) the address of the venue (e.g., "202 1st Avenue")
                crossstreet - the cross streets (e.g., "btw Grand & Broome")
                city - (required) the city name where this venue is
                state - (required) the state where the city is
                zip - (optional) the ZIP code for the venue
                phone - (optional) the phone number for the venue
                geolat - (required)
                geolong - (required)
                */
                if (String.IsNullOrEmpty(strAddress))
                {
                    MessageBox.Show("Oops! Address cannot be blank.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    return;
                }

                if (String.IsNullOrEmpty(strCity))
                {
                    MessageBox.Show("Oops! City cannot be blank.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    return;
                }

                if (String.IsNullOrEmpty(strState))
                {
                    MessageBox.Show("Oops! State cannot be blank.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    return;
                }

                if ((String.IsNullOrEmpty(strLat)) || (String.IsNullOrEmpty(strLon)))
                {
                    MessageBox.Show("Oops! You must specify a valid lat / long pair. Either click the 'Preview Map' button or enter it manually.", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return;
                }
            }
            else
            {
                if ((String.IsNullOrEmpty(strAddress)) && ((String.IsNullOrEmpty(strLat)) || (String.IsNullOrEmpty(strLon))))
                {
                    MessageBox.Show("Oops! You must specify either a valid address or a lat/long pair", Program.strProgramName,
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    return;
                }
            }

            DotNetSquare.NetSquare.FourSquareVenue strResult = DotNetSquare.NetSquare.VenueAdd(strName, strAddress, strCrossStreet, strCity, strState, strZip, strPhone, strLat + "," + strLon, strCatID, Program.AccessToken);

            if (!(strResult.Equals(null)))
            {
                MessageBox.Show("OK! Venue saved successfully", Program.strProgramName,
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                int i = Program.arrForm.Count - 1;
                Program.arrForm.RemoveAt(i);
                this.Close();

                if (_strFormType.Equals("add"))
                {
                    //get id
                    string strVenueID = strResult.id;
                    //show details
                    frmVenueDetails oVenueDetails = new frmVenueDetails(strVenueID);
                    oVenueDetails.Show();
                }
                else
                {
                    i--;
                    ((Form)Program.arrForm[i]).Show();
                }
            }
        }

        private void miCancel_Click(object sender, EventArgs e)
        {
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string strName = tbName.Text.Trim();
            string strAddress = tbAddress.Text.Trim();
            string strCrossStreet = tbCrossStreet.Text.Trim();
            string strCity = tbCity.Text.Trim();
            string strState = tbState.Text.Trim();
            string strZip = tbZip.Text.Trim();
            string strPhone = tbPhone.Text.Trim();

            string strGeocode = "";
            if (!String.IsNullOrEmpty(strAddress))
            {
                strGeocode += strAddress;
            }

            if (!String.IsNullOrEmpty(strState))
            {
                strGeocode += " " + strState;
            }

            if (!String.IsNullOrEmpty(strCity))
            {
                strGeocode += " " + strCity;
            }

            if (!String.IsNullOrEmpty(strZip))
            {
                strGeocode += " " + strZip;
            }

            strGeocode = strGeocode.Replace(" ", "+");
            GoogleGeoCode.GeoCode geoResult = GoogleGeoCode.GetGeoCode(System.Uri.EscapeDataString(strGeocode));

            tbLat.Text = geoResult.Latitude;
            tbLon.Text = geoResult.Longitude;

            frmVenueFullMap oForm = new frmVenueFullMap(tbLat.Text, tbLon.Text);
            oForm.Show();
            this.Hide();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            tbLat.Enabled = true;
            tbLon.Enabled = true;
            btnReview.Enabled = true;
        }

        private void frmVenueInput_Load(object sender, EventArgs e)
        {
            // grow the form
            pnlBasic.Height = tbPhone.Location.Y + tbPhone.Height;
            pnlLatLon.Location = new Point(3, pnlBasic.Location.Y + pnlBasic.Height + 5);
            pnlLatLon.Height = btnReview.Location.Y + btnReview.Height;
            pnlCategory.Location = new Point(3, pnlLatLon.Location.Y + pnlLatLon.Height + 5);

            if (!_strFormType.Equals("add"))
            {
                lblTitle.Text = "Propose Edit";
                /*
                vid - (required) the venue for which you want to propose an edit
                name - (required) the name of the venue
                address - (required) the address of the venue (e.g., "202 1st Avenue")
                crossstreet - the cross streets (e.g., "btw Grand & Broome")
                city - (required) the city name where this venue is
                state - (required) the state where the city is
                zip - (optional) the ZIP code for the venue
                phone - (optional) the phone number for the venue
                geolat - (required)
                geolong - (required)
                */
                lblAddress.ForeColor = lblName.ForeColor;
                lblCity.ForeColor = lblName.ForeColor;
                lblState.ForeColor = lblName.ForeColor;
                lblLat.ForeColor = lblName.ForeColor;
                lblLon.ForeColor = lblName.ForeColor;

                tbAddress.BackColor = tbName.BackColor;
                tbCity.BackColor = tbName.BackColor;
                tbState.BackColor = tbName.BackColor;
                tbLat.BackColor = tbName.BackColor;
                tbLon.BackColor = tbName.BackColor;
            }
            else
            {
                lblTitle.Text = "Add Venue";
            }

            comboBox1.Visible = false;
            comboBox2.Visible = false;

            lblCategoryID.Text = "";

            Cursor.Current = Cursors.WaitCursor;
            _strCategories = DotNetSquare.NetSquare.VenueCategories(Program.AccessToken);
            Cursor.Current = Cursors.Default;

            if (!(_strCategories.Equals(null)))
            {
                List<DotNetSquare.NetSquare.FourSquareVenueCategory> xmlCategories = _strCategories.categories;
                foreach (DotNetSquare.NetSquare.FourSquareVenueCategory xmlCategory in xmlCategories)
                {
                    string strNodeName = xmlCategory.name;
                    strNodeName = strNodeName.Replace("&&", "&");
                    ddlCategory.Items.Add(strNodeName);
                }
            }
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Visible = false;
            comboBox2.Visible = false;

            string strSelected = ddlCategory.SelectedItem.ToString();

            // read the xml

            DotNetSquare.NetSquare.FourSquareVenueCategory xmlSelected = _strCategories.categories.Find(delegate(DotNetSquare.NetSquare.FourSquareVenueCategory p) { return p.name == strSelected; });
            string strIconURL = xmlSelected.icon;

            Cursor.Current = Cursors.WaitCursor;
            pbIcon.Image = Program.getImageFromURL(strIconURL);
            Cursor.Current = Cursors.Default;

            lblCategoryID.Text = xmlSelected.id;

            List<DotNetSquare.NetSquare.FourSquareVenueCategory> xmlSubCats = xmlSelected.categories;
            if ((xmlSubCats != null) && (xmlSubCats.Count > 0))
            {
                foreach (DotNetSquare.NetSquare.FourSquareVenueCategory xmlSubCat in xmlSubCats)
                {
                    string strNodeName = xmlSubCat.name;
                    strNodeName = strNodeName.Replace("&&", "&");
                    comboBox1.Items.Add(strNodeName);
                }

                comboBox1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Visible = false;

            string strSelected = comboBox1.SelectedItem.ToString();

            // read the xml

            DotNetSquare.NetSquare.FourSquareVenueCategory xmlSelected = _strCategories.categories.Find(delegate(DotNetSquare.NetSquare.FourSquareVenueCategory p) { return p.name == strSelected; });
            string strIconURL = xmlSelected.icon;

            Cursor.Current = Cursors.WaitCursor;
            pbIcon.Image = Program.getImageFromURL(strIconURL);
            Cursor.Current = Cursors.Default;

            lblCategoryID.Text = xmlSelected.id;

            List<DotNetSquare.NetSquare.FourSquareVenueCategory> xmlSubCats = xmlSelected.categories;
            if ((xmlSubCats != null) && (xmlSubCats.Count > 0))
            {
                foreach (DotNetSquare.NetSquare.FourSquareVenueCategory xmlSubCat in xmlSubCats)
                {
                    string strNodeName = xmlSubCat.name;
                    strNodeName = strNodeName.Replace("&&", "&");
                    comboBox2.Items.Add(strNodeName);
                }

                comboBox2.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelected = comboBox2.SelectedItem.ToString();

            // read the xml

            DotNetSquare.NetSquare.FourSquareVenueCategory xmlSelected = _strCategories.categories.Find(delegate(DotNetSquare.NetSquare.FourSquareVenueCategory p) { return p.name == strSelected; });
            string strIconURL = xmlSelected.icon;

            Cursor.Current = Cursors.WaitCursor;
            pbIcon.Image = Program.getImageFromURL(strIconURL);
            Cursor.Current = Cursors.Default;

            lblCategoryID.Text = xmlSelected.id;
        }
    }
}