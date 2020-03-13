﻿//Кустарников Иван

//Создать программу, которая будет проверять корректность ввода логина. 
//Корректным логином будет строка от 2 до 10 символов, содержащая только 
//буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//б) с использованием регулярных выражений.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace HomeWork5
    {
        struct Account
        {
            public string Login { get; set; }
            public string Password { get; set; }

            public static string DBLogIn = AppDomain.CurrentDomain.BaseDirectory + "dblogin.txt";
            
            public static bool Check(string user, string password, string[] db)
            {
                string dbusername = string.Empty;
                string dbpassword = string.Empty;
                using (StreamReader sr = new StreamReader(DBLogIn))
                    for (int i = 0; i < db.Length; i++)
                        db[i] = sr.ReadLine();

                for (int i = 0; i < db.Length; i++)
                {
                    if (db[i] == null)
                        break;
                    int to = db[i].IndexOf(';');
                    dbusername = db[i].Substring(0, to);
                    dbpassword = db[i].Substring(++to);
                    if (user == dbusername && password == dbpassword)
                    {
                        Console.WriteLine($"Добро пожаловать {dbusername}!\n");
                        return true;
                    }


                }
                return false;
            }
        }
        class Program
        {
            public static string DBLogIn = AppDomain.CurrentDomain.BaseDirectory + "dblogin.txt";
            public static string DBtest = AppDomain.CurrentDomain.BaseDirectory + "dbtest.txt";

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
                    "   Создать программу, которая будет проверять корректность ввода логина. " +
                    "Корректным логином будет строка от 2 до 10 символов, содержащая только " +
                    "буквы латинского алфавита или цифры, при этом цифра не может быть первой:\n" +
                    "б) с использованием регулярных выражений.");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.SetWindowSize(50, 20);
                Console.SetBufferSize(50, 20);
                Console.Clear();

                string[] db = new string[2];
                int i = 1;
                Account account = new Account();

                Console.WriteLine($"Попытка №: {i}"); // Вывод номера попытки ввода данных
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Логин должен иметь от 2 до 10 символов, " +
                    "содержать только буквы латинского алфавита или цифры, " +
                    "при этом цифра не может быть первой.");
                Console.WriteLine(new string('-', 50));
                Console.Write("Введите логин: ");
                account.Login = Console.ReadLine(); // Вводим логин

                Console.Write("Введите пароль: ");
                account.Password = Console.ReadLine(); // Вводим пароль

                // начинаем цикл do while
                do
                {
                    Console.Clear(); // Чистка консоли
                    bool x = Account.Check(account.Login, account.Password, db);
                    Regex login_regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{2,9}$");
                    if (login_regex.Match(account.Login).Success) // если совпадение удачно
                    {
                        Console.WriteLine("Условие для логина выполнено\n");
                        if (x == false) // Проверка логина и пароля
                        {
                            if (i > 2) // Лимит попыток
                            {
                                Console.WriteLine("Доступ заблокирован: Превышен лимит попыток!");
                                break; // выход из цикла
                            }
                            else
                            {
                                Console.WriteLine($"Попытка №: {i + 1}\n"); // Вывод номера попытки ввода данных
                                Console.WriteLine("Ошибка: Данные не верны! Повторите ввод...\n"); // Вывод ошибки
                                Console.WriteLine(new string('-', 50));
                                Console.WriteLine("Логин должен иметь от 2 до 10 символов, " +
                                    "содержать только буквы латинского алфавита или цифры, " +
                                    "при этом цифра не может быть первой.");
                                Console.WriteLine(new string('-', 50));

                                Console.Write("Введите логин: ");
                                account.Login = Console.ReadLine(); // Вводим логин

                                Console.Write("Введите пароль: ");
                                account.Password = Console.ReadLine(); // Вводим пароль
                                i++; // операция инкремента
                            }
                        }
                        else
                        {
                            Console.WriteLine("Доступ открыт!");
                            break; // выход из цикла
                        }
                    }
                    else
                    {
                        Console.WriteLine("Условие для логина не выполнено.");
                        if (i > 2) // Лимит попыток
                        {
                            Console.WriteLine("Доступ заблокирован: Превышен лимит попыток!");
                            break; // выход из цикла
                        }
                        else
                        {
                            Console.WriteLine($"Попытка №: {i + 1}\n"); // Вывод номера попытки ввода данных
                            //Console.WriteLine("Ошибка: Данные не верны! Повторите ввод...\n"); // Вывод ошибки
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("Логин должен иметь от 2 до 10 символов, " +
                                "содержать только буквы латинского алфавита или цифры, " +
                                "при этом цифра не может быть первой.");
                            Console.WriteLine(new string('-', 50));

                            Console.Write("Введите логин: ");
                            account.Login = Console.ReadLine(); // Вводим логин

                            Console.Write("Введите пароль: ");
                            account.Password = Console.ReadLine(); // Вводим пароль
                            i++;
                        }
                    }



                } while (true);



                Console.ReadKey();

            }
        }
    }

}
