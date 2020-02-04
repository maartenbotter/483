using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run3StopAfterLast();
            Run3StopAfterFirst();
        }

        private static void PrintTask(int i)
        {
            Thread.Sleep(i * 5000);
            Console.WriteLine($"The current thread is {i}");
        }

        private static void Run3StopAfterFirst()
        {
            var tasks = new[]
            {
                Task.Factory.StartNew(() => PrintTask(1)),
                Task.Factory.StartNew(() => PrintTask(2)),
                Task.Factory.StartNew(() => PrintTask(3))
            };
            Task.WaitAny(tasks);
            Console.WriteLine("Test");
        }

        private static void Run3StopAfterLast()
        {
            var tasks = new[]
            {
                Task.Factory.StartNew(() => PrintTask(1)),
                Task.Factory.StartNew(() => PrintTask(2)),
                Task.Factory.StartNew(() => PrintTask(3))
            };
            Task.WaitAll(tasks);
            Console.WriteLine("Test");
        }
    }
}
