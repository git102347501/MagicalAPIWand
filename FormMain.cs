namespace MagicalAPIWand
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
         
        private delegate void InsertTextDelegate(RichTextBox richTextBox, string text);

        private void InsertText(RichTextBox richTextBox, string text)
        {
            // 如果当前线程不是UI线程，则通过Invoke委托给UI线程
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(InsertText), richTextBox, text);
            }
            else
            {
                // 在UI线程中直接操作
                richTextBox.AppendText(text + Environment.NewLine);
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();
            }
        }

        private void CreatTaskGroup(int num)
        {
            if (this.flowLayoutPanel_TaskContainer.Controls.Count >= num)
            {
                return;
            }
            GroupBox containerGroupBox = new GroupBox();
            containerGroupBox.Text = "Task" + num;
            containerGroupBox.Width = 200; // 设置宽度
            containerGroupBox.Height = 150; // 设置高度

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = "Task" + num;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None; // 可选：隐藏边框
            richTextBox.BackColor = System.Drawing.SystemColors.Window; // 可选：设置背景颜色

            // 将RichTextBox添加到GroupBox
            containerGroupBox.Controls.Add(richTextBox);

            this.flowLayoutPanel_TaskContainer.Controls.Add(containerGroupBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppConfig.TaskNum++; 
            CreatTaskGroup(AppConfig.TaskNum);
        }

        private async void button2_Click(object sender, EventArgs e)
        { 
            // 创建任务组
            for (int i = 1; i <= AppConfig.TaskNum; i++)
            {
                CreatTaskGroup(i);
            }

            // 动态创建任务列表
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= AppConfig.TaskNum; i++)
            {
                tasks.Add(ExecuteTaskAsync(i));
            }

            // 启动所有任务
            await Task.WhenAll(tasks);
        }

        private async Task ExecuteTaskAsync(int taskNumber)
        {
            // 获取对应的RichTextBox
            GroupBox groupBox = (GroupBox)this.flowLayoutPanel_TaskContainer.Controls[taskNumber - 1];
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];

            // 模拟任务执行
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); // 模拟任务执行时间
                InsertText(richTextBox, $"Task {taskNumber} - 消费 {i + 1}");
            }
            InsertText(richTextBox, $"Task {taskNumber} 消费完成");
        }
    }
}
