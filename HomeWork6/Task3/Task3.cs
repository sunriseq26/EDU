//Кустарников Иван

//Переделать программу «Пример использования коллекций» для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента;
//д) разработать единый метод подсчета количества студентов по различным параметрам
//выбора с помощью делегата и методов предикатов.
//*Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в начало программы условие и свою фамилию. Все программы сделайте в одном решении.

using System;
using System.Collections.Generic;
using System.IO;

namespace RMI_Stavropol
{
    namespace HomeWork6
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
            public int age;

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

        delegate bool Is(Student s);


        class Program
        {
            static int MyMethod(Student st1, Student st2)//Создаем метод для сравнения для экземпляров
            {
                //Сравниваем две строки
                // return String.Compare(st1.firstName, st2.firstName);
                if (st1.course > st2.course) return 1;
                if (st1.course < st2.course) return -1;
                return 0;
            }

            static bool IsAgeBigger18(Student student)
            {
                return student.age > 18;
            }

            static int CountStudents(List<Student> students, Is IS)
            {
                int count = 0;
                foreach (Student student in students)
                {
                    if (IS(student)) count++;
                }
                return count;
            }

            static void Main(string[] args)
            {
                int bakalav = 0;
                int magistr = 0;
                //Создаем список студентов
                List<Student> list = new List<Student>();
                DateTime dt = DateTime.Now;
                StreamReader sr = new StreamReader("students_4.csv");
                //File.ReadAllLines("students_4.csv");
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string[] s = sr.ReadLine().Split(';');
                        //Добавляем в список новый экземляр класса Student
                        Student t;
                        t = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), Convert.ToInt32(s[6]), int.Parse(s[7]), s[8]);
                        list.Add(t);
                        //Одновременно подсчитываем кол-во бакалавров и магистров
                        if (t.course == 4) bakalav++;
                        if (t.course == 6) magistr++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                sr.Close();
                Console.WindowWidth = 160;
                Console.BufferWidth = 160;
                //Можно оставить просто MyMethod, но помнить, что мы создаем объект-делегат, который передается в метод Sort
                //list.Sort(MyMethod);
                //foreach (var v in list) Console.WriteLine(v.ToString());
                Console.WriteLine("Всего студентов:" + list.Count);
                Console.WriteLine("Магистров:{0}", magistr);
                Console.WriteLine("Бакалавров:{0}", bakalav);
                Console.WriteLine("Кол-во студентов старше 18", CountStudents(list, delegate (Student s)
                {
                    return s.age > 18;
                }));
                Console.WriteLine("Кол-во студентов старше 18", CountStudents(list, IsAgeBigger18));
                Console.WriteLine(DateTime.Now - dt);
                Console.ReadKey();
            }
        }
    }
}

