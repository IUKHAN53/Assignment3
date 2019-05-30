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
using System.Windows.Shapes;

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : Window
    {
        public add()
        {
            InitializeComponent();
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            var query = from sp in nw.Suppliers
                        select new
                        {
                            sp.CompanyName

                        };
            foreach (var item in query)
            {
                SupplierC.Items.Add(item.CompanyName.ToString()) ;
            }
            var result = from ct in nw.Categories
                         select new
                         {
                             ct.CategoryName

                        };
            foreach (var item in result)
            {
                CategoryC.Items.Add(item.CategoryName.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            int cat = 0;
            int sup = 0;

            var res = from sp in nw.Suppliers
                      where sp.CompanyName == SupplierC.SelectedItem.ToString()
                      select new
                      {
                          sp.SupplierID
                      };
            foreach (var item in res)
            {
                sup = item.SupplierID;
            }
            var result = from ct in nw.Categories
                      where ct.CategoryName == CategoryC.SelectedItem.ToString()
                      select new
                      {
                          ct.CategoryID
                      };
            foreach(var item in result)
            {
                 cat = item.CategoryID;
            }
            Console.WriteLine(cat +""+ sup);

            nw.Products.Add(new Product()
            {
                ProductName = NameF.Text,
                CategoryID = cat,
                SupplierID = sup,
                UnitsInStock = short.Parse(QuantityF.Text),
                UnitPrice = int.Parse(PriceF.Text)

               }) ;
            nw.SaveChanges();

        }
    }
}
