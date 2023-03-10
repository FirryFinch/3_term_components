
namespace HW
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSearchTime = new System.Windows.Forms.Label();
            this.textBoxSearchTime = new System.Windows.Forms.TextBox();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.textBoxWordSearch = new System.Windows.Forms.TextBox();
            this.labelWordSearch = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxReadTime = new System.Windows.Forms.TextBox();
            this.labelReadTime = new System.Windows.Forms.Label();
            this.buttonStartRead = new System.Windows.Forms.Button();
            this.textBoxWays = new System.Windows.Forms.TextBox();
            this.labelWays = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelMaxD = new System.Windows.Forms.Label();
            this.textBoxMaxD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(630, 492);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(109, 32);
            this.buttonExit.TabIndex = 29;
            this.buttonExit.Text = "Закрыть";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Найденные слова";
            // 
            // labelSearchTime
            // 
            this.labelSearchTime.AutoSize = true;
            this.labelSearchTime.Location = new System.Drawing.Point(62, 232);
            this.labelSearchTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchTime.Name = "labelSearchTime";
            this.labelSearchTime.Size = new System.Drawing.Size(100, 17);
            this.labelSearchTime.TabIndex = 27;
            this.labelSearchTime.Text = "Время поиска";
            // 
            // textBoxSearchTime
            // 
            this.textBoxSearchTime.Location = new System.Drawing.Point(309, 232);
            this.textBoxSearchTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearchTime.Name = "textBoxSearchTime";
            this.textBoxSearchTime.Size = new System.Drawing.Size(195, 22);
            this.textBoxSearchTime.TabIndex = 26;
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 16;
            this.listBoxResult.Location = new System.Drawing.Point(309, 278);
            this.listBoxResult.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(430, 180);
            this.listBoxResult.TabIndex = 25;
            // 
            // textBoxWordSearch
            // 
            this.textBoxWordSearch.Location = new System.Drawing.Point(309, 79);
            this.textBoxWordSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWordSearch.Name = "textBoxWordSearch";
            this.textBoxWordSearch.Size = new System.Drawing.Size(195, 22);
            this.textBoxWordSearch.TabIndex = 24;
            // 
            // labelWordSearch
            // 
            this.labelWordSearch.AutoSize = true;
            this.labelWordSearch.Location = new System.Drawing.Point(62, 82);
            this.labelWordSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWordSearch.Name = "labelWordSearch";
            this.labelWordSearch.Size = new System.Drawing.Size(126, 17);
            this.labelWordSearch.TabIndex = 23;
            this.labelWordSearch.Text = "Слово для поиска";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(630, 74);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(109, 32);
            this.buttonSearch.TabIndex = 22;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxReadTime
            // 
            this.textBoxReadTime.Location = new System.Drawing.Point(544, 16);
            this.textBoxReadTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxReadTime.Name = "textBoxReadTime";
            this.textBoxReadTime.Size = new System.Drawing.Size(195, 22);
            this.textBoxReadTime.TabIndex = 21;
            // 
            // labelReadTime
            // 
            this.labelReadTime.AutoSize = true;
            this.labelReadTime.Location = new System.Drawing.Point(306, 18);
            this.labelReadTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadTime.Name = "labelReadTime";
            this.labelReadTime.Size = new System.Drawing.Size(211, 17);
            this.labelReadTime.TabIndex = 20;
            this.labelReadTime.Text = "Затраченное время на чтение";
            // 
            // buttonStartRead
            // 
            this.buttonStartRead.Location = new System.Drawing.Point(33, 12);
            this.buttonStartRead.Name = "buttonStartRead";
            this.buttonStartRead.Size = new System.Drawing.Size(224, 30);
            this.buttonStartRead.TabIndex = 19;
            this.buttonStartRead.Text = "Начать чтение из файла";
            this.buttonStartRead.UseVisualStyleBackColor = true;
            this.buttonStartRead.Click += new System.EventHandler(this.buttonStartRead_Click);
            // 
            // textBoxWays
            // 
            this.textBoxWays.Location = new System.Drawing.Point(309, 132);
            this.textBoxWays.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWays.Name = "textBoxWays";
            this.textBoxWays.Size = new System.Drawing.Size(195, 22);
            this.textBoxWays.TabIndex = 30;
            // 
            // labelWays
            // 
            this.labelWays.AutoSize = true;
            this.labelWays.Location = new System.Drawing.Point(62, 132);
            this.labelWays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWays.Name = "labelWays";
            this.labelWays.Size = new System.Drawing.Size(143, 17);
            this.labelWays.TabIndex = 31;
            this.labelWays.Text = "Количество потоков";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(33, 492);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 32);
            this.buttonSave.TabIndex = 32;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelMaxD
            // 
            this.labelMaxD.AutoSize = true;
            this.labelMaxD.Location = new System.Drawing.Point(62, 182);
            this.labelMaxD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxD.Name = "labelMaxD";
            this.labelMaxD.Size = new System.Drawing.Size(186, 17);
            this.labelMaxD.TabIndex = 34;
            this.labelMaxD.Text = "Максимальное расстояние";
            // 
            // textBoxMaxD
            // 
            this.textBoxMaxD.Location = new System.Drawing.Point(309, 182);
            this.textBoxMaxD.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMaxD.Name = "textBoxMaxD";
            this.textBoxMaxD.Size = new System.Drawing.Size(195, 22);
            this.textBoxMaxD.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.labelMaxD);
            this.Controls.Add(this.textBoxMaxD);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelWays);
            this.Controls.Add(this.textBoxWays);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelSearchTime);
            this.Controls.Add(this.textBoxSearchTime);
            this.Controls.Add(this.listBoxResult);
            this.Controls.Add(this.textBoxWordSearch);
            this.Controls.Add(this.labelWordSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxReadTime);
            this.Controls.Add(this.labelReadTime);
            this.Controls.Add(this.buttonStartRead);
            this.Name = "Form1";
            this.Text = "ДЗ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSearchTime;
        private System.Windows.Forms.TextBox textBoxSearchTime;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.TextBox textBoxWordSearch;
        private System.Windows.Forms.Label labelWordSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxReadTime;
        private System.Windows.Forms.Label labelReadTime;
        private System.Windows.Forms.Button buttonStartRead;
        private System.Windows.Forms.TextBox textBoxWays;
        private System.Windows.Forms.Label labelWays;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelMaxD;
        private System.Windows.Forms.TextBox textBoxMaxD;
    }
}

