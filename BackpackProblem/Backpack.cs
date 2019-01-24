using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProblem
{
    class Backpack<T> : IBackpack<T> where T : IComparable
    {
        private T[] objects;
        private T target_weight;
        private List<T> solution;

        public Backpack(T[] objects, T target_weight)
        {
            this.objects = object;
            this.target_weight = target_weight;
            solution = new List<T>();
        }
    }
}
