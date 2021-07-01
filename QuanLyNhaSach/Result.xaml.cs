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
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public Result()
        {
            InitializeComponent();

            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string checkstring;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            checkstring = Message; // nhận từ form Find
        }

        class Book
        {
            public int STT { get; set; }
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
            var check = checkstring.Substring(0, 3);

            var items = new List<Book>();

            var db = new BOOKEntities();

            if (check=="100") // Tìm theo tên
            {
                var name_text = checkstring.Substring(4, checkstring.Count() - 4);
                //MessageBox.Show(name_text, check);

                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TenSach.ToLower() == name_text.ToLower()) // tìm thấy tên
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check=="010") // Tìm theo tác giả
            {
                var author_text = checkstring.Substring(4, checkstring.Count() - 4);

                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TacGia.ToLower() == author_text.ToLower()) // tìm thấy tác giả
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check == "001") // Tìm theo năm
            {
                var year_text = checkstring.Substring(4, checkstring.Count() - 4);

                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.NamXuatBan.ToString() == year_text) // tìm thấy năm
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check == "110") // Tìm theo tên và tác giả
            {
                var chiso = checkstring.LastIndexOf('+'); // có 2 dấu cộng, tìm dấu cộng thứ 2
                var author_text = checkstring.Substring(chiso + 1 , checkstring.Count() - 1 - chiso); // từ dấu cậu thứ 2 đến cuối là tác giả
                var name_text = checkstring.Substring(4, checkstring.Count() -1 - 4 - author_text.Count()); // từ dấu cộng thứ nhất (vị trí 4) đến dấu cộng thứ 2 trừ 1 là tên
                //MessageBox.Show(author_text,name_text);


                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TenSach == name_text && index.TacGia == author_text)
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check == "101") // Tìm theo tên và năm
            {
                var chiso = checkstring.LastIndexOf('+');
                var year_text = checkstring.Substring(chiso + 1, checkstring.Count() - 1 - chiso);
                var name_text = checkstring.Substring(4, checkstring.Count() - 1 - 4 - year_text.Count());


                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TenSach == name_text && index.NamXuatBan.ToString() == year_text)
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check == "011") // Tìm theo tác giả và năm
            {
                var chiso = checkstring.LastIndexOf('+');
                var year_text = checkstring.Substring(chiso + 1, checkstring.Count() - 1 - chiso);
                var author_text = checkstring.Substring(4, checkstring.Count() - 1 - 4 - year_text.Count());


                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TacGia == author_text && index.NamXuatBan.ToString() == year_text)
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }

            if (check == "111") // Tìm theo tên, tác giả và năm
            {
                var chiso = checkstring.LastIndexOf('+');
                var year_text = checkstring.Substring(chiso + 1, checkstring.Count() - 1 - chiso);
                var nameAndAuthor_text = checkstring.Substring(4, checkstring.Count() - 1 - 4 - year_text.Count());
                //MessageBox.Show(nameAndAuthor_text, year_text);
                var chiso2 = nameAndAuthor_text.IndexOf('+');
                var name_text = nameAndAuthor_text.Substring(0, chiso2);
                var author_text = nameAndAuthor_text.Substring(chiso2 + 1, nameAndAuthor_text.Count() - 1 - name_text.Count());
                //MessageBox.Show(name_text, author_text);

                var sothutu = 0;
                foreach (var index in db.Saches)
                {
                    if (index.TenSach==name_text && index.TacGia == author_text && index.NamXuatBan.ToString() == year_text)
                    {
                        sothutu = sothutu + 1;
                        var item = new Book() { STT = sothutu, TenSach = index.TenSach, TacGia = index.TacGia, TheLoai = index.TheLoai, NXB = index.NhaXuatBan, NamXB = (int)index.NamXuatBan, GiaBan = (int)index.GiaBan, SoLuong = (int)index.SoLuong };
                        items.Add(item);
                    }
                }
            }


            return items;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;

            if (items.Count() == 0)
            {
                var img = MessageBoxImage.Information;
                var btn = MessageBoxButton.OK;
                var msg = "Không có sách cần tìm!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                this.Close();
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
