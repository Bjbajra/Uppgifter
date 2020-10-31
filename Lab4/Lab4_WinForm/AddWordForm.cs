using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_WinForm
{
    public partial class AddWordForm : Form
    {
        public AddWordForm()
        {
            InitializeComponent();
        }

        private void AddWordButton_Click(object sender, EventArgs e)
        {
            WordGridView.Rows.Add("");
        }

        private void CanelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
