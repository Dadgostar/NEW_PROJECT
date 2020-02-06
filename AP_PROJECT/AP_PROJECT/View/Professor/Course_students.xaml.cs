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
using AP_PROJECT.Class;

namespace AP_PROJECT.View.Professor
{
    /// <summary>
    /// Interaction logic for Course_students.xaml
    /// </summary>
    public partial class Course_students : Window
    {
        private Teacher teacher;
        private int cours_id;
        Data[] studentsData;

        public Course_students(int courseId, Class.Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.cours_id = courseId;
            MessageBox.Show(""+courseId);
            studentsData = Module.GetStudentsMark(cours_id, teacher);
            this.course_student_list.DataContext = studentsData;
        }

        public class Data
        {
            public string student_name { set; get; }
            public string student_id { set; get; }
            public string mark { set; get; }

        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            int student_id = int.Parse((row.Item as Data).student_id);

            Professor_mark_register mark_reg = new Professor_mark_register(student_id, teacher, cours_id);
            mark_reg.Show();

        }

       
    }
}

