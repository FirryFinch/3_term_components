using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ClassLib;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //  Список
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
              // this.textBoxReadCount.Text = list.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка: Необходимо выбрать файл! Повторите попытку.");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Слово для поиска
            string word = this.textBoxWordSearch.Text.Trim();
            string maxdstr = this.textBoxMaxD.Text.Trim();
            // Если слово для поиска не пусто
            this.listBoxResult.BeginUpdate();
            this.listBoxResult.Items.Clear();
            Stopwatch timer = new Stopwatch();
            if (!string.IsNullOrWhiteSpace(maxdstr))
            {
                int maxd = int.Parse(maxdstr);
                if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
                {
                    // Слово для поиска в верхнем регистре
                    string wordUpper = word.ToUpper();

                    timer.Start();

                    bool match = true;

                    Stopwatch t = new Stopwatch();
                    t.Start();

                    foreach (string str in list)
                    {
                        if (EditDistance.Distance(str.ToUpper(), word) <= maxd)
                        {
                            this.listBoxResult.Items.Add(str);
                            match = false;
                        }
                    }

                    timer.Stop();
                    //Если совпадений всё же не нашлось
                    if (match)
                    {
                        this.listBoxResult.Items.Add("Нет сопадений");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: Необходимо ввести слово для поиска! Повторите попытку.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка: Необходимо ввести максимальное расстояние! Повторите попытку.");
            }
            this.listBoxResult.EndUpdate();
            this.textBoxSearchTime.Text = timer.Elapsed.ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
