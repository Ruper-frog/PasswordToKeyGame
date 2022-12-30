using System;
using System.Collections;
using System.Data.OleDb;
using System.Threading;

namespace PasswordToKeyGame
{
    internal class Program
    {
        static string ToPush, Reader, UserName;

        static int SelectedIndex, OldSelectedIndex;

        static Stack Backwards = new Stack();
        static Stack Forwards = new Stack();

        static bool Left = false, Right = false;
        static void RunKeyboardClass(ref string readLine, int x_Axis, int y_Axis)
        {
            Keyboard KeyboardClass = new Keyboard(readLine, x_Axis, y_Axis);
            KeyboardClass.Call(ref readLine, ref Left, ref Right);
        }
        static void StackFunction()
        {
            if (Right || Left)
            {
                Left = false;
                Right = false;

                switch (Reader)
                {
                    case "MainMenu":
                        MainMenu();
                        break;
                    case "RegisterMenu":
                        RegisterMenu();
                        break;
                    case "SignInMenu":
                        SignInMenu(0, 0);
                        break;
                    case "UpdateMenu":
                        UpdateMenu(UserName);
                        break;
                }
            }
            ToPush = null;
            Reader = null;
        }
        static void LeftArrow()
        {
            Reader = Convert.ToString(Backwards.Pop());

            Forwards.Push(Reader);

            Forwards.Push(ToPush);
            StackFunction();
        }
        static void RightArrow()
        {
            Reader = Convert.ToString(Forwards.Pop());
            StackFunction();
        }
        static void CheckMe()
        {
            if (Left)
                LeftArrow();

            else if (Forwards.Count != 0 && Right)
            {
                RightArrow();
            }
            else
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

                Reader = ToPush;
                StackFunction();
            }
        }
        static void MainMenu()
        {
            Console.Clear();

            OldSelectedIndex = SelectedIndex;

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
            SelectedIndex = mainMenu.Run();

            if (Backwards.Count == 0)
                Backwards.Push("MainMenu");
            if (SelectedIndex != 3 && SelectedIndex != 4)
            {
                if (OldSelectedIndex != SelectedIndex && Forwards.Count != 0)
                {
                    Forwards.Clear();
                }
            }
            switch (SelectedIndex)
            {
                case 0:
                    {
                        RegisterMenu();
                    }
                    break;
                case 1:
                    {
                        SignInMenu(0, 0);
                    }
                    break;
                case 3:
                    {
                        Left = true;

                        if (Forwards.Count != 0)
                        {

                            ToPush = "MainMenu";

                            CheckMe();
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine(@"
             ██╗   ██╗ ██████╗ ██╗   ██╗    ███╗   ██╗███████╗███████╗██████╗     ████████╗ ██████╗     
             ╚██╗ ██╔╝██╔═══██╗██║   ██║    ████╗  ██║██╔════╝██╔════╝██╔══██╗    ╚══██╔══╝██╔═══██╗    
              ╚████╔╝ ██║   ██║██║   ██║    ██╔██╗ ██║█████╗  █████╗  ██║  ██║       ██║   ██║   ██║    
               ╚██╔╝  ██║   ██║██║   ██║    ██║╚██╗██║██╔══╝  ██╔══╝  ██║  ██║       ██║   ██║   ██║    
                ██║   ╚██████╔╝╚██████╔╝    ██║ ╚████║███████╗███████╗██████╔╝       ██║   ╚██████╔╝    
                ╚═╝    ╚═════╝  ╚═════╝     ╚═╝  ╚═══╝╚══════╝╚══════╝╚═════╝        ╚═╝    ╚═════╝     

              ██████╗██╗  ██╗ ██████╗  ██████╗ ███████╗███████╗    ███████╗██╗██████╗ ███████╗████████╗
             ██╔════╝██║  ██║██╔═══██╗██╔═══██╗██╔════╝██╔════╝    ██╔════╝██║██╔══██╗██╔════╝╚══██╔══╝
             ██║     ███████║██║   ██║██║   ██║███████╗█████╗      █████╗  ██║██████╔╝███████╗   ██║   
             ██║     ██╔══██║██║   ██║██║   ██║╚════██║██╔══╝      ██╔══╝  ██║██╔══██╗╚════██║   ██║   
             ╚██████╗██║  ██║╚██████╔╝╚██████╔╝███████║███████╗    ██║     ██║██║  ██║███████║   ██║   
              ╚═════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝                                             

");
                            Thread.Sleep(3000);

                            Reader = Convert.ToString(Backwards.Pop());
                            StackFunction();
                        }
                    }
                    break;
                case 4:
                    {
                        Right = true;

                        ToPush = "MainMenu";

                        CheckMe();
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

            RunKeyboardClass(ref NewUserName, UserNameString.Length, 15); ;

            if (Left || Right)
            {
                ToPush = "RegisterMenu";

                CheckMe();
                return;
            }

            Console.WriteLine("\n");

            Console.Write(PasswordString);

            string NewPassword = "";

            RunKeyboardClass(ref NewPassword, PasswordString.Length, 17); ;

            if (Left || Right)
            {
                ToPush = "RegisterMenu";

                CheckMe();
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
        static void SignInMenu(int NumberOfTimesHeGotTheUserNameWrong, int NumberOfTimesHeGotThePasswordWrong)
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
                while (NumberOfTimesHeGotTheUserNameWrong != 4)
                {
                    if (NumberOfTimesHeGotTheUserNameWrong == 3)
                    {
                        Console.WriteLine("\nyou've tried to meny times pls go register first");
                        Thread.Sleep(4000);

                        Backwards.Push("SignInMenu");

                        RegisterMenu();
                        break;
                    }
                    Console.SetCursorPosition(0, 16);

                    Console.Write(UserNameString + "\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t");

                    Console.SetCursorPosition(UserNameString.Length, 16);

                    UserName = "";

                    RunKeyboardClass(ref UserName, UserNameString.Length, 16);

                    if (Left || Right)
                    {
                        ToPush = "SignInMenu";

                        CheckMe();
                        return;
                    }

                    if (UserNameClient(UserName) == false)
                        NumberOfTimesHeGotTheUserNameWrong++;
                    else
                        break;
                }
            }
            while (NumberOfTimesHeGotThePasswordWrong != 4)
            {
                if (NumberOfTimesHeGotThePasswordWrong == 3)
                {
                    Console.WriteLine("\nyou've tried to meny times pls go Update your Password");
                    Thread.Sleep(4000);

                    Backwards.Push("SignInMenu");

                    UpdateMenu(UserName);
                    break;
                }
                Console.SetCursorPosition(0, 18);

                Console.Write(PasswordString + "\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(28, 18);

                string PasswordClient = "";

                PasswordClient = "";

                RunKeyboardClass(ref PasswordClient, PasswordString.Length, 18);

                if (Left || Right)
                {
                    ToPush = "SignInMenu";

                    CheckMe();
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

            Console.Write(UserNameString);

            string NewPassword = "";

            RunKeyboardClass(ref NewPassword, UserNameString.Length, 24);

            if (Left || Right)
            {
                ToPush = "UpdateMenu";

                CheckMe();
                return;
            }

            ACCDB_Type_File($"UPDATE UserNameAndPassword SET [Password] = '{NewPassword}' WHERE UserName = '{UserName}'", false, ref FoundIt);

            Console.WriteLine("\nyour Password was reset");
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
                Console.Write("\nyou've enterd the wrong UserName");
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
                Console.Write("\nyou may enter");

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
                Console.Write("\nyou've enterd the wrong Password");
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
