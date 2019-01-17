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
using Microsoft.Windows.Controls;

namespace Management_Application.ViewStatistic
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        List<Product> listProduct { get; set; }
        List<int> listMonth { get; set; }
        List<int> listYear { get; set; }

        public Statistics()
        {
            InitializeComponent();

            listMonth = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            listYear = new List<int>() { 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026 };

            month1.ItemsSource = listMonth;
            month2.ItemsSource = listMonth;
            year1.ItemsSource = listYear;
            year2.ItemsSource = listYear;
            Year1.ItemsSource = listYear;
            Year2.ItemsSource = listYear;

            comboboxSelection.ItemsSource = getSelection();
            processingData();
        }

        bool dateSelection = false;
        bool monthSelection = false;
        bool yearselection = false;

        List<string> getSelection()
        {
            List<string> listSelection = new List<string>();
            listSelection.Add("By Date");
            listSelection.Add("By Month");
            listSelection.Add("By Year");
            return listSelection;
        }

        //Best Seller
        void processingData()
        {
            gridDate.Visibility = Visibility.Collapsed;
            gridMonth.Visibility = Visibility.Collapsed;
            gridYear.Visibility = Visibility.Collapsed;
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

        List<Input> statisticImportByDate(DateTime dateFrom, DateTime dateTo)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for (int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if (DateTime.Compare(temp.Date,dateFrom) >= 0 && DateTime.Compare(temp.Date, dateTo) <= 0)
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

        List<Output> statisticExportByDate(DateTime dateFrom, DateTime dateTo)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (DateTime.Compare(temp.Date, dateFrom) >= 0 && DateTime.Compare(temp.Date, dateTo) <= 0)
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

        List<Order> statisticRevenueByDate(DateTime dateFrom, DateTime dateTo)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (DateTime.Compare(temp.Date, dateFrom) >= 0 && DateTime.Compare(temp.Date, dateTo) <= 0)
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

        List<Input> statisticImportByMonth(int month, int year, int monthTo, int yearTo)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for (int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if(year == yearTo)
                {
                    if(temp.Year == year)
                    {
                        if (temp.Month >= month && temp.Month <= monthTo)
                        {
                            list.Add(listInputs[i]);
                        }
                    }     
                }
                else if(year < yearTo)
                {
                    if (temp.Year >= year && temp.Year <= yearTo)
                    {
                        if(temp.Year == year)
                        {
                            if (temp.Month >= month)
                            {
                                list.Add(listInputs[i]);
                            }
                        }
                        else if(temp.Year == yearTo)
                        {
                            if (temp.Month <= monthTo)
                            {
                                list.Add(listInputs[i]);
                            }
                        }
                    }
                }
                
            }
            return list;
        }

        List<Output> statisticExportByMonth(int month, int year, int monthTo, int yearTo)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (year == yearTo)
                {
                    if (temp.Year == year)
                    {
                        if (temp.Month >= month && temp.Month <= monthTo)
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
                }
                else if (year < yearTo)
                {
                    if (temp.Year >= year && temp.Year <= yearTo)
                    {
                        if (temp.Year == year)
                        {
                            if (temp.Month >= month)
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
                        else if (temp.Year == yearTo)
                        {
                            if (temp.Month <= monthTo)
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
                    }
                }   
            }

            return list;
        }

        List<Order> statisticRevenueByMonth(int month, int year, int monthTo, int yearTo)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (year == yearTo)
                {
                    if (temp.Year == year)
                    {
                        if (temp.Month >= month && temp.Month <= monthTo)
                        {
                            list.Add(listOrders[i]);
                        }
                    }
                }
                else if (year < yearTo)
                {
                    if (temp.Year >= year && temp.Year <= yearTo)
                    {
                        if (temp.Year == year)
                        {
                            if (temp.Month >= month)
                            {
                                list.Add(listOrders[i]);
                            }
                        }
                        else if (temp.Year == yearTo)
                        {
                            if (temp.Month <= monthTo)
                            {
                                list.Add(listOrders[i]);
                            }
                        }
                    }
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

        List<Input> statisticImportByYear(int year, int yearTo)
        {
            List<Input> list = new List<Input>();
            List<Input> listInputs = DataProvider.ins.db.Inputs.ToList();
            for (int i = 0; i < listInputs.Count; i++)
            {
                DateTime temp = listInputs[i].DateEntry ?? DateTime.Now;
                if (temp.Year >= year && temp.Year <= yearTo)
                {
                    list.Add(listInputs[i]);
                }
            }
            return list;
        }

        List<Output> statisticExportByYear(int year, int yearTo)
        {
            List<Output> list = new List<Output>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            List<Output> listOutputs = DataProvider.ins.db.Outputs.ToList();

            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Year >= year && temp.Year <= yearTo)
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

        List<Order> statisticRevenueByYear(int year, int yearTo)
        {
            List<Order> list = new List<Order>();
            List<Order> listOrders = DataProvider.ins.db.Orders.ToList();
            for (int i = 0; i < listOrders.Count; i++)
            {
                DateTime temp = listOrders[i].DateSale ?? DateTime.Now;
                if (temp.Year >= year && temp.Year <= yearTo)
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
                    gridMonth.Visibility = Visibility.Collapsed;
                    gridYear.Visibility = Visibility.Collapsed;

                    amountDateChartColumn.Visibility = Visibility.Visible;
                    revenueDateChartPieChart.Visibility = Visibility.Visible;
                    amountDateChartLine.Visibility = Visibility.Collapsed;
                    revenueDateChartColumn.Visibility = Visibility.Collapsed;
                }
                else if(selectedItem == "By Month")
                { 
                    gridDate.Visibility = Visibility.Collapsed;
                    gridMonth.Visibility  = Visibility.Visible;
                    gridYear.Visibility = Visibility.Collapsed;

                    amountMonthChartColumn.Visibility = Visibility.Visible;
                    revenueMonthChartPieChart.Visibility = Visibility.Visible;
                    amountMonthChartLine.Visibility = Visibility.Collapsed;
                    revenueMonthChartColumn.Visibility = Visibility.Collapsed;
                }
                else if (selectedItem == "By Year")
                {
                    gridDate.Visibility = Visibility.Collapsed;
                    gridMonth.Visibility = Visibility.Collapsed;
                    gridYear.Visibility = Visibility.Visible;

                    amountYearChartColumn.Visibility = Visibility.Visible;
                    revenueYearChartPieChart.Visibility = Visibility.Visible;
                    amountYearChartLine.Visibility = Visibility.Collapsed;
                    revenueYearChartColumn.Visibility = Visibility.Collapsed;
                }

            }
        }

        //=======DATE=======
        private void datepickerDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = datepickerDate.SelectedDate ?? DateTime.Now;
            if (datepickerDate.SelectedDate != null)
            {
                if (dateSelection == false)
                {
                    List<Input> listimport = statisticImportByDate(date);
                    List<Output> listsold = statisticExportByDate(date);
                    List<Order> listorder = statisticRevenueByDate(date);

                    txtblocimportkDate.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkDate.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekDate.Text = calculateRevenue(listorder).ToString(".0####");

                    amountDateChartColumn.ChartSubTitle = "(" + date.ToString("dd/MM/yyyy") + ")";
                    revenueDateChartPieChart.ChartSubTitle = "(" + date.ToString("dd/MM/yyyy") + ")";

                    amountDateChart.ItemsSource = null;
                    amountDateChart.ItemsSource = listsold;
                    revenueDateChart.ItemsSource = null;
                    revenueDateChart.ItemsSource = listorder;
                }
            }
        }

        private void datepickerDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = datepickerDateTo.SelectedDate ?? DateTime.Now;
            if (datepickerDate.SelectedDate != null)
            {
                if (dateSelection == true)
                {
                    List<Input> listimport = statisticImportByDate((DateTime)datepickerDate.SelectedDate, date);
                    List<Output> listsold = statisticExportByDate((DateTime)datepickerDate.SelectedDate,date);
                    List<Order> listorder = statisticRevenueByDate((DateTime)datepickerDate.SelectedDate,date);

                    txtblocimportkDate.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkDate.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekDate.Text = calculateRevenue(listorder).ToString(".0####");

                    revenueDateChartColumn.ChartSubTitle = "(" + ((DateTime)datepickerDate.SelectedDate).ToString("dd/MM/yyyy") + " - " + date.ToString("dd/MM/yyyy") + ")";

                    if (listsold.Count != 0)
                    {
                        amountDateChart1.ItemsSource = null;
                        amountDateChart1.ItemsSource = listorder;
                    }
                    
                    revenueDateChart1.ItemsSource = null;
                    revenueDateChart1.ItemsSource = listorder;
                }
            }
        }

        private void buttonDate_Click(object sender, RoutedEventArgs e)
        {
            if (!dateSelection)
            {
                datepickerDateTo.IsEnabled = true;
                dateSelection = true;

                amountDateChartColumn.Visibility = Visibility.Collapsed;
                revenueDateChartPieChart.Visibility = Visibility.Collapsed;
                amountDateChartLine.Visibility = Visibility.Visible;
                revenueDateChartColumn.Visibility = Visibility.Visible;

            }
            else
            {
                datepickerDateTo.IsEnabled = false;
                dateSelection = false;
                

                amountDateChartColumn.Visibility = Visibility.Visible;
                revenueDateChartPieChart.Visibility = Visibility.Visible;
                amountDateChartLine.Visibility = Visibility.Collapsed;
                revenueDateChartColumn.Visibility = Visibility.Collapsed;
            }
        }

        //=========MONTH=========
        private void month1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (month1.SelectedItem != null && year1.SelectedItem != null)
            {
                int month = (int)month1.SelectedItem;
                int year = (int)year1.SelectedItem;
                if (monthSelection == false)
                {
                    List<Input> listimport = statisticImportByMonth(month,year);
                    List<Output> listsold = statisticExportByMonth(month, year);
                    List<Order> listorder = statisticRevenueByMonth(month, year);

                    txtblocimportkMonth.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkMonth.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekMonth.Text = calculateRevenue(listorder).ToString(".0####");

                    amountMonthChartColumn.ChartSubTitle = "(" + month.ToString() + "/" + year.ToString() + ")";
                    revenueDateChartPieChart.ChartSubTitle = "(" + month.ToString() + "/" + year.ToString() + ")";

                    amountMonthChart.ItemsSource = null;
                    amountMonthChart.ItemsSource = listsold;
                    revenueMonthChart.ItemsSource = null;
                    revenueMonthChart.ItemsSource = listorder;
                }
            }
        }

        private void month2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (month1.SelectedItem != null && year1.SelectedItem != null)
            {
                int month = (int)month1.SelectedItem;
                int year = (int)year1.SelectedItem;
                if (monthSelection == false)
                {
                    List<Input> listimport = statisticImportByMonth(month, year);
                    List<Output> listsold = statisticExportByMonth(month, year);
                    List<Order> listorder = statisticRevenueByMonth(month, year);

                    txtblocimportkMonth.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkMonth.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekMonth.Text = calculateRevenue(listorder).ToString(".0####");

                    revenueMonthChartColumn.ChartSubTitle = "(" + month.ToString() + "/" + year.ToString() + ")";

                    amountMonthChart1.ItemsSource = null;
                    amountMonthChart1.ItemsSource = listorder;
                    revenueMonthChart1.ItemsSource = null;
                    revenueMonthChart1.ItemsSource = listorder;
                }
            }
        }

        private void buttonMonth_Click(object sender, RoutedEventArgs e)
        {
            if (!monthSelection)
            {
                month2.IsEnabled = true;
                year2.IsEnabled = true;
                monthSelection = true;

                amountMonthChartColumn.Visibility = Visibility.Visible;
                revenueMonthChartPieChart.Visibility = Visibility.Visible;
                amountMonthChartLine.Visibility = Visibility.Collapsed;
                revenueMonthChartColumn.Visibility = Visibility.Collapsed;
            }
            else
            {
                month2.IsEnabled = false;
                year2.IsEnabled = false;
                monthSelection = false;
                
                amountMonthChartColumn.Visibility = Visibility.Visible;
                revenueMonthChartPieChart.Visibility = Visibility.Visible;
                amountMonthChartLine.Visibility = Visibility.Collapsed;
                revenueMonthChartColumn.Visibility = Visibility.Collapsed;
            }
        }

        //====YEAR====
        private void Year1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Year1.SelectedItem != null)
            {
                int _year1 = (int)Year1.SelectedItem;
                
                if (yearselection == false)
                {
                    List<Input> listimport = statisticImportByYear(_year1);
                    List<Output> listsold = statisticExportByYear(_year1);
                    List<Order> listorder = statisticRevenueByYear(_year1);

                    txtblocimportkYear.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkYear.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekYear.Text = calculateRevenue(listorder).ToString(".0####");

                    amountYearChartColumn.ChartSubTitle = "(" + _year1.ToString() + ")";
                    revenueYearChartPieChart.ChartSubTitle = "(" + _year1.ToString() + ")";

                    amountYearChart.ItemsSource = null;
                    amountYearChart.ItemsSource = listsold;
                    revenueYearChart.ItemsSource = null;
                    revenueYearChart.ItemsSource = listorder;
                }
            }
        }

        private void Year2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Year1.SelectedItem != null && Year2.SelectedItem != null)
            {
                int _year1 = (int)Year1.SelectedItem;
                int _year2 = (int)Year2.SelectedItem;
                if(yearselection == true)
                {
                    List<Input> listimport = statisticImportByYear(_year1, _year2);
                    List<Output> listsold = statisticExportByYear(_year1, _year2);
                    List<Order> listorder = statisticRevenueByYear(_year1, _year2);

                    txtblocimportkYear.Text = calculateNumberOfInputProduct(listimport).ToString();
                    txtblocsoldkYear.Text = calculateNumberOfOutputProduct(listsold).ToString();
                    txtblocrevenuekYear.Text = calculateRevenue(listorder).ToString(".0####");

                    revenueYearChartColumn.ChartSubTitle = "(" + _year1.ToString() + " - " + _year2.ToString() + ")";

                    amountYearChart1.ItemsSource = null;
                    amountYearChart1.ItemsSource = listorder;
                    revenueYearChart1.ItemsSource = null;
                    revenueYearChart1.ItemsSource = listorder;
                }
            }
        }

        private void buttonYear_Click(object sender, RoutedEventArgs e)
        {
            if (!yearselection)
            {
                Year2.IsEnabled = true;
                yearselection = true;

                amountYearChartColumn.Visibility = Visibility.Visible;
                revenueYearChartPieChart.Visibility = Visibility.Visible;
                amountYearChartLine.Visibility = Visibility.Collapsed;
                revenueYearChartColumn.Visibility = Visibility.Collapsed;

                
            }
            else
            {
                Year2.IsEnabled = false;
                yearselection = false;
                
                amountYearChartColumn.Visibility = Visibility.Visible;
                revenueYearChartPieChart.Visibility = Visibility.Visible;
                amountYearChartLine.Visibility = Visibility.Collapsed;
                revenueYearChartColumn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
