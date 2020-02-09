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
    /// Interaction logic for Student_user_pass_change.xaml
    /// </summary>
    public partial class Student_user_pass_change : Window
    {
        private Class.Student student;
        
       
        public Student_user_pass_change(Class.Student student)
        {
            InitializeComponent();
            this.student = student;
            
        }

        private void ChangePasswordClicked(object sender, RoutedEventArgs e)
        {
            if (Module.EditPassword(this.student, newpass_txt.Text, oldpass_txt.Text, confirm_txt.Text, this.student))
                CheckPassChange.Content = "Password changed";
            else
                CheckPassChange.Content = "Password not changed yet";

        }
    }
}
