using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_Modul_07
{
    public class Triangle
    {
        public Triangle(int a = 0, int b = 0, int c = 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public static Triangle operator ++(Triangle a)
        {
            return new Triangle(a.a + 1, a.b + 1, a.c + 1);
        }
        public static Triangle operator --(Triangle a)
        {
            return new Triangle(a.a - 1, a.b - 1, a.c - 1);
        }
        public static bool operator true(Triangle a)
        {
            if (a.a == a.b && a.c == a.a)
            {
                return true;
            }
            else return false;
        }
        public static bool operator false(Triangle a)
        {
            if (a.a == a.b && a.c == a.a)
            {
                return false;
            }
            else return true;
        }
        public static Triangle operator *(Triangle a, Triangle b)
        {
            return new Triangle(a.a * a.b);
        }
        public override string ToString()
        {
            return string.Format("Triangle {0},{1},{2}", a, b, c);
        }
    }
    public class point
    {
        public point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }

        public static point operator ++(point a)
        {
            return new point(a.x + 1, a.y + 1);
        }
        public static point operator --(point a)
        {
            return new point(a.x - 1, a.y - 1);
        }
        public static bool operator true(point a)
        {
            if (a.x == a.y)
                return true;
            else
                return false;
        }
        public static bool operator false(point a)
        {
            if (a.x == a.y)
                return false;
            else
                return true;
        }
        public static point operator +(point a, point b)
        {
            return new point(a.x + a.y, b.x + b.y);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", x, y);
        }

    }
    public class money
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        public money(decimal amount, string unit)
        {
            Unit = unit;
            Amount = amount;
        }
        public static money operator +(money a, money b)
        {
            if (a.Unit != b.Unit)
                throw new InvalidOperationException("Нельзя суммировать деньги в разных валютах");
            return new money(a.Amount + b.Amount, a.Unit);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Amount, Unit);
        }

        public static money operator ++(money a)
        {
            return new money(a.Amount + 100, a.Unit);
        }

    }
    public class MyArray
    {
        public int x, y, z;
        public MyArray(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static bool operator ==(MyArray a, MyArray b)
        {
            if ((a.x == b.x) || (a.y == b.y))
                return true;
            else
                return false;
        }
        public static bool operator !=(MyArray a, MyArray b)
        {
            if ((a.x != b.x) || (a.y != b.y))
                return true;
            else
                return false;
        }
        public static bool operator true(MyArray a)
        {
            if ((a.x < 0))
                return true;
            else
                return false;
        }
        public static bool operator false(MyArray a)
        {
            if ((a.x > 0))
                return true;
            else
                return false;
        }
    }
    public class Counter
    {
        public int Second { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Second = x };
        }
        public static explicit operator int(Counter x)
        {
            return x.Second;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle tri = new Triangle();
            tri.a = 5; tri.b = 5; tri.c = 5;
            tri--;
            Console.WriteLine("{0} {1} {2}", tri.a, tri.b, tri.c);
            if (tri)
            {
                Console.WriteLine("Стороны равны!");
            }
            else
            {
                Console.WriteLine("Стороны не равны!");
            }
            Console.WriteLine(tri.a * tri.c);
            Console.WriteLine(tri);
            return;
            MyArray a = new MyArray(1, 2, 8);
            MyArray b = new MyArray(2, 4, 8);
            if (a == b)
            {
                Console.WriteLine("ok");
            }
            else
                Console.WriteLine("no ok");
            if (a.x > 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("no ok");
            }

            Counter count = new Counter() { Second = 63 };


            money myMoney = new money(100, "USD");
            myMoney++;
            money yourMoney = new money(100, "USD");

            try
            {
                money totalSum = myMoney + yourMoney;
                Console.WriteLine(myMoney + " + " + yourMoney + " = " + totalSum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(myMoney + " + " + yourMoney + " = " + ex.Message);
            }


        }
    }
}
