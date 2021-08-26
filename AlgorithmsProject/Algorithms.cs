using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProject
{
    class Algorithms
    {
        public int[] GetNextNNumbersWithFibonacci(int number, int numbersToBeReturned)
        {
            int previous = number - 1, next = number;
            int[] fibonacci = new int[numbersToBeReturned];

            for (int i = 0; i < numbersToBeReturned; i++)
            {
                fibonacci[i] = previous;
                previous = next;
                next = fibonacci[i] + next;
            }

            return fibonacci;
        }

        public (int, List<int>) GetMaxNumberAndMaxQuantityOfLists(List<int>[] arrayList)
        {
            int maxNumber = int.MinValue;
            int maxQuantity = 0;
            List<int> listWithMaxQuantity = new List<int>();

            foreach (List<int> list in arrayList)
            {
                foreach (int number in list)
                {
                    maxNumber = number >= maxNumber ? number : maxNumber;
                }

                if (maxQuantity <= list.Count)
                {
                    maxQuantity = list.Count;
                    listWithMaxQuantity = list;
                }
            }

            return (maxNumber, listWithMaxQuantity);
        }
    }
}
