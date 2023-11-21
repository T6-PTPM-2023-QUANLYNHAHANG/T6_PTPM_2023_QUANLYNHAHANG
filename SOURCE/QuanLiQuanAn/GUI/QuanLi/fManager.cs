using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLi
{
    public partial class fManager : Form
    {
        Account_DTO acc;

        public Account_DTO Acc { get => acc; set => acc = value; }
        BindingSource foodList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        public fManager(Account_DTO account)
        {
            InitializeComponent();
            this.acc = account;
            this.Load += FManager_Load;
        }




        #region Events
        private void FManager_Load(object sender, EventArgs e)
        {

            dtgvFood.DataSource = foodList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            LoadDate();
            DateTime checkin = dtpkFromDate.Value;
            DateTime checkout = dtpkToDate.Value;
            loadIncome(checkin, checkout);
            loadCbbCategory();
            loadFood();
            loadFoodBinding();
            loadCategory();
            loadCategoryBinding();
            loadTable();
            loadTableBinding();
            loadAccount();
            loadCbbAccountType();
            loadAccountBinding();
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
                if (insertEvent != null)
                    insertEvent(this, new EventArgs());

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

                if (updateEvent != null)
                    updateEvent(this, new EventArgs());

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
                if (deleteEvent != null)
                    deleteEvent(this, new EventArgs());

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
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            loadCategory();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            FoodCategory_DTO cate = GetCategory();
            if (BLL.FoodCategory_BLL.Instance.insertCategory(cate) > 0)
            {
                MessageBox.Show("Thêm danh mục thành công");
                loadCbbCategory();
                loadCategory();
                if (insertEvent != null)
                    insertEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại");
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            FoodCategory_DTO cate = GetCategory();
            if (BLL.FoodCategory_BLL.Instance.deleteCategory(cate) > 0)
            {
                MessageBox.Show("Xóa danh mục thành công");
                loadCbbCategory();
                loadCategory();
                if (deleteEvent != null)
                    deleteEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại");
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            FoodCategory_DTO cate = GetCategory();
            if (BLL.FoodCategory_BLL.Instance.updateCategory(cate) > 0)
            {
                MessageBox.Show("Sửa danh mục thành công");
                loadCbbCategory();
                loadCategory();
                if (updateEvent != null)
                    updateEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa danh mục thất bại");
            }
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            loadTable();
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            TableFood_DTO tb = getTable();
            if (BLL.TableFood_BLL.Instance.insertTable(tb) > 0)
            {
                MessageBox.Show("Thêm bàn thành công");
                loadTable();
                if (insertEvent != null)
                    insertEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            TableFood_DTO tb = getTable();
            if (BLL.TableFood_BLL.Instance.deleteTable(tb) > 0)
            {
                MessageBox.Show("Xóa bàn thành công");
                loadTable();
                if (deleteEvent != null)
                    deleteEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            TableFood_DTO tb = getTable();
            if (BLL.TableFood_BLL.Instance.updateTable(tb) > 0)
            {
                MessageBox.Show("Sửa bàn thành công");
                loadTable();
                if (updateEvent != null)
                    updateEvent(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa bàn thất bại");
            }
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            Account_DTO newAcc =  getAccount();
            if (BLL.Account_BLL.Instance.insertAccount(newAcc) > 0)
            {
                MessageBox.Show("Thêm tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }

        

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            Account_DTO newAcc = getAccount();
            if (acc.Username == newAcc.Username)
            {
                MessageBox.Show("Bạn không được xóa tài khoản đang truy cập hiện tại)");
                return;
            }
            if (BLL.Account_BLL.Instance.deleteAccount(newAcc.Username) > 0)
            {
                MessageBox.Show("Xóa tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            Account_DTO newAcc = getAccount();
            if (BLL.Account_BLL.Instance.updateAccount(newAcc) > 0)
            {
                MessageBox.Show("Sửa tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại");
            }
        }
        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            if (txbUserName.ReadOnly == true)
            {
                txbUserName.ReadOnly = false;
                btnEditAccount.Enabled = false;
                btnDeleteAccount.Enabled = false;
                btnAddAccount.Enabled = true;
            }
            else
            {
                txbUserName.ReadOnly = true;
                btnEditAccount.Enabled = true;
                btnDeleteAccount.Enabled = true;
                btnAddAccount.Enabled = false;
            }
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            Account_DTO newAcc = getAccount();
            if (BLL.Account_BLL.Instance.resetPassword(newAcc.Username) > 0)
            {
                MessageBox.Show("Reset tài khoản thành công");
                loadAccount();
            }
            else
            {
                MessageBox.Show("Reset tài khoản thất bại");
            }
        }
        #endregion




        #region methods
        private Account_DTO getAccount()
        {
            string username = txbUserName.Text;
            string displayname = txbDisplayName.Text;
            string password = "0";
            int idType = Convert.ToInt32(cbAccountType.SelectedValue.ToString());
            return new Account_DTO(username, displayname, password, idType);
        }
        private void loadCbbAccountType()
        {
            cbAccountType.DataSource = BLL.AccountType_BLL.Instance.GetListAccountType();
            cbAccountType.DisplayMember = "Name";
            cbAccountType.ValueMember = "Id";
        }
        private void loadAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Displayname", true, DataSourceUpdateMode.Never));
            cbAccountType.DataBindings.Add(new Binding("SelectedValue", dtgvAccount.DataSource, "IdType", true, DataSourceUpdateMode.Never));
        }

        private void loadAccount()
        {
            dtgvAccount.DataSource = BLL.Account_BLL.Instance.GetListAccount();
        }
        private void loadTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));

        }
        private void loadTable()
        {
            tableList.DataSource = BLL.TableFood_BLL.Instance.getList();
        }
        private void loadCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        private void loadCategory()
        {
            categoryList.DataSource = BLL.FoodCategory_BLL.Instance.getList();
        }
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
        private void loadCbbCategory()
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
        private FoodCategory_DTO GetCategory()
        {
            int id = Convert.ToInt32(txbCategoryID.Text);
            string name = txbCategoryName.Text;
            return new FoodCategory_DTO(id, name);
        }
        private TableFood_DTO getTable()
        {
            int id = Convert.ToInt32(txbTableID.Text);
            string name = txbTableName.Text;
            return new TableFood_DTO(id, name , "Trống");
        }
        private void SearchFood(string foodName)
        {
            foodList.DataSource = BLL.Food_BLL.Instance.searchFoodByName(foodName);
        }

        #endregion




        private event EventHandler insertEvent;
        public event EventHandler InsertEvent
        {
            add { insertEvent += value; }
            remove { insertEvent -= value; }
        }

        private event EventHandler deleteEvent;
        public event EventHandler DeleteEvent
        {
            add { deleteEvent += value; }
            remove { deleteEvent -= value; }
        }

        private event EventHandler updateEvent;
        public event EventHandler UpdateEvent
        {
            add { updateEvent += value; }
            remove { updateEvent -= value; }
        }

        
    }
}
