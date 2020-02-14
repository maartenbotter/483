using System;
using System.Collections.Generic;
using System.Reflection;

namespace ScrambleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide 8 arguments");
            var arguments = new List<string>();
            for(int i = 0; i < 8; i++)
            {
                arguments.Add(Console.ReadLine());
            }
            Console.WriteLine($"Return: {ShuffleList(arguments)}");
        }

        private static string ShuffleList(List<string> inputList)
        {
            string shuffledListString = "";

            Random r = new Random();
            while (inputList.Count > 0)
            {
                int randomIndex = r.Next(0, inputList.Count);
                shuffledListString += $"{inputList[randomIndex]} "; //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return shuffledListString; //return the new random list
        }
    }
}
