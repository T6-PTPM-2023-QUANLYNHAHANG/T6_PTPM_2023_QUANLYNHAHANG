﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
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
        /// lấy danh sách bàn ăn
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
        /// <summary>
        /// đổi bàn (đổi trạng thái của bàn)
        /// </summary>
        /// <param name="idTable1"></param>
        /// <param name="idTable2"></param>
        /// <returns></returns>
        // Change tables with the input data tableId, and transfer the bill and billinfo of the two tables to each other
        public bool SwitchTable(int idTable1, int idTable2)
        {
            try
            {
                TableFood table1 = db.TableFoods.Where(x => x.id == idTable1).FirstOrDefault();
                TableFood table2 = db.TableFoods.Where(x => x.id == idTable2).FirstOrDefault();
                int idBill1 = Bill_BLL.Instance.GetUncheckBillIDByTableID(idTable1);
                int idBill2 = Bill_BLL.Instance.GetUncheckBillIDByTableID(idTable2);
                // if table1 and table2 are empty
                if (idBill1 == -1 && idBill2 == -1)
                {
                    return false;
                }
                else if (idBill1 != -1 && idBill2 == -1)
                {
                    table1.status = "Trống";
                    table2.status = "Có người";
                    db.SubmitChanges();
                    Bill_BLL.Instance.SwitchTable(idTable1, idTable2);
                }
                else
                {
                    Bill_BLL.Instance.SwitchTable(idTable1, idTable2);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// thêm bàn ăn mới
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public int insertTable(TableFood_DTO tb)
        {
            int result = 0;
            try
            {
                TableFood table = new TableFood();
                table.name = tb.Name.Trim();
                table.status = "Trống";
                db.TableFoods.InsertOnSubmit(table);
                db.SubmitChanges();
                result = table.id;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// đổi tên bàn ăn
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public int updateTable(TableFood_DTO tb)
        {
            int result = 0;
            try
            {
                TableFood table = db.TableFoods.Where(d=>d.id == tb.Id).SingleOrDefault();
                table.name = tb.Name.Trim();
                db.SubmitChanges();
                result = table.id;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// xoá bàn ăn
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public int deleteTable(TableFood_DTO tb)
        {
            try
            {
                Bill_BLL.Instance.deleteBillByTableID(tb.Id);
                TableFood table = db.TableFoods.Where(x => x.id == tb.Id).SingleOrDefault();
                db.TableFoods.DeleteOnSubmit(table);
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
