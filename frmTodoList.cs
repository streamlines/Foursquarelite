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
    public partial class frmTodoList : Form
    {
        string _strLat;
        string _strLon;
        string _strVenueName;

        public frmTodoList(string strLat, string strLon, string strVenueName)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            
            _strLat = strLat;
            _strLon = strLon;
            _strVenueName = strVenueName;
        }

        private void frmTodoList_Load(object sender, EventArgs e)
        {
            if (_strVenueName == "")
            {
                lblTitle.Text = "Recent Todo's";
            }
            else
            {
                lblTitle.Text = "Todo's Near " + _strVenueName;
            }
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
            DotNetSquare.NetSquare.FourSquareTodos xmlTodos;

            if (_strVenueName == "")
            {
                xmlTodos = DotNetSquare.NetSquare.UserTodos("self", "recent", "", Program.AccessToken);
            }
            else
            {
                xmlTodos = DotNetSquare.NetSquare.UserTodos("self", "nearby", _strLat + "," + _strLon, Program.AccessToken);
            }

            if (xmlTodos.count > 0)
            {
                int y = 0;
                pnlList.Controls.Clear();
                foreach (DotNetSquare.NetSquare.FourSquareTodo xmlTodo in xmlTodos.todos)
                {
                    if (xmlTodo.tip != null)
                    {
                        DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlTodo.tip.venue;
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

                        if (xmlTodo.tip.user != null)
                        {
                            ucTipListItem oTip = new ucTipListItem(xmlTodo.tip);
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
                    }
                }
                pnlList.Height += 3;
            }

            Cursor.Current = Cursors.Default;
        }
    }
}