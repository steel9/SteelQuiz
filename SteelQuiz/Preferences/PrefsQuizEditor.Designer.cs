﻿/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
    partial class PrefsQuizEditor
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
            this.pnl_closeBehaviour = new System.Windows.Forms.Panel();
            this.rdo_returnToDashboard = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_closeApp = new System.Windows.Forms.RadioButton();
            this.pnl_closeBehaviour.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_closeBehaviour
            // 
            this.pnl_closeBehaviour.Controls.Add(this.rdo_returnToDashboard);
            this.pnl_closeBehaviour.Controls.Add(this.label1);
            this.pnl_closeBehaviour.Controls.Add(this.rdo_closeApp);
            this.pnl_closeBehaviour.Location = new System.Drawing.Point(14, 14);
            this.pnl_closeBehaviour.Name = "pnl_closeBehaviour";
            this.pnl_closeBehaviour.Size = new System.Drawing.Size(635, 130);
            this.pnl_closeBehaviour.TabIndex = 2;
            // 
            // rdo_returnToDashboard
            // 
            this.rdo_returnToDashboard.AutoSize = true;
            this.rdo_returnToDashboard.Checked = true;
            this.rdo_returnToDashboard.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_returnToDashboard.ForeColor = System.Drawing.Color.White;
            this.rdo_returnToDashboard.Location = new System.Drawing.Point(15, 40);
            this.rdo_returnToDashboard.Name = "rdo_returnToDashboard";
            this.rdo_returnToDashboard.Size = new System.Drawing.Size(165, 24);
            this.rdo_returnToDashboard.TabIndex = 1;
            this.rdo_returnToDashboard.TabStop = true;
            this.rdo_returnToDashboard.Text = "Return to Dashboard";
            this.rdo_returnToDashboard.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Close Button Action";
            // 
            // rdo_closeApp
            // 
            this.rdo_closeApp.AutoSize = true;
            this.rdo_closeApp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_closeApp.ForeColor = System.Drawing.Color.White;
            this.rdo_closeApp.Location = new System.Drawing.Point(15, 70);
            this.rdo_closeApp.Name = "rdo_closeApp";
            this.rdo_closeApp.Size = new System.Drawing.Size(118, 24);
            this.rdo_closeApp.TabIndex = 0;
            this.rdo_closeApp.Text = "Exit SteelQuiz";
            this.rdo_closeApp.UseVisualStyleBackColor = true;
            this.rdo_closeApp.CheckedChanged += new System.EventHandler(this.Rdo_closeApp_CheckedChanged);
            // 
            // PrefsQuizEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.pnl_closeBehaviour);
            this.Name = "PrefsQuizEditor";
            this.Size = new System.Drawing.Size(652, 450);
            this.pnl_closeBehaviour.ResumeLayout(false);
            this.pnl_closeBehaviour.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_closeBehaviour;
        internal System.Windows.Forms.RadioButton rdo_returnToDashboard;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rdo_closeApp;
    }
}
