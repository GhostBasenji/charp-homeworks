// Программа выводит на печать (на принтер) изображение эллипса. Понятно, что таким же образом можно распечатывать
// и другие графические примитивы: // прямоугольники, отрезки, дуги и т. д. (см. методы объекта Graphics) 
namespace HW_036
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Выводится на печать эллипс зеленого цвета внутри
            // ограничивающего прямоугольника с вершиной в точке (200, 250),
            // шириной 300 и высотой 200
            var Pero = new Pen(Color.Green);
            e.Graphics.DrawEllipse(Pero, new Rectangle(200, 250, 300, 200));
            // или e.Graphics.DrawEllipse(Pero, 50, 50, 150, 150);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }
}

// Как видно из кода, с целью максимального упрощения программы для генерации события PrintPage
// при обработке события загрузки формы вызываем метод printDocument1.Print. В обработчике события
// PrintPage вызываем метод DrawEllipse для построения эллипса без заливки. В комментарии приведен
// вариант построения эллипса другим способом. 