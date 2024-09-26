// Программа позволяет при нажатой левой или правой кнопке мыши рисовать в форме 

namespace HW_040
{
    public partial class Form1 : Form
    {
        Boolean Risovat_li;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Рисую мышью в форме";
            button1.Text = "Стереть";
            Risovat_li = false; // в начале - не рисовать
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Если нажата кнопка мыши - MouseDown, то рисовать
            Risovat_li = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Если кнопку мыши отпустили, то НЕ рисовать
            Risovat_li = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Рисуем прямоугольник, если нажата кнопка мыши
            if (Risovat_li == true)
            {
                // Рисуем прямоугольник в точке (e.X, e.Y)
                var Grafika = CreateGraphics();
                Grafika.FillRectangle(new SolidBrush(Color.Blue), e.X, e.Y, 10, 10);
                // 10*10 пискелов - размер сплошного прямоугольника
                // e.X, e.Y - координаты указателя мыши
                Grafika.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Методы очистки формы:
            var Grafika = CreateGraphics();
            Grafika.Clear(this.BackColor);
            // Графика.Clear(SystemColors.Control); 
            // Графика.Clear(Color.FromName("Control")); 
            // Графика.Clear(Color.FromKnownColor(KnownColor.Control)); 
            // Графика.Clear(ColorTranslator.FromHtml("#F0F0F0")); 
            // this.Refresh(); // Этот метод также перерисовывает форму 
        }
    }
}


// Здесь в начале программы объявлена переменная Risovat_li логического типа (Boolean) со значением False. Эта переменная либо позволяет (Risovat_li = true)
// рисовать в форме при перемещении мыши (событие MouseMove), либо не разрешает делать это (Risovat_li = false). Область действия переменной Risovat_li — весь класс
// Form1, т. е. изменить или выяснить ее значение можно в любой процедуре этого класса.
// Значение переменной Risovat_li может изменить либо событие MouseUp (кнопку мыши отпустили, рисовать нельзя, Risovat_li = false), либо событие MouseDown (кнопку мыши
// нажали, рисовать можно, Risovat_li = frue). При перемещении мыши с нажатой кнопкой программа создает графический объект Graphics пространства имен System.Drawing,
// используя метод CreateGraphics(), и рисует прямоугольник FillRectangle() размером 10*10 пикселов, заполненный синим цветом.
// e.X, e.Y — координаты указателя мыши, которые так же являются координатами левого верхнего угла прямоугольника.