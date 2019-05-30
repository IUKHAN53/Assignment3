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
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {
        public update()
        {
            InitializeComponent();
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            int cat = 0;
            int sup = 0;

            var res = from pd in nw.Products
                      select new
                      {
                          pd.ProductName
                      };
            foreach (var item in res)
            {
                NameC.Items.Add(item.ProductName.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void selc(object sender, SelectionChangedEventArgs e)
        {
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            string cat = "";
            var result = from pd in nw.Products
                         join ct in nw.Categories on pd.CategoryID equals ct.CategoryID
                         select new
                         {
                             ct.CategoryName
                         };
            foreach (var item in result)
            {
                cat = item.CategoryName.ToString();
            }
            CategoryF.Text = cat;
            var res = from pd in nw.Products
                      join sp in nw.Suppliers on pd.SupplierID equals sp.SupplierID
                      select new
                      {
                          sp.CompanyName
                      };
            foreach (var item in res)
            {
                cat = item.CompanyName.ToString();
            }
            SupplierF.Text = cat;
            var query = from pd in nw.Products
                        where pd.ProductName == NameC.SelectedItem
                        select pd;
            Product p = query.SingleOrDefault();
            if (query != null)
            {
                //p.Category = new Category()
                //{
                //    CategoryName = CategoryF.Text,
                //    CategoryID = 555
                //};
                //p.Supplier = new Supplier()
                //{
                //    SupplierID = 222,
                //    CompanyName = SupplierF.Text
                //};
                //p.UnitPrice = decimal.Parse(PriceF.Text);
                //p.QuantityPerUnit = QuantityF.Text;
            }
            nw.SaveChanges();
        }
    }
}