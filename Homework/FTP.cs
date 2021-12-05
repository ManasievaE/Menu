using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class FTP
    {
        string host = "ftp://82.214.114.2:21";
        string UserId = "bojan_academy";
        string Password = "qjeK7#88";
        string path = "/TestFtpEM";
        string localFile = @"C:\DAHomework";
        string uploadFile = "/EmiM.txt";

        // We need FTP host, username and pass
        public bool CreateFolder()
        {
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create("ftp://" + host + path);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(UserId, Password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (Exception)
            {
                IsCreated = false;
            }
            return IsCreated;
        }
        // Check if folder exist or not
        public bool DoesFtpDirectoryExist(string dirPath)
        {
            bool isexist = false;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(dirPath);
                request.Credentials = new NetworkCredential(UserId, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isexist = true;
                    Console.WriteLine("The directory exists");
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isexist;
        }
        public void UploadFile()
        {
            
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(UserId, Password);
                client.UploadFile(host + path + uploadFile, localFile + uploadFile);
            }
        }
        
    }
}
