// Кустарников Иван
// Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcIMT
{
    class CalcIMT
    {
        static void Pause(string message)
        {
            Console.Write(message);
            Console.ReadKey();
        }

        static double IMT(double m, double h)
        {
            double I = m / (Math.Pow(h, 2));
            return I;
        }

        static void Main()
        {
            // Описание параметров консоли
            Console.Title = "Кустарников Иван, Ставрополь";
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Условия домашнего задания
            Console.WriteLine("Кустарников Иван \n \n" +
                "Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) " +
                "по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах \n");
            Pause("Нажмите любую клавишу, чтобы продолжить");
            Console.Clear();

            // Ввод данных и вычисление
            Console.Write("Введите вашу массу тела в килограммах, разделитель точка: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nВведите ваш рост в метрах, разделитель точка: ");
            double height = Convert.ToDouble(Console.ReadLine());

            double I = weight / (Math.Pow(height, 2));


            // Вывод результата используя форматированный вывод
            Console.WriteLine("\nВаш индекс массы тела (ИМТ) равен - {0:N} \n", I);


            if (I < 19)
            {
                Console.WriteLine("\nВам необходимо набрать вес");
            }
            if (I > 25)
            {
                Console.WriteLine("\nВам необходимо похудеть");
            }
            if (I > 19 && I < 25)
            {
                Console.WriteLine("\nВаш вес в норме");
            }

            Pause("\nДля выхода нажмите любую клавишу");
        }
    }
}
