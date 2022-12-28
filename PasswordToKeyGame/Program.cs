﻿using System;
using System.Collections;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace PasswordToKeyGame
{
    internal class Program
    {
        static string ToPush;

        static bool BackOrFor = true;

        static Stack Backwards = new Stack();
        static Stack Forwards = new Stack();

        static bool Left = false, Right = false;

        static string readLine;
        static void RunKeyboardClass(ref string readLine, int x_Axis, int y_Axis)
        {
            Keyboard KeyboardClass = new Keyboard(readLine, x_Axis, y_Axis);
            KeyboardClass.Call(ref readLine, ref Left, ref  Right);
        }
        static void StackFunction()
        {
            if (ToPush != null)
            {
                if (BackOrFor)
                    Backwards.Push(ToPush);
                else Forwards.Push(ToPush);
            }
            if (Backwards.Count == 0 && !Right)
            {
                Console.Clear();

                Console.WriteLine(@"
██╗   ██╗ ██████╗ ██╗   ██╗██╗   ██╗███████╗    ██████╗  █████╗ ███╗   ██╗     ██████╗ ██╗   ██╗████████╗
╚██╗ ██╔╝██╔═══██╗██║   ██║██║   ██║██╔════╝    ██╔══██╗██╔══██╗████╗  ██║    ██╔═══██╗██║   ██║╚══██╔══╝
 ╚████╔╝ ██║   ██║██║   ██║██║   ██║█████╗      ██████╔╝███████║██╔██╗ ██║    ██║   ██║██║   ██║   ██║   
  ╚██╔╝  ██║   ██║██║   ██║╚██╗ ██╔╝██╔══╝      ██╔══██╗██╔══██║██║╚██╗██║    ██║   ██║██║   ██║   ██║   
   ██║   ╚██████╔╝╚██████╔╝ ╚████╔╝ ███████╗    ██║  ██║██║  ██║██║ ╚████║    ╚██████╔╝╚██████╔╝   ██║  
   ╚═╝    ╚═════╝  ╚═════╝   ╚═══╝  ╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝     ╚═════╝  ╚═════╝    ╚═╝   
 
             ██████╗ ███████╗    ██████╗ ███████╗████████╗██╗   ██╗██████╗ ███╗   ██╗███████╗
            ██╔═══██╗██╔════╝    ██╔══██╗██╔════╝╚══██╔══╝██║   ██║██╔══██╗████╗  ██║██╔════╝
            ██║   ██║█████╗      ██████╔╝█████╗     ██║   ██║   ██║██████╔╝██╔██╗ ██║███████╗
            ██║   ██║██╔══╝      ██╔══██╗██╔══╝     ██║   ██║   ██║██╔══██╗██║╚██╗██║╚════██║
            ╚██████╔╝██║         ██║  ██║███████╗   ██║   ╚██████╔╝██║  ██║██║ ╚████║███████║
             ╚═════╝ ╚═╝         ╚═╝  ╚═╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝
                                                                                 
                                                                                 
                                                                                 
                                                                                 
                                                                                 
                                                                                 
                                                                                 
                                                                                 
                                                                                                                                        
");
                Thread.Sleep(3000);

                if (Forwards.Count == 0)
                    MainMenu();
                else
                    Right = true;
            }
            if (Forwards.Count == 0 && !Left && Backwards.Count == 0)
            {
                Console.Clear();

                Console.WriteLine(@"
██╗   ██╗ ██████╗ ██╗   ██╗     █████╗ ██████╗ ███████╗     █████╗ ██╗     ██████╗ ███████╗ █████╗ ██████╗ ██╗   ██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔══██╗██╔══██╗██╔════╝    ██╔══██╗██║     ██╔══██╗██╔════╝██╔══██╗██╔══██╗╚██╗ ██╔╝
 ╚████╔╝ ██║   ██║██║   ██║    ███████║██████╔╝█████╗      ███████║██║     ██████╔╝█████╗  ███████║██║  ██║ ╚████╔╝ 
  ╚██╔╝  ██║   ██║██║   ██║    ██╔══██║██╔══██╗██╔══╝      ██╔══██║██║     ██╔══██╗██╔══╝  ██╔══██║██║  ██║  ╚██╔╝  
   ██║   ╚██████╔╝╚██████╔╝    ██║  ██║██║  ██║███████╗    ██║  ██║███████╗██║  ██║███████╗██║  ██║██████╔╝   ██║   
   ╚═╝    ╚═════╝  ╚═════╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝    ╚═╝   

              ██████╗ ███╗   ██╗    ████████╗██╗  ██╗███████╗    ███╗   ███╗ ██████╗ ███████╗████████╗
             ██╔═══██╗████╗  ██║    ╚══██╔══╝██║  ██║██╔════╝    ████╗ ████║██╔═══██╗██╔════╝╚══██╔══╝
             ██║   ██║██╔██╗ ██║       ██║   ███████║█████╗      ██╔████╔██║██║   ██║███████╗   ██║   
             ██║   ██║██║╚██╗██║       ██║   ██╔══██║██╔══╝      ██║╚██╔╝██║██║   ██║╚════██║   ██║   
             ╚██████╔╝██║ ╚████║       ██║   ██║  ██║███████╗    ██║ ╚═╝ ██║╚██████╔╝███████║   ██║   
              ╚═════╝ ╚═╝  ╚═══╝       ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚═╝     ╚═╝ ╚═════╝ ╚══════╝   ╚═╝   

             ██████╗ ███████╗ ██████╗███████╗███╗   ██╗████████╗    ██████╗  █████╗  ██████╗ ███████╗
             ██╔══██╗██╔════╝██╔════╝██╔════╝████╗  ██║╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
             ██████╔╝█████╗  ██║     █████╗  ██╔██╗ ██║   ██║       ██████╔╝███████║██║  ███╗█████╗  
             ██╔══██╗██╔══╝  ██║     ██╔══╝  ██║╚██╗██║   ██║       ██╔═══╝ ██╔══██║██║   ██║██╔══╝  
             ██║  ██║███████╗╚██████╗███████╗██║ ╚████║   ██║       ██║     ██║  ██║╚██████╔╝███████╗
             ╚═╝  ╚═╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝       ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                                        
                                                                                                                                                                                     
                                                                                                                                                                                                                                                                                                             
");
                Thread.Sleep(3000);

                if (Backwards.Count == 0 && Backwards.Count == 0)
                    MainMenu();
                else
                    Left = true;
            }
                if (Left && Backwards.Count > 0)
                {
                    ToPush = Convert.ToString(Backwards.Pop());
                }
                else if (Right && Forwards.Count > 0)
                {
                    ToPush = Convert.ToString(Forwards.Pop());
                }
                if (Right || Left)
                {
                    Left = false;
                    Right = false;
                    BackOrFor = true;

                    switch (ToPush)
                    {
                        case "MainMenu":
                            MainMenu();
                            break;
                        case "RegisterMenu":
                            RegisterMenu();
                            break;
                        case "SignInMenu":
                            SignInMenu(0, 0, "");
                            break;
                    }
                }
                    ToPush = null;
        }
        static void MainMenu()
        {
            Console.Clear();

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

            string[] options = { "Register ", "Sign In", "Exit" };
            Menu mainMenu = new Menu(options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        ToPush = "MainMenu";
                        StackFunction();
                        RegisterMenu();
                    }
                    break;
                case 1:
                    {
                        ToPush = "MainMenu";
                        StackFunction();
                        SignInMenu(0, 0, "");
                    }
                    break;
                case 3:
                    {
                        Left = true;

                        if (Forwards.Count > 0)
                            ToPush = Convert.ToString(Forwards.Peek());

                        StackFunction();
                    }
                    break;
                case 4:
                    {
                        Right = true;

                        if (Backwards.Count > 0)
                            ToPush = Convert.ToString(Backwards.Peek());

                        StackFunction();
                    }
                    break;
            }
        }
        static void RegisterMenu()
        {
            bool FoundIt = false;

            string UserNameString = "ple enter your user name --> ", PasswordString = "pls enter your password --> ";

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write(@"
██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗ 
██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝
██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗
██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║
╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
");

            Console.Write(UserNameString);

            string NewUserName = "";

            RunKeyboardClass(ref NewUserName, UserNameString.Length, 15);;

            if (Right || Left)
            {
                ToPush = "RegisterMenu";
                BackOrFor = false;
               StackFunction();
                return;
            }

            Console.WriteLine("\n");

            Console.Write(PasswordString);

            string NewPassword = "";

            RunKeyboardClass(ref NewPassword, PasswordString.Length, 17);;

            if (Right || Left)
            {
                ToPush = "RegisterMenu";
                BackOrFor = false;
                StackFunction();
                return;
            }

            ACCDB_Type_File($"INSERT INTO UserNameAndPassword ([UserName], [Password]) VALUES ('{NewUserName}', '{NewPassword}')", false, ref FoundIt);

            Console.Write("\nYou've Registered successfully");

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
            Console.Clear();

            string UserNameString = "pls Enter your User Name --> ", PasswordString = "pls Enter your Password --> ";

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine(@"
███████╗██╗ ██████╗ ███╗   ██╗    ██╗███╗   ██╗
██╔════╝██║██╔════╝ ████╗  ██║    ██║████╗  ██║
███████╗██║██║  ███╗██╔██╗ ██║    ██║██╔██╗ ██║
╚════██║██║██║   ██║██║╚██╗██║    ██║██║╚██╗██║
███████║██║╚██████╔╝██║ ╚████║    ██║██║ ╚████║
╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝    ╚═╝╚═╝  ╚═══╝
                                               
                                               
                                               
                                               
                                               
                                               
                                               
                                               
");

            if (NumberOfTimesHeGotThePasswordWrong == 0)
            {
                while (NumberOfTimesHeGotTheUserNameWrong != 5)
                {
                    if (NumberOfTimesHeGotTheUserNameWrong == 4)
                    {
                        Console.WriteLine("\nyou've tried to meny times pls go register first");
                        Thread.Sleep(4000);

                        RegisterMenu();
                        break;
                    }
                    Console.SetCursorPosition(0, 16);

                    Console.Write(UserNameString + "\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t");

                    Console.SetCursorPosition(UserNameString.Length, 16);

                    UserName = "";

                    RunKeyboardClass(ref UserName, UserNameString.Length, 16);

                    if (Right || Left)
                    {
                        StackFunction();
                        return;
                    }

                    if (UserNameClient(UserName) == false)
                        NumberOfTimesHeGotTheUserNameWrong++;
                    else
                        break;
                }
            }
            while (NumberOfTimesHeGotThePasswordWrong != 5)
            {
                if (NumberOfTimesHeGotThePasswordWrong == 4)
                {
                    Console.WriteLine("\nyou've tried to meny times pls go Update your Password");
                    Thread.Sleep(4000);

                    UpdateMenu(UserName);
                    break;
                }
                Console.SetCursorPosition(0, 18);

                Console.Write(PasswordString + "\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(28, 18);

                string PasswordClient = "";

                PasswordClient = "";

                RunKeyboardClass(ref PasswordClient, UserNameString.Length, 16);

                if (Right || Left)
                {
                    StackFunction();
                    return;
                }

                if (Password(UserName, PasswordClient) == false)
                    NumberOfTimesHeGotThePasswordWrong++;
                else
                    break;
            }
        }
        static void UpdateMenu(string UserName)
        {
            Console.Clear();

            string UserNameString = "pls Enter your new password --> ";

            bool FoundIt = false;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine(@"
██╗   ██╗██████╗ ██████╗  █████╗ ████████╗███████╗  ██████╗  █████╗ ███████╗███████╗██╗    ██╗ ██████╗ ██████╗ ██████╗ 
██║   ██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝  ██╔══██╗██╔══██╗██╔════╝██╔════╝██║    ██║██╔═══██╗██╔══██╗██╔══██╗
██║   ██║██████╔╝██║  ██║███████║   ██║   █████╗    ██████╔╝███████║███████╗███████╗██║ █╗ ██║██║   ██║██████╔╝██║  ██║
██║   ██║██╔═══╝ ██║  ██║██╔══██║   ██║   ██╔══╝    ██╔═══╝ ██╔══██║╚════██║╚════██║██║███╗██║██║   ██║██╔══██╗██║  ██║
╚██████╔╝██║     ██████╔╝██║  ██║   ██║   ███████╗  ██║     ██║  ██║███████║███████║╚███╔███╔╝╚██████╔╝██║  ██║██████╔╝
 ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝  ╚═╝     ╚═╝  ╚═╝╚══════╝╚══════╝ ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═╝╚═════╝ 
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                                                                         
");

            string NewPassword = "";

            RunKeyboardClass(ref NewPassword, UserNameString.Length, 18);

            ACCDB_Type_File($"UPDATE UserNameAndPassword SET [Password] = '{NewPassword}' WHERE UserName = '{UserName}'", false, ref FoundIt);

            Console.WriteLine("your Password was reset");
            Thread.Sleep(3000);

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
                Thread.Sleep(2000);
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
                Thread.Sleep(2000);
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
            //SoundPlayer AngryBirds = new SoundPlayer(soundLocation: @"C:\Users\USER\source\repos\Visual Studio\Visual Studio Documents\Audio\Angry Birds Theme Song.wav");
            //AngryBirds.PlayLooping();

            MainMenu();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("It was nice to have you with us, come again");
            Console.ResetColor();
        }
    }
}
