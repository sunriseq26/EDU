// Кустарников Иван

//а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
//б) Сделать задание, только вывод организуйте в центре экрана
//в) * Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class print
        {
            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }

            static void Print(string msg, int x, int y)
            {                
                Console.SetCursorPosition(x, y);
                Console.WriteLine(msg);
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
                    "а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.\n" +
                    "б) Сделать задание, только вывод организуйте в центре экрана\n" +
                    "в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)\n");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Текст, который нужно вывести на экран
                string str = "Иван Кустарников, Ставрополь";

                // а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                Console.WriteLine("Код, который выводит на экран имя, фамилию и город проживания.\n");
                Console.WriteLine(str);
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // б) Сделать задание, только вывод организуйте в центре экрана
                int l = str.Length / 2;
                int a = Console.WindowWidth / 2 - l;
                int b = Console.WindowHeight / 2;
                int c = Console.WindowHeight - 1;

                Console.WriteLine("Код, который организует вывод в центре экрана");
                Console.SetCursorPosition(a, b);
                Console.WriteLine(str);

                Console.SetCursorPosition(0, c);
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
                Console.WriteLine("Код, который выполняет предыдущее задание с использованием метода");
                Print(str, a, b);

                Console.SetCursorPosition(0, c);
                Pause("Для выхода нажмите любую клавишу");
            }
        }
    }
}

