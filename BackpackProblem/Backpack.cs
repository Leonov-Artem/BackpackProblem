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
            this.objects = objects;
            this.target_weight = target_weight;
            solution = new List<T>();
        }

        /// <summary>
        /// Поиск решения перебором всех объектов
        /// </summary>
        /// <returns></returns>
        public List<T> Solution()
        {
            List<T> backpack;
            for (int i = 0; i < objects.Length; i++)
            {
                backpack = GetSolutionForObject(i);
                if (backpack.Count != 0)
                    return backpack;
            }
            return new List<T>();
        }
        /// <summary>
        /// Поиск решение для конкретного объекта из рюкзака
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private List<T> GetSolutionForObject(int i)
        {
            solution.Add(objects[i]);
            if (SolutionProblem(target_weight, objects[i]))
                return solution;
            else
            {
                solution.Remove(objects[i]);
                return new List<T>();
            }
        }
        /// <summary>
        /// Поиска решения алгоритмом с возвратом
        /// </summary>
        /// <param name="target_weight"></param>
        /// <param name="current_weight"></param>
        /// <returns></returns>
        private bool SolutionProblem(T target_weight, T current_weight)
        {
            if (target_weight.CompareTo(current_weight) < 0) return false;              // проверяем тестовое решение
            if (target_weight.CompareTo(current_weight) == 0) return true;              // проверяем, является ли это решение полным

            // расширяем частичное решение 
            for (int i = 0; i < objects.Length; i++)
            {
                if (!solution.Contains(objects[i]))
                {
                    solution.Add(objects[i]);
                    var target = target_weight as dynamic;
                    var current = current_weight as dynamic;

                    if (SolutionProblem(target - current, objects[i])) return true;     // проверяем частичное решение на допустимость
                    solution.Remove(objects[i]);                                        // если расширение не ведет к решению, то отменяем расширение
                }
            }

            //  если мы дошли до этой строки, то решения нет
            return false;
        }
    }
}
