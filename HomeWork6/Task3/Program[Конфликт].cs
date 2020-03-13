//1.	Сколько всего студентов?
//2.	Сколько всего бакалавров?
//3.	Сколько всего магистров?
//4.	Вывести всех студентов(по фио) в алфавитном порядке.

using System;
using System.Collections.Generic;
using System.IO;

namespace BigFiles_List_Generic
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string univercity;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        int age;

        //Создаем конструктор
        public Student(string firstName, string lastName, string univercity, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.univercity = univercity;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return String.Format("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}{7,5}{8,10}", firstName, lastName, univercity, faculty, department, age, course, group, city);
        }
    }

    class Program
    {
        static int MyMethod(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
        {
            //Сравниваем две строки
            //return String.Compare(st1.firstName, st2.firstName);
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            return 0;
        }

    static void Main(string[] args)
        {
            int bakalav = 0;
            int magistr = 0;
            //Создаем список студентов
            List<Student> list = new List<Student>();
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students_4.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    //Добавляем в список новый экземляр класса Student
                    Student t;
                    t=new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(t);
                    
                    //Одновременно подсчитываем кол-во бакалавров и магистров
                    if (t.course < 5) bakalav++; else magistr++;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
            //for (int i = 0; i < list.Count; i++) ;
            Console.WindowWidth = 160;
            Console.BufferWidth= 160;
            //Можно оставить просто MyMethod, но помнить, что мы создаем объект-делегат, который передается в метод Sort
            list.Sort(MyMethod);
           // foreach (var v in list) Console.WriteLine(v);
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalav);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
