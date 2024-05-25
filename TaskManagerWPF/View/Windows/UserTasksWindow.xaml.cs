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
    /// Логика взаимодействия для UserTasksWindow.xaml
    /// </summary>
    public partial class UserTasksWindow : Window
    {

        TaskManagerDBEntities _db = new TaskManagerDBEntities();
        List<ModifyTasksList> modifyTasksLists = new List<ModifyTasksList>();
        public static DataGrid datagrid;
        public UserTasksWindow()
        {
            InitializeComponent();
            this.DataContext = new Appvm();
            foreach (var item in _db.Task.ToList())
            {
                modifyTasksLists.Add(item);
            }
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = modifyTasksLists;
            datagrid = myDataGrid;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            if (MessageBox.Show($"Вы точно хотите выйти?", "Внимание!",
              MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                base.OnClosed(e);

                Application.Current.Shutdown();
            }
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(myDataGrid, "Печать");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = search_TextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                myDataGrid.ItemsSource = modifyTasksLists;
            }
            else
            {
                var filteredTasks = modifyTasksLists.Where(task =>
                    task != null &&
                    (
                        (task.TaskName != null && task.TaskName.ToLower().Contains(searchText)) ||
                        (task.TaskExecutor != null && task.TaskExecutor.ToLower().Contains(searchText)) ||
                        (task.TaskContext != null && task.TaskContext.ToLower().Contains(searchText)) ||
                        (task.TaskStatusName != null && task.TaskStatusName.ToLower().Contains(searchText)) ||
                        (task.Surname != null && task.Surname.ToLower().Contains(searchText))
                    )
                );

                myDataGrid.ItemsSource = filteredTasks;
            }
        }
    }
}
