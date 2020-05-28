//Иван Кустарников

//1. Построить три класса(базовый и 2 потомка), описывающих двух работников: с почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).
//а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная 
//заработная плата = 20.8 * 8 * почасовая ставка». Для работников с фиксированной оплатой: «среднемесячная заработная плата = фиксированная месячная оплата».
//б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
//в) * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
//г) * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

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
            return obj1.CalcPay().CompareTo(obj2.CalcPay());
        }
    }

    class SortToID : IComparer<Worker>
    {
        int IComparer<Worker>.Compare(Worker obj1, Worker obj2)
        {
            return obj1.ID.CompareTo(obj2.ID);
        }
    }

    class SortToName : IComparer<Worker>
    {
        int IComparer<Worker>.Compare(Worker obj1, Worker obj2)
        {
            return string.Compare(obj1.Name, obj2.Name);
        }
    }
}
