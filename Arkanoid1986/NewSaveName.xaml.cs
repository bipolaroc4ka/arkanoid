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

namespace Arkanoid1986
{
    /// <summary>
    /// Логика взаимодействия для NewSaveName.xaml
    /// </summary>
    public partial class NewSaveName : Window
    {
        public static string SaveName = "";
        public NewSaveName()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFileName.Text.Length!=0)
            {
                if (CheckFile(SaveName) ==false)
                {
                    SaveName = TextBoxFileName.Text + ".dat";
                    this.DialogResult = true;
                }
                else
                {
                    MessageBoxResult result =  MessageBox.Show("This save already exists, overwrite it?", "Warning!" ,MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveName = TextBoxFileName.Text + ".dat";
                        this.DialogResult = true;
                    }
                }
                
            }
        }
        bool CheckFile(string name)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save\Saves";
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save");
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save\Saves"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save\Saves");
            }
            DirectoryInfo dir = new DirectoryInfo(fullPath);
            if (dir.Exists)
            {
                string[] FoundFiles = Directory.GetFiles(fullPath, "*.dat");
                foreach (var item in FoundFiles)
                {
                    if (item.Contains(TextBoxFileName.Text + ".dat"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
