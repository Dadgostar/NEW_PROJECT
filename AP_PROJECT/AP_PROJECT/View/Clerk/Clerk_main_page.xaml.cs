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

namespace AP_PROJECT.View.Clerk
{
    /// <summary>
    /// Interaction logic for Clerk_main_page.xaml
    /// </summary>
    public partial class Clerk_main_page : Window
    {
        private Class.Clerk clerk;

        public Clerk_main_page(Class.Clerk clerk)
        {
            InitializeComponent();
            this.clerk = clerk;
        }

        private void clrk_prsnl_infor_button_Click(object sender, RoutedEventArgs e)
        {
            Clerk_Information clrk_infor = new Clerk_Information(this.clerk);
            clrk_infor.Show();
        }

        private void clrk_stdnt_button_Click(object sender, RoutedEventArgs e)
        {
            Clerk_student_list clrk_stud_list = new Clerk_student_list(this.clerk);
            clrk_stud_list.Show();
        }
        private void clrk_dect_overlap_button_Click(object sender, RoutedEventArgs e)
        {
            Clerk_deactivate_preq_overlap clrk_deac_over = new Clerk_deactivate_preq_overlap(this.clerk);
            clrk_deac_over.Show();
        }
        private void clrk_deact_dect_button_Click(object sender, RoutedEventArgs e)
        {
            Clerk_deactivate_preq_overlap clrk_deact_preq_over = new Clerk_deactivate_preq_overlap(this.clerk);
            clrk_deact_preq_over.Show();
        }
    }
}
