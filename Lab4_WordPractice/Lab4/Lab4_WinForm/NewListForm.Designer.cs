namespace Lab4_WinForm
{
    partial class NewListForm
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
            this.Tittlelabel = new System.Windows.Forms.Label();
            this.ListtextBox = new System.Windows.Forms.TextBox();
            this.Languagelabel = new System.Windows.Forms.Label();
            this.LanguagetextBox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tittlelabel
            // 
            this.Tittlelabel.AutoSize = true;
            this.Tittlelabel.Location = new System.Drawing.Point(12, 9);
            this.Tittlelabel.Name = "Tittlelabel";
            this.Tittlelabel.Size = new System.Drawing.Size(30, 13);
            this.Tittlelabel.TabIndex = 0;
            this.Tittlelabel.Text = "Tittle";
            // 
            // ListtextBox
            // 
            this.ListtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListtextBox.Location = new System.Drawing.Point(12, 25);
            this.ListtextBox.Name = "ListtextBox";
            this.ListtextBox.Size = new System.Drawing.Size(184, 20);
            this.ListtextBox.TabIndex = 1;
            this.ListtextBox.TextChanged += new System.EventHandler(this.ListTextBox_TextChanged);
            // 
            // Languagelabel
            // 
            this.Languagelabel.AutoSize = true;
            this.Languagelabel.Location = new System.Drawing.Point(12, 59);
            this.Languagelabel.Name = "Languagelabel";
            this.Languagelabel.Size = new System.Drawing.Size(60, 13);
            this.Languagelabel.TabIndex = 2;
            this.Languagelabel.Text = "Languages";
            // 
            // LanguagetextBox
            // 
            this.LanguagetextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguagetextBox.Location = new System.Drawing.Point(12, 75);
            this.LanguagetextBox.Multiline = true;
            this.LanguagetextBox.Name = "LanguagetextBox";
            this.LanguagetextBox.Size = new System.Drawing.Size(184, 129);
            this.LanguagetextBox.TabIndex = 3;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKbutton.Location = new System.Drawing.Point(12, 221);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbutton.Location = new System.Drawing.Point(121, 221);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 5;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelbutton;
            this.ClientSize = new System.Drawing.Size(205, 256);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.LanguagetextBox);
            this.Controls.Add(this.Languagelabel);
            this.Controls.Add(this.ListtextBox);
            this.Controls.Add(this.Tittlelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "NewListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewListForm";
            this.Load += new System.EventHandler(this.NewListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tittlelabel;
        private System.Windows.Forms.TextBox ListtextBox;
        private System.Windows.Forms.Label Languagelabel;
        private System.Windows.Forms.TextBox LanguagetextBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
    }
}