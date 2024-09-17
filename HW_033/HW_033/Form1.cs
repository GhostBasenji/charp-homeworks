// Программа позволяет рисовать в форме графические примитивы: 
// окружность, отрезок, прямоугольник, сектор, текст, эллипс и 
// закрашенный сектор. Выбор того или иного графического примитива 
// осуществляется с помощью элемента управления ListBox 

// Система координат такая: начало координат — это левый верхний угол формы, ось Ox 
// направлена вправо, а Oy — вниз.

namespace HW_033
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Выбери графический примитив";
            var Kollekciya = new Object[]
            {
                "Окружность", "Отрезок", "Прямоугольник", "Сектор",
                "Текст", "Эллипс", "Закрашенный сектор"
            };
            listBox1.Items.AddRange(Kollekciya);
            Font = new Font("Times New Roman", 12);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Здесь вместо этого события можно было бы обработать также событие listBox1_Click. 
            
            // Создаем графический объект:
            var Grafika = CreateGraphics();

            // Создаем перо для рисования им фигур
            var Pero = new Pen(Color.Green);

            // Создаем кисть для "закрашиваня" фигур
            var Kisty = new SolidBrush(Color.Green);

            // Очищаем область рисования путем ее окрашивания в первоначальный цвет формы
            Grafika.Clear(SystemColors.Control);
            // или Графика.Clear(Color.FromName("Control")); 
            // или Графика.Clear(ColorTranslator.FromHtml("#F0F0F0")); 

            switch (listBox1.SelectedIndex) // Выбираем фигуру:
            {
                case 0: // - выбираем окружность
                    Grafika.DrawEllipse(Pero, 50, 50, 150, 150); break;
                case 1: // - выбираем отрезок
                    Grafika.DrawLine(Pero, 50, 50, 200, 200); break;
                case 2: // - выбираем прямоугольник
                    Grafika.DrawRectangle(Pero, 50, 30, 150, 180); break;
                case 3: // - выбираем сектор
                    Grafika.DrawPie(Pero, 40, 50, 200, 200, 180, 225); break;
                case 4: // - выбираем текст
                    Grafika.DrawString("Каждый во что-то верит, но" + "\n" +
                        "жизнь преподносит сюрпризы", Font, Kisty, 10, 100); break;
                case 5: // выбираем эллипс
                    Grafika.DrawEllipse(Pero, 30, 30, 150, 200); break;
                case 6: // выбираем закрашенный сектор:
                    Grafika.FillPie(Kisty, 20, 50, 150, 150, 0, 45); break;
            }
            Grafika.Dispose();
        }
    }
}


// В программе, обрабатывая событие изменения выбранного индекса в списке listBox1
// создаем графический объект Графика, перо для рисования им фигур и кисть для "закрашивания" ею фигур.
// Далее очищаем область рисования путем окрашивания формы в первоначальный цвет "Control" или "#F0F0F0"
// (как записано в комментарии), используя метод Clear() объекта Графика: Графика.Clear(SystemColors.Control);
// При очищении области рисования оставляем цвет формы первоначальным — "Control". 

// После очистки формы, используя свойство SelectIndex, которое указывает на номер выбранного пользователем элемента списка (от 0 до 6),
// рисуем выбранную фигуру. Далее оператор switch осуществляет множественный выбор графического примитива в зависимости от индекса выбранного элемента
// списка SelectedIndex. Оператор switch case передает управление той или иной метке case.

// ВНИМАНИЕ! Оператор множественного выбора в C# "проваливается", т. е. управление, зайдя на какую-либо метку case,
// переходит на следующую метку, поэтому приходится использовать оператор break. 