using System;

namespace AbstractWorld.Characters
{
    public class Skeleton : Human
    {
        public Skeleton(string name) : base(name) {}

        public override void BattleCry()
        {
            Console.WriteLine("*click* *clack*");
        }
    }
}