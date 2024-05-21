using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TaskManagerWPF.Model.Database;
using TaskManagerWPF.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;
using System.Data.Entity.Migrations;

namespace TaskManagerWPF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        private TaskManagerDBEntities _db = new TaskManagerDBEntities();


        public EmployeesWindow()
        {
            InitializeComponent();

            DataContext = new EmployeesWindowViewModel();
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

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowForAdmin windowForAdmin = new WindowForAdmin();
            windowForAdmin.Show();
            this.Close();
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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image files (*.png;*.jpeg; *.jpg)|*.png;*.jpeg; *.jpg"
            };

            if (ofd.ShowDialog() == true)
            {
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                // Выбираем сотрудника из базы данных для обновления
                var employeeToUpdate = _db.Employee.FirstOrDefault(x => x.EmployeeID == 3);

                if (employeeToUpdate != null)
                {
                    employeeToUpdate.EmployeeImage = imageData;

                    // Сохраняем изменения
                    _db.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Employee not found");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "";
            ofd.DefaultExt = ".jpeg, .jpg, .png";

            bool? res = ofd.ShowDialog();

            BitmapImage Image = null;

            if (res == true)
            {
                Image = new BitmapImage(new Uri(ofd.FileName));
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();

                byte[] byteImage;

                if (Image == null)
                    Image = new BitmapImage(new Uri("pack://application:,,,/Resources/user.png"));

                encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(Image.UriSource)));

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    encoder.Save(memoryStream);

                    byteImage = memoryStream.ToArray();
                }

               

                Employee employee = new Employee()
                {
                    EmployeeID = 10,
                    Surname = "Сухова",
                    Name = "София",
                    Patronymic = "Дмитриевна",
                    Email = "Sofffia@mail.ru",
                    PhoneNumber = "89187656787",
                    LastLogin = System.DateTime.Now,
                    EmployeeImage = byteImage,
                    JobID = 14
                };
                _db.Employee.AddOrUpdate(employee);
                _db.SaveChangesAsync();

                (DataContext as EmployeesWindowViewModel).GetEmployeesListInfo();
            }
        }
    }
}
