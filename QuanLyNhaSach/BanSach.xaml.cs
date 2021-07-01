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
    /// Interaction logic for BanSach.xaml
    /// </summary>
    public partial class BanSach : Window
    {
        public BanSach()
        {
            InitializeComponent();
        }

        public string mahd;
        public DateTime NgayBan;
        public string manv;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new BOOKEntities();

            // Tìm mã hóa đơn tiếp theo để thêm
            var s = "";
            foreach (var index in db.HoaDons)
            {
                s = index.MaHoaDon;
            }
            int n = int.Parse(s.Substring(2, 3));
            n = n + 1;
            if (n < 10)
            {
                s = "HD00" + n.ToString();
            }
            else if (n < 100)
            {
                s = "HD0" + n.ToString();
            }
            else
            {
                s = "HD" + n.ToString();
            }

            mahd = s;
            NgayBan = DateTime.Now;
            if (MainWindow.manv=="")
            {
                manv = "NV001";
            }
            else
            {
                manv = MainWindow.manv;
            }

            lbl11.Content = s;
            lbl31.Content = manv;
            lbl41.Content = NgayBan;
        }

        

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Không để trống mã khách hàng";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new BOOKEntities();
                // Kiểm tra khách hàng có tồn tại
                var check_khachHang = db.KhachHangs.Find(txt1.Text);
                if (check_khachHang == null)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Mã khách hàng không tồn tại";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else
                {
                    // thêm hóa đơn
                    var hdToAdd = new HoaDon() { MaHoaDon = mahd, MaKhachHang = txt1.Text, MaNhanVien = manv, NgayLapHoaDon = NgayBan, TongTien = 0, DiemThuong = 0 };
                    db.HoaDons.Add(hdToAdd);
                    db.SaveChanges();

                    var windows = new BanChiTietSach();
                    var mess = mahd + "+" + txt1.Text;
                    windows.Sender(mess); // gửi mã hóa đơn và mã khách hàng sang form Bán chi tiết sách
                    windows.Show();
                    this.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt1.Text = "";
        }
    }
}
