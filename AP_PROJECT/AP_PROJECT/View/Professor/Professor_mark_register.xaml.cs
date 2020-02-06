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
    /// Interaction logic for Professor_mark_register.xaml
    /// </summary>
    public partial class Professor_mark_register : Window
    {
        private int course_id;
        private int student_id;
        private Teacher teacher;

        public Professor_mark_register(int student_id, Teacher teacher, int cours_id)
        {
            InitializeComponent();
            this.course_id = cours_id;
            this.student_id = student_id;
            this.teacher = teacher;
           
            AP_PROJECT.Class.Student student = Module.GetStudent(student_id);

            student_nametxt.DataContext = student.FirstName;
            student_idtxt.DataContext = student.Id;

            AP_PROJECT.Class.Course course = Module.GetCourse(cours_id);

            coursetxt.DataContext = course.Name;
        }

        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            int mark = int.Parse(student_marktxt.Text);
            bool b = Module.SetMark(course_id, student_id, teacher, mark);

            if (b)
                this.Close();
            else
                MessageBox.Show("Permission Denied!!!");
        }
    }
}
