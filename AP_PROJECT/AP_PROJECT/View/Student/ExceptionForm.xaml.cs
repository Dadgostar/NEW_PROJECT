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
    /// Interaction logic for ExceptionForm.xaml
    /// </summary>
    public partial class ExceptionForm : Window
    {
        public ExceptionForm()
        {
            InitializeComponent();
        }

        bool hasBeenClicked = false;
        private void explanation_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void SaveChangesClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
