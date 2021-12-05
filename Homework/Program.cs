using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Homework
{   
    class Program
    {
        static void Main(string[] args)
        {

            Menu.CreateMenu();


            //var testFtp = new FTP();

            //testFtp.host = "ftp://82.214.114.2:21";
            //testFtp.UserId = "bojan_academy";
            //testFtp.Password = "qjeK7#88";
            //testFtp.path = "/TestFtpEM";
            //testFtp.localFile = @"C:\DAHomework";
            //testFtp.uploadFile = "/Emilija.txt";

            //testFtp.CreateFolder();
            //testFtp.DoesFtpDirectoryExist("ftp://82.214.114.2:21/TestFtpEM");
            //testFtp.UploadFile();




            /*BuildEmail testEmail = new BuildEmail();

            BuildEmail.To = "emilija.manasieva@fon.edu.mk";
            BuildEmail.CC = "lazoboz333@gmail.com";
            BuildEmail.BCC = "emi.macedonia@hotmail.com";
            BuildEmail.Body = "IF YOU GET THIS EMAIL, GO TO SLEEP!";
            BuildEmail.Subject = "Test Email Via C#";

            
            if (BuildEmail.SendMailCustomBody())
            {
                Console.WriteLine("Bravo!!! :)");
            }
            else
            {
                Console.WriteLine("Try harder next time! :)");
            }



            //var path = @"C:\DAHomework\Basic\";
            //var longerPath = @"C:\DAHomework\";
            //var filePath = @"C:\Homework\basic2\2\3.pdf";
            //var sourcePath = @"C:\Homework\basic2";
            //var targetPath = @"C:\tmp\";
            //int location = 1;

            //Folders.CreateFolders(path);
            //Helper.RemoveFilesWithExtension(longerPath, ".txt");
            //Helper.RemoveFilesWithExtensionTakenFromInput.RemoveFromInput(longerPath);
            //Helper.CheckIfPathIsFile(longerPath);
            //Helper.BackupFolder(sourcePath, targetPath, location);*/
        }
    }
}
