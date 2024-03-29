﻿using System;
using System.Collections.Generic;

namespace PasswordToKeyGame
{
    internal class Keyboard
    {
        private static int X_Axis;
        private static int Y_Axis;

        private static bool LeftArrow = false;
        private static bool RightArrow = false;

        public Keyboard(int X_Axis, int Y_Axis)
        {
            LeftArrow = false;
            RightArrow = false;

            Keyboard.X_Axis = X_Axis;
            Keyboard.Y_Axis = Y_Axis;
        }
        private static void KeyBoardFunction(ref string ReadLine)
        {
            bool Ctrl = false, Shift = false, CapsLock, BackspaceBlocker;
            int Column = 0, Typed = 0;

            List<int> WordLength = new List<int>();

            ConsoleKey keyPressed;

            do
            {
                if (WordLength.Count == 0)
                {
                    WordLength.Add(Typed);
                    Column = 0;
                    Typed = 0;
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                CapsLock = Console.CapsLock;

                if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                    Ctrl = true;

                switch (keyPressed)
                {
                    case ConsoleKey.Backspace:
                        {
                            if (!string.IsNullOrEmpty(ReadLine))
                            {
                                Console.SetCursorPosition(X_Axis, Y_Axis);

                                WordLength[Column] += Typed;

                                if (WordLength[Column] == 0 && Column != 0)
                                {
                                    WordLength.RemoveAt(Column);
                                    Column--;
                                }
                                if (Ctrl)
                                {
                                    ReadLine = ReadLine.Substring(0, ReadLine.Length - WordLength[Column]);
                                    Console.Write(ReadLine);

                                    for (int i = 0; i < WordLength[Column]; i++)
                                        Console.Write(" ");

                                    WordLength.RemoveAt(Column);
                                    Column--;
                                    Typed = 0;
                                }
                                else
                                {
                                    ReadLine = ReadLine.Substring(0, ReadLine.Length - 1);

                                    if (WordLength[Column] != 0)
                                        WordLength[Column]--;

                                    Typed = 0;

                                    Console.Write(ReadLine + " ");
                                }
                                Console.SetCursorPosition(X_Axis + ReadLine.Length, Y_Axis);
                            }
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            ReadLine += " ";

                            Console.Write(" ");

                            Typed++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        RightArrow = true; break;

                    case ConsoleKey.LeftArrow:
                        LeftArrow = true; break;
                }
                if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0)
                    Shift = true;

                char ? Letter = null;

                bool UpperCase = false;

                if (CapsLock && !Shift || Shift && !CapsLock)
                    UpperCase = true;

                Shift = false;
                Ctrl = false;
                BackspaceBlocker = false;

                switch (keyPressed)
                {
                    case ConsoleKey.A:
                        Letter = UpperCase ? 'A' : 'a'; break;
                    case ConsoleKey.B:
                        Letter = UpperCase ? 'B' : 'b'; break;
                    case ConsoleKey.C:
                        Letter = UpperCase ? 'C' : 'c'; break;
                    case ConsoleKey.D:
                        Letter = UpperCase ? 'D' : 'd'; break;
                    case ConsoleKey.E:
                        Letter = UpperCase ? 'E' : 'e'; break;
                    case ConsoleKey.F:
                        Letter = UpperCase ? 'F' : 'f'; break;
                    case ConsoleKey.G:
                        Letter = UpperCase ? 'G' : 'g'; break;
                    case ConsoleKey.H:
                        Letter = UpperCase ? 'H' : 'h'; break;
                    case ConsoleKey.I:
                        Letter = UpperCase ? 'I' : 'i'; break;
                    case ConsoleKey.J:
                        Letter = UpperCase ? 'J' : 'j'; break;
                    case ConsoleKey.K:
                        Letter = UpperCase ? 'K' : 'k'; break;
                    case ConsoleKey.L:
                        Letter = UpperCase ? 'L' : 'l'; break;
                    case ConsoleKey.M:
                        Letter = UpperCase ? 'M' : 'm'; break;
                    case ConsoleKey.N:
                        Letter = UpperCase ? 'N' : 'n'; break;
                    case ConsoleKey.O:
                        Letter = UpperCase ? 'O' : 'o'; break;
                    case ConsoleKey.P:
                        Letter = UpperCase ? 'P' : 'p'; break;
                    case ConsoleKey.Q:
                        Letter = UpperCase ? 'Q' : 'q'; break;
                    case ConsoleKey.R:
                        Letter = UpperCase ? 'R' : 'r'; break;
                    case ConsoleKey.S:
                        Letter = UpperCase ? 'S' : 's'; break;
                    case ConsoleKey.T:
                        Letter = UpperCase ? 'T' : 't'; break;
                    case ConsoleKey.U:
                        Letter = UpperCase ? 'U' : 'u'; break;
                    case ConsoleKey.V:
                        Letter = UpperCase ? 'V' : 'v'; break;
                    case ConsoleKey.W:
                        Letter = UpperCase ? 'W' : 'w'; break;
                    case ConsoleKey.X:
                        Letter = UpperCase ? 'X' : 'x'; break;
                    case ConsoleKey.Y:
                        Letter = UpperCase ? 'Y' : 'y'; break;
                    case ConsoleKey.Z:
                        Letter = UpperCase ? 'Z' : 'z'; break;


                    case ConsoleKey.D1:
                        Letter = UpperCase ? '!' : '1'; break;
                    case ConsoleKey.D2:
                        Letter = UpperCase ? '@' : '2'; break;
                    case ConsoleKey.D3:
                        Letter = UpperCase ? '#' : '3'; break;
                    case ConsoleKey.D4:
                        Letter = UpperCase ? '$' : '4'; break;
                    case ConsoleKey.D5:
                        Letter = UpperCase ? '%' : '5'; break;
                    case ConsoleKey.D6:
                        Letter = UpperCase ? '^' : '6'; break;
                    case ConsoleKey.D7:
                        Letter = UpperCase ? '&' : '7'; break;
                    case ConsoleKey.D8:
                        Letter = UpperCase ? '*' : '8'; break;
                    case ConsoleKey.D9:
                        Letter = UpperCase ? '(' : '9'; break;
                    case ConsoleKey.D0:
                        Letter = UpperCase ? ')' : '0'; break;


                    case ConsoleKey.Oem3:
                        Letter = UpperCase ? '~' : '`'; break;
                    case ConsoleKey.OemMinus:
                        Letter = UpperCase ? '_' : '-'; break;
                    case ConsoleKey.OemPlus:
                        Letter = UpperCase ? '+' : '='; break;
                    case ConsoleKey.Oem1:
                        Letter = UpperCase ? ':' : ';'; break;
                    case ConsoleKey.Oem7:
                        Letter = UpperCase ? '"' : '\''; break;
                    case ConsoleKey.OemComma:
                        Letter = UpperCase ? '<' : ','; break;
                    case ConsoleKey.OemPeriod:
                        Letter = UpperCase ? '>' : '.'; break;
                    case ConsoleKey.Oem2:
                        Letter = UpperCase ? '?' : '/'; break;


                    case ConsoleKey.LeftArrow:
                        LeftArrow = true; break;

                    case ConsoleKey.RightArrow:
                        RightArrow = true; break;

                    default: continue;
                }
                if (ReadLine.Length != 0)
                {
                    if (((ReadLine[ReadLine.Length - 1] < 'A' || ReadLine[ReadLine.Length - 1] > 'Z') && 
                        (ReadLine[ReadLine.Length - 1] < 'a' || ReadLine[ReadLine.Length - 1] > 'z') && 
                        (ReadLine[ReadLine.Length - 1] < '0' || ReadLine[ReadLine.Length - 1] > '9')) && 
                        !((Letter < 'A' || Letter > 'Z') && (Letter < 'a' || Letter > 'z') &&
                        (Letter < '0' || Letter > '9')))
                        BackspaceBlocker = true;

                    if (ReadLine[ReadLine.Length - 1] == ' ' && !Letter.Equals(' ') || BackspaceBlocker)
                    {
                        WordLength[Column] += Typed;
                        Column++;

                        WordLength.Add(0);
                        Typed = 0;
                    }
                }
                ReadLine += Letter;
                Console.Write(Letter);

                if (keyPressed != ConsoleKey.Spacebar && keyPressed != ConsoleKey.Backspace)
                    Typed++;

            } while (keyPressed != ConsoleKey.Enter && !LeftArrow && !RightArrow);
        }
        public void Call(ref string ReadLine, ref bool LeftArrowFunction, ref bool RightArrowFunction)
        {
            KeyBoardFunction(ref ReadLine);

            LeftArrowFunction = LeftArrow;
            RightArrowFunction = RightArrow;
        }
    }
}