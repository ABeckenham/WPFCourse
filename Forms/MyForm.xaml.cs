using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPFCourse
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    /// step 3 : code behid, connecting form to code.
    public partial class MyForm : Window
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            tbx.Text = "Select a csv File";
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = "C:\\";
            // double backslash is a special character in visual studio to show it is a path, alternatively use @"C:\ instead
            openfile.Filter = "csv files(*.csv)|*.csv";
            //first part of the above is what is displayed to the user. after vertical line is the search

            if (openfile.ShowDialog() == true)
            {
                //set textbox to the folder path
                tbx.Text = openfile.FileName;
            }
            else
            {
                tbx.Text = "";
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {                        

            this.DialogResult = false;
            this.Close();  

        }
        public string getTextboxValue()
        {
            return tbx.Text;
        }

        public bool getcheckbox1()
        {
            if(chbCheck1.IsChecked == true)
                return true;
            else
                return false;

        }

        public  string GetGroup1()
        {
            if (rb1.IsChecked == true)
                return rb1.Content.ToString();
            else if (rb2.IsChecked == true)
                return rb2.Content.ToString();
            else return rb3.Content.ToString();
        }
    }

}
