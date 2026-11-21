/*
    Template v0.0
    Copyright (C) 2026 NataljaNeumann@gmx.de

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

*/

using System.Drawing;
using System.Windows.Forms;

namespace Template.Controls
{
    //*******************************************************************************************************
    /// <summary>
    /// Provides a checkbox that paints its foreground consistently in dark mode
    /// and supports right-to-left layouts.
    /// </summary>
    //*******************************************************************************************************
    public class ThemedCheckBox : CheckBox
    {
        //===================================================================================================
        /// <summary>
        /// Gets or sets a value indicating whether dark-mode painting is enabled.
        /// </summary>
        public bool DarkMode { get; set; }

        //===================================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemedCheckBox"/> class.
        /// </summary>
        //===================================================================================================
        public ThemedCheckBox()
        {
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,
                true);
            UseVisualStyleBackColor = false;
        }

        //===================================================================================================
        /// <summary>
        /// Paints the checkbox using a consistent layout for enabled and disabled
        /// states.
        /// </summary>
        /// <param name="oEventArgs">The event data for the paint operation.</param>
        //===================================================================================================
        protected override void OnPaint(
            PaintEventArgs oEventArgs
            )
        {
            if (!DarkMode)
            {
                base.OnPaint(oEventArgs);
                return;
            }

            oEventArgs.Graphics.Clear(BackColor);

            int nBoxSize = 13;
            int nBoxTop = (ClientSize.Height - nBoxSize) / 2;
            bool bRightToLeft = RightToLeft == RightToLeft.Yes;
            int nBoxLeft = bRightToLeft
                ? ClientSize.Width - nBoxSize - 5
                : 0;
            Rectangle oBox = new Rectangle(
                nBoxLeft,
                nBoxTop,
                nBoxSize,
                nBoxSize);

            using (SolidBrush oBackground = new SolidBrush(Color.FromArgb(45, 45, 45)))
            using (Pen oBorder = new Pen(Color.FromArgb(120, 120, 120)))
            {
                oEventArgs.Graphics.FillRectangle(oBackground, oBox);
                oEventArgs.Graphics.DrawRectangle(oBorder, oBox);
            }

            Color oForeground = Enabled
                ? Color.FromArgb(240, 240, 240)
                : Color.FromArgb(130, 130, 130);

            if (Checked)
            {
                using (Pen oCheck = new Pen(oForeground, 2))
                {
                    Point[] aCheckPoints =
                    {
                        new Point(nBoxLeft + 3, nBoxTop + 6),
                        new Point(nBoxLeft + 6, nBoxTop + 9),
                        new Point(nBoxLeft + 11, nBoxTop + 3)
                    };

                    oEventArgs.Graphics.DrawLines(oCheck, aCheckPoints);
                }
            }

            Rectangle oTextBounds = bRightToLeft
                ? new Rectangle(
                    0,
                    0,
                    ClientSize.Width - nBoxSize - 5,
                    ClientSize.Height)

                : new Rectangle(
                    nBoxSize + 4,
                    0,
                    ClientSize.Width - nBoxSize - 4,
                    ClientSize.Height);

            TextFormatFlags eAlignment = bRightToLeft
                ? TextFormatFlags.RightToLeft | TextFormatFlags.Right
                : TextFormatFlags.Left;

            TextRenderer.DrawText(
                oEventArgs.Graphics,
                Text,
                Font,
                oTextBounds,
                oForeground,
                eAlignment |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine |
                TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix);
        }
    }
}