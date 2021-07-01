using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QuanLyNhaSach
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Nhập sách clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThemSach_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap=="admin")
            {
                var windows = new ThemSach();
                windows.Show();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Chức năng thêm sách chỉ dành cho admin";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
        }

        /// <summary>
        /// Tìm kiếm clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var windows = new Find();
            windows.Show();
        }

        /// <summary>
        /// Hóa Đơn clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            var windows = new XemHoaDon();
            windows.Show();
        }

        /// <summary>
        /// Danh sách tài khoản clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDanhSachTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap == "admin")
            {
                var windows = new DanhSachTaiKhoan();
                windows.Show();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Chức năng xem danh sách tài khoản chỉ dành cho admin";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
        }

		private void btnThongKeNgay_Click(object sender, RoutedEventArgs e)
		{
            if (MainWindow.tendangnhap == "admin")
            {
                var windows = new XemTheoNgay();
                windows.Show();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Chức năng thống kê chỉ dành cho admin";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
        }

        private void BtnDanhSachSach_Click(object sender, RoutedEventArgs e)
        {
            var windows = new DanhSachSach();
            windows.Show();
        }

        private void BtnDanhSachKhachHang_Click(object sender, RoutedEventArgs e)
        {
            var windows = new DanhSachKhachHang();
            windows.Show();
        }

        private void BtnDanhSachNhanVien_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap == "admin")
            {
                var windows = new DanhSachNhanVien();
                windows.Show();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Chức năng xem danh sách nhân viên chỉ dành cho admin";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
        }

        private void BtnXemPhieuNhapSach_Click(object sender, RoutedEventArgs e)
        {
            var windows = new XemPhieuNhapSach();
            windows.Show();
        }

        private void BtnNhapSach_Click(object sender, RoutedEventArgs e)
        {
            var windows = new NhapSach();
            windows.Show();
        }

        private void BtnBanSach_Click(object sender, RoutedEventArgs e)
        {
            var windows = new BanSach();
            windows.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Xin chào " + MainWindow.tendangnhap + ", mời chọn chức năng";
        }

        private void BtnThemKhachHang_Click(object sender, RoutedEventArgs e)
        {
            var windows = new ThemKhachHang();
            windows.Show();
        }

        private void BtnDangKI_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap == "admin")
            {
                var windows = new DangKi();
                windows.Show();
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Chức năng đăng kí chỉ dành cho admin";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            var windows = new MainWindow();
            windows.Show();
            this.Close();
        }
    }
}
