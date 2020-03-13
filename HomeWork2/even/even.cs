//Кустарников Иван

//С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace HomeWork2
    {
        class Even
        {
            static void Main()
            {
                int b = 0;
                while (true)
                {
                    int a = Convert.ToInt32(Console.ReadLine());

                    if (a != 0)
                    {
                        if (a % 2 == 0)
                        { }
                        if (a < 0)
                        {
                            b = b;
                        }
                        else
                            b += a;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine(b);
                Console.ReadKey();
            }
        }
    }
}

