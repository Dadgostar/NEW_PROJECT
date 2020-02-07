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
    /// Interaction logic for List_of_terms.xaml
    /// </summary>
    public partial class List_of_terms : Window
    {
        Data[] datas;
        private Class.Student student;

        public List_of_terms(Class.Student student)
        {
            InitializeComponent();
            this.student = student;
            this.datas = Module.GetListOfTerms(this.student);
            DG.DataContext = this.datas;

        }


        public class Data
        {
            public int Term { set; get; }
            public int Total_Units { set; get; }
            public string Status { set; get; }
        }
        
    }
}
