// Перепишем код ДЗ 034 на более элегантный код, с использованием цикла foreach 
namespace HW_034a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Получаем массив строк имен цветов из перечисления KnownColor. 
            // Enum.GetNames возвращает массив имен констант в указанном перечислении. 

            // Удаляем все элементы из коллекции:
            listBox1.Items.Clear();

            // Добавляем имена всех цветов в список listBox1:
            foreach (String Cvet in Enum.GetNames(typeof(KnownColor)))
                if (Cvet != "Transparent") listBox1.Items.Add(Cvet);
            // Цвет Transparent является "прозрачным" 

            // Сортируем все цвета в списке в алфавитном порядке:
            listBox1.Sorted = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обрабатываем событие изменения выбранного индекса в списке listBox1:
            this.BackColor = Color.FromName(listBox1.Text);

            // Надпись в строке заголовка формы:
            this.Text = "Цвет: " + listBox1.Text;
        }
    }
}


// Как видно из кода, во втором варианте цикл foreach обеспечивает заполнение списка элементов именами
// цветов в строковом представлении — кроме цвета Transparent, поэтому теперь его даже не надо "отсеивать"
// в процедуре обработки события изменения выбранного индекса. 