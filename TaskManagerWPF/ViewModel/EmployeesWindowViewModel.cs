using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskManagerWPF.Model.Database;
using System.Diagnostics;
using System.Windows.Input;

namespace TaskManagerWPF.ViewModel
{
    internal class EmployeesWindowViewModel : BaseViewModel
    {

        TaskManagerDBEntities db = new TaskManagerDBEntities();

        private ObservableCollection<ModifyEmployeesList> _employeesLists;

        public ObservableCollection<ModifyEmployeesList> EmployeesLists { get => _employeesLists; set => SetPropertyChanged(ref _employeesLists, value); }

        public ICommand EmailHyperlinkCommand { get; private set; }
        public EmployeesWindowViewModel()
        {
            EmployeesLists = new ObservableCollection<ModifyEmployeesList>();

            EmailHyperlinkCommand = new RelayCommand(OpenEmailClient);

            GetEmployeesListInfo();
        }

        public void GetEmployeesListInfo()
        {
            List<ModifyEmployeesList> modifies = new List<ModifyEmployeesList>();

            EmployeesLists.Clear();

            foreach (var item in db.Employee)
            {
                modifies.Add(item);
            }

            foreach (var item in modifies)
            {
                if (item.EmployeeImage != null)
                {
                    item.BitmapImage = (BitmapSource)new ImageSourceConverter().ConvertFrom(item.EmployeeImage);
                }
            }

            foreach (var item in modifies)
            {
                _employeesLists.Add(item);
            }
        }
        private void OpenEmailClient(object obj) // Здесь мы изменили тип аргумента и его приведение к string
        {
            string email = obj as string;
            if (email != null)
            {
                Process.Start(new ProcessStartInfo("mailto:" + email) { UseShellExecute = true });
            }
        }
    }

}
