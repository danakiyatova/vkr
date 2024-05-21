using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerWPF.Model.Database;

namespace TaskManagerWPF.ViewModel
{
    public class UpdateTaskWindowViewModel : BaseViewModel
    {
        List<Model.Database.TaskStatus> _taskStatuses;
        Model.Database.TaskStatus _status;

        List<Employee> _employeesList;
        Employee _employee;

        public Model.Database.TaskStatus Statuses { get => _status; set => SetPropertyChanged(ref _status, value); }
        public List<Model.Database.TaskStatus> TaskStatusesList { get => _taskStatuses; set => SetPropertyChanged(ref _taskStatuses, value); }

        public Employee Employees { get => _employee; set => SetPropertyChanged(ref _employee, value); }
        public List<Employee> EmployeesList { get => _employeesList; set => SetPropertyChanged(ref _employeesList, value); }

        public UpdateTaskWindowViewModel()
        {
            TaskStatusesList = new List<Model.Database.TaskStatus>();
            EmployeesList = new List<Employee>();


            using (TaskManagerDBEntities db = new TaskManagerDBEntities())
            {
                foreach (var item in db.TaskStatus)
                {
                    TaskStatusesList.Add(item);
                }

                foreach (var item in db.Employee)
                {
                    EmployeesList.Add(item);
                }


            }
        }
    }
}
