using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Food_DTO
    {
        private int id;
        private string name;
        private int idCategory;
        private float price;

        public Food_DTO(int id, string name, int idCategory, float price)
        {
            this.id = id;
            this.name = name;
            this.idCategory = idCategory;
            this.price = price;
        }
        public Food_DTO()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
