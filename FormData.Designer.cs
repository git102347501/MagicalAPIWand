namespace MagicalAPIWand
{
    partial class FormData
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
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            dataGridView_main = new DataGridView();
            label_Msg = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_main).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label_Msg);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1306, 88);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Opt";
            // 
            // button3
            // 
            button3.Location = new Point(277, 41);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 2;
            button3.Text = "Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(159, 41);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 1;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(41, 41);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Import";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView_main);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1306, 660);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data";
            // 
            // dataGridView_main
            // 
            dataGridView_main.BackgroundColor = SystemColors.Control;
            dataGridView_main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_main.Dock = DockStyle.Fill;
            dataGridView_main.GridColor = SystemColors.InactiveBorder;
            dataGridView_main.Location = new Point(3, 26);
            dataGridView_main.Name = "dataGridView_main";
            dataGridView_main.RowHeadersWidth = 62;
            dataGridView_main.Size = new Size(1300, 631);
            dataGridView_main.TabIndex = 1;
            // 
            // label_Msg
            // 
            label_Msg.AutoSize = true;
            label_Msg.Location = new Point(409, 46);
            label_Msg.Name = "label_Msg";
            label_Msg.Size = new Size(48, 24);
            label_Msg.TabIndex = 3;
            label_Msg.Text = "Msg";
            // 
            // FormData
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 748);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormData";
            Load += FormData_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_main).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView_main;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label_Msg;
    }
}