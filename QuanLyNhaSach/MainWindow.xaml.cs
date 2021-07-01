using System.Windows;

namespace QuanLyNhaSach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string tendangnhap;
        public static string manv;

        /// <summary>
        /// Event when click login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool flags = true; // đăng nhập thất bại

            //MessageBox.Show("Đã đăng nhập", "Thông báo");
            if (txtUsername.Text == "")
            {
                flags = false;
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Không được để trống tên đăng nhập";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
            else if (txtPassword.Password == "")
            {
                flags = false;
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                string content = "Lỗi : Không được để trống mật khẩu";
                MessageBox.Show(content, "Lỗi!", button, icon);
            }
            else // user name & password đầy đủ
            {
                if (txtUsername.Text == "admin") // là admin
                {
                    if (txtPassword.Password != "123") // sai mật khẩu
                    {
                        flags = false;
                        MessageBoxButton button1 = MessageBoxButton.OK;
                        MessageBoxImage icon1 = MessageBoxImage.Warning;
                        string content1 = "Thông báo : Sai mật khẩu";
                        MessageBox.Show(content1, "Thông báo", button1, icon1);
                    }
                    else // đúng mật khẩu
                    {
                        flags = false;
                        tendangnhap = txtUsername.Text;
                        manv = "";
                        var windows = new DashBoard();
                        windows.Show();
                        this.Close();
                    }
                }
                else // là nhân viên hoặc sai mật khẩu
                {
                    var db = new BOOKEntities();
                    var user_text = txtUsername.Text;
                    var pass_text = txtPassword.Password;

                    foreach (var user in db.TaiKhoans)
                    {
                        //MessageBox.Show(user.TenDangNhap);
                        if (user.TenDangNhap == user_text) // tìm thấy nhân viên
                        {
                            flags = false;
                            if (user.MatKhau == pass_text) // đúng mật khẩu
                            {
                                tendangnhap = txtUsername.Text;
                                manv = user.MaNhanVien;

                                var windows = new DashBoard();
                                windows.Show();
                                this.Close();
                            }
                            else // sai mật khẩu
                            {
                                MessageBoxButton button = MessageBoxButton.OK;
                                MessageBoxImage icon = MessageBoxImage.Warning;
                                string content = "Thông báo : Sai mật khẩu";
                                MessageBox.Show(content, "Thông báo", button, icon);
                            }
                        }
                    }
                }
            }
            if (flags) // sai tên đăng nhập hoặc mật khẩu
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                string content = "Thông báo : Sai tên đăng nhập hoặc mật khẩu";
                MessageBox.Show(content, "Thông báo", button, icon);
            }
        }

        /// <summary>
        /// Exit screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        ///  Information of project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            string content = "Quản lý nhà sách\nby Nhóm 4";
            MessageBox.Show(content, "Thông tin", button, icon);
        }


        /// <summary>
        /// Password box focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = "";
        }


        /// <summary>
        /// username box focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Foreground = System.Windows.Media.Brushes.Black;
            txtUsername.Text = "";
        }

        /// <summary>
        /// Password box loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Loaded(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = "12345678";
        }
    }
}
