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
            if (this.pesel.IsPeselValid(this.peselInput.Text))
            {
                this.pesel.SetPeselWithoutVerification(this.peselInput.Text);
                this.PutInfo(this.pesel.GetDayInfo(), this.pesel.GetMonthInfo(), this.pesel.GetYearInfo(), this.pesel.GetSexInfo());
            }
            else MessageBox.Show("Invalid PESEL");           

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
