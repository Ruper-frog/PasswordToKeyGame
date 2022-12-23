using System;
using System.Configuration;
using System.Data.OleDb;
using System.Xml.XPath;
using System.Threading;
using System.Reflection.Emit;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Lifetime;

namespace PasswordToKeyGame
{
    internal class Program
    {
        static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string prompt = @"
▓█████▄  ██▀███   ▄▄▄       █     █░ ██▓ ███▄    █   ▄████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
▒██▀ ██▌▓██ ▒ ██▒▒████▄    ▓█░ █ ░█░▓██▒ ██ ▀█   █  ██▒ ▀█▒    ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
░██   █▌▓██ ░▄█ ▒▒██  ▀█▄  ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒▒██░▄▄▄░   ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
░▓█▄   ▌▒██▀▀█▄  ░██▄▄▄▄██ ░█░ █ ░█ ░██░▓██▒  ▐▌██▒░▓█  ██▓   ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
░▒████▓ ░██▓ ▒██▒ ▓█   ▓██▒░░██▒██▓ ░██░▒██░   ▓██░░▒▓███▀▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
 ▒▒▓  ▒ ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒  ░▒   ▒     ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░
 ░ ▒  ▒   ░▒ ░ ▒░  ▒   ▒▒ ░  ▒ ░ ░   ▒ ░░ ░░   ░ ▒░  ░   ░      ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░
 ░ ░  ░   ░░   ░   ░   ▒     ░   ░   ▒ ░   ░   ░ ░ ░ ░   ░    ░ ░   ░   ░   ▒   ░      ░      ░   
   ░       ░           ░  ░    ░     ░           ░       ░          ░       ░  ░       ░      ░  ░
 ░                                                                                                
";
            Console.WriteLine(prompt);

            string[] options = { "Register ", "Sign In", "Exit"};
            Menu mainMenu = new Menu(options);
            int selectedIndex = mainMenu.Run();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            switch(selectedIndex)
            {
                case 0:
                    RegisterMenu();
                    break;
                case 1:
                    SignInMenu(0, 0, "");
                    break;
            }
            return;
        }
        static void RegisterMenu()
        {
            bool FoundIt = false;

            Console.Clear();
            Console.Write("ple enter your user name --> ");

            string NewUserName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("pls enter your password --> ");
            string NewPassword = Console.ReadLine();

            ACCDB_Type_File($"INSERT INTO UserNameAndPassword ([UserName], [Password]) VALUES ('{NewUserName}', '{NewPassword}')", false, ref FoundIt);

            Console.Write("You've Registered successfully");

            Thread.Sleep(1000);

            for (int k = 0; k < 3; k++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }

            Console.Clear();

            MainMenu();
        }
        static void SignInMenu(int NumberOfTimesHeGotTheUserNameWrong, int NumberOfTimesHeGotThePasswordWrong, string UserName)
        {
            string UserNameString = "pls Enter your User Name --> ";

            if (NumberOfTimesHeGotThePasswordWrong == 0)
            {
                Console.Clear();

                Console.Write(UserNameString + "\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(UserNameString.Length, 0);

                UserName = Console.ReadLine();

                if (UserNameClient(UserName) == false)
                {
                    NumberOfTimesHeGotTheUserNameWrong++;
                    if (NumberOfTimesHeGotTheUserNameWrong != 4)
                        SignInMenu(NumberOfTimesHeGotTheUserNameWrong, NumberOfTimesHeGotThePasswordWrong, UserName);
                    else
                    {
                        Console.WriteLine("\nyou've tried to meny times pls go register first");
                        Thread.Sleep(4000);

                        Console.Clear();
                        MainMenu();
                    }
                }
            }

            Console.Clear();

            Console.WriteLine(UserNameString + UserName);

            Console.Write("\npls Enter your Password --> \t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(28, 2);

            string PasswordClient = Console.ReadLine();

            if (Password(UserName, PasswordClient) == false)
            {
                NumberOfTimesHeGotThePasswordWrong++;

                if (NumberOfTimesHeGotThePasswordWrong != 4)
                    SignInMenu(NumberOfTimesHeGotThePasswordWrong, NumberOfTimesHeGotThePasswordWrong, UserName);
                else
                {
                    Console.WriteLine("\nyou've tried to meny times pls go Update your Password");
                    Thread.Sleep(4000);

                    Console.Clear();
                    UpdateMenu(UserName);
                }
            }
        }
        static void UpdateMenu(string UserName)
        {
            bool FoundIt = false;

            Console.Write("pls Enter your new password --> ");
            string NewPassword = Console.ReadLine();

            ACCDB_Type_File($"UPDATE UserNameAndPassword SET [Password] = '{NewPassword}' WHERE UserName = '{UserName}'", false, ref FoundIt);

            Console.WriteLine("your Pass word was reset");
            Thread.Sleep(3000);

            Console.Clear();
            MainMenu();
        }
        static void UPDATEtry()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = $"UPDATE UserNameAndPassword SET [Password] = 'IGotIt' WHERE ID = 1";

            command.ExecuteNonQuery();
        }
        static void INSERTtry()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = $"INSERT INTO UserNameAndPassword ([UserName], [Password]) VALUES ('Noam', 'Boom')";

            command.ExecuteNonQuery();
        }
        static void UserNameAndPasswordMakingSomePasswords()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();

            Random random = new Random();

            int Start, Stop;

            int[] Char = new int[2];

            string Print, Print1 = "";

            for (int j = 1; j <= 4; j++)
            {
                Print1 = "";

                for (int i = 0; i < 30; i++)
                {
                    Char[0] = random.Next(1, 5);

                    switch (Char[0])
                    {
                        case 1:
                            {
                                Start = 97;
                                Stop = 123;
                            }
                            break;
                        case 2:
                            {
                                Start = 65;
                                Stop = 92;
                            }
                            break;
                        case 3:
                            {
                                Start = 48;
                                Stop = 58;
                            }
                            break;
                        case 4:
                            {
                                Start = 35;
                                Stop = 39;
                            }
                            break;

                        default:
                            {
                                Start = 0;
                                Stop = 0;
                            }
                            break;
                    }

                    Char[1] = random.Next(Start, Stop);

                    Print = Convert.ToString(Convert.ToChar(Char[1]));

                    Print1 = Print1 + Print;
                }
                command.CommandText = $"UPDATE UserNameAndPassword SET [Password] = '{Print1}' WHERE ID = {j}";
                command.ExecuteNonQuery();

                Console.WriteLine(Print1);
            }
        }
        static void MDB_Type_File()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\worldcup.mdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = "Select DISTINCT HomeTeamName FROM WorldCupMatches";
            OleDbDataReader reader = command.ExecuteReader();

            string country;

            while (reader.Read())
            {
                country = reader.GetString(0);

                Console.WriteLine(country);
            }
        } 
        static void ACCDB_Type_File(string CommandText, bool ReadOrNot, ref bool FoundIt)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = CommandText;

            if (ReadOrNot)
            {
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    FoundIt = true;
            }
            else
                command.ExecuteNonQuery();
        }
        static bool UserNameClient(string UserName)
        {
            bool FoundIt = false;
            ACCDB_Type_File($"SELECT UserName FROM UserNameAndPassword WHERE UserName = '{UserName}'", true, ref FoundIt);

            if (!FoundIt)
            {
                Console.Write("you've enterd the wrong UserName");
                Thread.Sleep(1000);
            }
            
            return FoundIt;
        }
        static bool Password(string UserName, string PasswordClient)
        {
            bool FoundIt = false;

            ACCDB_Type_File($"SELECT UserName, Password FROM UserNameAndPassword WHERE UserName = '{UserName}' AND Password = '{PasswordClient}'", true, ref FoundIt);

            if (FoundIt)
            {
                Console.Write("you may enter");

                Thread.Sleep(1000);

                for (int k = 0; k < 3; k++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }

                Console.Clear();

                Console.ResetColor();

                Paint();
            }

            else
            {
                Console.Write("you've enterd the wrong Password");
                Thread.Sleep(1000);
            }
            return FoundIt;
        }
        static void Paint()
        {
            ConsoleKeyInfo keyinfo;
            char s = '*';
            bool penDown = true;
            int x = 0, y = 0;

            // MENU //
            Console.SetCursorPosition(1, 20);
            Console.WriteLine("____________________________________");
            Console.WriteLine("C- Clear Screen, P- Change Pen, L- Change Color, U- Pen Up, D- Pen Down, Escape - Exit");
            Console.SetCursorPosition(1, 1);

            keyinfo = Console.ReadKey();

            while (keyinfo.Key != ConsoleKey.Escape)
            {
                keyinfo = Console.ReadKey();

                // Move corsore
                if (keyinfo.Key == ConsoleKey.RightArrow) x++;
                if (keyinfo.Key == ConsoleKey.LeftArrow) x--;
                if (keyinfo.Key == ConsoleKey.DownArrow) y++;
                if (keyinfo.Key == ConsoleKey.UpArrow) y--;

                // Other menu keys

                if (keyinfo.Key == ConsoleKey.U) penDown = false;
                if (keyinfo.Key == ConsoleKey.D) penDown = true;
                if (keyinfo.Key == ConsoleKey.R) Console.BackgroundColor = ConsoleColor.Red;
                if (keyinfo.Key == ConsoleKey.W) Console.BackgroundColor = ConsoleColor.White;

                if (keyinfo.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    // MENU //
                    Console.SetCursorPosition(1, 20);
                    Console.WriteLine("____________________________________");
                    Console.WriteLine("C- Clear Screen, P- Change Pen, L- Change Color, U- Pen Up, D- Pen Down, Escape - Exit");
                    Console.SetCursorPosition(1, 1);
                }

                if (keyinfo.Key == ConsoleKey.P)
                {
                    if (s == '*')
                        s = '+';
                    else
                        s = '*';
                }

                // Set Cursoe Position and pain if pen is down.

                Console.SetCursorPosition(x, y);
                if (penDown) Console.Write(s);

            }
        }
        static void Main(string[] args)
        {
            MainMenu();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("It was nice to have you with us, come again");
            Console.ResetColor();
        }
    }
}
