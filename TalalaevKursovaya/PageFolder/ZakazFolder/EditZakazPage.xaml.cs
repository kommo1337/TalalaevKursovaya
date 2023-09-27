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
using TalalaevKursach.PageFolder.AdminFolder;
using TalalaevKursovaya.ClassFolder;
using TalalaevKursovaya.DataFolder;

namespace TalalaevKursovaya.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для EditZakazPage.xaml
    /// </summary>
    public partial class EditZakazPage : Page
    {
        Customers customers = new Customers();
        public EditZakazPage(Customers customers)
        {
            InitializeComponent();
            DataContext = customers;

            this.customers.CustomerId = customers.CustomerId;

            ReklamaTypeCb.ItemsSource = DBEntities.GetContext()
                .ReklamaType.ToList();


        }



        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = ReklamaTypeCb.SelectedIndex + 1;
                customers = DBEntities.GetContext().Customers
                    .FirstOrDefault(u => u.CustomerId == customers.CustomerId);
                customers.FullName = NameTb.Text;
                customers.BirthDate = (DateTime)DateDRPick.SelectedDate;
                customers.PhoneNumber = PhoneNumberTb.Text;
                customers.Email = EmailTb.Text;
                customers.ReklamaTypeId = index;
                customers.Date = (DateTime)DateZakazPick.SelectedDate;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                NavigationService.Navigate(new ListUserPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Customers customers = DBEntities.GetContext().Customers
                    .FirstOrDefault(u => u.CustomerId == u.CustomerId);

                if (customers != null)
                {
                    NameTb.Text = customers.FullName;
                    PhoneNumberTb.Text = customers.PhoneNumber;
                    EmailTb.Text = customers.Email;

                    DateDRPick.SelectedDate = customers.BirthDate;
                    DateZakazPick.SelectedDate = customers.Date;

                    ReklamaTypeCb.SelectedIndex = customers.ReklamaTypeId - 1;
                }
                else
                {
                    MBClass.ShowMesagePopup("Выбирете пользователя", Application.Current.MainWindow);
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }           
    }
}
