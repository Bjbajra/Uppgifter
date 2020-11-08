namespace Lab4_WinForm
{
    partial class SelectWordList
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
            this.Wordlists_label = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.languages = new System.Windows.Forms.Label();
            this.listBoxWord = new System.Windows.Forms.ListBox();
            this.Value_label = new System.Windows.Forms.Label();
            this.Newlist_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.Select_button = new System.Windows.Forms.Button();
            this.listBoxLanguage = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Wordlists_label
            // 
            this.Wordlists_label.AutoSize = true;
            this.Wordlists_label.Location = new System.Drawing.Point(20, 22);
            this.Wordlists_label.Name = "Wordlists_label";
            this.Wordlists_label.Size = new System.Drawing.Size(56, 13);
            this.Wordlists_label.TabIndex = 0;
            this.Wordlists_label.Text = "Word lists:";
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(100, 22);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(66, 13);
            this.count.TabIndex = 1;
            this.count.Text = "Word count:";
            // 
            // languages
            // 
            this.languages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languages.AutoSize = true;
            this.languages.Location = new System.Drawing.Point(210, 22);
            this.languages.Name = "languages";
            this.languages.Size = new System.Drawing.Size(60, 13);
            this.languages.TabIndex = 2;
            this.languages.Text = "Languages";
            // 
            // listBoxWord
            // 
            this.listBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxWord.FormattingEnabled = true;
            this.listBoxWord.Location = new System.Drawing.Point(23, 38);
            this.listBoxWord.Name = "listBoxWord";
            this.listBoxWord.Size = new System.Drawing.Size(168, 186);
            this.listBoxWord.TabIndex = 0;
            this.listBoxWord.SelectedValueChanged += new System.EventHandler(this.listBoxWord_SelectedValueChanged);
            this.listBoxWord.DoubleClick += new System.EventHandler(this.listBoxWord_DoubleClick_1);
            // 
            // Value_label
            // 
            this.Value_label.AutoSize = true;
            this.Value_label.Location = new System.Drawing.Point(165, 22);
            this.Value_label.Name = "Value_label";
            this.Value_label.Size = new System.Drawing.Size(0, 13);
            this.Value_label.TabIndex = 5;
            // 
            // Newlist_button
            // 
            this.Newlist_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Newlist_button.Location = new System.Drawing.Point(20, 238);
            this.Newlist_button.Name = "Newlist_button";
            this.Newlist_button.Size = new System.Drawing.Size(75, 23);
            this.Newlist_button.TabIndex = 6;
            this.Newlist_button.Text = "New list";
            this.Newlist_button.UseVisualStyleBackColor = true;
            this.Newlist_button.Click += new System.EventHandler(this.Newlist_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.Location = new System.Drawing.Point(210, 238);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 7;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Select_button
            // 
            this.Select_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Select_button.Location = new System.Drawing.Point(303, 238);
            this.Select_button.Name = "Select_button";
            this.Select_button.Size = new System.Drawing.Size(75, 23);
            this.Select_button.TabIndex = 8;
            this.Select_button.Text = "Select";
            this.Select_button.UseVisualStyleBackColor = true;
            this.Select_button.Click += new System.EventHandler(this.Select_button_Click);
            // 
            // listBoxLanguage
            // 
            this.listBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxLanguage.FormattingEnabled = true;
            this.listBoxLanguage.Location = new System.Drawing.Point(210, 38);
            this.listBoxLanguage.Name = "listBoxLanguage";
            this.listBoxLanguage.Size = new System.Drawing.Size(168, 186);
            this.listBoxLanguage.TabIndex = 9;
            // 
            // SelectWordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_button;
            this.ClientSize = new System.Drawing.Size(398, 271);
            this.Controls.Add(this.listBoxLanguage);
            this.Controls.Add(this.Select_button);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Newlist_button);
            this.Controls.Add(this.Value_label);
            this.Controls.Add(this.listBoxWord);
            this.Controls.Add(this.languages);
            this.Controls.Add(this.count);
            this.Controls.Add(this.Wordlists_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "SelectWordList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select wordlist";
            this.Activated += new System.EventHandler(this.SelectWordlist_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Wordlists_label;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Label languages;
        private System.Windows.Forms.ListBox listBoxWord;
        private System.Windows.Forms.Label Value_label;
        private System.Windows.Forms.Button Newlist_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button Select_button;
        private System.Windows.Forms.ListBox listBoxLanguage;
    }
}