namespace HW_031c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Рисунок";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Risunok = new Bitmap(@"D:\test.png");
            // Создаем графический объект:
            var Grafika = this.CreateGraphics();
            // или var Grafika = CreateGraphics();
            Grafika.DrawImage(Risunok, 5, 5);
        }
    }
}
