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
            foreach (var dataPoint in await FetchIOTDataV1())
            {
                Console.WriteLine(dataPoint);
            }
            Console.WriteLine("Please press Enter to re-run the example using IAsyncEnumerable.");
            Console.ReadLine();
            Console.WriteLine("Step 2: IAsyncEnumerable");
            await foreach (var dataPoint in FetchIOTDataV2())
            {
                Console.WriteLine(dataPoint);
            }

            Console.ReadLine();

        }


        static async Task<IEnumerable<int>> FetchIOTDataV1()
        {
            List<int> dataPoints = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000); 
                dataPoints.Add(i);
            }

            return dataPoints;
        }

        static async IAsyncEnumerable<int> FetchIOTDataV2()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
