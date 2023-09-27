using TalalaevKursach.ClassFolder;
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
using TalalaevKursovaya.DataFolder;
using TalalaevKursovaya.ClassFolder;

namespace TalalaevKursach.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().User
                .ToList().OrderBy(u => u.UserName);
        }
      

        private void SearchTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .User.Where(u => u.UserName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.UserName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт пользователей");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            User user = DgUser.SelectedItem as User;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ShowMesagePopup("Выберете пользователя", Application.Current.MainWindow);
            }
            else
            {
                
                    DBEntities.GetContext().User
                        .Remove(DgUser.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                DgUser.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.UserName);
                

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выберете пользователя", Application.Current.MainWindow);

            }
            else
            {
                NavigationService.Navigate(
                    new EditUserPage(DgUser.SelectedItem as User));
            }
        }
    }
}
