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
    public partial class frmLeaderboardList : Form
    {
        string _strTitle;
        Int64 _TimeSinceEpoch;

        public frmLeaderboardList(string strTitle)
        {
            InitializeComponent();
            Program.arrForm.Add(this);
            _strTitle = strTitle;
            _TimeSinceEpoch = Program.ToUnixTime(DateTime.Now);

        }

        private void frmLeaderboardList_Load(object sender, EventArgs e)
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
        }

        private void LoadData()
        {
            lblTitle.Text = _strTitle;

            DotNetSquare.NetSquare.FourSquareLeaderBoard xmlLeaderBoard = null;

            try
            {
                xmlLeaderBoard = DotNetSquare.NetSquare.UserLeaderBoard(Program.AccessToken);

                int y = 0;
                for (int i = 0; i < xmlLeaderBoard.LeaderBoard.Count - 1; i++)
                {
                    DotNetSquare.NetSquare.FourSquareUser xmlUser = xmlLeaderBoard.LeaderBoard[i].User;
                    DotNetSquare.NetSquare.FourSquareScore xmlScore = xmlLeaderBoard.LeaderBoard[i].Score;

                    ucLeaderboardItem oLeaderboardItem = new ucLeaderboardItem(xmlUser, xmlScore);
                    oLeaderboardItem.Location = new Point(0, y);
                    oLeaderboardItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    oLeaderboardItem.Width = pnlList.Width;

                    pnlList.Controls.Add(oLeaderboardItem);
                    pnlList.Height = oLeaderboardItem.Location.Y + oLeaderboardItem.Height;

                    y = oLeaderboardItem.Location.Y + oLeaderboardItem.Height + 3;

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
            }
            catch
            {
            }
        }
    }
}