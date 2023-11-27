using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI.TaiKhoan
{
    public partial class fChangeAccount : Form
    {
        Account_DTO acc;
        public Account_DTO Acc { get => acc; set => acc = value; }

        public fChangeAccount(Account_DTO account)
        {
            InitializeComponent();
            this.acc = account;
            this.Load += FChangeAccount_Load;
        }



        #region Events
        private void FChangeAccount_Load(object sender, EventArgs e)
        {
            loadAccount(acc);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string displayname = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPass.Text;
            string renewpass = txbReEnterPass.Text;
            if (checkNewPass(newpass, renewpass))
            {
                if (Account_BLL.Instance.UpdateAccount(username, displayname, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    // truyền tài khoản về form fstaff
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(Account_BLL.Instance.Login(username)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp");
            }
        }

       

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }


        #endregion
        #region methods
        /// <summary>
        /// kiểm tra mật khẩu mới có trùng khớp hay không
        /// </summary>
        /// <param name="newpass"></param>
        /// <param name="renewpass"></param>
        /// <returns></returns>
        private bool checkNewPass(string newpass, string renewpass)
        {
            if (newpass.Equals(renewpass))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// hiện thị thông tin tài khoản
        /// </summary>
        /// <param name="acc"></param>
        private void loadAccount(Account_DTO acc)
        {
            txbUserName.Text = acc.Username;
            txbDisplayName.Text = acc.Displayname;
        }
        #endregion


    }
    // tạo event để truyền dữ liệu tài khoản qua form fstaff
    public class AccountEvent : EventArgs
    {
        private Account_DTO acc;

        public Account_DTO Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account_DTO acc)
        {
            this.Acc = acc;
        }
    }
}
