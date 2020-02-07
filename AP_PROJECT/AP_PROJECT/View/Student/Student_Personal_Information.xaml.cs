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
    /// Interaction logic for Student_Personal_Information.xaml
    /// </summary>
    /// 
    public partial class Student_Personal_Information : Window
    {
        private Class.Student student;

        public Student_Personal_Information(Class.Student student)
        {
            InitializeComponent();
            this.student = student; 
            username.Content = student.Id;
            password.Content = student.Password;
            name.Content = student.FirstName;
            family.Content = student.LastName;
            EntranceYear.Content = student.EntranceYear;          
            AvgGrade.Content = "" + Module.GetAvgGrade(student);
        }        
    }
}
