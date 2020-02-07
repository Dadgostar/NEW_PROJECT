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

namespace AP_PROJECT.View.Professor
{
    /// <summary>
    /// Interaction logic for Professor_listof_objections.xaml
    /// </summary>
    public partial class Professor_listof_objections : Window
    {
        private Teacher studentId;
        Data[] objectionData;

        public Professor_listof_objections(Teacher teacher)
        {
            InitializeComponent();
            
            // tracher is just passed, be careful !!!!!
            objectionData = Module.GetObjectionListData(teacher);
            this.list_of_objections.DataContext = objectionData;
        }

        public class Data
        {
            public string student_name { set; get; }
            public string student_id { set; get; }
            public string course_name { set; get; }
            public string course_id { set; get; }
           
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            int courseId = int.Parse((row.Item as Data).course_id);
            int studentId = int.Parse((row.Item as Data).student_id);

            Professor_objection_response objection_resp_page = new Professor_objection_response(courseId, studentId);
            objection_resp_page.Show();

        }

       
    }
}
