//Иван Кустарников

//1. Построить три класса(базовый и 2 потомка), описывающих двух работников: с почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).
//а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная 
//заработная плата = 20.8 * 8 * почасовая ставка». Для работников с фиксированной оплатой: «среднемесячная заработная плата = фиксированная месячная оплата».
//б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
//в) * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
//г) * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    
    class Program
    {
        static void Pause(string message)
        {
            Console.Write(message);
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            // Описание параметров консоли
            Console.Title = "Кустарников Иван, Ставрополь";
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Кустарников Иван \n \n" +
                    "  Построить три класса (базовый и 2 потомка), описывающих некоторых работников " +
                    "с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).\n" +
                    "  а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной " +
                    "платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная " +
                    "плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой " +
                    "«среднемесячная заработная плата = фиксированная месячная оплата».\n" +
                    "  б) Создать на базе абстрактного класса массив сотрудников и заполнить его.\n" +
                    "  в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().\n" +
                    "  г) *Создать класс, содержащий массив сотрудников, и реализовать возможность " +
                    "вывода данных с использованием foreach.\n");
            Pause("Нажмите любую клавишу, чтобы продолжить");
            Console.Clear();

            Worker[] objs = new Worker[10];
            objs[0] = new HourlyPayment(01, "Иван", 79);
            objs[1] = new FixedPayment(02, "Петр", 40000);
            objs[2] = new HourlyPayment(03, "Василий", 135);
            objs[3] = new FixedPayment(04, "Максим", 32000);
            objs[4] = new HourlyPayment(05, "Игорь", 118);
            objs[5] = new HourlyPayment(06, "Алексей", 250);
            objs[6] = new FixedPayment(07, "Елена", 26000);
            objs[7] = new FixedPayment(08, "Ирина", 28000);
            objs[8] = new FixedPayment(09, "Андрей", 93000);
            objs[9] = new HourlyPayment(10, "Светлана", 130);

            Console.WriteLine("Оригинальный массив\n");
            foreach (Worker obj in objs) 
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Сортировка по заработной плате\n");
            Array.Sort(objs, new SortToPayment());
            foreach (Worker obj in objs)
            {
                Console.WriteLine(obj);
            }

            Pause("\nНажмите любую клавишу, чтобы продолжить");
            Console.Clear();

            Console.WriteLine("Сортировка по ID\n");
            Array.Sort(objs, new SortToID());
            foreach (Worker obj in objs)
            {
                Console.WriteLine(obj);
            }

            Pause("\nНажмите любую клавишу, чтобы продолжить");
            Console.Clear();

            Console.WriteLine("Сортировка по имени\n");
            Array.Sort(objs, new SortToName());
            foreach (Worker obj in objs)
            {
                Console.WriteLine(obj);
            }


            Pause("\nНажмите любую клавишу чтобы выйти...");
        }
    }
}
