using System;

namespace Wizard_Ninja_Samurai
{
    class Samurai : Human
    {
        public Samurai(string name, int str = 3, int intel = 3, int dex = 3, int hp = 200) : base(name, str, intel, dex, hp)
        {
        }
        public override int Attack(Human target)
        {
            int dmg = base.Attack(target);
            if (target.Health < 50)
            {
                dmg += target.Health;
                target.Health = 0;
                Console.WriteLine($"{Name} finished off {target.Name}!");
            }
            return dmg;
        }

        public int Meditate()
        {
            this.Health = 200;
            Console.WriteLine($"{Name} meditated to restore their health!");
            return this.Health;
        }
    }
}