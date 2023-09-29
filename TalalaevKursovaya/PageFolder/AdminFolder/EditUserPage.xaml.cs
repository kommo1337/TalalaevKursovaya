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
using TalalaevKursovaya.PageFolder.AdminFolder;

namespace TalalaevKursach.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = new User();
        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;

            this.user.UserId = user.UserId;

            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }



        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = RoleCb.SelectedIndex + 1;
                user = DBEntities.GetContext().User
                    .FirstOrDefault(u => u.UserId == user.UserId);
                user.UserName = UserNameTb.Text;
                user.UserPassword = UserPassortTb.Text;
                user.RoleId = index;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                NavigationService.Navigate(new ListUserPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = RoleCb.SelectedIndex + 1;
                user = DBEntities.GetContext().User
                    .FirstOrDefault(u => u.UserId == user.UserId);
                user.UserName = UserNameTb.Text;
                user.UserPassword = UserPassortTb.Text;
                user.RoleId = index;
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

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        User user = DBEntities.GetContext().User
        //            .FirstOrDefault(u => u.UserId == u.UserId);

        //        if (user != null)
        //        {
        //            user.UserName = UserNameTb.Text;
        //            user.UserPassword = UserPassortTb.Text;
        //            user.FIO = FIOTb.Text;
        //            user.DateOfBirth = (DateTime)DateDRPick.SelectedDate;
        //            user.Adress = AdresTb.Text;

        //            DBEntities.GetContext().SaveChanges();

        //            MBClass.ShowMesagePopup("Обновлено", Application.Current.MainWindow);

        //            NavigationService.Navigate(new ListUserPage());
        //        }
        //        else
        //        {
        //            MBClass.ShowErrorPopup("Выбирете пользователя", Application.Current.MainWindow);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
        //    }
        //}
    }
}
