using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard merlin = new Wizard("Merlin");
            Human king = new Human("Arthur");
            Ninja nameless = new Ninja("Nameless");
            Samurai toranaga = new Samurai("Toranaga");
            king.Attack(merlin);
            merlin.Attack(king);
            nameless.Steal(merlin);
            nameless.Attack(king);
            nameless.Attack(king);
            nameless.Attack(king);
            nameless.Attack(king);
            nameless.Attack(king);
            merlin.Heal(king);
            merlin.Attack(toranaga);
            toranaga.Meditate();
            toranaga.Attack(king);
        }
    }
}
