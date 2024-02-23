using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Mind2Quest_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFolders();
        }
        private void LoadFolders()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "quests");
            if (Directory.Exists(folderPath))
            {
                string[] subDirectories = Directory.GetDirectories(folderPath);
                foreach (string subDir in subDirectories)
                {
                    string folderName = new DirectoryInfo(subDir).Name;
                    AddButton(folderName, subDir);
                }
            }
            else
            {
                MessageBox.Show("quests文件夹正在使用中或未找到");
            }
        }

        private void AddButton(string name, string folderPath)
        {
            Button button = new Button();
            button.Content = name;
            button.Margin = new Thickness(5);
            button.Click += (sender, e) =>
            {
                ShowJsonFilesWindow(name,folderPath);
            };

            stackPanel.Children.Add(button);
        }
        private void ShowJsonFilesWindow(string name,string folderPath)
        {
            JsonFilesWindow jsonFilesWindow = new JsonFilesWindow(folderPath);
            jsonFilesWindow.Owner = this;
            jsonFilesWindow.Title = name;
            jsonFilesWindow.Show();
        }
    }
}