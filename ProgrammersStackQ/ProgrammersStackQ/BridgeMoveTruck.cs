using System;
using System.Collections.Generic;


namespace ProgrammersStackQ
{
    public class Truck
    {
        public int weight { get; set; }
        public int usingTime { get; set; }

        public Truck(int w, int t)
        {
            weight = w;
            usingTime = t;
        }

        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            // 반환 할 것.
            int answer = 0;
            // bridge_length => 다리 길이.
            // weight => 다리가 견딜 수 있는 최대 무게.

            // 총 시간.
            int time = 0;
            // 기다리고 있는 트럭 큐.
            Queue<Truck> WaitingTrucks = new Queue<Truck>();

            // 다리를 건너고 있는 트럭 리스트.
            // 리스트 쓴 이유 => loop 에 사용하기 위해.
            List<Truck> RunningTrucks = new List<Truck>();

            // 현재 다리위 트럭 총 무게.
            int onBridgeWeight = 0;

            // WaitingTrucks 큐에 트럭들 인큐.
            foreach (int truckWeight in truck_weights)
            {
                Truck tmpTruck = new Truck(truckWeight, 0);
                WaitingTrucks.Enqueue(tmpTruck);

            }

            while (true)
            {
                // 시간 1초 +.
                time += 1;

                // 현재 다리 건너는 트럭이 있으면 
                if (RunningTrucks.Count > 0)
                {
                    // 시간 전부 +1.
                    RunningTrucks.ForEach(
                        obj => obj.usingTime++);

                    // 시간 증가 
                    // 다리를 전부 건넌 트럭은 RunningTrucks 에서 제거.
                    for (int i = RunningTrucks.Count - 1; i >= 0; i--)
                    {
                        if (RunningTrucks[i].usingTime >= bridge_length)
                        {
                            onBridgeWeight -= RunningTrucks[i].weight;
                            RunningTrucks.RemoveAt(i);
                        }
                    }

                }

                // 기다리고 있는 트럭이 있으면.
                if (WaitingTrucks.Count > 0)
                {
                    // tmpTruckWeigth에 다음에 다리를 건널 트럭 무게 할당 후.
                    int tmpTruckWeigth = 0;
                    tmpTruckWeigth = WaitingTrucks.Peek().weight;

                    // 현재 다리위에 있는 트럭 무게와 tmpTruckWeigth 를 더해 다리 무게 보다 작으면
                    if (onBridgeWeight + tmpTruckWeigth <= weight)
                    {
                        // RunningTrucks(리스트) 에 추가.
                        Truck tmpTruck = WaitingTrucks.Dequeue();
                        onBridgeWeight += tmpTruck.weight;
                        RunningTrucks.Add(tmpTruck);
                    }
                }

                // 건너고 있는 트럭도 없고 건널 트럭도 없으면 루프 종료.
                if (RunningTrucks.Count == 0 && WaitingTrucks.Count == 0)
                {
                    return answer = time;
                }

            }

        }

    }

    
}
