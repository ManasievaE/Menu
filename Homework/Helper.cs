using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Homework
{
    public class Helper
    {
        
        #region FilesAndFolders

        public static void RemoveFilesWithExtension(string folderPath, string fileExtension)
        {
            string folder = Path.GetDirectoryName(folderPath);
            var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                {
                    if (files[i].Contains(fileExtension))
                    {
                        File.Delete(files[i]);
                    }
                }

            }
            Console.WriteLine("Files Deleted");

        }
        public class RemoveFilesWithExtensionTakenFromInput
        {
            public static void RemoveFromInput(string path)
            {
                string folder = Path.GetDirectoryName(path);

                Console.WriteLine("Insert the type of extension: ");
                var extensionToRemove = Console.ReadLine();

                var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    {
                        if (files[i].Contains(extensionToRemove))
                        {
                            File.Delete(files[i]);
                        }
                    }

                }
                Console.WriteLine("Files Removed");
            }
        }
        public static bool CheckIfPathIsFile(string filePath)
        {
            bool result = false;
            FileAttributes attr = File.GetAttributes(filePath);

            // to see if its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                Console.WriteLine("It's a directory");
                result = false;
            }
            else
            {
                Console.WriteLine("It's a file");
                result = true;
            }
; return result;





        }
        public static void BackupFolder(string sourcePath, string targetPath, int location)
        {
            // 1(location) for local comp
            // 2(location) for remote comp

            // C# code for FTP to do

            var listDirectories = Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories);
            var listFiles = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            if (Directory.Exists(sourcePath))
            {
                //Now create all of the directories
                foreach (string dirPath in listDirectories)
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }
                // Copy all of the fileas and replaces any files with the same name
                foreach (string newPath in listFiles)
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                }
            }
            else
            {
                Console.WriteLine("Wrong Path.");
            }
        }
        #endregion

        #region Numbers
        public static Int32 TryParseInt(string value)
        {
            int number;

            bool result = Int32.TryParse(value, out number);

            if (result)
            {
                return number;
            }
            else
            {
                return int.MinValue;  // or if value is invalid return -1; 
            }
        }
        public static bool CheckValidDecimal(string number)
        {

            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.Number;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            decimal result;

            if (Decimal.TryParse(number, style, culture, out result))
            {
                return true;
            }
            else
                return false;


        }
























        #endregion
    }
}
