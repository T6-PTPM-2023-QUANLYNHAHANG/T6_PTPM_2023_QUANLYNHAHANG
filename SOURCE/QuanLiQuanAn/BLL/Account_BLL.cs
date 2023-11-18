using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

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
        public Account_DTO Login(string username)
        {
            // kiểm tra username và password có tồn tại trong database không
            return db.Accounts.Where(p => p.UserName == username).Select(p => new Account_DTO { Username = p.UserName, Password = p.PassWord, IdType = p.id, Displayname = p.DisplayName }).SingleOrDefault();

        }
        public Account_DTO Login(string username, string password)
        {
            // kiểm tra username và password có tồn tại trong database không
            return db.Accounts.Where(p => p.UserName == username && p.PassWord == password).Select(p => new Account_DTO { Username = p.UserName, Password = p.PassWord, IdType = p.id, Displayname = p.DisplayName }).SingleOrDefault();
                
        }
        public bool UpdateAccount(string username, string displayname, string password, string newpass)
        {
            // kiểm tra username và password có tồn tại trong database không
            Account acc = db.Accounts.Where(p => p.UserName == username && p.PassWord == password).SingleOrDefault();
            if (acc != null)
            {
                acc.DisplayName = displayname;
                acc.PassWord = newpass;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
