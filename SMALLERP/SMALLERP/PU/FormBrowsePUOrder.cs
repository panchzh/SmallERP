using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PU
{
    public partial class FormBrowsePUOrder : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormPUInStore formPUInStore;

        public FormBrowsePUOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PUOrder " + strWhere;

            try
            {
                dgvPUOrderInfo.DataSource = db.GetDataSet(strSql, "PUOrder").Tables["PUOrder"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowsePUOrder_Load(object sender, EventArgs e)
        {
            formPUInStore = (FormPUInStore) Owner;

            commUse.BindComboBox(dgvPUOrderInfo.Columns[2], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[3], "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[4], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[5], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[10], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[11], "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            BindDataGridView(" WHERE IsFlag = '1'");

            if (dgvPUOrderInfo.RowCount <= 0)
            {
                gbInfo.Text = "无已审核订单";
            }
        }

        private void dgvPUOrderInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPUOrderInfo.RowCount > 0)
            {
                formPUInStore.cbxSupplierCode.SelectedValue =
                    dgvPUOrderInfo[3, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
                formPUInStore.cbxStoreCode.SelectedValue = dgvPUOrderInfo[4, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
                formPUInStore.cbxInvenCode.SelectedValue = dgvPUOrderInfo[5, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
                formPUInStore.txtUnitPrice.Text =
                    dgvPUOrderInfo[6, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
                formPUInStore.txtQuantity.Text = dgvPUOrderInfo[7, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
                formPUInStore.txtPUMoney.Text = dgvPUOrderInfo[8, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
                formPUInStore.txtPUOrderCode.Text =
                    dgvPUOrderInfo[0, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
                Close();
            }
        }

        private void dgvPUOrderInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}