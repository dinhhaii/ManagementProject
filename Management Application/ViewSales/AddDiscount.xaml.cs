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
    /// Interaction logic for AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        public static int discount { get; set; }

        public AddDiscount(Output data)
        {
            InitializeComponent();
            if (data != null)
            {
                txtboxID.Text = data.IDProduct;
                txtboxName.Text = data.Name;

                List<int> listDiscount = new List<int>() { 0, 10, 15, 20, 25, 30, 40, 50, 75, 90, 100 };
                comboboxDiscount.ItemsSource = listDiscount;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxDiscount.SelectedItem != null)
            {
                AddDiscount.discount = (int)comboboxDiscount.SelectedItem;
            }
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            AddDiscount.discount = 0;
            this.Close();
        }
    }
}
