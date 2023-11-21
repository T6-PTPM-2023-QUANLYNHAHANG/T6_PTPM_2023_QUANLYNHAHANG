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
        public List<Account_DTO> GetListAccount()
        {
            List<Account_DTO> list = new List<Account_DTO>();
            list = db.Accounts.Select(p => new Account_DTO { Username = p.UserName, Password = p.PassWord, Displayname = p.DisplayName, IdType = p.id }).ToList();
            return list;
        }
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

        public int insertAccount(Account_DTO acc)
        {
            
            try
            {
                Account account = new Account();
                account.UserName = acc.Username;
                account.DisplayName = acc.Displayname;
                account.id = (int)acc.IdType;
                account.PassWord = "0";
                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int updateAccount(Account_DTO acc)
        {
            try
            {
                Account account = db.Accounts.Where(p => p.UserName == acc.Username).SingleOrDefault();
                account.DisplayName = acc.Displayname;
                account.id = (int)acc.IdType;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int deleteAccount(string username)
        {
            try
            {
                Account account = db.Accounts.Where(p => p.UserName == username).SingleOrDefault();
                db.Accounts.DeleteOnSubmit(account);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int resetPassword(string username)
        {
            try
            {
                Account account = db.Accounts.Where(p => p.UserName == username).SingleOrDefault();
                account.PassWord = "0";
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}
