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

namespace SteelQuiz.QuizEditor
{
    partial class QuizEditorWordPair
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
            this.pnl_translationRules = new System.Windows.Forms.Panel();
            this.chk_ignoreExcl = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_ignoreCapitalization = new System.Windows.Forms.CheckBox();
            this.txt_word1 = new System.Windows.Forms.TextBox();
            this.btn_editSynonyms_w1 = new System.Windows.Forms.Button();
            this.txt_word2 = new System.Windows.Forms.TextBox();
            this.btn_editSynonyms_w2 = new System.Windows.Forms.Button();
            this.pnl_translationRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_translationRules
            // 
            this.pnl_translationRules.Controls.Add(this.chk_ignoreExcl);
            this.pnl_translationRules.Controls.Add(this.label4);
            this.pnl_translationRules.Controls.Add(this.chk_ignoreCapitalization);
            this.pnl_translationRules.Location = new System.Drawing.Point(237, 29);
            this.pnl_translationRules.Name = "pnl_translationRules";
            this.pnl_translationRules.Size = new System.Drawing.Size(279, 65);
            this.pnl_translationRules.TabIndex = 2;
            // 
            // chk_ignoreExcl
            // 
            this.chk_ignoreExcl.AutoSize = true;
            this.chk_ignoreExcl.Location = new System.Drawing.Point(129, 22);
            this.chk_ignoreExcl.Name = "chk_ignoreExcl";
            this.chk_ignoreExcl.Size = new System.Drawing.Size(146, 17);
            this.chk_ignoreExcl.TabIndex = 2;
            this.chk_ignoreExcl.TabStop = false;
            this.chk_ignoreExcl.Text = "Ignore exclamation marks";
            this.chk_ignoreExcl.UseVisualStyleBackColor = true;
            this.chk_ignoreExcl.CheckedChanged += new System.EventHandler(this.chk_ignoreExcl_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Translation rules";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_ignoreCapitalization
            // 
            this.chk_ignoreCapitalization.AutoSize = true;
            this.chk_ignoreCapitalization.Location = new System.Drawing.Point(3, 22);
            this.chk_ignoreCapitalization.Name = "chk_ignoreCapitalization";
            this.chk_ignoreCapitalization.Size = new System.Drawing.Size(120, 17);
            this.chk_ignoreCapitalization.TabIndex = 0;
            this.chk_ignoreCapitalization.TabStop = false;
            this.chk_ignoreCapitalization.Text = "Ignore capitalization";
            this.chk_ignoreCapitalization.UseVisualStyleBackColor = true;
            this.chk_ignoreCapitalization.CheckedChanged += new System.EventHandler(this.chk_ignoreCapitalization_CheckedChanged);
            // 
            // txt_word1
            // 
            this.txt_word1.Location = new System.Drawing.Point(3, 3);
            this.txt_word1.Name = "txt_word1";
            this.txt_word1.Size = new System.Drawing.Size(357, 20);
            this.txt_word1.TabIndex = 0;
            this.txt_word1.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_word1.TextChanged += new System.EventHandler(this.txt_word1_TextChanged);
            this.txt_word1.Enter += new System.EventHandler(this.txt_word1_Enter);
            // 
            // btn_editSynonyms_w1
            // 
            this.btn_editSynonyms_w1.Location = new System.Drawing.Point(3, 29);
            this.btn_editSynonyms_w1.Name = "btn_editSynonyms_w1";
            this.btn_editSynonyms_w1.Size = new System.Drawing.Size(75, 39);
            this.btn_editSynonyms_w1.TabIndex = 4;
            this.btn_editSynonyms_w1.TabStop = false;
            this.btn_editSynonyms_w1.Text = "Edit synonyms";
            this.btn_editSynonyms_w1.UseVisualStyleBackColor = true;
            this.btn_editSynonyms_w1.Click += new System.EventHandler(this.btn_editSynonyms_w1_Click);
            // 
            // txt_word2
            // 
            this.txt_word2.Location = new System.Drawing.Point(368, 3);
            this.txt_word2.Name = "txt_word2";
            this.txt_word2.Size = new System.Drawing.Size(357, 20);
            this.txt_word2.TabIndex = 5;
            this.txt_word2.Click += new System.EventHandler(this.txt_word_Click);
            this.txt_word2.TextChanged += new System.EventHandler(this.txt_word2_TextChanged);
            this.txt_word2.Enter += new System.EventHandler(this.txt_word1_Enter);
            // 
            // btn_editSynonyms_w2
            // 
            this.btn_editSynonyms_w2.Location = new System.Drawing.Point(652, 29);
            this.btn_editSynonyms_w2.Name = "btn_editSynonyms_w2";
            this.btn_editSynonyms_w2.Size = new System.Drawing.Size(75, 39);
            this.btn_editSynonyms_w2.TabIndex = 6;
            this.btn_editSynonyms_w2.TabStop = false;
            this.btn_editSynonyms_w2.Text = "Edit synonyms";
            this.btn_editSynonyms_w2.UseVisualStyleBackColor = true;
            this.btn_editSynonyms_w2.Click += new System.EventHandler(this.btn_editSynonyms_w2_Click);
            // 
            // QuizEditorWordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_editSynonyms_w2);
            this.Controls.Add(this.txt_word2);
            this.Controls.Add(this.btn_editSynonyms_w1);
            this.Controls.Add(this.txt_word1);
            this.Controls.Add(this.pnl_translationRules);
            this.Name = "QuizEditorWordPair";
            this.Size = new System.Drawing.Size(728, 95);
            this.pnl_translationRules.ResumeLayout(false);
            this.pnl_translationRules.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_translationRules;
        internal System.Windows.Forms.CheckBox chk_ignoreExcl;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox chk_ignoreCapitalization;
        internal System.Windows.Forms.TextBox txt_word1;
        private System.Windows.Forms.Button btn_editSynonyms_w1;
        internal System.Windows.Forms.TextBox txt_word2;
        private System.Windows.Forms.Button btn_editSynonyms_w2;
    }
}