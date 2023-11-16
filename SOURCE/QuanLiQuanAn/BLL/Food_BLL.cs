using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class Food_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static Food_BLL instance;
        public static Food_BLL Instance
        {
            get { if (instance == null) instance = new Food_BLL(); return instance; }
            private set { instance = value; }
        }
        private Food_BLL() { }
        /// <summary>
        /// get list Food Category
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        public List<Food_DTO> getList(int idCategory)
        {
            var query = from f in db.Foods
                        where f.idCategory == idCategory
                        select new Food_DTO
                        {
                            Id = f.id,
                            Name = f.name,
                            IdCategory = f.idCategory,
                            Price = (float)f.price
                        };
            return query.ToList();
        }
    }
}
