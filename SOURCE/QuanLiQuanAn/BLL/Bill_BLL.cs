using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Bill_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static Bill_BLL instance;
        public static Bill_BLL Instance { get { if (instance == null) instance = new Bill_BLL(); return instance; } private set => instance = value; }
        private Bill_BLL() { }
        /// <summary>
        /// Get billId by tableId don't check out
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns>Bill id</returns>
        public int GetUncheckBillIDByTableID(int tableID)
        {
            // lấy ra id của bill chưa thanh toán
            // nếu không có bill nào thì trả về -1
            // nếu có thì trả về id của bill đó
            int id = db.Bills.Where(x => x.idTable == tableID && x.status == 0).Select(x => x.id).FirstOrDefault();
            if (id == 0)
                return -1;
            else
                return id;
        }
        public int insertBill(int idTable)
        {
            try
            {
                Bill bill = new Bill();
                bill.idTable = idTable;
                bill.DateCheckIn = DateTime.Now;
                bill.status = 0;
                db.Bills.InsertOnSubmit(bill);
                db.SubmitChanges();
                return bill.id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
