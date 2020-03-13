//Кустарников Иван

//Написать программу обмена значениями двух переменных.
//а) с использованием третьей переменной;
//б) * без использования третьей переменной.

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class change
        {
            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }

            static void Output(int x, int y)
            {
                Console.WriteLine("\nЗначения переменных до обмена: \n" +
                    "A = {0:D}, B = {1:D} \n", x, y);
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
                    "Написать программу обмена значениями двух переменных.\n" +
                    "а) с использованием третьей переменной;\n" +
                    "б) *без использования третьей переменной.\n");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Ввод данных и вычисление

                Console.Write("Введите целое число А: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите целое число В: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Вывод значений введеных данных
                Output(a, b);
                
                // обмен значениями двух переменных с использованием третьей
                int tmp; // введена третья переменная

                tmp = a;
                a = b;
                b = tmp;

                // Вывод результата
                Console.WriteLine("\nЗначения переменных после обмена (с использованием третьей): \n" +
                    "A = {0:D}, B = {1:D} \n", a, b);
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // обмен значениями двух переменных без использования третьей
                Output(a, b);

                // обмен значениями двух переменных без использования третьей
                a = a + b;
                b = b - a;
                b = -b;
                a = a - b;

                // Вывод результата
                Console.WriteLine("\nЗначения переменных после обмена (без использования третьей): \n" +
                    "A = {0:D}, B = {1:D} \n", a, b);
                Pause("Для выхода нажмите любую клавишу");
            }
        }
    }
}

