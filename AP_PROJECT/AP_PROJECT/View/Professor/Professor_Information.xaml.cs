using AP_PROJECT.Class;
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
    /// Interaction logic for Professor_Information.xaml
    /// </summary>
    public partial class Professor_Information : Window
    {
        private Teacher teacher;

        public Professor_Information(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            update();
        }

        public void update()
        {
            this.teacher = Module.getTeacher(teacher.Id);
            prof_usertext_label.Content = teacher.Id;
            prof_passtext_label.Content = teacher.Password;
            prof_nametext_label.Content = teacher.FirstName;
            prof_familytext_label.Content = teacher.LastName;
            prof_idtext_label.Content = teacher.Id;
            //prof_studfieldtext_label.Content = teacher.
            //prof_grade_label.Content = teacher.
        }
        private void prof_userpass_change_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_change_userpass change_userpass = new Professor_change_userpass(this,this.teacher);
            change_userpass.Show();
            //this.Close();
        }
    }
}
