using System;
using System.Collections;
using System.Collections.Generic;
namespace ProgrammersStackQ
{
    public class StockPrice
    {
        

        public StockPrice()
        {
        }

        public int[] CalculateStockKeepTime(int[] prices)
        {
            // 안씀.
            // int[] answer = new int[prices.Length];

            // 주식 가격들을 가지고 있을 큐.
            Queue<int> pricesQueue = new Queue<int>(prices);
            // 시간 결과를 가지는 큐.
            Queue<int> resultQueue = new Queue<int>();

            // 첫번째 주식가격이 들어오면 첫 번째 부터 비교 할 필요가 없으므로.
            // 두 번째(인덱스가 1인) 것부터 비교.
            int idx = 1;

            // 비교할 주식 가격이 존재하면 루프 지속.
            while(pricesQueue.Count > 0)
            {
                int time = 0;

                // 현재 비교할 주식 값.
                int curPrice = pricesQueue.Dequeue();

                // idx 가 prices.Length면
                // pricesQueue의 마지막 데이터 라는 뜻 임.
                // => 비교할 다음 주식 가격이 없음. => 0초.
                if (idx == prices.Length)
                {
                    // 이 떄 time 값은 0.
                    resultQueue.Enqueue(time);
                }
                for(int i = idx; i<prices.Length; i++)
                {
                    // 시간 1씩 증가하고.
                    time++;
                    // 주식 가격이 떨어질때 또는 끝까지 안떨여졋을때.
                    if(curPrice > prices[i] || i == prices.Length - 1)
                    {
                        resultQueue.Enqueue(time);
                        break;
                    }
                }
                idx++;
            }

            return resultQueue.ToArray();
        }


        public int[] CalculateStockKeepTime2(int[] prices)
        {

            int[] answer = new int[] { };
            //ArrayList answer = new ArrayList();
            Queue<int> pricesQueue = new Queue<int>();
            Queue<int> resultQueue = new Queue<int>();
            Queue<int> tmpQueue = null;

            foreach(int price in prices)
            {
                pricesQueue.Enqueue(price);
            }
            while(pricesQueue.Count > 0)
            {
                int time = 0;
                int tmpPrices = pricesQueue.Dequeue();
                tmpQueue = new Queue<int>(pricesQueue);

                if(tmpQueue.Count == 0)
                {
                    resultQueue.Enqueue(time);
                }

                for(int i = 0; i < pricesQueue.Count; i++)
                {
                    if (tmpPrices <= tmpQueue.Peek())
                    {
                        time++;
                        tmpQueue.Dequeue();
                        if(tmpQueue.Count == 0)
                        {
                            resultQueue.Enqueue(time);
                            break;
                        }
                    }
                    else
                    {
                        time++;
                        resultQueue.Enqueue(time);
                        break;
                    }
                }
                
                

            }

            answer = resultQueue.ToArray();
            

            return answer;
        }
    }
}
