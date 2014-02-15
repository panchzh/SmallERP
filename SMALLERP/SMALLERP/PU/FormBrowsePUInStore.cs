using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PU
{
    public partial class FormBrowsePUInStore : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormPUPay formPUPay;

        public FormBrowsePUInStore()
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
            strSql += "FROM PUInStore " + strWhere;

            try
            {
                dgvPUInStoreInfo.DataSource = db.GetDataSet(strSql, "PUInStore").Tables["PUInStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowsePUInStore_Load(object sender, EventArgs e)
        {
            formPUPay = (FormPUPay) Owner;

            commUse.BindComboBox(dgvPUInStoreInfo.Columns[2], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[3], "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[4], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[5], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[10], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[11], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            BindDataGridView(" WHERE IsFlag = '1'");

            if (dgvPUInStoreInfo.RowCount <= 0)
            {
                gbInfo.Text = "无已审核采购入库单";
            }
        }

        private void dgvPUInStoreInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPUInStoreInfo.RowCount > 0)
            {
                formPUPay.txtPUInCode.Text =
                    dgvPUInStoreInfo["PUInCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
                formPUPay.dtpPUInDate.Value =
                    Convert.ToDateTime(dgvPUInStoreInfo["PUInDate", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
                formPUPay.cbxSupplierCode.SelectedValue =
                    dgvPUInStoreInfo["SupplierCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
                formPUPay.txtPUMoney.Text =
                    dgvPUInStoreInfo["PUMoney", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
                Close();
            }
        }

        private void dgvPUInStoreInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}