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

namespace Management_Application.ViewCustomer
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        List<Customer> listCustomers { get; set; }
        List<Customer> filterCustomers { get; set; }
        private bool isDeleted = false;
        private bool isUpdating = true;
        private bool isSearching = false;

        public Customers()
        {
            InitializeComponent();
            listCustomers = new List<Customer>();
            filterCustomers = new List<Customer>();

            //Get Customer
            listCustomers = DataProvider.ins.db.Customers.ToList();

            //DataGrid ItemSource
            dataGridCustomer.ItemsSource = listCustomers;
        }

        //[UPDATE][DELETE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Customer temp = row.Item as Customer;

            if (isDeleted == true)
            {
                for (int i = 0; i < listCustomers.Count; i++)
                {
                    if (listCustomers[i].IDCustomer == temp.IDCustomer)
                    {
                        if (listCustomers[i].isSelected == true)
                        {
                            listCustomers[i].isSelected = false;
                        }
                        else
                        {
                            listCustomers[i].isSelected = true;
                        }
                    }
                }
                dataGridCustomer.ItemsSource = null;
                dataGridCustomer.ItemsSource = listCustomers;
            }

            if (isUpdating == true)
            {
                UpdateCustomer window = new UpdateCustomer(temp);
                window.ShowDialog();
                reloadData();
            }
        }

        //======================CHECKBOX======================
        //[DELETE] All Customer Checked
        private void checkBoxDeleteAll_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            if (checkBox.IsChecked == true)
            {
                for (int i = 0; i < listCustomers.Count; i++)
                {
                    listCustomers[i].isSelected = true;
                }
            }
            else
            {
                for (int i = 0; i < listCustomers.Count; i++)
                {
                    listCustomers[i].isSelected = false;
                }
            }
            dataGridCustomer.ItemsSource = null;
            dataGridCustomer.ItemsSource = listCustomers;
        }

        //[DELETE] Checked and UnChecked Customer
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            int index = dataGridRow.GetIndex();
            if (index < listCustomers.Count)
            {
                if (checkBox.IsChecked == false)
                {
                    dataGridRow.Background = Brushes.Transparent;
                    listCustomers[index].isSelected = false;
                }
                if (checkBox.IsChecked == true)
                {
                    dataGridRow.Background = Brushes.Red;
                    listCustomers[index].isSelected = true;
                }
            }
        }


        //======================RELOAD/ADD/DELETE/FILTER======================
        //FILTER
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterCustomer window = new FilterCustomer();
            window.ShowDialog();
            filterCustomers = FilterCustomer.filterList;

            dataGridCustomer.ItemsSource = null;
            dataGridCustomer.ItemsSource = filterCustomers;

            buttonAdd.Visibility = Visibility.Collapsed;
            buttonDelete.Visibility = Visibility.Collapsed;
            buttonReload.Visibility = Visibility.Collapsed;
            buttonCloseFilter.Visibility = Visibility.Visible;
            buttonFilter.Background = Brushes.Red;
        }

        private void buttonCloseFilter_Click(object sender, RoutedEventArgs e)
        {
            buttonAdd.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Visible;
            buttonReload.Visibility = Visibility.Visible;
            buttonCloseFilter.Visibility = Visibility.Collapsed;
            buttonFilter.Background = Brushes.Black;
            reloadData();
        }

        //RELOAD
        void reloadData()
        {
            listCustomers.Clear();
            listCustomers = DataProvider.ins.db.Customers.ToList();
            dataGridCustomer.ItemsSource = null;
            dataGridCustomer.ItemsSource = listCustomers;
        }

        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            reloadData();
        }

        //ADD
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer window = new AddCustomer();
            window.ShowDialog();
            reloadData();
        }

        //DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            bool deletesuccess = false;
            if (isDeleted == true)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Customers?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (result == MessageBoxResult.Yes)
                {
                    for(int i =0;i<listCustomers.Count;i++)
                    {
                        if (listCustomers[i] != null && listCustomers[i].isSelected == true)
                        {
                            DataProvider.ins.db.Customers.Remove(listCustomers[i]);
                            DataProvider.ins.db.SaveChanges();
                            deletesuccess = false;
                        }
                    }
                }
            }
            else
            {
                isDeleted = true;
                isUpdating = false;
                closeDelete.Visibility = Visibility.Visible;
                buttonReload.Visibility = Visibility.Collapsed;
                buttonAdd.Visibility = Visibility.Collapsed;
                buttonFilter.Visibility = Visibility.Collapsed;
                buttonDelete.Background = Brushes.Red;
                dataGridCustomer.Columns[0].Visibility = Visibility.Visible;
            }
            if (deletesuccess)
            {
                MessageBox.Show("Delete successfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
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
                buttonAdd.Visibility = Visibility.Visible;
                buttonFilter.Visibility = Visibility.Visible;
                buttonDelete.Background = Brushes.Black;
                dataGridCustomer.Columns[0].Visibility = Visibility.Collapsed;

                listCustomers = DataProvider.ins.db.Customers.ToList();
                for (int i = 0; i < listCustomers.Count; i++)
                {
                    listCustomers[i].isSelected = false;
                }
                dataGridCustomer.ItemsSource = null;
                dataGridCustomer.ItemsSource = listCustomers;
            }

        }

        //======================SEARCH======================
        private void searchItem()
        {
            for (int i = 0; i < listCustomers.Count; i++)
            {
                string str = listCustomers[i].NameCustomer.Trim().ToLower().Replace(" ", "");
                string expression = txtboxSearch.Text.ToLower();
                string[] token = expression.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int index = 0;

                for (; index < token.Length; index++)
                {
                    token[index] = token[index].Trim();

                    int pos = listCustomers[i].NameCustomer.ToLower().IndexOf(token[index]);
                    int pos1 = listCustomers[i].Phone.ToLower().IndexOf(token[index]);
                    int pos2 = listCustomers[i].IDCustomer.ToLower().IndexOf(token[index]);
                    int pos3 = listCustomers[i].Address.ToLower().IndexOf(token[index]);

                    if (pos < 0 && pos1 < 0 && pos2 < 0 && pos3 < 0)
                    {
                        break;
                    }
                }
                if (index == token.Length)
                {
                    filterCustomers.Add(listCustomers[i]);
                }
            }
        }

        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxSearch.Text == "" || txtboxSearch.Text == null)
            {
                filterCustomers.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Search;
                isSearching = false;
                dataGridCustomer.ItemsSource = null;
                dataGridCustomer.ItemsSource = listCustomers;
            }
            else
            {
                filterCustomers.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
                isSearching = true;
                searchItem();
                dataGridCustomer.ItemsSource = null;
                dataGridCustomer.ItemsSource = filterCustomers;
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

