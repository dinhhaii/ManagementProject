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

namespace Management_Application
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox.Text == "admin" && passwordBox.Password == "123")
            {
                Home window = new Home();
                login.Close();
                window.Show();
            }
            else
            {
                txtbox.Text = "";
                passwordBox.Password = "";
                MaterialDesignThemes.Wpf.HintAssist.SetHint(txtbox, "");
                MaterialDesignThemes.Wpf.HintAssist.SetHint(passwordBox, "");

                MessageBox.Show("Thông tin đăng nhập chưa đúng", "Notify", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

        }

        //Xử lý sự kiện khi bấm phím Enter để đăng nhập
        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void txtbox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtbox, "Username");
        }

        private void txtbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txtbox, "Username");
        }

        private void passwordBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(passwordBox, "Password");
        }

        private void passwordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(passwordBox, "Password");
        }

        //Dừng chương trình khi đóng cửa sổ Đăng nhập
        private void login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

