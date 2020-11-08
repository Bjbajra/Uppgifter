using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class SelectWordList : Form
    {
        public event EventHandler SelectHandler;
        public static string SelectedFile { get; set; }
        public  WordList ListName { get; set; }

        public SelectWordList()
        {
            InitializeComponent();
            Select_button.Enabled = false;
        }

        private void Select_button_Click(object sender, EventArgs e)
        {

            SelectHandler?.Invoke(this, null);
            Close();

        }

        private void Newlist_button_Click(object sender, EventArgs e)
        {
            using (NewListForm newListForm = new NewListForm())
            {
                newListForm.ShowDialog();
                newListForm.StartPosition = FormStartPosition.CenterParent;
            }
        }

        private void SelectWordlist_Activated(object sender, EventArgs e)
        {
            listBoxWord.Items.Clear();
            var lists = WordList.GetList();
            foreach (var list in lists)
            {
                if (WordList.LoadList(list) != null && WordList.LoadList(list).Languages.Length > 1)
                {
                    listBoxWord.Items.Add(list);
                }
            }

        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBoxWord_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxWord.SelectedItem != null)
            {
                listBoxLanguage.Items.Clear();
                ListName = WordList.LoadList(listBoxWord.SelectedItem.ToString());
                var arrayOfLanguage = WordList.LoadList(listBoxWord.SelectedItem.ToString()).Languages;
                var selectedFile = WordList.LoadList(listBoxWord.GetItemText(listBoxWord.SelectedItem));
                Value_label.Text = $"{WordList.LoadList(listBoxWord.SelectedItem.ToString()).Count()}";

                foreach (var lang in arrayOfLanguage)
                {
                    listBoxLanguage.Items.Add(lang);
                }

                SelectedFile = selectedFile.Name;
                Select_button.Enabled = true;
            }
        }

        private void listBoxWord_DoubleClick_1(object sender, EventArgs e)
        {
            if (listBoxWord.SelectedItem != null)
            {
                SelectHandler?.Invoke(this, null);
                Visible = false;
            }
        }
    }
}
