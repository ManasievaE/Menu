using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class LeoMenu
    {
            #region Properties
            public string InitialSelector { get; set; }
            public string EmailSubmenu { get; set; }
            public string EmailAddress { get; set; }
            public string EmailSubject { get; set; }
            public string EmailBody { get; set; }
            public string EmailAmend { get; set; }
            public string FtpPath { get; set; }
            public string FtpHost { get; set; }
            public int FtpPort { get; set; }
            public string FtpUserId { get; set; }
            public string FtpPassword { get; set; }
            #endregion
            public static void CreateMenu()
            {
                LeoMenu menu = new LeoMenu();
                FTP ftp = new FTP();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello and welcome to our console application.\n");

                do
                {
                Quit:
                    Console.WriteLine("Please select one of the following options:\n 1. Send email\n 2. Create FTP backup.\n 3. Quit");
                    menu.InitialSelector = Console.ReadLine();
                    if (menu.InitialSelector == "1")
                    {
                        do
                        {
                            Console.WriteLine("Please enter valid email address:\nFor ex: test@test.test");

                            // TODO cyrilic support
                            menu.EmailAddress = Console.ReadLine();
                            if (menu.EmailAddress.Contains("@"))
                            {
                                BuildEmail.To = menu.EmailAddress;
                            }
                            else
                            {
                                while (!menu.EmailAddress.Contains("@"))
                                {
                                    Console.WriteLine("Email address is not valid - please try again.");
                                    menu.EmailAddress = Console.ReadLine();
                                    BuildEmail.To = menu.EmailAddress;
                                }
                            }
                            Console.WriteLine("Please enter the subject of the message: ");
                            menu.EmailSubject = Console.ReadLine();
                            BuildEmail.Subject = menu.EmailSubject;
                            Console.WriteLine("Please enter the body of the message: ");
                            menu.EmailBody = Console.ReadLine();
                            BuildEmail.Body = menu.EmailBody;
                        comeBackAgain:
                            Console.WriteLine("Would you like to send the email? Y/N");
                            menu.EmailSubmenu = Console.ReadLine().ToLower();
                            if (menu.EmailSubmenu == "y")
                            {
                                BuildEmail.SendMailCustomBody();
                                Console.WriteLine("Message sent.");
                                break;
                            }
                            else if (menu.EmailSubmenu == "n")
                            {
                            comeBackHere:
                                Console.WriteLine("Would you like to amend the email? Y/N");
                                menu.EmailAmend = Console.ReadLine().ToLower();
                                if (menu.EmailAmend == "y")
                                {
                                    Console.WriteLine("Would you like to change the subject of the message, or the body?\nPress \"S\" for subject, or \"B\" for body.");
                                    string emailChanger = Console.ReadLine().ToLower();
                                    if (emailChanger == "s")
                                    {
                                        Console.WriteLine("Please add the new subject:");
                                        menu.EmailSubject = Console.ReadLine();
                                        BuildEmail.Subject = menu.EmailSubject;
                                        BuildEmail.SendMailCustomBody();
                                        Console.WriteLine("Message sent.");
                                        break;
                                    }
                                    else if (emailChanger == "b")
                                    {
                                        Console.WriteLine("Please add the new body:");
                                        menu.EmailBody = Console.ReadLine();
                                        BuildEmail.Body = menu.EmailBody;
                                        BuildEmail.SendMailCustomBody();
                                        Console.WriteLine("Message sent.");
                                        break;
                                    }
                                    else
                                    {
                                        while (emailChanger != "s" || emailChanger != "b")
                                        {
                                            Console.WriteLine("Wrong selection - please try again.");
                                            goto comeBackHere;
                                        }
                                    }
                                }
                                else if (menu.EmailAmend == "n")
                                {
                                    goto Quit;
                                }
                                else
                                {
                                    while (menu.EmailAmend != "s" || menu.EmailAmend != "b")
                                    {
                                        Console.WriteLine("Wrong selection - please try again.");
                                        goto comeBackHere;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong selection - please try again.");
                                goto comeBackAgain;

                            }
                        }
                        while (true);
                    }
                    else if (menu.InitialSelector == "2")
                    {
                        //newPath:
                        //    Console.WriteLine("Please provide a path for your local file:");
                        //    var tempPath = String.Format("ftp://" + Console.ReadLine());
                        //    menu.FtpPath = Path.GetDirectoryName(tempPath);
                        //    Console.WriteLine("Please enter host:");
                        //    menu.FtpHost = Console.ReadLine();
                        //    Console.WriteLine("Please enter port:");
                        //    menu.FtpPort = Convert.ToInt32(Console.ReadLine());
                        //    Console.WriteLine("Please enter user Id:");
                        //    menu.FtpUserId = Console.ReadLine();
                        //    Console.WriteLine("Please enter password:");
                        //    menu.FtpPassword = Console.ReadLine();

                        //if (ftp.DoesFtpDirectoryExist(tempPath, menu.FtpUserId, menu.FtpPassword))
                        //{
                        //    Console.WriteLine("Folder already exists, please choose another path.");
                        //    goto newPath;
                        //}
                        //else
                        //{
                        //Console.WriteLine("Folder doesn't exist.");
                        Console.WriteLine(ftp.CreateFolder());
                        ftp.UploadFile();
                        //}
                    }
                    else if (menu.InitialSelector == "3")
                    {
                        Console.WriteLine("Have a nice day :)");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid character.");
                    }

                }
                while (true);
            }
    }
  
}
