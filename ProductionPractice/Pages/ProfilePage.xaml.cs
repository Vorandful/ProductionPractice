using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using ProductionPractice.Components;

namespace ProductionPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            FirstName.Text = App.LoggedUser.Fname;
            SecondName.Text = App.LoggedUser.SName;
            Email.Text = App.LoggedUser.Email;
            NickName.Text = App.LoggedUser.NickName;
            balanceProfilePage.Text =App.LoggedUser.Balance.ToString();
            LVYourCourses.ItemsSource = App.LoggedUser.Course.ToList();
            BoughtCourses.ItemsSource = App.LoggedUser.BoughtCourse.ToList();
        }

        private void GoToMainPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
        private void GoToBalanceAddPage(object sender, RoutedEventArgs e) 
        {
            NavigationService.Navigate(new BalancePage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            balanceProfilePage.Text = App.LoggedUser.Balance.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Новый курс
        {
            NavigationService.Navigate(new CourseEditPage(new Course(){AuthorId = App.LoggedUser.Id}));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.LoggedUser.Fname = FirstName.Text;
            App.LoggedUser.SName = SecondName.Text;
            App.LoggedUser.Email = Email.Text;
            App.DB.SaveChanges();
        }
    }
}
