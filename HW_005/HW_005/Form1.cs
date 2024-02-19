// Программа для ввода пароля в текстовое поле, причем при вводе вместо вводимых 
// символов некто, "находящийся за спиной пользователя", увидит только звездочки


namespace HW_005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Введите пароль";
            textBox1.Text = null; textBox1.TabIndex = 0;
            textBox1.PasswordChar = '*';
            textBox1.Font = new Font("Courier New", 10.0F);
            // или textBox1.Font = new Font(FontFamily.GenericMonospace, 10.0F);
            label1.Text = String.Empty;
            label1.Font = new Font("Courier New", 10.0F);
            button1.Text = "Показать пароль";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }
    }
}