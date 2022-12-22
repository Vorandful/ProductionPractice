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
using ProductionPractice.Components;
using ProductionPractice.Pages;

namespace ProductionPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
            LV_Users.ItemsSource = App.DB.User.ToList();
            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LV_Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedUser = LV_Users.SelectedItem as User;
            var SelectedCourse = LV_Users.SelectedItem as Course;
            CourseAmount.Text = $"Автор {App.DB.Course.Count(x=>x.AuthorId == SelectedUser.Id)} курс(ов)";
            BoughtCurses.Text = $"Купил {App.DB.BoughtCourse.Count(x => x.AuthorId == SelectedUser.Id)} курс(ов)";
        }

        private void LV_Users_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
