using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private bool needSaving = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Extract_button_Click(object sender, EventArgs e)
        {
            String url = Search_textBox.Text;
            HttpClient client = new HttpClient();
            Task<string> imgExtract = client.GetStringAsync(url);

            imgExtract.Wait();
            Result_textBox.Text += Environment.NewLine + (imgExtract.Result); //(GetImagesInHTMLString(imgExtract.Result));

        }
        private List<string> GetImagesInHTMLString(string htmlString)
        {
            List<string> images = new List<string>();
            string pattern = @"<img\b[^\<\>]+?\bsrc\s*=\s*[""'](?<L>.+?)[""'][^\<\>]*?\>";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);

            foreach (var image in matches)
            {

            }
            return images;
        }

        //static Task<byte[]> DownloadImage(string url)
        //{
        //    var client = new HttpClient();
        //    return client.GetByteArrayAsync(url);
        //}

        static async Task SaveImage(byte[] bytes, string imagePath)
        {
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        private void SaveImg_button_Click(object sender, EventArgs e)
        {
            using (var browserDialog = new FolderBrowserDialog())
            {
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    var saveFile = new SaveFileDialog();
                    var result = saveFile.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                    //    string text = ;
                    //    var file = new StreamWriter(File.OpenWrite(saveFile.FileName));
                    //    file.WriteLine(text);
                    //    file.Close();
                    //}
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needSaving)
            {
                if (MessageBox.Show("Do you want to quit without saving!", "Quit application?",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
