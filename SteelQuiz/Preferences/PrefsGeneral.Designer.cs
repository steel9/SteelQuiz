﻿/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace SteelQuiz.Preferences
{
    partial class PrefsGeneral
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_rdoTheme = new System.Windows.Forms.Panel();
            this.rdo_themeDark = new System.Windows.Forms.RadioButton();
            this.rdo_themeLight = new System.Windows.Forms.RadioButton();
            this.pnl_rdoTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Theme:";
            // 
            // pnl_rdoTheme
            // 
            this.pnl_rdoTheme.Controls.Add(this.rdo_themeDark);
            this.pnl_rdoTheme.Controls.Add(this.label1);
            this.pnl_rdoTheme.Controls.Add(this.rdo_themeLight);
            this.pnl_rdoTheme.Location = new System.Drawing.Point(14, 14);
            this.pnl_rdoTheme.Name = "pnl_rdoTheme";
            this.pnl_rdoTheme.Size = new System.Drawing.Size(188, 130);
            this.pnl_rdoTheme.TabIndex = 1;
            // 
            // rdo_themeDark
            // 
            this.rdo_themeDark.AutoSize = true;
            this.rdo_themeDark.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeDark.ForeColor = System.Drawing.Color.White;
            this.rdo_themeDark.Location = new System.Drawing.Point(3, 66);
            this.rdo_themeDark.Name = "rdo_themeDark";
            this.rdo_themeDark.Size = new System.Drawing.Size(58, 24);
            this.rdo_themeDark.TabIndex = 1;
            this.rdo_themeDark.Text = "Dark";
            this.rdo_themeDark.UseVisualStyleBackColor = true;
            this.rdo_themeDark.CheckedChanged += new System.EventHandler(this.Rdo_theme_CheckedChanged);
            // 
            // rdo_themeLight
            // 
            this.rdo_themeLight.AutoSize = true;
            this.rdo_themeLight.Checked = true;
            this.rdo_themeLight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_themeLight.ForeColor = System.Drawing.Color.White;
            this.rdo_themeLight.Location = new System.Drawing.Point(3, 36);
            this.rdo_themeLight.Name = "rdo_themeLight";
            this.rdo_themeLight.Size = new System.Drawing.Size(60, 24);
            this.rdo_themeLight.TabIndex = 0;
            this.rdo_themeLight.TabStop = true;
            this.rdo_themeLight.Text = "Light";
            this.rdo_themeLight.UseVisualStyleBackColor = true;
            this.rdo_themeLight.CheckedChanged += new System.EventHandler(this.Rdo_theme_CheckedChanged);
            // 
            // PrefsGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_rdoTheme);
            this.Name = "PrefsGeneral";
            this.Size = new System.Drawing.Size(652, 409);
            this.pnl_rdoTheme.ResumeLayout(false);
            this.pnl_rdoTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_rdoTheme;
        internal System.Windows.Forms.RadioButton rdo_themeLight;
        internal System.Windows.Forms.RadioButton rdo_themeDark;
    }
}
