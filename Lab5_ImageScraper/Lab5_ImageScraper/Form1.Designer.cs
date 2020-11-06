namespace Lab5_ImageScraper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Result_RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.UrlTextBox1 = new System.Windows.Forms.TextBox();
            this.CountLabel = new System.Windows.Forms.Label();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Result_RichTextBox1
            // 
            resources.ApplyResources(this.Result_RichTextBox1, "Result_RichTextBox1");
            this.Result_RichTextBox1.Name = "Result_RichTextBox1";
            // 
            // UrlTextBox1
            // 
            resources.ApplyResources(this.UrlTextBox1, "UrlTextBox1");
            this.UrlTextBox1.Name = "UrlTextBox1";
            // 
            // CountLabel
            // 
            resources.ApplyResources(this.CountLabel, "CountLabel");
            this.CountLabel.Name = "CountLabel";
            // 
            // ExtractButton
            // 
            resources.ApplyResources(this.ExtractButton, "ExtractButton");
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click_1);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click_1);
            // 
            // Form1
            // 
            this.AcceptButton = this.ExtractButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.UrlTextBox1);
            this.Controls.Add(this.Result_RichTextBox1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HelpButton = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Result_RichTextBox1;
        private System.Windows.Forms.TextBox UrlTextBox1;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button SaveButton;
    }
}

