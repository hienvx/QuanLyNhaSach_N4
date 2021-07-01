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
    /// Interaction logic for ThemSach.xaml
    /// </summary>
    public partial class ThemSach : Window
    {
        public ThemSach()
        {
            InitializeComponent();
        }

        //class Book
        //{
        //    public string MaSach { get; set; }
        //    public string TenSach { get; set; }
        //    public string TacGia { get; set; }
        //    public string TheLoai { get; set; }
        //    public string NXB { get; set; }
        //    public int NamXB { get; set; }
        //    public int GiaBan { get; set; }
        //    public int SoLuong { get; set; }
        //}

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "" || txt2.Text=="" || txt3.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "" || txt7.Text =="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập đầy đủ thông tin";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new BOOKEntities();

                // Tìm mã sách tiếp theo để thêm
                var s = "";
                foreach (var index in db.Saches)
                {
                    s = index.MaSach;
                }
                int n = int.Parse(s.Substring(2,3));
                n = n + 1;
                if (n < 10)
                {
                    s = "SA00" + n.ToString();
                }
                else if (n < 100)
                {
                    s = "SA0" + n.ToString();
                }
                else
                {
                    s = "SA" + n.ToString();
                }
                //MessageBox.Show(s);

                // thêm sách
                //var bookToAdd = new Book() { MaSach = s, TenSach = txt1.Text, TacGia = txt2.Text, TheLoai = txt3.Text, NXB = txt4.Text, NamXB = int.Parse(txt5.Text), GiaBan = int.Parse(txt6.Text), SoLuong = int.Parse(txt7.Text) };
                var bookToAdd = new Sach() { MaSach = s, TenSach = txt1.Text, TacGia = txt2.Text, TheLoai = txt3.Text, NhaXuatBan = txt4.Text, NamXuatBan = int.Parse(txt5.Text), GiaBan = int.Parse(txt6.Text), SoLuong = int.Parse(txt7.Text) };
                db.Saches.Add(bookToAdd);
                db.SaveChanges();
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Information;
                var msg = "Thêm sách thành công";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
        }
    }
}
