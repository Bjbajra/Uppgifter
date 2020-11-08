namespace Lab4_WinForm
{
    partial class PracticeControl
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
            this.Practicelabel = new System.Windows.Forms.Label();
            this.PracticetextBox = new System.Windows.Forms.TextBox();
            this.Resultlabel = new System.Windows.Forms.Label();
            this.Restartbutton = new System.Windows.Forms.Button();
            this.Endbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Practicelabel
            // 
            this.Practicelabel.AutoSize = true;
            this.Practicelabel.Location = new System.Drawing.Point(194, 193);
            this.Practicelabel.Name = "Practicelabel";
            this.Practicelabel.Size = new System.Drawing.Size(59, 13);
            this.Practicelabel.TabIndex = 0;
            this.Practicelabel.Text = "Translation";
            // 
            // PracticetextBox
            // 
            this.PracticetextBox.Location = new System.Drawing.Point(197, 231);
            this.PracticetextBox.Name = "PracticetextBox";
            this.PracticetextBox.Size = new System.Drawing.Size(282, 20);
            this.PracticetextBox.TabIndex = 1;
            this.PracticetextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PracticeTextBox_KeyDown);
            // 
            // Resultlabel
            // 
            this.Resultlabel.AutoSize = true;
            this.Resultlabel.Location = new System.Drawing.Point(235, 277);
            this.Resultlabel.Name = "Resultlabel";
            this.Resultlabel.Size = new System.Drawing.Size(32, 13);
            this.Resultlabel.TabIndex = 2;
            this.Resultlabel.Text = "result";
            // 
            // Restartbutton
            // 
            this.Restartbutton.Location = new System.Drawing.Point(197, 320);
            this.Restartbutton.Name = "Restartbutton";
            this.Restartbutton.Size = new System.Drawing.Size(126, 27);
            this.Restartbutton.TabIndex = 3;
            this.Restartbutton.Text = "RESTART";
            this.Restartbutton.UseVisualStyleBackColor = true;
            this.Restartbutton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // Endbutton
            // 
            this.Endbutton.Location = new System.Drawing.Point(353, 320);
            this.Endbutton.Name = "Endbutton";
            this.Endbutton.Size = new System.Drawing.Size(126, 27);
            this.Endbutton.TabIndex = 4;
            this.Endbutton.Text = "END PRACTICE";
            this.Endbutton.UseVisualStyleBackColor = true;
            this.Endbutton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // PracticeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Endbutton);
            this.Controls.Add(this.Restartbutton);
            this.Controls.Add(this.Resultlabel);
            this.Controls.Add(this.PracticetextBox);
            this.Controls.Add(this.Practicelabel);
            this.Name = "PracticeControl";
            this.Size = new System.Drawing.Size(749, 591);
            this.Load += new System.EventHandler(this.PracticeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Practicelabel;
        private System.Windows.Forms.TextBox PracticetextBox;
        private System.Windows.Forms.Label Resultlabel;
        private System.Windows.Forms.Button Restartbutton;
        private System.Windows.Forms.Button Endbutton;
    }
}
