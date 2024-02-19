// Обработка события — MouseHover. Событие MouseHover наступает, когда 
// пользователь указателем мыши "зависает" над каким-либо объектом, причем именно 
// "зависает" (от англ. hover — реять, парить), а не просто проводит мышью над объектом. 
// Можно сказать также, что событие MouseHover происходит, когда указатель мыши наведен на элемент.

namespace HW_002
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Процедура обработки события загрузки формы
            base.Text = "Дом. задание №2";

            // или
            // this.Text = "Приветствие";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Процедура обработки события "щелчок на кнопке"
            MessageBox.Show("Вызвали событие Button_Click");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            // Обработка события, когда указатель мыши "завис" над меткой:
            MessageBox.Show("Вызвали событие MouseHover");
        }
    }
}