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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TalalaevKursach.ClassFolder;
using TalalaevKursach.PageFolder.AdminFolder;
using TalalaevKursovaya.ClassFolder;
using TalalaevKursovaya.DataFolder;

namespace TalalaevKursovaya.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для ListZakazPage.xaml
    /// </summary>
    public partial class ListZakazPage : Page
    {
        public ListZakazPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Customers.
                ToList().OrderBy(u => u.CustomerId);
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = DgUser.SelectedItem as Customers;
            if (DgUser.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выбирете пользователя", Application.Current.MainWindow);

            }
            else
            {
                
                
                    DBEntities.GetContext().Customers
                        .Remove(DgUser.SelectedItem as Customers);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Customers.ToList().OrderBy(u => u.CustomerId);
                

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выбиерите заказ", Application.Current.MainWindow);

            }
            else
            {
                NavigationService.Navigate(
                    new EditZakazPage(DgUser.SelectedItem as Customers));
            }
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт заказ");
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Customers.Where(u => u.FullName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.FullName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Выберите данные", Application.Current.MainWindow);

            }
        }
    }
}
