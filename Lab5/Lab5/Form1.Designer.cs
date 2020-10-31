namespace Lab5
{
    partial class Form1
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
            this.Search_textBox = new System.Windows.Forms.TextBox();
            this.Result_textBox = new System.Windows.Forms.TextBox();
            this.Extract_button = new System.Windows.Forms.Button();
            this.SaveImg_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Search_textBox
            // 
            this.Search_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Search_textBox.Location = new System.Drawing.Point(12, 10);
            this.Search_textBox.Name = "Search_textBox";
            this.Search_textBox.Size = new System.Drawing.Size(674, 20);
            this.Search_textBox.TabIndex = 0;
            // 
            // Result_textBox
            // 
            this.Result_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result_textBox.Location = new System.Drawing.Point(12, 51);
            this.Result_textBox.Multiline = true;
            this.Result_textBox.Name = "Result_textBox";
            this.Result_textBox.Size = new System.Drawing.Size(775, 357);
            this.Result_textBox.TabIndex = 1;
            // 
            // Extract_button
            // 
            this.Extract_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Extract_button.Location = new System.Drawing.Point(692, 9);
            this.Extract_button.Name = "Extract_button";
            this.Extract_button.Size = new System.Drawing.Size(95, 20);
            this.Extract_button.TabIndex = 2;
            this.Extract_button.Text = "Extract";
            this.Extract_button.UseVisualStyleBackColor = true;
            this.Extract_button.Click += new System.EventHandler(this.Extract_button_Click);
            // 
            // SaveImg_button
            // 
            this.SaveImg_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveImg_button.Location = new System.Drawing.Point(692, 414);
            this.SaveImg_button.Name = "SaveImg_button";
            this.SaveImg_button.Size = new System.Drawing.Size(95, 20);
            this.SaveImg_button.TabIndex = 3;
            this.SaveImg_button.Text = "Save Images";
            this.SaveImg_button.UseVisualStyleBackColor = true;
            this.SaveImg_button.Click += new System.EventHandler(this.SaveImg_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "info";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveImg_button);
            this.Controls.Add(this.Extract_button);
            this.Controls.Add(this.Result_textBox);
            this.Controls.Add(this.Search_textBox);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ImageScraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Search_textBox;
        private System.Windows.Forms.TextBox Result_textBox;
        private System.Windows.Forms.Button Extract_button;
        private System.Windows.Forms.Button SaveImg_button;
        private System.Windows.Forms.Label label1;
    }
}

