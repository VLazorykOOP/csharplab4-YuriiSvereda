using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class Rectangle
    {
        protected int a, b;
        protected int c;

        public int SideA
        {
            get
            {
                return a;
            }
            set
            {
                if (value >= 0)
                {
                    a = value;
                }
                else
                {
                    throw new InvalidOperationException("Attemt to accept negative value of rectangle side");
                }
            }
        }
        public Rectangle() : this(1, 1, 0) { }
        public Rectangle(int a, int b) : this(a, b, 0) { }
        public Rectangle(int a, int b, int c)
        {
            SideA = a;
            SideB = b;
            if (c >= 0 && c <= 15)
            {
                this.c = c;
            }
            else
            {
                throw new ArgumentException("Out of range possible colors");
            }
        }

        public int SideB
        {
            get
            {
                return b;
            }
            set
            {
                if (value >= 0)
                {
                    b = value;
                }
                else
                {
                    throw new ArgumentException("Attemt to accept negative value of rectangle side");
                }
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return (ConsoleColor)c;
            }
        }
        public void PrintSides()
        {
            Console.WriteLine("a sides = {0}", a);
            Console.WriteLine("b sides = {0}", b);
        }
        public int CalculatePerimeter()
        {
            return 2 * (a + b);
        }
        public int CalculateArea()
        {
            return a * b;
        }

        public bool IsSquare()
        {
            return (a == b);
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return c;
                    default:
                        throw new ArgumentException("Out of range");
                }
            }
        }

        public static Rectangle operator ++(Rectangle instance)
        {
            instance.a++;
            instance.b++;
            return instance;
        }
        public static Rectangle operator --(Rectangle instance)
        {
            instance.a--;
            instance.b--;
            return instance;
        }


        public static Rectangle operator *(Rectangle instance, int scalar)
        {
            return new Rectangle(instance.a * scalar, instance.b * scalar);
        }

        public static implicit operator bool(Rectangle instance)
        {
            return instance.IsSquare();
        }

        public static explicit operator string(Rectangle instance)
        {
            return $"{instance.a}; {instance.b}; {instance.c}";
        }

        public static explicit operator Rectangle(string text)
        {
            var st = text.Split(';');
            int a, b, c;
            if(st.Length == 3)
            {
                if (int.TryParse(st[0].Trim(), out a) &&
                int.TryParse(st[1].Trim(), out b) &&
                int.TryParse(st[2].Trim(), out c))
                {
                    return new Rectangle(a, b, c);
                }
            }
            throw new InvalidCastException("Attempt to convert string with invalid format to Rectangle");
        }


        public override string ToString()
        {
            return $"Side A: {a}; Side B: {b}; \nColor: {Color}";
        }
    }
}
