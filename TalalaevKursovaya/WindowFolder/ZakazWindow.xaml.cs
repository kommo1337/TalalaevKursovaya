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
using TalalaevKursovaya.PageFolder.ZakazFolder;

namespace TalalaevKursovaya.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazWindow.xaml
    /// </summary>
    public partial class ZakazWindow : Window
    {
        public ZakazWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListZakazPage());

        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListZakazPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddZakazPage());

        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
