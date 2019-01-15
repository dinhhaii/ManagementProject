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
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        List<Category> listCategory { get; set; }

        public AddCategory()
        {
            InitializeComponent();
            listCategory = new List<Category>();
            listCategory = DataProvider.ins.db.Categories.ToList();

        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            category.IDCategory = (listCategory.Count+1).ToString();
            category.NameCategory = txtboxCategory.Text;
            try
            {
                DataProvider.ins.db.Categories.Add(category);
                DataProvider.ins.db.SaveChanges();
                MessageBox.Show("Added Category successfully", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Added Failed!", "Management Application", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
