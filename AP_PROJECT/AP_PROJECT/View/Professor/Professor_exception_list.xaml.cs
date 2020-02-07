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
    /// Interaction logic for Professor_exception_list.xaml
    /// </summary>
    public partial class Professor_exception_list : Window
    {

        Data[] exceptionData;
        public Professor_exception_list(Class.Teacher teacher)
        {
            InitializeComponent();

            exceptionData = Module.GetExceptionListData(teacher);
            this.list_of_exceptions.DataContext = exceptionData;
        }

        public class Data
        {
            public string student_name { set; get; }
            public string student_id { set; get; }
            public string teacher_name { set; get; }
            public string teacher_id { set; get; }
            public string course_id { set; get; }
            public string coursr_name { set; get; }

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            int studentName = int.Parse((row.Item as Data).student_name);
            int studentId = int.Parse((row.Item as Data).student_id);
            int courseId = int.Parse((row.Item as Data).course_id);

            Professor_exception_response exception_resp_page = new Professor_exception_response(studentName, studentId, courseId);
            exception_resp_page.Show();

        }
    }
}
