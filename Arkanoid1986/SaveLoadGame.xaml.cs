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

namespace Arkanoid1986
{
    /// <summary>
    /// Логика взаимодействия для SaveLoadGame.xaml
    /// </summary>
    public partial class SaveLoadGame : Window
    {
        public static string NameFile = "";
        public SaveLoadGame()
        {
            InitializeComponent();
            FillTable();
        }
        void FillTable()
        {
            table.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (dir.Exists)
            {
                string[] FoundFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dat");
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
    }
}
