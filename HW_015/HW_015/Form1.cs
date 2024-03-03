// Программа создает командную кнопку в форме "программным" способом,
// т.е. с помощью написания непосредственно программного кода, не используя
// при этом панель элементов управления Toolbox. Программа задает свойства
// кнопки: ее видимость, размеры, положение, надпись на кнопке
// и подключает событие "щелчок на кнопке"
namespace HW_015
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание кнопки без панели элементов управления:
            var Knopka = new Button();
            // Задаем свойства кнопки:
            Knopka.Visible = true;
            // Ширина и высота кнопки:
            Knopka.Size = new Size(150, 30);
            //Расположение кнопки в системе координат формы:
            Knopka.Location = new Point(70, 80);
            Knopka.Text = "Новая кнопка";
            // Добавление кнопки в коллекцию элементов управления
            this.Controls.Add(Knopka);

            // Подписку на событие Click для кнопки можно делать "вручную".
            // Связываем событие Click с процедурой обработки этого события:
            Knopka.Click += new EventHandler(Klik);
        }
        // Создаем обработчик события Click для кнопки:
        private void Klik(object sender, EventArgs e)
        {
            MessageBox.Show("Нажата новая кнопка");
        }
    }
}