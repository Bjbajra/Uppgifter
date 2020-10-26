namespace Lab4_WinForm
{
    partial class FirstGridControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Swedish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spanish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nepali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Removebutton = new System.Windows.Forms.Button();
            this.Practicebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.English,
            this.Swedish,
            this.Spanish,
            this.Nepali});
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(749, 534);
            this.dataGridView1.TabIndex = 0;
            // 
            // English
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.English.DefaultCellStyle = dataGridViewCellStyle9;
            this.English.HeaderText = "ENGLISH";
            this.English.Name = "English";
            this.English.ReadOnly = true;
            // 
            // Swedish
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Green;
            this.Swedish.DefaultCellStyle = dataGridViewCellStyle10;
            this.Swedish.HeaderText = "SWEDISH";
            this.Swedish.Name = "Swedish";
            this.Swedish.ReadOnly = true;
            // 
            // Spanish
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red;
            this.Spanish.DefaultCellStyle = dataGridViewCellStyle11;
            this.Spanish.HeaderText = "SPANISH";
            this.Spanish.Name = "Spanish";
            this.Spanish.ReadOnly = true;
            // 
            // Nepali
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Nepali.DefaultCellStyle = dataGridViewCellStyle12;
            this.Nepali.HeaderText = "NEPALI";
            this.Nepali.Name = "Nepali";
            this.Nepali.ReadOnly = true;
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
            // 
            // FirstGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Practicebutton);
            this.Controls.Add(this.Removebutton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FirstGridControl";
            this.Size = new System.Drawing.Size(749, 591);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button Removebutton;
        private System.Windows.Forms.Button Practicebutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewTextBoxColumn Swedish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spanish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nepali;
    }
}
