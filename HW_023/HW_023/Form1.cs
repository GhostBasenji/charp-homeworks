// Программа для чтения/записи текстового файла в кодировке Unicode

// Для текстового поля (textBox) в окне Properties указывается для свойства Multiline значение True,
// чтобы текстовое поле имело не одну строку, а столько, сколько поместится в растянутом указателем мыши поле.

using static System.Net.Mime.MediaTypeNames;

namespace HW_023
{
    public partial class Form1 : Form
    {
        // Объявляем ImyaFaila вне всех подпрограмм, чтобы эта переменная
        // была "видна" во всех процедурах обработок событий:
        String ImyaFaila;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Открыть"; button1.TabIndex = 0;
            button2.Text = "Сохранить";
            this.Text = "Здесь кодировка Unicode";
            ImyaFaila = @"D:\Text1.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке Открыть.
            // Русские буквы будут корректно читаться,
            // если открыть файл в кодировке UNICODE:
            try
            {
                // Создание объекта StreamReader для чтения из файла:
                var Chitatel = new System.IO.StreamReader(ImyaFaila);
                textBox1.Text = Chitatel.ReadToEnd();
                Chitatel.Close();

                // Читать текстовый файл в кодировке UNICODE в массив строк
                // можно следующим образом (без Open и Close):
                // var MassivStrok = System.IO.File.ReadAllLines(@"D:\Text.txt");
            }
            catch (System.IO.FileNotFoundException Situation)
            {
                // Обработка исключительной ситуации:
                MessageBox.Show(Situation.Message + "\n" +
                    "Нет такого файла", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Situation)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке Сохранить:
            try
            {
                var Pisatel = new System.IO.StreamWriter(ImyaFaila, false);
                Pisatel.Write(textBox1.Text);
                Pisatel.Close();

                // Сохранить текстовый файл можно следующим образом (без Close),
                // причем если файл уже существует, то он будет заменен:
                // System.IO.File.WriteAllText(@"D:\tmp.tmp", textBox1.Text);
            }
            catch (Exception Situation)
            {
                // Отчет обо всех возможных ошибок:
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}




// Несколько слов о блоках try, которые, как можно видеть, присутствуют в данном программном коде. Логика использования try следующая: попытаться(try) выполнить
// некоторую задачу, например прочитать файл. Если задача решена некорректно(например файл не найден), то "перехватить"(catch) управление и обработать возникшую
// (исключительную, Exception) ситуацию. Как видно из текста программы, обработка исключительной ситуации свелась к информированию пользователя о недоразумении.

// При обработке события "щелчок на кнопке Открыть" организован ввод файла D:\Text1.txt.
// Обычно в такой ситуации для выбора файла применяют элемент управления OpenFileDialog.
// Мы не стали использовать этот элемент управления для того, чтобы не "заговорить" проблему, а также свести к минимуму программный код.
// Далее создаем объект(поток) Chitatel для чтения из файла. Затем следует чтение файла ImyaFaila методом ReadToEnd() в текстовое поле TextBox1.Text
// и закрытие файла методом Close().

// При обработке события "щелчок на кнопке Сохранить" аналогично организована запись файла на диск через объект Писатель.
// При создании объекта Pisatel первым аргументом является ImyaFaila, а второй аргумент false указывает, что данные следует
// не добавить(append) к содержимому файла(если он уже существует), а перезаписать (overwrite). Запись на диск производится
// с помощью метода Write() из свойства Text элемента управления TextBox1.