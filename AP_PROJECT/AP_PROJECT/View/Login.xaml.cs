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
using AP_PROJECT.View.Clerk;
using System.ComponentModel;
using System.Diagnostics;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker BW = new BackgroundWorker();
            BW.DoWork += new DoWorkEventHandler(dowork);
            BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(completeEvent);
            BW.RunWorkerAsync();

//            for (int i = 0; i < 100; i++)
//               Module.loadData();
//            MessageBox.Show("completed22");
        }

        private void completeEvent(object sender, RunWorkerCompletedEventArgs e)
        {
            Trace.WriteLine("ssssssss");
            MessageBox.Show("completed");
        }

        private void dowork(object sender, DoWorkEventArgs e)
        {
            Module.loadData();   
            for(int i=0; i<1000; i++)
            Module.loadData();
 
        }

        private void LoginBtnClicked(object sender, RoutedEventArgs e)
        {
            var person = Module.Login(username_txt.Text, password_txt.Password);
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
            if(person is AP_PROJECT.Class.Student)
            {
                Student_main_page window = new Student_main_page((AP_PROJECT.Class.Student)person);
                window.Show();
                this.Close();
            }
            if (person is AP_PROJECT.Class.Clerk)
            {
                Clerk_main_page window = new Clerk_main_page((AP_PROJECT.Class.Clerk)person);
                window.Show();
                this.Close();
            }

        }
    }
}
