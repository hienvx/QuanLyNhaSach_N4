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
    /// Interaction logic for DanhSachSach.xaml
    /// </summary>
    public partial class DanhSachSach : Window
    {
        public DanhSachSach()
        {
            InitializeComponent();
        }

        class Book
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public string TacGia { get; set; }
            public string TheLoai { get; set; }
            public string NXB { get; set; }
            public int NamXB { get; set; }
            public int GiaBan { get; set; }
            public int SoLuong { get; set; }
        }

        private List<Book> getItem()
        {
            var items = new List<Book>();

            var db = new BOOKEntities();

            foreach (var index in db.Saches)
            {
                var item = new Book() { MaSach = index.MaSach, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
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
