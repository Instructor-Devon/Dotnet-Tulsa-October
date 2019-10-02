using AbstractWorld.Characters;
using System.Collections.Generic;

namespace AbstractWorld.Buildings
{
    public class Barracks : IAttackable
    {
        public int Health {get;set;}
        public List<Human> Garrison;
        public Barracks()
        {
            Health = 50;
            Garrison = new List<Human>();
        }

        public void AddRecruit(Human recruit)
        {
            Garrison.Add(recruit);
        }

        public void Rally()
        {
            foreach(var rec in Garrison)
            {
                rec.BattleCry();
            }
        }
    }
}