//Кустарников Иван

//Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. 
//При возникновении ошибки вывести сообщение. Напишите соответствующую функцию

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

            static void SumPositive()
            {
                Console.Write("Введите целое число: ");

                int b = 0;
                int a = 0;
                while (true)
                {
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Входная строка имела неверный формат");
                    }

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
                    "б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. " +
                    "При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                SumPositive();

                Pause("\nНажмите любую клавишу чтобы выйти...");

            }
        }
    }
}
