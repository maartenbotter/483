using System;
using System.Collections.Generic;
using System.Reflection;

namespace ScrambleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Available assemblies:");
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            Dictionary<int, string> assemblyNameDict = new Dictionary<int, string>();
            for (int i = 0; i < currentAssemblies.Length; i++)
            {
                var dictEntryNumber = i + 1;
                assemblyNameDict.Add(dictEntryNumber, currentAssemblies[i].FullName);
                Console.WriteLine($"{dictEntryNumber}: {assemblyNameDict[dictEntryNumber]}");
            }
            Console.WriteLine("Choose a number");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int intInput) && assemblyNameDict.ContainsKey(intInput)) 
                ShowClassNames(assemblyNameDict[intInput]);
            else 
                Console.WriteLine("Invalid input");
        }

        private static void ShowClassNames(string assemblyName)
        {
            try
            {
                Assembly assembly = Assembly.Load(assemblyName);
                foreach (Type type in assembly.GetTypes())
                {
                    Console.WriteLine(type.FullName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input, Stacktrace:\n{e.StackTrace}");
            }
        }
    }
}
