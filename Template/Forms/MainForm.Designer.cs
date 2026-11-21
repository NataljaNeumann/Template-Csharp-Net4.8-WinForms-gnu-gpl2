/*  Vokabel-Trainer aims to provide you a simple vocabulary training app
    Copyright (C) 2024 NataljaNeumann@gmx.de

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

namespace Template.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_lblShowLicense = new System.Windows.Forms.LinkLabel();
            this.m_lblShowAbout = new System.Windows.Forms.LinkLabel();
            this.m_btnShowDesktopKeyboard = new Template.Controls.ThemedButton();
            this.m_chkTest = new Template.Controls.ThemedCheckBox();
            this.m_btnOsLanguageAndKeyboardSettings = new Template.Controls.ThemedButton();
            this.SuspendLayout();
            // 
            // m_lblShowLicense
            // 
            resources.ApplyResources(this.m_lblShowLicense, "m_lblShowLicense");
            this.m_lblShowLicense.Name = "m_lblShowLicense";
            this.m_lblShowLicense.TabStop = true;
            this.m_lblShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnShowLicence_LinkClicked);
            // 
            // m_lblShowAbout
            // 
            resources.ApplyResources(this.m_lblShowAbout, "m_lblShowAbout");
            this.m_lblShowAbout.Name = "m_lblShowAbout";
            this.m_lblShowAbout.TabStop = true;
            this.m_lblShowAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnShowAbout_LinkClicked);
            // 
            // m_btnShowDesktopKeyboard
            // 
            this.m_btnShowDesktopKeyboard.DarkMode = false;
            resources.ApplyResources(this.m_btnShowDesktopKeyboard, "m_btnShowDesktopKeyboard");
            this.m_btnShowDesktopKeyboard.Name = "m_btnShowDesktopKeyboard";
            this.m_btnShowDesktopKeyboard.UseVisualStyleBackColor = true;
            this.m_btnShowDesktopKeyboard.Click += new System.EventHandler(this.OnShowDesktopKeyboard_Click);
            // 
            // m_chkTest
            // 
            this.m_chkTest.DarkMode = false;
            resources.ApplyResources(this.m_chkTest, "m_chkTest");
            this.m_chkTest.Name = "m_chkTest";
            this.m_chkTest.UseVisualStyleBackColor = true;
            // 
            // m_btnOsLanguageAndKeyboardSettings
            // 
            this.m_btnOsLanguageAndKeyboardSettings.DarkMode = false;
            this.m_btnOsLanguageAndKeyboardSettings.FlatAppearance.BorderSize = 0;
            this.m_btnOsLanguageAndKeyboardSettings.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.m_btnOsLanguageAndKeyboardSettings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.m_btnOsLanguageAndKeyboardSettings, "m_btnOsLanguageAndKeyboardSettings");
            this.m_btnOsLanguageAndKeyboardSettings.ForeColor = System.Drawing.Color.Blue;
            this.m_btnOsLanguageAndKeyboardSettings.Name = "m_btnOsLanguageAndKeyboardSettings";
            this.m_btnOsLanguageAndKeyboardSettings.UseVisualStyleBackColor = false;
            this.m_btnOsLanguageAndKeyboardSettings.Click += new System.EventHandler(this.OnOsLanguageAndKeyboardSettings_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnOsLanguageAndKeyboardSettings);
            this.Controls.Add(this.m_chkTest);
            this.Controls.Add(this.m_btnShowDesktopKeyboard);
            this.Controls.Add(this.m_lblShowAbout);
            this.Controls.Add(this.m_lblShowLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.OnHelpRequested);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VokabelTrainer_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel m_lblShowLicense;
        private System.Windows.Forms.LinkLabel m_lblShowAbout;
        private Template.Controls.ThemedButton m_btnShowDesktopKeyboard;
        private Template.Controls.ThemedCheckBox m_chkTest;
        private Template.Controls.ThemedButton m_btnOsLanguageAndKeyboardSettings;
    }
}

