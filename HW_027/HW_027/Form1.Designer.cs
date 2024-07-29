namespace HW_027
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьвформатеRTFToolStripMenuItem = new ToolStripMenuItem();
            открытьВФорматеWin1251ToolStripMenuItem = new ToolStripMenuItem();
            сохранитьВФорматеRTFToolStripMenuItem = new ToolStripMenuItem();
            закрытьToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 24);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(800, 426);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьвформатеRTFToolStripMenuItem, открытьВФорматеWin1251ToolStripMenuItem, сохранитьВФорматеRTFToolStripMenuItem, закрытьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьвформатеRTFToolStripMenuItem
            // 
            открытьвформатеRTFToolStripMenuItem.Name = "открытьвформатеRTFToolStripMenuItem";
            открытьвформатеRTFToolStripMenuItem.Size = new Size(230, 22);
            открытьвформатеRTFToolStripMenuItem.Text = "Открыть в формате RTF";
            // 
            // открытьВФорматеWin1251ToolStripMenuItem
            // 
            открытьВФорматеWin1251ToolStripMenuItem.Name = "открытьВФорматеWin1251ToolStripMenuItem";
            открытьВФорматеWin1251ToolStripMenuItem.Size = new Size(230, 22);
            открытьВФорматеWin1251ToolStripMenuItem.Text = "Открыть в формате Win1251";
            // 
            // сохранитьВФорматеRTFToolStripMenuItem
            // 
            сохранитьВФорматеRTFToolStripMenuItem.Name = "сохранитьВФорматеRTFToolStripMenuItem";
            сохранитьВФорматеRTFToolStripMenuItem.Size = new Size(230, 22);
            сохранитьВФорматеRTFToolStripMenuItem.Text = "Сохранить в формате RTF";
            сохранитьВФорматеRTFToolStripMenuItem.Click += сохранитьВФорматеRTFToolStripMenuItem_Click;
            // 
            // закрытьToolStripMenuItem
            // 
            закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            закрытьToolStripMenuItem.Size = new Size(230, 22);
            закрытьToolStripMenuItem.Text = "Закрыть";
            закрытьToolStripMenuItem.Click += закрытьToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Простой RTF-редактор";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьвформатеRTFToolStripMenuItem;
        private ToolStripMenuItem открытьВФорматеWin1251ToolStripMenuItem;
        private ToolStripMenuItem сохранитьВФорматеRTFToolStripMenuItem;
        private ToolStripMenuItem закрытьToolStripMenuItem;
    }
}
