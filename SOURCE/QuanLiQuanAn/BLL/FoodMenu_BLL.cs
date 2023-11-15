using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class FoodMenu_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static FoodMenu_BLL instance;
        public static FoodMenu_BLL Instance { get { if (instance == null) instance = new FoodMenu_BLL(); return instance; } private set => instance = value; }
        private FoodMenu_BLL() { }
        // get list FoodMenu
        /// <summary>
        /// get list FoodMenu
        /// </summary>
        /// <param name="billID"></param>
        /// <returns> list foodmenu</returns>
        public List<FoodMenu_DTO> getListFoodMenu(int billID)
        {
            List<FoodMenu_DTO> lst = new List<FoodMenu_DTO>();
            var query = from binfo in db.BillInfos
                        join b in db.Bills on binfo.idBill equals b.id
                        join f1 in db.Foods on binfo.idFood equals f1.id
                        where b.id == billID
                        select new
                        {
                            foodName = f1.name,
                            count = binfo.count,
                            price = f1.price,
                            totalPrice = binfo.count * f1.price
                        };
            foreach (var item in query)
            {
                FoodMenu_DTO foodMenu = new FoodMenu_DTO(item.foodName, item.count, (float)item.price, (float)item.totalPrice);
                lst.Add(foodMenu);
            }
            return lst;
        }
    }
}
