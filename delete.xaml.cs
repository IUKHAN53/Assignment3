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
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public delete()
        {

            InitializeComponent();
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();

            var res = from pd in nw.Products
                      select new
                      {
                          pd.ProductName
                      };
            foreach (var item in res)
            {
                productC.Items.Add(item.ProductName.ToString());
            }

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            string item = productC.SelectedItem.ToString();
            NORTHWNDEntities1 nw = new NORTHWNDEntities1();
            var order = from x in nw.Order_Details
                        join v in nw.Products on x.ProductID equals v.ProductID
                        where v.ProductName==item
                        select x;
            foreach (Order_Detail res in order)
            {
                nw.Order_Details.Remove(res);
                
            }
            nw.SaveChanges();


            var query = from x in nw.Products
                        where x.ProductName == item
                        select x;
            Product result = query.SingleOrDefault();
            if (result != null)
            {
                nw.Products.Remove(result);
                nw.SaveChanges();
                confirmLbl.Content = "Product "+item+" Deleted from Database";
            }
            else
            {
                MessageBox.Show("An Error Occured");
            }
        }
    }
}
