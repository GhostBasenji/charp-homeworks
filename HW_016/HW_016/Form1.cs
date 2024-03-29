// В форме имеем две кнопки, и при нажатии указателем мыши
// любой из них получаем номер нажатой кнопки. При этом в программе
// предусмотрена только одна процедура обработки событий 
// При этом используя параметр процедуры обработки события sender, мы определим, на какой из двух кнопок щелкнули мышью.
namespace HW_016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            base.Text = "Щелкните на кнопке"; label1.Text = null;

            // Связываем события Click от обеих кнопок с одной процедурой Knopka_Click:
            button1.Click += new EventHandler(Knopka_Klik);
            button2.Click += new EventHandler(Knopka_Klik);

            // Подпиской на событие называют связывание названия события,
            // например, Click, с названием процедуры обработки события,
            // например, Knopka_Click посредством EventHandler 
        }

        // Создаем обработчик события Click для кнопки:
        private void Knopka_Klik(object sender, EventArgs e)
        {
            // Получить текст, отображаемый на кнопке, можно таким образом:
            // label1.Text = Convert.ToString(sender);
            // или
            // label1.Text = ((Button) sender).Text;
            var Knopka = (Button)sender;
            label1.Text = "Нажата кнопка " + Knopka.Text; // или Knopka.Name
        }
    }
}




// Как видно из текста программы, при обработке события загрузки формы осуществляется т.н. "подписка на событие",
// т.е. происходит связывание названия события с названием процедуры обработки события Knopka_Klik посредством метода (делегата) EventHandler.
// Этот метод делегирует (передает полномочия) обработку события "щелчок на кнопке" процедуре, именуемой Klik. Заметим, что события Click от обеих 
// кнопок мы связали с одной и той же процедурой Klik.
// Далее создаем процедуру обработки события Klik. Параметр этой процедуры sender
// содержит ссылку на объект-источник события, т.е. кнопку, нажатую пользователем.
// C помощью преобразования можно конвертировать параметр sender в экземпляр класса Button
// и, таким образом, выяснить все свойства кнопки, которая инициировала событие.