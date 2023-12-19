using System;
using System.Collections.Generic;

namespace Contagion_Control
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of citizens:");
            int.TryParse(Console.ReadLine(), out int N);//市民人數

            List<int> idList = new List<int>(N);//市民名單
            List<int> contacteeList = new List<int>(N);//接觸者名單

            for (int i = 0; i < N; i++)
            {
                idList.Add(i);
                contacteeList.Add(i);
            }

            //接觸者名單重新洗牌(Fisher-Yates Suffle)
            Random rng = new Random();
            int n = contacteeList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(N - n) + n;
                int value = contacteeList[k];
                contacteeList[k] = contacteeList[n];
                contacteeList[n] = value;
            }

            //印出共有幾個市民
            Console.Write("ID List:        ");
            foreach (int id in idList)
            {
                Console.Write("{0,3}", id);
            }
            Console.WriteLine();
            //印出各居民互相接觸情形
            Console.Write("Contactee List: ");
            foreach (int Contactee in contacteeList)
            {
                Console.Write("{0,3}", Contactee);
            }

            Console.WriteLine();

            // 輸入初始感染者的ID
            Console.WriteLine("Enter id of infected citizens:");
            int.TryParse(Console.ReadLine(), out int infectedID);

            //起始傳染者與接觸者名單比對
            List<int> transmissionChain = new List<int>();//隔離名單

            int currentInfectedID = infectedID;

            while (true)
            {
                
                int contacteeIndex = idList.IndexOf(currentInfectedID); // 在市民名單中找到傳染者的索引

                int nextInfectedID = contacteeList[contacteeIndex]; // 找到對應的市民ID

                transmissionChain.Add(nextInfectedID); // 把需要隔離加入名單

                if (nextInfectedID == infectedID) break;// 如果找到須隔離的人是市民本身而已就停止搜尋

                currentInfectedID = nextInfectedID;
            }

            // 輸出傳播鏈
            Console.Write("Transmission Chain: ");
            foreach (int id in transmissionChain)
            {
                Console.Write("{0,3}", id);
            }
        }

       
    }
}
