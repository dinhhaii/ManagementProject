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

namespace Management_Application.ViewProducts
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        List<Category> listCategory { get; set; }
        List<Input> listInput { get; set; }
        int count { get; set; }

        public AddProduct()
        {
            InitializeComponent();
            listCategory = new List<Category>();
            listInput = new List<Input>();
            listCategory = DataProvider.ins.db.Categories.ToList();
            listInput = DataProvider.ins.db.Inputs.ToList();
            
            processingData();
        }

        void processingData()
        {
            comboboxCategory.ItemsSource = listCategory;
            datepickerDateEntry.Text = DateTime.Now.ToString();
            count = listInput.Count;
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

            product.IDProduct = txtboxID.Text;
            product.Name = txtboxName.Text;
            category = comboboxCategory.SelectedItem as Category;
            product.Category = category;

            int temp;
            float tempfloat;
            if (int.TryParse(txtboxAmount.Text, out temp)|| float.TryParse(txtboxPrice.Text, out tempfloat))
            {
                isSuccess = true;
                product.Amount = int.Parse(txtboxAmount.Text);
                product.Price = float.Parse(txtboxPrice.Text);
            }
            else
            {
                isSuccess = false;
                MessageBox.Show("Input failed","Management Application",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            input.Serial = listInput.Count;
            input.IDProduct = txtboxID.Text;
            input.Name = txtboxName.Text;

            if (isSuccess == true)
            {
                DataProvider.ins.db.Products.Add(product);
                DataProvider.ins.db.SaveChanges();

                DataProvider.ins.db.Inputs.Add(input);
                DataProvider.ins.db.SaveChanges();

                MessageBox.Show("Successfully imported product!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
