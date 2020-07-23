using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncEnumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Discovering AsyncEnumerable in C# 8.0");
            Console.WriteLine("Step 1: Awaitable inside loop");
            foreach (var dataPoint in await FetchIOTData())
            {
                Console.WriteLine(dataPoint);
            }
            Console.ReadLine();
        }


        static async Task<IEnumerable<int>> FetchIOTData()
        {
            List<int> dataPoints = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000); 
                dataPoints.Add(i);
            }

            return dataPoints;
        }
    }
}
