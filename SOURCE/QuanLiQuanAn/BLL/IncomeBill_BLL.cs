using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class IncomeBill_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static IncomeBill_BLL instance;
        public static IncomeBill_BLL Instance { get { if (instance == null) instance = new IncomeBill_BLL(); return instance; } private set => instance = value; }
        private IncomeBill_BLL() { }
        public List<IncomeBill_DTO> GetListIncomeBillByDate(DateTime dateCheckIn, DateTime dateCheckOut)
        {
            List<IncomeBill_DTO> list = new List<IncomeBill_DTO>();

            var query = from b in db.Bills
                        join tb in db.TableFoods on b.idTable equals tb.id
                        where b.DateCheckIn >= dateCheckIn && b.DateCheckOut <= dateCheckOut
                        select new IncomeBill_DTO
                        {
                            TableName = tb.name,
                            DateCheckIn = b.DateCheckIn,
                            DateCheckOut = b.DateCheckOut,
                            Discount = b.discount,
                            TotalPrice = (float)b.totalPrice
                        };
            list = query.ToList();
            return list;
        }
    }
}
