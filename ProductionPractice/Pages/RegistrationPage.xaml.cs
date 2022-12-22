using ProductionPractice.Components;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Кнопка "Зарегистрироваться"
        {
            var user = App.DB.User.FirstOrDefault(emp => emp.NickName == TB_NickNameAdd.Text);
            if (TB_NickNameAdd.Text.Length <= 0 || Pb_PaswordAdd.Password.Length <= 0 || user != null)
            {
                MessageBox.Show("Данный пользователь уже зарегистрирован, или не все поля заполнены.");
            }
                else
                {
                    App.DB.User.Add(new User() { NickName = TB_NickNameAdd.Text.Trim(),
                        Password = Pb_PaswordAdd.Password.Trim(),
                        RoleId = 1, 
                        Fname = " ",
                        SName = " ", 
                        Balance = 0,
                        Email = TB_EmailAdd.Text});
                    App.DB.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    NavigationService.GoBack();
                }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

