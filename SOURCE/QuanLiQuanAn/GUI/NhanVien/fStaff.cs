using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVien
{
    public partial class fStaff : Form
    {
        public fStaff()
        {
            InitializeComponent();
            this.Load += FStaff_Load;
        }
        #region Event
        private void FStaff_Load(object sender, EventArgs e)
        {
            loadTableFood();
            loadFoodCategory();
            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(cbCategory.SelectedValue.ToString());
            loadFood(idCategory);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableFood_DTO).Id;
            lsvBill.Tag = ((sender as Button).Tag as TableFood_DTO);
            showBill(tableID);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int idTable = (lsvBill.Tag as TableFood_DTO).Id;
            
            int idBill = Bill_BLL.Instance.GetUncheckBillIDByTableID(idTable);
            int idFood = (cbFood.SelectedItem as Food_DTO).Id;
            int count = (int)nmFoodCount.Value;
            // idBill don't exist
            if (idBill == -1)
            {
                int newidBill = BLL.Bill_BLL.Instance.insertBill(idTable);
                BLL.BIllinfo_BLL.Instance.insertBillinfo(newidBill, idFood, count);
            }
            // idBill exist
            else
            {
                int idBillInfo = BLL.BIllinfo_BLL.Instance.isHaveFoodinBillinfo(idBill, idFood);
                // idBillInfo don't exist
                if (idBillInfo == 0)
                {
                    if (count <= 0)
                    {
                        return;
                    }
                    BLL.BIllinfo_BLL.Instance.insertBillinfo(idBill, idFood, count);
                }
                // idBillInfo exist
                else
                {
                    BLL.BIllinfo_BLL.Instance.updateBillinfo(idBillInfo, idFood, count);
                }
            }
            showBill(idTable);
        }
        #endregion



        #region Method
        private void loadFood(int idCategory)
        {
            cbFood.DataSource = Food_BLL.Instance.getList(idCategory);
            cbFood.DisplayMember = "Name";
            cbFood.ValueMember = "Id";
            
        }
        private void loadFoodCategory()
        {
            cbCategory.DataSource = FoodCategory_BLL.Instance.getList();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            int idCategory = Convert.ToInt32(cbCategory.SelectedValue.ToString());
            loadFood(idCategory);

        }
        private void loadTableFood()
        {
            List<TableFood_DTO> lst = BLL.TableFood_BLL.Instance.getList();
            foreach (TableFood_DTO item in lst)
            {
                Button btn = new Button() { Width = 100, Height = 100 };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
               
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }



        private void showBill(int tableID)
        {
            lsvBill.Items.Clear();

            int billID = BLL.Bill_BLL.Instance.GetUncheckBillIDByTableID(tableID);
            List<FoodMenu_DTO> lst = FoodMenu_BLL.Instance.getListFoodMenu(billID);
            float totalPrice = 0;
            foreach (FoodMenu_DTO item in lst)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = totalPrice.ToString("c", culture);
        }


        #endregion

        
    }
}
