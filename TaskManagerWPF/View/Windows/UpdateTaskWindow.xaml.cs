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
using TaskManagerWPF.Model.Database;
using TaskManagerWPF.ViewModel;

namespace TaskManagerWPF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateTaskWindow.xaml
    /// </summary>
    public partial class UpdateTaskWindow : Window
    {

        TaskManagerDBEntities _db = new TaskManagerDBEntities();
        int Id;
        public UpdateTaskWindow(int taskId)
        {
            InitializeComponent();

            updateTaskEmployeeCB.ItemsSource = TaskManagerDBEntities.GetContext().Employee.ToList();
            updateTaskStatusCB.ItemsSource = TaskManagerDBEntities.GetContext().TaskStatus.ToList();
            DataContext = new UpdateTaskWindowViewModel();
            Id = taskId;

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



        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            TasksWindow tasksWindow = new TasksWindow();
            tasksWindow.Show();
            this.Hide();
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

        private void UpdateTask_Click(object sender, RoutedEventArgs e)
        {


            int selectedTaskId = Id; // Проверьте, что Id у вас устанавливается корректно
            Model.Database.Task updateTask = _db.Task.FirstOrDefault(m => m.TaskID == selectedTaskId);

            if (updateTask != null)
            {
                updateTask.TaskName = Convert.ToString(updateTaskName.Text);
                updateTask.TaskExecutor = Convert.ToString(updateTaskExecutorTB.Text);
            updateTask.TaskContext = Convert.ToString(updateTaskContext.Text);
            updateTask.TaskStart = Convert.ToDateTime(updateTaskStart.Text);
            updateTask.TaskEnd = Convert.ToDateTime(updateTaskEnd.Text);
            updateTask.TaskStatusID = Convert.ToInt32((DataContext as UpdateTaskWindowViewModel).Statuses.TaskStatusID);
            updateTask.EmployeeID = Convert.ToInt32((DataContext as UpdateTaskWindowViewModel).Employees.EmployeeID);


            _db.SaveChanges();
            TasksWindow.datagrid.ItemsSource = _db.Task.ToList();
            this.Hide();
            TasksWindow tasksWindow = new TasksWindow();
            tasksWindow.Show();
            }
            else
            {
                // Обработка ситуации, когда задача с указанным Id не найдена
                MessageBox.Show("Задача не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
