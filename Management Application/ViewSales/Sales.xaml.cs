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
using Management_Application.Model;

namespace Management_Application.ViewSales
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : UserControl
    {
        List<Product> listProducts { get; set; }
        List<Product> filterProducts { get; set; }
        List<Customer> listCustomers { get; set; }
        List<Output> listOrderProducts { get; set; }
        List<string> listCustomerName { get; set; }

        public Sales()
        {
            InitializeComponent();
            listProducts = new List<Product>();
            filterProducts = new List<Product>();
            listCustomers = new List<Customer>();
            listOrderProducts = new List<Output>();

            //Get Data
            listCustomers = DataProvider.ins.db.Customers.ToList();

            //DataGrid ItemSource
            reloadProduct();

            //ComboBox Customer
            reloadCustomer();
        }

        //===============COMBOBOX CUSTOMER==============
        //Customer Name List
        List<string> getCustomerNameList()
        {
            List<string> result = new List<string>();

            foreach(var item in listCustomers)
            {
                result.Add(item.NameCustomer);
            }

            return result;
        }

        private void comboboxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboboxCustomer.SelectedItem != null)
            {
                string name = comboboxCustomer.SelectedItem as string;
                Customer customer = DataProvider.ins.db.Customers.Find(name);

                txtblockCustomer.Visibility = Visibility.Collapsed;
                comboboxCustomer.Visibility = Visibility.Collapsed;
                chipCustomerName.Visibility = Visibility.Visible;
                chipCustomerName.Content = name;
            }
        }


        private void chipCustomerName_DeleteClick(object sender, RoutedEventArgs e)
        {
            comboboxCustomer.SelectedItem = null;
            txtblockCustomer.Visibility = Visibility.Visible;
            comboboxCustomer.Visibility = Visibility.Visible;
            chipCustomerName.Visibility = Visibility.Collapsed;
        }


        //=======================DATAGRID=======================
        

        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Product temp = row.Item as Product;
            bool isAdded = false;

            Order order = new Order();
            order.IDOrder = DataProvider.ins.db.Orders.Count() + 1;
            if(comboboxCustomer.SelectedItem != null)
            {
                order.Customer = comboboxCustomer.SelectedItem as Customer;
                order.IDCustomer = order.Customer.IDCustomer;
            }

            Output export = new Output();
            export.Product = temp;
            export.IDProduct = temp.IDProduct;
            export.Name = temp.Name;
            export.Category = temp.Category;
            export.IDCategory = temp.IDCategory;
            export.Discount = 0;
            export.Price = temp.Price;
            export.IDOrder = DataProvider.ins.db.Orders.Count() + 1;
            export.Order = order;

            

            
            foreach (var item in listOrderProducts)
            {
                if (item.IDProduct == export.IDProduct && item.IDOrder == export.IDOrder)
                { 
                    Product product = DataProvider.ins.db.Products.Find(item.IDProduct);
                    if (product.Amount > 0)
                    {
                        product.Amount -= 1;
                        item.Amount += 1;
                        isAdded = true;
                        break;
                    }
                    else
                    {
                        isAdded = true;
                        MessageBox.Show("Number of products has exceeded the limit", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            if (!isAdded)
            {
                export.Amount = 1;
                Product product = DataProvider.ins.db.Products.Find(export.IDProduct);
                product.Amount -= 1;
                listOrderProducts.Add(export);
                isAdded = true;
            }

            try
            {
                DataProvider.ins.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Some errors have occurred!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            listViewOrder.ItemsSource = null;
            listViewOrder.ItemsSource = listOrderProducts;
            reloadProduct();
        }

        //======================RELOAD======================

        void reloadCustomer()
        {
            if(listCustomerName != null)
                listCustomerName.Clear();
            if(listCustomers!=null)
                listCustomers.Clear();
            listCustomers = DataProvider.ins.db.Customers.ToList();
            listCustomerName = getCustomerNameList();
            comboboxCustomer.ItemsSource = null;
            comboboxCustomer.ItemsSource = listCustomerName;
        }

        void reloadProduct()
        {
            if(listProducts != null)
                listProducts.Clear();
            listProducts = DataProvider.ins.db.Products.ToList();
            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = listProducts;
        }

        //======================SEARCH======================
        private bool isSearching = false;

        private void searchItem()
        {
            for (int i = 0; i < listProducts.Count; i++)
            {
                string str = listProducts[i].Name.Trim().ToLower().Replace(" ", "");
                //Tách chuỗi nhập vào thành các từ
                string expression = txtboxSearch.Text.ToLower();
                string[] token = expression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int index = 0;
                //Duyệt qua mảng các từ trong chuỗi nhập
                for (; index < token.Length; index++)
                {
                    //Xóa khoảng trắng
                    token[index] = token[index].Trim();
                    //Kiểm tra từ đó xuất hiện trong tên sản phẩm không
                    int pos = listProducts[i].Name.ToLower().IndexOf(token[index]);
                    int pos1 = listProducts[i].Category.NameCategory.ToLower().IndexOf(token[index]);
                    int pos2 = listProducts[i].IDProduct.ToLower().IndexOf(token[index]);

                    //Nếu không xuất hiện 
                    if (pos < 0 && pos1 < 0 && pos2 < 0)
                    {
                        break;
                    }
                }
                if (index == token.Length)
                {
                    filterProducts.Add(listProducts[i]);
                }
            }
        }

        //TextChanged Search
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxSearch.Text == "" || txtboxSearch.Text == null)
            {
                filterProducts.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Search;
                isSearching = false;
                dataGridProduct.ItemsSource = null;
                dataGridProduct.ItemsSource = listProducts;
            }
            else
            {
                filterProducts.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
                isSearching = true;
                searchItem();
                dataGridProduct.ItemsSource = null;
                dataGridProduct.ItemsSource = filterProducts;
            }
        }

        //Click button Search
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (isSearching == true)
            {
                txtboxSearch.Text = "";
            }
        }

        //===================LISTVIEW===================

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Output output = ((FrameworkElement)sender).DataContext as Output;

            if (output != null)
            {
                if (output.Amount > 0)
                {
                    Product product = DataProvider.ins.db.Products.Find(output.IDProduct);
                    product.Amount += 1;
                    output.Amount -= 1;
                    if(output.Amount == 0)
                    {
                        listOrderProducts.Remove(output);
                    }
                    try
                    {
                        DataProvider.ins.db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Some errors have occurred!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            listViewOrder.ItemsSource = null;
            listViewOrder.ItemsSource = listOrderProducts;
            reloadProduct();
        }

    }
}