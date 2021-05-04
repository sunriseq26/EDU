using System;

namespace Pattern_HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте вас приветствует математическая программа" +
                              "\nпожалуйста введите число. ");

            String S = Console.ReadLine();

            MathFactorial(S);
            
        }

        static void MathFactorial(string message)
        {
            if (message == "q"){
                return;
            }
            
            int M = Int32.Parse(message);
            int c1 = 1; 
            int c2 = 0;
            int c3 = 0;
            
            for (int i = 1; i <= M; i++)
            {
                c1 = c1*i;
                c2 = c2 + i;
                if (i%2 == 0)
                {
                    c3 = i;
                }
            }
            
            Console.WriteLine("Факториал равет " + c1 + 
                              "\nСумма от 1 до N равна " + c2 + 
                              "\nМаксимальное четное число меньше N равно " + c3);
            
            Console.ReadLine();
        }
    }
}