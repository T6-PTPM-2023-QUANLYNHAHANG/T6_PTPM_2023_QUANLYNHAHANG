using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class IncomeBill_DTO
    {
        string tableName;
        DateTime? dateCheckIn;
        DateTime? dateCheckOut;
        int? discount;
        float? totalPrice;

        public IncomeBill_DTO(string tableName, DateTime dateCheckIn, DateTime dateCheckOut, int discount, float totalPrice)
        {
            this.tableName = tableName;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.discount = discount;
            this.totalPrice = totalPrice;
        }
        public IncomeBill_DTO()
        {
            
        }
        public string TableName { get => tableName; set => tableName = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int? Discount { get => discount; set => discount = value; }
        public float? TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
