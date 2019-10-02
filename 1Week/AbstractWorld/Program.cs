using System;
using AbstractWorld.Buildings;
using AbstractWorld.Characters;

namespace AbstractWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Werewolf newPlayer = new Werewolf("Bozo");
            Vampire otherPlayer = new Vampire();
            Werewolf wolfie = new Werewolf("Wolfie");
            Skeleton skelz = new Skeleton("Skelly");

            wolfie.Attack(skelz, 5);
            skelz.Attack(wolfie, 500);

            Barracks homeBase = new Barracks();
            homeBase.AddRecruit(newPlayer);
            homeBase.AddRecruit(otherPlayer);
            homeBase.AddRecruit(wolfie);
            homeBase.AddRecruit(skelz);

            skelz.Attack(homeBase, 3);


            homeBase.Rally();
        }
    }
}
