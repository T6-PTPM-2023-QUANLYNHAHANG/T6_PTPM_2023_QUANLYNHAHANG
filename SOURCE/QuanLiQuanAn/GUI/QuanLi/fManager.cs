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
        public fManager()
        {
            InitializeComponent();
            this.Load += FManager_Load;
        }
        #region Events
        private void FManager_Load(object sender, EventArgs e)
        {
            LoadDate();
            DateTime checkin = dtpkFromDate.Value;
            DateTime checkout = dtpkToDate.Value;
            loadIncome(checkin,checkout);
        }



        #endregion
        #region methods
        private void LoadDate()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void loadIncome(DateTime checkin, DateTime checkout)
        {
            dtgvBill.DataSource = BLL.IncomeBill_BLL.Instance.GetListIncomeBillByDate(checkin,checkout);
        }

        #endregion

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            DateTime checkin = dtpkFromDate.Value;
            DateTime checkout = dtpkToDate.Value;
            loadIncome(checkin, checkout);
        }
    }
}
