//Кустарников Иван

//Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения 
//от –10 000 до 10 000 включительно. Написать программу, позволяющую найти и вывести количество 
//пар элементов массива, в которых хотя бы одно число делится на 3. В данной задаче под парой 
//подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 
//6; 2; 9; –3; 6 – ответ: 4.

using System;

namespace RMI_Stavropol
{
    namespace HomeWork4
    {
        public class MyArray
        {
            //Приватное поле-массив класса Array 
            private int[] a;


            //Конструктор массива с заполением случаяными числами 
            public MyArray(int n, int min, int max)
            {
                a = new int[n];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                    a[i] = random.Next(min, max+1);
            }

            //Метод подсчета пар чисел, которые делятся на 3
            public int Divisibility3()
            {
                //Переменная для счетчика
                int count = 0;
                //Переменные остатка
                int b = 0;
                int c = 0;
                //Переменная истинности для деления на 3
                string d;

                //подсчет количества пар делящихся на 3 без остатка
                for (int i = 0; i < a.Length - 1; i++)
                    if (i < a.Length)
                    {
                        if (a[i] % 3 == 0 | a[i + 1] % 3 == 0)
                        {
                            count++;
                            d = " - правда";
                        }
                        else
                        {
                            d = " - ложь";
                        }
                        b = a[i] % 3;
                        c = a[i + 1] % 3;
                        
                        Console.WriteLine($"\n{i+1})Пара чисел: {a[i]} остаток: {b} и {a[i + 1]} остаток: {c} {d}");
                    }  
                        
                    else
                    {
                        break;
                    }
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("\nКоличество пар: " + count);
                return count;
            }

            //Метод вывода массива на консоль
            override public string ToString()
            {
                string strArr = "";
                foreach (int x in a)
                    strArr = strArr + x + " ";
                return strArr;
            }

            class Program
            {
                static void Pause(string msg)
                {
                    Console.Write(msg);
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
                        "   Дан целочисленный массив из 20 элементов. Элементы массива могут принимать " +
                        "целые значения от –10 000 до 10 000 включительно. Написать программу, " +
                        "позволяющую найти и вывести количество пар элементов массива, в которых хотя бы " +
                        "одно число делится на 3. В данной задаче под парой подразумевается два подряд " +
                        "идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.");
                    Pause("\nНажмите любую клавишу, чтобы продолжить");
                    Console.SetWindowSize(80, 50);
                    Console.SetBufferSize(80, 50);
                    Console.Clear();

                    //Объявление массива длинной 20 элементов с минимальным и максимальным значениями 
                    MyArray my = new MyArray(20, -10000, 10000);
                    //Вывод массива на консоль
                    Console.WriteLine(my.ToString());
                    Console.WriteLine(new string('-', 80));
                    // Вывод результата
                    my.Divisibility3();
                    
                    Pause("\nНажмите любую клавишу чтобы выйти...");

                }
            }
        }
    }
}
