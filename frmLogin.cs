using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _4SquareLite
{
    public partial class frmLogin : Form
    {

        String Oauth2 = "https://foursquare.com/oauth2/authenticate?client_id=<CLIENT ID>&response_type=token&redirect_uri=<CALLBACK URL>";


        public frmLogin()
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

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            String HaydenCode = "<USER1 ACCESS ID>";
            String CeliaCode = "<USER2 ACCESS ID>";
            String TestCode = "<USER3 ACCESS ID>";
            if (cmbUser.SelectedItem.ToString() != "")
            {
                switch (cmbUser.SelectedItem.ToString().ToLower())
                {
                    case ("celia"):
                        Program.AccessToken = CeliaCode;
                        LocalSettings.Save("Authentication", CeliaCode);
                        break;
                    case ("hayden"):
                        Program.AccessToken = HaydenCode;
                        LocalSettings.Save("Authentication", HaydenCode);
                        break;
                    case ("testing"):
                        Program.AccessToken = TestCode;
                        LocalSettings.Save("Authentication", TestCode);
                        break;
                }
                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareUser strResult = DotNetSquare.NetSquare.User(Program.AccessToken);
                Cursor.Current = Cursors.Default;

                if (strResult.Equals(null))
                {
                    MessageBox.Show("Oops! You've entered either an incorrect email, phone number or password.", Program.strProgramName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    frmDashboard oForm = new frmDashboard(strResult);
                    oForm.Show();
                    this.Hide();
                }
            }
        }

    }
}