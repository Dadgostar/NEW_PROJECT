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
        private Class.Student student;

        

        public WeekSchedule(Class.Student student)
        {
            InitializeComponent();
            this.student = student;
            this.datas = Module.GetStudentSchedule(this.student);
            WeekSchedule.DataContext = this.datas;
        }

        public class Data
        {

            public String Day { set; get; }
            public String CourseNameTime1 { set; get; }
            public String CourseNameTime2 { set; get; }
            public String CourseNameTime3 { set; get; }
            public String CourseNameTime4 { set; get; }
         
        }
    }
}
