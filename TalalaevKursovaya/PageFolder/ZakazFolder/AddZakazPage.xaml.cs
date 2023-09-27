using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using TalalaevKursovaya.ClassFolder;
using TalalaevKursovaya.DataFolder;

namespace TalalaevKursovaya.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для AddZakazPage.xaml
    /// </summary>
    public partial class AddZakazPage : Page
    {
        public AddZakazPage()
        {
            InitializeComponent();
            ReklamaTypeCb.ItemsSource = DBEntities.GetContext()
                .ReklamaType.ToList();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = ReklamaTypeCb.SelectedIndex + 1;
                int price = GetPriceForReklamaType(index);
                DBEntities.GetContext().Customers.Add(new Customers()
                {
                    FullName = NameTb.Text,
                    BirthDate = (DateTime)DateBirthPick.SelectedDate,
                    PhoneNumber= PhoneNumberTb.Text,
                    Email = EmailTb.Text,
                    ReklamaTypeId = index,
                    Date= (DateTime)DateZakazPick.SelectedDate,
                    Price= price
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);



            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                
            }
        }

        private int GetPriceForReklamaType(int reklamaTypeId)
        {
            int price = 0;

            switch (reklamaTypeId)
            {
                case 1:
                    price = 100; 
                    break;
                case 2:
                    price = 150; 
                    break;
                case 3:
                    price = 200; 
                    break;
                
                default:
                    price = 0; 
                    break;
            }

            return price;
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
