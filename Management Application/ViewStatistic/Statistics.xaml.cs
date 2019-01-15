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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Management_Application.Model;

namespace Management_Application.ViewStatistic
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        List<Product> listProduct { get; set; }
        public Statistics()
        {
            InitializeComponent();

            comboboxSelection.ItemsSource = getSelection();
            processingData();
        }

        List<string> getSelection()
        {
            List<string> listSelection = new List<string>();
            listSelection.Add("By Date");
            listSelection.Add("By Month");
            listSelection.Add("By Year");
            listSelection.Add("All Time");
            return listSelection;
        }

        //Best Seller
        void processingData()
        {
            
        }

        //Calculate
        int calculateNumberOfInputProduct(List<Input> list)
        {
            int count = 0;
            for(int i = 0; i < list.Count; i++)
            {
                count += (list[i].Amount ?? 0);
            }
            return count;
        }

        int calculateNumberOfOutputProduct(List<Output> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                count += (list[i].Amount ?? 0);
            }
            return count;
        }

        double calculateRevenue(List<Order> list)
        {
            double result = 0;
            for(int i = 0; i < list.Count; i++)
            {
                result += (list[i].TotalItem ?? 0);
            }
            return result;
        }

        //=====BY DATE=====
        List<Input> statisticImportByDate(DateTime date)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for(int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if (temp.Date == date.Date)
                {
                    list.Add(listInputs[i]);
                }
            }
            return list;
        }

        List<Output> statisticExportByDate(DateTime date)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Date == date.Date)
                {
                    for(int index = 0;index < listOutputs.Count; index++)
                    {
                        if(listOutputs[index].IDOrder == listOutputs[i].IDOrder)
                        {
                            list.Add(listOutputs[index]);
                        }
                    }
                }
            }

            return list;
        }

        List<Order> statisticRevenueByDate(DateTime date)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Date == date.Date)
                {
                    list.Add(listOrders[i]);
                }
            }
            return list;
        }


        //=====BY MONTH=====
        List<Input> statisticImportByMonth(int month, int year)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for (int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if (temp.Month == month && temp.Year == year)
                {
                    list.Add(listInputs[i]);
                }
            }
            return list;
        }

        List<Output> statisticExportByMonth(int month, int year)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Month == month && temp.Year == year)
                {
                    for (int index = 0; index < listOutputs.Count; index++)
                    {
                        if (listOutputs[index].IDOrder == listOutputs[i].IDOrder)
                        {
                            list.Add(listOutputs[index]);
                        }
                    }
                }
            }

            return list;
        }

        List<Order> statisticRevenueByMonth(int month, int year)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if(temp.Month == month && temp.Year == year)
                {
                    list.Add(listOrders[i]);
                }
            }
            return list;
        }

        //=====BY YEAR=====
        List<Input> statisticImportByYear(int year)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for (int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if (temp.Year == year)
                {
                    list.Add(listInputs[i]);
                }
            }
            return list;
        }

        List<Output> statisticExportByYear(int year)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Year == year)
                {
                    for (int index = 0; index < listOutputs.Count; index++)
                    {
                        if (listOutputs[index].IDOrder == listOutputs[i].IDOrder)
                        {
                            list.Add(listOutputs[index]);
                        }
                    }
                }
            }

            return list;
        }

        List<Order> statisticRevenueByYear(int year)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Year == year)
                {
                    list.Add(listOrders[i]);
                }
            }
            return list;
        }

        private void comboboxSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboboxSelection.SelectedItem != null)
            {
                string selectedItem = comboboxSelection.SelectedItem as string;
                if (selectedItem == "By Date")
                {
                    gridDate.Visibility = Visibility.Visible;
                }
                else if(selectedItem == "By Month")
                { 

                }
                else if (selectedItem == "By Year")
                {
                    
                }
                else if (selectedItem == "All Time")
                {

                }

            }
        }

        private void datepickerDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = datepickerDate.SelectedDate ?? DateTime.Now;
            if (date != null)
            {
                List<Input> listimport = statisticImportByDate(date);
                List<Output> listsold = statisticExportByDate(date);
                List<Order> listorder = statisticRevenueByDate(date);

                txtblocimportkDate.Text = calculateNumberOfInputProduct(listimport).ToString();
                txtblocsoldkDate.Text = calculateNumberOfOutputProduct(listsold).ToString();
                txtblocrevenuekDate.Text = calculateRevenue(listorder).ToString(".0####");

                DateChart.ChartSubTitle = "(" + date.ToString("dd/MM/yyyy") + ")";
                DateChart1.ChartSubTitle = "(" + date.ToString("dd/MM/yyyy") + ")";

                amountDateChart.ItemsSource= null;
                amountDateChart.ItemsSource = listsold;
                revenueDateChart.ItemsSource = null;
                revenueDateChart.ItemsSource = listorder;
            }
        }

        private void datepickerDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = datepickerDateTo.SelectedDate ?? DateTime.Now;
            if (date != null)
            {
                List<Input> listimport = statisticImportByDate(date);
                List<Output> listsold = statisticExportByDate(date);
                List<Order> listorder = statisticRevenueByDate(date);

                txtblocimportkDate.Text = calculateNumberOfInputProduct(listimport).ToString();
                txtblocsoldkDate.Text = calculateNumberOfOutputProduct(listsold).ToString();
                txtblocrevenuekDate.Text = calculateRevenue(listorder).ToString(".0####");

                DateChart.ChartSubTitle = "(" + ((DateTime)datepickerDate.SelectedDate).ToString("dd/MM/yyyy") + " - " + date.ToString("dd/MM/yyyy") + ")";
                DateChart1.ChartSubTitle = "(" + ((DateTime)datepickerDate.SelectedDate).ToString("dd/MM/yyyy") + " - " + date.ToString("dd/MM/yyyy") + ")";

                amountDateChart.ItemsSource = null;
                amountDateChart.ItemsSource = listsold;
                revenueDateChart.ItemsSource = null;
                revenueDateChart.ItemsSource = listorder;
            }
        }

        private void buttonDate_Click(object sender, RoutedEventArgs e)
        {
            datepickerDateTo.IsEnabled = true;
            
        }

   
    }
}
