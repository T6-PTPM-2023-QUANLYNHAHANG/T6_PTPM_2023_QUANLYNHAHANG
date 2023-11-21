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
        public int insertCategory(FoodCategory_DTO category)
        {
            int result = 0;
            try
            {
                FoodCategory fc = new FoodCategory();
                fc.name = category.Name;
                db.FoodCategories.InsertOnSubmit(fc);
                db.SubmitChanges();
                result = fc.id;
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // delete category
        public int deleteCategory(FoodCategory_DTO category)
        {
            try
            {
                Food_BLL.Instance.deleteAllFoodbyCategoryID(category.Id);
                FoodCategory foodCategory = db.FoodCategories.Where(x => x.id == category.Id).SingleOrDefault();
                db.FoodCategories.DeleteOnSubmit(foodCategory);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        // update category
        public int updateCategory(FoodCategory_DTO category)
        {
            try
            {
                var query = db.FoodCategories.Where(x => x.id == category.Id).SingleOrDefault();
                query.name = category.Name;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
