// Template v0.0
// Copyright (C) 2026 NataljaNeumann@gmx.de
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Template.Forms;
using Template.Properties;


namespace Template.Forms
{
    //*******************************************************************************************************
    /// <summary>
    /// Main form of the application
    /// </summary>
    //*******************************************************************************************************
    public partial class MainForm : Form
    {
        //===================================================================================================
        /// <summary>
        /// A random number generator for choosing words 
        /// </summary>
        Random m_oRnd;

        //===================================================================================================
        /// <summary>
        /// Constructs a new vocabulary trainer object
        /// </summary>
        //===================================================================================================
        public MainForm()
        {
            InitializeComponent();

            // init random with current time
            m_oRnd = new Random((((DateTime.UtcNow.Hour * 60 + DateTime.UtcNow.Minute) * 60 +
                DateTime.UtcNow.Second) * 1000 + DateTime.UtcNow.Millisecond) * 365 + DateTime.UtcNow.DayOfYear);

            // If there is no special header, then use default
            ReadyToUseImageInjection("Images" + Path.DirectorySeparatorChar + "Header.jpg");

            ThemeManager.Attach(this);
        }



        //===================================================================================================
        /// <summary>
        /// This is executed when user wants to see the licence
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oArgs">Event args</param>
        //===================================================================================================
        private void OnShowLicence_LinkClicked(
            object oSender,
            LinkLabelLinkClickedEventArgs oArgs
            )
        {
            System.Diagnostics.Process.Start(System.IO.Path.Combine(Application.StartupPath, "Licence.html"));
        }

        //===================================================================================================
        /// <summary>
        /// This is executed when user wants to see information about the application
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oArgs">Event args</param>
        //===================================================================================================
        private void OnShowAbout_LinkClicked(
            object oSender,
            LinkLabelLinkClickedEventArgs oArgs
            )
        {
            using (About oAboutForm = new About())
            {
                oAboutForm.ShowDialog(this);
            }
        }

        //===================================================================================================
        /// <summary>
        /// This is executed when user wants to show the desktop keyboard
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oArgs">Event args</param>
        //===================================================================================================
        private void OnShowDesktopKeyboard_Click(
            object oSender,
            EventArgs oArgs
            )
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        //===================================================================================================
        /// <summary>
        /// This is called when user moves mouse, in order to improve random numbers
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oArgs">Event args</param>
        //===================================================================================================
        private void VokabelTrainer_MouseMove(
            object oSender,
            MouseEventArgs oArgs
            )
        {
            unchecked
            {
                // make randoms less deterministic, whenever possible
                if (m_oRnd != null)
                {
                    m_oRnd = new Random(m_oRnd.Next() + ((DateTime.UtcNow.Hour * 60 + DateTime.UtcNow.Minute) * 60 +
                        DateTime.UtcNow.Second) * 1000 + DateTime.UtcNow.Millisecond + (oArgs.X & 15) * 256);
                    m_oRnd.Next();
                    m_oRnd.Next();
                    m_oRnd.Next();
                    m_oRnd.Next();
                }
            }
        }


        //===================================================================================================
        /// <summary>
        /// Shows OS keyboard and language settings (is called when gear is clicked)
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oRags">Event args</param>
        //===================================================================================================
        private void OnOsLanguageAndKeyboardSettings_Click(
            object oSender,
            EventArgs oArgs
            )
        {
            string strWindowsVersion = Environment.OSVersion.Version.ToString();

            try
            {
                if (strWindowsVersion.StartsWith("10.") || strWindowsVersion.StartsWith("11."))
                {
                    // Windows 10 and 11
                    Process.Start(new ProcessStartInfo("cmd", "/c start ms-settings:regionlanguage") 
                    { 
                        CreateNoWindow = true 
                    });
                }
                else 
                if (strWindowsVersion.StartsWith("6.3"))
                {
                    // Windows 8.1
                    Process.Start("control.exe", "/name Microsoft.Language");
                }
                else if (strWindowsVersion.StartsWith("6.2"))
                {
                    // Windows 8
                    Process.Start("control.exe", "/name Microsoft.Language");
                }
                else if (strWindowsVersion.StartsWith("6.1"))
                {
                    // Windows 7
                    Process.Start("control.exe", "/name Microsoft.RegionAndLanguage");
                }
            }
            catch (Exception oEx)
            {
                NewMessageBox.Show(this, oEx.Message, this.Text, "", true, false, false, "Error");
            }
        }

        //===================================================================================================
        /// <summary>
        /// This is execute when user presses F1 key
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oEventArgs">Even args</param>
        //===================================================================================================
        private void OnHelpRequested(
            object oSender,
            HelpEventArgs oEventArgs
            )
        {
            System.Diagnostics.Process.Start(System.IO.Path.Combine(Application.StartupPath, "Readme.html"));
        }


        #region image injection part
        //===================================================================================================
        /// <summary>
        /// Picture box control
        /// </summary>
        private PictureBox m_ctlPictureBox;
        //===================================================================================================
        /// <summary>
        /// Image
        /// </summary>
        private System.Drawing.Image m_oLoadedImage;
        //===================================================================================================
        /// <summary>
        /// A dictionary with positions of other elements
        /// </summary>
        private Dictionary<Control, int> m_oOriginalPositions;
        //===================================================================================================
        /// <summary>
        /// Tooltip for celebrations
        /// </summary>
        private ToolTip m_oToolTip;
        //===================================================================================================
        /// <summary>
        /// Url to call when image is clicked
        /// </summary>
        private string m_strUrlForImage;

        //===================================================================================================
        /// <summary>
        /// Loads an image from application startup path and shows it at the top of the window
        /// </summary>
        /// <param name="strName">Name of the image, without directory specifications</param>
        //===================================================================================================
        private bool ReadyToUseImageInjection(string strImageName)
        {
            string strImagePath = System.IO.Path.Combine(Application.StartupPath, strImageName);
            // if there is a dark theme, then test, if there is a dark image variant
            if (ForeColor.GetBrightness() > BackColor.GetBrightness())
            {
                string strDarkImagePath =
                    strImagePath.Substring(0, strImagePath.LastIndexOf(".")) + "Dark" +
                    strImagePath.Substring(strImagePath.LastIndexOf("."));
                if (System.IO.File.Exists(strDarkImagePath))
                    strImagePath = strDarkImagePath;
            }
            if (System.IO.File.Exists(strImagePath))
            {
                m_oOriginalPositions = new Dictionary<Control, int>();
                foreach (Control ctl in Controls)
                {
                    m_oOriginalPositions[ctl] = ctl.Top;
                }

                m_ctlPictureBox = new PictureBox();
                m_ctlPictureBox.Location = this.ClientRectangle.Location;
                m_ctlPictureBox.Size = new Size(0, 0);
                Controls.Add(m_ctlPictureBox);

                LoadAndResizeImage(strImagePath);

                this.Resize += new EventHandler(ResizeImageAlongWithForm);
                return true;
            }
            else
            {
                return false;
            }
        }

        //===================================================================================================
        /// <summary>
        /// Resizes image along with the form
        /// </summary>
        /// <param name="oSender">Sender object</param>
        /// <param name="oEventArgs">Event args</param>
        //===================================================================================================
        private void ResizeImageAlongWithForm(object oSender, EventArgs oEventArgs)
        {
            ResizeImageAndShiftElements();
        }

        //===================================================================================================
        /// <summary>
        /// Loads an image and resizes it to the width of client area
        /// </summary>
        /// <param name="strImagePath"></param>
        //===================================================================================================
        private void LoadAndResizeImage(string strImagePath)
        {
            m_oLoadedImage = Image.FromFile(strImagePath);
            ResizeImageAndShiftElements();
        }

        //===================================================================================================
        /// <summary>
        /// Resizes image and shifts other elements
        /// </summary>
        //===================================================================================================
        private void ResizeImageAndShiftElements()
        {
            if (m_oLoadedImage != null)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    float fAspectRatio = (float)m_oLoadedImage.Width / (float)m_oLoadedImage.Height;

                    int nNewWidth = this.ClientSize.Width;
                    if (nNewWidth != 0)
                    {
                        int nNewHeight = (int)(nNewWidth / fAspectRatio);

                        int nHeightChange = nNewHeight - m_ctlPictureBox.Height;

                        this.m_ctlPictureBox.Image = new Bitmap(m_oLoadedImage, nNewWidth, nNewHeight);
                        this.m_ctlPictureBox.Size = new Size(nNewWidth, nNewHeight);

                        ShiftOtherElementsUpOrDown(nHeightChange);
                        this.Height += nHeightChange;
                    }
                }
            }
        }

        //===================================================================================================
        /// <summary>
        /// Shifts elements, apart from the image box up or down
        /// </summary>
        /// <param name="nHeightChange"></param>
        //===================================================================================================
        private void ShiftOtherElementsUpOrDown(int nHeightChange)
        {
            foreach (Control ctl in m_oOriginalPositions.Keys)
            {
                if ((ctl.Anchor & AnchorStyles.Bottom) == AnchorStyles.None)
                    ctl.Top += nHeightChange;
            }
        }
        #endregion


    }
}
