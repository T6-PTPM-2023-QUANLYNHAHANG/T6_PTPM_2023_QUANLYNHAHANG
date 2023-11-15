using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableFood_DTO
    {
        int id;
        string name;
        string status;

        public TableFood_DTO(int id, string name, string status)
        {
            this.id = id;
            this.name = name;
            this.status = status;
        }
        public TableFood_DTO()
        {
                
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
