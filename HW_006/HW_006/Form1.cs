// Программа управляет стилем шрифта текста, выведенного на метку Label, посредством флажка CheckBox
namespace HW_006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            base.Text = "Флажок CheckBox";
            checkBox1.Text = "Полужирный"; checkBox1.Focus();
            label1.Text = "Выбери стиль шрифта";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font("Courier New", 14.0F);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Изменение состояния флажка на противоположное
            if (checkBox1.Checked == true) label1.Font = new Font("Courier New", 14.0F, FontStyle.Bold);
            if (checkBox1.Checked == false) label1.Font = new Font("Courier New", 14.0F, FontStyle.Regular);
        }
    }
}

// При обработке события загрузки формы задаем начальные значения некоторых свойств объектов Form1(посредством ссылки base), label1 и checkBox1.
// Так, тексту флажка, выводимого с правой стороны, присваиваем значение "Полужирный".
// Кроме того, при старте программы фокус должен находиться на флажке (checkBox1.Focus()), в этом случае пользователь может изменять установку флажка даже клавишей <Пробел>.

// Текст метки — "Выбери стиль шрифта", выравнивание метки TextAlign задаем посередине и по центру (MiddleCenter) относительно всего того места, что предназначено для метки.
// Задаем шрифт метки Courier New (в этом шрифте все буквы имеют одинаковую ширину) размером 14 пунктов.

// Тут читается так: если флажок установлен(т.е.содержит "галочку") Checked = True, то для метки Label1 устанавливается тот же шрифт Courier New, 14 пунктов, но Bold, т.е. полужирный.
// Далее — следующая строчка кода: если флажок не установлен, т.е. CheckBox1.Checked = False, то шрифт устанавливается Regular, т. е. обычный.
// Очень часто эту ситуацию программируют, используя ключевое слово else, однако будучи записано, как здесь, — выражение выглядит более ясным и понятным.
