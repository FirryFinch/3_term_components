
namespace Lab4
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
            this.buttonStartRead = new System.Windows.Forms.Button();
            this.labelReadTime = new System.Windows.Forms.Label();
            this.textBoxReadTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSearchTime = new System.Windows.Forms.Label();
            this.textBoxSearchTime = new System.Windows.Forms.TextBox();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.textBoxWordSearch = new System.Windows.Forms.TextBox();
            this.labelWordSearch = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartRead
            // 
            this.buttonStartRead.Location = new System.Drawing.Point(12, 12);
            this.buttonStartRead.Name = "buttonStartRead";
            this.buttonStartRead.Size = new System.Drawing.Size(224, 30);
            this.buttonStartRead.TabIndex = 0;
            this.buttonStartRead.Text = "Начать чтение из файла";
            this.buttonStartRead.UseVisualStyleBackColor = true;
            this.buttonStartRead.Click += new System.EventHandler(this.buttonStartRead_Click);
            // 
            // labelReadTime
            // 
            this.labelReadTime.AutoSize = true;
            this.labelReadTime.Location = new System.Drawing.Point(285, 18);
            this.labelReadTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelReadTime.Name = "labelReadTime";
            this.labelReadTime.Size = new System.Drawing.Size(211, 17);
            this.labelReadTime.TabIndex = 4;
            this.labelReadTime.Text = "Затраченное время на чтение";
            // 
            // textBoxReadTime
            // 
            this.textBoxReadTime.Location = new System.Drawing.Point(523, 16);
            this.textBoxReadTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxReadTime.Name = "textBoxReadTime";
            this.textBoxReadTime.Size = new System.Drawing.Size(195, 22);
            this.textBoxReadTime.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Найденные слова";
            // 
            // labelSearchTime
            // 
            this.labelSearchTime.AutoSize = true;
            this.labelSearchTime.Location = new System.Drawing.Point(120, 130);
            this.labelSearchTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchTime.Name = "labelSearchTime";
            this.labelSearchTime.Size = new System.Drawing.Size(100, 17);
            this.labelSearchTime.TabIndex = 16;
            this.labelSearchTime.Text = "Время поиска";
            // 
            // textBoxSearchTime
            // 
            this.textBoxSearchTime.Location = new System.Drawing.Point(288, 127);
            this.textBoxSearchTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearchTime.Name = "textBoxSearchTime";
            this.textBoxSearchTime.Size = new System.Drawing.Size(195, 22);
            this.textBoxSearchTime.TabIndex = 15;
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 16;
            this.listBoxResult.Location = new System.Drawing.Point(288, 191);
            this.listBoxResult.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(195, 228);
            this.listBoxResult.TabIndex = 14;
            // 
            // textBoxWordSearch
            // 
            this.textBoxWordSearch.Location = new System.Drawing.Point(288, 79);
            this.textBoxWordSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWordSearch.Name = "textBoxWordSearch";
            this.textBoxWordSearch.Size = new System.Drawing.Size(195, 22);
            this.textBoxWordSearch.TabIndex = 13;
            // 
            // labelWordSearch
            // 
            this.labelWordSearch.AutoSize = true;
            this.labelWordSearch.Location = new System.Drawing.Point(120, 82);
            this.labelWordSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWordSearch.Name = "labelWordSearch";
            this.labelWordSearch.Size = new System.Drawing.Size(126, 17);
            this.labelWordSearch.TabIndex = 12;
            this.labelWordSearch.Text = "Слово для поиска";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(609, 69);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(109, 32);
            this.buttonSearch.TabIndex = 11;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(609, 436);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(109, 32);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "Закрыть";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
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
            this.Text = "Л4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartRead;
        private System.Windows.Forms.Label labelReadTime;
        private System.Windows.Forms.TextBox textBoxReadTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSearchTime;
        private System.Windows.Forms.TextBox textBoxSearchTime;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.TextBox textBoxWordSearch;
        private System.Windows.Forms.Label labelWordSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonExit;
    }
}

