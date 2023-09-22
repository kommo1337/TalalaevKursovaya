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
    /// Логика взаимодействия для AddReklamaTypePage.xaml
    /// </summary>
    public partial class AddReklamaTypePage : Page
    {
        public AddReklamaTypePage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().ReklamaType.Add(new ReklamaType()
                {
                   ReklamaTypeName = ReklamaTypeTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Тип рекламы успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}
