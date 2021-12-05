using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Homework
{
    public class Menu
    {
        #region Properties
        public string chosenNumber { get; set; }
        public string emailAddress { get; set; }
        public string fromAddress { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string emailSend { get; set; }
        public string ftpPath { get; set; }
        public string ftpHost { get; set; }
        public string ftpUserId { get; set; }
        public string ftpPassword { get; set; }
        public int ftpPort { get; set; }

        #endregion
        public static void CreateMenu()
        {
            Menu menu = new Menu();
            FTP ftp = new FTP();
            Console.WriteLine("         WELCOME!         ");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Please select an option:\n 1. Send email\n 2. Create FTP backup\n 3. Quit");
                menu.chosenNumber = Console.ReadLine();
                if (menu.chosenNumber == "1")
                {
                    do
                    {
                        Console.WriteLine("Mail To: ");
                        menu.emailAddress = Console.ReadLine();
                        BuildEmail.To = menu.emailAddress;
                        Console.WriteLine("Mail From: ");
                        menu.fromAddress = Console.ReadLine();
                        BuildEmail.From = menu.fromAddress;
                        Console.WriteLine("Subject: ");
                        menu.emailSubject = Console.ReadLine();
                        BuildEmail.Subject = menu.emailSubject;
                        Console.WriteLine("Your Message: ");
                        menu.emailBody = Console.ReadLine();
                        BuildEmail.Body = menu.emailBody;
                        Console.WriteLine("Would you like to send the email? y/n ");
                        menu.emailSend = Console.ReadLine();
                        if (menu.emailSend == "y")
                        {
                            BuildEmail.SendMailCustomBody();
                            Console.WriteLine("Message send.");
                            break;
                        }
                        else if (menu.emailSend == "n")
                        {
                            Console.WriteLine("Message not send.");
                        }
                        else
                        {
                            while (menu.emailSend != "y" || menu.emailSend != "n")
                            {
                                Console.WriteLine("Invalid character, please try again!");
                                break;
                            }

                        }
                    } while (true);
                }
                else if (menu.chosenNumber == "2")
                {
                  newPath:
                    Console.WriteLine("Enter a path for your local file: ");
                    var enterPath = "ftp://" + Console.ReadLine();
                    menu.ftpPath = Path.GetDirectoryName(enterPath);
                    Console.WriteLine("Enter Host: ");
                    menu.ftpHost = Console.ReadLine();
                    Console.WriteLine("Enter Port: ");
                    menu.ftpPort = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter User ID: ");
                    menu.ftpUserId = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    menu.ftpPassword = Console.ReadLine();

                    if (ftp.DoesFtpDirectoryExist(enterPath))
                    {
                        Console.WriteLine("Folder already exists./n Try another path!");
                        goto newPath;
                    }
                    else
                    {
                        Console.WriteLine("Folder doesn't exist");
                        Console.WriteLine((ftp.CreateFolder()));
                        ftp.UploadFile();
                    }

                }
                else if (menu.chosenNumber == "3")
                {
                    Console.WriteLine("              Have a nice day!              ");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter one of the following numbers: 1, 2 or 3");
                }

            }
            while (true);
        }
    }
}
