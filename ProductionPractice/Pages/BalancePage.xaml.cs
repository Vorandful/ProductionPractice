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

namespace ProductionPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для BalancePage.xaml
    /// </summary>
    public partial class BalancePage : Page
    {
        public BalancePage()
        {
            InitializeComponent();
           
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BalanceAddSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(BalanceAddSum.Text) || string.IsNullOrWhiteSpace(BalanceAddSum.Text))
            {
                BalanceAddSum.Text = "0";
                balanceProfilePageTB.Text = (double.Parse(BalanceAddSum.Text) + App.LoggedUser.Balance).ToString();
            }
            else if (BalanceAddSum.Text != "0")
            {
                switch (BalanceAddSum.Text)
                {
                    case "01":
                        BalanceAddSum.Text = "1";
                        break;
                    case "02":
                        BalanceAddSum.Text = "2";
                        break;
                    case "03":
                        BalanceAddSum.Text = "3";
                        break;
                    case "04":
                        BalanceAddSum.Text = "4";
                        break;
                    case "05":
                        BalanceAddSum.Text = "5";
                        break;
                    case "06":
                        BalanceAddSum.Text = "6";
                        break;
                    case "07":
                        BalanceAddSum.Text = "7";
                        break;
                    case "08":
                        BalanceAddSum.Text = "8";
                        break;
                    case "09":
                        BalanceAddSum.Text = "9";
                        break;
                    case "00":
                        BalanceAddSum.Text = "1";
                        
                        break;
                    default:
                        balanceProfilePageTB.Text = (double.Parse(BalanceAddSum.Text) + App.LoggedUser.Balance).ToString();
                        break;

                }

            }
            else 
            {
                balanceProfilePageTB.Text = (double.Parse(BalanceAddSum.Text) + App.LoggedUser.Balance).ToString();
            }
        }

        private void MoneyAdd_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser.Balance = double.Parse(balanceProfilePageTB.Text);
            App.DB.SaveChanges();
        }
    }
}
