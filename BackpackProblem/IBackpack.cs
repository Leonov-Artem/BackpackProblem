using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProblem
{
    interface IBackpack<T>
    {
        List<T> Solution();
    }
}
