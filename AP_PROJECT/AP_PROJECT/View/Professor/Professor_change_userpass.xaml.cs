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
    /// Interaction logic for Professor_change_userpass.xaml
    /// </summary>
    public partial class Professor_change_userpass : Window
    {
        private Teacher teacher;
        private Professor_Information page;
        public Professor_change_userpass(Professor_Information professor_Information, Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.page = professor_Information;
        }

        private void prof_userpass_apply_button_Click(object sender, RoutedEventArgs e)
        {
            if (Module.EditPassword(this.teacher, prof_newpass_txt.Password, prof_oldpass_txt.Password, prof_passconfirm_txt.Password, this.teacher))
            {
                isPassChanged.Content = "Pass Changed";
                page.update();
            }
            else 
                 isPassChanged.Content = "Pass is not Changed!";
        }
    }
}
