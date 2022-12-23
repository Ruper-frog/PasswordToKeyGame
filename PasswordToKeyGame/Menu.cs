using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PasswordToKeyGame
{
    internal class Menu
    {
        private int SelectedIndex;
        private string[] Options;

        public Menu(string[] options)
        {
            Options = options;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];

                if (i == SelectedIndex)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black; 
                }

                WriteLine($"<< {currentOption} >>");
            }
            ResetColor();
        }

        public int Run()
        { 
            ConsoleKey keyPressed;
            do
            {
                Console.SetCursorPosition(0, 13);

                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //Update SelectedIndex Based on arrow keyes.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                        SelectedIndex--;

                        if (SelectedIndex == -1)
                            SelectedIndex = Options.Length - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                        SelectedIndex++;

                        if (SelectedIndex == Options.Length)
                            SelectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
