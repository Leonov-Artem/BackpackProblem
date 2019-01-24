using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int weight = 16;
            int[] objects = new int[] { 11, 4, 1, 5 };

            Backpack<int> backpack = new Backpack<int>(objects, weight);
            List<int> solution = backpack.Solution();

            if (solution.Count != 0)
            {
                Console.Write($"Чтобы собрать рюкзак массой {weight} из объектов ");    Print(objects);
                Console.Write($" необходимо взять ");                                   Print(solution);
            }
            else
            {
                Console.Write($"Из объектов ");
                Print(objects);
                Console.Write($" нельзя собрать рюкзак массой {weight}");
            }

            Console.ReadKey();
        }
        static void Print(int[] array)
        {
            foreach (var num in array)
                Console.Write(num + " ");
        }
        static void Print(List<int> list)
        {
            foreach (var elem in list)
                Console.Write(elem + " ");
            Console.WriteLine();
        }
    }
}
