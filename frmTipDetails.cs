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
    public partial class frmTipDetails : Form
    {
        string _strTipID;

        public frmTipDetails(DotNetSquare.NetSquare.FourSquareTip xmlTip)
        {
            InitializeComponent();
            Program.arrForm.Add(this);

            Cursor.Current = Cursors.WaitCursor;

            _strTipID = xmlTip.id;

            string strCreated = xmlTip.createdAt.ToString();
            lblTimestamp.Text = Program.convertAPITimeToCuteTime(strCreated);

            string strDistance = xmlTip.venue.location.Distance;
            if (!String.IsNullOrEmpty(strDistance))
            {
                strDistance = Program.convertDistanceToKM(strDistance);
                strDistance = lblTimestamp.Text + " " + strDistance + " away";
                lblTimestamp.Text = strDistance.Trim();
            }
            
            int y = lblTimestamp.Location.Y + lblTimestamp.Height + 3;

            DotNetSquare.NetSquare.FourSquareVenue xmlVenue = xmlTip.venue;
            if (xmlVenue != null)
            {
                ucVenueListItem oVenue = new ucVenueListItem(xmlVenue);
                oVenue.Location = new Point(0, 0);
                oVenue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oVenue.Width = pnlVenue.Width;

                pnlVenue.Controls.Add(oVenue);
                pnlVenue.Height = oVenue.Location.Y + oVenue.Height;

                y = pnlVenue.Location.Y + pnlVenue.Height + 3;
            }

            DotNetSquare.NetSquare.FourSquareUser xmlUser = xmlTip.user;
            if (xmlUser != null)
            {
                ucUserListItem oUser = new ucUserListItem(xmlUser);
                oUser.Location = new Point(3, y);
                oUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                oUser.Width = pnlForm.Width - 3 * 2;

                pnlForm.Controls.Add(oUser);

                y = oUser.Location.Y + oUser.Height + 3;
            }

            tbTip.Text = xmlTip.text;

            pnlTip.Location = new Point(3, y);

            y = pnlTip.Location.Y + pnlTip.Height + 3;

            pnlButtons.Location = new Point(3, y + 3);

            Cursor.Current = Cursors.Default;
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

        private void miBack_Click(object sender, EventArgs e)
        {
            int i = Program.arrForm.Count;
            i--;
            Program.arrForm.RemoveAt(i);
            i--;
            ((Form)Program.arrForm[i]).Show();
            this.Close();
        }

        private void btnToDo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Add this item to your to-do list?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareTodo strResult = DotNetSquare.NetSquare.TipMarkTodo(_strTipID,Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Item added to your to-do list.", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Mark this item as done?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareTip strResult = DotNetSquare.NetSquare.TipMarkDone(_strTipID, Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Item marked as done", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Undo this item?", Program.strProgramName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DotNetSquare.NetSquare.FourSquareTip strResult = DotNetSquare.NetSquare.TipUnMark(_strTipID, Program.AccessToken);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("OK! Item reverted to its previous state", Program.strProgramName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }
    }
}