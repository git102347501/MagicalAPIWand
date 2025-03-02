﻿namespace MagicalAPIWand
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            settingToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            ownerToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label_data_count = new Label();
            button3 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            flowLayoutPanel_TaskContainer = new FlowLayoutPanel();
            button4 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1686, 32);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configToolStripMenuItem });
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(88, 28);
            settingToolStripMenuItem.Text = "Setting";
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(167, 34);
            configToolStripMenuItem.Text = "Config";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ownerToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(80, 28);
            aboutToolStripMenuItem.Text = "About";
            // 
            // ownerToolStripMenuItem
            // 
            ownerToolStripMenuItem.Name = "ownerToolStripMenuItem";
            ownerToolStripMenuItem.Size = new Size(167, 34);
            ownerToolStripMenuItem.Text = "Owner";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 32);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel_TaskContainer);
            splitContainer1.Size = new Size(1686, 938);
            splitContainer1.SplitterDistance = 270;
            splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label_data_count);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1686, 270);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Api Info";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(161, 231);
            label3.Name = "label3";
            label3.Size = new Size(333, 24);
            label3.TabIndex = 12;
            label3.Text = "Desc: Use Import Data {{datacolumn}}";
            // 
            // label_data_count
            // 
            label_data_count.AutoSize = true;
            label_data_count.Location = new Point(52, 175);
            label_data_count.Name = "label_data_count";
            label_data_count.Size = new Size(79, 24);
            label_data_count.TabIndex = 11;
            label_data_count.Text = "Data (0)";
            // 
            // button3
            // 
            button3.Location = new Point(41, 136);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 10;
            button3.Text = "Import";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1060, 39);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 9;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(159, 79);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1417, 139);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(1591, 136);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(76, 28);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "form";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(1591, 102);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(72, 28);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Json";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1482, 224);
            button1.Name = "button1";
            button1.Size = new Size(94, 34);
            button1.TabIndex = 4;
            button1.Text = "AddTask";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 93);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 2;
            label2.Text = "ApiData";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(884, 30);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 42);
            label1.Name = "label1";
            label1.Size = new Size(110, 24);
            label1.TabIndex = 0;
            label1.Text = "ApiAddress";
            // 
            // flowLayoutPanel_TaskContainer
            // 
            flowLayoutPanel_TaskContainer.AutoScroll = true;
            flowLayoutPanel_TaskContainer.Dock = DockStyle.Fill;
            flowLayoutPanel_TaskContainer.Location = new Point(0, 0);
            flowLayoutPanel_TaskContainer.Name = "flowLayoutPanel_TaskContainer";
            flowLayoutPanel_TaskContainer.Size = new Size(1686, 664);
            flowLayoutPanel_TaskContainer.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(1372, 224);
            button4.Name = "button4";
            button4.Size = new Size(104, 34);
            button4.TabIndex = 5;
            button4.Text = "OpenLog";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1686, 970);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MagicalAPIWand";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem configToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem ownerToolStripMenuItem;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel_TaskContainer;
        private Button button2;
        private Button button3;
        private Label label_data_count;
        private Label label3;
        private Button button4;
    }
}
