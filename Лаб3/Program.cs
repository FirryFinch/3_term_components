using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    /// <summary>
    /// Абстрактный класс фигур
    /// </summary>
    abstract class Figure : IComparable
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type
        { get; protected set; }

        /// <summary>
        /// Подсчет площади
        /// </summary>
        public abstract double Area();

        /// <summary>
        /// Преобразование в строку
        /// </summary>
        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }

        /// <summary>
        /// Сравнение площадей
        /// </summary>
        /// <returns>
        /// -1 - если левый операнд меньше правого
        /// 0 - если операнды равны
        /// 1 - если левый операнд больше правого
        /// </returns>
        public int CompareTo(object Obj)
        {
            Figure A = (Figure)Obj;
            if (this.Area() < A.Area())
            {
                return -1;
            }
            else
            {
                if (this.Area() == A.Area())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }

    /// <summary>
    /// Интерфейс IPrint
    /// </summary>
    interface IPrint
    {
        void Print();
    }

    /// <summary>
    /// Класс Прямоугольник
    /// </summary>
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

    /// <summary>
    /// Класс Квадрат
    /// </summary>
    class Square : Rectangle, IPrint
    {
        public Square(double size) : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }

    /// <summary>
    /// Класс Круг
    /// </summary>
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

    /// <summary>
    /// Класс разреженной матрицы
    /// </summary>
    public class Matrix<T>
    {
        /// <summary>
        /// Словарь для хранения значений
        /// </summary>
        Dictionary<string, T> _matrix = new Dictionary <string, T>();

        /// <summary>
        /// Количество элементов по горизонтали (столбцы)
        /// </summary>
        int maxX;

        /// <summary>
        /// Количество элементов по вертикали (строки)
        /// </summary>
        int maxY;

        /// <summary>
        /// Количество элементов по вертикали (строки)
        /// </summary>
        int maxZ;

        /// <summary>
        /// Реализация интерфейса для проверки пустого элемента
        /// </summary>
        IMatrixCheckEmpty<T> сheckEmpty;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Matrix(int px, int py, int pz, IMatrixCheckEmpty<T> сheckEmptyParam)
        {
            this.maxX = px;
            this.maxY = py;
            this.maxZ = pz;
            this.сheckEmpty = сheckEmptyParam;
        }

        /// <summary>
        /// Индексатор для доступа к данным
        /// </summary>
        public T this[int x, int y, int z]
        {
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this._matrix.Add(key, value);
            }
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matrix.ContainsKey(key))
                {
                    return this._matrix[key];
                }
                else
                {
                    return this.сheckEmpty.getEmptyElement();
                }
            }
        }

        /// <summary>
        /// Проверка границ
        /// </summary>
        void CheckBounds(int x, int y, int z)
        {
            if ((x < 0) || (x >= this.maxX))
            {
                throw new ArgumentOutOfRangeException("x", "x=" + x + " выходит за границы");
            }
            if ((y < 0) || (y >= this.maxY))
            {
                throw new ArgumentOutOfRangeException("y", "y=" + y + " выходит за границы");
            }
            if ((z < 0) || (z >= this.maxZ))
            {
                throw new ArgumentOutOfRangeException("z", "z=" + z + " выходит за границы");
            }
        }

        /// <summary>
        /// Формирование ключа
        /// </summary>
        string DictKey(int x, int y, int z)
        {
            return (x.ToString() + "_" + y.ToString() + "_" + z.ToString());
        }

        /// <summary>
        /// Приведение к строке
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < this.maxZ; k++)
            {
                sb.Append("[");
                for (int j = 0; j < this.maxY; j++)
                {
                    for (int i = 0; i < this.maxX; i++)
                    {
                        //Добавление разделителя-табуляции
                        if (i > 0)
                        {
                            sb.Append("\t");
                        }
                        //Если текущий элемент не пустой
                        if (!this.сheckEmpty.checkEmptyElement(this[i, j, k]))
                        {
                            //Добавить приведенный к строке текущий элемент
                            sb.Append(this[i, j, k].ToString());
                        }
                        else
                        {
                            //Иначе добавить признак пустого значения
                            sb.Append(" - ");
                        }
                    }
                    sb.Append("]\n");
                }
            }
            return (sb.ToString());
        }
    }

    /// <summary>
    /// Проверка пустого элемента матрицы
    /// </summary>
    public interface IMatrixCheckEmpty<T>
    {
        /// <summary>
        /// Возвращает пустой элемент
        /// </summary>
        T getEmptyElement();

        /// <summary>
        /// Проверка, что элемент является пустым
        /// </summary>
        bool checkEmptyElement(T element);
    }

    /// <summary>
    /// Класс, реализующий интерфейс IMatrixEmpty
    /// </summary>
    class FigureMatrixCheckEmpty : IMatrixCheckEmpty <Figure>
    {
        public Figure getEmptyElement()
        {
            return null;
        }
        public bool checkEmptyElement(Figure element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }

    /// <summary>
    /// Элемент списка
    /// </summary>
    public class SimpleListItem<T>
    {
        /// <summary>
        /// Данные
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// Следующий элемент
        /// </summary>
        public SimpleListItem<T> next { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public SimpleListItem(T param)
        {
            this.data = param;
        }
    }

    /// <summary>
    /// Список
    /// </summary>
    public class SimpleList<T> : IEnumerable<T>
    where T : IComparable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        protected SimpleListItem<T> first = null;

        /// <summary>
        /// Последний элемент списка
        /// </summary>
        protected SimpleListItem<T> last = null;

        /// <summary>
        /// Количество элементов
        /// </summary>
        public int Count
        {   get; protected set;}

        /// <summary>
        /// Добавление элемента
        /// </summary>
        public void Add(T element)
        {
            SimpleListItem<T> newItem = new SimpleListItem<T>(element);
            this.Count++;

            if (last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                this.last.next = newItem;
                this.last = newItem;
            }
        }

        /// <summary>
        /// Чтение контейнера с указанным номером 
        /// </summary>
        public SimpleListItem<T> GetItem(int number)
        {
            SimpleListItem<T> current = this.first;
            int i = 0;
            while (i < number)
            {
                current = current.next;
                i++;
            }
            return current;
        }

        /// <summary>
        /// Чтение элемента с указанным номером
        /// </summary>
        public T Get(int number)
        {
            return GetItem(number).data;
        }

        /// <summary>
        /// Для перебора коллекции
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            SimpleListItem<T> current = this.first;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Cортировка
        /// </summary>
        public void Sort()
        {
            Sort(0, this.Count - 1);
        }

        /// <summary>
        /// Алгоритм быстрой сортировки
        /// </summary>
        private void Sort(int low, int high)
        {
            int i = low;
            int j = high;
            T x = Get((low + high) / 2);
            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;
                if (i <= j)
                {
                    Swap(i, j);
                    i++; j--;
                }
            } while (i <= j);

            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);
        }

        /// <summary>
        /// Вспомогательный метод для обмена элементов при сортировке
        /// </summary>
        private void Swap(int i, int j)
        {
            SimpleListItem<T> ci = GetItem(i);
            SimpleListItem<T> cj = GetItem(j);
            T temp = ci.data;
            ci.data = cj.data;
            cj.data = temp;
        }
    }

    /// <summary>
    /// Класс стек
    /// </summary>
    class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        /// <summary>
        /// Добавление в стек
        /// </summary>
        public void Push(T element)
        {
           Add(element);
        }

        /// <summary>
        /// Удаление и чтение из стека
        /// </summary>
        public T Pop()
        {
            T Result = default(T);
            if (this.Count == 0)
            { return Result; }
            if (this.Count == 1)
            {
                Result = this.first.data;
                this.first = null;
                this.last = null;
            }
            else
            {
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                Result = newLast.next.data;
                this.last = newLast;
                newLast.next = null;
            }
            this.Count--;
            return Result;
        }
    }

    /// <summary>
    /// Основная программа
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectan = new Rectangle(5, 4);
            Square sqr = new Square(5);
            Circle circ = new Circle(5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Использование необобщенного списка ArrayList");
            Console.ResetColor();

            ArrayList figlist1 = new ArrayList();
            figlist1.Add(circ);
            figlist1.Add(sqr);
            figlist1.Add(rectan);
            Console.WriteLine("\nПеред сортировкой: ");
            foreach (var Ai in figlist1)
            {
                Console.WriteLine(Ai);
            }
            figlist1.Sort();
            Console.WriteLine("\nПосле сортировки: ");
            foreach (var Ai in figlist1)
            {
                Console.WriteLine(Ai);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИспользование обобщенного списка List<>");
            Console.ResetColor();

            List<Figure> figlist2 = new List<Figure>();
            figlist2.Add(circ);
            figlist2.Add(sqr);
            figlist2.Add(rectan);
            Console.WriteLine("\nПеред сортировкой: ");
            foreach (var Ai in figlist2)
            {
                Console.WriteLine(Ai);
            }
            figlist2.Sort();
            Console.WriteLine("\nПосле сортировки: ");
            foreach (var Ai in figlist2)
            {
                Console.WriteLine(Ai);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИспользование разреженной матрицы\n");
            Console.ResetColor();

            Matrix<Figure> matr = new Matrix<Figure>(3, 3, 3, new FigureMatrixCheckEmpty());
            matr[0, 0, 0] = circ;
            matr[1, 1, 1] = sqr;
            matr[2, 2, 2] = rectan;
            Console.WriteLine(matr.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИспользование стека\n");
            Console.ResetColor();
            SimpleStack<Figure> stk = new SimpleStack<Figure>();
            stk.Push(circ);
            stk.Push(sqr);
            stk.Push(rectan);
            while (stk.Count > 0)
            {
                Figure fig = stk.Pop();
                Console.WriteLine(fig);
            }
        }
    }
}