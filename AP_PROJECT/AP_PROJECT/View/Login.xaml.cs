using ProjectAP;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtnClicked(object sender, RoutedEventArgs e)
        {
            var person = Module.Login(username_txt.Text, password_txt.Text);
            if(person == null)
            {
                MessageBox.Show("username or password is invalid");
            }
            if(person is Teacher)
            {
                Professor_main_page window = new Professor_main_page((Teacher)person);
                window.Show();
                this.Close();
            }
            if(person is Student)
            {
                Student_main_page window = new Student_main_page((Student)person);
                window.Show();
                this.Close();
            }
        }
    }
}
