using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using Microsoft.VisualBasic.FileIO;

namespace Arkanoid1986
{
    /// <summary>
    /// Логика взаимодействия для SaveLoadGame.xaml
    /// </summary>
    public partial class SaveLoadGame : Window
    {
        public static string NameFile = "";
        public static string OverWrite = "";
        public SaveLoadGame()
        {
            InitializeComponent();
            FillTable();
        }
        void FillTable()
        {
            table.Items.Clear();
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
                    table.Items.Add(System.IO.Path.GetFileNameWithoutExtension(item));
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           NameFile = table.SelectedItem.ToString()+".dat";
           this.DialogResult = true;
        }

        private void table_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NameFile = table.SelectedItem.ToString()+".dat";
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewSaveName newSave = new NewSaveName();
            if (newSave.ShowDialog()==true)
            {
                table.Items.Clear();
                this.DialogResult = true;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OverWrite = table.SelectedItem.ToString() + ".dat";
            this.DialogResult = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("DELETE THIS SAVE:  " + table.SelectedItem.ToString() + "?", "Warning!" ,MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result==MessageBoxResult.Yes)
            {
                string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Arkanoid1986Save\Saves\";
                string fileDel = fullPath + table.SelectedItem.ToString() + ".dat";
                FileSystem.DeleteFile(fileDel, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                table.Items.Remove(table.SelectedItem);
            }
            
        }
    }
}
