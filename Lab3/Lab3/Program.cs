using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = Path.GetFullPath(@"C:\Users\bijay\OneDrive\Bilder\Test_photos\pic.bmp");
            string filePath;
            if (args.Length != 0)
            {
                filePath = args[0];
            }
            else
            {
                Console.Write("Give the path for file: ");
                filePath = Console.ReadLine();
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                if (filePath.IsImage(out IsImageExtension.ImageType type))
                {
                    FileStream fsSource = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    string ext = type.ToString().ToLower();
                    var img = IsImageExtension.GetResolution(fsSource, type);
                    Console.WriteLine($"This is a {ext} image. Resolution: {img} pixels.");

                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    Console.WriteLine($"File Size in Bytes:  {bytes.Length}");
                }
                else
                {
                    Console.WriteLine($"This is a not a valid .bmp or .png file!");
                }
            }
        }
    }
    public static class IsImageExtension
    {
        static List<string> bmp;
        static List<string> png;
        public enum ImageType
        {
            BMP,
            PNG,
            NONE
        }
        public static string GetResolution(FileStream fileStream, ImageType imgType)
        {
            var data = new byte[8];
            var width = 0;
            var height = 0;

            switch (imgType)
            {
                case ImageType.BMP:
                    fileStream.Seek(18, SeekOrigin.Begin);
                    fileStream.Read(data, 0, 8);

                    width = data[0] + (data[1] << 8) + (data[2] << 16) + (data[3] << 24);
                    height = data[4] + (data[5] << 8) + (data[6] << 16) + (data[7] << 24);

                    return $"{width}x{height}";

                case ImageType.PNG:
                    fileStream.Seek(16, SeekOrigin.Begin);
                    fileStream.Read(data, 0, 8);

                    width = data[3] + (data[2] << 8) + (data[1] << 16) + (data[0] << 24);
                    height = data[7] + (data[6] << 8) + (data[5] << 16) + (data[4] << 24);

                    return $"{width} x {height}";
            }
            return null;
        }

        const string BMP = "42";
        const string PNG = "89";

        static IsImageExtension()
        {
            bmp = new List<string> { "42", "4D" };
            png = new List<string> { "89", "50", "4E", "47", "0D", "0A", "1A", "0A" };
        }

        public static bool IsImage(this string file, out ImageType type)
        {
            type = ImageType.NONE;
            if (string.IsNullOrWhiteSpace(file)) return false;
            if (!File.Exists(file)) return false;
            using (var stream = File.OpenRead(file))
                return stream.IsImage(out type);
        }

        public static bool IsImage(this Stream stream, out ImageType type)
        {
            type = ImageType.NONE;
            stream.Seek(0, SeekOrigin.Begin);
            string bit = stream.ReadByte().ToString("X2");
            switch (bit)
            {
                case BMP:
                    if (stream.IsImage(bmp))
                    {
                        type = ImageType.BMP;
                        return true;
                    }
                    break;

                case PNG:
                    if (stream.IsImage(png))
                    {
                        type = ImageType.PNG;
                        return true;
                    }
                    break;
            }
            return false;
        }
        public static bool IsImage(this Stream stream, List<string> comparer)
        {
            stream.Seek(0, SeekOrigin.Begin);
            foreach (string c in comparer)
            {
                string bit = stream.ReadByte().ToString("X2");
                if (0 != string.Compare(bit, c))
                    return false;
            }
            return true;
        }
    }
}
