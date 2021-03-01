using System;
using System.Collections.Generic;
using System.Linq;


namespace Hash
{
    public class Camouflage
    {
        public Camouflage()
        {
        }

        public int solution(string[,] clothes)
        {
            int answer = 1;

            Dictionary<string, int> clothesDic = new Dictionary<string, int>();

            for(int i = 0; i< clothes.GetLength(0); i++)
            {
                if(clothesDic.ContainsKey(clothes[i, 1]) == false)
                {
                    clothesDic[clothes[i, 1]] = new int();

                }
                clothesDic[clothes[i, 1]] += 1;
            }

            foreach(KeyValuePair<string, int> cloth in clothesDic)
            {
                answer *= cloth.Value + 1; 
            }


            return --answer;
        }

    }
}
