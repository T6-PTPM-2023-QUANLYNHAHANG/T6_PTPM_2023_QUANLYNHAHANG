using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLi
{
    public partial class fManager : Form
    {
        BindingSource foodList = new BindingSource();
        public fManager()
        {
            InitializeComponent();
            this.Load += FManager_Load;
        }
        #region Events
        private void FManager_Load(object sender, EventArgs e)
        {
            
            dtgvFood.DataSource = foodList;
            LoadDate();
            DateTime checkin = dtpkFromDate.Value;
            DateTime checkout = dtpkToDate.Value;
            loadIncome(checkin, checkout);
            loadCategory();
            loadFood();
            loadFoodBinding();
        }

       

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            loadFood();
        }


        private void btnViewBill_Click(object sender, EventArgs e)
        {
            DateTime checkin = dtpkFromDate.Value;
            DateTime checkout = dtpkToDate.Value;
            loadIncome(checkin, checkout);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Food_DTO food = GetFood();
            if (BLL.Food_BLL.Instance.insertFood(food) > 0)
            {
                MessageBox.Show("Thêm món thành công");
                loadFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Thêm món thất bại");
            }
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            Food_DTO food = GetFood();
            if (BLL.Food_BLL.Instance.updateFood(food) > 0)
            {
                MessageBox.Show("Sửa món thành công");
                loadFood();

                if (updateFood != null)
                    updateFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Sửa món thất bại");
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            Food_DTO food = GetFood();
            if (BLL.Food_BLL.Instance.deleteFood(food) > 0)
            {
                MessageBox.Show("Xóa món thành công");
                loadFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Xóa món thất bại");
            }
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            SearchFood(txbSearchFoodName.Text);
        }
        #endregion
        #region methods
        private void loadFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Id", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
            cbFoodCategory.DataBindings.Add(new Binding("SelectedValue", dtgvFood.DataSource, "IdCategory", true, DataSourceUpdateMode.Never));
        }
        private void LoadDate()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void loadIncome(DateTime checkin, DateTime checkout)
        {
            dtgvBill.DataSource = BLL.IncomeBill_BLL.Instance.GetListIncomeBillByDate(checkin, checkout);
        }
        private void loadFood()
        {
            foodList.DataSource = BLL.Food_BLL.Instance.getList();
        }
        private void loadCategory()
        {
            cbFoodCategory.DataSource = BLL.FoodCategory_BLL.Instance.getList();
            cbFoodCategory.DisplayMember = "Name";
            cbFoodCategory.ValueMember = "Id";
        }
        private Food_DTO GetFood()
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            string name = txbFoodName.Text;
            int idCategory = Convert.ToInt32(cbFoodCategory.SelectedValue.ToString());
            float price = (float)nmFoodPrice.Value;
            return new Food_DTO(id, name, idCategory, price);
        }
        private void SearchFood(string foodName)
        {
            foodList.DataSource = BLL.Food_BLL.Instance.searchFoodByName(foodName);
        }

        #endregion
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        

        
    }
}
