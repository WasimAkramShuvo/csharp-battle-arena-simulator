using BattleArenaSimulator.Interfaces;

namespace BattleArenaSimulator.Models
{
    public class Healer : Character, ISpecialAttack
    {
        public Healer(string name) : base(name, 95, 18, 6)
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
            Console.WriteLine($"{Name} attacked {opponent.Name} and dealt {damage} damage.");
        }

        public void UseSpecialAttack(Character opponent)
        {
            Heal(20);
            Console.WriteLine($"{Name} used Healing Light.");
        }
    }
}
