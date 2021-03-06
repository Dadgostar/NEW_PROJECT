﻿using AP_PROJECT.Class;
using AP_PROJECT.View.Professor;
using System;
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
    /// Interaction logic for Professor_main_page.xaml
    /// </summary>
    public partial class Professor_main_page : Window
    {
        private Teacher teacher;

        public Professor_main_page(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        private void personal_infor_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_Information information = new Professor_Information(this.teacher);
            information.Show();
        }

        private void schedule_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_courses courses = new Professor_courses(this.teacher);
            courses.Show();
            //this.Close();
        }


        private void objection_response_button_Click(object sender, RoutedEventArgs e)
        {
            // Is it fine to pass just teachr to go to the Professor_listof_objections ?!!!
            Professor_listof_objections objection_list = new Professor_listof_objections(this.teacher);
            objection_list.Show();
            //this.Close();
        }

        private void Exception_response_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_exception_list exception_list = new Professor_exception_list(this.teacher);
            exception_list.Show();
            //this.Close();
        }
    }
}
