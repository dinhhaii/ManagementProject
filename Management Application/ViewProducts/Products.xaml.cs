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
        bool isDeleted = false;
        bool isUpdating = true;

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

        //[UPDATE][DELETE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Product temp = row.Item as Product;

            if (isDeleted == true)
            {
                for(int i = 0; i < listProducts.Count; i++)
                {
                    if(listProducts[i].IDProduct == temp.IDProduct)
                    {
                        if (listProducts[i].isSelected == true)
                        {
                            listProducts[i].isSelected = false;
                        }
                        else
                        {
                            listProducts[i].isSelected = true;
                        }
                    }
                }
                dataGridProduct.ItemsSource = null;
                dataGridProduct.ItemsSource = listProducts;
            }

            if (isUpdating == true)
            {
                UpdateProduct window = new UpdateProduct(temp);
                window.ShowDialog();
                reloadData();
            }
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


        //======================RELOAD/ADD/DELETE/FILTER======================
        //FILTER
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterProduct window = new FilterProduct();
            window.ShowDialog();
            filterProducts = FilterProduct.filterList;

            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = filterProducts;

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
            listProducts.Clear();
            listProducts = DataProvider.ins.db.Products.ToList();
            dataGridProduct.ItemsSource = null;
            dataGridProduct.ItemsSource = listProducts;
        }

        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            reloadData();
        }

        //ADD
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct window = new AddProduct();
            window.ShowDialog();
            reloadData();
        }

        //DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleted == true)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Products?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < listProducts.Count; i++)
                    {
                        if (listProducts[i] != null && listProducts[i].isSelected == true)
                        {
                            List<Input> listInput = DataProvider.ins.db.Inputs.ToList();
                            DataProvider.ins.db.Products.Remove(listProducts[i]);
                            DataProvider.ins.db.SaveChanges();
                            foreach (var value in listInput)
                            {
                                var itemInput = DataProvider.ins.db.Inputs.Find(listProducts[i].IDProduct, value.Serial);
                                if (itemInput != null)
                                {
                                    DataProvider.ins.db.Inputs.Remove(itemInput);
                                    DataProvider.ins.db.SaveChanges();
                                }
                            }
                        }
                    }
                    reloadData();
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
                dataGridProduct.Columns[0].Visibility = Visibility.Visible;
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
                buttonAdd.Visibility = Visibility.Visible;
                buttonFilter.Visibility = Visibility.Visible;
                buttonDelete.Background = Brushes.Black;
                dataGridProduct.Columns[0].Visibility = Visibility.Collapsed;

                listProducts = DataProvider.ins.db.Products.ToList();
                for(int i = 0; i < listProducts.Count; i++)
                {
                    listProducts[i].isSelected = false;
                }
                dataGridProduct.ItemsSource = null;
                dataGridProduct.ItemsSource = listProducts;
            }

        }

        //======================SEARCH======================
        private bool isSearching = false;

        private void searchItem()
        {
            for(int i = 0; i < listProducts.Count; i++)
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

        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtboxSearch.Text == "" || txtboxSearch.Text == null)
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


    }
}
