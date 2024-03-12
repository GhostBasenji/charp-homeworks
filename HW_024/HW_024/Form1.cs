// Программа для чтения/записи текстового файла в кодировке Windows 1251

namespace HW_024
{
    public partial class Form1 : Form
    {
        String ImyaFaila;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            button1.Text = "Открыть"; button1.TabIndex = 0;
            button2.Text = "Сохранить";
            this.Text = "Здесь кодировка Windows 1251";
            ImyaFaila = @"D:\Text2.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке Открыть
            try
            {
                // Чтобы русские буквы читались корректно, объявляем объект Kodirovka:
                var Kodirovka = System.Text.Encoding.GetEncoding(1251);

                // Создаем экземпляр StreamReader для чтения из файла
                var Chitatel = new System.IO.StreamReader(ImyaFaila, Kodirovka);
                textBox1.Text = Chitatel.ReadToEnd();
                Chitatel.Close();

                // Читать текстовый файл в кодировке Windows 1251 в массив
                // строк можно также таким образом (без Open и Close):
                // var МассивСтрок = System.IO.File.
                // ReadAllLines(@"D:\Text2.txt", Кодировка);
            }
            catch (System.IO.FileNotFoundException Situation)
            {
                // Обработка исключительной ситуации:
                MessageBox.Show(Situation.Message + "\nНет такого файла",
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            catch (Exception Situation)
            {
                // Отчет о других ошибках
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Щелчок на кнопке Сохранить:
            try
            {
                var Kodirovka = System.Text.Encoding.GetEncoding(1251);

                // Создаем экземпляр StreamWriter для записи в файл:
                var Pisatel = new System.IO.StreamWriter(ImyaFaila, false, Kodirovka);
                Pisatel.Write(textBox1.Text);
                Pisatel.Close();
                
                // Сохранить текстовый файл можно также таким образом (без Close),
                // причем если файл уже существует, то он будет заменен:
                // System.IO.File.WriteAllText(@"D:\tmp.tmp", 
                // textBox1.Text, Кодировка);
            }
            catch (Exception Situation)
            {
                // Отчет обо всех возможных ошибках:
                MessageBox.Show(Situation.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}



// Текст этой программы отличается от предыдущей лишь тем, что здесь введен новый объект — Kodirovka.
// Метод GetEncoding(1251) устанавливает кодовую страницу Windows 1251 для объекта Kodirovka.
// Можно убедиться в этом, если распечатать свойство Kodirovka.HeaderName.

// При создании объекта Chitatel используются уже два аргумента: имя файла и объект Kodirovka, указывающий,
// в какой кодировке (для какой кодовой страницы) читать данные из текстового файла.
// А при создании объекта Pisatel используются три аргумента: имя файла, установка false (для случая,
// если файл уже существует, нужно будет не  добавлять новые данные, а создавать новый файл)
// и объект Kodirovka, указывающий, в какой кодировке писать данные в файл.

// Примечание. При обработке события "щелчок на второй кнопке" мы объявили переменные Kodirovka и Pisatel просто как var,
// т. е. типы этих переменных выводятся из выражения инициализации. 