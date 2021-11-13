using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie_3_Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string font = ((sender as ComboBox).SelectedItem) as string;
            if (textBox1 != null)
            {
                textBox1.FontFamily = new FontFamily(font);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem) as string);
            if (textBox1 != null)
            {
                textBox1.FontSize = fontSize;
            }
        }

        private void OpenFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы | *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы | *.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
            }
        }

        private void SaveFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textBox1.Text!=null && textBox1.Text.Length!=0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void NewFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите очистить содержимое текстового окна?", "Новый файл",
MessageBoxButton.OKCancel,
MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                textBox1.Text = "";
            }
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из приложения?", "Выход из программы",
    MessageBoxButton.OKCancel,
    MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.WindowStyle = WindowStyle.ToolWindow;
            window1.ShowDialog();
        }

        private void Bold_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox1.FontWeight == FontWeights.Normal)
            {
                textBox1.FontWeight = FontWeights.Bold;
                (sender as Button).BorderBrush = Brushes.Blue;
            }
            else
            {
                textBox1.FontWeight = FontWeights.Normal;
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
        }

        private void Italic_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox1.FontStyle == FontStyles.Normal)
            {
                textBox1.FontStyle = FontStyles.Italic;
                (sender as Button).BorderBrush = Brushes.Blue;
            }
            else
            {
                textBox1.FontStyle = FontStyles.Normal;
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
        }

        private void Underline_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox1.TextDecorations != TextDecorations.Underline)
            {
                textBox1.TextDecorations = TextDecorations.Underline;
                (sender as Button).BorderBrush = Brushes.Blue;
            }
            else
            {
                textBox1.TextDecorations = null;
                (sender as Button).BorderBrush = Brushes.Transparent;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox1 != null)
            {
                textBox1.Foreground = Brushes.Red;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox1 != null)
            {
                textBox1.Foreground = Brushes.Black;
            }
        }

        private void SetLightTheme(object sender, ExecutedRoutedEventArgs e)
        {
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        private void SetDarkTheme(object sender, ExecutedRoutedEventArgs e)
        {
            Uri uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
