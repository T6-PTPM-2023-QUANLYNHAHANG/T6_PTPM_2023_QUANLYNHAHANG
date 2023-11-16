using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class FoodCategory_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static FoodCategory_BLL instance;
        public static FoodCategory_BLL Instance 
        {
            get { if (instance == null) instance = new FoodCategory_BLL(); return instance; }
            private set { instance = value; }
        }
        private FoodCategory_BLL() { }
        /// <summary>
        /// get list FoodCategory
        /// </summary>
        /// <returns></returns>
        public List<FoodCategory_DTO> getList()
        {
           var query = from fc in db.FoodCategories
                       select new FoodCategory_DTO
                       {
                           Id = fc.id,
                           Name = fc.name
                       };
            return query.ToList();
        }
    }
}
