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

namespace SteelQuiz.QuizImport.Guide.Studentlitteratur
{
    partial class Step4
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
            this.txt_lang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_question = new System.Windows.Forms.Label();
            this.lst_words = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txt_lang
            // 
            this.txt_lang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_lang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lang.Location = new System.Drawing.Point(144, 334);
            this.txt_lang.Name = "txt_lang";
            this.txt_lang.Size = new System.Drawing.Size(619, 22);
            this.txt_lang.TabIndex = 0;
            this.txt_lang.TextChanged += new System.EventHandler(this.Txt_lang_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Language (in English):";
            // 
            // lbl_question
            // 
            this.lbl_question.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_question.ForeColor = System.Drawing.Color.White;
            this.lbl_question.Location = new System.Drawing.Point(3, 13);
            this.lbl_question.Name = "lbl_question";
            this.lbl_question.Size = new System.Drawing.Size(760, 43);
            this.lbl_question.TabIndex = 4;
            this.lbl_question.Text = "Which language are the following words written in?";
            // 
            // lst_words
            // 
            this.lst_words.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_words.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_words.ForeColor = System.Drawing.Color.White;
            this.lst_words.FormattingEnabled = true;
            this.lst_words.Location = new System.Drawing.Point(2, 55);
            this.lst_words.Name = "lst_words";
            this.lst_words.Size = new System.Drawing.Size(761, 275);
            this.lst_words.TabIndex = 6;
            this.lst_words.TabStop = false;
            // 
            // Step5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.txt_lang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_words);
            this.Controls.Add(this.lbl_question);
            this.Name = "Step5";
            this.Size = new System.Drawing.Size(766, 364);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox txt_lang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_question;
        private System.Windows.Forms.ListBox lst_words;
    }
}
