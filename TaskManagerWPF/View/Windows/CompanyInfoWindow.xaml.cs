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

namespace TaskManagerWPF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для CompanyInfoWindow.xaml
    /// </summary>
    public partial class CompanyInfoWindow : Window
    {
        public CompanyInfoWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try { 
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
            catch { }
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Hide();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите выйти?", "Внимаение!",
              MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                base.OnClosed(e);

                Application.Current.Shutdown();
            }
        }
    }
}
