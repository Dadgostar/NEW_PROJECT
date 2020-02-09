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
    /// Interaction logic for Clerk_student_list.xaml
    /// </summary>
    public partial class Clerk_student_list : Window
    {
        private Class.Clerk clerk;
        Data[] studentsData;

        public Clerk_student_list(Class.Clerk clerk)
        {
            InitializeComponent();
            studentsData = Module.GetStudentsDataForClerk(clerk);
            this.students_list.DataContext = studentsData;
        }

        public class Data
        {
            public string student_name { set; get; }
            public string student_id { set; get; }
            public string student_gpa { set; get; }
        }

        private void add_stu_button_Click(object sender, RoutedEventArgs e)
        {
            string newStudentName = this.new_student_name.Text;
            string newStudentId = this.new_student_id.Text;

            studentsData = Module.GetAddedStudentByEducAssist(newStudentId, newStudentName);
            this.students_list.DataContext = studentsData;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            var student = Module.GetStudent(int.Parse((row.Item as Data).student_id));
            Student.Student_offeredCourses page = new Student.Student_offeredCourses(Module.getLastTerm(student),student);
            page.Show();
        }

    }

}
