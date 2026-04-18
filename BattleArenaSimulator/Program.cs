using BattleArenaSimulator.Models;
using BattleArenaSimulator.Services;

namespace BattleArenaSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battle Arena Simulator";

            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                ShowWelcomeMessage();

                Character player = CreatePlayerCharacter();
                Character enemy = CreateRandomEnemy();

                BattleService battleService = new BattleService();
                battleService.StartBattle(player, enemy);

                Console.WriteLine();
                Console.Write("Do you want to play again? (y/n): ");
                string answer = Console.ReadLine();

                playAgain = answer != null && answer.Trim().ToLower() == "y";
            }

            Console.WriteLine("Thanks for playing Battle Arena Simulator!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ShowWelcomeMessage()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("     WELCOME TO BATTLE ARENA");
            Console.WriteLine("==================================");
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Archer");
            Console.WriteLine("4. Healer");
            Console.WriteLine();
        }

        static Character CreatePlayerCharacter()
        {
            while (true)
            {
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return new Warrior("Player Warrior");
                    case "2":
                        return new Mage("Player Mage");
                    case "3":
                        return new Archer("Player Archer");
                    case "4":
                        return new Healer("Player Healer");
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static Character CreateRandomEnemy()
        {
            Random random = new Random();
            int enemyChoice = random.Next(1, 5);

            switch (enemyChoice)
            {
                case 1:
                    return new Warrior("Enemy Warrior");
                case 2:
                    return new Mage("Enemy Mage");
                case 3:
                    return new Archer("Enemy Archer");
                case 4:
                    return new Healer("Enemy Healer");
                default:
                    return new Warrior("Enemy Warrior");
            }
        }
    }
}
