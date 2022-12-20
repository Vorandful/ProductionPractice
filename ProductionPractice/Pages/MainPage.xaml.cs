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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LV_Courses.ItemsSource = App.DB.Course.OrderBy(x => x.Name).ToList();
            BalanceOnMainPage.Text = App.LoggedUser.Balance.ToString();
        }
       

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void ToProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedCourse = LV_Courses.SelectedItem as Course;
            if (selectedCourse == null)
            {
                MessageBox.Show("Выберите курс");
            }
            else
            {
                if (App.LoggedUser.Id != selectedCourse.Id)
                {
                    if (App.LoggedUser.RoleId == 2)
                    {
                        NavigationService.Navigate(new CourseEditPage(selectedCourse));
                    }
                    else
                    {
                        MessageBox.Show(" У вас нет доступа к редактированию этого курса");
                    }

                }
                else { NavigationService.Navigate(new CourseEditPage(selectedCourse)); }
            }
        }

        private void Beginner_Click(object sender, RoutedEventArgs e)
        {            
                LV_Courses.ItemsSource = App.DB.Course.Where(a => a.KnowledgeLevelId == 1).ToList();            
        }

        private void Advanced_Click(object sender, RoutedEventArgs e)
        {
            LV_Courses.ItemsSource = App.DB.Course.Where(a => a.KnowledgeLevelId == 2).ToList();
        }

        private void Proffesional_Click(object sender, RoutedEventArgs e)
        {
            LV_Courses.ItemsSource = App.DB.Course.Where(a => a.KnowledgeLevelId == 3).ToList();
        }

        private void ByDefault_Click(object sender, RoutedEventArgs e)
        {
            LV_Courses.ItemsSource = App.DB.Course.ToList();
            TBSearch.Text = null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //Сортировка
        {
            Refresh();
        }
        private void Refresh()
        {
            if (string.IsNullOrWhiteSpace(TBSearch.Text))
            {
                LV_Courses.ItemsSource = App.DB.Course.ToList();
            }
            else
            {
                LV_Courses.ItemsSource = App.DB.Course.Where(a => a.Name.ToString().Contains(TBSearch.Text.ToLower())).ToList();
            }
            switch (SortCB.SelectedIndex)
            {
                case 2:
                    LV_Courses.ItemsSource = App.DB.Course.OrderBy(x =>x.Name).ToList();
                    break;
                case 1:
                    LV_Courses.ItemsSource = App.DB.Course.OrderByDescending(x => x.Price).ToList();
                    break;
                case 0:
                    LV_Courses.ItemsSource = App.DB.Course.OrderBy(x => x.Price).ToList();
                    break;
            }
            BalanceOnMainPage.Text = App.LoggedUser.Balance.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            Refresh();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var selectedCourse = (sender as Button).DataContext as Course;
            if (App.LoggedUser.Balance < selectedCourse.Price) 
            {
                MessageBox.Show("Бомж, хаха");
                return;
            }
       
            if (MessageBox.Show($"Вы действительно хотите купить курс {selectedCourse.Name}", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) 
            {
                var courseauthor = App.DB.User.FirstOrDefault(emp => emp.Id == selectedCourse.AuthorId);
                App.DB.SellHistory.Add(new SellHistory(){ CourseID = selectedCourse.Id, AuthorId = selectedCourse.AuthorId, Price = selectedCourse.Price});
                courseauthor.Balance = courseauthor.Balance + selectedCourse.Price;
                App.DB.BoughtCourse.Add(new BoughtCourse(){AuthorId = App.LoggedUser.Id, CourseId = selectedCourse.Id});
                App.LoggedUser.Balance = App.LoggedUser.Balance - selectedCourse.Price;
                App.DB.SaveChanges();
                Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
