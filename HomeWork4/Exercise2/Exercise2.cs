//Кустарников Иван

//а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив 
//заданной размерности и заполняющий массив числами от начального значения с заданным шагом. Создать 
//свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех 
//элементов массива, метод Multi, умножающий каждый элемент массива на определенное число, свойство 
//MaxCount, возвращающее количество максимальных элементов. В Main продемонстрировать работу класса.

//б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace HomeWork4
    {
        class Program
        {
            public class MyArrays
            {
                int[] a;
                Random rnd = new Random();

                //конструктор, создающий массив, который может принимать значения от 0 до 10
                public MyArrays(int n)
                {
                    a = new int[n];
                    for (int i = 0; i < n; i++)
                        a[i] = rnd.Next(0, 10);
                }

                //конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом
                public MyArrays(int n, int start, int step)
                {
                    a = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        a[i] = start + (step * i);
                    }
                }

                //конструктор, который загружает данные из файла
                public MyArrays(string filename)
                {
                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(filename);
                        string s = sr.ReadLine();
                        int n = int.Parse(s);
                        a = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            s = sr.ReadLine();
                            a[i] = int.Parse(s);
                        }
                    }
                    catch (ArgumentException)
                    {

                    }
                    catch (DirectoryNotFoundException)
                    {

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        sr?.Close();
                    }
                }

                //свойство Sum, которые возвращают сумму элементов массива
                public int Sum
                {
                    get
                    {
                        int sum = 0;
                        for (int i = 0; i < a.Length; i++)
                        {
                            sum += a[i];
                        }
                        return sum;
                    }
                }

                //метод Inverse, меняющий знаки у всех элементов массив
                public void Inverse()
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] *= -1;
                    }
                }

                //метод Multi, умножающий каждый элемент массива на определенное число
                public void Multi(int x)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = x * a[i];
                    }
                }

                //свойство MaxCount, возвращающее количество максимальных элементов
                public int MaxCount
                {
                    get
                    {
                        int max = a.Max();
                        int count = 0;
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i] == max)
                                count++;
                        }
                        return count;
                    }
                    
                }

                //Вывод результата в строку
                override public string ToString()
                {
                    string strArr = "";
                    foreach (int x in a)
                        strArr = strArr + x + " ";
                    return strArr;
                }
                
                //Запись данных в файл
                public void Write(string filename)
                {
                    StreamWriter sw = null;
                    sw = new StreamWriter(filename);
                    sw.WriteLine(a.Length);
                    for (int i = 0; i < a.Length; i++)
                        sw.WriteLine(a[i]);
                    sw.Close();
                }

                public void Rec(string filename)
                {
                    //переводим данные из чисел в строки
                    string[] a_string = new string[a.Length];
                    for (int i = 0; i < a_string.Length; i++)
                        a_string[i] = Convert.ToString(a[i]);

                    //пишем массив со строками в файл
                    System.IO.File.WriteAllLines(filename, a_string);
                }
            }

            static void Read(string filename)
            {
                if (File.Exists(filename))
                {
                    //Считываем все строки из файла
                    string[] s = File.ReadAllLines(filename);
                    for (int i = 0; i < s.Length; i++)
                    {
                        Console.Write(s[i] + " ");
                    }
                    Console.WriteLine();
                }
                else Console.WriteLine("Error load file");
            }

            static void Pause(string msg)
            {
                Console.Write(msg);
                Console.ReadKey();
            }

            static void Main()
            {
                // Описание параметров консоли
                Console.Title = "Кустарников Иван, Ставрополь";
                Console.SetWindowSize(80, 20);
                Console.SetBufferSize(80, 20);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "Условие домашнего задания\n" +
                    "а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, " +
                    "создающий массив заданной размерности и заполняющий массив числами от начального " +
                    "значения с заданным шагом. Создать свойство Sum, которые возвращают сумму элементов " +
                    "массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, " +
                    "умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее " +
                    "количество максимальных элементов. В Main продемонстрировать работу класса. " +
                    "\nб) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.SetWindowSize(80, 45);
                Console.SetBufferSize(80, 45);
                Console.Clear();

                MyArrays arr1 = new MyArrays(10, 0, 3);
                Console.WriteLine($"Конструктор, создающий массив заданной размерности " +
                    $"и заполняющий массив числами от начального значения с заданным шагом. \n\n{arr1.ToString()}");
                Console.WriteLine(new string('-', 80));

                Console.WriteLine($"Сумма элементов arr1: {arr1.Sum}");
                Console.WriteLine(new string('-', 80));

                arr1.Inverse();
                Console.Write($"Инверсия элементов arr1: \n{arr1.ToString()}\n");
                Console.WriteLine(new string('-', 80));

                arr1.Multi(2);
                Console.Write($"Умножаем на 2 элементы arr1: \n{arr1.ToString()}\n");
                Console.WriteLine(new string('-', 80));

                Console.WriteLine($"Количество максимальных элементов в массиве arr1: {arr1.MaxCount}");
                Console.WriteLine(new string('-', 80));
                MyArrays arr2 = new MyArrays(100);
                Console.WriteLine($"Количество максимальных элементов в массиве arr2: {arr2.MaxCount}");
                Console.WriteLine(new string('-', 80));

                string filename = @"D:\temp\data1.txt";

                Console.WriteLine("\nПроверяем запись в файл массива arr2 и чтение файла с  данными");
                arr2.Write(filename);
                Read(filename);
                Console.WriteLine(new string('-', 80));

                MyArrays arr3 = new MyArrays(filename);
                Console.WriteLine("\nПроверяем чтение из файла с помощью конструктора");
                Console.WriteLine(arr3.ToString());
                Console.WriteLine(new string('-', 80));

                string filename2 = @"D:\temp\data2.txt";
                MyArrays arr4 = new MyArrays(20);
                arr4.Write(filename2);
                Console.WriteLine("\nПроверяем чтение из файла с помощью метода");
                Console.WriteLine(arr4.ToString());
                Console.WriteLine(new string('-', 80));

                Pause("\nНажмите любую клавишу чтобы выйти...");
            }
        }
    }
}
