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
    /// Interaction logic for Clerk_Information.xaml
    /// </summary>
    public partial class Clerk_Information : Window
    {
        private Clerk clerk;
        private Class.Clerk clerk1;

        public Clerk_Information(Clerk clerk)
        {
            InitializeComponent();
            this.clerk = clerk;
            clerk_nametext_label.Content = clerk.FirstName;
            clerk_familytext_label.Content = clerk.LastName;
            clerk_idtext_label.Content = clerk.Id;
            clerk_passtext_label.Content = clerk.Password;

        }

        public Clerk_Information(Class.Clerk clerk1)
        {
            this.clerk1 = clerk1;
        }

        private void clerk_userpass_change_button_Click(object sender, RoutedEventArgs e)
        {
            Clerk_userpass_change clrk_usepass_change = new Clerk_userpass_change(this.clerk);
            clrk_usepass_change.Show();
        }
    }
}
