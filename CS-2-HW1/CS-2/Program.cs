using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2
{
    class Vector
    {
        private double x, y;

        public Vector()
        {            
        }

        public Vector(double x,double y):this()
        {
            this.x = x;
            this.y = y;
        }


        public Vector(double x):this(x,x)
        {
            
        }

        public void SetX(double value)
        {
            this.x = value;
        }

        public double GetX()
        {
            return this.x;
        }

        public void SetY(double value)
        {
            this.y = value;
        }

        public double GetY()
        {
            return this.y;
        }

        public double X
        {
            get//акцессоры доступа
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get//акцессоры доступа
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public static Vector operator+(Vector v1,Vector v2)
        {            
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator +(Vector v1, double add)
        {
            return new Vector(v1.x + add, v1.y + add);
        }


        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector operator &(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1.x == v2.x && v1.y == v2.y);
        }

        public static implicit operator double (Vector x)
        {
            return x.x;
        }

        public static explicit operator Vector(double x)
        {
            return new Vector(x);
        }


        //public double X1 { get; set; }

    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
            X = Y = 0;
        }
    }


    class NewClass : Point
    {
        public double Z { get; set; }

        public NewClass()
        {
            Z = 0;
        }
    }

    class NewClass2//наследование агрегированием
    {
        Point P { get; set; }
        public double Z { get; set; }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            NewClass newClass = new NewClass();


















            Vector v1=new Vector(), v2=new Vector(2,4),v3=new Vector(5) ,vect4;
            v1.SetX(10);            
            v1.SetY(20);
            Console.WriteLine("x={0} y={1}", v1.GetX(), v1.GetY());
            v1.X = 10;
            v1.Y = 20;
            Console.WriteLine("x={0} y={1}", v1.X, v1.Y);
            Vector v10 = v1 + v2;
            Vector v11 = v1 + 5;
            Vector vector = (Vector)10;

            double p = vector;

            Point a=new Point();
            a.X = 10;
            a.Y = 20;

            int u = (int)50.4;

            bool b = vector == v1;
            bool b1 = vector.Equals(v1);
        }
    }
}
