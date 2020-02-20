using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string str = @"Здравствуйте уважаемы форумчане. 
Попросили написать программу, которая считает количество 
встречаемости каждой буквы в тексте.
Подскажите как подсчитать эти смволы? Заранее спасибо!";
        Console.WriteLine("Введите символ:");
        string s = Console.ReadLine();
        int count = str.ToCharArray().Where(c => c == s[0]).Count();
        Console.WriteLine(count);
        Console.ReadKey();


    }
}