namespace Lab4_WinForm
{
    partial class MainGridControl
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
            this.MainGridView = new System.Windows.Forms.DataGridView();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Removebutton = new System.Windows.Forms.Button();
            this.Practicebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGridView
            // 
            this.MainGridView.AllowUserToAddRows = false;
            this.MainGridView.AllowUserToDeleteRows = false;
            this.MainGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGridView.Location = new System.Drawing.Point(0, 25);
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.ReadOnly = true;
            this.MainGridView.RowHeadersVisible = false;
            this.MainGridView.Size = new System.Drawing.Size(749, 534);
            this.MainGridView.TabIndex = 0;
            this.MainGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FirstGridView_CellContentClick);
            // 
            // Addbutton
            // 
            this.Addbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Addbutton.Location = new System.Drawing.Point(493, 565);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Addbutton.Size = new System.Drawing.Size(75, 23);
            this.Addbutton.TabIndex = 1;
            this.Addbutton.Text = "Add word";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Removebutton
            // 
            this.Removebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Removebutton.Location = new System.Drawing.Point(574, 565);
            this.Removebutton.Name = "Removebutton";
            this.Removebutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Removebutton.Size = new System.Drawing.Size(91, 23);
            this.Removebutton.TabIndex = 2;
            this.Removebutton.Text = "Remove word";
            this.Removebutton.UseVisualStyleBackColor = true;
            this.Removebutton.Click += new System.EventHandler(this.Removebutton_Click);
            // 
            // Practicebutton
            // 
            this.Practicebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Practicebutton.Location = new System.Drawing.Point(671, 565);
            this.Practicebutton.Name = "Practicebutton";
            this.Practicebutton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Practicebutton.Size = new System.Drawing.Size(75, 23);
            this.Practicebutton.TabIndex = 3;
            this.Practicebutton.Text = "Practice";
            this.Practicebutton.UseVisualStyleBackColor = true;
            this.Practicebutton.Click += new System.EventHandler(this.PracticeButton_Click);
            // 
            // MainGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Practicebutton);
            this.Controls.Add(this.Removebutton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.MainGridView);
            this.Name = "MainGridControl";
            this.Size = new System.Drawing.Size(749, 591);
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainGridView;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button Removebutton;
        private System.Windows.Forms.Button Practicebutton;
    }
}
