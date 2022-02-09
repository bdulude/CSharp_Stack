using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        public static int[] RandomArray()
        {
            int[] output = new int[10];
            int min = 30;
            int max = 0;
            int sum = 0;
            Random rand = new Random();

            for (int x = 0; x < output.Length; x++)
            {
                int entry = rand.Next(5,26);
                output[x] = entry;
                max = entry > max ? entry : max;
                min = entry < min ? entry : min;
                sum += entry;
            }

            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Sum: {sum}");
            return output;
        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a coin!");
            Random rand = new Random();
            Boolean toss = rand.NextDouble() >= 0.5;
            String output = toss ? "Heads" : "Tails";
            Console.WriteLine(output);
            return output;
        }

        public static double TossMultipleCoins(int num)
        {
            double headsCount = 0;
            double count = 0;

            for (int y = 0; y < num; y++)
            {
                headsCount = (TossCoin() == "Heads" ? headsCount + 1 : headsCount);
                count++;
            }

            double heads = headsCount / count;
            Console.WriteLine($"Heads: {heads:R}");
            return heads;
        }

        public static List<string> Names()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random rand = new Random();
            for (int x = 0; x < names.Count * 2; x++)
            {
                int select = rand.Next(0,5);
                string temp = names[select];
                names.Add(temp);
                names.RemoveAt(select);
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            for (int y = 0; y < names.Count; y++)
            {
                if (names[y].Length < 5)
                {
                    names.RemoveAt(y);
                }
            }
            return names;
        }
        static void Main(string[] args)
        {
            RandomArray();
            // TossCoin();
            TossMultipleCoins(3);
            Names();
        }
    }
}
