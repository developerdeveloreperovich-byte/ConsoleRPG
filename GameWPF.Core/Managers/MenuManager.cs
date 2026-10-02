using System;
using System.Collections.Generic;
using System.Text;

namespace GameWPF.Core.Managers
{
    public static class MenuManager
    {
        public static void StartMenu()
        {
            while (true)
            {

                Console.WriteLine("========================================================================");
                Console.WriteLine("\t\tWelcome to the GameWPF.Core!");

                Console.WriteLine("Chose an option: \n1 - Start the game\n2 - Read the rules\n0 - Exit");
                Console.Write("Enter your option: ");
                int choice = int.TryParse(Console.ReadLine(), out int temp) ? temp : 0;

                switch (choice)
                {
                    case 1:
                        StartTheGame();
                        break;
                    case 2:
                        ReadRules();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        continue;
                }
            }
        }

        public static void StartTheGame()
        {
            GameManager.StartGame();
        }
        public static void ReadRules()
        {
            Console.WriteLine("Rules are simple. You start the game, after that you just keep chosing your options. Have fun!");
        }
    }
}
