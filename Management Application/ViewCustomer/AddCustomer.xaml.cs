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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {

        public AddCustomer()
        {
            InitializeComponent();
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            Customer customer = new Customer();
            bool isSuccess = true;

            customer.IDCustomer = txtboxID.Text;
            customer.NameCustomer = txtboxName.Text;
            customer.Address = txtboxAddress.Text;
            customer.Phone = txtboxPhone.Text;

            if (isSuccess == true)
            {
                try
                {
                    DataProvider.ins.db.Customers.Add(customer);
                    DataProvider.ins.db.SaveChanges();

                    MessageBox.Show("Successfully imported Customer!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Import Failed", "Management Application", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
