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
            // �����ǰ�̲߳���UI�̣߳���ͨ��Invokeί�и�UI�߳�
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(UpdateRichTextBox), num, groupBox, text);
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
            containerGroupBox.Width = 200; // ���ÿ��
            containerGroupBox.Height = 150; // ���ø߶�

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


        public static Guid Id { get; set; }

        public void Work(Action<int, List<object>> func)
        {
            if (AppConfig.TaskNum < 1)
            {
                MessageBox.Show("Task Num < 1");
                return;
            }
            Id = Guid.NewGuid();
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
            Task.WaitAll([.. tasks]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Work(ExecuteTaskAsync);
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
                        UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data));
                    }));
                }
                else
                {
                    UpdateRichTextBox(taskNumber, groupBox, JsonConvert.SerializeObject(data));
                }
            }

            // ������ɣ��л���UI�̣߳�
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

        private void SaveLogToFile(int num,string logContent)
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
    }
}
