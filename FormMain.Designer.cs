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
            textBox_api_url = new TextBox();
            label_msg = new Label();
            comboBox_api_method = new ComboBox();
            button4 = new Button();
            label3 = new Label();
            label_data_count = new Label();
            button_api_data_impot = new Button();
            button_api_start = new Button();
            richTextBox_api_data = new RichTextBox();
            radioButton_mode_form = new RadioButton();
            radioButton_mode_json = new RadioButton();
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
            groupBox1.Controls.Add(textBox_api_url);
            groupBox1.Controls.Add(label_msg);
            groupBox1.Controls.Add(comboBox_api_method);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label_data_count);
            groupBox1.Controls.Add(button_api_data_impot);
            groupBox1.Controls.Add(button_api_start);
            groupBox1.Controls.Add(richTextBox_api_data);
            groupBox1.Controls.Add(radioButton_mode_form);
            groupBox1.Controls.Add(radioButton_mode_json);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_api_address);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1686, 270);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Api Info";
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
            button4.Location = new Point(1372, 224);
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
            label3.Location = new Point(130, 229);
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
            // richTextBox_api_data
            // 
            richTextBox_api_data.BorderStyle = BorderStyle.FixedSingle;
            richTextBox_api_data.Location = new Point(130, 79);
            richTextBox_api_data.Name = "richTextBox_api_data";
            richTextBox_api_data.Size = new Size(1446, 139);
            richTextBox_api_data.TabIndex = 8;
            richTextBox_api_data.Text = "{\n  \"soid\": \"{{soid}}\",\n  \"createtime\":\"{{createtime}}\",\n  \"usersysno\": {{usersysno}},\n  \"username\":\"{{username}}\"\n}";
            // 
            // radioButton_mode_form
            // 
            radioButton_mode_form.AutoSize = true;
            radioButton_mode_form.Location = new Point(1591, 136);
            radioButton_mode_form.Name = "radioButton_mode_form";
            radioButton_mode_form.Size = new Size(76, 28);
            radioButton_mode_form.TabIndex = 6;
            radioButton_mode_form.Text = "form";
            radioButton_mode_form.UseVisualStyleBackColor = true;
            // 
            // radioButton_mode_json
            // 
            radioButton_mode_json.AutoSize = true;
            radioButton_mode_json.Checked = true;
            radioButton_mode_json.Location = new Point(1591, 102);
            radioButton_mode_json.Name = "radioButton_mode_json";
            radioButton_mode_json.Size = new Size(72, 28);
            radioButton_mode_json.TabIndex = 5;
            radioButton_mode_json.TabStop = true;
            radioButton_mode_json.Text = "Json";
            radioButton_mode_json.UseVisualStyleBackColor = true;
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
            flowLayoutPanel_TaskContainer.Size = new Size(1686, 664);
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
        private RichTextBox richTextBox_api_data;
        private RadioButton radioButton_mode_form;
        private RadioButton radioButton_mode_json;
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
    }
}
