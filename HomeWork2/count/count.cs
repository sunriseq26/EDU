//Кустарников Иван

//Написать метод подсчета количества цифр числа.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace HomeWork2
    {
        class Count
        {
            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }
            static int CountNum(string str)
            {
                int n = int.Parse(str), count = 0;

                while (n != 0)
                {
                    n /= 10;
                    count++;
                }
                return count;
            }
            static void Main()
            {
                Console.WriteLine("Введите число для расчета: ");
                string str = Console.ReadLine();

                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"Число {str} имеет {CountNum(str)} чисел");
                Pause("\nДля выхода нажмите любую клавишу");
            }
        }
    }

}
