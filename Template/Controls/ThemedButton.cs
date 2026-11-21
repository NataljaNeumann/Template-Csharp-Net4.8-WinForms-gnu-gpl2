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

            eFlags |= eAlignment switch
            {
                ContentAlignment.TopLeft => TextFormatFlags.Left |
                                            TextFormatFlags.Top,
                ContentAlignment.TopCenter => TextFormatFlags.HorizontalCenter |
                                              TextFormatFlags.Top,
                ContentAlignment.TopRight => TextFormatFlags.Right |
                                             TextFormatFlags.Top,
                ContentAlignment.MiddleLeft => TextFormatFlags.Left |
                                               TextFormatFlags.VerticalCenter,
                ContentAlignment.MiddleCenter => TextFormatFlags.HorizontalCenter |
                                                  TextFormatFlags.VerticalCenter,
                ContentAlignment.MiddleRight => TextFormatFlags.Right |
                                                TextFormatFlags.VerticalCenter,
                ContentAlignment.BottomLeft => TextFormatFlags.Left |
                                               TextFormatFlags.Bottom,
                ContentAlignment.BottomCenter => TextFormatFlags.HorizontalCenter |
                                                  TextFormatFlags.Bottom,
                ContentAlignment.BottomRight => TextFormatFlags.Right |
                                                TextFormatFlags.Bottom,
                _ => TextFormatFlags.HorizontalCenter |
                     TextFormatFlags.VerticalCenter
            };

            return eFlags;
        }
    }
}