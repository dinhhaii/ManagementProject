using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Management_Application.Model;
using Microsoft.Win32;

namespace Management_Application.ViewProducts
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        List<Product> listProducts { get; set; }
        List<Category> listCategory { get; set; }
        List<Input> listInput { get; set; }
        int count { get; set; }

        public AddProduct()
        {
            InitializeComponent();
            listCategory = new List<Category>();
            listInput = new List<Input>();
            listProducts = new List<Product>();

            listCategory = DataProvider.ins.db.Categories.ToList();
            listInput = DataProvider.ins.db.Inputs.ToList();
            listProducts = DataProvider.ins.db.Products.ToList();
         
            processingData();
        }

        void processingData()
        {
            List<string> listIDProduct = createListIDProduct();

            comboboxCategory.ItemsSource = listCategory;
            comboboxIDProduct.ItemsSource = listIDProduct;
            datepickerDateEntry.Text = DateTime.Now.ToString();
            count = listInput.Count;
        }

        List<string> createListIDProduct()
        {
            listProducts = DataProvider.ins.db.Products.ToList();
            List<string> result = new List<string>();
            foreach (var item in listProducts)
            {
                result.Add(item.IDProduct);
            }
            return result;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            Product product = new Product();
            Category category = new Category();
            Input input = new Input();

            bool isSuccess = true;

            if (togglebtnNewProduct.IsChecked == true)
            {
                //Add Input
                input.Serial = listInput.Count;
                input.IDProduct = txtboxID.Text;
                input.Name = txtboxName.Text;
                input.Category = comboboxCategory.SelectedItem as Category;
                input.DateEntry = datepickerDateEntry.SelectedDate;

                int temp;
                float tempfloat;
                if (int.TryParse(txtboxAmount.Text, out temp) || float.TryParse(txtboxPrice.Text, out tempfloat))
                {
                    isSuccess = true;
                    input.Amount = int.Parse(txtboxAmount.Text);
                    input.Price = float.Parse(txtboxPrice.Text);
                }
                else
                {
                    isSuccess = false;
                    MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                //Add Product
                product.IDProduct = input.IDProduct;
                product.Name = input.Name;
                product.Picture = imageProduct.Source.ToString();
                product.Category = input.Category;
                product.Amount = input.Amount;
                product.Price = input.Price;

                if (isSuccess == true)
                {
                    try
                    {
                        DataProvider.ins.db.Products.Add(product);
                        DataProvider.ins.db.SaveChanges();

                        DataProvider.ins.db.Inputs.Add(input);
                        DataProvider.ins.db.SaveChanges();
                        MessageBox.Show("Successfully imported product!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                if (txtboxAmount != null && txtboxAmount.Text != "" && txtboxAmount.Text != null)
                {
                    //Update Product
                    string id = comboboxIDProduct.SelectedItem as string;
                    product = DataProvider.ins.db.Products.Find(id);
                    int oldValue = product.Amount ?? 0;
                    int temp;
                    if (int.TryParse(txtboxAmount.Text, out temp))
                    {
                        isSuccess = true;
                        product.Amount += int.Parse(txtboxAmount.Text);
                    }
                    else
                    {
                        isSuccess = false;
                        MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    //Add Input
                    input.Serial = listInput.Count;
                    input.IDProduct = product.IDProduct;
                    input.Name = product.Name;
                    input.Category = comboboxCategory.SelectedItem as Category;
                    input.Price = product.Price;
                    input.Amount = product.Amount - oldValue;
                    input.DateEntry = datepickerDateEntry.SelectedDate;

                    if (isSuccess == true)
                    {
                        try
                        {
                            DataProvider.ins.db.Inputs.Add(input);
                            DataProvider.ins.db.SaveChanges();
                            MessageBox.Show("Successfully imported product!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

            }
        }

        //Choose Image
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imageProduct.Source = new BitmapImage(new Uri(op.FileName));
            }
        }


        private void togglebtnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxIDProduct != null && txtboxID != null)
            {
                if (togglebtnNewProduct.IsChecked == true)
                {
                    comboboxIDProduct.Visibility = Visibility.Collapsed;
                    txtboxID.Visibility = Visibility.Visible;
                    txtboxName.IsEnabled = true;
                    txtboxPrice.IsEnabled = true;
                    comboboxCategory.IsEnabled = true;
                }
                else
                {
                    comboboxIDProduct.Visibility = Visibility.Visible;
                    txtboxID.Visibility = Visibility.Collapsed;
                    txtboxName.IsEnabled = false;
                    txtboxPrice.IsEnabled = false;
                    comboboxCategory.IsEnabled = false;
                }
            }
        }

        private void comboboxIDProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxIDProduct.SelectedItem != null)
            {
                string id = comboboxIDProduct.SelectedItem as string;
                Product product = DataProvider.ins.db.Products.Find(id);

                txtboxID.Text = product.IDProduct;
                txtboxName.Text = product.Name;
                txtboxPrice.Text = product.Price.ToString();
                comboboxCategory.SelectedItem = product.Category;
                datepickerDateEntry.SelectedDate = DateTime.Now;
                imageProduct.Source = new BitmapImage(new Uri(product.Picture, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
