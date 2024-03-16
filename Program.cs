using System;
using System.IO;

namespace Random_Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string input;
            string[] abcArr = { "a", "A", "b", "B", "c", "C", "d", "D", "e", "E", "f", "F", "g", "G", "h", "H", "i", "I", "j", "J", "k", "K", "l", "L", "m", "M", "n", "N", "o", "O", "p", "P", "q", "Q", "r", "R", "s", "S", "t", "T", "u", "U", "v", "V", "w", "W", "x", "X", "y", "Y", "z", "Z" };
            string[] numArr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] specArr = { "+", "!", "%", "/", "=", ",", "?", ".", ":", "-", "_", "%", ";", "*", "#", "@", "[", "]", "(", ")", "{", "}", "~", "´", "'" };
            bool useAbc;
            bool useNum;
            bool useSpec;
            int charLimit;
            int randomObj;


            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("gen, list, remove");
                    Console.Write("> ");
                    input = Console.ReadLine();
                    if (input == "gen")
                    {
                        break;
                    }
                    else if (input == "list")
                    {
                        Console.Write("Specify the platform, or write '*' to list all the passwords: ");
                        input = Console.ReadLine();
                        ListPassword(input);
                    }
                    else if (input == "remove")
                    {
                        string password;
                        Console.Write("Specify the password that you want to delete, or write '*' to clear all the saved passwords: ");
                        password = Console.ReadLine();
                        RemovePassword(password);
                    }
                }


                while (true)
                {
                    Console.Write("Do you want to use letters? (y/n): ");
                    input = Console.ReadLine();
                    if (input == "y")
                    {
                        useAbc = true;
                        break;
                    }
                    else if (input == "n")
                    {
                        useAbc = false;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Do you want to use numbers? (y/n): ");
                    input = Console.ReadLine();
                    if (input == "y")
                    {
                        useNum = true;
                        break;
                    }
                    else if (input == "n")
                    {
                        useNum = false;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Do you want to use special characters? (y/n): ");
                    input = Console.ReadLine();
                    if (input == "y")
                    {
                        useSpec = true;
                        break;
                    }
                    else if (input == "n")
                    {
                        useSpec = false;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Specify the password limit: ");
                    input = Console.ReadLine();
                    try
                    {
                        charLimit = Convert.ToInt32(input);
                        if (charLimit <= 0)
                        {
                            Console.WriteLine("Wrong input. Use positive integers.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input. Use positive integers.");
                    }
                }


                int i = 0;
                var passwd = new string[charLimit];
                do
                {
                    randomObj = rnd.Next(1, 4);
                    switch (randomObj)
                    {
                        case 1:
                            if (useAbc)
                            {
                                passwd[i] = abcArr[rnd.Next(0, abcArr.Length)];
                            }
                            else
                            {
                                i--;
                            }
                            break;
                        case 2:
                            if (useNum)
                            {
                                passwd[i] = numArr[rnd.Next(0, numArr.Length)];
                            }
                            else
                            {
                                i--;
                            }
                            break;
                        case 3:
                            if (useSpec)
                            {
                                passwd[i] = specArr[rnd.Next(0, specArr.Length)];
                            }
                            else
                            {
                                i--;
                            }
                            break;
                    }
                    i++;
                } while (i < charLimit);

                Console.Write("\n\nYour password is: ");
                for (int j = 0; j < passwd.Length; j++)
                {
                    Console.Write(passwd[j]);
                }

                Console.Write("\nDo you want to save the password? (y/n): ");
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "y")
                    {
                        SavePassword(passwd);
                        break;
                    }
                    else if (input == "n")
                    {
                        break;
                    }
                }

                Console.Write("\n");
                while (true)
                {
                    Console.Write("Do you want to generate an another password, or list a password? (y/n): ");
                    input = Console.ReadLine();
                    if (input == "y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (input == "n")
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        static void SavePassword(string[] passwd)
        {
            DateTime currentTime = DateTime.Now;
            string savedPasswdPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Saved_Passwd.txt";
            string platform;
            string username;

            if (!File.Exists(savedPasswdPath))
            {
                File.Create(savedPasswdPath);
                File.SetAttributes(savedPasswdPath, FileAttributes.Hidden);
            }

            Console.Write("Specify the platform: ");
            platform = Console.ReadLine();

            Console.Write("Specify the username: ");
            username = Console.ReadLine();

            File.SetAttributes(savedPasswdPath, FileAttributes.Normal);
            using (StreamWriter sw = new StreamWriter(savedPasswdPath, true))
            {
                sw.Write("Platform: {0} ; Username: {1} ; ", platform, username);
                sw.Write("Password: ");
                foreach (string s in passwd)
                {
                    sw.Write(s);
                }
                sw.Write(" ; Password Generated At: {0}\n", currentTime);
                sw.Close();
            }
            File.SetAttributes(savedPasswdPath, FileAttributes.Hidden);
        }

        static void ListPassword(string platform)
        {
            string savedPasswdPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Saved_Passwd.txt";

            if (!File.Exists(savedPasswdPath))
            {
                Console.WriteLine("Currently you don't have any saved passwords.");
            }
            else
            {
                Console.WriteLine("\n");
                if (platform == "*")
                {
                    using (StreamReader sr = new StreamReader(savedPasswdPath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line + "\n");
                        }
                        sr.Close();
                    }
                }
                else
                {
                    using (StreamReader sr = new StreamReader(savedPasswdPath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("Platform: " + platform))
                            {
                                Console.WriteLine(line);
                                Console.WriteLine("\n");
                            }
                        }
                        sr.Close();
                    }
                }
            }
        }

        static void RemovePassword(string password)
        {
            string savedPasswdPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Saved_Passwd.txt";

            if (!File.Exists(savedPasswdPath))
            {
                Console.WriteLine("Currently you don't have any saved passwords.");
            }
            else
            {
                if (password == "*")
                {
                    File.SetAttributes(savedPasswdPath, FileAttributes.Normal);
                    using (var sw = new StreamWriter(savedPasswdPath))
                    File.SetAttributes(savedPasswdPath, FileAttributes.Hidden);
                }
                else if (password == "")
                {
                    Console.WriteLine("Invalid input.\n");
                }
                else
                {
                    string tempFile = Path.GetTempFileName();

                    File.SetAttributes(savedPasswdPath, FileAttributes.Normal);
                    using (var sr = new StreamReader(savedPasswdPath))
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (!line.Contains(password))
                            {
                                sw.WriteLine(line);
                            }
                        }
                        sw.Close();
                        sr.Close();
                    }
                    File.Delete(savedPasswdPath);
                    File.Move(tempFile, savedPasswdPath);
                    File.SetAttributes(savedPasswdPath, FileAttributes.Hidden);
                }
            }
        }
    }
}