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
    /// Interaction logic for Outputs.xaml
    /// </summary>
    public partial class Outputs : Window
    {
        List<Output> listOutputs { get; set; }
        List<Output> listOutputOrder { get; set; }
        List<Output> filterOutputs { get; set; }
        bool isDeleted = false;
        bool isUpdating = true;

        private int idOrder { get; set; }
        private Order receivedData { get; set; }

        public Outputs(Order data)
        {
            InitializeComponent();
            listOutputs = new List<Output>();
            filterOutputs = new List<Output>();
            listOutputOrder = new List<Output>();

            idOrder = data.IDOrder;
            receivedData = data;

            groupbox.Header = "Order (ID = " + idOrder.ToString() + ") - " + receivedData.Status.NameStatus;

            if(receivedData.IDStatus != 1)
            {
                buttonDone.IsEnabled = true;
            }
            else
            {
                buttonDone.IsEnabled = false;
            }

            reloadData();
        }

        //[UPDATE][DELETE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Output temp = row.Item as Output;

            //if (isDeleted == true)
            //{
            //    for (int i = 0; i < listOutputs.Count; i++)
            //    {
            //        if (listOutputs[i].IDOutput == temp.IDOutput)
            //        {
            //            if (listOutputs[i].isSelected == true)
            //            {
            //                listOutputs[i].isSelected = false;
            //            }
            //            else
            //            {
            //                listOutputs[i].isSelected = true;
            //            }
            //        }
            //    }
            //    dataGridOutput.ItemsSource = null;
            //    dataGridOutput.ItemsSource = listOutputs;
            //}

            if (isUpdating == true)
            {
                //UpdateOutput window = new UpdateOutput(temp);
                //window.ShowDialog();
                //reloadData();


            }
        }

        //======================CHECKBOX======================
        //[DELETE] All Output Checked
        private void checkBoxDeleteAll_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            if (checkBox.IsChecked == true)
            {
                for (int i = 0; i < listOutputs.Count; i++)
                {
                    listOutputs[i].isSelected = true;
                }
            }
            else
            {
                for (int i = 0; i < listOutputs.Count; i++)
                {
                    listOutputs[i].isSelected = false;
                }
            }
            dataGridOutput.ItemsSource = null;
            dataGridOutput.ItemsSource = listOutputs;
        }

        //[DELETE] Checked and UnChecked Output
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            int index = dataGridRow.GetIndex();
            if (index < listOutputs.Count)
            {
                if (checkBox.IsChecked == false)
                {
                    dataGridRow.Background = Brushes.Transparent;
                    listOutputs[index].isSelected = false;
                }
                if (checkBox.IsChecked == true)
                {
                    dataGridRow.Background = Brushes.Red;
                    listOutputs[index].isSelected = true;
                }
            }
        }


        //======================RELOAD/ADD/DELETE/FILTER======================
        //FILTER
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            //FilterOutput window = new FilterOutput();
            //window.ShowDialog();
            //filterOutputs = FilterOutput.filterList;
            //
            //dataGridOutput.ItemsSource = null;
            //dataGridOutput.ItemsSource = filterOutputs;
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
            if (listOutputs != null)
            {
                listOutputs.Clear();
            }
            listOutputs = DataProvider.ins.db.Outputs.ToList();
            foreach (var item in listOutputs)
            {
                if (item.IDOrder == idOrder)
                {
                    listOutputOrder.Add(item);
                }
            }

            //DataGrid ItemSource
            dataGridOutput.ItemsSource = null;
            dataGridOutput.ItemsSource = listOutputOrder;
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
                foreach (Output item in listOutputOrder)
                {
                    if (item != null && item.isSelected == true)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Outputs?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                        if (result == MessageBoxResult.Yes)
                        {
                            try
                            {
                                DataProvider.ins.db.Outputs.Remove(item);
                                List<Output> listOutput = DataProvider.ins.db.Outputs.ToList();
                                var itemOrder = DataProvider.ins.db.Orders.Find(item.IDOrder);
                                itemOrder.TotalItem -= item.Price * (float)item.Amount * ((float)100 - (float)item.Discount) / (float)100;
                                DataProvider.ins.db.SaveChanges();
                                MessageBox.Show("Delete successfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch
                            {
                                MessageBox.Show("Delete unsuccessfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            reloadData();
                        }
                        break;
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
                dataGridOutput.Columns[0].Visibility = Visibility.Visible;
            }
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
                dataGridOutput.Columns[0].Visibility = Visibility.Collapsed;

                listOutputs = DataProvider.ins.db.Outputs.ToList();
                for (int i = 0; i < listOutputs.Count; i++)
                {
                    listOutputs[i].isSelected = false;
                }
                reloadData();
            }

        }

        //======================SEARCH======================
        private bool isSearching = false;

        private void searchItem()
        {
            for (int i = 0; i < listOutputs.Count; i++)
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
                    int pos = listOutputs[i].IDProduct.ToString().ToLower().IndexOf(token[index]);
                    int pos1 = listOutputs[i].Name.ToLower().IndexOf(token[index]);
                    int pos2 = listOutputs[i].Category.NameCategory.ToLower().IndexOf(token[index]);
                    //Nếu không xuất hiện 
                    if (pos < 0 && pos1 < 0 && pos2 < 0)
                    {
                        break;
                    }
                }
                if (index == token.Length)
                {
                    filterOutputs.Add(listOutputs[i]);
                }
            }
        }

        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxSearch.Text == "" || txtboxSearch.Text == null)
            {
                filterOutputs.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Search;
                isSearching = false;
                dataGridOutput.ItemsSource = null;
                dataGridOutput.ItemsSource = listOutputs;
            }
            else
            {
                filterOutputs.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
                isSearching = true;
                searchItem();
                dataGridOutput.ItemsSource = null;
                dataGridOutput.ItemsSource = filterOutputs;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (receivedData.IDStatus != 1)
            {
                Order order = DataProvider.ins.db.Orders.Find(idOrder);
                order.Status = DataProvider.ins.db.Status.Find(1);
                order.IDStatus = order.Status.IDStatus;
                groupbox.Header = "Order (ID = " + idOrder.ToString() + ") - " + order.Status.NameStatus;
                buttonDone.IsEnabled = false;
                DataProvider.ins.db.SaveChanges();
            }
        }
    }
}
