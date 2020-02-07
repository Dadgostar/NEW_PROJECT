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
    /// Interaction logic for WeekSchedule.xaml
    /// </summary>
    public partial class WeekSchedule : Window
    {
        Data[] datas;
        private Class.TermCourseStudent termCourseStudent;
        public WeekSchedule(Class.TermCourseStudent termCourseStudent)
        {
            InitializeComponent();
            this.termCourseStudent = termCourseStudent;
            this.datas = Module.GetStudentSchedule(this.termCourseStudent);
        }

        public class Data
        {

            public String Day { set; get; }
            public String CourseNameTime { set; get; }
    }
}
