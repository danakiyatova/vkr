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
using TaskManagerWPF.ViewModel;

namespace TaskManagerWPF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.DataContext = new AuthorizationViewModel();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var authVM = DataContext as AuthorizationViewModel;
            authVM.Password = password.Password;

            if (await authVM.ValidateUserLoginAndPassword())
            {
                // Проверка на админский логин и пароль        
                if (authVM.Login == "direct" && authVM.Password == "direct")
                {
                    App.IsUserAdmin = true;
                    WindowForAdmin adminWindow = new WindowForAdmin();
                    adminWindow.Show();
                    this.Hide();
                }
                else
                {
                    App.IsUserAdmin = false;
                    MainMenuWindow mainWindow = new MainMenuWindow();
                    mainWindow.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                base.OnMouseLeftButtonDown(e);
                DragMove();
            }
            catch { }
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

