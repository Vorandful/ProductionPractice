﻿using Microsoft.Win32;
using ProductionPractice.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CourseCreation.xaml
    /// </summary>
    public partial class CourseCreation : Page
    {
        Course coursecontext;
        public CourseCreation(Course course)
        {
            InitializeComponent();
            CB_Level.ItemsSource = App.DB.KnowledgeLevel.ToList();
            DataContext = coursecontext;
            coursecontext = course;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            coursecontext.AuthorId = App.LoggedUser.Id;
            App.DB.Course.Add(coursecontext);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CoursePhotoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                coursecontext.Image = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = coursecontext;
            }
        }


    }
}
