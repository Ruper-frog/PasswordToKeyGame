using System;
using System.Collections.Generic;

namespace PasswordToKeyGame
{
    internal class Keyboard
    {
        private string ReadLine;
        private int X_Axis;
        private int Y_Axis;
        private static bool LeftArrow = false;
        private static bool RightArrow = false;
        public Keyboard(string readLine, int x_Axis, int y_Axis)
        {
            LeftArrow = false;
            RightArrow = false;

            ReadLine = readLine;
            X_Axis = x_Axis;
            Y_Axis = y_Axis;
        }
        private static void KeyBoardFunction(ref string ReadLine, int x, int y)
        {
            bool Ctrl = false, Shift = false, CapsLock;
            int Column = 0, WordLength = 0;

            List<int> SpaceBar = new List<int>();

            ConsoleKey keyPressed;
            do
            {
                if (SpaceBar.Count == 0)
                {
                    SpaceBar.Add(WordLength);
                    Column = 0;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                CapsLock = Console.CapsLock;

                if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                    Ctrl = true;

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    RightArrow = true;
                    break;
                }

                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    LeftArrow = true;
                    break;
                }

                else if (keyPressed == ConsoleKey.Backspace && !string.IsNullOrEmpty(ReadLine))
                {
                    Console.SetCursorPosition(x, y);

                    if (WordLength != 0)
                        SpaceBar[Column] = WordLength;

                    if (SpaceBar[Column] == 0 && Column != 0)
                    {
                        SpaceBar.RemoveAt(Column);
                        Column--;
                    }

                    if (Ctrl)
                    {
                        ReadLine = ReadLine.Substring(0, ReadLine.Length - SpaceBar[Column]);
                        Console.Write(ReadLine);

                        for (int i = 0; i < SpaceBar[Column]; i++)
                        {
                            Console.Write(" ");
                        }

                        SpaceBar.RemoveAt(Column);
                        WordLength = 0;
                        Column--;
                    }
                    else
                    {
                        ReadLine = ReadLine.Substring(0, ReadLine.Length - 1);

                        if (SpaceBar[Column] != 0 )
                            SpaceBar[Column]--;

                        if (WordLength != 0)
                            WordLength--;

                        Console.Write(ReadLine + " ");
                    }

                    Console.SetCursorPosition(x + ReadLine.Length, y);
                }
                else if (keyPressed == ConsoleKey.Spacebar)
                {
                    ReadLine += " ";

                    Console.Write(" ");

                    SpaceBar[Column] = ++WordLength;
                    Column++;

                    SpaceBar.Add(0);
                    WordLength = 0;
                }

                if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                    Shift = true;

                string Letter = "";

                bool UpperCase = false;

                if (CapsLock && !Shift || Shift && !CapsLock)
                    UpperCase = true;

                switch (keyPressed)
                {
                    case ConsoleKey.A:
                        {
                            Letter = UpperCase ? "A" : "a";
                        }
                        break;
                    case ConsoleKey.B:
                        {
                            Letter = UpperCase ? "B" : "b";
                        }
                        break;
                    case ConsoleKey.C:
                        {
                            Letter = UpperCase ? "C" : "c";
                        }
                        break;
                    case ConsoleKey.D:
                        {
                            Letter = UpperCase ? "D" : "d";
                        }
                        break;
                    case ConsoleKey.E:
                        {
                            Letter = UpperCase ? "E" : "e";
                        }
                        break;
                    case ConsoleKey.F:
                        {
                            Letter = UpperCase ? "F" : "f";
                        }
                        break;
                    case ConsoleKey.G:
                        {
                            Letter = UpperCase ? "G" : "g";
                        }
                        break;
                    case ConsoleKey.H:
                        {
                            Letter = UpperCase ? "H" : "h";
                        }
                        break;
                    case ConsoleKey.I:
                        {
                            Letter = UpperCase ? "I" : "i";
                        }
                        break;
                    case ConsoleKey.J:
                        {
                            Letter = UpperCase ? "J" : "j";
                        }
                        break;
                    case ConsoleKey.K:
                        {
                            Letter = UpperCase ? "K" : "k";
                        }
                        break;
                    case ConsoleKey.L:
                        {
                            Letter = UpperCase ? "L" : "l";
                        }
                        break;
                    case ConsoleKey.M:
                        {
                            Letter = UpperCase ? "M" : "m";
                        }
                        break;
                    case ConsoleKey.N:
                        {
                            Letter = UpperCase ? "N" : "n";
                        }
                        break;
                    case ConsoleKey.O:
                        {
                            Letter = UpperCase ? "O" : "o";
                        }
                        break;
                    case ConsoleKey.P:
                        {
                            Letter = UpperCase ? "P" : "p";
                        }
                        break;
                    case ConsoleKey.Q:
                        {
                            Letter = UpperCase ? "Q" : "q";
                        }
                        break;
                    case ConsoleKey.R:
                        {
                            Letter = UpperCase ? "R" : "r";
                        }
                        break;
                    case ConsoleKey.S:
                        {
                            Letter = UpperCase ? "S" : "s";
                        }
                        break;
                    case ConsoleKey.T:
                        {
                            Letter = UpperCase ? "T" : "t";
                        }
                        break;
                    case ConsoleKey.U:
                        {
                            Letter = UpperCase ? "U" : "u";
                        }
                        break;
                    case ConsoleKey.V:
                        {
                            Letter = UpperCase ? "V" : "v";
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            Letter = UpperCase ? "W" : "w";
                        }
                        break;
                    case ConsoleKey.X:
                        {
                            Letter = UpperCase ? "X" : "x";
                        }
                        break;
                    case ConsoleKey.Y:
                        {
                            Letter = UpperCase ? "Y" : "y";
                        }
                        break;
                    case ConsoleKey.Z:
                        {
                            Letter = UpperCase ? "Z" : "z";
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        LeftArrow = true;
                        break;
                    case ConsoleKey.RightArrow:
                        RightArrow = true;
                        break;
                }

                ReadLine += Letter;
                Console.Write(Letter);

                if (Convert.ToChar(keyPressed) >= 'A' && Convert.ToChar(keyPressed) <= 'Z')
                    WordLength++;

                Shift = false;
                Ctrl = false;
            } while (keyPressed != ConsoleKey.Enter && keyPressed != ConsoleKey.LeftArrow && keyPressed != ConsoleKey.RightArrow);
        }
        public void Call(ref string ReadLine, ref bool LeftArrowFunction, ref bool RightArrowFunction)
        {
            KeyBoardFunction(ref ReadLine, X_Axis, Y_Axis);
            LeftArrowFunction = LeftArrow;
            RightArrowFunction = RightArrow;
        }
    }
}