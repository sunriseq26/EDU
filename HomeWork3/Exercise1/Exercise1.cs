//Кустарников Иван

//а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;
//б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;

using System;

namespace RMI_Stavropol
{
    namespace HomeWork3
    {
        class Complex
        {
            double im, re;


            public Complex()
            {
                im = 0;
                re = 0;
            }

            public Complex(double _im, double re)
            {
                im = _im;
                this.re = re;
            }
            public Complex Plus(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.im + im;
                x3.re = x2.re + re;
                return x3;
            }

            public Complex Minus(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.im - im;
                x3.re = x2.re - re;
                return x3;
            }

            public Complex Multiplication(Complex x2)
            {
                Complex x3 = new Complex();
                x3.im = x2.re * im + re * x2.im;
                x3.re = x2.re * re - x2.im * im;
                return x3;
            }


            public double Im
            {
                get { return im; }
                set
                {
                    if (value >= 0) im = value;
                }
            }

            public string ToString(string msg)
            {
                return msg + re + "+" + im + "i";
            }
        }



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
                    "а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;\n " +
                    "б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                Complex complex1;
                complex1 = new Complex(1, 1);

                Complex complex2 = new Complex(2, 2);
                complex2.Im = 3;
                Complex resultPlus;
                resultPlus = complex1.Plus(complex2);

                Complex complex3 = new Complex(2, 3);
                Complex resultMinus;
                resultMinus = complex1.Minus(complex3);

                Complex complex4 = new Complex(1, 8);
                Complex resultMultiplication;
                resultMultiplication = complex1.Multiplication(complex4);

                Console.WriteLine(resultPlus.ToString("Метод сложения комплексных чисел: "));
                Console.WriteLine(resultMinus.ToString("Метод вычитания комплексных чисел: "));
                Console.WriteLine(resultMultiplication.ToString("Метод умножения комплексных чисел: "));
                Pause("\nНажмите любую клавишу чтобы выйти...");

            }
        }
    }
}
