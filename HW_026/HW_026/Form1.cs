// В этом примере мы создадим инструмент для тестирования студентов — напишем программу, которая читает
// заранее подготовленный преподавателем текстовый файл с вопросами по какому-либо предмету
// и выводит в экранную форму каждый вопрос с вариантами ответов.
// Студент выбирает правильный вариант ответа, а в конце тестирования программа подводит итоги проверки знаний,
// выставляет общую оценку и, в качестве обоснования поставленной оценки, показывает вопросы, на которые студент ответил неправильно

namespace HW_026
{
    public partial class Form1 : Form
    {
        // Внешние переменные
        int SchetVoprosov;     // Счет вопросов
        int PravilOtvetov;     // Количество правильных ответов
        int NePravilOtvetov;   // Количество неправильных ответов

        // Массив вопросов, на которые даны неправильные ответы:
        String[] NePravilOtveti; // Размерность этого массива задается позже
        int NomerPravOtveta;     // Номер правильного ответа
        int VibranOtvet;         // Номер ответа, выбранный студентом

        System.IO.StreamReader Chitatel;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Следующий вопрос";
            button2.Text = "Выход";

            // Подписываем на событие "изменение состояния переключателей" RadioButton:
            radioButton1.CheckedChanged += new EventHandler(IzmSostPerekl);
            radioButton2.CheckedChanged += new EventHandler(IzmSostPerekl);
            radioButton3.CheckedChanged += new EventHandler(IzmSostPerekl);
            NachaloTesta();
        }

        void NachaloTesta()
        {
            try
            {
                // Создаем экземпляр StreamReader для чтения из файла
                Chitatel = new System.IO.StreamReader(
                    System.IO.Directory.GetCurrentDirectory() + @"\test.txt");
                this.Text = Chitatel.ReadLine();   // Название предмета

                // Обнуляем все счетчики:
                SchetVoprosov = 0; PravilOtvetov = 0; NePravilOtvetov = 0;
                // Задаем размер массива для NePravilOtveti:
                NePravilOtveti = new String[100];
            }
            catch (Exception Situation)
            {
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ChitatSledVopros();
        }

        void ChitatSledVopros()
        {
            label1.Text = Chitatel.ReadLine();

            // Считываем варианты ответа:
            radioButton1.Text = Chitatel.ReadLine();
            radioButton2.Text = Chitatel.ReadLine();
            radioButton3.Text = Chitatel.ReadLine();

            // Выясняем, какой ответ - правильный:
            NomerPravOtveta = int.Parse(Chitatel.ReadLine());

            // Переводим все переключатели в состояние "выключено":
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            // Первую кнопку делаем неактивной, пока студент не выберет вариант ответа
            button1.Enabled = false;
            SchetVoprosov = SchetVoprosov + 1;

            // Проверяем, конец ли файла:
            if (Chitatel.EndOfStream == true) button1.Text = "Завершить";
        }

        void IzmSostPerekl(object sender, EventArgs e)
        {
            // Кнопка "Следующий вопрос" становится активной, и ей передаем фокус:
            button1.Enabled = true; button1.Focus();
            RadioButton Perekluchatel = (RadioButton)sender;
            var tmp = Perekluchatel.Name;

            // Выясняем номер ответа, выбранный студентом:
            VibranOtvet = int.Parse(tmp.Substring(11));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке "Следующий вопрос/Завершить/Начать тестирование сначала"
            // Счет правильных ответов:
            if (VibranOtvet == NomerPravOtveta) PravilOtvetov = PravilOtvetov + 1;
            if (VibranOtvet != NomerPravOtveta)
            {
                // Счет неправильных ответов:
                NePravilOtvetov = NePravilOtvetov + 1;
                // Запоминаем вопросы с неправильными ответами:
                NePravilOtveti[NePravilOtvetov] = label1.Text;
            }
            if (button1.Text == "Начать тестирование сначала")
            {
                button1.Text = "Следующий вопрос";

                // Переключатели становятся видимиыми, доступными для выбора:
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;

                // Переходим к началу файла:
                NachaloTesta(); return;
            }
            if (button1.Text == "Завершить")
            {
                // Закрываем текстовый файл:
                Chitatel.Close();

                // Переключатели делаем невидимыми:
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;

                // Формируем оценку за тест:
                label1.Text = String.Format("Тестирование завершено.\n" +
                    "Правильных ответов: {0} из {1}.\n" +
                    "Оценка в пятибалльной системе: {2:F2}.",
                    PravilOtvetov, SchetVoprosov, (PravilOtvetov * 5.0F) / SchetVoprosov); // 5.0F - это максимальная оценка
                button1.Text = "Начать тестирование сначала";

                // Выводим вопросы, на которые "Вы дали неправильный ответ":
                var Str = "СПИСОК ВОПРОСОВ, НА КОТОРЫЕ ВЫ ДАЛИ " +
                    "НЕПРАВИЛЬНЫЙ ОТВЕТ:\n\n";
                for (int i = 1; i <= NePravilOtvetov; i++)
                    Str = Str + NePravilOtveti[i] + "\n";

                // Если есть неправильные ответы, то выводим через MessageBox список соответствующих вопросов:
                if (NePravilOtvetov != 0) MessageBox.Show(Str, "Тестирование завершено");
            } // Конец условия if (button1.Text == "Завершить")
            if (button1.Text == "Следующий вопрос") ChitatSledVopros();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
