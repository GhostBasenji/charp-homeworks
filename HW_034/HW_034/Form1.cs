// Программа меняет цвет фона формы BackColor, перебирая константы цвета,
// предусмотренные в Visual Studio 2022, с помощью элемента управления ListBox

namespace HW_034
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Получаем массив строк имен цветов из перечисления KnownColor
            var VseCveta = Enum.GetNames(typeof(KnownColor));
            listBox1.Items.Clear();
            // В список элементов добавляем имена всех цветов:
            listBox1.Items.AddRange(VseCveta);
            // Сортируем записи в алфавитном порядке
            listBox1.Sorted = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Цвет Transparent является "прозрачным"
            if (listBox1.Text == "Transparent") return;
            this.BackColor = Color.FromName(listBox1.Text);
            this.Text = "Цвет: " + listBox1.Text;
        }
    }
}



// Как видно из кода, при обработке события загрузки формы, используя метод Enum.GetNames,
// получим массив имен цветов в строковом представлении.
// Теперь этот массив легко добавить в список (коллекцию) ListBox методом AddRange.
// Если запустить на данном этапе текущий проект (клавишей <F5>), не написав обработку события
// изменения выбранного индекса, то увидим форму и заполненные строки элемента управления ListBox
// цветами из перечисления KnownColor.
// Обрабатывая событие изменения выбранного индекса в списке ListBox, предпоследней строкой назначаем выбранный
// пользователем цвет формы (BackColor). Один из цветов перечисления KnownColor — цвет Control ("умалчиваемый" цвет формы),
// который является базовым цветом во многих программах Microsoft. Кроме того, здесь цветов больше, чем в константах цветов
// (структуре) Color (в структуре Color нет цвета Control). Один из цветов — Transparent — является "прозрачным",
// и для фона формы он не поддерживается. Поэтому если пользователь выберет этот цвет, то произойдет выход из процедуры (return),
// и цвет формы не изменится. 