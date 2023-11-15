using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BIllinfo_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static BIllinfo_BLL instance;
        public static BIllinfo_BLL Instance { get { if (instance == null) instance = new BIllinfo_BLL(); return instance; } private set => instance = value; }
        private BIllinfo_BLL() { }
        // get list billinfo by id bill
        public List<Billinfo_DTO> getListBillInfo(int id)
        {
            List<Billinfo_DTO> lst = new List<Billinfo_DTO>();
            lst = db.BillInfos.Where(x => x.idBill == id).Select(x => new Billinfo_DTO { Id = x.id, BillId = x.idBill, FoodId = x.idFood, Count = x.count }).ToList();
            return lst;
        }
        public int insertBillinfo(int idBill, int idFood, int count)
        {
            try
            {
                BillInfo billinfo_DTO = new BillInfo();
                billinfo_DTO.idBill = idBill;
                billinfo_DTO.idFood = idFood;
                billinfo_DTO.count = count;
                db.BillInfos.InsertOnSubmit(billinfo_DTO);
                db.SubmitChanges();
                return 1;

            }
            catch (Exception)
            {

                return 0;
            }
            

        }
        public int isHaveFoodinBillinfo(int idBill, int idFood)
        {
            try
            {
                BillInfo billinfo = db.BillInfos.Where(x => x.idBill == idBill && x.idFood == idFood).FirstOrDefault();
                if (billinfo == null)
                    return 0;
                else
                    return billinfo.id;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public int updateBillinfo(int idBillInfo, int idFood ,int count)
        {
            try
            {
                // update count in billinfo
                BillInfo billinfo = db.BillInfos.Where(x => x.id == idBillInfo).FirstOrDefault();
                billinfo.count += count;
                if (billinfo.count <= 0)
                {
                    // delete billinfo
                    db.BillInfos.DeleteOnSubmit(billinfo);
                }
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
