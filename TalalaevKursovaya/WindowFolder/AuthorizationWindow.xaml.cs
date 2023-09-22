﻿using System;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DBEntities.GetContext()
                    .User.FirstOrDefault(u => u.UserName == LoginTB.Text);

                if (user == null)
                {
                    MBClass.ErrorMB("Введен неверный логин");
                    LoginTB.Focus();
                    return;
                }
                if (user.UserPassword != PaswordTB.Text)
                {
                    MBClass.ErrorMB("Введен неверный пароль");
                    PaswordTB.Focus();
                    return;
                }
                else
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            new MainWindow().Show();
                            Close();
                            break;
                        case 2:
                            new ZakazWindow().Show();
                            break;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
