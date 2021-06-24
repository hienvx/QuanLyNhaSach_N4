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
    /// Interaction logic for DanhSachKhachHang.xaml
    /// </summary>
    public partial class DanhSachKhachHang : Window
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
        }

        class KhachHang
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
            public string CMND { get; set; }
            public string SoDienThoai { get; set; }
            public int DiemTichLuy { get; set; }
        }

        private List<KhachHang> getItem()
        {
            var items = new List<KhachHang>();

            var db = new BOOKEntities();

            foreach (var index in db.KhachHangs)
            {
                var item = new KhachHang() { MaKH=index.MaKhachHang,TenKH=index.TenKhachHang,CMND=index.CMND,SoDienThoai=index.SoDienThoai,DiemTichLuy=(int)index.DiemTichLuy };
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
