// Программа позволяет открыть в стандартном диалоговом окне текстовый файл,
// просмотреть его в текстовом поле без возможности изменения текста
// (ReadOnly) и при желании пользователя вывести этот текст на принтер

namespace HW_029
{
    public partial class Form1 : Form
    {
        System.IO.StreamReader reader;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Открытие текстового файла и его печать";
            textBox1.Clear();
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.ReadOnly = true;

            // До тех пор, пока файл не прочитан в текстовое поле,
            // не должен быть виден пункт меню "Печать..."
            печатьToolStripMenuItem.Visible = false;
            openFileDialog1.FileName = null;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
                "Текстовые файлы (*txt)|*.txt|All files(*.*) | *.* ";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null) return;
            try
            {
                // Создаем поток StreamReader для чтения из файла
                reader = new System.IO.StreamReader(
                    openFileDialog1.FileName,
                    System.Text.Encoding.GetEncoding(1251));
                // - здесь мы заказываем кодовую страницу Win1251 для русских букв
                textBox1.Text = reader.ReadToEnd();
                reader.Close();
                печатьToolStripMenuItem.Visible = true;
            }
            catch (System.IO.FileNotFoundException Situacia)
            {
                MessageBox.Show(Situacia.Message +
                    "\nНет такого файла", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                reader = new System.IO.StreamReader(
                    openFileDialog1.FileName,
                    System.Text.Encoding.GetEncoding(1251));
                try
                {
                    printDocument1.Print();
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception Situacia)
            {
                MessageBox.Show(Situacia.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Событие вывода на печать страницы (PrintPage)
            Single StrokNaStranice = 0.0F;
            Single Y = 0;
            var LeviyKray = e.MarginBounds.Left;
            var VerhniyKray = e.MarginBounds.Top;
            var Stroka = String.Empty;
            var Shrift = new Font("Times New Roman", 12.0F);

            // Вычисляем количество строк на одной странице
            StrokNaStranice = e.MarginBounds.Height / Shrift.GetHeight(e.Graphics);

            // Печатаем каждую строку файла
            var i = 0; // - счет строк
            while (i < StrokNaStranice)
            {
                Stroka = reader.ReadLine();
                if (Stroka == null) break; // Выходим из цикла
                Y = VerhniyKray + i * Shrift.GetHeight(e.Graphics);

                //Печатаем строки
                e.Graphics.DrawString(Stroka, Shrift, Brushes.Black, LeviyKray, Y, new StringFormat());
                i = i + 1; // или i += 1 - счет строк
            }
            // Печать следующей страницы, если есть еще строки файла
            if (Stroka != null) e.HasMorePages = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



// Здесь при обработке события загрузки формы Form1_Load запрещаем пользователю редактировать текстовое поле: ReadOnly = true.
// Также назначаем свойству ПечатьToolStripMenuItem.Visible = false (пункт меню Печать), т. е. в начале работы
// программы пункт меню Печать пользователю не виден (поскольку пока распечатывать нечего — необходимо вначале открыть текстовый файл).
// Остальные присваивания при обработке события Form1_Load очевидны.

// При обработке события "щелчок на пункте меню Открыть" вызываем стандартный диалог openFileDialog и организуем чтение файла через создание потока StreamReader.
// После чтения файла в текстовое поле назначаем видимость пункту меню Печать: печатьToolStripMenuItem.Visible = true,
// поскольку уже есть, что печатать на принтере (файл открыт).

// Представляет интерес обработка события "щелчок на пункте меню Печать". Здесь во
// вложенных блоках try...finally...catch программа еще раз создает поток 
// StreamReader, а затем запускает процесс печати документа printDocument1.Print.
// Если ничего более не программировать, только метод printDocument1.Print,
// то принтер распечатает лишь пустую страницу. Чтобы принтер распечатал текст, необходимо обработать событие PrintPage, которое создает объект PrintDocument.
// То есть роль метода Print — это создать событие PrintPage. 

// Вначале перечислены объявления переменных, значения некоторых из них получаем из аргументов события e, например, LeviyKray —
// значение отступа от левого края, и т. д. Назначаем шрифт печати — Times New Roman, 12 пунктов.
// Далее в цикле while программа читает каждую строку Stroka из файла — reader.ReadLine(), а затем распечатывает ее командой (методом) DrawString. Здесь
// используется графический объект Graphics, который получаем из аргумента события e. 
// В переменной i происходит счет строк. Если количество строк оказывается большим, чем число строк на странице, то происходит выход из цикла, поскольку страница
// распечатана. Если есть еще страницы, а программа выясняет это, анализируя содержимое переменной Stroka, — если ее содержимое отличается от значения null
// (Строка != null), то аргументной переменной e.HasMorePages назначаем true, что инициирует опять событие PrintPage,
// и процедура printDocument1_PrintPage начинает свою работу вновь. И так, пока не закончатся все страницы e.HasMorePages = false для печати на принтере.