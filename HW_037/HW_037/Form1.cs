// Эта программа выводит на печать файл с расширением bmp

namespace HW_037
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = @"Печать файла d:\test.bmp";
            button1.Text = "Печать";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Пользователь щелкнул на кнопке
            try
            {
                printDocument1.Print();
            }
            catch (Exception Situaciya)
            {
                MessageBox.Show("Ошибка печати на принтере\n", Situaciya.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Это событие возникает, когда вызывают метод Print().

            // Рисуем содержимое BMP-файла
            e.Graphics.DrawImage(Image.FromFile(@"D:\test.bmp"), e.Graphics.VisibleClipBounds);

            // Следует ли распечатывать следующую страницу?
            e.HasMorePages = false;
        }
    }
}

// Как видно из кода, при нажатии пользователем кнопки вызывается метод printDocument1.Print.
// Этот метод создает событие PrintPage, которое обрабатывается в обработчике printDocument1_PrintPage.
// Для вывода на принтер вызывается метод DrawImage рисования содержимого BMP-файла. 