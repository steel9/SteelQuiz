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

namespace SteelQuiz
{
    partial class Welcome
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_addQuiz = new System.Windows.Forms.Button();
            this.ofd_loadQuiz = new System.Windows.Forms.OpenFileDialog();
            this.lbl_copyright = new System.Windows.Forms.Label();
            this.tmr_chkUpdate = new System.Windows.Forms.Timer(this.components);
            this.btn_chkUpdates = new System.Windows.Forms.Button();
            this.btn_preferences = new System.Windows.Forms.Button();
            this.tmr_welcomeMsg = new System.Windows.Forms.Timer(this.components);
            this.flp_lastQuizzes = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_addQuizFromFile = new System.Windows.Forms.Button();
            this.btn_createQuiz = new System.Windows.Forms.Button();
            this.btn_importQuiz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_welcome.Location = new System.Drawing.Point(202, 9);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(586, 43);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Welcome back!";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_addQuiz
            // 
            this.btn_addQuiz.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_addQuiz.FlatAppearance.BorderSize = 0;
            this.btn_addQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addQuiz.Location = new System.Drawing.Point(12, 407);
            this.btn_addQuiz.Name = "btn_addQuiz";
            this.btn_addQuiz.Size = new System.Drawing.Size(184, 31);
            this.btn_addQuiz.TabIndex = 1;
            this.btn_addQuiz.Text = "+";
            this.btn_addQuiz.UseVisualStyleBackColor = false;
            this.btn_addQuiz.Click += new System.EventHandler(this.Btn_addQuiz_Click);
            // 
            // ofd_loadQuiz
            // 
            this.ofd_loadQuiz.Filter = "SteelQuiz Quizzes|*.steelquiz";
            this.ofd_loadQuiz.Title = "Select a quiz to load";
            // 
            // lbl_copyright
            // 
            this.lbl_copyright.AutoSize = true;
            this.lbl_copyright.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_copyright.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_copyright.Location = new System.Drawing.Point(206, 420);
            this.lbl_copyright.Name = "lbl_copyright";
            this.lbl_copyright.Size = new System.Drawing.Size(263, 13);
            this.lbl_copyright.TabIndex = 4;
            this.lbl_copyright.Text = "Copyright (C) 2019 Steel9Apps - All rights reserved";
            // 
            // tmr_chkUpdate
            // 
            this.tmr_chkUpdate.Enabled = true;
            this.tmr_chkUpdate.Interval = 120000;
            this.tmr_chkUpdate.Tick += new System.EventHandler(this.Tmr_chkUpdate_Tick);
            // 
            // btn_chkUpdates
            // 
            this.btn_chkUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_chkUpdates.FlatAppearance.BorderSize = 0;
            this.btn_chkUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chkUpdates.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chkUpdates.ForeColor = System.Drawing.Color.White;
            this.btn_chkUpdates.Location = new System.Drawing.Point(546, 415);
            this.btn_chkUpdates.Name = "btn_chkUpdates";
            this.btn_chkUpdates.Size = new System.Drawing.Size(118, 23);
            this.btn_chkUpdates.TabIndex = 6;
            this.btn_chkUpdates.Text = "Check for updates";
            this.btn_chkUpdates.UseVisualStyleBackColor = false;
            this.btn_chkUpdates.Click += new System.EventHandler(this.Btn_chkUpdates_Click);
            // 
            // btn_preferences
            // 
            this.btn_preferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_preferences.FlatAppearance.BorderSize = 0;
            this.btn_preferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_preferences.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_preferences.ForeColor = System.Drawing.Color.White;
            this.btn_preferences.Location = new System.Drawing.Point(670, 415);
            this.btn_preferences.Name = "btn_preferences";
            this.btn_preferences.Size = new System.Drawing.Size(118, 23);
            this.btn_preferences.TabIndex = 7;
            this.btn_preferences.Text = "Preferences";
            this.btn_preferences.UseVisualStyleBackColor = false;
            this.btn_preferences.Click += new System.EventHandler(this.Btn_preferences_Click);
            // 
            // tmr_welcomeMsg
            // 
            this.tmr_welcomeMsg.Enabled = true;
            this.tmr_welcomeMsg.Interval = 10000;
            this.tmr_welcomeMsg.Tick += new System.EventHandler(this.Tmr_welcomeMsg_Tick);
            // 
            // flp_lastQuizzes
            // 
            this.flp_lastQuizzes.AutoScroll = true;
            this.flp_lastQuizzes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_lastQuizzes.Location = new System.Drawing.Point(12, 12);
            this.flp_lastQuizzes.MaximumSize = new System.Drawing.Size(184, 0);
            this.flp_lastQuizzes.MinimumSize = new System.Drawing.Size(184, 389);
            this.flp_lastQuizzes.Name = "flp_lastQuizzes";
            this.flp_lastQuizzes.Size = new System.Drawing.Size(184, 389);
            this.flp_lastQuizzes.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(202, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 354);
            this.panel1.TabIndex = 9;
            // 
            // btn_addQuizFromFile
            // 
            this.btn_addQuizFromFile.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_addQuizFromFile.FlatAppearance.BorderSize = 0;
            this.btn_addQuizFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addQuizFromFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addQuizFromFile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addQuizFromFile.Location = new System.Drawing.Point(12, 333);
            this.btn_addQuizFromFile.Name = "btn_addQuizFromFile";
            this.btn_addQuizFromFile.Size = new System.Drawing.Size(184, 31);
            this.btn_addQuizFromFile.TabIndex = 10;
            this.btn_addQuizFromFile.Text = "Add Quiz from File";
            this.btn_addQuizFromFile.UseVisualStyleBackColor = false;
            this.btn_addQuizFromFile.Visible = false;
            this.btn_addQuizFromFile.Click += new System.EventHandler(this.btn_loadQuiz_Click);
            // 
            // btn_createQuiz
            // 
            this.btn_createQuiz.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_createQuiz.FlatAppearance.BorderSize = 0;
            this.btn_createQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_createQuiz.Location = new System.Drawing.Point(12, 370);
            this.btn_createQuiz.Name = "btn_createQuiz";
            this.btn_createQuiz.Size = new System.Drawing.Size(184, 31);
            this.btn_createQuiz.TabIndex = 11;
            this.btn_createQuiz.Text = "Create Quiz";
            this.btn_createQuiz.UseVisualStyleBackColor = false;
            this.btn_createQuiz.Visible = false;
            this.btn_createQuiz.Click += new System.EventHandler(this.btn_createQuiz_Click);
            // 
            // btn_importQuiz
            // 
            this.btn_importQuiz.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_importQuiz.FlatAppearance.BorderSize = 0;
            this.btn_importQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_importQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_importQuiz.Location = new System.Drawing.Point(12, 296);
            this.btn_importQuiz.Name = "btn_importQuiz";
            this.btn_importQuiz.Size = new System.Drawing.Size(184, 31);
            this.btn_importQuiz.TabIndex = 12;
            this.btn_importQuiz.Text = "Import Quiz from Internet";
            this.btn_importQuiz.UseVisualStyleBackColor = false;
            this.btn_importQuiz.Visible = false;
            this.btn_importQuiz.Click += new System.EventHandler(this.btn_importQuizFromSite_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_importQuiz);
            this.Controls.Add(this.btn_createQuiz);
            this.Controls.Add(this.btn_addQuizFromFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flp_lastQuizzes);
            this.Controls.Add(this.btn_preferences);
            this.Controls.Add(this.btn_chkUpdates);
            this.Controls.Add(this.lbl_copyright);
            this.Controls.Add(this.btn_addQuiz);
            this.Controls.Add(this.lbl_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.Shown += new System.EventHandler(this.Welcome_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_addQuiz;
        private System.Windows.Forms.OpenFileDialog ofd_loadQuiz;
        private System.Windows.Forms.Label lbl_copyright;
        private System.Windows.Forms.Button btn_chkUpdates;
        private System.Windows.Forms.Button btn_preferences;
        internal System.Windows.Forms.Timer tmr_chkUpdate;
        private System.Windows.Forms.Timer tmr_welcomeMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addQuizFromFile;
        private System.Windows.Forms.Button btn_createQuiz;
        private System.Windows.Forms.Button btn_importQuiz;
        private System.Windows.Forms.FlowLayoutPanel flp_lastQuizzes;
    }
}

