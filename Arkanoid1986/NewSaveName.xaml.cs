using System;
using System.Collections.Generic;
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
                SaveName = TextBoxFileName.Text+".dat";
                this.DialogResult = true;
            }
        }
    }
}
