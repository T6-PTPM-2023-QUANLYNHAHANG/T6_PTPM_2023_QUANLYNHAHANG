using BLL;
using DTO;
using GUI.NhanVien;
using GUI.QuanLi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.TaiKhoan
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            btnExit.Click += BtnExit_Click;
            this.FormClosing += FLogin_FormClosing;
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát", "Thoát chương trình", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            Account_DTO acc = Account_BLL.Instance.Login(username, password);
            if (acc != null)
            {
                fStaff f = new fStaff(acc);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
