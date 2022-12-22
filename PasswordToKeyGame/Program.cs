using System;
using System.Configuration;
using System.Data.OleDb;
using System.Xml.XPath;
using System.Threading;
using System.Reflection.Emit;
using System.Data;


namespace PasswordToKeyGame
{
    internal class Program
    {
        static void MainMenu()
        {
            Random random = new Random();
            int Number = random.Next(1, 3);
            string prompt = @"
▓█████▄  ██▀███ ▓██   ██▓ ██▓ ███▄    █   ▄████      ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
▒██▀ ██▌▓██ ▒ ██▒▒██  ██▒▓██▒ ██ ▀█   █  ██▒ ▀█▒    ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
░██   █▌▓██ ░▄█ ▒ ▒██ ██░▒██▒▓██  ▀█ ██▒▒██░▄▄▄░   ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
░▓█▄   ▌▒██▀▀█▄   ░ ▐██▓░░██░▓██▒  ▐▌██▒░▓█  ██▓   ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
░▒████▓ ░██▓ ▒██▒ ░ ██▒▓░░██░▒██░   ▓██░░▒▓███▀▒   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
 ▒▒▓  ▒ ░ ▒▓ ░▒▓░  ██▒▒▒ ░▓  ░ ▒░   ▒ ▒  ░▒   ▒     ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░
 ░ ▒  ▒   ░▒ ░ ▒░▓██ ░▒░  ▒ ░░ ░░   ░ ▒░  ░   ░      ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░
 ░ ░  ░   ░░   ░ ▒ ▒ ░░   ▒ ░   ░   ░ ░ ░ ░   ░    ░ ░   ░   ░   ▒   ░      ░      ░   
   ░       ░     ░ ░      ░           ░       ░          ░       ░  ░       ░      ░  ░
 ░               ░ ░                                                                   
";
            Console.WriteLine(prompt);

            string[] options = { "Register ", "Sign In"};
            Menu mainMenu = new Menu(options);
            int selectedIndex = mainMenu.Run();
            
            switch(selectedIndex)
            {
                case 0:
                    RegisterMenu(); ;
                    break;
                case 1:
                        SignInMenu();
                    break;
            }
        }
        static void RegisterMenu()
        {
            Console.Clear();
            Console.Write("ple enter your user name --> ");

            string NewUserName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("pls enter your password --> ");
            string NewPassword = Console.ReadLine();

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = $"INSERT INTO UserNameAndPassword ([UserName], [Password]) VALUES ('{NewUserName}', '{NewPassword}')";

            command.ExecuteNonQuery();

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
        static void SignInMenu()
        {
            Console.Clear();
            Console.Write("pls Enter your User Name --> ");

            string UserName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("pls Enter your Password --> ");
            string PasswordClient = Console.ReadLine();

            Password(UserName, PasswordClient);
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
        static void UserNameAndPasswordInsert()
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
        static void ACCDB_Type_File()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = "SELECT UserName, Password FROM UserNameAndPassword";
            OleDbDataReader reader = command.ExecuteReader();

            string UserName, Password;

            while (reader.Read())
            {
                UserName = reader.GetString(0);

                Password = reader.GetString(1);

                Console.WriteLine(UserName + " " + Password);
            }
        }
        static void Password(string UserName, string PasswordClient)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Access\UserName and Passowrd.accdb""";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("", connection);

            connection.Open();
            command.CommandText = $"SELECT UserName, Password FROM UserNameAndPassword WHERE UserName = '{UserName}' AND Password = '{PasswordClient}'";
            OleDbDataReader reader = command.ExecuteReader();

            bool FoundIt = false;

            while (reader.Read())
                FoundIt = true;

            if (FoundIt)
            {
                Console.Write("\nyou may enter");

                Thread.Sleep(1000);

                for (int k = 0; k < 3; k++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }

                Console.Clear();

                Paint();
            }

            else
                Console.WriteLine("\nyou've enterd the wrong UserName or Password");
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
        }
    }
}
