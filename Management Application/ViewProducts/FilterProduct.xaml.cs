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
    /// Interaction logic for FilterProduct.xaml
    /// </summary>
    public partial class FilterProduct : Window
    {

        static public List<Product> filterList { get; set; }
        public List<Category> listCategory { get; set; }
        public FilterProduct()
        {
            InitializeComponent();
            FilterProduct.filterList = new List<Product>();
            listCategory = new List<Category>();
            listCategory = DataProvider.ins.db.Categories.ToList();

            comboboxCategory.ItemsSource = listCategory;
        }

        List<Product> filterData()
        {
            List<Product> listProducts = DataProvider.ins.db.Products.ToList();
            List<Product> result = new List<Product>();

            for (int i = 0; i < listProducts.Count; i++)
            {
                string str = listProducts[i].Name.Trim().ToLower().Replace(" ", "");
                string filterID = txtboxID.Text.ToLower();
                string filterName = txtboxName.Text.ToLower();
                string[] tokenID = filterID.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string[] tokenName = filterName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                //ID
                int index = 0;
                bool isAdded = false;
                for (; index < tokenID.Length; index++)
                {
                    tokenID[index] = tokenID[index].Trim();
                    int pos = listProducts[i].IDProduct.ToLower().IndexOf(tokenID[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }
                if (index == tokenID.Length && tokenID.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listProducts[i]);
                        isAdded = true;
                    }
                }
                //Name
                index = 0;
                for (; index < tokenName.Length; index++)
                {
                    tokenName[index] = tokenName[index].Trim();
                    int pos = listProducts[i].Name.ToLower().IndexOf(tokenName[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }

                if (index == tokenName.Length && tokenName.Length != 0)
                { 
                    if (isAdded == false)
                    {
                        result.Add(listProducts[i]);
                        isAdded = true;
                    }
                }
                //Category
                if(listProducts[i].Category == comboboxCategory.SelectedItem as Category)
                {
                    if (isAdded == false)
                    {
                        result.Add(listProducts[i]);
                        isAdded = true;
                    }
                }

                //Price
                if(listProducts[i].Price >= 0 && listProducts[i].Price <= slider.Value)
                {
                    if (isAdded == false)
                    {
                        result.Add(listProducts[i]);
                        isAdded = true;
                    }
                }

                ////Date
                //if (listProducts[i]. >= 0 && listProducts[i].Price <= slider.Value)
                //{
                //    if (isAdded == false)
                //    {
                //        result.Add(listProducts[i]);
                //        isAdded = true;
                //    }
                //}
            }

            return result;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            FilterProduct.filterList = DataProvider.ins.db.Products.ToList();
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            FilterProduct.filterList = filterData();
            this.Close();
        }

    }
}
