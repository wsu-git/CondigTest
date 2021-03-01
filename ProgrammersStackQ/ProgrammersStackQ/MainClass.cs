using System;
using System.Collections.Generic;

namespace ProgrammersStackQ
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StockPrice stockPrice = new StockPrice();
            FunctionDevelopment f = new FunctionDevelopment();

            int[] testData = new int[] { 93,30,55};
            int[] testSpd = new int[] { 1, 30, 5 };
            int[] result = f.Solution(testData, testSpd);

            foreach(var t in result)
            {
                Console.WriteLine(t);
            }


        }

        //
        
    }
}
