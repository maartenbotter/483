using System;

namespace EventHandlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var eClass = new EventClass();
            eClass.Action += (sender, e) => Console.WriteLine("Event called");
            eClass.Execute();
        }

        public void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Event");
        }
    }
}
