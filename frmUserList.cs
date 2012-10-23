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
    public partial class frmUserList : Form
    {
        string _strFormType;
        string _strSearchType;
        string _strCriteria;
        string _strTitle;

        //friendrequest
        public frmUserList(string strTitle, string strFormType)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strTitle = strTitle;
            _strFormType = strFormType;
        }

        //friends, criteria
        public frmUserList(string strTitle, string strFormType, string strCriteria)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strTitle = strTitle;
            _strFormType = strFormType;
            _strCriteria = strCriteria;
        }

        //search, type, criteria
        public frmUserList(string strTitle, string strFormType, string strSearchType, string strCriteria)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strTitle = strTitle;
            _strFormType = strFormType;
            _strSearchType = strSearchType;
            _strCriteria = strCriteria;
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

        private void frmPending_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            DotNetSquare.NetSquare.FourSquareUsers xmlUsers = null;
            Int16 Limit = 100;
            Int16 Offset = 0;

            lblTitle.Text = _strTitle;

            if (_strFormType.Equals("friendrequest"))
            {
                xmlUsers = DotNetSquare.NetSquare.UserRequests(Program.AccessToken);
            }
            else
            {
                if (!String.IsNullOrEmpty(_strCriteria))
                {
                    xmlUsers = DotNetSquare.NetSquare.UserSearch("","","","","",_strCriteria, Program.AccessToken);
                }
                else
                {
                    xmlUsers = DotNetSquare.NetSquare.UserFriends("self", Limit, Offset,Program.AccessToken);
                }
            }
            
            if (xmlUsers.count > 0)
            {
                int y = 0;
                pnlList.Controls.Clear();
                foreach (DotNetSquare.NetSquare.FourSquareUser xmlUser in xmlUsers.Users)
                {
                    ucUserListItem oUser = new ucUserListItem(xmlUser);
                    oUser.Location = new Point(0, y);
                    oUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oUser.Width = pnlList.Width;

                    pnlList.Controls.Add(oUser);
                    pnlList.Height = oUser.Location.Y + oUser.Height;

                    y = oUser.Location.Y + oUser.Height + 3;

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
    }
}