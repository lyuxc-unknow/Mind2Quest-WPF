using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mind2Quest_WPF
{
    /// <summary>
    /// JsonDataWindow.xaml 的交互逻辑
    /// </summary>
    public partial class JsonDataWindow : Window
    {
        public JsonDataWindow(string filePath)
        {
            InitializeComponent();
            LoadJsonData(filePath);
        }
        private void LoadJsonData(string filePath)
        {
            if (File.Exists(filePath))
            {
                // 读取并解析JSON文件
                string jsonData = File.ReadAllText(filePath);
                dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

                // 填充标题、描述和奖励
                titleLabel.Text = "任务标题：" + jsonObject.title;
                frontload.Text = "前置任务：" + jsonObject.frontload;
                requestLabel.Text = "任务要求：" + jsonObject.request;
                descriptionLabel.Text = "任务描述：" + jsonObject.description;
                //rewardLabel.Text = jsonObject.reward;
            }
            else
            {
                MessageBox.Show("读取到的文件正在被别的程序使用中....");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(Owner != null)
            {
                Owner.Focus();
            }
        }
    }
}
