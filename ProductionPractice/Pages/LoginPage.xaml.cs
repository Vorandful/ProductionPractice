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

namespace ProductionPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e) // Регистрация
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Авторизация
        {
            var user = App.DB.User.FirstOrDefault(emp => emp.NickName == Tb_login.Text);
            if (user == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (user.Password != Pb_password.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            App.LoggedUser = user;
            NavigationService.Navigate(new MainPage());
        }
    }
}
