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
    /// Interaction logic for DanhSachNhanVien.xaml
    /// </summary>
    public partial class DanhSachNhanVien : Window
    {
        public DanhSachNhanVien()
        {
            InitializeComponent();
        }


        class NhanVien
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public DateTime NgaySinh { get; set; }
            public string DiaChi { get; set; }
            public string SoDienThoai { get; set; }
        }

        private List<NhanVien> getItem()
        {
            var items = new List<NhanVien>();

            var db = new BOOKEntities();

            foreach (var index in db.NhanViens)
            {
                var item = new NhanVien() {MaNV=index.MaNhanVien,TenNV=index.TenNhanVien,NgaySinh=(DateTime)index.NgaySinh,DiaChi=index.DiaChi,SoDienThoai=index.SoDienThoai };
                items.Add(item);
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
