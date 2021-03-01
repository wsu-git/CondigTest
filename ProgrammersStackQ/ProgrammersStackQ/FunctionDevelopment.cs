using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersStackQ
{
    public class FunctionDevelopment
    {
        public FunctionDevelopment()
        {
        }

        public int[] Solution(int[] progresses, int[] speeds)
        {
            int[] answer = new int[] { };

            Queue<int> progresseQueue = new Queue<int>(progresses);
            List<int> result = new List<int>();
            // speeds 루프 인덱스.
            int idx = 0;

            //
            while(progresseQueue.Count > 0)
            {
                // 완료된 작업 수.
                int count = 0;
                // Console.WriteLine("idx = {0}", idx);
                // 작업시간을 전부 진행준인 작업에 더한다.
                for (int i = idx; i < speeds.Length; i++)
                {
                    progresses[i] += speeds[i];
                    // Console.WriteLine(progresses[i]);
                }
                // 완료된 작업이 있는지 검사.
                for(int j = idx; j < speeds.Length; j ++)
                {
                    if(progresses[j] > 99)
                    {
                        // 배열에서 완료된 작업으 더 이상 사용할 필요가 없으므로 인덱스 1 증가.
                        idx++;
                        count++;
                        // 작업리스트에서 제거.
                        progresseQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                // 완료된 작업이 있으면 추가.
                if(count > 0)
                {
                    result.Add(count);
                }


            }

              return result.ToArray() ;
        }

    }
}
