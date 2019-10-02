using System;

namespace AbstractWorld.Characters
{
    public class Werewolf : Human
    {
        public Werewolf(string name) : base(name) {}
        public override void BattleCry()
        {
            Console.WriteLine($"Wrrrooorrrrrshhnnghghh, says {Name}");
        }
    }
}