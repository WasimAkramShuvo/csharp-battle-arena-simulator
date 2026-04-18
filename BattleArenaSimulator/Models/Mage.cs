using BattleArenaSimulator.Interfaces;

namespace BattleArenaSimulator.Models
{
    public class Mage : Character, ISpecialAttack
    {
        public Mage(string name) : base(name, 90, 30, 5)
        {
        }

        public override void Attack(Character opponent)
        {
            int damage = AttackPower - opponent.Defense;
            if (damage < 0)
            {
                damage = 0;
            }

            opponent.TakeDamage(damage);
            Console.WriteLine($"{Name} cast Fireball on {opponent.Name} and dealt {damage} damage.");
        }

        public void UseSpecialAttack(Character opponent)
        {
            int specialDamage = 40 - opponent.Defense;
            if (specialDamage < 0)
            {
                specialDamage = 0;
            }

            opponent.TakeDamage(specialDamage);
            Console.WriteLine($"{Name} used Lightning Storm on {opponent.Name} and dealt {specialDamage} damage.");
        }
    }
}
