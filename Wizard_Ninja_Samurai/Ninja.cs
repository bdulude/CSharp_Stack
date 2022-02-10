using System;

namespace Wizard_Ninja_Samurai
{
    class Ninja : Human
    {
        public Ninja(string name, int str = 3, int intel = 3, int dex = 175, int hp = 100) : base(name, str, intel, dex, hp)
        {
        }

        public override int Attack(Human target)
        {
            int dmg = this.Dexterity * 5;
            Random rand = new Random();
            dmg = rand.NextDouble() >= 0.2 ? dmg : dmg + 10;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return dmg;
        }

        public int Steal(Human target)
        {
            int stolen = 5;
            target.Health -= stolen;
            this.Health += stolen;
            Console.WriteLine($"{Name} stole {stolen} hp from {target.Name}!");
            return stolen;
        }

    }
}