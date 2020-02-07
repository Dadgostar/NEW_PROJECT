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
    /// Interaction logic for Professor_objection_response.xaml
    /// </summary>
    public partial class Professor_objection_response : Window
    {
        // chetor teacher ro besh begim in teacher?
        private Teacher teacher;
        private int courseId;
        private int studentId;

    
        public Professor_objection_response(int courseId, int studentId)
        {
            this.courseId = courseId;
            this.studentId = studentId;

            AP_PROJECT.Class.Student student = Module.GetStudent(studentId);

            student_nametxt.DataContext = student.FirstName + student.FirstName;
            student_idtxt.DataContext = student.Id;

            AP_PROJECT.Class.Course course = Module.GetCourse(courseId);

            course_nametxt.DataContext = course.Name;
        }

        // Radio buttons funtionallity?!!
        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            // storing teachers explanation to student's objection
            string explanation = explanationtxt.Text;
            bool b = Module.SetObjection(courseId, studentId, teacher);

            if (b)
                this.Close();
            else
                MessageBox.Show("Permission Denied!!!");
        }
    }
}
