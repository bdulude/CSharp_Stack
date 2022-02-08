using System;
using System.Collections.Generic;


namespace Collections_Prac
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] strArr = { "Tim", "Martin", "Nikki", "Sara" };
            bool[] boolArr = { true, false, true, false, true, false, true, false, true, false };

            List<string> iceCreams = new List<string>();
            iceCreams.Add("Vanilla");
            iceCreams.Add("Chocolate");
            iceCreams.Add("Rainbow Sherbert");
            iceCreams.Add("Rocky Road");
            iceCreams.Add("Pistachio");
            Console.WriteLine($"Ice Cream Flavors: {iceCreams.Count}");
            Console.WriteLine(iceCreams[2]);
            iceCreams.RemoveAt(2);
            Console.WriteLine($"Ice Cream Flavors: {iceCreams.Count}");

            Dictionary<string,string> userInfo = new Dictionary<string, string>();
            Random rand = new Random();
            foreach (var name in strArr)
            {
                userInfo.Add(name, iceCreams[rand.Next(0,3)]);
            }
            foreach (KeyValuePair<string,string> entry in userInfo)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
        }
    }
}
