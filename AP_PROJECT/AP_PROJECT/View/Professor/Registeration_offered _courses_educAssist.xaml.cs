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
    /// Interaction logic for Registeration_offered__courses_educAssist.xaml
    /// </summary>
    public partial class Registeration_offered__courses_educAssist : Window
    {
        Data[] offeredCoursesData;
        public Registeration_offered__courses_educAssist()
        {
            InitializeComponent();
            offeredCoursesData = Module.GetOfferedCoursesData();
            this.offered_courses.DataContext = offeredCoursesData;
        }

        public class Data
        {
            public string course_name { set; get; }
            public string course_id { set; get; }
            public string teacher { set; get; }
            public string units { set; get; }
            public string volume { set; get; }
            public string time { set; get; }

        }

        private void add_butt_Click(object sender, RoutedEventArgs e)
        {
            // sending required informaion to module 
            string courseId = this.couresId_txt.Text;
            string profId = this.prof_name.Text;
            string time_ofCourse = this.time.Text;
            string volume_ofCourse = this.volume.Text;

            // in nakone dataye ghabli ro pak kone va jadid ro benevise?
            // chon mikham dataye jadid ezafe she, na inke ja datahaye ghabli biad
            offeredCoursesData = Module.GetAddedCourse_byEduAssist(courseId, profId, time_ofCourse, volume_ofCourse);
            this.offered_courses.DataContext = offeredCoursesData;
        }

    }
}
