//Кустарников Иван

//* Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class method
        {
            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }

            static void Pause()
            {
                Console.ReadKey();
            }

            static void PrintCenter(string msg)
            {
                int l = msg.Length / 2;
                int a = Console.WindowWidth / 2 - l;
                int b = Console.WindowHeight / 2;
                int c = Console.WindowHeight - 1;

                Console.SetCursorPosition(a, b);
                Console.WriteLine(msg);
            }

            static double Dist(int x1, int x2, int y1, int y2)
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }

            static int Sum(int x, int y)
            {
                return x + y;
            }

            static void Main()
            {
                
            }
        }
    }
}

