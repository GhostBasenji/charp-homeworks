// Напишем код формы, в которой размещен прозрачный треугольник
namespace HW_035
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Событие перерисовки формы:
            this.ClientSize = new Size(500, 500);

            // Устанавливаем вершины треугольника:
            var p1 = new Point(20, 20);
            var p2 = new Point(225, 66);
            var p3 = new Point(80, 185);

            // Инициализируем массив точек:
            Point[] To4ki = { p1, p2, p3 };

            // Закрашиваем этот треугольник цветом ControlDark:
            e.Graphics.FillPolygon(new SolidBrush(SystemColors.ControlDark), To4ki);

            // Цвет ControlDark задаем прозрачным:
            this.TransparencyKey = SystemColors.ControlDark;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        }
    }
}
