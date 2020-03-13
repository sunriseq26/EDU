//Кустарников Иван

//а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
//б) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class distance
        {
            

            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }

            static double Dist(int x1, int x2, int y1, int y2)
            {
                return Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(y2 - y1,2));
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
                    "а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 " +
                    "по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор " +
                    "формата .2f (с двумя знаками после запятой) \n" +
                    "б) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода; \n");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Ввод данных и вычисление
                Console.Write("Введите координату Х1: ");
                int x1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите координату Y1: ");
                int y1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nВведите координату X2: ");
                int x2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите координату Y2: ");
                int y2 = Convert.ToInt32(Console.ReadLine());

                // Вычисление и вывод результата, используя спецификатор формата .2f (с двумя знаками после запятой)
                double r = Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(y2 - y1,2));

                Console.WriteLine("\nВывод результата, используя спецификатор формата .2f (с двумя знаками после запятой) \n" +
                    "Расстояние - {0:F} \n", r);
                Pause("Нажмите любую клавишу, чтобы продолжить");

                // Вычисление и вывод результата, используя метод
                r = Dist(x1, x2, y1, y2);

                Console.WriteLine("\n\nВывод результата, используя метод \n" +
                    "Расстояние - {0:F} \n", r);

                Pause("Для выхода нажмите любую клавишу");

            }
        }
    }
}

