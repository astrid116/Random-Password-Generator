using System;

namespace Random_Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] abcArr= {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] numArr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] specArr = { "+", "!", "%", "/", "=", ",", "?", ".", ":", "-", "_" };
            string input;
            int charLimit;
            bool useAbc;
            bool useNum;
            bool useSpec;
            int randomObj;
            int randomIndex;
            string randomChar;
            int i = 0;

            while (true)
            {
                while (true)
                {
                    Console.Write("Do you want to use letters? (y/n): ");
                    input = Console.ReadLine();
                    try
                    {
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
                    catch
                    {
                        Console.WriteLine("Wrong input. Use 'y' for yes, or 'n' for no.");
                    }
                }

                while (true)
                {
                    Console.Write("Do you want to use numbers? (y/n): ");
                    input = Console.ReadLine();
                    try
                    {
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
                    catch
                    {
                        Console.WriteLine("Wrong input. Use 'y' for yes, or 'n' for no.");
                    }
                }

                while (true)
                {
                    Console.Write("Do you want to use special characters? (y/n): ");
                    input = Console.ReadLine();
                    try
                    {
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
                    catch
                    {
                        Console.WriteLine("Wrong input. Use 'y' for yes, or 'n' for no.");
                    }
                }

                while (true)
                {
                    Console.Write("Specify the character limit: ");
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

                var passwd = new string[charLimit];
                while (i < charLimit)
                {
                    randomObj = rnd.Next(1, 4);
                    if (randomObj == 1)
                    {
                        if (useAbc)
                        {
                            randomIndex = rnd.Next(0, abcArr.Length);
                            randomChar = abcArr[randomIndex].ToString();
                            passwd[i] = randomChar;
                        }
                    }
                    else if (randomObj == 2)
                    {
                        if (useNum)
                        {
                            randomIndex = rnd.Next(0, numArr.Length);
                            randomChar = numArr[randomIndex].ToString();
                            passwd[i] = randomChar;
                        }
                    }
                    else if (randomObj == 3)
                    {
                        if (useSpec)
                        {
                            randomIndex = rnd.Next(0, specArr.Length);
                            randomChar = specArr[randomIndex].ToString();
                            passwd[i] = randomChar;
                        }
                    }
                    i++;
                }
                Console.Write("\nYour password is: ");
                for (int j = 0; j < passwd.Length; j++)
                {
                    Console.Write(passwd[j]);
                }




                try
                {
                    Console.Write("\nDo you want to generate an another password? (y/n): ");
                    input = Console.ReadLine();
                    if (input == "n")
                    {
                        Environment.Exit(0);
                    }
                    else if (input == "y")
                    {
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong input format. Use 'y' for yes, or 'n' for no.");
                }
                i = 0;
            }
        }
    }
}