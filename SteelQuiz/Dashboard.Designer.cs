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

namespace SteelQuiz
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.btn_addQuiz = new System.Windows.Forms.Button();
            this.ofd_loadQuiz = new System.Windows.Forms.OpenFileDialog();
            this.tmr_chkUpdate = new System.Windows.Forms.Timer(this.components);
            this.btn_preferences = new System.Windows.Forms.Button();
            this.tmr_welcomeMsg = new System.Windows.Forms.Timer(this.components);
            this.flp_lastQuizzes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_quizOverview = new System.Windows.Forms.Panel();
            this.pnl_welcome = new System.Windows.Forms.Panel();
            this.pnl_welcomeText = new System.Windows.Forms.Panel();
            this.lbl_toBegin = new System.Windows.Forms.Label();
            this.btn_loadQuizFromFile = new System.Windows.Forms.Button();
            this.btn_createQuiz = new System.Windows.Forms.Button();
            this.btn_importQuiz = new System.Windows.Forms.Button();
            this.lbl_recentQuizzes = new System.Windows.Forms.Label();
            this.cms_recentQuizzes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearRecentQuizzesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.pnl_quizOverview.SuspendLayout();
            this.pnl_welcome.SuspendLayout();
            this.pnl_welcomeText.SuspendLayout();
            this.cms_recentQuizzes.SuspendLayout();
            this.pnl_left.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_welcome.Location = new System.Drawing.Point(3, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(370, 79);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Welcome back!";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btn_addQuiz
            // 
            this.btn_addQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_addQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_addQuiz.FlatAppearance.BorderSize = 0;
            this.btn_addQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addQuiz.Location = new System.Drawing.Point(10, 539);
            this.btn_addQuiz.Name = "btn_addQuiz";
            this.btn_addQuiz.Size = new System.Drawing.Size(173, 45);
            this.btn_addQuiz.TabIndex = 1;
            this.btn_addQuiz.Text = "▲";
            this.btn_addQuiz.UseVisualStyleBackColor = false;
            this.btn_addQuiz.Click += new System.EventHandler(this.Btn_addQuiz_Click);
            // 
            // ofd_loadQuiz
            // 
            this.ofd_loadQuiz.Filter = "SteelQuiz Quizzes|*.steelquiz";
            this.ofd_loadQuiz.Title = "Select a quiz to load";
            // 
            // tmr_chkUpdate
            // 
            this.tmr_chkUpdate.Enabled = true;
            this.tmr_chkUpdate.Interval = 120000;
            this.tmr_chkUpdate.Tick += new System.EventHandler(this.Tmr_chkUpdate_Tick);
            // 
            // btn_preferences
            // 
            this.btn_preferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_preferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btn_preferences.FlatAppearance.BorderSize = 0;
            this.btn_preferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_preferences.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_preferences.ForeColor = System.Drawing.Color.White;
            this.btn_preferences.Location = new System.Drawing.Point(10, 375);
            this.btn_preferences.Name = "btn_preferences";
            this.btn_preferences.Size = new System.Drawing.Size(173, 31);
            this.btn_preferences.TabIndex = 7;
            this.btn_preferences.Text = "Preferences";
            this.btn_preferences.UseVisualStyleBackColor = false;
            this.btn_preferences.Visible = false;
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
            this.flp_lastQuizzes.Location = new System.Drawing.Point(0, 55);
            this.flp_lastQuizzes.MaximumSize = new System.Drawing.Size(196, 0);
            this.flp_lastQuizzes.MinimumSize = new System.Drawing.Size(196, 477);
            this.flp_lastQuizzes.Name = "flp_lastQuizzes";
            this.flp_lastQuizzes.Size = new System.Drawing.Size(196, 477);
            this.flp_lastQuizzes.TabIndex = 8;
            // 
            // pnl_quizOverview
            // 
            this.pnl_quizOverview.Controls.Add(this.pnl_welcome);
            this.pnl_quizOverview.Location = new System.Drawing.Point(202, 12);
            this.pnl_quizOverview.Name = "pnl_quizOverview";
            this.pnl_quizOverview.Size = new System.Drawing.Size(730, 572);
            this.pnl_quizOverview.TabIndex = 9;
            // 
            // pnl_welcome
            // 
            this.pnl_welcome.Controls.Add(this.pnl_welcomeText);
            this.pnl_welcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_welcome.Location = new System.Drawing.Point(0, 0);
            this.pnl_welcome.Name = "pnl_welcome";
            this.pnl_welcome.Size = new System.Drawing.Size(730, 572);
            this.pnl_welcome.TabIndex = 1;
            // 
            // pnl_welcomeText
            // 
            this.pnl_welcomeText.Controls.Add(this.lbl_welcome);
            this.pnl_welcomeText.Controls.Add(this.lbl_toBegin);
            this.pnl_welcomeText.Location = new System.Drawing.Point(179, 162);
            this.pnl_welcomeText.Name = "pnl_welcomeText";
            this.pnl_welcomeText.Size = new System.Drawing.Size(373, 249);
            this.pnl_welcomeText.TabIndex = 2;
            // 
            // lbl_toBegin
            // 
            this.lbl_toBegin.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_toBegin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_toBegin.Location = new System.Drawing.Point(0, 116);
            this.lbl_toBegin.Name = "lbl_toBegin";
            this.lbl_toBegin.Size = new System.Drawing.Size(373, 133);
            this.lbl_toBegin.TabIndex = 1;
            this.lbl_toBegin.Text = "Select a quiz in the Recent Quizzes list, or add one by clicking the triangle arr" +
    "ow button in the bottom left corner.";
            this.lbl_toBegin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_loadQuizFromFile
            // 
            this.btn_loadQuizFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_loadQuizFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_loadQuizFromFile.FlatAppearance.BorderSize = 0;
            this.btn_loadQuizFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadQuizFromFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadQuizFromFile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_loadQuizFromFile.Location = new System.Drawing.Point(10, 464);
            this.btn_loadQuizFromFile.Name = "btn_loadQuizFromFile";
            this.btn_loadQuizFromFile.Size = new System.Drawing.Size(173, 31);
            this.btn_loadQuizFromFile.TabIndex = 10;
            this.btn_loadQuizFromFile.Text = "Load Quiz";
            this.btn_loadQuizFromFile.UseVisualStyleBackColor = false;
            this.btn_loadQuizFromFile.Visible = false;
            this.btn_loadQuizFromFile.Click += new System.EventHandler(this.btn_loadQuiz_Click);
            // 
            // btn_createQuiz
            // 
            this.btn_createQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_createQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_createQuiz.FlatAppearance.BorderSize = 0;
            this.btn_createQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_createQuiz.Location = new System.Drawing.Point(10, 501);
            this.btn_createQuiz.Name = "btn_createQuiz";
            this.btn_createQuiz.Size = new System.Drawing.Size(173, 31);
            this.btn_createQuiz.TabIndex = 11;
            this.btn_createQuiz.Text = "Create Quiz";
            this.btn_createQuiz.UseVisualStyleBackColor = false;
            this.btn_createQuiz.Visible = false;
            this.btn_createQuiz.Click += new System.EventHandler(this.btn_createQuiz_Click);
            // 
            // btn_importQuiz
            // 
            this.btn_importQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_importQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btn_importQuiz.FlatAppearance.BorderSize = 0;
            this.btn_importQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importQuiz.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_importQuiz.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_importQuiz.Location = new System.Drawing.Point(10, 427);
            this.btn_importQuiz.Name = "btn_importQuiz";
            this.btn_importQuiz.Size = new System.Drawing.Size(173, 31);
            this.btn_importQuiz.TabIndex = 12;
            this.btn_importQuiz.Text = "Import Quiz";
            this.btn_importQuiz.UseVisualStyleBackColor = false;
            this.btn_importQuiz.Visible = false;
            this.btn_importQuiz.Click += new System.EventHandler(this.btn_importQuizFromSite_Click);
            // 
            // lbl_recentQuizzes
            // 
            this.lbl_recentQuizzes.ContextMenuStrip = this.cms_recentQuizzes;
            this.lbl_recentQuizzes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recentQuizzes.Location = new System.Drawing.Point(6, 9);
            this.lbl_recentQuizzes.Name = "lbl_recentQuizzes";
            this.lbl_recentQuizzes.Size = new System.Drawing.Size(170, 43);
            this.lbl_recentQuizzes.TabIndex = 13;
            this.lbl_recentQuizzes.Text = "Recent";
            this.lbl_recentQuizzes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cms_recentQuizzes
            // 
            this.cms_recentQuizzes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearRecentQuizzesListToolStripMenuItem});
            this.cms_recentQuizzes.Name = "cms_recentQuizzes";
            this.cms_recentQuizzes.Size = new System.Drawing.Size(205, 26);
            // 
            // clearRecentQuizzesListToolStripMenuItem
            // 
            this.clearRecentQuizzesListToolStripMenuItem.Name = "clearRecentQuizzesListToolStripMenuItem";
            this.clearRecentQuizzesListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.clearRecentQuizzesListToolStripMenuItem.Text = "Clear Recent Quizzes List";
            this.clearRecentQuizzesListToolStripMenuItem.Click += new System.EventHandler(this.clearRecentQuizzesListToolStripMenuItem_Click);
            // 
            // pnl_left
            // 
            this.pnl_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnl_left.ContextMenuStrip = this.cms_recentQuizzes;
            this.pnl_left.Controls.Add(this.lbl_recentQuizzes);
            this.pnl_left.Controls.Add(this.btn_importQuiz);
            this.pnl_left.Controls.Add(this.btn_createQuiz);
            this.pnl_left.Controls.Add(this.btn_loadQuizFromFile);
            this.pnl_left.Controls.Add(this.btn_preferences);
            this.pnl_left.Controls.Add(this.btn_addQuiz);
            this.pnl_left.Controls.Add(this.flp_lastQuizzes);
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(197, 596);
            this.pnl_left.TabIndex = 14;
            // 
            // Dashboard
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(944, 596);
            this.Controls.Add(this.pnl_left);
            this.Controls.Add(this.pnl_quizOverview);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(831, 496);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteelQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.Shown += new System.EventHandler(this.Welcome_Shown);
            this.SizeChanged += new System.EventHandler(this.Welcome_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Dashboard_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Dashboard_DragEnter);
            this.pnl_quizOverview.ResumeLayout(false);
            this.pnl_welcome.ResumeLayout(false);
            this.pnl_welcomeText.ResumeLayout(false);
            this.cms_recentQuizzes.ResumeLayout(false);
            this.pnl_left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btn_addQuiz;
        private System.Windows.Forms.OpenFileDialog ofd_loadQuiz;
        private System.Windows.Forms.Button btn_preferences;
        internal System.Windows.Forms.Timer tmr_chkUpdate;
        private System.Windows.Forms.Timer tmr_welcomeMsg;
        private System.Windows.Forms.Panel pnl_quizOverview;
        private System.Windows.Forms.Button btn_loadQuizFromFile;
        private System.Windows.Forms.Button btn_createQuiz;
        private System.Windows.Forms.Button btn_importQuiz;
        private System.Windows.Forms.FlowLayoutPanel flp_lastQuizzes;
        private System.Windows.Forms.Label lbl_recentQuizzes;
        private System.Windows.Forms.Panel pnl_welcome;
        private System.Windows.Forms.Label lbl_toBegin;
        private System.Windows.Forms.Panel pnl_welcomeText;
        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.ContextMenuStrip cms_recentQuizzes;
        private System.Windows.Forms.ToolStripMenuItem clearRecentQuizzesListToolStripMenuItem;
    }
}

