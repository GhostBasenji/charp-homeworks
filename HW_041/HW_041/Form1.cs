// Программа строит сплайн Безье по двум узловым точкам, а две контрольные (управляющие) точки совмещены в одну.
// Эта одна управляющая точка отображается в форме в виде красного прямоугольника.
// Перемещая указателем мыши управляющую точку, мы регулируем форму сплайна (кривой) 

namespace HW_041
{
    public partial class Form1 : Form
    {
        PointF[] MassivTo4ek;
        // Запрещаем управлять формой кривой:
        Boolean Upravlenie;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Upravlenie = false;
            this.Text = "Управление сплайном Безье";

            // Начальная узловая точка:
            var p0 = new PointF(50, 50);

            // Две контрольные (управляющие) точки, мы их совместили в одну:
            var p1 = new PointF(125, 125);
            var p2 = new PointF(125, 125);

            // Конечная узловая точка:
            var p3 = new PointF(200.0F, 200.0F);
            MassivTo4ek = new PointF[] { p0, p1, p2, p3 };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Задаем поверхность для рисования из аргумента события e:
            var Grafika = e.Graphics;
            var Pero = new Pen(Color.Blue, 3);

            // Рисуем начальную и конечную узловые точки диаметром 4 пиксела:
            Grafika.DrawEllipse(Pero, MassivTo4ek[0].X - 2, MassivTo4ek[0].Y - 2, 4.0F, 4.0F);
            Grafika.DrawEllipse(Pero, MassivTo4ek[3].X - 2, MassivTo4ek[3].Y - 2, 4.0F, 4.0F);

            // Одна управляющая точка в виде прямоугольника красного цвета:
            Pero.Color = Color.Red;
            Grafika.DrawRectangle(Pero, MassivTo4ek[1].X - 2, MassivTo4ek[1].Y - 2, 4.0F, 4.0F);
            Pero.Color = Color.Blue;

            // Рисуем сплайн Безье:
            Grafika.DrawBeziers(Pero, MassivTo4ek);
            
            // Освобождаем ресурсы:
            Grafika.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Событие перемещения указателя мыши в области формы.

            // Если указатель мыши расположен над управляющей точкой
            if (Math.Abs(e.X - MassivTo4ek[1].X) < 4.0F &&
                Math.Abs(e.Y - MassivTo4ek[1].Y) < 4.0F &&
                Upravlenie == true)
            {
                // и при этом нажата кнопка мыши,
                // то меняем координаты управляющей точки:
                MassivTo4ek[1].X = e.X;
                MassivTo4ek[1].Y = e.Y;
                MassivTo4ek[2].X = e.X;
                MassivTo4ek[2].Y = e.Y;
                // и обновляем (перерисовываем) форму:
                this.Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Если нажата кнопка мыши, то разрешаем управлять формой кривой:
            Upravlenie = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Если кнопку мыши отпустили, то запрещаем управлять формой кривой:
            Upravlenie = false;
        }
    }
}


// Система Visual Studio 22 предоставляет возможность построения фундаментального сплайна и сплайна Безье.
// В принципе, программирование сплайна Безье сводится к подаче на вход соответствующей функции DrawBezier узловых точек,
// через которые проходит сплайн, а также дополнительных контрольных точек. В сплайне Безье с помощью контрольных точек
// управляют его кривизной, т. е. его формой. Можно себе представить, как при некотором положении контрольных точек добиться
// того, что сплайн будет изгибаться в обе стороны, т. е. между двумя точками появятся положительная кривизна и отрицательная,
// а между ними — точка перегиба. 

// В коде массив из четырех точек (две узловые и две контрольные) объявляем вне процедур класса Form1, чтобы этот массив был "виден"
// из всех этих процедур.
// Начальные значения элементов массива задаем при обработке события загрузки формы.
// При обработке события перерисовки формы рисуем начальную и конечную узловые точки, одну управляющую точку в виде прямоугольника
// красного цвета и, наконец, сплайн Безье по текущим значениям массива четырех точек. Булева переменная Upravlenie, объявленная
// также вне всех процедур, принимает значение true при нажатой кнопке мыши, а если кнопку мыши отпустили, то этой переменной присваиваем
// значение false. При обработке события перемещения указателя мыши в пределах формы происходит проверка — если указатель мыши расположен вблизи 
// управляющей точки, и при этом нажата кнопка мыши, то координаты управляющей точки назначаем равными текущим координатам положения мыши
// (их берем из аргументной переменной e) и перерисовываем (т. е. обновляем) форму.