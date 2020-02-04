using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdditionApp
{
    class Program
    {
        private static int num1, num2;

        static void Main(string[] args)
        {
            AddByTask();
            AddByPool();
        }

        private static void GetNumbers()
        {
            try
            {
                Console.WriteLine("Number 1:");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Number 2:");
                num2 = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                GetNumbers();
            }
        }

        private static void AddByTask()
        {
            GetNumbers();
            Thread t = new Thread(Add);
            t.Start();
            t.Join();
        }

        private static void AddByPool()
        {
            GetNumbers();
            ThreadPool.QueueUserWorkItem(Add);
        }

        private static void Add(object stateInfo) => Console.WriteLine($"The result is {num1 + num2}");
    }
}