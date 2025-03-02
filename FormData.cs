using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicalAPIWand
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打开文件对话框，选择Excel文件
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Select an Excel file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 读取Excel文件内容
                List<Dictionary<string, object>> data = ReadExcelFile(filePath);

                // 将数据绑定到DataGridView
                BindDataToDataGridView(data);
            }
        }

        private List<Dictionary<string, object>> ReadExcelFile(string filePath)
        {
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();

            // 使用EPPlus读取Excel文件
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // 获取第一个工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // 获取表头（第一行）
                int headerRow = 1;
                int rowCount = worksheet.Dimension?.Rows ?? 0;
                int colCount = worksheet.Dimension?.Columns ?? 0;

                if (rowCount < 2) // 至少需要两行（表头和一行数据）
                {
                    MessageBox.Show("Excel file does not contain enough data.");
                    return dataList;
                }

                // 读取表头
                List<string> headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add(worksheet.Cells[headerRow, col].Text);
                }

                // 读取数据行
                for (int row = 2; row <= rowCount; row++)
                {
                    Dictionary<string, object> rowDict = new Dictionary<string, object>();
                    for (int col = 1; col <= colCount; col++)
                    {
                        string header = headers[col - 1];
                        object cellValue = worksheet.Cells[row, col].Value;
                        rowDict[header] = cellValue ?? string.Empty; // 如果单元格为空，使用空字符串
                    }
                    dataList.Add(rowDict);
                }
            }

            return dataList;
        }

        private void BindDataToDataGridView(List<Dictionary<string, object>> data)
        {
            // 清空DataGridView
            dataGridView_main.Rows.Clear();
            dataGridView_main.Columns.Clear();

            if (data.Count == 0)
            {
                MessageBox.Show("No data to display.");
                return;
            }

            // 获取表头
            List<string> headers = new List<string>(data[0].Keys);

            // 动态创建列
            foreach (var header in headers)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    Name = header,
                    HeaderText = header
                };
                dataGridView_main.Columns.Add(column);
            }

            // 添加数据行
            foreach (var row in data)
            {
                object[] rowData = new object[headers.Count];
                for (int i = 0; i < headers.Count; i++)
                {
                    rowData[i] = row[headers[i]];
                }
                dataGridView_main.Rows.Add(rowData);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 清空所有行
            dataGridView_main.Rows.Clear(); 
            // 清空所有列
            dataGridView_main.Columns.Clear();

            ShowMsg("Clear Success");
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            if (ImportData.Data != null && ImportData.Data.Count > 0)
            {
                RestoreDataGridViewFromImportData();
            }
            this.label_Msg.Text = ""; 
        }

        private void RestoreDataGridViewFromImportData()
        {
            // 清空DataGridView
            dataGridView_main.Rows.Clear();
            dataGridView_main.Columns.Clear();

            if (ImportData.Data.Count == 0)
            {
                MessageBox.Show("No data in ImportData.Data to restore.");
                return;
            }

            // 获取表头（假设所有行的列名相同）
            var firstRow = ImportData.Data[0] as Dictionary<string, object>;
            if (firstRow == null)
            {
                MessageBox.Show("Invalid data format in ImportData.Data.");
                return;
            }

            // 动态创建列
            foreach (var key in firstRow.Keys)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    Name = key,
                    HeaderText = key
                };
                dataGridView_main.Columns.Add(column);
            }

            // 添加数据行
            foreach (var row in ImportData.Data)
            {
                var rowData = row as Dictionary<string, object>;
                if (rowData == null) continue;

                object[] values = new object[dataGridView_main.Columns.Count];
                for (int i = 0; i < dataGridView_main.Columns.Count; i++)
                {
                    string columnName = dataGridView_main.Columns[i].Name;
                    values[i] = rowData.ContainsKey(columnName) ? rowData[columnName] : string.Empty;
                }
                dataGridView_main.Rows.Add(values);
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 遍历DataGridView的每一行
            ImportData.Data.Clear();
            foreach (DataGridViewRow row in dataGridView_main.Rows)
            {
                if (row.IsNewRow) continue; // 跳过新增行

                Dictionary<string, object> rowData = new Dictionary<string, object>();

                // 遍历每一列
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dataGridView_main.Columns[cell.ColumnIndex].Name;
                    object cellValue = cell.Value ?? string.Empty;
                    rowData[columnName] = cellValue;
                }

                // 将当前行的数据添加到ImportData.Data
                ImportData.Data.Add(rowData);
            }
            ShowMsg("Save Success");
        }

        private async void ShowMsg(string message)
        {
            this.label_Msg.Text = message;
            // 延迟3秒后清空标签文本
            await Task.Delay(1000);
            this.label_Msg.Text = string.Empty;
        } 
    }
} 
