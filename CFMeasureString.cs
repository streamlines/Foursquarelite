using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace _4SquareLite
{
    class CFMeasureString
    {
        private struct Rect
        {
            public int Left, Top, Right, Bottom;
            public Rect(Rectangle r)
            {
                this.Left = r.Left;
                this.Top = r.Top;
                this.Bottom = r.Bottom;
                this.Right = r.Right;
            }
        }

        [DllImport("coredll.dll")]
        static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref Rect lpRect, int wFormat);

        [DllImport("coredll.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("coredll.dll")]
        static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        private const int DT_CALCRECT = 0x00000400;
        private const int DT_WORDBREAK = 0x00000010;
        private const int DT_EDITCONTROL = 0x00002000;


        /// <summary>
        /// Measure a Multiline string for a control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="text">String to measure</param>
        /// <param name="rect">Original Rect. The Width will be taken as fixed</param>
        /// <returns>A Size object with the measure of the string according to the params</returns>
        static public Size MeasureString(Control control, string text, Rectangle rect)
        {
            Size Result = Size.Empty;
            IntPtr controlFont = control.Font.ToHfont();
            IntPtr hDC = GetDC(control.Handle);
            using (Graphics gr = Graphics.FromHdc(hDC))
            {
                IntPtr originalObject = SelectObject(hDC, controlFont);
                Result = MeasureString(gr, text, rect, control is TextBox);
                SelectObject(hDC, originalObject); //Release resources
            }
            return Result;
        }


        /// <summary>
        /// Measure a multiline string for a Control
        /// </summary>
        /// <param name="gr">Graphics</param>
        /// <param name="text">String to messure</param>
        /// <param name="rect">Original rect. The Width will be taken as fixed</param>
        /// <param name="textboxControl">True if you want to measure the string for a textbox control</param>
        /// <returns>A Size object with the measure of the string according with the params</returns>
        static public Size MeasureString(Graphics gr, string text, Rectangle rect, bool textboxControl)
        {
            Rect bounds = new Rect(rect);
            IntPtr hdc = gr.GetHdc();
            int flags = DT_CALCRECT | DT_WORDBREAK;
            if (textboxControl) flags |= DT_EDITCONTROL;
            DrawText(hdc, text, text.Length, ref bounds, flags);
            gr.ReleaseHdc(hdc);
            return new Size(bounds.Right - bounds.Left, bounds.Bottom - bounds.Top + (textboxControl ? 6 : 0));

        }
    }
}
