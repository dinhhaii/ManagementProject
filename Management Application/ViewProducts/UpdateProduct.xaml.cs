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
using Microsoft.Win32;

namespace Management_Application.ViewProducts
{
    /// <summary>
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        List<Product> listProducts { get; set; }
        List<Category> listCategory { get; set; }
        List<Input> listInput { get; set; }
        int count { get; set; }

        public UpdateProduct(Product data)
        {
            InitializeComponent();
            listCategory = new List<Category>();
            listInput = new List<Input>();
            listProducts = new List<Product>();

            listCategory = DataProvider.ins.db.Categories.ToList();
            listInput = DataProvider.ins.db.Inputs.ToList();
            listProducts = DataProvider.ins.db.Products.ToList();


            if (data != null)
            {
                imageProduct.Source = new BitmapImage(new Uri(data.Picture, UriKind.RelativeOrAbsolute));

                txtboxID.Text = data.IDProduct;
                txtboxName.Text = data.Name;
                txtboxAmount.Text = data.Amount.ToString();
                txtboxPrice.Text = data.Price.ToString();
                comboboxCategory.SelectedItem = data.Category;

            }

            processingData();
        }

        void processingData()
        {
            txtboxAmount.IsEnabled = false;
            comboboxCategory.ItemsSource = listCategory;
            datepickerDateEntry.SelectedDate = DateTime.Now;
            count = listInput.Count;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = true;

            // Get product with PrimaryKey
            var product = DataProvider.ins.db.Products.Find(txtboxID.Text);
            Category category = new Category();

            // Update data
            product.IDProduct = txtboxID.Text;
            product.Name = txtboxName.Text;
            product.Picture = imageProduct.Source.ToString();
            product.Category = comboboxCategory.SelectedItem as Category;

            int temp;
            float tempfloat;
            if (int.TryParse(txtboxAmount.Text, out temp) || float.TryParse(txtboxPrice.Text, out tempfloat))
            {
                isSuccess = true;
                product.Amount = int.Parse(txtboxAmount.Text);
                product.Price = float.Parse(txtboxPrice.Text);
            }
            else
            {
                isSuccess = false;
                MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            // Get Input with PrimaryKey & Update
            foreach (Input item in listInput)
            {
                if(txtboxID.Text.ToString().Trim() == item.IDProduct.ToString().Trim())
                {
                    var input = DataProvider.ins.db.Inputs.Find(item.IDProduct,item.Serial);
                    input.IDProduct = product.IDProduct;
                    input.Name = product.Name;
                    input.Price = product.Price;
                    input.Category = product.Category;
                }
            }

            if (isSuccess == true)
            {
                DataProvider.ins.db.SaveChanges();

                MessageBox.Show("Successfully updated product!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
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
    }
}
