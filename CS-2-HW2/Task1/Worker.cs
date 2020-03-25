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
        public int id;
        public string name;
        public double rate;
        public Worker(int id, string name, double rate)
        {
            this.id = id;
            this.name = name;
            this.rate = rate;
        }
        public abstract double CalcPay();
        public override string ToString()
        {
            return string.Format("ID:{0,4}, Имя:{1,8}, з/п={2,9:f2}", id, name, CalcPay());
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
            return 20.8 * 8 * rate;
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
            return rate;
        }
        public override string ToString()
        {
            return string.Format("Работник с фиксированной ставкой {0}", base.ToString());
        }
    }
}
