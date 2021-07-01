using QuanLyNhaSach;
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
    /// Interaction logic for BanChiTietSach.xaml
    /// </summary>
    public partial class BanChiTietSach : Window
    {
        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public BanChiTietSach()
        {
            InitializeComponent();

            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public string mess;
        public string mahd;
        public string makh;

        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mess = Message; // nhận từ form XemHoaDon
            mahd = mess.Substring(0, 5);
            makh = mess.Substring(6, 5);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Vui lòng thêm sách vào hóa đơn " + mahd;
        }

        private void Txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt1.Text = "";
        }

        private void Txt2_GotFocus(object sender, RoutedEventArgs e)
        {
            txt2.Text = "";
        }

        private void Txt3_GotFocus(object sender, RoutedEventArgs e)
        {
            txt3.Text = "";
        }

        public int T=0; // dùng để tính tổng tiền => điểm thưởng, khi nào bấm Cancel sẽ cộng điểm thưởng cho khách hàng
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var db = new BOOKEntities();
            var update_diemThuong = db.KhachHangs.Find(makh); // update điểm thưởng
            update_diemThuong.DiemTichLuy += T / 100000;
            var update_diemThuongForHoaDon = db.HoaDons.Find(mahd);
            update_diemThuongForHoaDon.DiemThuong += T / 100000;
            db.SaveChanges();
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập tất cả thông tin vào các box";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new BOOKEntities();

                var masach = txt1.Text;
                var timsach = db.Saches.Find(masach);
                if (timsach == null)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Mã sách không hợp lệ, không thể thêm vào hóa đơn " + mahd;
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else // tiến hành thêm sách vào hóa đơn
                {
                    // Tìm mã chi tiết hóa đơn tiếp theo để thêm
                    var s = "";
                    foreach (var index in db.ChiTietHoaDons)
                    {
                        s = index.MaChiTietHoaDon;
                    }
                    int n = int.Parse(s.Substring(2, 3));
                    n = n + 1;
                    if (n < 10)
                    {
                        s = "CD00" + n.ToString();
                    }
                    else if (n < 100)
                    {
                        s = "CD0" + n.ToString();
                    }
                    else
                    {
                        s = "CD" + n.ToString();
                    }

                    // Thêm vào database
                    var soluong = int.Parse(txt2.Text);
                    var update_soLuongSach = db.Saches.Find(txt1.Text); // update số lượng khi bán
                    update_soLuongSach.SoLuong -= soluong;
                    var giaban = int.Parse(txt3.Text);
                    var tongtien = soluong * giaban;
                    var update_tongTien = db.HoaDons.Find(mahd); // update tổng tiền của Hóa đơn
                    update_tongTien.TongTien += tongtien;
                    T += tongtien;
                    
                    var bookToAdd = new ChiTietHoaDon() { MaChiTietHoaDon = s, MaHoaDon = mahd, MaSach = txt1.Text, SoLuong = soluong, GiaBan = giaban };
                    db.ChiTietHoaDons.Add(bookToAdd);
                    db.SaveChanges();

                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Information;
                    var msg = "Thêm thành công chi tiết hóa đơn " + s + " với mã hóa đơn " + mahd;
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
            }
        }
    }
}
