using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для DocumentsWindow.xaml
    /// </summary>
    public partial class DocumentsWindow : Window
    {
        public class File
        {
            public string IconPath { get; set; }
            public string FileName { get; set; }
            public string FullPath { get; set; }
        }

        private string pathToFileFolder = "./Documents/";

        public DocumentsWindow()
        {
            InitializeComponent();
            // Получение списка файлов .pdf
            string[] files = Directory.GetFiles(pathToFileFolder);

            // Заполнение выпадающего списка именами файлов
            foreach (string file in files)
            {
                // Здесь вам нужно указать путь к иконке соответствующему файлу
                string iconPath = "/Resourses/doc_icon.png";
                pdfFileList.Items.Add(new File
                {
                    FileName = new FileInfo(file).Name,
                    FullPath = file,
                    IconPath = iconPath
                });
            }
        }

        private void OpenPDFButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный файл
            File selectedFile = ((Button)sender).DataContext as File;

            // Запускаем процесс открытия файла
            Process process = new Process();
            process.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(selectedFile.FullPath);
            process.StartInfo.FileName = selectedFile.FileName; ;

            try
            {
                // Пытаемся открыть файл
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть файл: " + ex.Message);
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

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            if (App.IsUserAdmin)
            {
                WindowForAdmin adminWindow = new WindowForAdmin();
                adminWindow.Show();
            }
            else
            {
                MainMenuWindow mainWindow = new MainMenuWindow();
                mainWindow.Show();
            }
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

        //private void OpenPDFButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Получение выбранного файла
        //    File selectedFile = ((Button)sender).DataContext as File;


        //    // Запускаем процесс открытия файла
        //    Process process = new Process();
        //    process.StartInfo.UseShellExecute = true;
        //    process.StartInfo.FileName = selectedFile.FullPath;

        //    try
        //    {
        //        // Пытаемся открыть файл
        //        process.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Не удалось открыть файл: " + ex.Message);
        //    }

            //    // Получение выбранного файла
            //    string selectedFile = (string)pdfFileList.SelectedItem;

            //    if (string.IsNullOrEmpty(selectedFile))
            //    {
            //        // Пользователь не выбрал файл
            //        System.Windows.MessageBox.Show("Пожалуйста, выберите файл для открытия.");
            //        return;
            //    }

            //    // Определение полного пути к выбранному файлу
            //    var resourcePath = System.IO.Path.Combine(pathToFileFolder, selectedFile);

            //    // Создание нового процесса для открытия файла
            //    Process process = new Process();
            //    process.StartInfo.UseShellExecute = true;
            //    process.StartInfo.FileName = resourcePath;

            //    try
            //    {
            //        // Пробуем открыть файл
            //        process.Start();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.MessageBox.Show("Не удалось открыть файл: " + ex.Message);
            //    }
            //}


            //private void Example_Click(object sender, RoutedEventArgs e)
            //{
            //    string pdfFileName = "po_sohraneniu_bioraznoobraziya.pdf";

            //    string pathToFileFolder = @"C:\Users\2-PC\Desktop\TaskManagerWPF\TaskManagerWPF\Resourses\Documents";

            //    // Определение полного пути к файлу
            //    var resourcePath = System.IO.Path.Combine(pathToFileFolder, pdfFileName);

            //    // Проверка существования файла
            //    if (!File.Exists(resourcePath))
            //    {
            //        System.Windows.MessageBox.Show("Файл отсутствует: " + resourcePath);
            //        return;
            //    }

            //    // Создание нового процесса для открытия файла
            //    Process process = new Process();

            //    process.StartInfo.UseShellExecute = true;
            //    process.StartInfo.FileName = resourcePath;

            //    try
            //    {
            //        // Пробуем открыть файл
            //        process.Start();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.MessageBox.Show("Не удалось открыть файл: " + ex.Message);
            //    }
            //}
        }


    }

