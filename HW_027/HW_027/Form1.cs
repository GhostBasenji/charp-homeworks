// Простейший RTF-редактор
namespace HW_027
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            openFileDialog1.FileName = @"D:\Text2.txt";
            saveFileDialog1.Filter = "Файлы RTF (*.RTF) | *.RTF";

            // Оба события щелчка указателем мыши на пунктах меню "Открыть в формате RTF"
            // и "Открыть в формате Win1251" будем обрабатывать одной процедурой OPEN_FILES:
            открытьВФорматеWin1251ToolStripMenuItem.Click += new EventHandler(OPEN_FILES);
            открытьвформатеRTFToolStripMenuItem.Click += new EventHandler(OPEN_FILES);
        }

        void OPEN_FILES(object sender, EventArgs e)
        {
            // Процедура обработки событий открытия файла в двух разных форматах.
            // Выясняем, в каком формате открыть файл:
            var t = (ToolStripMenuItem)sender;

            // Читаем надпись на пункте меню:
            var Format = t.Text;
            try
            {
                // Открыть в каком-либо формате:
                if (Format == "Открыть в формате RTF")
                {
                    openFileDialog1.Filter = "Файлы RTF (*.RTF) | *.RTF";
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName == null) return;
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                }
                if (Format == "Открыть в формате Win1251")
                {
                    openFileDialog1.Filter = "Текстовые файлы (*.txt) | *.txt";
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName == null) return;
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                richTextBox1.Modified = false;
            }
            catch (System.IO.FileNotFoundException Situaciya)
            {
                MessageBox.Show(Situaciya.Message + "\nНет такого файла", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Situaciya)
            {
                // Отчет о других ошибках
                MessageBox.Show(Situaciya.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьВФорматеRTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Zapisy();
        }
        void Zapisy()
        {
            try
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                richTextBox1.Modified = false;
            }
            catch (Exception Situaciya)
            {
                // Отчет обо всех возможных ошибках:
                MessageBox.Show(Situaciya.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Обработка момента закрытия формы:
            if (richTextBox1.Modified == false) return;

            // Если текст модифицирован, то выясняем, записывать ли файл или нет?
            var MBox = MessageBox.Show(
                "Текст был изменен. \n" + "Сохранить изменения?",
                "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            // YES - диалог; NO - выход;  CANCEL - редактирование
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Zapisy(); return;
                }
                else e.Cancel = true; // Передумал выходить из редактора
            }
        }
    }
}


// В процедуре обработки события загрузки формы задаем начальные значения некоторым переменным.
// Здесь же выполняем подписку на обработку одной процедурой ОТКРЫТЬ двух событий:
// выбор пунктов меню Открыть в формате RTF и Открыть в формате Win1251
// Какой пункт меню выбрал пользователь, можно узнать, конвертировав переменную sender в объект t класса ToolStripMenuItem.
// Метод LoadFile объекта richTextBox1 загружает либо файл в формате RTF, либо файл в обычном текстовом формате.
// Перехватчик ошибок Catch сообщает пользователю либо о том, что такого файла нет, либо, если пользователь выбрал пункт 
// меню Открыть в формате RTF для открытия текстового файла, он получает сообщение "Недопустимый формат файла".
// Сохранение файла выполняется также с использованием стандартного диалога SaveFileDialog.
// Непосредственное сохранение файла удобнее всего выполнять в отдельной процедуре Запись(), поскольку эту процедуру необходимо вызывать также
// при выходе из программы, когда в документе имеются несохраненные изменения richTextBox1.Modified = true.
// В основе процедуры Запись() также лежит блок try...catch — выполнить попытку (try) сохранения файла (SaveFile)
// и при этом перехватить (catch) возможные недоразумения и сообщить о них пользователю в диалоговом окне MessageBox. 
// Вдобавок обработаны два события: пункт меню Выход и всевозможные варианты закрытия программы традиционными способами Windows.
// Предусмотрен диалог с пользователем в случае, если имеются несохраненные данные.

/* ЗАМЕЧАНИЕ
Для закрытия приложения следует осторожно пользоваться методом Exit объекта Application (можно сказать, с оглядкой).
Этот метод подготавливает приложение к закрытию. Да, метод Application.Exit() не вызывает события формы Closing. 
Но попробуйте проследить за поведением программы после команды Application.Exit с помощью отладчика (клавиша <F11>). 
Вы убедитесь, что после команды Application.Exit управление перейдет следующему оператору, затем — следующему, и так до конца процедуры.
Если на пути встретится функция MessageBox, то программа выдаст это диалоговое окно, и это несмотря на то, что уже давно была команда Application.Exit.
Аналогично ведет себя метод Close элемента Form (если вы работаете с проектом Windows Application), который вызывается таким образом: this.Close(). 
Да, this.Close вызывает событие формы Closing. Этот метод закрывает форму и освобождает все ресурсы. Но для освобождения ресурсов после команды this.Close управление также пройдет все операторы процедуры. 
Таким образом, для немедленного выхода из процедуры следует комбинировать названные методы с return. */