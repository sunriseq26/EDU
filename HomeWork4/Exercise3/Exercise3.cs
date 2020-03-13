//Кустарников Иван

//Решить задачу с логинами из предыдущего урока, 
//только логины и пароли считать из файла в массив. 
//Создайте структуру Account, содержащую Login и Password.

using System;
using System.IO;

namespace RMI_Stavropol
{
    struct Account
    {
        public static string DBLogIn = AppDomain.CurrentDomain.BaseDirectory + "dblogin.txt";
        public static int re = 0;
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
    
    namespace LogPass
    {
        class Program
        {

            public static string DBLogIn = AppDomain.CurrentDomain.BaseDirectory + "dblogin.txt";
            public static string DBtest = AppDomain.CurrentDomain.BaseDirectory + "dbtest.txt";


            static void Pause(string msg)
            {
                Console.Write(msg);
                Console.ReadKey();
            }
            static void Main()
            {
                // Описание параметров консоли
                Console.Title = "Кустарников Иван, Ставрополь";
                Console.SetWindowSize(80, 10);
                Console.SetBufferSize(80, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                // Условия домашнего задания
                Console.WriteLine("Кустарников Иван \n \n" +
                    "Решить задачу с логинами из предыдущего урока, " +
                    "только логины и пароли считать из файла в массив. " +
                    "Создайте структуру Account, содержащую Login и Password.");
                Pause("\nНажмите любую клавишу, чтобы продолжить");
                Console.SetWindowSize(40, 20);
                Console.SetBufferSize(40, 20);
                Console.Clear();

                string[] db = new string[2];
                int i = 1;
                

                Console.WriteLine($"Попытка №: {i}"); // Вывод номера попытки ввода данных

                Console.Write("Введите логин: ");
                string userName = Console.ReadLine(); // Вводим логин

                Console.Write("Введите пароль: ");
                string userPassword = Console.ReadLine(); // Вводим пароль

                

                // начинаем цикл do while
                do
                {
                    Console.Clear(); // Чистка консоли
                    bool x = Account.Check(userName, userPassword, db);

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

                            Console.Write("Введите логин: ");
                            userName = Console.ReadLine(); // Вводим логин

                            Console.Write("Введите пароль: ");
                            userPassword = Console.ReadLine(); // Вводим пароль
                            i++; // операция инкремента
                        }
                    }

                    else
                    {
                        Console.WriteLine("Доступ открыт!");
                        break; // выход из цикла
                    }

                } while (true); // вечный цикл



                Console.ReadKey();

            }
        }
    }
}

