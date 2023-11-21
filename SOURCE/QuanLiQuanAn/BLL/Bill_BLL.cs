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
        /// <returns>Bill id or -1</returns>
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
        /// <summary>
        /// insert bill
        /// </summary>
        /// <param name="idTable"></param>
        /// <returns>Bill id</returns>
        public int insertBill(int idTable)
        {
            try
            {
                Bill bill = new Bill();
                bill.idTable = idTable;
                bill.DateCheckIn = DateTime.Now;
                bill.status = 0;
                bill.discount = 0;
                bill.totalPrice = 0;
                db.Bills.InsertOnSubmit(bill);
                db.SubmitChanges();
                return bill.id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// check out bill
        /// </summary>
        /// <param name="idBill"></param>
        /// <param name="discount"></param>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        public int checkBillOut(int idBill, int discount, float totalPrice)
        {
            try
            {
                Bill bill = db.Bills.Where(x => x.id == idBill).FirstOrDefault();
                bill.DateCheckOut = DateTime.Now;
                bill.status = 1;
                bill.discount = discount;
                bill.totalPrice = totalPrice;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        // Convert bill and billinfo of two tables. If table 2 does not have a bill, when the conversion is complete, table 2 will have a bill, table 1 will have no bill.
        /// <summary>
        /// switch bill and billinfo of two tables
        /// </summary>
        /// <param name="idTable1"></param>
        /// <param name="idTable2"></param>
        public void SwitchTable(int idTable1, int idTable2)
        {
            Bill bill1 = db.Bills.Where(x => x.idTable == idTable1 && x.status == 0).FirstOrDefault();
            Bill bill2 = db.Bills.Where(x => x.idTable == idTable2 && x.status == 0).FirstOrDefault();
            

            if (bill1 != null && bill2 == null)
            {
                int idBill1 = bill1.id;
                int idBill2 = Bill_BLL.instance.insertBill(idTable2);
                List<BillInfo> lstBillInfo1 = db.BillInfos.Where(x => x.idBill == idBill1).ToList();
                foreach (BillInfo item in lstBillInfo1)
                {
                    item.idBill = idBill2;
                }
                bill1.idTable = idTable2;
                // delete bill1
                db.Bills.DeleteOnSubmit(bill1);
            }
            // change bill and billinfo of two tables
            else if (bill1 != null && bill2 != null)
            {
                int idBill1 = bill1.id;
                int idBill2 = bill2.id;
                List<BillInfo> lstBillInfo1 = db.BillInfos.Where(x => x.idBill == idBill1).ToList();
                List<BillInfo> lstBillInfo2 = db.BillInfos.Where(x => x.idBill == idBill2).ToList();
                foreach (BillInfo item in lstBillInfo1)
                {
                    item.idBill = idBill2;
                }
                foreach (BillInfo item in lstBillInfo2)
                {
                    item.idBill = idBill1;
                }
                db.SubmitChanges();
            }
            db.SubmitChanges();
        }
        public int deleteBillByTableID(int TableID)
        {
            try
            {
                List<Bill> lst = db.Bills.Where(x => x.idTable == TableID).ToList();
                foreach (Bill item in lst)
                {
                    BIllinfo_BLL.Instance.deleteBillInfoByBillID(item.id);
                    Bill f = db.Bills.Where(x => x.id == item.id).FirstOrDefault();
                    db.Bills.DeleteOnSubmit(f);
                    db.SubmitChanges();
                }
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
    }
}
