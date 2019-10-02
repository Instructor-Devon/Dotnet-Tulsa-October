using System;

namespace AbstractWorld.Characters
{
    public class Vampire : Human
    {
        public Vampire() : base("Vampire") {}

        public override void BattleCry()
        {
            Console.WriteLine($"I vant to suck your bloooood - {Name}");
        }
    }
}