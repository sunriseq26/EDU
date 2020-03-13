//Кустарников Иван

//*Для двух строк написать метод, определяющий, является ли 
//одна строка перестановкой другой. Регистр можно не учитывать:
//    а) с использованием методов C#;
//    б) * разработав собственный алгоритм.

//    Например:
//    badc являются перестановкой abcd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace Homework5
    {
        class Program
        {
            static bool CheckAnagram(string str1, string str2)
            {
                return str1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(str2.Select(Char.ToUpper).OrderBy(x => x));
            }

            static void Pause(string msg)
            {
                Console.Write(msg);
                Console.ReadKey();
            }
            static void Main(string[] args)
            {
                // Описание параметров консоли
                Console.Title = "Кустарников Иван, Ставрополь";
                Console.SetWindowSize(80, 12);
                Console.SetBufferSize(80, 12);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "   Условие домашнего задания\n\n" +
                    "   *Для двух строк написать метод, определяющий, является ли " +
                    "одна строка перестановкой другой. Регистр можно не учитывать:" +
                    "а) с использованием методов C#;");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                Console.Write("Введите первую строку: ");
                string str1 = Console.ReadLine();

                Console.Write("Введите вторую строку: ");
                string str2 = Console.ReadLine();

                Console.WriteLine($"Результат с использованием методов C#: {CheckAnagram(str1, str2)}\n");
                
                Pause("\nНажмите любую клавишу, чтобы продолжить");
            }
        }
    }
}
