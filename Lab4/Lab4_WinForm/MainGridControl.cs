using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class MainGridControl : UserControl
    {
        private string ListName { get; set; }
        public MainGridControl(string listName)
        {
            InitializeComponent();
            ListName = listName;
            SelectWordlist selectWordlist = new SelectWordlist(listName);
            Controls.Add(selectWordlist);

        }
        public MainGridControl()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddWordForm addWordForm  = new AddWordForm();
            //Controls.Add(addWordForm);
            addWordForm.Show();
        }

        private void PracticeButton_Click(object sender, EventArgs e)
        {
            MainGridView.Hide();
            PracticeControl practiceControl = new PracticeControl();
            Controls.Add(practiceControl);
            practiceControl.Dock = DockStyle.Fill;
            practiceControl.Show();

            //if (listBox1.SelectedItem != null)
            //{
            //    listBox1.Enabled = false;
            //    var name = listBox1.SelectedItem.ToString();
            //    if (WordList.LoadList(name).Count() != 0)
            //    {
            //        PracticeControl practiceControl = new PracticeControl();
            //        Controls.Add(practiceControl);
            //        practiceControl.Dock = DockStyle.Fill;
            //        practiceControl.Show();
            //    }
            //    else
            //    {
            //        var caption = "Error Detected";
            //        var message =
            //            "The selected list is empty, you cant practice with an empty list";
            //        var buttons = MessageBoxButtons.OK;
            //        DialogResult result;
            //        result = MessageBox.Show(message, caption, buttons);
            //    }
            //}
        }

        private void FirstGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (WordList.LoadList(ListName) != null)
            {
                var languageArray = WordList.LoadList(ListName).Languages;
                var sortBy = 0;
                
                MainGridView.Rows.Clear();
                MainGridView.Columns.Clear();
                //FirstGridView.Refresh();
                foreach (var languages in languageArray)
                    MainGridView.Columns.Add("newColumnName", languages.ToUpper());
                MainGridView.Rows.Clear();

                WordList.LoadList(ListName).List(sortBy, x => { MainGridView.Rows.Add(x); });
            }
        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedItem != null) ListName = listBox1.SelectedItem.ToString();

            foreach (DataGridViewRow item in MainGridView.SelectedRows) MainGridView.Rows.RemoveAt(item.Index);
            if (MainGridView.SelectedRows.Count != 0)
            {
                var selectedRows = MainGridView.SelectedRows;
                var word = selectedRows[0].Cells[0].Value.ToString();
                WordList.LoadList(ListName).Remove(0, word);
            }
        }
    }
}
