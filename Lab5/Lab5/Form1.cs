using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace Lab5
{
    public partial class Form1 : Form
    {
        static Encoding enc8 = Encoding.UTF8;
        private List<string> imageLinks = new List<string>();
        private int i;

        public Form1()
        {
            InitializeComponent();
            SaveImg_button.Enabled = false;
        }

        private void Extract_button_Click(object sender, EventArgs e)
        {
            String url = Search_textBox.Text;
            Task<string> imgExtract = PostRequest(url);
            imageLinks = GetImagesLinks(imgExtract.Result);

            foreach (var imageLink in imageLinks)
            {
                Result_textBox.Text += Environment.NewLine + imageLink;
            }

            CountLabel.Text = $"Found: {imageLinks.Count()} images";
            SaveImg_button.Enabled = true;
            Extract_button.Enabled = false;
        }

        private async Task<string> PostRequest(string sUrl)
        {
            HttpClient client = new HttpClient();
            byte[] urlContents = await client.GetByteArrayAsync(sUrl).ConfigureAwait(false);
            return enc8.GetString(urlContents);
        }

        private List<string> GetImagesLinks(string htmlString)
        {
            List<string> images = new List<string>();
            string pattern = @"<img\b[^\<\>]+?\bsrc\s*=\s*[""'](?<L>.+?)[""'][^\<\>]*?\>";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(htmlString);
            string imageLink;
            foreach (Match match in matches)
            {

                if (match.Groups["L"].Value.StartsWith("http://") || match.Groups["L"].Value.StartsWith("https://"))
                {
                    imageLink = match.Groups["L"].Value;
                }
                else
                {
                    imageLink = Search_textBox.Text + match.Groups["L"].Value;
                }

                images.Add(imageLink);
            }

            return images;
        }

        private async void SaveImg_button_Click(object sender, EventArgs e)
        {
            using (var browserDialog = new FolderBrowserDialog())
            {
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<string> exceptions =
                            await SaveImages(browserDialog.SelectedPath, Search_textBox.Text, imageLinks);

                        if (exceptions.Count > 0)
                        {
                            StringBuilder errors = new StringBuilder();

                            foreach (String exception in exceptions)
                            {
                                errors.Append(exception + "\n\n");
                            }

                            MessageBox.Show(errors.ToString(), "Image Download Error(s)", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Image Download Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task<List<string>> SaveImages(string path, string url, List<string> images)
        {
            List<string> exceptionMessages = new List<string>();
            String downloadFolderName = path;
            Directory.CreateDirectory(downloadFolderName);
            List<Task<byte[]>> tasks = new List<Task<byte[]>>();
            List<ImageDownload> downloadsList = new List<ImageDownload>();

            foreach (string image in images)
            {
                if (image.Contains(".bmp") || image.Contains(".png") || image.Contains(".gif") ||
                    image.Contains(".jpg") ||
                    image.Contains(".jpeg"))
                {
                    try
                    {
                        Uri imageURI = new Uri(image);
                        HttpClient httpClient = new HttpClient();
                        Task<byte[]> imageBytes = httpClient.GetByteArrayAsync(imageURI);
                        tasks.Add(imageBytes);
                        downloadsList.Add(new ImageDownload(imageBytes, imageURI));

                    }
                    catch (Exception e)
                    {
                        exceptionMessages.Add("File URL: " + image + "\nError Message: " + e.Message);
                    }
                }
            }

            while (tasks.Count > 0)
            {
                Task<byte[]> imageBytes = await Task.WhenAny(tasks.ToArray());
                Uri imageURI = null;
                string imageName = "image";

                for (i = 0; i < downloadsList.Count; ++i)
                {
                    if (downloadsList[i].DownloadTask == imageBytes)
                    {
                        imageURI = downloadsList[i].URI;
                        downloadsList.RemoveAt(i);
                        break;
                    }
                }

                if (imageURI != null)
                {
                    using (FileStream fs =
                        new FileStream(downloadFolderName + "//" + Path.GetFileName(imageURI.LocalPath),
                            FileMode.Create, FileAccess.Write))
                    {
                        await fs.WriteAsync(imageBytes.Result, 0, imageBytes.Result.Length);
                    }
                }

                tasks.Remove(imageBytes);
            }

            return exceptionMessages;
        }

        class ImageDownload
        {
            public Task<byte[]> DownloadTask { get; }

            public Uri URI { get; }

            public ImageDownload(Task<byte[]> downloadTask, Uri uri)
            {
                DownloadTask = downloadTask;
                URI = uri;
            }
        }
    }
}


