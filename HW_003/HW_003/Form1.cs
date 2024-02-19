// Как видно из программного кода, при обработке события загрузки формы задается нужный формат отображения даты:
// * вначале(первые три буквы "ddd") — вывод дня недели в краткой форме;
// * затем("dd MMM") — числа и названия месяца, также в краткой форме;
// * и, наконец, вывод года ("yyyy" ). 
// При обработке события изменения даты ValueChanged текстовой метке label1 присваиваем выбранное значение даты. При этом пользуемся методом String.Format. 
// Использованный формат "Выбранная дата: {0}" означает — взять нулевой выводимый элемент,
// т. е. свойство Text объекта DataTimePicker1, и записать его вместо фигурных скобок.
// При обработке события "щелчок на кнопке" вначале передаем фокус на элемент управления DateTimePicker1. Теперь для раскрытия календаря можно использовать нажатие клавиши <F4>.

namespace HW_003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Простое приложение выбора даты";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "ddd, dd MMM, yyyy";

            button1.Text = "Выбрать дату:";

            label1.Text = String.Format("Сегодня: {0}", dateTimePicker1.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = String.Format("Выбранная дата: {0}", dateTimePicker1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Передаем фокус на элемент управления dateTimePicker1:
            dateTimePicker1.Focus();

            // Имитация нажатия клавиши F4
            SendKeys.Send("{F4}");
        }
    }
}