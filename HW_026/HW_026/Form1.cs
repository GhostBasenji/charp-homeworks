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




// В программе есть несколько переменных, которые объявлены в начале вне всех процедур, чтобы они были "видны" из всех процедур класса Form1.
// В процедуре обработки загрузки формы организуем подписку на событие "изменение состояния переключателей" RadioButton одной процедурой IzmSostPerekl.
// В этой программе изменение состояния любого из трех переключателей будем обрабатывать одной процедурой IzmSostPerekl.

// Далее в процедуре NachaloTesta открываем файл test.txt, в котором содержится непосредственно тест, и читаем первую строку с названием предмета или темы,
// подлежащей тестированию. При этом обнуляем счетчик всех вопросов и счетчики вопросов, на которые студент дал правильные и неправильные ответы.
// Затем вызываем процедуру ChitatSledVopros, которая читает очередной вопрос, варианты ответов на него и номер варианта правильного ответа.
// Тут же проверяем, не достигнут ли конец читаемого программой файла. Если достигнут, то меняем надпись на первой кнопке на "Завершить".
// В нашей программе надпись на первой кнопке является как бы флагом, который указывает, по какой ветви в программе следует передавать управление.
// При выборе студентом того или иного варианта испытуемый может сколь угодно раз щелкать на разных переключателях, пока не выберет окончательно вариант ответа.
// Программа зафиксирует выбранный вариант только после щелчка на кнопке Следующий вопрос. В процедуре обработки события "изменение состояния переключателей" 
// выясняем, какой из вариантов ответа выбрал студент, но делаем вывод, правильно ли ответил студент или нет, только при обработке события "щелчок на первой кнопке".

// В процедуре обработки события "щелчок на первой кнопке" ведем счет правильных и неправильных ответов, а также запоминаем в строковый массив вопросы, на которые
// студент дал неверный ответ. Если достигнут конец файла, и надпись на кнопке стала "Завершить", то закрываем текстовый файл, все переключатели делаем невидимыми 
// (уже выбирать нечего) и формируем оценку за прохождение теста, а также через MessageBox выводим список вопросов, на которые испытуемый дал ошибочный ответ.