﻿namespace SteelQuiz
{
    partial class QuizNotFound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizNotFound));
            this.lbl_msg = new System.Windows.Forms.Label();
            this.btn_autoSearch = new System.Windows.Forms.Button();
            this.btn_specifyManually = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.ofd_quiz = new System.Windows.Forms.OpenFileDialog();
            this.bgw_quizSearcher = new System.ComponentModel.BackgroundWorker();
            this.lbl_oldPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msg.Location = new System.Drawing.Point(12, 9);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(517, 37);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "Could not locate quiz. Did you rename or move it?";
            this.lbl_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_autoSearch
            // 
            this.btn_autoSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_autoSearch.FlatAppearance.BorderSize = 0;
            this.btn_autoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_autoSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_autoSearch.Location = new System.Drawing.Point(316, 128);
            this.btn_autoSearch.Name = "btn_autoSearch";
            this.btn_autoSearch.Size = new System.Drawing.Size(213, 38);
            this.btn_autoSearch.TabIndex = 1;
            this.btn_autoSearch.Text = "Let SteelQuiz search";
            this.btn_autoSearch.UseVisualStyleBackColor = false;
            this.btn_autoSearch.Click += new System.EventHandler(this.btn_autoSearch_Click);
            // 
            // btn_specifyManually
            // 
            this.btn_specifyManually.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_specifyManually.FlatAppearance.BorderSize = 0;
            this.btn_specifyManually.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_specifyManually.Location = new System.Drawing.Point(170, 128);
            this.btn_specifyManually.Name = "btn_specifyManually";
            this.btn_specifyManually.Size = new System.Drawing.Size(140, 38);
            this.btn_specifyManually.TabIndex = 2;
            this.btn_specifyManually.Text = "Specify new path manually";
            this.btn_specifyManually.UseVisualStyleBackColor = false;
            this.btn_specifyManually.Click += new System.EventHandler(this.btn_specifyManually_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(12, 128);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(91, 38);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // ofd_quiz
            // 
            this.ofd_quiz.Filter = "SteelQuiz Quizzes|*.steelquiz";
            this.ofd_quiz.Title = "Select the quiz file";
            // 
            // bgw_quizSearcher
            // 
            this.bgw_quizSearcher.WorkerSupportsCancellation = true;
            this.bgw_quizSearcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_quizSearcher_DoWork);
            this.bgw_quizSearcher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_quizSearcher_RunWorkerCompleted);
            // 
            // lbl_oldPath
            // 
            this.lbl_oldPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_oldPath.Location = new System.Drawing.Point(12, 46);
            this.lbl_oldPath.Name = "lbl_oldPath";
            this.lbl_oldPath.Size = new System.Drawing.Size(517, 79);
            this.lbl_oldPath.TabIndex = 4;
            this.lbl_oldPath.Text = "Old Path:\r\nNULL";
            this.lbl_oldPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuizNotFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(541, 178);
            this.Controls.Add(this.lbl_oldPath);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_specifyManually);
            this.Controls.Add(this.btn_autoSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizNotFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Not Found";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_msg;
        private System.Windows.Forms.Button btn_autoSearch;
        private System.Windows.Forms.Button btn_specifyManually;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.OpenFileDialog ofd_quiz;
        private System.ComponentModel.BackgroundWorker bgw_quizSearcher;
        private System.Windows.Forms.Label lbl_oldPath;
    }
}