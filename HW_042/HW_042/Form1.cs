// Программа рисует график объемов продаж по месяцам. Понятно, что таким 
// же образом можно построить любой график по точкам для других прикладных целей 

namespace HW_042
{
    public partial class Form1 : Form
    {
        String[] Months;
        int[] Sales;
        Graphics Grafika;

        // Создаем объект Bitmap, который имеет тот же размер и разрешение, что и PictureBox
        Bitmap Rastr;
        int OtstupSleva, OtstupSprava, OtstupSnizu, OtstupSverhu;
        int DlinaVertOsi, DlinaGorizOsi, Y_GorizOsi, X_Max, X_Na4Epyuri;

        // Шаг градуировки по горизонтальной и вертикальной осям:
        Double GorizShag;
        int VertShag;
        int i;

        public Form1()
        {
            InitializeComponent();
        }

// ----------------------------------------------------------------------------------------------------------       
        void RisuemOsi()
        {
            var Pero = new Pen(Color.Black, 2);

            // Рисуем вертикальную ось координат:
            Grafika.DrawLine(Pero, OtstupSleva, Y_GorizOsi, OtstupSleva, OtstupSverhu);

            // Рисуем горизонтальную ось координат:
            Grafika.DrawLine(Pero, OtstupSleva, Y_GorizOsi, X_Max, Y_GorizOsi);

            var Shrift = new Font("Arial", 8);
            for (this.i = 1; i <= 10; i++)
            {
                // Рисуем "усики" на вертикальной координатной оси:
                int Y = Y_GorizOsi - i * VertShag;
                Grafika.DrawLine(Pero, OtstupSleva - 4, Y, OtstupSleva, Y);

                // Подписываем значения продаж через каждые 100 единиц:
                Grafika.DrawString((i * 100).ToString(), Shrift, Brushes.Black, 0, Y - 5);
            } // конец цикла по i

            // Подписываем месяцы на горизонтальной оси:
            for (this.i = 0; i <= Months.Length - 1; i++)
            {
                Grafika.DrawString(Months[i], Shrift, Brushes.Black,
                    (int)(OtstupSleva + 18 + i * GorizShag), (Y_GorizOsi + 4));
            }
        }

        void RisuemGorizontLinii()
        {
            var TonkoePero = new Pen(Color.LightGray, 1);
            for (this.i = 1; i <= 10; i++) 
            {
                // Рисуем горизонтальные почти "прозрачные" линии:
                int Y = Y_GorizOsi - VertShag * i;
                Grafika.DrawLine(TonkoePero, OtstupSleva + 3, Y, X_Max, Y);
            }
            TonkoePero.Dispose();
        }

        void RisuemVertikalLinii()
        {
            // Рисуем вертикальные почти "прозрачные" линии:
            var TonkoePero = new Pen(Color.Bisque, 1);
            for (this.i = 0; i <= Months.Length - 1; i++)
            {
                int X = X_Na4Epyuri + Convert.ToInt32(GorizShag * i);
                Grafika.DrawLine(TonkoePero, X, OtstupSverhu, X, Y_GorizOsi - 4);
            }
            TonkoePero.Dispose();
        }

        void RisovanieEpyuri()
        {
            var VertMashtab = Convert.ToDouble(DlinaVertOsi / 1000.0);
            // или  var  ВертМасштаб = (Double)ДлинаВертОси / 1000.0; 

            // Значения ординат на экране:
            var Y = new int[Sales.Length];

            // Значения абсцисс на экране:
            var X = new int[Sales.Length];

            for(this.i = 0; i <= Sales.Length - 1; i++)
            {
                // Вычисляем графические координаты точек:
                Y[i] = Y_GorizOsi - Convert.ToInt32(Sales[i] * VertMashtab);

                // Отнимаем значения продаж, поскольку ось Y экрана направлена вниз
                X[i] = X_Na4Epyuri + Convert.ToInt32(GorizShag * i);
            }
            // Рисуем первый кружок:
            var Pero = new Pen(Color.Blue, 3);
            Grafika.DrawEllipse(Pero, X[0] - 2, Y[0] - 2, 4, 4);
            for(this.i = 0; i <= Sales.Length - 2; i++)
            {
                // Цикл по линиям между точками:
                Grafika.DrawLine(Pero, X[i], Y[i], X[i + 1], Y[i + 1]);

                // Отнимаем 2, поскольку диаметр (ширина) точки = 4:
                Grafika.DrawEllipse(Pero, X[i + 1] - 2, Y[i + 1] - 2, 4, 4);
            }
        }
        
        // -----------------------------------------------------------------------------------------------------------

        private void Form1_Load(object sender, EventArgs e)
        {
            // Исходные данные для построения графика (т.е. исходные точки):
            Months = new String[] { "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сент", "Окт", "Нояб", "Дек" };
            Sales = new int[] { 335, 414, 572, 629, 750, 931, 753, 599, 422, 301, 245, 155 };
            OtstupSleva = 35; OtstupSprava = 15;
            OtstupSnizu = 20; OtstupSverhu = 10;

            this.Text = " Построение графика ";
            button1.Text = "Нарисовать график";
            this.ClientSize = new Size(593, 319);
            pictureBox1.Size = new Size(569, 242);

            Rastr = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());

            // Нарисовать границу pictureBox1 для отладки:
            // pictureBox1.BorderStyle = BorderStyle.FixedSingle; 

            Y_GorizOsi = pictureBox1.Height - OtstupSnizu;
            X_Max = pictureBox1.Width - OtstupSprava;
            DlinaGorizOsi = pictureBox1.Width - (OtstupSleva + OtstupSprava);
            DlinaVertOsi = Y_GorizOsi - OtstupSverhu;
            GorizShag = Convert.ToDouble(DlinaGorizOsi / Sales.Length);
            VertShag = Convert.ToInt32(DlinaVertOsi / 10);
            X_Na4Epyuri = OtstupSleva + 30;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Последовательно вызываем следующие процедуры:
            Grafika = Graphics.FromImage(Rastr);
            RisuemOsi();
            RisuemGorizontLinii();
            RisuemVertikalLinii();
            RisovanieEpyuri();
            pictureBox1.Image = Rastr;

            // Освобождаем ресурсы, используемые объектом класса Graphics:
            Grafika.Dispose();
        }
    }
}

// Как видно из текста программы, вначале объявляем некоторые переменные, чтобы они были видны из всех процедур класса.
// Строковый массив Months содержит названия месяцев, которые пользователь нашего кода может менять в зависимости 
// от контекста строящегося графика. В любом случае записанные строки в этом массиве будут отображаться по горизонтальной оси графика.
// Массив целых чисел Sales содержит объемы продаж по каждому месяцу, они соответствуют вертикальным ординатам графика.
// Оба массива должны иметь между собой одинаковую размерность, но не обязательно равную двенадцати. 

// При обработке события "щелчок мыши на кнопке Button" создаем объект класса Graphics, используя элемент управления PictureBox
// (графическое поле), а затем, вызывая соответствующие процедуры, поэтапно рисуем координатные оси, сетку из горизонтальных и вертикальных
// линий и непосредственно эпюру.

// Чтобы успешно, минимальными усилиями, с возможностью дальнейшего совершенствования программы построить график, следует как можно более понятно назвать
// некоторые ключевые, часто встречающиеся интервалы и координаты на рисунке. Из названий этих интервалов будет следовать смысл. Скажем, переменная OtstupSleva
// хранит число пикселов, на которое следует отступать, чтобы строить на графике, например, вертикальную ось продаж. Кроме очевидных названий упомянем переменную 
// Y_GorizOsi — это графическая ордината (ось x направлена слева направо, а ось y — сверху вниз) горизонтальной оси графика, на которой подписываются месяцы. Переменная
// X_Max содержит значение максимальной абсциссы, правее которой уже никаких построений нет. Переменная X_Na4Epyuri — это значение абсциссы первой построенной точки графика.