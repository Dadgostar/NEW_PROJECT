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
    /// Interaction logic for Professor_courses.xaml
    /// </summary>
    public partial class Professor_courses : Window
    {
        Data[] coursesData;

        public Professor_courses(Teacher teacher)
        {
            InitializeComponent();
            coursesData = Module.GetProfessorCoursesData(teacher);
            this.courses_list.DataContext = coursesData;
        }

       
        public class Data
        {
<<<<<<< HEAD
            string course_name { set; get; }
            string course_id { set; get; }
            bool type { set; get; }
            int units { set; get; }
            int students { set; get; }
            string time { set; get; }
=======
            public string course_name { set; get; }
            public string course_id { set; get; }
            public string type { set; get; }
            public int units { set; get; }
            public int students { set; get; }
>>>>>>> edcddb4e684461997d62971ea2b8f04204d2d246
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            ////////////////////////////////////////

        }
    }
}
