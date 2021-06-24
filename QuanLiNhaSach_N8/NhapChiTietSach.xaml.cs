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
    /// Interaction logic for NhapChiTietSach.xaml
    /// </summary>
    public partial class NhapChiTietSach : Window
    {
        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public NhapChiTietSach()
        {
            InitializeComponent();

            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public string mapn;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mapn = Message; // nhận từ form XemHoaDon
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text=="" || txt2.Text == "" ||txt3.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập tất cả thông tin vào các box";
                MessageBox.Show(msg, "Thông báo", btn , img);
            }
            else
            {
                var db = new BOOKEntities();

                var masach = txt1.Text;
                var timsach = db.Saches.Find(masach);
                if (timsach==null)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Mã sách không hợp lệ, không thể thêm vào phiếu nhập " + mapn;
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else // tiến hành thêm sách vào phiếu nhập
                {
                    // Tìm mã chi tiết phiếu nhập tiếp theo để thêm
                    var s = "";
                    foreach (var index in db.ChiTietPhieuNhapSaches)
                    {
                        s = index.MaChiTietPhieuNhapSach;
                    }
                    int n = int.Parse(s.Substring(2, 3));
                    n = n + 1;
                    if (n < 10)
                    {
                        s = "CP00" + n.ToString();
                    }
                    else if (n < 100)
                    {
                        s = "CP0" + n.ToString();
                    }
                    else
                    {
                        s = "CP" + n.ToString();
                    }

                    // Thêm vào database
                    var soluong = int.Parse(txt2.Text);
                    var update_soLuongSach = db.Saches.Find(txt1.Text); // update số lượng khi nhập
                    update_soLuongSach.SoLuong += soluong;
                    var gianhap = int.Parse(txt3.Text);
                    var tongtien = soluong * gianhap;
                    var update_tongTien = db.PhieuNhapSaches.Find(mapn); // update tổng tiền của PN sách
                    update_tongTien.TongTien += tongtien;
                    var bookToAdd = new ChiTietPhieuNhapSach() { MaChiTietPhieuNhapSach = s, MaPhieuNhapSach = mapn, MaSach = txt1.Text, SoLuong = soluong, GiaNhap = gianhap };
                    db.ChiTietPhieuNhapSaches.Add(bookToAdd);
                    db.SaveChanges();

                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Information;
                    var msg = "Thêm thành công chi tiết phiếu nhập " + s + " với mã phiếu nhập " + mapn;
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
            }
        }
    }
}
