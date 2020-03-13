//Кустарников Иван

//С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
//Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;

using System;

namespace RMI_Stavropol
{
    namespace HomeWork3
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

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). " +
                    "Требуется подсчитать сумму всех нечетных положительных чисел. " +
                    "Сами числа и сумму вывести на экран, используя tryParse;");
                Console.Clear();

                Console.Write("Введите целое число: ");
                int b = 0;

                while (true)
                {
                    int a;
                    bool flag;
                    
                    do
                    {
                        
                        flag = int.TryParse(Console.ReadLine(), out a);
                        if (!flag) Console.Write("\nОшибка! Необходимо ввести целое число. Повторите ввод: ");

                    }
                    while (!flag);

                    if (a != 0)
                    {
                        if (a > 0 && a % 2 == 1)
                            b += a;
                        Console.Write("\nВведите следующее число: ");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine($"\nСумма всех нечетных положительных чисел равна - {b}");
                Pause("\nНажмите любую клавишу чтобы выйти...");

            }
        }
    }
}
