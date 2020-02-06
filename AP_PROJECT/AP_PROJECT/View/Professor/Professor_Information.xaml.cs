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
using ProjectAP;

namespace AP_PROJECT.View
{
    /// <summary>
    /// Interaction logic for Professor_Information.xaml
    /// </summary>
    public partial class Professor_Information : Window
    {
        private Teacher teacher;

        public Professor_Information(ProjectAP.Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        private void prof_userpass_change_button_Click(object sender, RoutedEventArgs e)
        {
            Professor_change_userpass change_userpass = new Professor_change_userpass(this.teacher);
            change_userpass.Show();
            //this.Close();
        }
    }
}
