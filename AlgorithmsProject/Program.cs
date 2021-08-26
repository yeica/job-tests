using System;
using System.Collections.Generic;

namespace AlgorithmsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorithms algorithms = new Algorithms();

            int option;

            do
            {
                Console.WriteLine("Cuál algoritmo ejecutar?\n\n" +
                    "[1] Fibonacci\n" +
                    "[2] Máximo número de listas y lista con más números\n" +
                    "[3] Salir");

                option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Iniciar fibonacci con el num #");
                        int number = int.Parse(Console.ReadLine());
                        //5 as asked
                        string numbers = string.Join(" ", algorithms.GetNextNNumbersWithFibonacci(number, 5));
                        Console.WriteLine(numbers);
                        Console.ReadKey();
                        break;

                    case 2:
                        List<int>[] arrayList = new List<int>[5];

                        arrayList[0] = new List<int>() { 5, 2, 8, 9 };
                        arrayList[1] = new List<int>() { 2, 15, -5, 2, 4 };
                        arrayList[2] = new List<int>() { 1, 8, 15, 0, 20, 21 };
                        arrayList[3] = new List<int>() { 5, 2, 0, 9 };
                        arrayList[4] = new List<int>() { 2, 4 };

                        Console.WriteLine("Mayor número de listas y lista con mayor números, dado (ej.)\n\n");

                        foreach (List<int> list in arrayList)
                        {
                            string listString = string.Join(" ", list);
                            Console.WriteLine($"{listString}");
                        }

                        (int, List<int>) result = algorithms.GetMaxNumberAndMaxQuantityOfLists(arrayList);

                        string maxNumbersList = string.Join(" ", result.Item2);

                        Console.WriteLine($"El mayor número es {result.Item1} y la lista con mayor números es {maxNumbersList}");
                        Console.ReadKey();
                        break;

                    default:
                        Environment.Exit(1);
                        break;
                }
                Console.Clear();
            }
            while (option != 3);
        }
    }
}
