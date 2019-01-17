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
using Management_Application.Model;

namespace Management_Application.ViewSales
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        List<Output> listOrderProducts { get; set; }
        List<Product> listProducts { get; set; }
        List<Status> listStatus { get; set; }

        private float totalOrder = 0;
        private int amountOrder = 0;

        public OrderManagement(List<Output> data)
        {
            InitializeComponent();
            listStatus = new List<Status>();
            listStatus = DataProvider.ins.db.Status.ToList();

            getData(data);
            List<int> listDiscount = new List<int>() { 0, 10, 15, 20, 25, 30, 40, 50, 75, 90, 100 };
            comboboxDiscount.ItemsSource = listDiscount;
            listViewOrder.ItemsSource = listOrderProducts;

            handlingData();
        }

        void getData(List<Output> data)
        {
            if (data != null) {
                listOrderProducts = data;
                chipCustomerName.Content = data[0].Order.Customer.NameCustomer;
            }
        }

        void handlingData()
        {
            float total = 0;
            int amount = 0;
            foreach(var item in listOrderProducts)
            {
                total += ((item.Price??0) * (float)item.Amount)*(((float)100 - (float)item.Discount)/(float)100);
                amount += (item.Amount ?? 0);
            }
            txtboxNumberItem.Text = listOrderProducts.Count.ToString();
            txtboxTotalItem.Text = total.ToString(".0##");
            totalOrder = total * ((float)100 - (float)(int)comboboxDiscount.SelectedItem)/(float)100;
            amountOrder = amount;
            txtboxtotal.Text = totalOrder.ToString(".0##");
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem row = sender as ListViewItem;
            Output output = row.DataContext as Output;
            AddDiscount window = new AddDiscount(output);
            window.ShowDialog();
            
            for(int i = 0; i < listOrderProducts.Count; i++)
            {
                if(listOrderProducts[i].IDProduct == output.IDProduct)
                {
                    listOrderProducts[i].Discount = AddDiscount.discount;
                    break;
                }
            }

            handlingData();
            listViewOrder.ItemsSource = null;
            listViewOrder.ItemsSource = listOrderProducts;
        }

        void resetData()
        {
            foreach (var item in listOrderProducts)
            {
                Product product = DataProvider.ins.db.Products.Find(item.IDProduct);
                product.Amount += item.Amount;
            }

            try
            {
                DataProvider.ins.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Some errors have occurred!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //listOrderProducts.Clear();
            //listViewOrder.ItemsSource = null;
            //listViewOrder.ItemsSource = listOrderProducts;
            
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            resetData();
            this.Close();
        }

        private void ButtonPay_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to pay for these orders?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                Order order = new Order();
                order = listOrderProducts[0].Order;
                order.TotalItem = totalOrder;
                order.Amount = amountOrder;
                order.Discount = (int)comboboxDiscount.SelectedItem;
                order.IDCustomer = order.Customer.IDCustomer;
                order.DateSale = DateTime.Now;
                float temp;
                if (float.TryParse(txtboxStake.Text, out temp))
                {
                    order.Deposite = float.Parse(txtboxStake.Text);
                }

                if (checkBoxStaked.IsChecked == true)
                {
                    order.Status = DataProvider.ins.db.Status.Find(3);
                }
                else
                {
                    order.Status = DataProvider.ins.db.Status.Find(2);
                }
                order.IDStatus = order.Status.IDStatus;

                //try
                //{
                    DataProvider.ins.db.Orders.Add(order);
                    for (int i = 0; i < listOrderProducts.Count; i++)
                    {
                        listOrderProducts[i].Order = order;
                        DataProvider.ins.db.Outputs.Add(listOrderProducts[i]);
                    }
                    DataProvider.ins.db.SaveChanges();
                    MessageBox.Show("Successful Payment", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
                //catch(Exception error)
                //{
                //    resetData();
                //    //MessageBox.Show("Unsuccessful Payment", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                //    MessageBox.Show(error.ToString(), "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);

                //}
                this.Close();
            }
        }

        private void comboboxDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            handlingData();
        }
    }
}
