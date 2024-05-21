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
    /// Логика взаимодействия для InsertTaskWindow.xaml
    /// </summary>
    public partial class InsertTaskWindow : Window
    {

        private Model.Database.Task _currentTask = new Model.Database.Task();
        public static Grid grid;

        TaskManagerDBEntities _db = new TaskManagerDBEntities();

        public InsertTaskWindow()
        {
            InitializeComponent();
      

            DataContext = _currentTask;
            //TaskEmployeeCB.ItemsSource = TaskManagerDBEntities.GetContext().Employee.ToList();
            //TaskStatusCB.ItemsSource = TaskManagerDBEntities.GetContext().TaskStatus.ToList();

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

        private void InsertTask_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Model.Database.Task newTask = new Model.Database.Task()
                {
                    
                TaskName = InsertTaskName.Text,
                    TaskExecutor = TaskExecutorTB.Text,
                    TaskContext = InsertTaskContext.Text,
                    TaskStart = Convert.ToDateTime(InsertTaskStart.Text),
                    TaskEnd = Convert.ToDateTime(InsertTaskEnd.Text),

                    //TaskStatusID = ((Model.Database.TaskStatus)TaskStatusCB.SelectedItem).TaskStatusID, // Исправлено
                    //EmployeeID = ((Employee)TaskEmployeeCB.SelectedItem).EmployeeID // Исправлено
                };

                string errorMessage = string.Empty;

                // Проверка на null и конвертация в int для TaskStatusCB
                if (TaskStatusCB.SelectedItem != null)
                {
                    newTask.TaskStatusID = ((Model.Database.TaskStatus)TaskStatusCB.SelectedItem).TaskStatusID;
                }
                else
                {
                    errorMessage += "Выберите статус задачи.\n";
                }

                // Проверка на null и конвертация в int для TaskEmployeeCB
                if (TaskEmployeeCB.SelectedItem != null)
                {
                    newTask.EmployeeID = ((Employee)TaskEmployeeCB.SelectedItem).EmployeeID;
                }
                else
                {
                    errorMessage += "Выберите исполнителя задачи.\n";
                }

                // Если есть ошибки, отобразить MessageBox и завершить выполнение метода
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _db.Task.Add(newTask);
                _db.SaveChanges();
                TasksWindow.datagrid.ItemsSource = _db.Task.ToList();
                this.Hide();
              
                TasksWindow tasksWindow = new TasksWindow();
                tasksWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный формат данных", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}