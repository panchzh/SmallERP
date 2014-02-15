using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.SE
{
    public partial class FormBrowseSEOutStore : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormSEGather formSEGather;

        public FormBrowseSEOutStore()
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
            strSql += "FROM SEOutStore " + strWhere;

            try
            {
                dgvSEOutStoreInfo.DataSource = db.GetDataSet(strSql, "SEOutStore").Tables["SEOutStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowseSEOutStore_Load(object sender, EventArgs e)
        {
            formSEGather = (FormSEGather) Owner;

            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["CustomerCode"], "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSEOutStoreInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            BindDataGridView(" WHERE IsFlag = '1'");

            if (dgvSEOutStoreInfo.RowCount <= 0)
            {
                gbInfo.Text = "无已审核销售出库单";
            }
        }

        private void dgvSEOutStoreInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSEOutStoreInfo.RowCount > 0)
            {
                formSEGather.txtSEOutCode.Text =
                    dgvSEOutStoreInfo["SEOutCode", dgvSEOutStoreInfo.CurrentCell.RowIndex].Value.ToString();
                formSEGather.dtpSEOutDate.Value =
                    Convert.ToDateTime(dgvSEOutStoreInfo["SEOutDate", dgvSEOutStoreInfo.CurrentCell.RowIndex].Value);
                formSEGather.cbxCustomerCode.SelectedValue =
                    dgvSEOutStoreInfo["CustomerCode", dgvSEOutStoreInfo.CurrentCell.RowIndex].Value;
                formSEGather.txtSEMoney.Text =
                    dgvSEOutStoreInfo["SEMoney", dgvSEOutStoreInfo.CurrentCell.RowIndex].Value.ToString();
                Close();
            }
        }

        private void dgvSEOutStoreInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}