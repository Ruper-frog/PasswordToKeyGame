using System;
using System.Data.OleDb;
using System.Media;
using System.Threading;
using System.Collections;

namespace PasswordToKeyGame
{
    internal class Program
    {
        public static string ToPush;

        public static Stack Backwards = new Stack();
        public static Stack Forward = new Stack();

        static void KeyBoard(ref string ReadLine, ref bool Left, ref bool Right, int x, int y)
        {
            bool Shift = false, CapsLock;

            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                CapsLock = Console.CapsLock;

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    ToPush = Convert.ToString(Forward.Pop());
                    Right = true;
                }

                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    ToPush = Convert.ToString(Backwards.Pop());
                    Left = true;
                }

                if (Left || Right)
                    StackFunction(Left, Right, ToPush);

                else if (keyPressed == ConsoleKey.Backspace)
                {
                    ReadLine = ReadLine.Substring(0, ReadLine.Length - 1);

                    Console.SetCursorPosition(x, y);

                    Console.Write(ReadLine + " ");

                    Console.SetCursorPosition(x + ReadLine.Length, y);
                }
                else if (keyPressed == ConsoleKey.Spacebar)
                {
                    ReadLine += " ";

                    Console.Write(" ");
                }

                if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                    Shift = true;

                if (!Shift && !CapsLock || Shift && CapsLock)
                {
                    switch (keyPressed)
                    {
                        case ConsoleKey.A:
                            {
                                Console.Write("a");
                                ReadLine += "a";
                            }
                            break;
                        case ConsoleKey.B:
                            {
                                Console.Write("b");
                                ReadLine += "b";
                            }
                            break;
                        case ConsoleKey.C:
                            {
                                Console.Write("c");
                                ReadLine += "c";
                            }
                            break;
                        case ConsoleKey.D:
                            {
                                Console.Write("d");
                                ReadLine += "d";
                            }
                            break;
                        case ConsoleKey.E:
                            {
                                Console.Write("e");
                                ReadLine += "e";
                            }
                            break;
                        case ConsoleKey.F:
                            {
                                Console.Write("f");
                                ReadLine += "f";
                            }
                            break;
                        case ConsoleKey.G:
                            {
                                Console.Write("g");
                                ReadLine += "g";
                            }
                            break;
                        case ConsoleKey.H:
                            {
                                Console.Write("h");
                                ReadLine += "h";
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                Console.Write("i");
                                ReadLine += "i";
                            }
                            break;
                        case ConsoleKey.J:
                            {
                                Console.Write("j");
                                ReadLine += "j";
                            }
                            break;
                        case ConsoleKey.K:
                            {
                                Console.Write("k");
                                ReadLine += "k";
                            }
                            break;
                        case ConsoleKey.L:
                            {
                                Console.Write("l");
                                ReadLine += "l";
                            }
                            break;
                        case ConsoleKey.M:
                            {
                                Console.Write("m");
                                ReadLine += "m";
                            }
                            break;
                        case ConsoleKey.N:
                            {
                                Console.Write("n");
                                ReadLine += "n";
                            }
                            break;
                        case ConsoleKey.O:
                            {
                                Console.Write("o");
                                ReadLine += "o";
                            }
                            break;
                        case ConsoleKey.P:
                            {
                                Console.Write("p");
                                ReadLine += "p";
                            }
                            break;
                        case ConsoleKey.Q:
                            {
                                Console.Write("q");
                                ReadLine += "q";
                            }
                            break;
                        case ConsoleKey.R:
                            {
                                Console.Write("r");
                                ReadLine += "r";
                            }
                            break;
                        case ConsoleKey.S:
                            {
                                Console.Write("s");
                                ReadLine += "s";
                            }
                            break;
                        case ConsoleKey.T:
                            {
                                Console.Write("t");
                                ReadLine += "t";
                            }
                            break;
                        case ConsoleKey.U:
                            {
                                Console.Write("u");
                                ReadLine += "u";
                            }
                            break;
                        case ConsoleKey.V:
                            {
                                Console.Write("v");
                                ReadLine += "v";
                            }
                            break;
                        case ConsoleKey.W:
                            {
                                Console.Write("w");
                                ReadLine += "w";
                            }
                            break;
                        case ConsoleKey.X:
                            {
                                Console.Write("x");
                                ReadLine += "x";
                            }
                            break;
                        case ConsoleKey.Y:
                            {
                                Console.Write("y");
                                ReadLine += "y";
                            }
                            break;
                        case ConsoleKey.Z:
                            {
                                Console.Write("z");
                                ReadLine += "z";
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            Left = true;
                            break;
                        case ConsoleKey.RightArrow:
                            Right = true;
                            break;
                    }
                }
                if (CapsLock && !Shift || Shift && !CapsLock)
                {
                    switch (keyPressed)
                    {
                        case ConsoleKey.A:
                            {
                                Console.Write("A");
                                ReadLine += "A";
                            }
                            break;
                        case ConsoleKey.B:
                            {
                                Console.Write("B");
                                ReadLine += "B";
                            }
                            break;
                        case ConsoleKey.C:
                            {
                                Console.Write("C");
                                ReadLine += "C";
                            }
                            break;
                        case ConsoleKey.D:
                            {
                                Console.Write("D");
                                ReadLine += "D";
                            }
                            break;
                        case ConsoleKey.E:
                            {
                                Console.Write("E");
                                ReadLine += "E";
                            }
                            break;
                        case ConsoleKey.F:
                            {
                                Console.Write("F");
                                ReadLine += "F";
                            }
                            break;
                        case ConsoleKey.G:
                            {
                                Console.Write("G");
                                ReadLine += "G";
                            }
                            break;
                        case ConsoleKey.H:
                            {
                                Console.Write("H");
                                ReadLine += "H";
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                Console.Write("I");
                                ReadLine += "I";
                            }
                            break;
                        case ConsoleKey.J:
                            {
                                Console.Write("J");
                                ReadLine += "J";
                            }
                            break;
                        case ConsoleKey.K:
                            {
                                Console.Write("K");
                                ReadLine += "K";
                            }
                            break;
                        case ConsoleKey.L:
                            {
                                Console.Write("L");
                                ReadLine += "L";
                            }
                            break;
                        case ConsoleKey.M:
                            {
                                Console.Write("M");
                                ReadLine += "M";
                            }
                            break;
                        case ConsoleKey.N:
                            {
                                Console.Write("N");
                                ReadLine += "N";
                            }
                            break;
                        case ConsoleKey.O:
                            {
                                Console.Write("O");
                                ReadLine += "O";
                            }
                            break;
                        case ConsoleKey.P:
                            {
                                Console.Write("P");
                                ReadLine += "P";
                            }
                            break;
                        case ConsoleKey.Q:
                            {
                                Console.Write("Q");
                                ReadLine += "Q";
                            }
                            break;
                        case ConsoleKey.R:
                            {
                                Console.Write("R");
                                ReadLine += "R";
                            }
                            break;
                        case ConsoleKey.S:
                            {
                                Console.Write("S");
                                ReadLine += "S";
                            }
                            break;
                        case ConsoleKey.T:
                            {
                                Console.Write("T");
                                ReadLine += "T";
                            }
                            break;
                        case ConsoleKey.U:
                            {
                                Console.Write("U");
                                ReadLine += "U";
                            }
                            break;
                        case ConsoleKey.V:
                            {
                                Console.Write("V");
                                ReadLine += "V";
                            }
                            break;
                        case ConsoleKey.W:
                            {
                                Console.Write("W");
                                ReadLine += "W";
                            }
                            break;
                        case ConsoleKey.X:
                            {
                                Console.Write("X");
                                ReadLine += "X";
                            }
                            break;
                        case ConsoleKey.Y:
                            {
                                Console.Write("Y");
                                ReadLine += "Y";
                            }
                            break;
                        case ConsoleKey.Z:
                            {
                                Console.Write("Z");
                                ReadLine += "Z";
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            Left = true;
                            break;
                        case ConsoleKey.RightArrow:
                            Right = true;
                            break;
                    }

                }
                Shift = false;
            } while (keyPressed != ConsoleKey.Enter && keyPressed != ConsoleKey.LeftArrow && keyPressed != ConsoleKey.RightArrow);
        }
        static void StackFunction(bool Left, bool Right, string FuncionName)
        {


            if (!Right || !Left)
                Backwards.Push(FuncionName);

            if (Left)
            {
                ToPush  = Convert.ToString(Backwards.Pop());

                switch(ToPush)
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

                Forward.Push(ToPush);
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

            string[] options = { "Register ", "Sign In", "Exit" };
            Menu mainMenu = new Menu(options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        StackFunction(false, false, "MainMenu");
                        RegisterMenu();
                    }
                    break;
                case 1:
                    {
                        StackFunction(false, false, "MainMenu");
                        SignInMenu(0, 0, "");
                    }
                    break;
            }
            return;
        }
        static void RegisterMenu()
        {
            bool FoundIt = false, Left = false, Right = false;

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
            KeyBoard(ref NewUserName, ref Left, ref Right, UserNameString.Length, 15);

            Console.WriteLine("\n");

            Console.Write(PasswordString);

            string NewPassword = "";
            KeyBoard(ref NewPassword, ref Left, ref Right, PasswordString.Length, 17);

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

            string UserNameString = "pls Enter your User Name --> ";

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

                    UserName = Console.ReadLine();

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

                Console.Write("pls Enter your Password --> \t\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t");

                Console.SetCursorPosition(28, 18);

                string PasswordClient = Console.ReadLine();

                if (Password(UserName, PasswordClient) == false)
                    NumberOfTimesHeGotThePasswordWrong++;
                else
                    break;

            }
        }
        static void UpdateMenu(string UserName)
        {
            Console.Clear();

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

            Console.Write("pls Enter your new password --> ");
            string NewPassword = Console.ReadLine();

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
