using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountType_DTO
    {
        private int id;
        private string name;

        public AccountType_DTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public AccountType_DTO()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
