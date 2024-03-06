// Программа Калькулятор с кнопками цифр. Управление калькулятором возможно
// только мышью. Данный калькулятор выполняет лишь арифметические операции
// P.S. Обработка нескольких событий от разных объектов одной процедурой оказывается весьма полезной при программировании Калькулятора.
namespace HW_017
{
    public partial class Form1 : Form
    {
        // Объявляем внешние переменные, видимые из всех процедур класса Form1:
        String Znak = String.Empty; // - знак арифметической операции

        // Признак того, что пользователь вводит новое число:
        Boolean Nachalo_Vvoda = true;

        // Первое и второе числа, вводимые пользователем:
        Double Chislo1, Chislo2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Калькулятор";
            button1.Text = "1"; button2.Text = "2"; button3.Text = "3";
            button4.Text = "4"; button5.Text = "5"; button6.Text = "6";
            button7.Text = "7"; button8.Text = "8"; button9.Text = "9";
            button10.Text = "0"; button11.Text = "="; button12.Text = "+";
            button13.Text = "-"; button14.Text = "*"; button15.Text = "/";
            button16.Text = "Очистить";
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Right;

            // Связываем все события "щелчок на кнопках-цифрах" с обработчиком Cifra:
            this.button1.Click += new System.EventHandler(this.Cifra);
            this.button2.Click += new System.EventHandler(this.Cifra);
            this.button3.Click += new System.EventHandler(this.Cifra);
            this.button4.Click += new System.EventHandler(this.Cifra);
            this.button5.Click += new System.EventHandler(this.Cifra);
            this.button6.Click += new System.EventHandler(this.Cifra);
            this.button7.Click += new System.EventHandler(this.Cifra);
            this.button8.Click += new System.EventHandler(this.Cifra);
            this.button9.Click += new System.EventHandler(this.Cifra);
            this.button10.Click += new System.EventHandler(this.Cifra);

            this.button12.Click += new System.EventHandler(this.Operacia);
            this.button13.Click += new System.EventHandler(this.Operacia);
            this.button14.Click += new System.EventHandler(this.Operacia);
            this.button15.Click += new System.EventHandler(this.Operacia);

            this.button11.Click += new System.EventHandler(this.Ravno);
            
            this.button16.Click += new System.EventHandler(this.Ochistit);
        }
        private void Cifra(object sender, EventArgs e)
        {
            // Обработка события нажатия кнопки-цифры.
            // Получить текст, отображаемый на кнопке можно таким образом:
            Button Knopka = (Button)sender;
            String Digit = Knopka.Text;
            if (Nachalo_Vvoda == true)
            {
                // Ввод первой цифры числа:
                textBox1.Text = Digit;
                Nachalo_Vvoda = false; return;
            }
            // "Сцепляем" полученные цифры в новое число:
            if (Nachalo_Vvoda == false)
                textBox1.Text = textBox1.Text + Digit;
        }

        // Это означает, что мы различаем начало ввода числа Nachalo_Vvoda = True, когда нуль
        // следует менять на вводимую цифру, и последующий ввод Nachalo_Vvoda = False, когда
        // очередную цифру следует добавлять справа.Таким образом, если это уже не первая
        // нажатая пользователем кнопка-цифра (Nachalo_Vvoda = False), то "сцепляем" полученную цифру с предыдущими введенными цифрами,
        // иначе — просто запоминаем первую цифру в текстовом поле TextBox1.

        private void Operacia(object sender, EventArgs e)
        {
            // Обработка события нажатия кнопки арифметической операции:
            Chislo1 = Double.Parse(textBox1.Text);
            // Получить текст, отображаемый на кнопке можно таким образом:
            Button Knopka = (Button)sender;
            Znak = Knopka.Text;
            Nachalo_Vvoda = true; // ожидаем ввод нового числа
        }
        private void Ravno(object sender, EventArgs e)
        {
            // Обработка события нажатия клавиши "Равно"
            double Resultat = 0;
            Chislo2 = Double.Parse(textBox1.Text);
            if (Znak == "+") Resultat = Chislo1 + Chislo2;
            if (Znak == "-") Resultat = Chislo1 - Chislo2;
            if (Znak == "*") Resultat = Chislo1 * Chislo2;
            if (Znak == "/") Resultat = Chislo1 / Chislo2;
            Znak = null;

            // Отображаем результат в текстовом поле:
            textBox1.Text = Resultat.ToString();
            Chislo1 = Resultat; Nachalo_Vvoda = true;
        }
        private void Ochistit(object sender, EventArgs e)
        {
            // Обработка события нажатия клавиши "Очистить"
            textBox1.Text = "0"; Znak = null; Nachalo_Vvoda = true;
        }
    }
}