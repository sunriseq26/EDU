//Кустарников Иван

//Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах

using System;

namespace RMI_Stavropol
{
    namespace homeWork1
    {
        class IMT
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
                    "Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) " +
                    "по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах \n");
                Pause("Нажмите любую клавишу, чтобы продолжить");
                Console.Clear();

                // Ввод данных и вычисление
                Console.Write("Введите вашу массу тела в килограммах, разделитель точка: ");
                double m = Convert.ToDouble(Console.ReadLine());

                Console.Write("\nВведите ваш рост в метрах, разделитель точка: ");
                double h = Convert.ToDouble(Console.ReadLine());
                
                double I = m / (h * h);
                
                // Вывод результата используя форматированный вывод
                Console.WriteLine("\nВаш индекс массы тела (ИМТ) равен - {0:N} \n", I);

                Pause("Для выхода нажмите любую клавишу");
            }
        }
    }
}
