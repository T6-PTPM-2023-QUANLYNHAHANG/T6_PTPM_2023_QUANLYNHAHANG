using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class AccountType_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static AccountType_BLL instance;
        public static AccountType_BLL Instance
        {
            get { if (instance == null) instance = new AccountType_BLL(); return instance; }
            private set { instance = value; }
        }
        private AccountType_BLL() { }
        public List<AccountType_DTO> GetListAccountType()
        {
            List<AccountType_DTO> list = new List<AccountType_DTO>();

            list = db.AccountTypes.Select(p => new AccountType_DTO { Id = p.id, Name = p.name }).ToList();

            return list;
        }
    }
}
