namespace HW_018
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
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(36, 49);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(60, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel1";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(36, 120);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(60, 15);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "linkLabel2";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(36, 198);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(60, 15);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "linkLabel3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 280);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
    }
}