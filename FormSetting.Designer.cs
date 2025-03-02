namespace MagicalAPIWand
{
    partial class FormSetting
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
            button1 = new Button();
            label1 = new Label();
            textBox_task_num = new TextBox();
            textBox_task_msg_length = new TextBox();
            label2 = new Label();
            textBox_form_width = new TextBox();
            label3 = new Label();
            textBox_form_height = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(347, 274);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 33);
            label1.Name = "label1";
            label1.Size = new Size(96, 24);
            label1.TabIndex = 1;
            label1.Text = "Task Num";
            // 
            // textBox_task_num
            // 
            textBox_task_num.Location = new Point(264, 27);
            textBox_task_num.Name = "textBox_task_num";
            textBox_task_num.Size = new Size(433, 30);
            textBox_task_num.TabIndex = 2;
            // 
            // textBox_task_msg_length
            // 
            textBox_task_msg_length.Location = new Point(264, 75);
            textBox_task_msg_length.Name = "textBox_task_msg_length";
            textBox_task_msg_length.Size = new Size(433, 30);
            textBox_task_msg_length.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 78);
            label2.Name = "label2";
            label2.Size = new Size(198, 24);
            label2.TabIndex = 3;
            label2.Text = "Max Task Msg Length";
            // 
            // textBox_form_width
            // 
            textBox_form_width.Location = new Point(264, 125);
            textBox_form_width.Name = "textBox_form_width";
            textBox_form_width.Size = new Size(433, 30);
            textBox_form_width.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 125);
            label3.Name = "label3";
            label3.Size = new Size(156, 24);
            label3.TabIndex = 5;
            label3.Text = "Task Form Width";
            // 
            // textBox_form_height
            // 
            textBox_form_height.Location = new Point(264, 172);
            textBox_form_height.Name = "textBox_form_height";
            textBox_form_height.Size = new Size(433, 30);
            textBox_form_height.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 175);
            label4.Name = "label4";
            label4.Size = new Size(162, 24);
            label4.TabIndex = 7;
            label4.Text = "Task Form Height";
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 352);
            Controls.Add(textBox_form_height);
            Controls.Add(label4);
            Controls.Add(textBox_form_width);
            Controls.Add(label3);
            Controls.Add(textBox_task_msg_length);
            Controls.Add(label2);
            Controls.Add(textBox_task_num);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSetting";
            Load += FormSetting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox_task_num;
        private TextBox textBox_task_msg_length;
        private Label label2;
        private TextBox textBox_form_width;
        private Label label3;
        private TextBox textBox_form_height;
        private Label label4;
    }
}