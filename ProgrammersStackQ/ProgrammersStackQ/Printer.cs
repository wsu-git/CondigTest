using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersStackQ
{
    public class Printer
    {
        public Printer()
        {
        }
        public int solution(int[] priorities, int location)
        {
            int answer = 0;
            Queue<int> prioritiesQueue = new Queue<int>(priorities);
            
            int maxPriority = prioritiesQueue.Max();


            while (true)
            {
                int paper = prioritiesQueue.Dequeue();
                // 문서 중요도가 제일 높으면
                if (maxPriority == paper)
                {
                    // 첫 번 째로 리턴 됨.
                    answer += 1;

                    // 만약 내가 원한 문서 위치가 첫 번째면.
                    if(location == 0)
                    {
                        break;
                    }
                    // 첫번 쨰가 아니면.
                    else
                    {
                        location -= 1;
                        maxPriority = prioritiesQueue.Max();
                    }
                }
                // 중요도에서 밀리면.
                else
                {
                    // 종이 다시 맨 뒤로.
                    prioritiesQueue.Enqueue(paper);
                    // 내가 원한 문서가 첫 번째였으면,
                    // 멘 뒤로 가게 되니 location을 맨 끝으로 바꿔야한다.
                    if(location == 0)
                    {
                        location = prioritiesQueue.Count - 1;

                    }
                    // 내가 원한 문서가 첫 번째가 아니면
                    // 한 칸 앞으로 오게되니 -1.
                    else
                    {
                        location -= 1;
                    }
                }
            }

            return answer;
        }
    }
}
