using System;
using System.Text;

namespace Lab2
{
    abstract class Figure
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;
        public abstract double Area();
        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }
    }
    interface IPrint
    {
        void Print();
    }
    class Rectangle : Figure, IPrint
    {
        double height;
        double width;
        public Rectangle(double ph, double pw)
        {
            this.height = ph;
            this.width = pw;
            this.Type = "Прямоугольник";
        }
        public override double Area()
        {
            double Result = this.width * this.height;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rectangle, IPrint
    {
        public Square(double size) : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }
    class Circle : Figure, IPrint
    {
        double radius;
        public Circle(double pr)
        {
            this.radius = pr;
            this.Type = "Круг";
        }
        public override double Area()
        {
            double Result = Math.PI * this.radius * this.radius;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectan = new Rectangle(5, 4);
            Square sqr = new Square(5);
            Circle circ = new Circle(5);

            rectan.Print();
            sqr.Print();
            circ.Print();
        }
    }
}
