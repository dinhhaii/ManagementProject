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

namespace Management_Application.ViewImport
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : UserControl
    {
        List<Input> listInputs { get; set; }
        List<Input> filterInputs { get; set; }
        bool isDeleted = false;
        bool isUpdating = true;

        public Import()
        {
            InitializeComponent();
            listInputs = new List<Input>();
            filterInputs = new List<Input>();

            //Get Input
            listInputs = DataProvider.ins.db.Inputs.ToList();

            //DataGrid ItemSource
            dataGridInput.ItemsSource = listInputs;
        }

        //[UPDATE][DELETE] Click Cell in DataGrid
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Input temp = row.Item as Input;

            if (isDeleted == true)
            {
                for (int i = 0; i < listInputs.Count; i++)
                {
                    if (listInputs[i].IDProduct == temp.IDProduct && listInputs[i].Serial == temp.Serial)
                    {
                        if (listInputs[i].isSelected == true)
                        {
                            listInputs[i].isSelected = false;
                        }
                        else
                        {
                            listInputs[i].isSelected = true;
                        }
                    }
                }
                dataGridInput.ItemsSource = null;
                dataGridInput.ItemsSource = listInputs;
            }

            if (isUpdating == true)
            {
                UpdateImport window = new UpdateImport(temp);
                window.ShowDialog();
                reloadData();
            }
        }

        //======================CHECKBOX======================
        //[DELETE] All Input Checked
        private void checkBoxDeleteAll_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            if (checkBox.IsChecked == true)
            {
                for (int i = 0; i < listInputs.Count; i++)
                {
                    listInputs[i].isSelected = true;
                }
            }
            else
            {
                for (int i = 0; i < listInputs.Count; i++)
                {
                    listInputs[i].isSelected = false;
                }
            }
            dataGridInput.ItemsSource = null;
            dataGridInput.ItemsSource = listInputs;
        }

        //[DELETE] Checked and UnChecked Input
        private void checkBoxDelete_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            int index = dataGridRow.GetIndex();
            if (index < listInputs.Count)
            {
                if (checkBox.IsChecked == false)
                {
                    dataGridRow.Background = Brushes.Transparent;
                    listInputs[index].isSelected = false;
                }
                if (checkBox.IsChecked == true)
                {
                    dataGridRow.Background = Brushes.Red;
                    listInputs[index].isSelected = true;
                }
            }
        }


        //======================RELOAD/ADD/DELETE/FILTER======================
        //FILTER
        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterImport window = new FilterImport();
            window.ShowDialog();
            filterInputs = FilterImport.filterList;

            dataGridInput.ItemsSource = null;
            dataGridInput.ItemsSource = filterInputs;

            buttonDelete.Visibility = Visibility.Collapsed;
            buttonReload.Visibility = Visibility.Collapsed;
            buttonCloseFilter.Visibility = Visibility.Visible;
            buttonFilter.Background = Brushes.Red;
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
            listInputs.Clear();
            listInputs = DataProvider.ins.db.Inputs.ToList();
            dataGridInput.ItemsSource = null;
            dataGridInput.ItemsSource = listInputs;
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
                foreach (Input item in listInputs)
                {
                    if (item != null && item.isSelected == true)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Inputs?", "Management Application", MessageBoxButton.YesNo, MessageBoxImage.Hand);
                        if (result == MessageBoxResult.Yes)
                        {
                            //Remove input data
                            DataProvider.ins.db.Inputs.Remove(item);
                            //Update product data
                            Product itemUpdate = DataProvider.ins.db.Products.Find(item.IDProduct);
                            itemUpdate.Amount -= item.Amount;

                            DataProvider.ins.db.SaveChanges();
                            MessageBox.Show("Delete successfully!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
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
                dataGridInput.Columns[0].Visibility = Visibility.Visible;
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
                dataGridInput.Columns[0].Visibility = Visibility.Collapsed;

                listInputs = DataProvider.ins.db.Inputs.ToList();
                for (int i = 0; i < listInputs.Count; i++)
                {
                    listInputs[i].isSelected = false;
                }
                dataGridInput.ItemsSource = null;
                dataGridInput.ItemsSource = listInputs;
            }

        }

        //======================SEARCH======================
        private bool isSearching = false;

        private void searchItem()
        {
            for (int i = 0; i < listInputs.Count; i++)
            {
                string str = listInputs[i].Name.Trim().ToLower().Replace(" ", "");
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
                    int pos = listInputs[i].Name.ToLower().IndexOf(token[index]);
                    int pos1 = listInputs[i].Category.NameCategory.ToLower().IndexOf(token[index]);
                    int pos2 = listInputs[i].IDProduct.ToLower().IndexOf(token[index]);

                    //Nếu không xuất hiện 
                    if (pos < 0 && pos1 < 0 && pos2 < 0)
                    {
                        break;
                    }
                }
                if (index == token.Length)
                {
                    filterInputs.Add(listInputs[i]);
                }
            }
        }

        //TextChanged
        private void txtboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxSearch.Text == "" || txtboxSearch.Text == null)
            {
                filterInputs.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Search;
                isSearching = false;
                dataGridInput.ItemsSource = null;
                dataGridInput.ItemsSource = listInputs;
            }
            else
            {
                filterInputs.Clear();
                iconSearch.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
                isSearching = true;
                searchItem();
                dataGridInput.ItemsSource = null;
                dataGridInput.ItemsSource = filterInputs;
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
