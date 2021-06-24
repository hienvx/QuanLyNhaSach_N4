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

namespace QuanLyNhaSach
{
    /// <summary>
    /// Interaction logic for Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        public Find()
        {
            InitializeComponent();
        }

        //public static List<Book> listbook = new List<Book>();

        public string check = "000";

        private void cbName_Checked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(0, 1);
            check = check.Insert(0, "1");
            //MessageBox.Show("Box Name checked");
            //MessageBox.Show(check);
        }

        private void cbAuthor_Checked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(1, 1);
            check = check.Insert(1, "1");
            //MessageBox.Show("Box Author checked");
            //MessageBox.Show(check);
        }

        private void cbYear_Checked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(2, 1);
            check = check.Insert(2, "1");
            //MessageBox.Show("Box Year checked");
            //MessageBox.Show(check);
        }

        private void cbName_Unchecked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(0, 1);
            check = check.Insert(0, "0");
            //MessageBox.Show("Box Name unchecked");
            //MessageBox.Show(check);
        }

        private void cbAuthor_Unchecked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(1, 1);
            check = check.Insert(1, "0");
            //MessageBox.Show("Box Author unchecked");
            //MessageBox.Show(check);
        }

        private void cbYear_Unchecked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(2, 1);
            check = check.Insert(2, "0");
            //MessageBox.Show("Box Year unchecked");
            //MessageBox.Show(check);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (check=="000") // Không tick vào checkbox nào cả
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng chọn ít nhất 1 thuộc tính tìm kiếm!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                if (check=="100")
                {
                    check = check.Insert(3,"+");
                    check = check.Insert(4,txtName.Text);
                }

                if (check=="010")
                {
                    check = check.Insert(3, "+");
                    check = check.Insert(4, txtAuthor.Text);
                }

                if (check == "001")
                {
                    check = check.Insert(3, "+");
                    check = check.Insert(4, txtYear.Text);
                }

                if (check == "110")
                {
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtName.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtAuthor.Text);
                }

                if (check == "101")
                {
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtName.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtYear.Text);
                }

                if (check == "011")
                {
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtAuthor.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtYear.Text);
                }

                if (check == "111")
                {
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtName.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtAuthor.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtYear.Text);
                }

                var windows = new Result();
                windows.Sender(check);
                windows.Show();
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check[0]=='0')
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng tick vào ô bên cạnh trước khi gõ vào đây!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                txtName.Text = "";
            }
        }

        private void TxtAuthor_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check[1] == '0')
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng tick vào ô bên cạnh trước khi gõ vào đây!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                txtAuthor.Text = "";
            }
        }

        private void TxtYear_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check[2] == '0')
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng tick vào ô bên cạnh trước khi gõ vào đây!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                txtYear.Text = "";
            }
        }
    }
}
