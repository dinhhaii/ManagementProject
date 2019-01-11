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
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            if (checkBox.IsChecked == true)
            {
                for (int i = 0; i < listProducts.Count; i++)
                {
                    listProducts[i].isSelected = true;
                }
            }
            else
            {
                for (int i = 0; i < listProducts.Count; i++)
                {
                    listProducts[i].isSelected = false;
                }
            }
            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = listProducts;
        }

        //[DELETE] Checked and UnChecked Product
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            int index = dataGridRow.GetIndex();
            if (index < listProducts.Count)
            {
                if (checkBox.IsChecked == false)
                {
                    dataGridRow.Background = Brushes.Transparent;
                    listProducts[index].isSelected = false;
                }
                if (checkBox.IsChecked == true)
                {
                    dataGridRow.Background = Brushes.Red;
                    listProducts[index].isSelected = true;
                }
            }
        }


        //======================RELOAD/ADD/DELETE/UPDATE======================
        //RELOAD
        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            listProducts.Clear();
            listProducts = DataProvider.ins.db.Products.ToList();
            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = listProducts;
        }

        //ADD
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct window = new AddProduct();
            window.ShowDialog();
            buttonReload_Click(sender, e);
        }

        //DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product item in listProducts)
            {
                if (item != null && item.isSelected == true)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Products?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.ins.db.Products.Remove(item);
                        var itemInput = DataProvider.ins.db.Inputs.SingleOrDefault(x => x.IDProduct == item.IDProduct);
                        DataProvider.ins.db.Inputs.Remove(itemInput);
                        DataProvider.ins.db.SaveChanges();
                        MessageBox.Show("Delete successfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                        buttonReload_Click(sender, e);
                    }
                    break;
                }
            }

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
