using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TalalaevKursovaya.ClassFolder;
using TalalaevKursovaya.DataFolder;
using TalalaevKursovaya.PageFolder.AdminFolder;
using TalalaevKursovaya.PageFolder.ZakazFolder;

namespace TalalaevKursach.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.GetContext()
               .Role.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                UserNameTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(UserPassortTb.Text))
            {
                MBClass.ErrorMB("Введите пароль");
                UserPassortTb.Focus();
            }
            else if (RoleCb.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите роль для пользователя");
                RoleCb.Focus();
            }
            else
            {
                try
                {
                    string dateString = DateDRPick.SelectedDate.ToString();
                    string format = "dd.MM.yyyy"; 

                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                    {
                        DBEntities.GetContext().User.Add(new User()
                        {
                            UserName = UserNameTb.Text,
                            UserPassword = UserPassortTb.Text,
                            RoleId = Int32.Parse(RoleCb.SelectedValue.ToString()),
                            FIO = FIOTb.Text,
                            DateOfBirth = dateOfBirth,
                            Adress = AdresTb.Text
                        });
                        DBEntities.GetContext().SaveChanges();
                        NavigationService.Navigate(new ListUserPage());
                    }
                    else
                    {
                        
                        MessageBox.Show("Ошибка: Неверный формат даты.");
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    throw;
                }
            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTb.Text))
            {
                MBClass.ShowErrorPopup("Введите логин", Application.Current.MainWindow);
                UserNameTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(UserPassortTb.Text))
            {
                MBClass.ShowErrorPopup("Введите пароль", Application.Current.MainWindow);
                UserPassortTb.Focus();
            }
            else if (RoleCb.SelectedIndex == -1)
            {
                MBClass.ShowErrorPopup("Выберите роль", Application.Current.MainWindow);
                RoleCb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        UserName = UserNameTb.Text,
                        UserPassword = UserPassortTb.Text,
                        RoleId = Int32.Parse(RoleCb.SelectedValue.ToString()),
                        FIO = FIOTb.Text,
                        DateOfBirth = (DateTime)DateDRPick.SelectedDate,
                        Adress = AdresTb.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.ShowMesagePopup("Добавленно", Application.Current.MainWindow);
                }
                catch (Exception ex)
                {
                    MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                    
                }

               
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
