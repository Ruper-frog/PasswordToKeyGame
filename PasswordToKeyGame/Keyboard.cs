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

            SpaceBar.Add(WordLength);

            ConsoleKey keyPressed;
            do
            {
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

                    if (SpaceBar.Count != 1)
                        SpaceBar.Add(WordLength);
                    else 
                        SpaceBar[Column] = WordLength;

                    if (Ctrl)
                    {
                        ReadLine = ReadLine.Substring(0, ReadLine.Length - SpaceBar[Column]);
                        Console.Write(ReadLine);

                        for (int i = 0; i < SpaceBar[Column]; i++)
                        {
                            Console.Write(" ");
                        }

                        WordLength = 0;

                        if (Column != 0)
                        {
                            SpaceBar.RemoveAt(Column);
                            Column--;
                        }
                    }
                    else
                    {
                        ReadLine = ReadLine.Substring(0, ReadLine.Length - 1);
                        Console.Write(ReadLine + " ");
                    }

                    Console.SetCursorPosition(x + ReadLine.Length, y);
                }
                else if (keyPressed == ConsoleKey.Spacebar)
                {
                    ReadLine += " ";

                    Console.Write(" ");

                    SpaceBar[Column] = WordLength;

                    SpaceBar.Add(0);

                    Column++;
                    WordLength = 1;
                }

                if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                    Shift = true;

                string Letter = "";

                bool UpperCase = false;

                if (CapsLock && !Shift || Shift && !CapsLock)
                    UpperCase = true;

                if (!Shift && !CapsLock || Shift && CapsLock)
                {
                    switch (keyPressed)
                    {
                        case ConsoleKey.A:
                            {
                                if (UpperCase)
                                    Letter = "A";
                                else
                                    Letter = "a";
                            }
                            break;
                        case ConsoleKey.B:
                            {
                                if (UpperCase)
                                    Letter = "B";
                                else
                                    Letter = "b";
                            }
                            break;
                        case ConsoleKey.C:
                            {
                                if (UpperCase)
                                    Letter = "C";
                                else
                                    Letter = "c";
                            }
                            break;
                        case ConsoleKey.D:
                            {
                                if (UpperCase)
                                    Letter = "D";
                                else
                                    Letter = "d";
                            }
                            break;
                        case ConsoleKey.E:
                            {
                                if (UpperCase)
                                    Letter = "E";
                                else
                                    Letter = "e";
                            }
                            break;
                        case ConsoleKey.F:
                            {
                                if (UpperCase)
                                    Letter = "F";
                                else
                                    Letter = "f";
                            }
                            break;
                        case ConsoleKey.G:
                            {
                                if (UpperCase)
                                    Letter = "G";
                                else
                                    Letter = "g";
                            }
                            break;
                        case ConsoleKey.H:
                            {
                                if (UpperCase)
                                    Letter = "H";
                                else
                                    Letter = "h";
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                if (UpperCase)
                                    Letter = "I";
                                else
                                    Letter = "i";
                            }
                            break;
                        case ConsoleKey.J:
                            {
                                if (UpperCase)
                                    Letter = "J";
                                else
                                    Letter = "j";
                            }
                            break;
                        case ConsoleKey.K:
                            {
                                if (UpperCase)
                                    Letter = "K";
                                else
                                    Letter = "k";
                            }
                            break;
                        case ConsoleKey.L:
                            {
                                if (UpperCase)
                                    Letter = "L";
                                else
                                    Letter = "l";
                            }
                            break;
                        case ConsoleKey.M:
                            {
                                if (UpperCase)
                                    Letter = "M";
                                else
                                    Letter = "m";
                            }
                            break;
                        case ConsoleKey.N:
                            {
                                if (UpperCase)
                                    Letter = "N";
                                else
                                    Letter = "n";
                            }
                            break;
                        case ConsoleKey.O:
                            {
                                if (UpperCase)
                                    Letter = "O";
                                else
                                    Letter = "o";
                            }
                            break;
                        case ConsoleKey.P:
                            {
                                if (UpperCase)
                                    Letter = "P";
                                else
                                    Letter = "p";
                            }
                            break;
                        case ConsoleKey.Q:
                            {
                                if (UpperCase)
                                    Letter = "Q";
                                else
                                    Letter = "q";
                            }
                            break;
                        case ConsoleKey.R:
                            {
                                if (UpperCase)
                                    Letter = "R";
                                else
                                    Letter = "r";
                            }
                            break;
                        case ConsoleKey.S:
                            {
                                if (UpperCase)
                                    Letter = "S";
                                else
                                    Letter = "s";
                            }
                            break;
                        case ConsoleKey.T:
                            {
                                if (UpperCase)
                                    Letter = "T";
                                else
                                    Letter = "t";
                            }
                            break;
                        case ConsoleKey.U:
                            {
                                if (UpperCase)
                                    Letter = "U";
                                else
                                    Letter = "u";
                            }
                            break;
                        case ConsoleKey.V:
                            {
                                if (UpperCase)
                                    Letter = "V";
                                else
                                    Letter = "v";
                            }
                            break;
                        case ConsoleKey.W:
                            {
                                if (UpperCase)
                                    Letter = "W";
                                else
                                    Letter = "w";
                            }
                            break;
                        case ConsoleKey.X:
                            {
                                if (UpperCase)
                                    Letter = "X";
                                else
                                    Letter = "x";
                            }
                            break;
                        case ConsoleKey.Y:
                            {
                                if (UpperCase)
                                    Letter = "Y";
                                else
                                    Letter = "y";
                            }
                            break;
                        case ConsoleKey.Z:
                            {
                                if (UpperCase)
                                    Letter = "Z";
                                else
                                    Letter = "z";
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
                }
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