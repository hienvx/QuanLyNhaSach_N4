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
    /// Interaction logic for PhieuNhapSachDetail.xaml
    /// </summary>
    public partial class PhieuNhapSachDetail : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public PhieuNhapSachDetail()
        {
            InitializeComponent();
            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string mapn;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mapn = Message; // nhận từ form XemPhieuNhapSach
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

        private List<Book> getItem()
        {
            var items = new List<Book>();

            // Cập nhật thông tin phiếu nhập
            var db = new BOOKEntities();
            var phieunhap_ = db.PhieuNhapSaches.Find(mapn); // chắc chắn tìm thấy, vì đã tìm thấy mới sang form này
            lblMaPN2.Content = phieunhap_.MaPhieuNhapSach;
            lblMaNV2.Content = phieunhap_.MaNhanVien;
            lblNgay2.Content = phieunhap_.NgayNhapSach.ToString();
            lblTongtien2.Content = phieunhap_.TongTien.ToString() + " VNĐ";

            var sothutu = 0;
            // Cập nhật chi tiết phiếu nhập
            foreach (var index in db.ChiTietPhieuNhapSaches)
            {
                if (index.MaPhieuNhapSach == mapn)
                {
                    sothutu = sothutu + 1;

                    var ms = index.MaSach;
                    var sach_ = db.Saches.Find(ms);

                    var soluong = (int)index.SoLuong;
                    var dongia = (int)sach_.GiaBan;
                    var thanhtien = soluong * dongia;
                    var item = new Book() { STT = sothutu, MaSach = ms, TenSach = sach_.TenSach, SL = soluong, DonGia = dongia, ThanhTien = thanhtien };
                    items.Add(item);
                }
            }

            return items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
