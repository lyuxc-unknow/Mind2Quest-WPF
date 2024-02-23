using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Mind2Quest_WPF
{
    public partial class JsonFilesWindow : Window
    {
        private string folderPath;
        public JsonFilesWindow(string folderPath)
        {
            InitializeComponent();
            this.folderPath = folderPath;
            LoadJsonFiles();
        }

        private void LoadJsonFiles()
        {
            if (Directory.Exists(folderPath))
            {
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");
                foreach (string jsonFile in jsonFiles)
                {
                    string fileName = Path.GetFileName(jsonFile);
                    fileName = fileName.Replace(".json", "");
                    listBox.Items.Add(fileName);
                }
            }
            else
            {
                MessageBox.Show("The folder does not exist.");
            }
        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedFile = (string)listBox.SelectedItem;
            if (selectedFile != null)
            {
                string filePath = Path.Combine(folderPath, selectedFile);
                ShowJsonDataWindow(selectedFile,filePath);
            }
        }

        private void ShowJsonDataWindow(string name,string filePath)
        {
            JsonDataWindow jsonDataWindow = new JsonDataWindow(filePath + ".json");
            jsonDataWindow.Owner = this;
            jsonDataWindow.Title = name;
            jsonDataWindow.Show();
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
