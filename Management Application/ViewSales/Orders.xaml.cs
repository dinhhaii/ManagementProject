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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        List<Order> listOrders { get; set; }
        List<Order> filterOrders { get; set; }
        bool isDeleted = false;
        bool isUpdating = true;

        public Orders()
        {
            InitializeComponent();
            listOrders = new List<Order>();
            filterOrders = new List<Order>();

            //Get Order
            listOrders = DataProvider.ins.db.Orders.ToList();

            //DataGrid ItemSource
            dataGridOrder.ItemsSource = listOrders;
        }

        //[UPDATE][DELETE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Order temp = row.Item as Order;

            if (isDeleted == true)
            {
                for (int i = 0; i < listOrders.Count; i++)
                {
                    if (listOrders[i].IDOrder == temp.IDOrder)
                    {
                        if (listOrders[i].isSelected == true)
                        {
                            listOrders[i].isSelected = false;
                        }
                        else
                        {
                            listOrders[i].isSelected = true;
                        }
                    }
                }
                dataGridOrder.ItemsSource = null;
                dataGridOrder.ItemsSource = listOrders;
            }

            if (isUpdating == true)
            {
                //UpdateOrder window = new UpdateOrder(temp);
                //window.ShowDialog();
                //reloadData();
                Outputs window = new Outputs(temp);
                window.ShowDialog();
                reloadData();
            }
        }

        //======================CHECKBOX======================
        //[DELETE] All Order Checked
        private void checkBoxDeleteAll_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            if (checkBox.IsChecked == true)
            {
                for (int i = 0; i < listOrders.Count; i++)
                {
                    listOrders[i].isSelected = true;
                }
            }
            else
            {
                for (int i = 0; i < listOrders.Count; i++)
                {
                    listOrders[i].isSelected = false;
                }
            }
            dataGridOrder.ItemsSource = null;
            dataGridOrder.ItemsSource = listOrders;
        }

        //[DELETE] Checked and UnChecked Order
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            int index = dataGridRow.GetIndex();
            if (index < listOrders.Count)
            {
                if (checkBox.IsChecked == false)
                {
                    dataGridRow.Background = Brushes.Transparent;
                    listOrders[index].isSelected = false;
                }
                if (checkBox.IsChecked == true)
                {
                    dataGridRow.Background = Brushes.Red;
                    listOrders[index].isSelected = true;
                }
            }
        }


        //======================RELOAD/ADD/DELETE/FILTER======================
        //FILTER
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            //FilterOrder window = new FilterOrder();
            //window.ShowDialog();
            //filterOrders = FilterOrder.filterList;
            //
            //dataGridOrder.ItemsSource = null;
            //dataGridOrder.ItemsSource = filterOrders;
            //
            //buttonAdd.Visibility = Visibility.Collapsed;
            //buttonDelete.Visibility = Visibility.Collapsed;
            //buttonReload.Visibility = Visibility.Collapsed;
            //buttonCloseFilter.Visibility = Visibility.Visible;
            //buttonFilter.Background = Brushes.Red;
        }

        private void buttonCloseFilter_Click(object sender, RoutedEventArgs e)
        {
            buttonDelete.Visibility = Visibility.Visible;
            buttonReload.Visibility = Visibility.Visible;
            buttonCloseFilter.Visibility = Visibility.Collapsed;
            buttonFilter.Background = Brushes.Black;
            reloadData();
        }

        //RELOAD
        void reloadData()
        {
            listOrders.Clear();
            listOrders = DataProvider.ins.db.Orders.ToList();
            dataGridOrder.ItemsSource = null;
            dataGridOrder.ItemsSource = listOrders;
        }

        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            reloadData();
        }

        //DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleted == true)
            {
                bool deleteSuccess = true;
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Orders?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < listOrders.Count; i++)
                    {
                        if (listOrders[i] != null && listOrders[i].isSelected == true)
                        {

                            try
                            {
                                DataProvider.ins.db.Orders.Remove(listOrders[i]);
                                List<Output> listOutput = DataProvider.ins.db.Outputs.ToList();
                                foreach (var outputItem in listOutput)
                                {
                                    var itemOutput = DataProvider.ins.db.Outputs.Find(outputItem.IDProduct, listOrders[i].IDOrder);
                                    if (itemOutput != null)
                                    {
                                        DataProvider.ins.db.Outputs.Remove(itemOutput);
                                    }
                                }
                                DataProvider.ins.db.SaveChanges();
                                deleteSuccess = true;
                            }
                            catch
                            {
                                deleteSuccess = false;
                            }

                        }
                    }

                    if (deleteSuccess)
                    {
                        MessageBox.Show("Delete successfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Delete unsuccessfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                isDeleted = true;
                isUpdating = false;
                closeDelete.Visibility = Visibility.Visible;
                buttonReload.Visibility = Visibility.Collapsed;
                buttonFilter.Visibility = Visibility.Collapsed;
                buttonDelete.Background = Brushes.Red;
                dataGridOrder.Columns[0].Visibility = Visibility.Visible;
            }

            reloadData();
        }

        private void buttoncloseDelete_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleted == true)
            {
                isDeleted = false;
                isUpdating = true;
                closeDelete.Visibility = Visibility.Collapsed;
                buttonReload.Visibility = Visibility.Visible;
                buttonFilter.Visibility = Visibility.Visible;
                buttonDelete.Background = Brushes.Black;
                dataGridOrder.Columns[0].Visibility = Visibility.Collapsed;

                listOrders = DataProvider.ins.db.Orders.ToList();
                for (int i = 0; i < listOrders.Count; i++)
                {
                    listOrders[i].isSelected = false;
                }
                dataGridOrder.ItemsSource = null;
                dataGridOrder.ItemsSource = listOrders;
            }

        }

        //======================SEARCH======================
        private bool isSearching = false;

        private void searchItem()
        {
            for (int i = 0; i < listOrders.Count; i++)
            {
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
                    int pos = listOrders[i].IDOrder.ToString().ToLower().IndexOf(token[index]);
                    int pos1 = listOrders[i].Customer.NameCustomer.ToLower().IndexOf(token[index]);

                    //Nếu không xuất hiện 
                    if (pos < 0 && pos1 < 0)
                    {
                        break;
                    }
                }
                if (index == token.Length)
                {
                    filterOrders.Add(listOrders[i]);
                }
            }
        }

        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxSearch.Text == "" || txtboxSearch.Text == null)
            {
                filterOrders.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Search;
                isSearching = false;
                dataGridOrder.ItemsSource = null;
                dataGridOrder.ItemsSource = listOrders;
            }
            else
            {
                filterOrders.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
                isSearching = true;
                searchItem();
                dataGridOrder.ItemsSource = null;
                dataGridOrder.ItemsSource = filterOrders;
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


    }
}
