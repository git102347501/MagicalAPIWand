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
            // �����ǰ�̲߳���UI�̣߳���ͨ��Invokeί�и�UI�߳�
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(UpdateRichTextBox), num, richTextBox, text);
            }
            else
            {
                richTextBox.AppendText(text + Environment.NewLine);
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();

                // ��UI�߳���ֱ�Ӳ���
                if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
                {
                    // ���浽��־�ļ�
                    SaveLogToFile(num, richTextBox.Text);
                    // ����ı���
                    richTextBox.Clear();
                }
            }
        }


        private void UpdateRichTextBox(int num, RichTextBox richTextBox, string text)
        { 
            richTextBox.AppendText(text + Environment.NewLine);
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.ScrollToCaret();

            // ��UI�߳���ֱ�Ӳ���
            if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
            {
                // ���浽��־�ļ�
                SaveLogToFile(num, richTextBox.Text);
                // ����ı���
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
            containerGroupBox.Width = AppConfig.TaskFormWidth; // ���ÿ��
            containerGroupBox.Height = AppConfig.TaskFormHeight; // ���ø߶�

            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Text = "Task" + num;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None; // ��ѡ�����ر߿�
            richTextBox.BackColor = System.Drawing.SystemColors.Window; // ��ѡ�����ñ�����ɫ

            // ��RichTextBox��ӵ�GroupBox
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
            // �����ݷָ�ɶ�����б�
            var chunks = ImportData.SplitDataIntoChunks(ImportData.Data, AppConfig.TaskNum);

            // ���������б�
            List<Task> tasks = new List<Task>();

            // Ϊÿ�����б���һ������
            for (int i = 0; i < chunks.Count; i++)
            {
                int taskIndex = i; // ��ֹ�հ�����
                tasks.Add(Task.Run(() =>
                {
                    func(taskIndex + 1, chunks[taskIndex], cancellationToken);
                }));
            }

            // �ȴ������������ 
            await Task.WhenAll(tasks); 
        }

        private async void ShowMsg(string message)
        {
            this.label_msg.Text = message;
            // �ӳ�3�����ձ�ǩ�ı�
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
            // ��ȡ��Ӧ��GroupBox 
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

                // ģ������ִ�У��ں�̨�߳������У�
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

                        // ����UI���л���UI�̣߳�
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

                    // ������ɣ��л���UI�̣߳�
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
            // ��ȡӦ�ó���Ŀ¼�µ�Logs�ļ���·��
            string logsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            // ���Logs�ļ��в����ڣ��򴴽�
            if (!Directory.Exists(logsFolder))
            {
                Directory.CreateDirectory(logsFolder);
            }

            string idFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/" + Id);
            // ���Logs�ļ��в����ڣ��򴴽�
            if (!Directory.Exists(idFolder))
            {
                Directory.CreateDirectory(idFolder);
            }

            // ������־�ļ�·��
            string logFilePath = Path.Combine(idFolder, $"task_{num}.log");

            // ����־����д���ļ�
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
            // ��ȡӦ�ó���ĸ�Ŀ¼
            string appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // ����Ŀ��Ŀ¼·��
            string logsDirectory = Path.Combine(appBaseDirectory, "Logs");

            // ���Ŀ¼�����ڣ��򴴽���
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }

            // ʹ�� Process.Start ���ļ���Դ��������ָ��Ŀ¼
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
                MessageBox.Show($"Open Directory Error��{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
