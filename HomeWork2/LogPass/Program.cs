//Кустарников Иван

//Реализовать метод проверки логина и пароля. На вход подается логин и пароль.
//На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
//Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
//С помощью цикла do while ограничить ввод пароля тремя попытками.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMI_Stavropol
{
    namespace LogPass
    {
        class Program
        {
            // Метод проверки на наличие пользователя в БД.
            public static bool userCheck(string user, string password)
            {
                // проверяем наличие пользователя
                if (user == "root")
                {
                    Console.WriteLine("Пользователь найден!");
                    if (passCheck(password) == true) // Проверяем пароль методом passCheck();
                    {
                        Console.WriteLine("Пароль правильный!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Пароль не правильный!");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("Ошибка: Пользователь не найден!");
                    return false; // пользователя нет в БД.
                }

            }

            // Метод проверки пароля пользователя
            public static bool passCheck(string password)
            {
                if (password == "GeekBrains")
                {
                    return true; // пароль совпал
                }
                else return false; // пароль не совпал
            }
            static void Main()
            {
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

                    if (userCheck(userName, userPassword) == false) // Проверка логина и пароля
                    {
                        if (i > 2) // Лимит попыток
                        {
                            Console.WriteLine("Доступ заблокирован: Превышен лимит попыток!");
                            break; // выход из цикла
                        }
                        else
                        {
                            Console.WriteLine($"Попытка №: {i + 1}"); // Вывод номера попытки ввода данных
                            Console.WriteLine("Ошибка: Данные не верные!"); // Вывод ошибки

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

