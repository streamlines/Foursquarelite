using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _4SquareLite
{
    public partial class ucSpecialListItem : UserControl
    {
        DotNetSquare.NetSquare.FourSquareSpecial _xmlSpecial;
        public ucSpecialListItem(DotNetSquare.NetSquare.FourSquareSpecial xmlSpecial)
        {
            InitializeComponent();

            _xmlSpecial = xmlSpecial;

            lblType.Text = xmlSpecial.type;

            lblKind.Text = xmlSpecial.message;

            lblMessage.Text = xmlSpecial.description;
        }

        private void ucSpecialListItem_Click(object sender, EventArgs e)
        {
            frmSpecialDetails oForm = new frmSpecialDetails(_xmlSpecial);
            oForm.Show();

            var oObject = this.Parent;
            while (!oObject.ToString().Contains("frm"))
            {
                oObject = oObject.Parent;
            }

            oObject.Hide();
        }
    }
}
