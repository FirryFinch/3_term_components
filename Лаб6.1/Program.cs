using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    delegate object MathOp(int p1, float p2);
    class Program
    {
        static object Addition(int p1, float p2) 
        { 
            return p1 + p2;
        }
        static object Subtraction(int p1, float p2)
        {
            return p1 - p2;
        }
        static object Method(int i1, float i2, MathOp mo)
        {
            object result = mo(i1, i2);
            return result;
        }
        static object MethodFunc(int i1, float i2, Func<int, float, object> func)
        {
            object result = func(i1, i2);
            return result;
        }
        static void Main(string[] args)
        {
            int i1 = 3;
            int i2 = 2;
            Console.WriteLine("Числа: " + i1 + " " + i2);
            Console.WriteLine("");
            Console.WriteLine("Применение делегата:");
            Console.Write("Сложение: ");
            Console.Write(Method(i1, i2, Addition));
            Console.Write(" Вычитание: ");
            Console.WriteLine(Method(i1, i2, Subtraction));
            Console.WriteLine("");
            Console.WriteLine("Применение лямбда-выражения:");
            MathOp p1 = (int x, float y) =>
            {
                object z = x + y;
                return z;
            };
            MathOp p2 = (int x, float y) =>
            {
                object z = x - y;
                return z;
            };
            Console.Write("Сложение: ");
            Console.Write(Method(i1, i2, p1));
            Console.Write(" Вычитание: ");
            Console.WriteLine(Method(i1, i2, p2));
            Console.WriteLine("");
            Console.WriteLine("Применение Func:");
            Console.Write("Сложение: ");
            Console.Write(MethodFunc(i1, i2, (x, y) => x + (int)y));
            Console.Write(" Вычитание: ");
            Console.WriteLine(MethodFunc(i1, i2, (x, y) => x - (int)y));
            Console.ReadKey(true);
        }
    }
}
