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
    /// Interaction logic for Professor_exception_response.xaml
    /// </summary>
    public partial class Professor_exception_response : Window
    {
        private Teacher teacher;
        private int studentName;
        private int studentId;

        public Professor_exception_response(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        public Professor_exception_response(int studentName, int studentId, int courseId)
        {
            this.studentName = studentName;
            this.studentId = studentId;

            AP_PROJECT.Class.Student student = Module.GetStudent(studentId);

            student_nametxt.DataContext = student.FirstName + student.FirstName;
            student_idtxt.DataContext = student.Id;

            AP_PROJECT.Class.PreQuisite preRequisite = Module.GetRequisite(courseId);

            exception_typetxt.DataContext = preRequisite;
        }
    }
}
