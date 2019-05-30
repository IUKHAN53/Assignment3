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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            var query = from emp in nw.Employees
                        select new
                        {
                            emp.TitleOfCourtesy,
                            emp.FirstName,
                            emp.LastName

                        };
            var result = from ord in nw.Shippers
                    join t in nw.Orders on ord.ShipperID equals t.Shipper.ShipperID
                    select new
                    {
                        ord.ShipperID,
                        ord.CompanyName,
                        t.Customer.ContactName,
                        t.CustomerID,
                        t.Employee.FirstName,
                        t.ShipAddress,
                        t.ShipCity,
                        t.ShipCountry
                    };

            this.empDataGrid.ItemsSource = query.ToList();
            this.ordDataGrid.ItemsSource = result.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            add a = new add();
            a.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            update a = new update();
            a.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            delete a = new delete();
            a.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
