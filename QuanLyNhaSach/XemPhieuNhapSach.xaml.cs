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
    /// Interaction logic for XemPhieuNhapSach.xaml
    /// </summary>
    public partial class XemPhieuNhapSach : Window
    {
        public XemPhieuNhapSach()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            var mapn = txtInput.Text;

            if  (mapn=="")
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Mã phiếu nhập không được để trống!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new BOOKEntities();

                var hoadon = db.PhieuNhapSaches.Find(mapn);

                if (hoadon == null) // không tìm thấy mã phiếu nhập nào
                {
                    var img = MessageBoxImage.Error;
                    var btn = MessageBoxButton.OK;
                    var msg = "Không tìm thấy mã phiếu nhập!";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else // có mã phiếu nhập
                {
                    var windows = new PhieuNhapSachDetail();
                    windows.Sender(txtInput.Text); // gửi mã phiếu nhập sang form chi tiết phiếu nhập
                    windows.Show();
                    //this.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtInput_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
        }
    }
}
