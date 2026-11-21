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

using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Template
{


    //*******************************************************************************************************
    /// <summary>
    /// Objects of this class provide theme for the controls
    /// </summary>
    //*******************************************************************************************************
    public static class ThemeManager
    {
        //===================================================================================================
        /// <summary>
        /// Sets window attribute
        /// </summary>
        /// <param name="hwndWindowHandle">The handle of the window to update.</param>
        /// <param name="nAttribute">The window attribute to update.</param>
        /// <param name="nValue">The value of the window attribute.</param>
        /// <param name="nSize">The size of the attribute value.</param>
        /// <returns>-1 in case of errors</returns>
        //===================================================================================================
        [DllImport("dwmapi.dll", ExactSpelling = true)]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwndWindowHandle,
            int nAttribute,
            ref int nValue,
            int nSize);


        //===================================================================================================
        /// <summary>
        /// Applies the requested dark-mode state to the form title bar.
        /// </summary>
        /// <param name="oForm">Form for applying title bar</param>
        /// <param name="bDark">Indicates, if dark mode</param>
        private static void ApplyTitleBar(
            Form oForm,
            bool bDark)
        {
            if (!oForm.IsHandleCreated)
            {
                return;
            }

            int nValue = bDark ? 1 : 0;


            int nResult = DwmSetWindowAttribute(
                oForm.Handle,
                20,
                ref nValue,
                sizeof(int));

            if (nResult < 0)
            {
                DwmSetWindowAttribute(
                    oForm.Handle,
                    19,
                    ref nValue,
                    sizeof(int));
            }

        }


        //===================================================================================================
        /// <summary>
        /// Attaches to a form
        /// </summary>
        /// <param name="oForm">Form to attach to</param>
        /// <exception cref="ArgumentNullException">If form is null</exception>
        //===================================================================================================
        public static void Attach(Form oForm)
        {

            if (oForm == null)
            {
                throw new ArgumentNullException(nameof(oForm));
            }

            // Bei Änderungen der Windows-Einstellungen neu anwenden.
            UserPreferenceChangedEventHandler dHandler = (oSender, oArgs) =>
            {
                if (oForm.IsDisposed || !oForm.IsHandleCreated)
                {
                    return;
                }

                try
                {
                    oForm.BeginInvoke((Action)(() =>
                    {
                        if (!oForm.IsDisposed)
                            Apply(oForm);
                    }));
                }
                catch (InvalidOperationException)
                {
                    // ignore
                }
            };

            /*
            SystemEvents.UserPreferenceChanged += dHandler;

            // Wichtig: statisches Ereignis wieder abmelden.
            oForm.Disposed += (oSender, oArgs) =>
            {
                SystemEvents.UserPreferenceChanged -= dHandler;
            };
            */

            oForm.HandleCreated += (oSender, oArgs) =>
            {
                Apply(oForm);
            };

            Apply(oForm);
        }

        //===================================================================================================
        /// <summary>
        /// Applies theme to the whole control tree
        /// </summary>
        /// <param name="ctlRoot">The root of the control tree</param>
        //===================================================================================================
        public static void Apply(Control ctlRoot)
        {
            // High-contrast themes take precedence over dark mode.
            bool bDark = !SystemInformation.HighContrast && ReadDarkMode();

            ApplyControl(ctlRoot, bDark);

            Form oForm = ctlRoot as Form;

            if (oForm != null)
            {
                ApplyTitleBar(oForm, bDark);
            }

            ctlRoot.Invalidate(true);
        }

        //===================================================================================================
        /// <summary>
        /// Reads whether application controls should use dark mode.
        /// </summary>
        /// <returns></returns>
        //===================================================================================================
        private static bool ReadDarkMode()
        {
            bool bDarkFromColor = SystemColors.ControlText.GetBrightness() >
                SystemColors.Control.GetBrightness();

            try
            {
                using (RegistryKey oKey = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    object oValue = oKey?.GetValue("AppsUseLightTheme");
                    return oValue is int && (int)oValue == 0;
                }
            }
            catch (SecurityException)
            {
                return bDarkFromColor;
            }
            catch (UnauthorizedAccessException)
            {
                return bDarkFromColor;
            }
            catch (IOException)
            {
                return false;
            }
        }

        //===================================================================================================
        /// <summary>
        /// Applies the theme to the control
        /// </summary>
        /// <param name="oControl"></param>
        /// <param name="bDark"></param>
        //===================================================================================================
        private static void ApplyControl(Control oControl, bool bDark)
        {
            // Only adapt colors, if in dark mode (works only once)
            if (!bDark)
                return;

            Color oBackground = bDark
                ? Color.FromArgb(20, 20, 20)
                : SystemColors.Control;

            Color oForeground = bDark
                ? Color.FromArgb(240, 240, 240)
                : SystemColors.ControlText;

            Color oInputBackground = bDark
                ? Color.FromArgb(45, 45, 45)
                : SystemColors.Window;

            Color oInputForeground = bDark
                ? Color.FromArgb(240, 240, 240)
                : SystemColors.WindowText;

            Color oDisabledForeground = Color.FromArgb(130, 130, 130);

            if (oControl.ForeColor.B > oControl.ForeColor.R * 2)
                oControl.BackColor = oControl.Parent?.BackColor ?? oBackground;
            else
                oControl.BackColor = oBackground;

            if (oControl.ForeColor.B > oControl.ForeColor.R * 2)
                oControl.ForeColor = Color.FromArgb(110, 180, 255);
            else
                oControl.ForeColor = oForeground;

            if (!oControl.Enabled && (oControl is CheckBox || oControl is Button))
                oControl.ForeColor = oDisabledForeground;

            if (oControl is Template.Controls.ThemedCheckBox oThemedCheckBox)
                oThemedCheckBox.DarkMode = bDark;

            Button btnButton = oControl as Button;

            if (
                oControl is TextBoxBase ||
                oControl is ComboBox ||
                oControl is ListBox ||
                oControl is UpDownBase)
            {
                oControl.BackColor = oInputBackground;
                oControl.ForeColor = oInputForeground;
            }

            if (btnButton != null)
            {
                if (bDark)
                {
                    btnButton.FlatStyle = FlatStyle.Flat;
                    btnButton.UseVisualStyleBackColor = false;

                    if (btnButton is Template.Controls.ThemedButton btnThemedButton)
                        btnThemedButton.DarkMode = true;

                    btnButton.ForeColor = btnButton.Enabled
                        ? oForeground
                        : oDisabledForeground;

                    if (oControl.ForeColor.B > oControl.ForeColor.R * 2)
                        btnButton.BackColor = oBackground;
                    else
                        btnButton.BackColor = oInputBackground;

                    btnButton.FlatAppearance.BorderColor =
                        Color.FromArgb(90, 90, 90);

                    if (btnButton.FlatAppearance.MouseOverBackColor == SystemColors.Control)
                        btnButton.FlatAppearance.MouseOverBackColor = oBackground;

                    if (btnButton.FlatAppearance.MouseDownBackColor == SystemColors.Control)
                        btnButton.FlatAppearance.MouseDownBackColor = oBackground;

                    btnButton.Invalidate();
                }
            }

            LinkLabel btnLink = oControl as LinkLabel;

            if (btnLink != null)
            {
                btnLink.LinkColor = bDark
                    ? Color.FromArgb(110, 180, 255)
                    : SystemColors.HotTrack;

                btnLink.ActiveLinkColor = bDark
                    ? Color.FromArgb(170, 210, 255)
                    : SystemColors.HotTrack;

                btnLink.VisitedLinkColor = bDark
                    ? Color.FromArgb(200, 160, 255)
                    : SystemColors.HotTrack;

                btnLink.DisabledLinkColor = bDark
                    ? Color.FromArgb(150, 150, 150)
                    : SystemColors.GrayText;
            }

            ComboBox ctlCombo = oControl as ComboBox;

            if (ctlCombo != null)
            {
                ctlCombo.BackColor = oInputBackground;
                ctlCombo.ForeColor = oInputForeground;

                if (ctlCombo.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    ctlCombo.DrawMode = DrawMode.OwnerDrawFixed;

                    // Avoid registering the same drawing handler more than once.
                    ctlCombo.DrawItem -= DrawComboBoxItem;
                    ctlCombo.DrawItem += DrawComboBoxItem;
                }

                ctlCombo.Invalidate();
            }

            foreach (Control ctlChild in oControl.Controls)
            {
                ApplyControl(ctlChild, bDark);
            }
        }

        /// <summary>
        /// Draws one owner-drawn combo-box item.
        /// </summary>
        /// <param name="oSender">The combo box that owns the item.</param>
        /// <param name="oEventArgs">The event data for the draw operation.</param>
        private static void DrawComboBoxItem(
            object oSender,
            DrawItemEventArgs oEventArgs)
        {
            ComboBox oCombo = (ComboBox)oSender;

            bool bSelected =
                (oEventArgs.State & DrawItemState.Selected) != 0;

            Color oBackground = bSelected
                ? SystemColors.Highlight
                : oCombo.BackColor;

            Color oForeground = !oCombo.Enabled
                ? SystemColors.GrayText
                : bSelected
                    ? SystemColors.HighlightText
                    : oCombo.ForeColor;

            using (SolidBrush oBrush = new SolidBrush(oBackground))
            {
                oEventArgs.Graphics.FillRectangle(oBrush, oEventArgs.Bounds);
            }

            string strText = oEventArgs.Index >= 0
                ? oCombo.GetItemText(oCombo.Items[oEventArgs.Index])
                : oCombo.Text;

            Rectangle oBounds = oEventArgs.Bounds;
            oBounds.Inflate(-2, 0);

            TextFormatFlags eFlags =
                TextFormatFlags.Left |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.SingleLine |
                TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix;

            if (oCombo.RightToLeft == RightToLeft.Yes)
            {
                eFlags |= TextFormatFlags.RightToLeft |
                          TextFormatFlags.Right;
            }

            TextRenderer.DrawText(
                oEventArgs.Graphics,
                strText,
                oEventArgs.Font ?? oCombo.Font,
                oBounds,
                oForeground,
                eFlags);

            oEventArgs.DrawFocusRectangle();
        }
    }

}
