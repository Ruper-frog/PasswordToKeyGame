using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading;

namespace PasswordToKeyGame
{
    internal class Program
    {
        static string ToPush, Reader, UserName;

        static int SelectedIndex, BackwardsEmpty = 0, ForwardsEmpty = 0;

        static int X, Y;

        static Stack Backwards = new Stack();
        static Stack Forwards = new Stack();

        static bool Left = false, Right = false;
        static void RunKeyboardClass(ref string ReadLine, int X_Axis, int Y_Axis)
        {
            Keyboard KeyboardClass = new Keyboard(ReadLine, X_Axis, Y_Axis);
            KeyboardClass.Call(ref ReadLine, ref Left, ref Right);
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
                        SignInMenu();
                        break;
                    case "UpdateMenu":
                        UpdateMenu();
                        break;
                }
            }
            ToPush = null;
            Reader = null;
        }
        static void LeftArrow()
        {
            Reader = Backwards.Pop().ToString();

            Forwards.Push(ToPush);

            StackFunction();
        }
        static void RightArrow()
        {
            Reader = Forwards.Pop().ToString();

            Backwards.Push(ToPush);

            StackFunction();
        }
        static void CheckMe()
        {
            if (Left)
            {
                if (Backwards.Count != 0)
                {
                    BackwardsEmpty = 0;
                    LeftArrow();
                }

                else
                {
                    BackwardsEmpty++;

                    if (BackwardsEmpty == 3)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine(@"
           ██╗   ██╗ ██████╗ ██╗   ██╗    ███╗   ██╗███████╗███████╗██████╗     ████████╗ ██████╗
           ╚██╗ ██╔╝██╔═══██╗██║   ██║    ████╗  ██║██╔════╝██╔════╝██╔══██╗    ╚══██╔══╝██╔═══██╗
            ╚████╔╝ ██║   ██║██║   ██║    ██╔██╗ ██║█████╗  █████╗  ██║  ██║       ██║   ██║   ██║
             ╚██╔╝  ██║   ██║██║   ██║    ██║╚██╗██║██╔══╝  ██╔══╝  ██║  ██║       ██║   ██║   ██║
              ██║   ╚██████╔╝╚██████╔╝    ██║ ╚████║███████╗███████╗██████╔╝       ██║   ╚██████╔╝
              ╚═╝    ╚═════╝  ╚═════╝     ╚═╝  ╚═══╝╚══════╝╚══════╝╚═════╝        ╚═╝    ╚═════╝
 
          ██████╗██╗  ██╗ ██████╗  ██████╗ ███████╗███████╗    ███████╗██╗██████╗ ███████╗████████╗██╗
         ██╔════╝██║  ██║██╔═══██╗██╔═══██╗██╔════╝██╔════╝    ██╔════╝██║██╔══██╗██╔════╝╚══██╔══╝██║
         ██║     ███████║██║   ██║██║   ██║███████╗█████╗      █████╗  ██║██████╔╝███████╗   ██║   ██║
         ██║     ██╔══██║██║   ██║██║   ██║╚════██║██╔══╝      ██╔══╝  ██║██╔══██╗╚════██║   ██║   ╚═╝
         ╚██████╗██║  ██║╚██████╔╝╚██████╔╝███████║███████╗    ██║     ██║██║  ██║███████║   ██║   ██╗
          ╚═════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚═╝
                                                                                             

                                                                                         
                                                                                         
                                                                                         
                                                                                         
                                                                                         
                                                                                         
                                                                                         
                                                                                         
");
                        Thread.Sleep(3000);

                        BackwardsEmpty = 0;
                    }
                    Reader = ToPush;
                    StackFunction();
                }
            }

            else if (Right)
            {
                if (Forwards.Count != 0)
                {
                    ForwardsEmpty = 0;
                    RightArrow();
                }

                else
                {
                    ForwardsEmpty++;

                    if (ForwardsEmpty == 3)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine(@"

████████╗██╗  ██╗██╗███████╗    ██╗███████╗    ████████╗██╗  ██╗███████╗    ███╗   ███╗ ██████╗ ███████╗████████╗
╚══██╔══╝██║  ██║██║██╔════╝    ██║██╔════╝    ╚══██╔══╝██║  ██║██╔════╝    ████╗ ████║██╔═══██╗██╔════╝╚══██╔══╝
   ██║   ███████║██║███████╗    ██║███████╗       ██║   ███████║█████╗      ██╔████╔██║██║   ██║███████╗   ██║   
   ██║   ██╔══██║██║╚════██║    ██║╚════██║       ██║   ██╔══██║██╔══╝      ██║╚██╔╝██║██║   ██║╚════██║   ██║   
   ██║   ██║  ██║██║███████║    ██║███████║       ██║   ██║  ██║███████╗    ██║ ╚═╝ ██║╚██████╔╝███████║   ██║   
   ╚═╝   ╚═╝  ╚═╝╚═╝╚══════╝    ╚═╝╚══════╝       ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚═╝     ╚═╝ ╚═════╝ ╚══════╝   ╚═╝   

             ██████╗ ███████╗ ██████╗███████╗███╗   ██╗████████╗    ██████╗  █████╗  ██████╗ ███████╗
             ██╔══██╗██╔════╝██╔════╝██╔════╝████╗  ██║╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝ ██╔════╝
             ██████╔╝█████╗  ██║     █████╗  ██╔██╗ ██║   ██║       ██████╔╝███████║██║  ███╗█████╗  
             ██╔══██╗██╔══╝  ██║     ██╔══╝  ██║╚██╗██║   ██║       ██╔═══╝ ██╔══██║██║   ██║██╔══╝  
             ██║  ██║███████╗╚██████╗███████╗██║ ╚████║   ██║       ██║     ██║  ██║╚██████╔╝███████╗
             ╚═╝  ╚═╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝       ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                                        
                                 
                                 
                                 
                                                                                                                                 

                                                                                                           
                                                                                                           
                                                                                                           
                                                                                                           
                                                                                                           
                                                                                                           
");
                        Thread.Sleep(3000);

                        ForwardsEmpty = 0;
                    }
                    Reader = ToPush;
                    StackFunction();
                }
            }
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

            string[] options = { "Register ", "Sign in", "Exit" };
            Menu mainMenu = new Menu(options);
            SelectedIndex = mainMenu.Run();

            if (SelectedIndex != 3 && SelectedIndex != 4)
            {
                Backwards.Clear();
                Forwards.Clear();
            }
            switch (SelectedIndex)
            {
                case 0:
                    {
                        Backwards.Push("MainMenu");
                        RegisterMenu();
                    }
                    break;
                case 1:
                    {
                        Backwards.Push("MainMenu");
                        SignInMenu();
                    }
                    break;
                case 3:
                    {
                        Left = true;

                        ToPush = "MainMenu";

                        CheckMe();
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
            Console.Clear();

            bool FoundIt = false;

            string UserNameString = "ple enter your user name --> ", PasswordString = "pls enter your password --> ";

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write(@"
██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗
██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝
██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗
██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║
╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
                                                             
");

            X = Console.CursorLeft;
            Y = Console.CursorTop;

            string NewUserName;

            while (true)
            {
                NewUserName = "";

                Console.SetCursorPosition(X, Y);

                Console.Write(UserNameString + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(UserNameString.Length, Y);

                RunKeyboardClass(ref NewUserName, UserNameString.Length, Y); ;

                if (Left || Right)
                {
                    ToPush = "RegisterMenu";

                    CheckMe();
                    return;
                }
                if (!String.IsNullOrEmpty(NewUserName) && !UserNameClient(NewUserName.Trim( ), true))
                    break;
            }

            Console.WriteLine("\n");

            Console.Write(PasswordString);

            string NewPassword = "";

            while (true)
            {
                RunKeyboardClass(ref NewPassword, PasswordString.Length, Console.CursorTop); ;

                if (Left || Right)
                {
                    ToPush = "RegisterMenu";

                    CheckMe();
                    return;
                }
                if (!String.IsNullOrEmpty(NewUserName))
                    break;
            }

            ACCDB_Type_File($"INSERT INTO UserNameAndPassword ([UserName], [Password]) VALUES ('{NewUserName}', '{NewPassword}')", false, ref FoundIt);

            Console.Write("\nYou've Registered successfully");

            Thread.Sleep(1000);

            for (int k = 0; k < 3; k++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }

            Backwards.Clear();
            Forwards.Clear();

            MainMenu();
        }
        static void SignInMenu()
        {
            Console.Clear();

            int NumberOfTimesHeGotTheUserNameWrong = 0, NumberOfTimesHeGotThePasswordWrong = 0;

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

            X = Console.CursorLeft;
            Y= Console.CursorTop;

            while (NumberOfTimesHeGotTheUserNameWrong != 4)
            {
                if (NumberOfTimesHeGotTheUserNameWrong == 3)
                {
                    Console.WriteLine("\nyou've tried to meny times pls go register first");
                    Thread.Sleep(4000);

                    Backwards.Push("SignInMenu");

                    RegisterMenu();
                    return;
                }
                UserName = "";

                Console.SetCursorPosition(X, Y);

                Console.Write(UserNameString + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(UserNameString.Length, Y);

                RunKeyboardClass(ref UserName, UserNameString.Length, Y);

                if (Left || Right)
                {
                    ToPush = "SignInMenu";

                    CheckMe();
                    return;
                }

                if (!String.IsNullOrEmpty(UserName))
                {
                    if (UserNameClient(UserName, false) == false)
                        NumberOfTimesHeGotTheUserNameWrong++;
                    else
                        break;
                }
            }
            X = 0;
            Y = Console.CursorTop + 2;

            while (NumberOfTimesHeGotThePasswordWrong != 4)
            {
                if (NumberOfTimesHeGotThePasswordWrong == 3)
                {
                    Console.WriteLine("\nyou've tried to meny times pls go Update your Password");
                    Thread.Sleep(4000);

                    Backwards.Push("SignInMenu");

                    UpdateMenu();
                    return;
                }
                Console.SetCursorPosition(X, Y);

                Console.Write(PasswordString + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(PasswordString.Length, Y);

                string PasswordClient = "";

                PasswordClient = "";

                RunKeyboardClass(ref PasswordClient, PasswordString.Length, Y);

                if (Left || Right)
                {
                    ToPush = "SignInMenu";

                    CheckMe();
                    return;
                }

                if (!String.IsNullOrEmpty(PasswordClient))
                {
                    if (Password(UserName, PasswordClient) == false)
                        NumberOfTimesHeGotThePasswordWrong++;
                    else
                        break;
                }
            }
        }
        static void UpdateMenu()
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

            while (true)
            {
                RunKeyboardClass(ref NewPassword, UserNameString.Length, Console.CursorTop);

                if (Left || Right)
                {
                    ToPush = "UpdateMenu";

                    CheckMe();
                    return;
                }
                if (!String.IsNullOrEmpty(NewPassword))
                    break;
            }
            ACCDB_Type_File($"UPDATE UserNameAndPassword SET [Password] = '{NewPassword}' WHERE UserName = '{UserName}'", false, ref FoundIt);

            Console.Write("\nyour Password was reset");
            Thread.Sleep(1000);

            for (int k = 0; k < 3; k++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }

            Backwards.Clear();
            Forwards.Clear();

            MainMenu();
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
        static bool UserNameClient(string UserName, bool NewUserName)
        {
            bool FoundIt = false;
            ACCDB_Type_File($"SELECT UserName FROM UserNameAndPassword WHERE UserName = '{UserName}'", true, ref FoundIt);

            if (!NewUserName)
            {
                if (!FoundIt)
                {
                    Console.Write("\nyou've enterd the wrong UserName");
                    Thread.Sleep(2000);
                }
            }
            else if (FoundIt)
            {
                Console.Write("\nThe user name already exists");
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

                MyKeyGame();
            }

            else
            {
                Console.Write("\nyou've enterd the wrong Password");
                Thread.Sleep(2000);
            }
            return FoundIt;
        }
        static void PaintTheSkeyInBlwo(int Num, string p)
        {
            if (Num != 0)
                Console.ForegroundColor = (ConsoleColor)Num;

            Console.Write(p);
        }
        static void Display(int x, int y, int Num, string p)
        {
            Console.SetCursorPosition(x, y);

            PaintTheSkeyInBlwo(Num, p);
        }
        static void MyKeyGame()
        {
            Random random = new Random();

            ConsoleKeyInfo KeyInfo;

            bool FirstTime = true, Left = false, NewLine = false, Done = false, FinichLine = false;

            string p = "*";

            int[] Num = new int[2];

            int x = 0, y = 0, w = 0, h = 1;

            int Width, Height;

            Width = Console.WindowWidth;

            Height = Console.WindowHeight;

            Display(0, 19, Num[0], "C - Clear Screan, P - Change pen, R - Change Color to a random Color, W - Change color to Wite, U - Pen Up, D - Pen Down,B - Carriage Return, Escape - Exit");

            do
            {
                if (NewLine)
                    h = 1;

                if (Left)
                    Display(x + h, y, Num[0], "");

                if (Done)
                    Display(x + 1, y, Num[0], "");

                if (FinichLine)
                {
                    Display(Width - 1, y, Num[0], "");
                    x = Width - 2;
                }

                Done = false;

                Left = false;

                FinichLine = false;

                KeyInfo = Console.ReadKey();

                if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (!FirstTime)
                        x++;
                    if (x < Width - 1)
                        Display(x, y, Num[0], p);
                    else
                        FinichLine = true;

                    FirstTime = false;
                }

                else if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (x > 0)
                        h++;

                    Left = true;

                    if (x > 0)
                        Display(--x, y, Num[0], p);
                }

                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (y < Height - 2)
                        Display(x, ++y, Num[0], p);
                    else
                        Done = true;
                }

                else if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (y > 0)
                        Display(x, --y, Num[0], p);
                    else
                        Done = true;
                }

                else if (KeyInfo.Key == ConsoleKey.B)
                {
                    Display(0, y, Num[0], "");
                    x = -1;
                }

                else if (KeyInfo.Key == ConsoleKey.C)
                {
                    Console.Clear();
                }

                else if (KeyInfo.Key == ConsoleKey.P)
                {
                    Num[1] = random.Next(33, 48);

                    p = Convert.ToString(Convert.ToChar(Num[1]));
                }

                else if (KeyInfo.Key == ConsoleKey.R)
                {
                    Num[0] = random.Next(1, 15);

                    PaintTheSkeyInBlwo(Num[0], "");
                }

                else if (KeyInfo.Key == ConsoleKey.W)
                {
                    Num[0] = 15;
                    PaintTheSkeyInBlwo(Num[0], "");
                }

                else if (KeyInfo.Key == ConsoleKey.Escape)
                {
                    Num[0] = 0;

                    Display(0, 22, Num[0], "It was nice to have you here \n");
                    break;
                }

                NewLine = false;

                if (y != w)
                {
                    w = y;
                    NewLine = true;
                }

            } while (true);
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

        //Dumpster 
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

            command.CommandText = $"SELECT * FROM UserNameAndPassword";

            OleDbDataReader reader = command.ExecuteReader();

            List<string> IDNum = new List<string>();

            int Column = 0;

            while (reader.Read())
            {
                IDNum[Column] = reader.GetString(0);
                Column++;
            }

            connection.Close();

            connection.Open();

            Random random = new Random();

            int Start, Stop;

            int[] Char = new int[2];

            string Print, Print1 = "";

            for (int j = 1; j <= IDNum.Count; j++)
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
                command.CommandText = $"UPDATE UserNameAndPassword SET [Password] = '{Print1}' WHERE ID = {IDNum[j]}";
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
        static void FindKeyName()
        {
            ConsoleKeyInfo KeyInfo;
            bool cont = true;

            while (cont == true)
            {
                KeyInfo = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine(KeyInfo.Key + " Was Pressed");

                if (KeyInfo.Key == ConsoleKey.Escape)
                    cont = false;
            }
        }
        static void PaintGame()
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
    }
}
