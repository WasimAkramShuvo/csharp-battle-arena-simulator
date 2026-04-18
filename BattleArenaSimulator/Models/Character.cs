namespace BattleArenaSimulator.Models
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        protected Character(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        public virtual void Attack(Character opponent)
        {
            int damage = AttackPower - opponent.Defense;
            if (damage < 0)
            {
                damage = 0;
            }

            opponent.TakeDamage(damage);
            Console.WriteLine($"{Name} attacked {opponent.Name} and dealt {damage} damage.");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} restored {amount} health.");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} | Health: {Health} | Attack: {AttackPower} | Defense: {Defense}");
        }
    }
}
