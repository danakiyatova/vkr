using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskManagerWPF.Model.Database;

namespace TaskManagerWPF.ViewModel
{
    internal class AuthorizationViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
       
        private string _buttonSignIn = "ВОЙТИ";

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string ButtonSignIn
        {
            get => _buttonSignIn;
            set
            {
                _buttonSignIn = value;
                OnPropertyChanged(nameof(ButtonSignIn));
            }
        }

        public async Task<bool> ValidateUserLoginAndPassword()
        {
            try
            {
                ButtonSignIn = "подождите...";
                using (var context = new TaskManagerDBEntities())
                {
                    var user = await context.Authorization.FirstOrDefaultAsync(u => u.Login == _login && u.Password == _password);

                    if (user != null)
                    {
                        var employee = await context.Employee.FirstOrDefaultAsync(e => e.EmployeeID == user.EmployeeID);
                        if (employee != null)
                        {
                            employee.LastLogin = DateTime.Now; // обновить время последнего входа
                            await context.SaveChangesAsync(); // сохранить изменения в базе данных
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка соединения с базой данных", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
            finally
            {
                ButtonSignIn = "ВОЙТИ";
            }
        }
}
}