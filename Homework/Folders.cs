using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    public class Folders
    {
        public static string CreateFolders(string path)
        {
            string folder = Path.GetDirectoryName(path);
            string[] extensions = new string[] { ".txt", ".html", ".doc", ".pdf", ".asf" };
            Random random = new Random();

            int counter = 1;

            while (counter <= 10)
            {
                if (!Directory.Exists(folder))
                {
                    DirectoryInfo homeworkDirectory = Directory.CreateDirectory(folder + counter + "\\");
                    for (int i = 1; i <= 10; i++)
                    {
                        DirectoryInfo homeworkSubDirectory = Directory.CreateDirectory(folder + counter + "\\" + i);
                        for (int j = 1; j <= 10; j++)
                        {
                            FileStream subFile = File.Create(folder + counter + "\\" + i + "\\" + j + extensions[random.Next(extensions.Length)]);
                            subFile.Close();
                        }
                    }

                }
                counter++;
            }
            return path;
        }
    }
}
