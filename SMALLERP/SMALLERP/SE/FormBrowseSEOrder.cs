using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;
using SMALLERP.PR;

namespace SMALLERP.SE
{
    public partial class FormBrowseSEOrder : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormPRPlan formPRPlan;
        private FormSEOutStore formSEOutStore;

        public FormBrowseSEOrder()
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
            strSql += "FROM SEOrder " + strWhere;

            try
            {
                dgvSEOrderInfo.DataSource = db.GetDataSet(strSql, "SEOrder").Tables["SEOrder"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowseSEOrder_Load(object sender, EventArgs e)
        {
            if (Owner.GetType() == typeof (FormSEOutStore))
            {
                formSEOutStore = (FormSEOutStore) Owner;
            }

            if (Owner.GetType() == typeof (FormPRPlan))
            {
                formPRPlan = (FormPRPlan) Owner;
            }

            commUse.BindComboBox(dgvSEOrderInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSEOrderInfo.Columns["CustomerCode"], "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvSEOrderInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSEOrderInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSEOrderInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSEOrderInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            BindDataGridView(" WHERE IsFlag = '1'");

            if (dgvSEOrderInfo.RowCount <= 0)
            {
                gbInfo.Text = "无已审核订单";
            }
        }

        private void dgvSEOrderInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSEOrderInfo.RowCount > 0)
            {
                if (formSEOutStore != null)
                {
                    formSEOutStore.cbxCustomerCode.SelectedValue =
                        dgvSEOrderInfo["CustomerCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value;
                    formSEOutStore.cbxStoreCode.SelectedValue =
                        dgvSEOrderInfo["StoreCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value;
                    formSEOutStore.cbxInvenCode.SelectedValue =
                        dgvSEOrderInfo["InvenCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value;
                    formSEOutStore.txtSellPrice.Text =
                        dgvSEOrderInfo["SellPrice", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                    formSEOutStore.txtQuantity.Text =
                        dgvSEOrderInfo["Quantity", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                    formSEOutStore.txtSEMoney.Text =
                        dgvSEOrderInfo["SEMoney", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                    formSEOutStore.txtSEOrderCode.Text =
                        dgvSEOrderInfo["SEOrderCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                    formSEOutStore.cbxEmployeeCode.SelectedValue =
                        dgvSEOrderInfo["EmployeeCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value;
                }

                if (formPRPlan != null)
                {
                    string strSEOrderCode =
                        dgvSEOrderInfo["SEOrderCode", dgvSEOrderInfo.CurrentRow.Index].Value.ToString();
                    DataGridViewRowCollection dgvrc = formPRPlan.dgvPRPlanInfo.Rows;

                    foreach (DataGridViewRow dgvr in dgvrc)
                    {
                        if (dgvr.Cells["SEOrderCode"] != null)
                        {
                            if (strSEOrderCode == dgvr.Cells["SEOrderCode"].Value.ToString())
                            {
                                MessageBox.Show("该销售订单已制定相应的主生产计划！", "软件提示");
                                return;
                            }
                        }
                    }

                    formPRPlan.txtSEOrderCode.Text =
                        dgvSEOrderInfo["SEOrderCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                    formPRPlan.cbxInvenCode.SelectedValue =
                        dgvSEOrderInfo["InvenCode", dgvSEOrderInfo.CurrentCell.RowIndex].Value;
                    formPRPlan.txtQuantity.Text =
                        dgvSEOrderInfo["Quantity", dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
                }

                Close();
            }
        }

        private void dgvSEOrderInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}