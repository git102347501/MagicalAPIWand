using Newtonsoft.Json;
using System.Diagnostics; 

namespace MagicalAPIWand
{
    public partial class FormMain : Form
    {
        private string address { get; set; }
        private string url { get; set; }
        private int mode { get; set; }
        private string apidata { get; set; }
        private string method { get; set; }
        private CancellationTokenSource _cts;

        public FormMain()
        {
            InitializeComponent();
        }

        private delegate void InsertTextDelegate(int num, RichTextBox richTextBox, string text);

        private void UpdateRichTextBox(int num, GroupBox groupBox, string text)
        {
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];
            // 如果当前线程不是UI线程，则通过Invoke委托给UI线程
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(UpdateRichTextBox), num, richTextBox, text);
            }
            else
            {
                richTextBox.AppendText(text + Environment.NewLine);
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();

                // 在UI线程中直接操作
                if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
                {
                    // 保存到日志文件
                    SaveLogToFile(num, richTextBox.Text);
                    // 清空文本框
                    richTextBox.Clear();
                }
            }
        }


        private void UpdateRichTextBox(int num, RichTextBox richTextBox, string text)
        { 
            richTextBox.AppendText(text + Environment.NewLine);
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.ScrollToCaret();

            // 在UI线程中直接操作
            if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
            {
                // 保存到日志文件
                SaveLogToFile(num, richTextBox.Text);
                // 清空文本框
                richTextBox.Clear();
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
            containerGroupBox.Width = AppConfig.TaskFormWidth; // 设置宽度
            containerGroupBox.Height = AppConfig.TaskFormHeight; // 设置高度

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


        public static string Id { get; set; }

        public async Task WorkAsync(Action<int, List<object>, CancellationToken> func, CancellationToken cancellationToken)
        {
            if (AppConfig.TaskNum < 1)
            {
                MessageBox.Show("Task Num < 1");
                return;
            }
            Id = DateTime.Now.ToString("yyyyMMddHHmmss");
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
                    func(taskIndex + 1, chunks[taskIndex], cancellationToken);
                }));
            }

            // 等待所有任务完成 
            await Task.WhenAll(tasks); 
        }

        private async void ShowMsg(string message)
        {
            this.label_msg.Text = message;
            // 延迟3秒后清空标签文本
            await Task.Delay(1000);
            this.label_msg.Text = string.Empty;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (this.button_api_start.Text == "Stop")
            {
                _cts.Cancel();
                this.button_api_start.Text = "Start";
                return;
            }
            if (comboBox_api_method.SelectedItem == null)
            {
                ShowMsg("Select Method");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_api_address.Text))
            {
                ShowMsg("Input Address");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_api_url.Text))
            {
                ShowMsg("Input Url");
                return;
            }
            if (!radioButton_mode_json.Checked && !radioButton_mode_form.Checked)
            {
                ShowMsg("Check Mode");
                return;
            }
            this.address = textBox_api_address.Text.Trim();
            this.url = textBox_api_url.Text.Trim();
            this.method = comboBox_api_method.SelectedItem.ToString();
            this.mode = radioButton_mode_json.Checked ? 1 : 2;
            this.apidata = richTextBox_api_data.Text;
            foreach (GroupBox item in this.flowLayoutPanel_TaskContainer.Controls)
            {
                item.Text = Clear(item.Text);
                item.ForeColor = Color.Black;
                RichTextBox richTextBox = (RichTextBox)item.Controls[0];
                richTextBox.Text = "";
            }
            _cts = new CancellationTokenSource();
            await WorkAsync(ExecuteTaskAsync, _cts.Token);
            this.button_api_start.Text = "Stop";
        }

        public string Clear(string val)
        {
            return val.Replace("[Working]", "").Replace("[Error]", "").Replace("[Done]", "");
        }

        private async void ExecuteTaskAsync(int taskNumber, List<object> data, CancellationToken cancellationToken)
        {
            // 获取对应的GroupBox 
            GroupBox groupBox = (GroupBox)this.flowLayoutPanel_TaskContainer.Controls[taskNumber - 1];

            var text = groupBox.Text;
            try
            {
 
                        
                if (groupBox.InvokeRequired)
                {
                    groupBox.Invoke(new Action(() =>
                    {
                        groupBox.Text = text + "[Working]";
                        groupBox.ForeColor = Color.Blue;
                    }));
                }
                else
                {
                    groupBox.Text += text + "[Working]";
                    groupBox.ForeColor = Color.Blue;
                }

                // 模拟任务执行（在后台线程中运行）
                try
                {
                    var http = new HttpHelper();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            UpdateRichTextBox(taskNumber, groupBox, "Tasl Cancel");
                            return;
                        }
                        UpdateRichTextBox(taskNumber, groupBox, "http data:" + JsonConvert.SerializeObject(data[i]));
                        try
                        {
                            var res = await http.SendAsync(address, url, method, mode, apidata, data[i]);
                            UpdateRichTextBox(taskNumber, groupBox, "http res:" + res.StatusCode + " content:" + res.Content);
                        }
                        catch (Exception ex)
                        {
                            UpdateRichTextBox(taskNumber, groupBox, "http error:" + ex.Message);
                        }

                        // 更新UI（切换到UI线程）
                        if (groupBox.InvokeRequired)
                        {
                            groupBox.Invoke(new Action(() =>
                            {
                                UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data[i]));
                            }));
                        }
                        else
                        {
                            UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data[i]));
                        }
                    }

                    // 任务完成（切换到UI线程）
                    if (groupBox.InvokeRequired)
                    {
                        groupBox.Invoke(new Action(() =>
                        {
                            UpdateRichTextBox(taskNumber, groupBox, "Task Work Done");
                            groupBox.ForeColor = Color.Green;
                            groupBox.Text = text + "[Done]";
                        }));
                    }
                    else
                    {
                        UpdateRichTextBox(taskNumber, groupBox, "Task Work Done");
                        groupBox.ForeColor = Color.Green;
                        groupBox.Text = text + "[Done]";
                    }
                }
                catch (Exception ex)
                {
                    if (groupBox.InvokeRequired)
                    {
                        groupBox.Invoke(new Action(() =>
                        {

                            groupBox.Text = text + "[Error]";
                            groupBox.ForeColor = Color.Red;
                        }));
                    }
                    else
                    {

                        groupBox.Text = text + "[Error]";
                        groupBox.ForeColor = Color.Red;
                    }
                    UpdateRichTextBox(taskNumber, groupBox, "Task Work Err:" + ex.Message);
                } 
            }
            catch (OperationCanceledException)
            {
                UpdateRichTextBox(taskNumber, groupBox, "Task Work Cancel");
            } 
        } 

        private void SaveLogToFile(int num, string logContent)
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
            this.label_msg.Text = "";
            this.comboBox_api_method.SelectedIndex = 0;
            AddTask();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 获取应用程序的根目录
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 构造目标目录路径
            string logsDirectory = Path.Combine(appBaseDirectory, "Logs");

            // 如果目录不存在，则创建它
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }

            // 使用 Process.Start 打开文件资源管理器到指定目录
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = logsDirectory
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Open Directory Error：{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
