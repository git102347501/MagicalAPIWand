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
            // �����ǰ�̲߳���UI�̣߳���ͨ��Invokeί�и�UI�߳�
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new InsertTextDelegate(InsertText), richTextBox, text);
            }
            else
            {
                // ��UI�߳���ֱ�Ӳ���
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
            AppConfig.TaskNum++; 
            CreatTaskGroup(AppConfig.TaskNum);
        }

        private async void button2_Click(object sender, EventArgs e)
        { 
            // ����������
            for (int i = 1; i <= AppConfig.TaskNum; i++)
            {
                CreatTaskGroup(i);
            }

            // ��̬���������б�
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= AppConfig.TaskNum; i++)
            {
                tasks.Add(ExecuteTaskAsync(i));
            }

            // ������������
            await Task.WhenAll(tasks);
        }

        private async Task ExecuteTaskAsync(int taskNumber)
        {
            // ��ȡ��Ӧ��RichTextBox
            GroupBox groupBox = (GroupBox)this.flowLayoutPanel_TaskContainer.Controls[taskNumber - 1];
            RichTextBox richTextBox = (RichTextBox)groupBox.Controls[0];

            // ģ������ִ��
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); // ģ������ִ��ʱ��
                InsertText(richTextBox, $"Task {taskNumber} - ���� {i + 1}");
            }
            InsertText(richTextBox, $"Task {taskNumber} �������");
        }
    }
}
