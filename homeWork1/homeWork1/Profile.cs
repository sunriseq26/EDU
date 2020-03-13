//Кустарников Иван

//1. Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
//а) используя склеивание;
//б) используя форматированный вывод;
//в) * используя вывод со знаком $.

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class Profile
        {
            static void Pause(string message)
            {
                Console.Write(message);
                Console.ReadKey();
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
                    "Написать программу «Анкета». Последовательно " +
                    "задаются вопросы (имя, фамилия, возраст, рост, вес). В результате " +
                    "вся информация выводится в одну строчку. \n " +
                    "а) используя склеивание; \n " +
                    "б) используя форматированный вывод; \n " +
                    "в) *используя вывод со знаком $.\n");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Ввод данных
                
                Console.Write("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                Console.Write("\nВведите вашу фамилию: ");
                string lastName = Console.ReadLine();

                Console.Write("\nВведите ваш возраст: ");
                int age = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("\nВведите ваш рост (см): ");
                int height = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("\nВведите ваш вес (с точностью до сотых, разделитель точка): ");
                double weight = Convert.ToDouble(Console.ReadLine());
                
                // Вывод результата используя склеивание
                Console.WriteLine("\n\nВывод результата, используя склеивание: \n" + 
                    lastName + " " + firstName + ", возраст - " + age + " лет, рост - " + height +
                    " см, вес - " + weight + " кг \n");
                Pause("Нажмите любую клавишу, чтобы продолжить");

                // Вывод результата используя форматированный вывод
                Console.WriteLine("\n\nВывод результата, используя форматированный вывод: \n" +
                    "{0} {1}, возраст - {2:D} лет, рост - {3:D} cм, вес - {4:N} кг \n", lastName, firstName, age, height, weight);
                Pause("Нажмите любую клавишу, чтобы продолжить");

                // *Результат, используя вывод со знаком $
                Console.WriteLine($"\n\n*Результат, используя вывод со знаком $: \n" +
                    $"{lastName} {firstName}, возраст - {age:D} лет, рост - {height:D} cм, вес - {weight:N} кг \n");

                Pause("Для выхода нажмите любую клавишу");
            }
        }
    }
}

