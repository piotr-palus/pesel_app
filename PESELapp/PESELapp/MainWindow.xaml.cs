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

namespace PESELapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pesel pesel;
        public MainWindow()
        {
            InitializeComponent();
            this.pesel = new Pesel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.PutInfo("30","11","2017","Male");
            this.pesel.setPesel("30103020912");
        }

        private void PutInfo(string day, string month, string year, string sex)
        {
            this.PutDateInfo(day, month, year);
            this.PutSexInfo(sex);
        }

        private void PutDateInfo(string day, string month, string year)
        {
            this.dayValue.Text = day;
            this.monthValue.Text = month;
            this.yearValue.Text = year;
        }

        private void PutSexInfo(string sex)
        {
            this.sexValue.Text = sex;
        }
    }
}
