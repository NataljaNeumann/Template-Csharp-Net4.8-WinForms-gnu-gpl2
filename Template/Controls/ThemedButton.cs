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
    /// Provides a button that paints its foreground consistently in light and dark mode.
    /// </summary>
    //*******************************************************************************************************
    public class ThemedButton : Button
    {
        //===================================================================================================
        /// <summary>
        /// Gets or sets a value indicating whether dark-mode painting is enabled.
        /// </summary>
        public bool DarkMode { get; set; }

        //===================================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemedButton"/> class.
        /// </summary>
        //===================================================================================================
        public ThemedButton()
        {
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,
                true);
            UseVisualStyleBackColor = false;
        }

        //===================================================================================================
        /// <summary>
        /// Paints the button using one layout for enabled and disabled states.
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

            if (FlatAppearance.BorderSize > 0)
            {
                using (Pen oBorder = new Pen(
                    FlatAppearance.BorderColor,
                    FlatAppearance.BorderSize))
                {
                    Rectangle oBorderBounds = ClientRectangle;
                    oBorderBounds.Width--;
                    oBorderBounds.Height--;
                    oEventArgs.Graphics.DrawRectangle(oBorder, oBorderBounds);
                }
            }

            Rectangle oTextBounds = ClientRectangle;
            oTextBounds.Inflate(-Padding.Horizontal, -Padding.Vertical);

            Color oTextColor = Enabled
                ? Color.FromArgb(240, 240, 240)
                : Color.FromArgb(130, 130, 130);

            TextRenderer.DrawText(
                oEventArgs.Graphics,
                Text,
                Font,
                oTextBounds,
                oTextColor,
                GetButtonTextFormatFlags(TextAlign));
        }

        //===================================================================================================
        /// <summary>
        /// Gets text-formatting flags for the specified button alignment.
        /// </summary>
        /// <param name="eAlignment">The alignment of the button text.</param>
        /// <returns>The text-formatting flags for the alignment.</returns>
        //===================================================================================================
        private static TextFormatFlags GetButtonTextFormatFlags(
            ContentAlignment eAlignment
            )
        {
            TextFormatFlags eFlags = TextFormatFlags.EndEllipsis |
                                      TextFormatFlags.SingleLine |
                                      TextFormatFlags.NoPrefix;

            switch (eAlignment)
            {
                case ContentAlignment.TopLeft:
                    eFlags |= TextFormatFlags.Left |
                              TextFormatFlags.Top;
                    break;

                case ContentAlignment.TopCenter:
                    eFlags |= TextFormatFlags.HorizontalCenter |
                              TextFormatFlags.Top;
                    break;

                case ContentAlignment.TopRight:
                    eFlags |= TextFormatFlags.Right |
                              TextFormatFlags.Top;
                    break;

                case ContentAlignment.MiddleLeft:
                    eFlags |= TextFormatFlags.Left |
                              TextFormatFlags.VerticalCenter;
                    break;

                case ContentAlignment.MiddleCenter:
                    eFlags |= TextFormatFlags.HorizontalCenter |
                              TextFormatFlags.VerticalCenter;
                    break;

                case ContentAlignment.MiddleRight:
                    eFlags |= TextFormatFlags.Right |
                              TextFormatFlags.VerticalCenter;
                    break;

                case ContentAlignment.BottomLeft:
                    eFlags |= TextFormatFlags.Left |
                              TextFormatFlags.Bottom;
                    break;

                case ContentAlignment.BottomCenter:
                    eFlags |= TextFormatFlags.HorizontalCenter |
                              TextFormatFlags.Bottom;
                    break;

                case ContentAlignment.BottomRight:
                    eFlags |= TextFormatFlags.Right |
                              TextFormatFlags.Bottom;
                    break;

                default:
                    eFlags |= TextFormatFlags.HorizontalCenter |
                              TextFormatFlags.VerticalCenter;
                    break;
            }

            return eFlags;
        }
    }
}