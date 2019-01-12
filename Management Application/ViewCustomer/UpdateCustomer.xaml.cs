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

namespace Management_Application.ViewCustomer
{
    /// <summary>
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {

        public UpdateCustomer(Customer data)
        {
            InitializeComponent();

            if (data != null)
            {
                txtboxID.Text = data.IDCustomer;
                txtboxName.Text = data.NameCustomer;
                txtboxPhone.Text = data.Phone;
                txtboxAddress.Text = data.Address;
            }

        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = true;

            // Get Customer with PrimaryKey
            var customer = DataProvider.ins.db.Customers.Find(txtboxID.Text);

            // Update data
            customer.IDCustomer = txtboxID.Text;
            customer.NameCustomer = txtboxName.Text;
            customer.Phone = txtboxPhone.Text;
            customer.Address = txtboxAddress.Text;

            if (isSuccess == true)
            {
                DataProvider.ins.db.SaveChanges();
                MessageBox.Show("Successfully updated Customer!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

    }
}