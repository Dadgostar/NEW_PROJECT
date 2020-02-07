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
        public Student_offeredCourses(int term, Class.Student student)
        {
            InitializeComponent();
        }
    }
}
