namespace Lab4_WinForm
{
    partial class AddWordForm
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
            this.WordGridView = new System.Windows.Forms.DataGridView();
            this.AddWordButton = new System.Windows.Forms.Button();
            this.CanelButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WordGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WordGridView
            // 
            this.WordGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WordGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.WordGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.WordGridView.Location = new System.Drawing.Point(0, 0);
            this.WordGridView.Name = "WordGridView";
            this.WordGridView.RowHeadersVisible = false;
            this.WordGridView.Size = new System.Drawing.Size(235, 161);
            this.WordGridView.TabIndex = 0;
            // 
            // AddWordButton
            // 
            this.AddWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddWordButton.Location = new System.Drawing.Point(12, 167);
            this.AddWordButton.Name = "AddWordButton";
            this.AddWordButton.Size = new System.Drawing.Size(75, 23);
            this.AddWordButton.TabIndex = 1;
            this.AddWordButton.Text = "Add";
            this.AddWordButton.UseVisualStyleBackColor = true;
            this.AddWordButton.Click += new System.EventHandler(this.AddWordButton_Click);
            // 
            // CanelButton
            // 
            this.CanelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CanelButton.Location = new System.Drawing.Point(137, 167);
            this.CanelButton.Name = "CanelButton";
            this.CanelButton.Size = new System.Drawing.Size(75, 23);
            this.CanelButton.TabIndex = 2;
            this.CanelButton.Text = "Cancel";
            this.CanelButton.UseVisualStyleBackColor = true;
            this.CanelButton.Click += new System.EventHandler(this.CanelButton_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Langugae";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Word";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // AddWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 200);
            this.Controls.Add(this.CanelButton);
            this.Controls.Add(this.AddWordButton);
            this.Controls.Add(this.WordGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddWordForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddWord";
            ((System.ComponentModel.ISupportInitialize)(this.WordGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WordGridView;
        private System.Windows.Forms.Button AddWordButton;
        private System.Windows.Forms.Button CanelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}