﻿using System;
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
    /// Interaction logic for Clerk_userpass_change.xaml
    /// </summary>
    public partial class Clerk_userpass_change : Window
    {
        private Class.Clerk clerk;

        public Clerk_userpass_change(Class.Clerk clerk)
        {
            InitializeComponent();
            this.clerk = clerk;
        }

        private void apply_button_Click(object sender, RoutedEventArgs e)
        {
            if (Module.EditPassword(this.clerk, clerk_newpasstxt.Text, clerk_oldpasstxt.Text, clerk_confirmtxt.Text, this.clerk))
                CheckPassChange.Content = "Password changed";
            else
                CheckPassChange.Content = "Password not changed yet";
        }
    }
}
