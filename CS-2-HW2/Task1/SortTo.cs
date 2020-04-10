using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class SortToPayment : IComparer<Worker>
    {
        int IComparer<Worker>.Compare(Worker obj1, Worker obj2)
        {
            return obj2.CalcPay().CompareTo(obj1.CalcPay());
        }
    }

    class SortToID : IComparer<Worker>
    {
        int IComparer<Worker>.Compare(Worker obj1, Worker obj2)
        {
            return obj2.id.CompareTo(obj1.id);
        }
    }

    class SortToName : IComparer<Worker>
    {
        int IComparer<Worker>.Compare(Worker obj1, Worker obj2)
        {
            return string.Compare((obj1 as Worker).name, (obj2 as Worker).name);
        }
    }
}
