//Кустарников Иван

//Написать метод, возвращающий минимальное из трех чисел.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace HomeWork2
    {
        class Min
        {
            static int MinNum(int x, int y, int z)
            {
                int m = 0;
                if (x < y & x < z) m = x;
                if (y < z & y < x) m = y;
                if (z < y & z < x) m = z;

                return m;
            }
            static void Main()
            {
                Console.WriteLine("Введите три целых числа");
                Console.Write("\nВведите первое число: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nВведите второе число: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nВведите третье число: ");
                int c = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine($"\nНаименьшее из трех введенных чисел равно: {MinNum(a, b, c)}");
                Console.ReadLine();
            }
        }
    }
}

