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
    /// Interaction logic for ThemKhachHang.xaml
    /// </summary>
    public partial class ThemKhachHang : Window
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text=="" ||txt2.Text=="" ||txt3.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập đầy đủ thông tin";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new BOOKEntities();
                var s = "";
                foreach (var index in db.KhachHangs)
                {
                    s = index.MaKhachHang;
                }
                int n = int.Parse(s.Substring(2, 3));
                n = n + 1;
                if (n < 10)
                {
                    s = "KH00" + n.ToString();
                }
                else if (n < 100)
                {
                    s = "KH0" + n.ToString();
                }
                else
                {
                    s = "KH" + n.ToString();
                }

                db.KhachHangs.Add(new KhachHang() { MaKhachHang = s, TenKhachHang = txt1.Text, CMND = txt2.Text, SoDienThoai = txt3.Text, DiemTichLuy = 0 });
                db.SaveChanges();

                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Information;
                var msg = "Thêm khách hàng thành công!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                this.Close();
            }
        }
    }
}
