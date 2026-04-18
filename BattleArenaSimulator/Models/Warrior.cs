using BattleArenaSimulator.Interfaces;

namespace BattleArenaSimulator.Models
{
    public class Warrior : Character, ISpecialAttack
    {
        public Warrior(string name) : base(name, 120, 25, 10)
        {
        }

        public override void Attack(Character opponent)
        {
            int damage = AttackPower - opponent.Defense + 5;
            if (damage < 0)
            {
                damage = 0;
            }

            opponent.TakeDamage(damage);
            Console.WriteLine($"{Name} used Sword Slash on {opponent.Name} and dealt {damage} damage.");
        }

        public void UseSpecialAttack(Character opponent)
        {
            int specialDamage = 35 - opponent.Defense;
            if (specialDamage < 0)
            {
                specialDamage = 0;
            }

            opponent.TakeDamage(specialDamage);
            Console.WriteLine($"{Name} used Power Strike on {opponent.Name} and dealt {specialDamage} damage.");
        }
    }
}
