using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using ClassLib;

namespace HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Список
        List<string> list = new List<string>();
        private void buttonStartRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Текстовые файлы|*.txt";
            // Диалог
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                // Весь текст
                string text = File.ReadAllText(fd.FileName);
                // Разделители
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                // С разделенным текстом
                string[] textArray = text.Split(separators);
                // Перебор слов
                foreach (string word in textArray)
                {
                    // Удаление пробелов в начале и конце строки
                    string str = word.Trim();
                    // Добавление строки в список, если строки нет в списке (повторяющиеся слова)
                    if (!list.Contains(str)) list.Add(str);
                }
                t.Stop();
                this.textBoxReadTime.Text = t.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка: Необходимо выбрать файл!");
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Слово для поиска
            string word = this.textBoxWordSearch.Text.Trim();

            // Если слово для поиска не пусто
            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                int MD;
                if (!int.TryParse(this.textBoxMaxD.Text.Trim(), out MD))
                {
                    MessageBox.Show("Ошибка: Необходимо указать максимальное расстояние!");
                    return;
                }

                int WC;
                if (!int.TryParse(this.textBoxWays.Text.Trim(), out WC))
                {
                    MessageBox.Show("Ошибка: Необходимо указать количество потоков!");
                    return;
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                // Результирующий список  
                List<ParallelSearchResult> result = new List<ParallelSearchResult>();

                // Деление списка на фрагменты для параллельного запуска в потоках
                List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count, WC);
                int count = arrayDivList.Count;

                // Количество потоков соответствует количеству фрагментов массива
                Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];

                // Запуск потоков
                for (int i = 0; i < count; i++)
                {
                    // Создание временного списка, чтобы потоки не работали параллельно с одной коллекцией
                    List<string> temptasklist = list.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);

                    tasks[i] = new Task<List<ParallelSearchResult>>(
                        // Метод, который будет выполняться в потоке
                        ArrayThreadTask,
                        // Параметры потока 
                        new ParallelSearchThreadParam()
                        {
                            templist = temptasklist,
                            MD = MD,
                            waynum = i,
                            word1 = word
                        });
                    // Запуск потока
                    tasks[i].Start();
                }
                Task.WaitAll(tasks);
                timer.Stop();
                // Объединение результатов
                for (int i = 0; i < count; i++)
                {
                    result.AddRange(tasks[i].Result);
                }
                timer.Stop();
                //Время поиска
                this.textBoxSearchTime.Text = timer.Elapsed.ToString();
                //Начало обновления списка результатов
                this.listBoxResult.BeginUpdate();
                //Очистка списка
                this.listBoxResult.Items.Clear();
                // Вывод результатов поиска 
                foreach (var x in result)
                {
                    string temp = x.word + "(расстояние = " + x.dist.ToString() + " поток = " + x.waynum.ToString() + ")";
                    this.listBoxResult.Items.Add(temp);
                }
                // Окончание обновления списка результатов
                this.listBoxResult.EndUpdate();
            }
            else
            {
                MessageBox.Show("Ошибка: Необходимо ввести слово для поиска!");
            }
        }
        public static List<ParallelSearchResult> ArrayThreadTask(object paramObj)
        {
            ParallelSearchThreadParam param = (ParallelSearchThreadParam)paramObj;

            //Слово для поиска в верхнем регистре
            string wordUpper = param.word1.Trim().ToUpper();

            //Результаты поиска в одном потоке
            List<ParallelSearchResult> Result = new List<ParallelSearchResult>();

            //Перебор всех слов во временном списке данного потока 
            foreach (string str in param.templist)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = Classes.Distance(str.ToUpper(), wordUpper);

                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= param.MD)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        word = str,
                        dist = dist,
                        waynum = param.waynum
                    };

                    Result.Add(temp);
                }
            }
            return Result;
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Имя файла отчета
            string TempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
            // Диалог сохранения файла отчета
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".txt";
            fd.Filter = "Отчет .txt|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string ReportFileName = fd.FileName;
                // Формирование отчета
                StringBuilder b = new StringBuilder();
                b.AppendLine("Отчет:" + " " + ReportFileName);
                b.AppendLine("");
                b.AppendLine("Затраченное время на чтение:" + " " + this.textBoxReadTime.Text);
                b.AppendLine("");
                b.AppendLine("Слово для поиска:" + " " + this.textBoxWordSearch.Text);
                b.AppendLine("");
                b.AppendLine("Максимальное расстояние:" + " " + this.textBoxMaxD.Text);
                b.AppendLine("");
                b.AppendLine("Время поиска:" + " " + this.textBoxSearchTime.Text);
                b.AppendLine("");
                b.AppendLine("");
                b.AppendLine("Результаты поиска:");
                foreach (var x in this.listBoxResult.Items)
                {
                    b.AppendLine(x.ToString());
                }
                // Сохранение файла
                File.AppendAllText(ReportFileName, b.ToString());
                MessageBox.Show("Отчет сформирован. Файл находится по пути: " + ReportFileName);
            }
        }
    }
    /// <summary>
    /// Результаты параллельного поиска
    /// </summary>
    public class ParallelSearchResult
    {
        /// <summary>
        /// Найденное слово
        /// </summary>
        public string word { get; set; }
        /// <summary>
        /// Расстояние
        /// </summary>
        public int dist { get; set; }
        /// <summary>
        /// Номер потока
        /// </summary>
        public int waynum { get; set; }
    }
    /// <summary>
    /// Параметры которые передаются в поток для параллельного поиска
    /// </summary>
    class ParallelSearchThreadParam
    {
        /// <summary>
        /// Массив для поиска
        /// </summary>
        public List<string> templist { get; set; }
        /// <summary>
        /// Слово для поиска
        /// </summary>
        public string word1 { get; set; }
        /// <summary>
        /// Максимальное расстояние для нечеткого поиска
        /// </summary>
        public int MD { get; set; }
        /// <summary>
        /// Номер потока
        /// </summary>
        public int waynum { get; set; }
    }
    /// <summary>
    /// Хранение минимального и максимального значений диапазона
    /// </summary>
    public class MinMax
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public MinMax(int pmin, int pmax)
        {
            this.Min = pmin;
            this.Max = pmax;
        }
    }
    /// <summary>
    /// Класс для деления массива на последовательности
    /// </summary>
    public static class SubArrays
    {
        /// <summary>
        /// Деление массива на последовательности
        /// </summary>
        /// <param name="beginIndex">Начальный индекс массива</param>
        /// <param name="endIndex">Конечный индекс массива</param>
        /// <param name="subArraysCount">Требуемое количество подмассивов</param>
        /// <returns>Список пар с индексами подмассивов</returns>
        public static List<MinMax> DivideSubArrays(int beginIndex, int endIndex, int subArraysCount)
        {
            //Результирующий список пар с индексами подмассивов
            List<MinMax> result = new List<MinMax>();

            //Если число элементов в массиве слишком мало для деления 
            //то возвращается массив целиком
            if ((endIndex - beginIndex) <= subArraysCount)
            {
                result.Add(new MinMax(0, (endIndex - beginIndex)));
            }
            else
            {
                //Размер подмассива
                int delta = (endIndex - beginIndex) / subArraysCount;
                //Начало отсчета
                int currentBegin = beginIndex;
                //Пока размер подмассива укладывается в оставшуюся последовательность
                while ((endIndex - currentBegin) >= 2 * delta)
                {
                    //Формируем подмассив на основе начала последовательности
                    result.Add(new MinMax(currentBegin, currentBegin + delta));
                    //Сдвигаем начало последовательности вперед на размер подмассива
                    currentBegin += delta;
                }
                //Оставшийся фрагмент массива
                result.Add(new MinMax(currentBegin, endIndex));
            }
            //Возврат списка результатов
            return result;
        }
    }
}
