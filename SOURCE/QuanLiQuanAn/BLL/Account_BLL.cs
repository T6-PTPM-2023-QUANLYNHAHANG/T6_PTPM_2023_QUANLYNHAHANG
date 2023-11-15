using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Account_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static Account_BLL instance;
        public static Account_BLL Instance
        {
            get { if (instance == null) instance = new Account_BLL(); return instance; }
            private set { instance = value; }
        }
        private Account_BLL() { }
        public bool Login(string username, string password)
        {
            // kiểm tra username và password có tồn tại trong database không
            return db.Accounts.Count(x => x.UserName == username && x.PassWord == password) > 0;
                
        }
    }
}
