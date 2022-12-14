using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProductionPractice.Components;

namespace ProductionPractice
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ProductionPracticeEntities DB = new ProductionPracticeEntities();
        public static User LoggedUser;
    }
}
