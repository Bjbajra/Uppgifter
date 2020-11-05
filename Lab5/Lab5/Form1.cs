using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;

namespace Lab5
{
    public partial class Form1 : Form
    {
        static Encoding enc8 = Encoding.UTF8;
        private List<string> imageLinks;

        public Form1()
        {
            InitializeComponent();
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

            CountLabel.Text = $"Found: {imageLinks.ToArray().Count()} images";
            //UpdateImageCount();
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
            foreach (Match match in matches)  
            {
                var imageLink = Search_textBox.Text + match.Groups["L"].Value;
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
                        List<string> exceptions = await SaveImages(browserDialog.SelectedPath, Search_textBox.Text, imageLinks);

                        if (exceptions.Count > 0)
                        {
                            StringBuilder errors = new StringBuilder();

                            foreach (String exception in exceptions)
                            {
                                errors.Append(exception + "\n\n");
                            }

                            MessageBox.Show(errors.ToString(), "Image Download Error(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Image Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task<List<string>> SaveImages(string path, string url, List<string> images)
        {
            List<string> exceptionMessages = new List<string>();
            String downloadFolderName = path;
            Directory.CreateDirectory(downloadFolderName);
            List<Task<byte[]>> taskList = new List<Task<byte[]>>();
            List<ImageDownload> downloadsList = new List<ImageDownload>();

            foreach (string image in images)
            {
                if (image.Contains("bmp") || image.Contains("png") || image.Contains("gif") || image.Contains("jpg") ||
                    image.Contains("jpeg"))
                {
                    string imageURL = image;
                    if (!image.Contains("http") && !image.Contains("//"))
                    {
                        string urlBase = url;
                        if (urlBase[urlBase.Length - 1] != '/' && image[0] != '/')
                        {
                            imageURL = urlBase + '/' + image;
                        }
                        else
                        {
                            imageURL = urlBase + image;
                        }
                    }

                    try
                    {
                        Uri imageURI = new Uri(imageURL);
                        HttpClient httpClient = new HttpClient();
                        Task<byte[]> imageBytes = httpClient.GetByteArrayAsync(imageURI);
                        taskList.Add(imageBytes);
                        
                        downloadsList.Add(new ImageDownload(imageBytes, imageURI));
                    }
                    catch (Exception e)
                    {
                        exceptionMessages.Add("File URL: " + imageURL + "\nError Message: " + e.Message);
                    }
                }
            }

            while (taskList.Count > 0)
            {
                Task<byte[]> imageBytes = await Task.WhenAny(taskList.ToArray());
                Uri imageURI = null;

                for (int i = 0; i < downloadsList.Count; ++i)
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
                    CancellationTokenSource cancellationToken = new CancellationTokenSource();
                    using (FileStream fs =
                        new FileStream(downloadFolderName + "//" + Path.GetFileName(imageURI.LocalPath),
                            FileMode.Create))
                    {
                        await fs.WriteAsync(imageBytes.Result, 0, imageBytes.Result.Length);
                    }

                    cancellationToken.Token.ThrowIfCancellationRequested();
                }

                taskList.Remove(imageBytes);
            }

            return exceptionMessages;
        }
        private void UpdateImageCount()
        {
            CountLabel.Text = imageLinks.Count.ToString();
            Result_textBox.Text = "";

            if (imageLinks.Count > 0)
            {
                SaveImg_button.Enabled = true;

                foreach (string image in imageLinks)
                {
                    Result_textBox.AppendText(image + "\n");
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
