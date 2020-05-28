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
    abstract class Worker
    {
        //Свойства
        public int ID { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public Worker(int id, string name, double rate)
        {
            this.ID = id;
            this.Name = name;
            this.Rate = rate;
        }
        public abstract double CalcPay();
        public override string ToString()
        {
            return string.Format("ID:{0,4}, Имя:{1,8}, з/п={2,9:f2}", ID, Name, CalcPay());
        }

    }

    class HourlyPayment : Worker
    {
        public HourlyPayment(int id, string name, double rate) : 
            base(id, name, rate)
        {
            
        }
        public override double CalcPay()
        {
            return 20.8 * 8 * Rate;
        }
        public override string ToString()
        {
            return string.Format("Работник с почасовой ставкой     {0}", base.ToString());
        }
    }

    class FixedPayment : Worker
    {
        public FixedPayment(int id, string name, double rate) :
            base(id, name, rate)
        {

        }
        public override double CalcPay()
        {
            return Rate;
        }
        public override string ToString()
        {
            return string.Format("Работник с фиксированной ставкой {0}", base.ToString());
        }
    }
}
