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
    public partial class frmAddTip : Form
    {
        string _strVenueID;
        string _strVenueName;
        string _strIconURL;
        string _strCategory;
        string _strLat;
        string _strLon;

        public frmAddTip(string strVenueID, 
                         string strVenueName,
                         string strIconURL, 
                         string strCategory, 
                         string strLat, 
                         string strLon)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strVenueID = strVenueID;
            _strVenueName = strVenueName;
            _strIconURL = strIconURL;
            _strCategory = strCategory;
            _strLat = strLat;
            _strLon = strLon;
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

        private void miCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void frmAddTip_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //name
            lblVenue.Text = _strVenueName;

            ////nodename
            if (!String.IsNullOrEmpty(_strCategory))
            {
                lblCategory.Text = _strCategory;
            }

            ////iconurl
            if (!String.IsNullOrEmpty(_strIconURL))
            {
                pbIcon.Image = Program.getImageFromURL(_strIconURL);
            }

            if ((!String.IsNullOrEmpty(_strLat)) && (!String.IsNullOrEmpty(_strLon)))
            {
                pbMap.Image = Program.getImageFromURL(GoogleGeoCode.getGoogleMapURL(_strLat, _strLon, pbMap.Size, false));
            }

            lblCounter.Text = "(0 / 140)";

            Cursor.Current = Cursors.Default;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            string strTip = tbText.Text.Trim();

            if (!String.IsNullOrEmpty(strTip))
            {
                /*
                vid - the venue where you want to add this tip (required)
                text - the text of the tip or to-do item (required)
                */

                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareTip Result = DotNetSquare.NetSquare.TipAdd(_strVenueID, tbText.Text.Trim(), "",Program.AccessToken);
                Cursor.Current = Cursors.Default;

                if (Result.Equals(null))
                {
                    MessageBox.Show("Oops! We couldn't post your tip. Try again later.", Program.strProgramName,
                        MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("OK! Tip added successfully.", Program.strProgramName,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    CloseForm();
                }
            }
        }

        private void CloseForm()
        {
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void tbText_KeyUp(object sender, KeyEventArgs e)
        {
            int iNoOfChars = tbText.Text.Length;
            lblCounter.Text = "(" + iNoOfChars + " / 140)";
        }
    }
}