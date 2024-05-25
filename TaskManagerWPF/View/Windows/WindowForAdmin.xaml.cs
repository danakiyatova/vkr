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
    /// Логика взаимодействия для WindowForAdmin.xaml
    /// </summary>
    public partial class WindowForAdmin : Window
    {
        public WindowForAdmin()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                //tt_maps.Visibility = Visibility.Collapsed;
                tt_companyInfo.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                //tt_maps.Visibility = Visibility.Visible;
                tt_companyInfo.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите выйти?", "Внимание!",
              MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                base.OnClosed(e);

                Application.Current.Shutdown();
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        //private void ConpanyInfoBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    CompanyInfoWindow companyInfoWindow = new CompanyInfoWindow();
        //    companyInfoWindow.Show();
        //    this.Hide();
        //}

        private void Authorization_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show($"Хотите перейти к авторизации?", "Внимание!",
             MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
            }
            

        }

        private void News_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            NewsWindow newsWindow = new NewsWindow();
            newsWindow.Show();
        }

        private void Documents_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            DocumentsWindow documentsWindow = new DocumentsWindow();
            documentsWindow.Show();
        }

        private void Employees_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            EmployeesWindow employeesWindow = new EmployeesWindow();
            employeesWindow.Show();
        }

        private void Tasks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            TasksWindow tasksWindow = new TasksWindow();
            tasksWindow.Show();
        }

        private void CompanyInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            CompanyInfoWindow companyInfoWindow = new CompanyInfoWindow();
            companyInfoWindow.Show();

        }

        private void Help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            HelpWindow newsWindow = new HelpWindow();
            newsWindow.Show();
        }
    }
}

