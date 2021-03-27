using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWithoutBlocking
{
    class Program
    {
        private static int DoCount()
        {
            int counter = 0;
            for (int i = 0; i < 100000; i++)
            {
                ++counter;
            }
            return counter;
        }

        private static async Task Main(string[] args)
        {
            int workerCount = 100;
            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 0; i < workerCount; i++)
            {
                //start all the worker tasks
                tasks.Add(Task.Run(() => DoCount()));
            }
            //asynchronously wait for all tasks to complete
            //and collect the results
            var results = await Task.WhenAll(tasks);
            //sum all the results
            int totalCount = results.Sum();
            Console.WriteLine(totalCount);
            Console.ReadLine();
        }

 
    }
}