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

namespace AP_PROJECT.View.Professor
{
    /// <summary>
    /// Interaction logic for Proffessor_educational_assist_.xaml
    /// </summary>
    public partial class Proffessor_educational_assist_ : Window

    {
        private Teacher teacher;
        public Proffessor_educational_assist_(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        private void personal_infor_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_Information pro_infor = new Professor_Information(this.teacher);
            pro_infor.Show();
        }

        private void schedule_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_courses pro_course = new Professor_courses(this.teacher);
            pro_course.Show();
        }

        private void objection_response_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_listof_objections prof_listobj = new Professor_listof_objections(this.teacher);
            prof_listobj.Show();
        }

        private void Exception_response_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_exception_list pro_excep_list = new Professor_exception_list(this.teacher);
            pro_excep_list.Show();
        }

        

        private void register_list_Click(object sender, RoutedEventArgs e)
        {
            Registeration_offered__courses_educAssist reg_off_eduAssis = new Registeration_offered__courses_educAssist();
            reg_off_eduAssis.Show();
        }
    }
}
