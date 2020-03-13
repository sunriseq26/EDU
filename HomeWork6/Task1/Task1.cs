//Кустарников Иван

//Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
//Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

using System;


namespace RMI_Stavropol
{
    namespace HomeWork6
    {
        class Program
        {
            delegate double Fun(double x, double y);

            private static double FunPow(double a, double x)
            {
                return a * Math.Pow(x, 2);
            }
            private static double FunSin(double a, double x)
            {
                return a * Math.Sin(x);
            }

            static double EnterText(string msg)
            {
                Console.Write(msg);
                double d = Convert.ToDouble(Console.ReadLine());
                return d;
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
                Console.SetWindowSize(80, 12);
                Console.SetBufferSize(80, 12);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "   Условие домашнего задания\n\n" +
                    "   Изменить программу вывода функции так, чтобы можно было передавать " +
                    "функции типа double (double,double).\nПродемонстрировать работу на функции " +
                    "с функцией a*x^2 и функцией a*sin(x).");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.SetWindowSize(60, 10);
                Console.SetBufferSize(60, 10);
                Console.Clear();

                double a = EnterText("Введите значение double для A: ");
                double x = EnterText("Введите значение double для X: ");

                Fun delegat = FunPow;
                double result = delegat(a, x);
                Console.WriteLine("\nРезультат вывода функции FunPow = "+result);

                delegat = FunSin;
                result = delegat(a, x);
                Console.WriteLine("Результат вывода функции FunSin = " + result);

                Pause("\nНажмите любую клавишу чтобы выйти...");
            }
        }
    }
}