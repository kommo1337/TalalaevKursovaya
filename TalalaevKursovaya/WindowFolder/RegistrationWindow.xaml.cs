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
using TalalaevKursovaya.ClassFolder;
using TalalaevKursovaya.DataFolder;

namespace TalalaevKursovaya.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().User.Add(new User()
                {
                    FIO = FirstNameTB.Text,
                    DateOfBirth = DateTime.Parse(BirthDateTB.Text),
                    Adress = BirthDateTB.Text,
                    UserName = LoginTB.Text,
                    UserPassword = PasswordTB.Text,
                    RoleId = 1
                });
                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Вы успешно зарегистрировались");
                new AuthorizationWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AuthorizationWindow().Show();
        }
    }
}
