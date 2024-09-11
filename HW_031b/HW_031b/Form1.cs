namespace HW_031b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // В свойствах формы щелкнем на значке молнии и в появившемся 
            // списке всех событий для объекта Form1 выберем событие Paint. 
            // Событие Paint — это событие рисования формы: 
            this.Text = "Рисунок";
            
            // Создаем объект для работы с изображением:
            var Risunok = Image.FromFile(@"D:\test.png");
            // или
            // var Risunok = new Bitmap(@"D:\test.png");

            // Выводим изображения в форму:
            e.Graphics.DrawImage(Risunok, 5, 5);
        }
    }
}
