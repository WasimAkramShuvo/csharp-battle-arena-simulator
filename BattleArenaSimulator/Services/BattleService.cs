using BattleArenaSimulator.Interfaces;
using BattleArenaSimulator.Models;

namespace BattleArenaSimulator.Services
{
    public class BattleService
    {
        private readonly Random _random = new Random();

        public void StartBattle(Character player, Character enemy)
        {
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("         BATTLE STARTED");
            Console.WriteLine("==================================");
            Console.WriteLine($"{player.Name} VS {enemy.Name}");
            Console.WriteLine();

            int round = 1;

            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine($"---------- Round {round} ----------");
                player.ShowStatus();
                enemy.ShowStatus();
                Console.WriteLine();

                PlayerTurn(player, enemy);

                if (!enemy.IsAlive())
                {
                    break;
                }

                Console.WriteLine();
                EnemyTurn(enemy, player);

                Console.WriteLine();
                round++;
            }

            Console.WriteLine("==================================");
            Console.WriteLine("         BATTLE FINISHED");
            Console.WriteLine("==================================");

            if (player.IsAlive())
            {
                Console.WriteLine($"{player.Name} is the WINNER!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} is the WINNER!");
            }
        }

        private void PlayerTurn(Character player, Character enemy)
        {
            Console.WriteLine("Your turn:");
            Console.WriteLine("1. Normal Attack");
            Console.WriteLine("2. Special Attack");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "2" && player is ISpecialAttack specialAttacker)
            {
                specialAttacker.UseSpecialAttack(enemy);
            }
            else
            {
                player.Attack(enemy);
            }
        }

        private void EnemyTurn(Character enemy, Character player)
        {
            Console.WriteLine("Enemy turn:");

            bool useSpecial = _random.Next(1, 101) <= 30;

            if (useSpecial && enemy is ISpecialAttack specialAttacker)
            {
                specialAttacker.UseSpecialAttack(player);
            }
            else
            {
                enemy.Attack(player);
            }
        }
    }
}
