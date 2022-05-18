using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace FileManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog open = new OpenFileDialog();
       
        public MainWindow()
        {
            InitializeComponent();
          
        }     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (open.ShowDialog() == true)  //Срабатывает, если был выбран файл в FileDialog
            {
                if (File.ReadAllText(open.FileName).Length == 0) // Не будет добавлять файл, если он пуст
                {
                }
                else
                {
                    Button image = new Button();
                    string[] filePath = open.FileName.Split('\\');
                    string filename = "";
                    for (int g = 0; g < filePath.Count(); g++)
                    {
                        if (g == filePath.Count() - 1)
                        {
                            filename = filePath[g];
                            if (filename.Contains("doc"))
                            {
                                image.Content = "🖿";
                               
                            }
                            if (filename.Contains("sql"))
                            {
                                image.Content = "Ⓢ";
                            }
                            if (filename.Contains("mp4"))
                            {
                                image.Content = "🎞";
                            }
                            if (filename.Contains("jpg"))
                            {
                                image.Content = "🖼";
                            }
                            if (filename.Contains("jpeg"))
                            {
                                image.Content = "🖼";
                            }
                            if (filename.Contains("png"))
                            {
                                image.Content = "🖼";
                            }
                            if (filename.Contains("mp3"))
                            {
                                image.Content = "𝄞";
                            }
                        }
                    }
                    image.ToolTip = open.FileName.ToString();
                    image.Background = Brushes.LightBlue;
                    image.FontSize = 16;
                    image.Height = 40;
                    image.Width = 55;
                    image.MouseRightButtonDown += delete;
                    image.Click += path;

                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;

                    TextBlock text = new TextBlock();
                    text.FontSize = 20;
                    text.Width = 100;
                    text.MaxWidth = 100;
                    text.Text = filename;

                    Grid grid = new Grid();
                    grid.Width = 50;

                    Grid grid2 = new Grid();
                    grid2.Width = 50;

                    Grid grid3 = new Grid();
                    grid3.Width = 50;

                    TextBlock text2 = new TextBlock(); // Создаёт текстблок
                    text2.FontSize = 20; // Выставляет текстблоку 20 шрифт
                    text2.Text = open.FileName.ToString(); // Меняет тексблоку текст 
                    text2.Width = 200;
                    text2.ToolTip = open.FileName.ToString();

                    TextBlock text3 = new TextBlock();
                    text3.FontSize = 20;
                    text3.Text = (File.ReadAllText(open.FileName).Length * 1.2).ToString() + "б";

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(grid);
                    stackPanel.Children.Add(text);
                    stackPanel.Children.Add(grid2);
                    stackPanel.Children.Add(text2);
                    stackPanel.Children.Add(grid3);
                    stackPanel.Children.Add(text3);
                    stackPanel.Width = 680;

                    list.Items.Add(stackPanel);
                }
            }
        }

        public void delete(object sender, RoutedEventArgs e)
        {
            var body = sender as Button;
            list.Items.Remove(body);
        }
        public void path(object sender, RoutedEventArgs e)
        {
            var body = sender as Button;
            Process.Start(body.ToolTip.ToString());
        }
      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 dva=new Window1();
            dva.Owner = this;
            dva.Show();
        }

        private void file_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var body = sender as Image;
            Process.Start(body.Source.ToString());
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Пенис");
        }
    }

    
}
    
    

