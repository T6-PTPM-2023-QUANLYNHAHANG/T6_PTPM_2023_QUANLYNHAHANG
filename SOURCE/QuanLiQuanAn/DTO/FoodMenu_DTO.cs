using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FoodMenu_DTO
    {
        string foodName;
        int count;
        float price;
        float totalPrice;

        public FoodMenu_DTO(string foodName, int count, float price, float totalPrice)
        {
            this.foodName = foodName;
            this.count = count;
            this.price = price;
            this.totalPrice = totalPrice;
        }
        public FoodMenu_DTO()
        {
            
        }
        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
