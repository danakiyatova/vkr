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
    /// Логика взаимодействия для TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {

        TaskManagerDBEntities _db = new TaskManagerDBEntities();
        List<ModifyTasksList> modifyTasksLists = new List<ModifyTasksList>();
        public static DataGrid datagrid;
        public TasksWindow()
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
            WindowForAdmin windowForAdmin = new WindowForAdmin();
            windowForAdmin.Show();
            this.Close();
        }

        private void insertTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertTaskWindow insertTaskWindow = new InsertTaskWindow();
            insertTaskWindow.Show();
            this.Close();
        }

        private void UpdateTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (myDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите строку.");
                }
                else
                {
                    int Id = (myDataGrid.SelectedItem as ModifyTasksList).TaskID;
                    UpdateTaskWindow updateTaskWindow = new UpdateTaskWindow(Id);
                    this.Close();
                    updateTaskWindow.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var removeTask = myDataGrid.SelectedItem as ModifyTasksList;
            if (removeTask == null)
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Внимание!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (MessageBox.Show($"Вы точно хотите удалить этот элемент?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int Id = removeTask.TaskID;
                        var deleteBooking = _db.Task.Where(m => m.TaskID == Id).Single();
                        _db.Task.Remove(deleteBooking);
                        _db.SaveChanges();
                        myDataGrid.ItemsSource = _db.Task.ToList();
                        MessageBox.Show("Данные удалены.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }

        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog()==true)
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

