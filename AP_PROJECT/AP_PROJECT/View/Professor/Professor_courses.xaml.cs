﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AP_PROJECT.View
{
    /// <summary>
    /// Interaction logic for Professor_courses.xaml
    /// </summary>
    public partial class Professor_courses : Window
    {
        public Professor_courses(ProjectAP.Teacher teacher)
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        public class Data
        {
            string course_name { set; get; }
            string course_id { set; get; }
            bool type { set; get; }
            int units { set; get; }
            int students { set; get; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            ////////////////////////////////////////

        }
    }
}
