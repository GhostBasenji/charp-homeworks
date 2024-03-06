// Программа обеспечивает ссылку для посещения ya.ru,
// ссылку для просмотра папки C:\Windows\ и
// ссылку для запуска текстового редактора Блокнот
// с помощью элемента управления LinkLabel

using System.Diagnostics;

namespace HW_018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            base.Text = "Щелкните на ссылке:";
            linkLabel1.Text = "Сайт ya.ru";
            linkLabel2.Text = @"Папка C:\Windows\";
            linkLabel3.Text = "Вызвать \"Блокнот\"";
            this.Font = new Font("Consolas", 12.0F);
            linkLabel1.LinkVisited = true;
            linkLabel2.LinkVisited = true;
            linkLabel3.LinkVisited = true;

            // Подписка на события: все три события обрабатываются одной процедурой:
            linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SSYLKA);
            linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SSYLKA);
            linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SSYLKA);
        }

        private void SSYLKA(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Обработка щелчка на любой из ссылок:
            var ssilka = (LinkLabel)sender;
            // Выбор ссылки:
            switch (ssilka.Name) 
            {
                case "linkLabel1": // Интернет-ресурс
                    Process.Start(new ProcessStartInfo("https://ya.ru/") { UseShellExecute = true });
                    break;
                case "linkLabel2": // Папка файловой системы
                    Process.Start("explorer.exe", @"C:\Windows");
                    break;
                case "linkLabel3": // Редактор Блокнот
                    Process.Start("notepad.exe", @"d:\test.txt");
                    break;
            }
        }
    }
}

// Информация об объекте, создающем событие Click, записана в объектную переменную sender.
// Она позволяет распознавать объекты (ссылки), создающие события. Чтобы "вытащить"
// эту информацию из sender, объявим переменную ssilka типа LinkLabel и с помощью
// обычного присваивания выполним конвертирование параметра sender в экземпляр
// класса LinkLabel. В этом случае переменная ssilka будет содержать все свойства объекта-источника события,
// в том числе свойство Name, с помощью которого мы сможем распознавать выбранную ссылку.
// Идентифицируя по свойству Name каждую из ссылок, с помощью метода Start вызываем либо Chrome Browser,
// либо Windows Explorer, либо Блокнот.
// Вторым параметром метода Start является имя ресурса, подлежащее открытию.
// Именем ресурса может быть или название веб-страницы, или имя текстового файла.