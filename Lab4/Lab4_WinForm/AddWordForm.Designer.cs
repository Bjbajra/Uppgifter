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
            this.AddWordButton = new System.Windows.Forms.Button();
            this.CanelButton = new System.Windows.Forms.Button();
            this.WordGridView = new System.Windows.Forms.DataGridView();
            this.langugae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.WordGridView)).BeginInit();
            this.SuspendLayout();
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
            this.CanelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.CanelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CanelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanelButton.Location = new System.Drawing.Point(137, 167);
            this.CanelButton.Name = "CanelButton";
            this.CanelButton.Size = new System.Drawing.Size(75, 23);
            this.CanelButton.TabIndex = 2;
            this.CanelButton.Text = "Cancel";
            this.CanelButton.UseVisualStyleBackColor = true;
            this.CanelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // WordGridView
            // 
            this.WordGridView.AllowUserToAddRows = false;
            this.WordGridView.AllowUserToDeleteRows = false;
            this.WordGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WordGridView.ColumnHeadersVisible = false;
            this.WordGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.langugae,
            this.Word});
            this.WordGridView.Location = new System.Drawing.Point(1, 3);
            this.WordGridView.Name = "WordGridView";
            this.WordGridView.RowHeadersVisible = false;
            this.WordGridView.Size = new System.Drawing.Size(233, 152);
            this.WordGridView.TabIndex = 3;
            this.WordGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.WordGridView_CellValueChanged_1);
            // 
            // langugae
            // 
            this.langugae.HeaderText = "Language";
            this.langugae.Name = "langugae";
            this.langugae.ReadOnly = true;
            // 
            // Word
            // 
            this.Word.HeaderText = "Word";
            this.Word.Name = "Word";
            // 
            // AddWordForm
            // 
            this.AcceptButton = this.AddWordButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CanelButton;
            this.ClientSize = new System.Drawing.Size(235, 200);
            this.Controls.Add(this.WordGridView);
            this.Controls.Add(this.CanelButton);
            this.Controls.Add(this.AddWordButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddWordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddWord";
            this.Load += new System.EventHandler(this.AddWordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WordGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddWordButton;
        private System.Windows.Forms.Button CanelButton;
        private System.Windows.Forms.DataGridView WordGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn langugae;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
    }
}