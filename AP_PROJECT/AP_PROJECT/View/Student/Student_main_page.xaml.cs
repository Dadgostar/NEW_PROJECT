using AP_PROJECT.Class;
using AP_PROJECT.View.Student;
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
    /// Interaction logic for Student_main_page.xaml
    /// </summary>
    public partial class Student_main_page : Window
    {
        private AP_PROJECT.Class.Student student;

        public Student_main_page(Class.Student student)
        {
            InitializeComponent();
            this.student = student;

        }

        private void PersonalInformationClicked(object sender, RoutedEventArgs e)
        {
            Student_Personal_Information Personal_Information_Page = new Student_Personal_Information(this.student);
            Personal_Information_Page.Show();


        }

        private void ListOfTermClicked(object sender, RoutedEventArgs e)
        {
            List_of_terms list_Of_Terms = new List_of_terms(this.student);
            list_Of_Terms.Show();
        }

        private void RegClicked(object sender, RoutedEventArgs e)
        {
            Student_offeredCourses student_OfferedCourses = new Student_offeredCourses();
            student_OfferedCourses.Show();          
        }

        private void WeeklyScheduleClicked(object sender, RoutedEventArgs e)
        {
            WeekSchedual weekSchedual = new WeekSchedual();
            weekSchedual.Show();
        }

        private void ExcepForm(object sender, RoutedEventArgs e)
        {
            ExceptionForm exceptionForm = new ExceptionForm();
            exceptionForm.Show();
        }

        private void ProfEvalClicked(object sender, RoutedEventArgs e)
        {
            Student_professor_evaluation studentProffesorEvaluation = new Student_professor_evaluation();
            studentProffesorEvaluation.Show();
        }

        private void ChangePassClicked(object sender, RoutedEventArgs e)
        {
            Student_user_pass_change student_User_Pass_Change = new Student_user_pass_change();
            student_User_Pass_Change.Show();
        }

        private void PaymentClicked(object sender, RoutedEventArgs e)
        {
            double payment = Module.GetPayment(this.student);
                
        }

        private void PersonalInfoClicked(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
