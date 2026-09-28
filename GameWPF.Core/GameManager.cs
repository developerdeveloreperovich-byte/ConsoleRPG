using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleRPG
{
    public static class GameManager
    {
        private static Character character;
        public static Character ChooseClass()
        {
            Console.WriteLine("Choose your game class: \n1 - Warrior\n2 - Archer\n3 - Mage");
            Console.Write("Enter your option: ");

            Character character = null;
            do
            {
                int classChoice = int.TryParse(Console.ReadLine(), out int tempClassChoice) ? tempClassChoice : 0;
                switch (classChoice)
                {
                    case 1:
                        character = new Warrior();
                        break;
                    case 2:
                        character = new Archer();
                        break;
                    case 3:
                        character = new Mage();
                        break;
                    default:
                        Console.WriteLine("Whoops, something is wrong, choose again");
                        break;
                }
            } while (character == null);
            return character;
        }
        public static void StartGame()
        {
            character = ChooseClass();
            DrawGameMenu();

        }
        public static void EndGame()
        {
            Console.WriteLine("Thanks for playing, bye!");
        }
        public static void StartBattle(Character character, NPC npc)
        {
            Console.WriteLine("\nBattle is begin, your opponent is... " + npc.Name + "\n");

            bool _isRun = false;

            Level levelBeforeBattle = character.Level;
            

            while (!character.IsDead && !npc.IsDead && _isRun == false)
            {
                //message my stats
                Console.WriteLine($"\n\t\t  YOU \n\t\tHP: {character.Health}/{character.MaxHealth} \n\t\tDamage: {character.Damage} \n\t\tDefense: {character.Defense}");

                //batle icon
                string swordImage = "\t\t *               * " + "\n" +
                                    "\t\t **             ** " + "\n" +
                                    "\t\t  **           **  " + "\n" +
                                    "\t\t   **         **   " + "\n" +
                                    "\t\t  -   -    -    -  " + "\n" +
                                    "\t\t    ---     ---    " + "\n" +
                                    "\t\t      **   **      " + "\n" +
                                    "\t\t        * *        " + "\n";

                Console.WriteLine("\n\n" + swordImage + "\n\n");
                //enemy stats
                Console.WriteLine($"\t\t  { npc.Name } \n\t\tHP: { npc.Health }/{npc.MaxHealth} \n\t\tDamage: {npc.Damage } \n\t\tDefense: {npc.Defense}\n");
                
                
                Console.WriteLine("Choose action: \n1 - Attack\n2 - Run");
                Console.Write("Enter your option: ");

                int battleChoice = int.TryParse(Console.ReadLine(), out int tempBattleChoice) ? tempBattleChoice : 0;

                
                switch (battleChoice)
                {
                    case 1:
                        BattleManager.AttackNpc(character, npc);

                        if (npc.IsDead)
                        {
                            Console.WriteLine("You win!!!\n");
                            RewardManager.RewardPlayer(character, npc);
                            if (levelBeforeBattle != character.Level)
                            {
                                character.Health = character.MaxHealth;
                            }
                            break;
                        }
                        

                        Console.WriteLine("Now " + npc.Name + " is attacking you!\n");

                        BattleManager.AttackCharacter(character, npc);

                        if (character.IsDead)
                        {
                            Console.WriteLine("Oh nooo, you have lost..");
                            GameManager.EndGame();
                            break;
                        }

                        continue;
                    case 2:
                        Console.WriteLine("You are trying to run!");
                        _isRun = BattleManager.TryRun(character, npc);
                        break;
                    default:
                        Console.WriteLine("Whoops, something is wrong, choose again");
                        continue;
                }
            }

        }
        public static NPC GenerateOpponent()
        {
            int opponent = new Random().Next(1, 4);
            if (opponent == 1)
                return new Goblin(level: character.Level);
            if (opponent == 2)
                return new Orc(level: character.Level);
            else
                return new Zombie(level: character.Level);
        }

        public static void DrawGameMenu()
        {
            while (true)
            {
                Console.WriteLine("Chose an option: \n1 - DiscoverWorld\n2 - Check stats\n3 - Check equipment\n4 - Go to the store\n0 - Exit");
                Console.Write("Enter your option: ");
                int choice = int.TryParse(Console.ReadLine(), out int temp) ? temp : 0;

                if (choice == 1)
                {
                    DiscoverWorld(character);
                }
                else if (choice == 2)
                {
                    CheckStats();
                }
                else if (choice == 3)
                {
                    //3 - character.CheckEquipment()
                }
                else if (choice == 4)
                {
                    //4 - StoreOfItems()
                }
                else
                {
                    //EndGame();
                    break;
                }
            }
        }
        public static void DiscoverWorld(Character character)
        {
            Console.WriteLine("You are walking down by the river and you notice something...");
            DiscoveryObject discoveredObject = GoldOrTrap(character);
            if (discoveredObject is Gold gold)
            {
                Console.WriteLine($"Wow, you have found {gold.GoldAmount} gold!");
                RewardManager.RewardPlayer(character, gold.GoldAmount);   
            }
            else if (discoveredObject is DiscoveredNPC npc)
            {
                Console.WriteLine("Oops.. enemy is going to approach you, battle is about to begin..\n");
                StartBattle(character, npc.NPC);
            }
        }
        public static DiscoveryObject GoldOrTrap(Character character)
        {
            int randDiscover = (new Random().Next(1, 3));
            if (randDiscover == 1)
            {
                return new Gold { GoldAmount = RewardManager.GenGoldFromWorldDiscovery() };

            }
            else
            {
                return new DiscoveredNPC { NPC = GenerateOpponent() };

            }
        }
        public static void CheckStats()
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Strength: " + character.Strength);
            Console.WriteLine("Defense: " + character.Defense);
            Console.WriteLine("Experience: " + character.Experience);
            Console.WriteLine("Gold: " + character.Gold);
            Console.WriteLine("Level: " + character.Level);
            Console.WriteLine("Weapon: ");
        }
        public static void CheckEquipment()
        {

        }
    }
}
