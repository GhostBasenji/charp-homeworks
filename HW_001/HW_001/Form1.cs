// Простой пример формы с Button, Label и с диалоговым окном MessageBox с текстом "Всем привет!"

namespace HW_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Всем привет!");
        }
    }
}