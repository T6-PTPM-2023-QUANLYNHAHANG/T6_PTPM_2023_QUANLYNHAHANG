using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Billinfo_DTO
    {
        int id;
        int billId;
        int foodId;
        int count;

        public Billinfo_DTO(int id, int billId, int foodId, int count)
        {
            this.id = id;
            this.billId = billId;
            this.foodId = foodId;
            this.count = count;
        }
        public Billinfo_DTO()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public int BillId { get => billId; set => billId = value; }
        public int FoodId { get => foodId; set => foodId = value; }
        public int Count { get => count; set => count = value; }
    }
}
