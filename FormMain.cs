using Newtonsoft.Json;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicalAPIWand
{
    public partial class FormMain : Form
    {

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


        private void UpdateRichTextBox(int num, RichTextBox groupBox, string text)
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

                //// ��UI�߳���ֱ�Ӳ���
                //if (richTextBox.Text.Length > AppConfig.MaxTaskMsgLength)
                //{
                //    // ���浽��־�ļ�
                //    SaveLogToFile(num, richTextBox.Text);
                //    // ����ı���
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

        public async Task WorkAsync(Action<int, List<object>> func)
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
                    // �������б��е�����
                    func(taskIndex + 1, chunks[taskIndex]);
                }));
            }

            // �ȴ������������ 
            await Task.WhenAll(tasks);
            MessageBox.Show("Work Done");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await WorkAsync(ExecuteTaskAsync);
        }

        private void ExecuteTaskAsync(int taskNumber, List<object> data)
        {
            // ��ȡ��Ӧ��GroupBox
            GroupBox groupBox = (GroupBox)this.flowLayoutPanel_TaskContainer.Controls[taskNumber - 1];

            // ģ������ִ�У��ں�̨�߳������У�
            foreach (var item in data)
            {
                // ģ������ִ��ʱ��
                Task.Delay(1000).Wait(); // ʹ��Task.Delay������Thread.Sleep

                // ����UI���л���UI�̣߳�
                if (groupBox.InvokeRequired)
                {
                    groupBox.Invoke(new Action(() =>
                    {
                        UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(item));
                    }));
                }
                else
                {
                    UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(item));
                }
            }

            // ������ɣ��л���UI�̣߳�
            if (groupBox.InvokeRequired)
            {
                groupBox.Invoke(new Action(() =>
                {
                    UpdateRichTextBox(taskNumber, groupBox, "�������");
                }));
            }
            else
            {
                UpdateRichTextBox(taskNumber, groupBox, "�������");
            }
        }

        private void ExecuteTaskOnUIThread(int taskNumber, List<object> data, GroupBox groupBox)
        {
            // ��ȡRichTextBox
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];

            // ģ������ִ��
            for (int i = 0; i < data.Count; i++)
            {
                richTextBox.AppendText($"Task {taskNumber} - ���� {JsonConvert.SerializeObject(data[i])}{Environment.NewLine}");
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.ScrollToCaret();

                // ģ������ִ��ʱ��
                Thread.Sleep(1000); // ע�⣺����ʹ��Thread.Sleep������Task.Delay
            }

            richTextBox.AppendText($"Task {taskNumber} �������{Environment.NewLine}");
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
