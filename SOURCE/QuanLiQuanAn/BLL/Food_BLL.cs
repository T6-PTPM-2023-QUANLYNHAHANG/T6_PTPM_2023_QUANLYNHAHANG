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
        /// get list Food by idCategory
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns>List<Food_DTO></returns>
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
        /// <summary>
        /// get list food
        /// </summary>
        /// <returns>List<Food_DTO></returns>
        public List<Food_DTO> getList()
        {
            return db.Foods.Select(f => new Food_DTO { 
                Id = f.id, 
                Name = f.name, 
                Price = (float)f.price, 
                IdCategory = f.idCategory
            }).ToList();
        }
        /// <summary>
        /// thêm món ăn mới
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public int insertFood(Food_DTO food)
        {
            try
            {
                Food f = new Food();
                f.name = food.Name;
                f.idCategory = food.IdCategory;
                f.price = food.Price;
                db.Foods.InsertOnSubmit(f);
                db.SubmitChanges();
                return f.id;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }
        /// <summary>
        /// cập nhật món ăn
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public int updateFood(Food_DTO food)
        {
            try
            {
                Food f = db.Foods.Where(x => x.id == food.Id).FirstOrDefault();
                f.name = food.Name;
                f.idCategory = food.IdCategory;
                f.price = food.Price;
                db.SubmitChanges();
                return f.id;
            }
            catch (Exception)
            {

                return -1; 
            }
            
        }
        /// <summary>
        /// xoá món ăn
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public int deleteFood(Food_DTO food)
        {
            
            try
            {
                BIllinfo_BLL.Instance.deleteBillInfoByFoodID(food.Id);
                Food f = db.Foods.Where(x => x.id == food.Id).FirstOrDefault();
                db.Foods.DeleteOnSubmit(f);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        /// <summary>
        /// xoá món ăn theo id category
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        public int deleteAllFoodbyCategoryID(int idCategory)
        {
            try
            {
                List<Food_DTO> lst = getList(idCategory);
                foreach (Food_DTO item in lst)
                {
                    BIllinfo_BLL.Instance.deleteBillInfoByFoodID(item.Id);
                    Food f = db.Foods.Where(x => x.id == item.Id).FirstOrDefault();
                    db.Foods.DeleteOnSubmit(f);
                    db.SubmitChanges();
                }
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        /// <summary>
        /// yimf món ăn theo tên
        /// </summary>
        /// <param name="foodName"></param>
        /// <returns></returns>
        public List<Food_DTO> searchFoodByName(string foodName)
        {
            var Query = from f in db.Foods
                        where f.name.Contains(foodName)
                        select new Food_DTO
                        {
                            Id = f.id,
                            Name = f.name,
                            IdCategory = f.idCategory,
                            Price = (float)f.price
                        };
            return Query.ToList();

        }
    }
}
