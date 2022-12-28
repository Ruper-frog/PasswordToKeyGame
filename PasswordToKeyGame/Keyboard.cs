using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            ReadLine = readLine;
            X_Axis = x_Axis;
            Y_Axis = y_Axis;
        }
        private static void KeyBoardFunction(ref string ReadLine, int x, int y)
        {
            bool Shift = false, CapsLock;

            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                CapsLock = Console.CapsLock;

                if (keyPressed == ConsoleKey.RightArrow)
                    RightArrow = true;

                else if (keyPressed == ConsoleKey.LeftArrow)
                    LeftArrow = true;

                if (LeftArrow || RightArrow)
                    break;

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
                            LeftArrow = true;
                            break;
                        case ConsoleKey.RightArrow:
                            RightArrow = true;
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
                            LeftArrow = true;
                            break;
                        case ConsoleKey.RightArrow:
                            RightArrow = true;
                            break;
                    }
                }
                Shift = false;
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
