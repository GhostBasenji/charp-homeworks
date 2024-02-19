// Программа управляет стилем шрифта текста, выведенного на метку Label, посредством двух флажков CheckBox.
// Программа использует побитовый оператор (^) Xor — исключающее ИЛИ

namespace HW_007
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            base.Text = "Флажок CheckBox";
            checkBox1.Text = "Полужирный"; checkBox1.Focus();
            checkBox2.Text = "Наклонный";
            label1.Text = "Выбери стиль шрифта";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font("Courier New", 14.0F);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Font = new Font("Courier New", 14.0F, label1.Font.Style ^ FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Font = new Font("Courier New", 14.0F, label1.Font.Style ^ FontStyle.Italic);
        }
    }
}

// Здесь каждый раз при изменении состояния флажка значение параметра 
// Label1.Font.Style сравнивается с одним и тем же значением FontStyle.Bold. Поскольку 
// между ними стоит побитовый оператор (^) (исключающее ИЛИ), он будет назначать 
// Bold, если текущее состояние Label1.Font.Style "не Bold". А если Label1.Font.Style
// пребывает в состоянии "Bold", то оператор (^) будет назначать состояние "не Bold". 
// Этот оператор еще называют логическим XOR.
// Таблица истинности логического XOR такова:
// A Xor B = C
// 0 Xor 0 = 0
// 1 Xor 0 = 1
// 0 Xor 1 = 1
// 1 Xor 1 = 0
// В нашем случае мы имеем всегда B = 1 (FontStyle.Bold), а A(Label1.Font.Style) попеременно то Bold, то Regular (т. е. "не Bold"). Таким образом, оператор Xor всегда будет 
// назначать противоположное тому, что записано в Label1.Font.Style. 
// Как можно видеть, применение побитового оператора привело к существенному уменьшению количества программного кода.
// СОВЕТ. Использование побитовых операторов может значительно упростить написание программ со сложной логикой