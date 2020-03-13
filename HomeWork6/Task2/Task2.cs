//Кустарников Иван

//Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
//б) Используйте массив(или список) делегатов, в котором хранятся различные функции.


using System;
using System.IO;
using System.Collections.Generic;

namespace RMI_Stavropol
{
    namespace HomeWork6
    {

        class Program
        {
            public delegate double Function(double x);
            public static double Func1(double x)
            {
                return x * x - 50 * x + 10;
            }

            public static double Func2(double x)
            {
                return x * x - 10 * x + 50;
            }
            public static void SaveFunc(string fileName, double a, double b, double h, Function F)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                double x = a;
                while (x <= b)
                {
                    bw.Write(F(x));
                    x += h;
                }
                bw.Close();
                fs.Close();
            }
            public static double Load(string fileName)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                double min = double.MaxValue;
                double d;
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    // Считываем значение и переходим к следующему
                    d = bw.ReadDouble();
                    if (d < min) min = d;
                }
                bw.Close();
                fs.Close();
                return min;
            }

            static int EnterText(string msg)
            {
                Console.WriteLine(msg);
                int i = int.Parse(Console.ReadLine());
                return i;
            }

            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
            }

            static void Main()
            {
                // Описание параметров консоли
                Console.Title = "Кустарников Иван, Ставрополь";
                Console.SetWindowSize(83, 17);
                Console.SetBufferSize(83, 17);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "   Условие домашнего задания\n\n" +
                    "   Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.\n"+
                    "а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.\n" +
                    "б) Используйте массив(или список) делегатов, в котором хранятся различные функции.");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.SetWindowSize(80, 10);
                Console.SetBufferSize(80, 10);
                Console.Clear();

                //Создаем список
                List<Function> listFunc = new List<Function>();
                listFunc.Add(Func1);
                listFunc.Add(Func2);

                //Вводим значения для выбора функции
                int i = EnterText("Сделайте выбор: введите (1) - для функции Func1 или (2) - для функция Func2");
                
                SaveFunc("data.bin", -100, 100, 0.5, listFunc[i - 1]);
                Console.WriteLine(Load("data.bin"));

                Pause("\nНажмите любую клавишу чтобы выйти...");
            }
        }
    }
}
