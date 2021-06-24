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
	/// Interaction logic for XemTheoNgay.xaml
	/// </summary>
	public partial class XemTheoNgay : Window
	{
		public XemTheoNgay()
		{
			InitializeComponent();
		}

		private void TKNgay_Click(object sender, RoutedEventArgs e)
		{
			var ngay = pickerNgay.Text;
			var db = new BOOKEntities();
			//MessageBox.Show(ngay);
			var flag = 0;//co de xem thu co ngay do hay khong
			foreach (var item in db.HoaDons)
			{
				if (item.NgayLapHoaDon.ToString().Contains(ngay))
				{
					flag = 1;
					break;
				}
			}
			if (flag == 0)
			{
				var img = MessageBoxImage.Error;
				var btn = MessageBoxButton.OK;
				var msg = "Không tìm thấy ngày cần tìm!";
				MessageBox.Show(msg, "Thông báo", btn, img);
			}
			else
			{
				var windows = new ThongKeTheoNgay();
				windows.Sender(ngay);
				windows.Show();
			}
		}

		private void ThoatTr_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
