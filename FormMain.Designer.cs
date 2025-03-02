namespace MagicalAPIWand
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
            button3 = new Button();
            button2 = new Button();
            tabControl_api = new TabControl();
            tabPage1 = new TabPage();
            richTextBox_api_data = new RichTextBox();
            tabPage2 = new TabPage();
            textBox_api_fn5 = new TextBox();
            textBox_api_fn3 = new TextBox();
            textBox_api_fn4 = new TextBox();
            textBox_api_fn2 = new TextBox();
            textBox_api_fn1 = new TextBox();
            textBox_api_fv5 = new TextBox();
            textBox_api_fv4 = new TextBox();
            textBox_api_fv3 = new TextBox();
            textBox_api_fv2 = new TextBox();
            textBox_api_fv1 = new TextBox();
            textBox_api_url = new TextBox();
            label_msg = new Label();
            comboBox_api_method = new ComboBox();
            button4 = new Button();
            label3 = new Label();
            label_data_count = new Label();
            button_api_data_impot = new Button();
            button_api_start = new Button();
            button1 = new Button();
            label2 = new Label();
            textBox_api_address = new TextBox();
            label1 = new Label();
            flowLayoutPanel_TaskContainer = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl_api.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            configToolStripMenuItem.Click += configToolStripMenuItem_Click;
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
            ownerToolStripMenuItem.Size = new Size(270, 34);
            ownerToolStripMenuItem.Text = "Owner";
            ownerToolStripMenuItem.Click += ownerToolStripMenuItem_Click;
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
            splitContainer1.SplitterDistance = 297;
            splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(tabControl_api);
            groupBox1.Controls.Add(textBox_api_url);
            groupBox1.Controls.Add(label_msg);
            groupBox1.Controls.Add(comboBox_api_method);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label_data_count);
            groupBox1.Controls.Add(button_api_data_impot);
            groupBox1.Controls.Add(button_api_start);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_api_address);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1686, 297);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Api Info";
            // 
            // button3
            // 
            button3.Location = new Point(1230, 257);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 18;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(1348, 257);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 17;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // tabControl_api
            // 
            tabControl_api.Controls.Add(tabPage1);
            tabControl_api.Controls.Add(tabPage2);
            tabControl_api.Location = new Point(130, 77);
            tabControl_api.Multiline = true;
            tabControl_api.Name = "tabControl_api";
            tabControl_api.SelectedIndex = 0;
            tabControl_api.Size = new Size(1544, 174);
            tabControl_api.TabIndex = 16;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox_api_data);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1536, 137);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "JSON";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox_api_data
            // 
            richTextBox_api_data.BorderStyle = BorderStyle.FixedSingle;
            richTextBox_api_data.Dock = DockStyle.Fill;
            richTextBox_api_data.Location = new Point(3, 3);
            richTextBox_api_data.Name = "richTextBox_api_data";
            richTextBox_api_data.Size = new Size(1530, 131);
            richTextBox_api_data.TabIndex = 9;
            richTextBox_api_data.Text = "{\n  \"soid\": \"{{soid}}\",\n  \"createtime\":\"{{createtime}}\",\n  \"usersysno\": {{usersysno}},\n  \"username\":\"{{username}}\"\n}";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox_api_fn5);
            tabPage2.Controls.Add(textBox_api_fn3);
            tabPage2.Controls.Add(textBox_api_fn4);
            tabPage2.Controls.Add(textBox_api_fn2);
            tabPage2.Controls.Add(textBox_api_fn1);
            tabPage2.Controls.Add(textBox_api_fv5);
            tabPage2.Controls.Add(textBox_api_fv4);
            tabPage2.Controls.Add(textBox_api_fv3);
            tabPage2.Controls.Add(textBox_api_fv2);
            tabPage2.Controls.Add(textBox_api_fv1);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1536, 137);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "FormData";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_api_fn5
            // 
            textBox_api_fn5.Location = new Point(734, 98);
            textBox_api_fn5.Name = "textBox_api_fn5";
            textBox_api_fn5.Size = new Size(153, 30);
            textBox_api_fn5.TabIndex = 16;
            // 
            // textBox_api_fn3
            // 
            textBox_api_fn3.Location = new Point(734, 56);
            textBox_api_fn3.Name = "textBox_api_fn3";
            textBox_api_fn3.Size = new Size(153, 30);
            textBox_api_fn3.TabIndex = 15;
            textBox_api_fn3.Text = "usersysno";
            // 
            // textBox_api_fn4
            // 
            textBox_api_fn4.Location = new Point(6, 101);
            textBox_api_fn4.Name = "textBox_api_fn4";
            textBox_api_fn4.Size = new Size(153, 30);
            textBox_api_fn4.TabIndex = 14;
            textBox_api_fn4.Text = "username";
            // 
            // textBox_api_fn2
            // 
            textBox_api_fn2.Location = new Point(6, 59);
            textBox_api_fn2.Name = "textBox_api_fn2";
            textBox_api_fn2.Size = new Size(153, 30);
            textBox_api_fn2.TabIndex = 13;
            textBox_api_fn2.Text = "createtime";
            // 
            // textBox_api_fn1
            // 
            textBox_api_fn1.Location = new Point(6, 15);
            textBox_api_fn1.Name = "textBox_api_fn1";
            textBox_api_fn1.Size = new Size(153, 30);
            textBox_api_fn1.TabIndex = 12;
            textBox_api_fn1.Text = "soid";
            // 
            // textBox_api_fv5
            // 
            textBox_api_fv5.Location = new Point(893, 98);
            textBox_api_fv5.Name = "textBox_api_fv5";
            textBox_api_fv5.Size = new Size(623, 30);
            textBox_api_fv5.TabIndex = 11;
            // 
            // textBox_api_fv4
            // 
            textBox_api_fv4.Location = new Point(165, 101);
            textBox_api_fv4.Name = "textBox_api_fv4";
            textBox_api_fv4.Size = new Size(543, 30);
            textBox_api_fv4.TabIndex = 9;
            textBox_api_fv4.Text = "asdasdasd";
            // 
            // textBox_api_fv3
            // 
            textBox_api_fv3.Location = new Point(893, 56);
            textBox_api_fv3.Name = "textBox_api_fv3";
            textBox_api_fv3.Size = new Size(623, 30);
            textBox_api_fv3.TabIndex = 7;
            textBox_api_fv3.Text = "232323";
            // 
            // textBox_api_fv2
            // 
            textBox_api_fv2.Location = new Point(165, 56);
            textBox_api_fv2.Name = "textBox_api_fv2";
            textBox_api_fv2.Size = new Size(543, 30);
            textBox_api_fv2.TabIndex = 5;
            textBox_api_fv2.Text = "2025-02-03";
            // 
            // textBox_api_fv1
            // 
            textBox_api_fv1.Location = new Point(165, 15);
            textBox_api_fv1.Name = "textBox_api_fv1";
            textBox_api_fv1.Size = new Size(1351, 30);
            textBox_api_fv1.TabIndex = 1;
            textBox_api_fv1.Text = "{{soid}}";
            // 
            // textBox_api_url
            // 
            textBox_api_url.Location = new Point(608, 41);
            textBox_api_url.Name = "textBox_api_url";
            textBox_api_url.Size = new Size(578, 30);
            textBox_api_url.TabIndex = 15;
            textBox_api_url.Text = "/test/json";
            // 
            // label_msg
            // 
            label_msg.AutoSize = true;
            label_msg.ForeColor = Color.Red;
            label_msg.Location = new Point(1328, 47);
            label_msg.Name = "label_msg";
            label_msg.Size = new Size(48, 24);
            label_msg.TabIndex = 14;
            label_msg.Text = "Msg";
            // 
            // comboBox_api_method
            // 
            comboBox_api_method.FormattingEnabled = true;
            comboBox_api_method.Items.AddRange(new object[] { "POST", "GET", "PUT", "DELETE" });
            comboBox_api_method.Location = new Point(130, 39);
            comboBox_api_method.Name = "comboBox_api_method";
            comboBox_api_method.Size = new Size(141, 32);
            comboBox_api_method.TabIndex = 13;
            // 
            // button4
            // 
            button4.Location = new Point(1466, 257);
            button4.Name = "button4";
            button4.Size = new Size(104, 34);
            button4.TabIndex = 5;
            button4.Text = "OpenLog";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 262);
            label3.Name = "label3";
            label3.Size = new Size(333, 24);
            label3.TabIndex = 12;
            label3.Text = "Desc: Use Import Data {{datacolumn}}";
            // 
            // label_data_count
            // 
            label_data_count.AutoSize = true;
            label_data_count.Location = new Point(18, 175);
            label_data_count.Name = "label_data_count";
            label_data_count.Size = new Size(79, 24);
            label_data_count.TabIndex = 11;
            label_data_count.Text = "Data (0)";
            // 
            // button_api_data_impot
            // 
            button_api_data_impot.Location = new Point(12, 136);
            button_api_data_impot.Name = "button_api_data_impot";
            button_api_data_impot.Size = new Size(90, 34);
            button_api_data_impot.TabIndex = 10;
            button_api_data_impot.Text = "Import";
            button_api_data_impot.UseVisualStyleBackColor = true;
            button_api_data_impot.Click += button3_Click;
            // 
            // button_api_start
            // 
            button_api_start.Location = new Point(1192, 41);
            button_api_start.Name = "button_api_start";
            button_api_start.Size = new Size(112, 34);
            button_api_start.TabIndex = 9;
            button_api_start.Text = "Start";
            button_api_start.UseVisualStyleBackColor = true;
            button_api_start.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1576, 257);
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
            label2.Location = new Point(14, 93);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 2;
            label2.Text = "ApiData";
            // 
            // textBox_api_address
            // 
            textBox_api_address.Location = new Point(277, 41);
            textBox_api_address.Name = "textBox_api_address";
            textBox_api_address.Size = new Size(325, 30);
            textBox_api_address.TabIndex = 1;
            textBox_api_address.Text = "http://localhost:5034";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 42);
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
            flowLayoutPanel_TaskContainer.Size = new Size(1686, 637);
            flowLayoutPanel_TaskContainer.TabIndex = 0;
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
            tabControl_api.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
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
        private Button button1;
        private Label label2;
        private TextBox textBox_api_address;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel_TaskContainer;
        private Button button_api_start;
        private Button button_api_data_impot;
        private Label label_data_count;
        private Label label3;
        private Button button4;
        private ComboBox comboBox_api_method;
        private Label label_msg;
        private TextBox textBox_api_url;
        private TabControl tabControl_api;
        private TabPage tabPage1;
        private RichTextBox richTextBox_api_data;
        private TabPage tabPage2;
        private TextBox textBox_api_fn5;
        private TextBox textBox_api_fn3;
        private TextBox textBox_api_fn4;
        private TextBox textBox_api_fn2;
        private TextBox textBox_api_fn1;
        private TextBox textBox_api_fv5;
        private TextBox textBox_api_fv4;
        private TextBox textBox_api_fv3;
        private TextBox textBox_api_fv2;
        private TextBox textBox_api_fv1;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private Button button2;
        private Button button3;
    }
}
