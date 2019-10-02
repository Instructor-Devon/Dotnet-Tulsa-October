using System;

namespace AbstractWorld.Characters
{
    public abstract class Human : IAttackable
    {
        public static string SpeciesName = "Homo Sapien";
        private static int startingHealth = 100;
        protected string name;
        public string Name
        {
            get { return name; }
        }
        public int Health 
        {
            get { return health; }
            set { health = value; }
        }
        private int health;
        public bool Attack(IAttackable target, int dmg)
        {
            // return true if target is dead
            BattleCry();
            target.Health -= dmg;

            return target.Health <= 0;
        }
        public Human(string name)
        {
            this.name = name;
            this.health = startingHealth;
        }
        public abstract void BattleCry();
    }
}