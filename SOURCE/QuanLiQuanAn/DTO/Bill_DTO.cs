using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill_DTO
    {
        int id;
        DateTime? dateCheckIn;
        DateTime? dateCheckOut;
        int status;

        public Bill_DTO(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.id = id;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
        }
        public Bill_DTO()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
