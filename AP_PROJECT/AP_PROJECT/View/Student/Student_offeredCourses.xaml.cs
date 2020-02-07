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

namespace AP_PROJECT.View.Student
{
    /// <summary>
    /// Interaction logic for Student_offeredCourses.xaml
    /// </summary>
    public partial class Student_offeredCourses : Window
    {
        Data[] datas;
        Class.Term term;
        Class.Student student;
        public Student_offeredCourses(int term, Class.Student student)
        {
            InitializeComponent();
            this.student = student;
            this.term.TermNum = term;
            OfferedCourses.DataContext = Module.GetStudentOfferedCoursesData(student, term);

        }
        public class Data
        {
            public String Name { set; get; }
            public int ID { set; get; }
            public int ECT { set; get; }
            public String Professor { set; get; }
            public int Time { set; get; }
            public String Status { set; get; }

        }
    }
}
