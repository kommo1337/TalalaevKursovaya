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
                DBEntities.GetContext().Customers.Add(new Customers()
                {
                    FullName = NameTb.Text,
                    BirthDate = DateTime.Parse(BirthDateTb.Text),
                    PhoneNumber= PhoneNumberTb.Text,
                    Email = EmailTb.Text,
                    ReklamaTypeId= index,
                    Date= DateTime.Parse(DateTb.Text)
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Пользователь успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
