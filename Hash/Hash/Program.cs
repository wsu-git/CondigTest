using System;

namespace Hash
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Camouflage camou = new Camouflage();
            string[,] testCase = new string[4, 2]
            {
                { "yellowhat", "headgear"},
                { "yellowhat", "headgear"},
                { "yellowhat", "headgear"},
                { "yellowhat", "headgear"}
            };

            Console.WriteLine(camou.solution(testCase));
        }
    }
}
