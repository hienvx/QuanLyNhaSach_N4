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
    /// Interaction logic for NhapSach.xaml
    /// </summary>
    public partial class NhapSach : Window
    {
        public NhapSach()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string mapn;
        public DateTime NgayNhap;
        public string manv;

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            var db = new BOOKEntities();
            // thêm phiếu nhập
            var pnToAdd = new PhieuNhapSach() { MaPhieuNhapSach = mapn, NgayNhapSach = NgayNhap, MaNhanVien = manv, TongTien = 0 };
            db.PhieuNhapSaches.Add(pnToAdd);
            db.SaveChanges();

            var windows = new NhapChiTietSach();
            windows.Sender(mapn); // gửi mã phiếu nhập sang form Nhập chi tiết sách
            windows.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new BOOKEntities();

            // Tìm mã phiếu nhập tiếp theo để thêm
            var s = "";
            foreach (var index in db.PhieuNhapSaches)
            {
                s = index.MaPhieuNhapSach;
            }
            int n = int.Parse(s.Substring(2, 3));
            n = n + 1;
            if (n < 10)
            {
                s = "PN00" + n.ToString();
            }
            else if (n < 100)
            {
                s = "PN0" + n.ToString();
            }
            else
            {
                s = "PN" + n.ToString();
            }

            mapn = s;
            NgayNhap = DateTime.Now;
            if (MainWindow.manv == "")
            {
                manv = "NV001";
            }
            else
            {
                manv = MainWindow.manv;
            }

            lbl11.Content = s;
            lbl21.Content = NgayNhap;
            lbl31.Content = manv;
        }
    }
}
