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

namespace Management_Application.ViewImport
{
    /// <summary>
    /// Interaction logic for UpdateImport.xaml
    /// </summary>
    public partial class UpdateImport : Window
    {
        List<Category> listCategory { get; set; }
        List<Input> listInput { get; set; }
        private Input receivedData { get; set; }

        public UpdateImport(Input data)
        {
            InitializeComponent();
            listCategory = new List<Category>();
            listInput = new List<Input>();
            listCategory = DataProvider.ins.db.Categories.ToList();
            listInput = DataProvider.ins.db.Inputs.ToList();

            receivedData = new Input();
            receivedData = data;
            processingData();
        }

        void processingData()
        {
            if (receivedData != null)
            {
                txtboxID.Text = receivedData.IDProduct;
                txtboxName.Text = receivedData.Name;
                txtboxAmount.Text = receivedData.Amount.ToString();
                txtboxPrice.Text = receivedData.Price.ToString();
                comboboxCategory.SelectedItem = receivedData.Category;

                txtboxID.IsEnabled = false;
                txtboxName.IsEnabled = false;
                txtboxPrice.IsEnabled = false;
                comboboxCategory.IsEnabled = false;

            }
            comboboxCategory.ItemsSource = listCategory;
            datepickerDateEntry.SelectedDate = DateTime.Now;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = true;
            int oldAmount = receivedData.Amount ?? 0;

            // Get Input with PrimaryKey
            var input = DataProvider.ins.db.Inputs.Find(receivedData.IDProduct,receivedData.Serial);
            // Update data
            input.DateEntry = datepickerDateEntry.SelectedDate;
            int temp;
            if (int.TryParse(txtboxAmount.Text, out temp))
            {
                isSuccess = true;
                input.Amount = int.Parse(txtboxAmount.Text);
            }
            else
            {
                isSuccess = false;
                MessageBox.Show("Input failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            // Get Product with PrimaryKey
            var product = DataProvider.ins.db.Products.Find(receivedData.Product.IDProduct);
            // Update Product
            product.Amount -= oldAmount;
            product.Amount += input.Amount;

            if (isSuccess == true)
            {
                DataProvider.ins.db.SaveChanges();

                MessageBox.Show("Successfully updated Import!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}