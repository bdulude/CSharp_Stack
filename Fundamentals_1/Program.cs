using System;

namespace Fundamentals_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x < 256; x++)
            {
                Console.WriteLine(x);
            }
            for (int y = 1; y < 101; y++)
            {
                if (y % 3 == 0 && y % 5 == 0)
                {
                    Console.WriteLine("Fizz Buzz");
                }
                else if (y % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (y % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else {
                    Console.WriteLine(y);
                }
            }
            // Console.WriteLine("Hello World!");
        }
    }
}
