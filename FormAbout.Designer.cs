namespace MagicalAPIWand
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            label5 = new Label();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 91);
            label1.Name = "label1";
            label1.Size = new Size(167, 24);
            label1.TabIndex = 0;
            label1.Text = "Github Repository";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(238, 91);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(462, 24);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/git102347501/MagicalAPIWand";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 36);
            label2.Name = "label2";
            label2.Size = new Size(67, 24);
            label2.TabIndex = 2;
            label2.Text = "Owner";
            // 
            // label5
            // 
            label5.Location = new Point(65, 157);
            label5.Name = "label5";
            label5.Size = new Size(648, 91);
            label5.TabIndex = 5;
            label5.Text = "Please comply with the laws in your area and do not use it for any illegal purposes. Any liability arising from personal illegal use is not related to this software";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(138, 36);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(133, 24);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "git102347501";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 276);
            Controls.Add(linkLabel2);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label5;
        private LinkLabel linkLabel2;
    }
}