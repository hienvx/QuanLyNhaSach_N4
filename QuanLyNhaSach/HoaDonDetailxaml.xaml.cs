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
    /// Interaction logic for HoaDonDetailxaml.xaml
    /// </summary>
    public partial class HoaDonDetailxaml : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public HoaDonDetailxaml()
        {
            InitializeComponent();
            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string mahd;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mahd = Message; // nhận từ form XemHoaDon
        }

        class Book
        {
            public int STT { get; set; }
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SL { get; set; }
            public int DonGia { get; set; }
            public int ThanhTien { get; set; }
        }

        public int tongtien = 0;
        private List<Book> getItem()
        {
            var items = new List<Book>();

            // Cập nhật thông tin hóa đơn
            var db = new BOOKEntities();
            var hoadon_ = db.HoaDons.Find(mahd); // chắc chắn tìm thấy, vì đã tìm thấy mới sang form này
            lblMaHD2.Content = hoadon_.MaHoaDon;
            lblMaKH2.Content = hoadon_.MaKhachHang;
            var khachang_ = db.KhachHangs.Find(hoadon_.MaKhachHang);
            lblTenKH2.Content = khachang_.TenKhachHang;
            lblMaNV2.Content = hoadon_.MaNhanVien;
            lblNgay2.Content = hoadon_.NgayLapHoaDon.ToString();

            var sothutu = 0;
            // Cập nhật chi tiết hóa đơn
            foreach (var index in db.ChiTietHoaDons)
            {
                if (index.MaHoaDon==mahd)
                {
                    sothutu = sothutu + 1;

                    var ms = index.MaSach;
                    var sach_ = db.Saches.Find(ms);

                    var soluong = (int)index.SoLuong;
                    var dongia = (int)sach_.GiaBan;
                    var thanhtien = soluong * dongia;
                    tongtien = tongtien + thanhtien;
                    var item = new Book() { STT = sothutu,MaSach=ms,TenSach=sach_.TenSach,SL=soluong,DonGia=dongia,ThanhTien=thanhtien};
                    items.Add(item);
                }
            }

            // cập nhật thành tiền + điểm
            lblTongtien2.Content = tongtien.ToString() + " VNĐ";
            int diem = tongtien / 100000;
            lblDiemTichLuy2.Content = diem.ToString() + " điểm";

            return items;
        }

        /// <summary>
        ///  Load danh sách các sách của hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }


        /// <summary>
        /// Về menu clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

