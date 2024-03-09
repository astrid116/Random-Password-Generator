using System;

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
            int randomIndex;


            while (true)
            {
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
                                randomIndex = rnd.Next(0, abcArr.Length);
                                passwd[i] = abcArr[randomIndex];
                            }
                            else
                            {
                                i--;
                            }
                            break;
                        case 2:
                            if (useNum)
                            {
                                randomIndex = rnd.Next(0, numArr.Length);
                                passwd[i] = numArr[randomIndex];
                            }
                            else
                            {
                                i--;
                            }
                            break;
                        case 3:
                            if (useSpec)
                            {
                                randomIndex = rnd.Next(0, specArr.Length);
                                passwd[i] = specArr[randomIndex];
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



                Console.WriteLine("\n\n");
                while (true)
                {
                    Console.Write("Do you want to generate an another password? (y/n): ");
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
    }
}