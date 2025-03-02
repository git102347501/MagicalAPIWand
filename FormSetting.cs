using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicalAPIWand
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppConfig.TaskNum = int.Parse(this.textBox_task_num.Text);
            AppConfig.MaxTaskMsgLength = int.Parse(this.textBox_task_msg_length.Text);
            AppConfig.TaskFormWidth = int.Parse(this.textBox_form_width.Text);
            AppConfig.TaskFormHeight = int.Parse(this.textBox_form_height.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            this.textBox_task_num.Text = AppConfig.TaskNum.ToString();
            this.textBox_task_msg_length.Text = AppConfig.MaxTaskMsgLength.ToString();
            this.textBox_form_width.Text = AppConfig.TaskFormWidth.ToString();
            this.textBox_form_height.Text = AppConfig.TaskFormHeight.ToString();
        }
    }
}
