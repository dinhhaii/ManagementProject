using Management_Application.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Management_Application.ViewProducts
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        List<Product> listProducts { get; set; }
        List<Product> filterProducts { get; set; }
        public Products()
        {
            InitializeComponent();
            listProducts = new List<Product>();
            filterProducts = new List<Product>();

            //Get Product
            listProducts = DataProvider.ins.db.Products.ToList();
          
            //DataGrid ItemSource
            dataGridProduct.ItemsSource = listProducts;
        }

        //[UPDATE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        //======================CHECKBOX======================
        //[DELETE] All Product Checked
        private void checkBoxDeleteAll_CheckedUnChecked(object sender, RoutedEventArgs e)
        {

        }

        //[DELETE] Checked and UnChecked Product
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {

        }


        //======================RELOAD/ADD/DELETE/UPDATE======================
        //RELOAD
        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = listProducts;
        }

        //ADD
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct window = new AddProduct();
            window.ShowDialog();
        }

        //DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct window = new UpdateProduct();
            window.ShowDialog();
        }

        //======================SEARCH======================
        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //Clear input data
        private void buttonClearSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        //Click button Search
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        

       
    }
}
