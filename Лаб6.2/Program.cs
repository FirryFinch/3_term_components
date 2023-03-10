using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab6._2
{
    class Program
    {
        /// <summary>
        /// Проверка, что у свойства есть атрибут заданного типа
        /// </summary>
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }
        static void Main(string[] args)
        {
            ForInspection obj = new ForInspection();
            Type t = obj.GetType();

            Console.WriteLine("Конструкторы:");
            foreach (var a in t.GetConstructors())
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("");
            Console.WriteLine("Свойства:");
            foreach (var a in t.GetProperties())
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("");
            Console.WriteLine("Методы:");
            foreach (var a in t.GetMethods())
            {
                Console.WriteLine(a);
            }

            ForInspection obj1 = new ForInspection();
            Type t1 = obj.GetType();

            Console.WriteLine("");
            Console.WriteLine("Свойства, помеченные атрибутом:");
            foreach (var x in t1.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
            Type t2 = typeof(ForInspection);
            Console.WriteLine("");
            Console.WriteLine("Вызов метода:");
                       
            ForInspection fi = new ForInspection();
            object[] parameters = new object[] { 3, 2 };
            object Result = t.InvokeMember("Plus", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Plus(3,2)={0}", Result);
            Console.ReadKey(true);
        }
    }
}
