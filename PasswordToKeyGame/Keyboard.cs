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

                    if (SpaceBar[Column] != WordLength)
                    {
                        SpaceBar.Add(0);
                        Column--;
                    }

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

                    if (Column == 0)
                        SpaceBar[0] = WordLength;

                    SpaceBar.Add(0);

                    Column++;
                    WordLength = 0;
                }

                if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                    Shift = true;
char Letter;
                if (!Shift && !CapsLock || Shift && CapsLock)
                {
                    switch (keyPressed)
                    {
                        case ConsoleKey.A:
                                Letter = 'a';
                        Case ConsoleKey.B
                                Letter = 'b';
                            break;
                        case ConsoleKey.C:
                                Letter = 'c';
                            break;
                        case ConsoleKey.D:
                                Letter = 'd';
                            break;
                        case ConsoleKey.E:
                                Letter = 'e';
                            break;
                        case ConsoleKey.F:
                                Letter = 'f';
                            break;
                        case ConsoleKey.G:
                                Letter = 'g';
                            break;
                        case ConsoleKey.H
                                Letter = 'h';
                            break;
                        case ConsoleKey.I:
                                Letter = 'i';
                            break;
                        case ConsoleKey.J:
                                Letter = 'j';
                            break;
                        case ConsoleKey.K:
                                Letter = 'k';
                            break;
                        case ConsoleKey.L:
                                Letter = 'l';
                            break;
                        case ConsoleKey.M:
                                Letter = 'm';
                            break;
                        case ConsoleKey.N:
                            {
                                Letter = 'n';
                            }
                            break;
                        case ConsoleKey.O:
                            {
                                Letter = 'o';
                            }
                            break;
                        case ConsoleKey.P:
                            {
                                Letter = 'p';
                            }
                            break;
                        case ConsoleKey.Q:
                            {
                                Letter = 'q';
                            }
                            break;
                        case ConsoleKey.R:
                            {
                                Letter = 'r';
                            }
                            break;
                        case ConsoleKey.S:
                            {
                                Letter = 's';
                            }
                            break;
                        case ConsoleKey.T:
                            {
                                Letter = 't';
                            }
                            break;
                        case ConsoleKey.U:
                            {
                                Letter = 'u';
                            }
                            break;
                        case ConsoleKey.V:
                            {
                                Letter = 'v';
                            }
                            break;
                        case ConsoleKey.W:
                            {
                                Letter = 'w';
                            }
                            break;
                        case ConsoleKey.X:
                            {
                                Letter = 'x';
                            }
                            break;
                        case ConsoleKey.Y:
                            {
                                Letter = 'y';
                            }
                            break;
                        case ConsoleKey.Z:
                            {
                                Letter = 'z';
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

                    if (!string.IsNullOrEmpty(ReadLine) && keyPressed != ConsoleKey.Spacebar)
                        WordLength++;
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
                            LeftArrow = true;
                            break;
                        case ConsoleKey.RightArrow:
                            RightArrow = true;
                            break;
                    }

                    if (!string.IsNullOrEmpty(ReadLine) && keyPressed != ConsoleKey.Spacebar)
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
