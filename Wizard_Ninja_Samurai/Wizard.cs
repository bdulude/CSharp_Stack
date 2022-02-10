using System;

namespace Wizard_Ninja_Samurai
{
    class Wizard : Human
    {
        public Wizard(string name, int str = 3, int intel = 25, int dex = 3, int hp = 50) : base(name, str, intel, dex, hp)
        {
        }
        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.Health -= dmg;
            this.Health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"{Name} healed for {dmg} health!");
            return dmg;
        }
        public int Heal(Human target)
        {
            int add = this.Intelligence * 10;
            target.Health += add;
            Console.WriteLine($"{Name} healed {target.Name} for {add} health!");
            return add;
        }
    }
}