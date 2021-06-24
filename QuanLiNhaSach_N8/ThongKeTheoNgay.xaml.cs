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
	/// Interaction logic for ThongKeTheoNgay.xaml
	/// </summary>
	public partial class ThongKeTheoNgay : Window
	{
		public delegate void SendNgay(string n);
		public SendNgay Sender;
		public ThongKeTheoNgay()
		{
			InitializeComponent();
			Sender = new SendNgay(GetNgay);
		}
		public static string NgayTK;
		private void GetNgay(string n)
		{
			NgayTK = n;
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
		
		
		private List<Book> getItemBook()
		{
			var itemsBook = new List<Book>();
			var db = new BOOKEntities();
			var stt = 0;
			//cap nhat ne
			foreach(var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(NgayTK))
				{
					//lay ma hoa don cua ngay do
					var mahoadon = item.MaHoaDon;
					foreach(var para in db.ChiTietHoaDons)
					{
						if (para.MaHoaDon == mahoadon)
						{
							stt = stt + 1;

							var ms = para.MaSach;
							var sach_ = db.Saches.Find(ms);

							var soluong = (int)para.SoLuong;
							var dongia = (int)sach_.GiaBan;
							var thanhtien = soluong * dongia;
							tongtien = tongtien + thanhtien;
							var it = new Book() { STT = stt, MaSach = ms, TenSach = sach_.TenSach, SL = soluong, DonGia = dongia, ThanhTien = thanhtien };
							itemsBook.Add(it);
						}
					}
				}
			}
			return itemsBook;
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			lblTKNgay.Content = NgayTK;
			var itemsBook = getItemBook();
			itemTKNgayListView.ItemsSource = itemsBook;
		}
	}
}
