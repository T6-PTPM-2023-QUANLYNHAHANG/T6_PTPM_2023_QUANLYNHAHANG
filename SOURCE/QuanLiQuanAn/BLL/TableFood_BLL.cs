using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TableFood_BLL
    {
        QLNhaHangDataContext db = new QLNhaHangDataContext();
        private static TableFood_BLL instance;
        public static TableFood_BLL Instance { get { if (instance == null) instance = new TableFood_BLL(); return instance; } private set => instance = value; }
        private TableFood_BLL() { }
        /// <summary>
        /// Get list TableFood
        /// </summary>
        /// <returns> list table food</returns>
        public List<TableFood_DTO> getList()
        {
            List<TableFood_DTO> lst = new List<TableFood_DTO>();
            lst = db.TableFoods.Select(u => new TableFood_DTO
            {
                Id = u.id,
                Name = u.name,
                Status = u.status
            }).ToList();
            return lst;
        }
    }
}
