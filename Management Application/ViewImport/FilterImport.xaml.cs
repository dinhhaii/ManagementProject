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
    /// Interaction logic for FilterImport.xaml
    /// </summary>
    public partial class FilterImport : Window
    {
        static public List<Input> filterList { get; set; }
        public List<Category> listCategory { get; set; }

        public FilterImport()
        {
            InitializeComponent();
            FilterImport.filterList = new List<Input>();
            listCategory = new List<Category>();
            listCategory = DataProvider.ins.db.Categories.ToList();

            comboboxCategory.ItemsSource = listCategory;
        }

        List<Input> filterData()
        {
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            List<Input> result = new List<Input>();

            for (int i = 0; i < listInputs.Count; i++)
            {
                string str = listInputs[i].Name.Trim().ToLower().Replace(" ", "");
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
                    int pos = listInputs[i].IDProduct.ToLower().IndexOf(tokenID[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }
                if (index == tokenID.Length && tokenID.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listInputs[i]);
                        isAdded = true;
                    }
                }
                //Name
                index = 0;
                for (; index < tokenName.Length; index++)
                {
                    tokenName[index] = tokenName[index].Trim();
                    int pos = listInputs[i].Name.ToLower().IndexOf(tokenName[index]);
                    if (pos < 0)
                    {
                        break;
                    }
                }

                if (index == tokenName.Length && tokenName.Length != 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listInputs[i]);
                        isAdded = true;
                    }
                }
                //Category
                if (listInputs[i].Category == comboboxCategory.SelectedItem as Category)
                {
                    if (isAdded == false)
                    {
                        result.Add(listInputs[i]);
                        isAdded = true;
                    }
                }

                //Price
                if (listInputs[i].Price >= 0 && listInputs[i].Price <= slider.Value)
                {
                    if (isAdded == false)
                    {
                        result.Add(listInputs[i]);
                        isAdded = true;
                    }
                }

                //Date
                DateTime datetimeInput = listInputs[i].DateEntry ?? DateTime.Now;
                if (DateTime.Compare(datetimeInput,datepickerFrom.SelectedDate ?? DateTime.Now) >= 0 &&
                    DateTime.Compare(datetimeInput, datepickerTo.SelectedDate ?? DateTime.Now) <= 0)
                {
                    if (isAdded == false)
                    {
                        result.Add(listInputs[i]);
                        isAdded = true;
                    }
                }
            }

            return result;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            FilterImport.filterList = DataProvider.ins.db.Inputs.ToList();
            this.Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            FilterImport.filterList = filterData();
            this.Close();
        }

    }
}
