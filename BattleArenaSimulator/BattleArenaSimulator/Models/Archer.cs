using BattleArenaSimulator.Interfaces;

namespace BattleArenaSimulator.Models
{
    public class Archer : Character, ISpecialAttack
    {
        public Archer(string name) : base(name, 100, 22, 7)
        {
        }

        public override void Attack(Character opponent)
        {
            int damage = AttackPower - opponent.Defense + 3;
            if (damage < 0)
            {
                damage = 0;
            }

            opponent.TakeDamage(damage);
            Console.WriteLine($"{Name} shot an arrow at {opponent.Name} and dealt {damage} damage.");
        }

        public void UseSpecialAttack(Character opponent)
        {
            int specialDamage = 32 - opponent.Defense;
            if (specialDamage < 0)
            {
                specialDamage = 0;
            }

            opponent.TakeDamage(specialDamage);
            Console.WriteLine($"{Name} used Triple Shot on {opponent.Name} and dealt {specialDamage} damage.");
        }
    }
}
