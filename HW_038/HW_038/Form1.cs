// Программа формирует изображение методами класса Graphics, записывает его на диск в формате JPG-файла
// и выводит его отображение в форму

// Задача, решаемая в этом примере, состоит в следующем. Имеем форму и кнопку на ней, при щелчке указателем мыши на кнопке
// нужно создать изображение и методами класса Graphics вывести на это изображение текстовую строку, представляющую текущую дату.
// С целью демонстрации возможностей методов Graphics развернем данную строку на некоторый угол относительно горизонта.
// Далее — сохранить рисунок в текущий каталог и вывести его отображение в форму. 

namespace HW_038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Показать дату";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(250, 40);

            // Создаем точечное изображение размером 250*40 точек глубиной цвета 24
            var Risunok = new Bitmap(250, 40, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Создаем новый объект класса Graphics из изображения РАСТР
            var Grafika = Graphics.FromImage(Risunok);

            // Теперь становятся доступными методы класса Graphics.
            // Заливаем поверхность цветом формы:
            Grafika.Clear(Color.FromName("Control"));

            // Выводим в строку полной даты:
            var Data = String.Format("Сегодня {0:D}", DateTime.Now);

            // Разворачиваем рисунок на 356 градусов по часовой стрелке:
            Grafika.RotateTransform(356.0F);

            // Выводим на изображение текстовую строку Data,
            // x = 5, y = 15 - координаты левого верхнего угла строки
            Grafika.DrawString(Data, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Green, 5, 15);

            // Сохраняем изображение в файле risunok.jpg
            Risunok.Save("risunok.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            // Задаем стиль границ рисунка:
            pictureBox1.BorderStyle = BorderStyle.None;

            // Загружаем рисунок из файла:
            pictureBox1.Image = Image.FromFile("risunok.jpg");

            // Освобождаем ресурсы:
            Risunok.Dispose(); Grafika.Dispose();
        }
    }
}


// Как видно из кода, при обработке события "щелчок на кнопке" создаем точечное изображение заданного размера, формат Format24bppRgb указывает,
// что отводится 24 бита на точку: по 8 бит на красный, зеленый и синий каналы. Данное изображение позволяет создать новый объект класса Graphics
// методом FromImage. Теперь разворачиваем поверхность рисования на 356 методом RotateTransform и выводим на поверхность рисования текстовую строку
// с текущей датой. Методом Save сохраняем файл изображения в текущей папке в формате JPEG. Далее элементу управления pictureBox1 указываем путь к файлу изображения. 