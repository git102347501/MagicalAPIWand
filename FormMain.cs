using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicalAPIWand
{
    public partial class FormMain : Form
    {
        
        public FormMain()
        {
            InitializeComponent();
        }

        private delegate void InsertTextDelegate(int num, GroupBox richTextBox, string text);

        private void UpdateRichTextBox(int num, GroupBox groupBox, string text)
        {
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];
            // 如果当前线程不是UI线程，则通过Invoke委托给UI线程
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(UpdateRichTextBox), num, groupBox, text);
            }
            else
            { 
                richTextBox.AppendText(text + Environment.NewLine);
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();

                //// 在UI线程中直接操作
                //if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
                //{
                //    // 保存到日志文件
                //    SaveLogToFile(num, richTextBox.Text);
                //    // 清空文本框
                //    richTextBox.Clear();
                //}
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
            AddTask();
        }

        private void AddTask()
        {

            AppConfig.TaskNum++;
            CreatTaskGroup(AppConfig.TaskNum);
        }


        public static Guid Id { get; set; }

        public void Work(Action<int, List<object>> func)
        {
            if (AppConfig.TaskNum < 1)
            {
                MessageBox.Show("Task Num < 1");
                return;
            }
            Id = Guid.NewGuid();
            // 将数据分割成多个子列表
            var chunks = ImportData.SplitDataIntoChunks(ImportData.Data, AppConfig.TaskNum);

            // 创建任务列表
            List<Task> tasks = new List<Task>();

            // 为每个子列表创建一个任务
            for (int i = 0; i < chunks.Count; i++)
            {
                int taskIndex = i; // 防止闭包问题
                tasks.Add(Task.Run(() =>
                {
                    // 处理子列表中的数据
                    func(taskIndex + 1, chunks[taskIndex]);
                }));
            }

            // 等待所有任务完成
            Task.WaitAll([.. tasks]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Work(ExecuteTaskAsync);
        }

        private void ExecuteTaskAsync(int taskNumber, List<object> data)
        {
            // 获取对应的GroupBox
            GroupBox groupBox = (GroupBox)this.flowLayoutPanel_TaskContainer.Controls[taskNumber - 1];

            // 模拟任务执行（在后台线程中运行）
            foreach (var item in data)
            {
                // 模拟任务执行时间
                Task.Delay(1000).Wait(); // 使用Task.Delay而不是Thread.Sleep

                // 更新UI（切换到UI线程）
                if (groupBox.InvokeRequired)
                {
                    groupBox.Invoke(new Action(() =>
                    {
                        UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data));
                    }));
                }
                else
                {
                    UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data));
                }
            }

            // 任务完成（切换到UI线程）
            if (groupBox.InvokeRequired)
            {
                groupBox.Invoke(new Action(() =>
                {
                    UpdateRichTextBox(taskNumber, groupBox, null);
                }));
            }
            else
            {
                UpdateRichTextBox(taskNumber, groupBox, null);
            }
        } 

        private void ExecuteTaskOnUIThread(int taskNumber, List<object> data, GroupBox groupBox)
        {
            // 获取RichTextBox
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];

            // 模拟任务执行
            for (int i = 0; i < data.Count; i++)
            {
                richTextBox.AppendText($"Task {taskNumber} - 消费 {JsonConvert.SerializeObject(data[i])}{Environment.NewLine}");
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();

                // 模拟任务执行时间
                Thread.Sleep(1000); // 注意：这里使用Thread.Sleep而不是Task.Delay
            }

            richTextBox.AppendText($"Task {taskNumber} 消费完成{Environment.NewLine}");
        }

        private void SaveLogToFile(int num,string logContent)
        {
            // 获取应用程序目录下的Logs文件夹路径
            string logsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            // 如果Logs文件夹不存在，则创建
            if (!Directory.Exists(logsFolder))
            {
                Directory.CreateDirectory(logsFolder);
            }

            string idFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/" + Id);
            // 如果Logs文件夹不存在，则创建
            if (!Directory.Exists(idFolder))
            {
                Directory.CreateDirectory(idFolder);
            }

            // 定义日志文件路径
            string logFilePath = Path.Combine(idFolder, $"task_{num}.log");

            // 将日志内容写入文件
            File.AppendAllText(logFilePath, logContent);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormData form = new FormData();
            form.ShowDialog();
            this.label_data_count.Text = $"Data ({ImportData.Data.Count})";
        }

        private void FormMain_Load(object sender, EventArgs e)
        { 
            AddTask();
        }
    }
}
