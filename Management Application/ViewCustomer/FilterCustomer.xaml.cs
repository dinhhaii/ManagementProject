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

namespace Management_Application.ViewCustomer
{
    /// <summary>
    /// Interaction logic for FilterCustomer.xaml
    /// </summary>
    public partial class FilterCustomer : Window
    {
        static public List<Customer> filterList { get; set; }

        public FilterCustomer()
        {
            InitializeComponent();
            FilterCustomer.filterList = new List<Customer>();
        }

        List<Customer> filterData()
        {
            List<Customer> listCustomers = DataProvider.ins.db.Customers.ToList();
            List<Customer> result = new List<Customer>();

            for (int i = 0; i < listCustomers.Count; i++)
            {
                string filterID = txtboxID.Text.ToLower();
                string filterName = txtboxName.Text.ToLower();
                string filterPhone = txtboxPhone.Text.ToLower();
                string filterAddress = txtboxAddress.Text.ToLower();
                string[] tokenID = filterID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string[] tokenName = filterName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string[] tokenPhone = filterPhone.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string[] tokenAddress = filterAddress.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                //ID
                int index = 0;
                bool isAdded = false;
                for (; index < tokenID.Length; index++)
                {
                    tokenID[index] = tokenID[index].Trim();
                    int pos = listCustomers[i].IDCustomer.ToLower().IndexOf(tokenID[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }
                if (index == tokenID.Length && tokenID.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listCustomers[i]);
                        isAdded = true;
                    }
                }
                //Name
                index = 0;
                for (; index < tokenName.Length; index++)
                {
                    tokenName[index] = tokenName[index].Trim();
                    int pos = listCustomers[i].NameCustomer.ToLower().IndexOf(tokenName[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }

                if (index == tokenName.Length && tokenName.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listCustomers[i]);
                        isAdded = true;
                    }
                }

                //Phone
                index = 0;
                for (; index < tokenPhone.Length; index++)
                {
                    tokenPhone[index] = tokenPhone[index].Trim();
                    int pos = listCustomers[i].Phone.ToLower().IndexOf(tokenPhone[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }

                if (index == tokenPhone.Length && tokenPhone.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listCustomers[i]);
                        isAdded = true;
                    }
                }

                //Address
                index = 0;
                for (; index < tokenAddress.Length; index++)
                {
                    tokenAddress[index] = tokenAddress[index].Trim();
                    int pos = listCustomers[i].Address.ToLower().IndexOf(tokenAddress[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }

                if (index == tokenAddress.Length && tokenAddress.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listCustomers[i]);
                        isAdded = true;
                    }
                }
            }

            return result;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            FilterCustomer.filterList = DataProvider.ins.db.Customers.ToList();
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            FilterCustomer.filterList = filterData();
            this.Close();
        }

    }
}
