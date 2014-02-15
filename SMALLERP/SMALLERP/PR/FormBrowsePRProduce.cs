using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PR
{
    public partial class FormBrowsePRProduce : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormPRInStore formPRInStore;
        private FormProduceComplete formProduceComplete;

        public FormBrowsePRProduce()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strSql"> Transact-SQL语句 </param>
        /// <param name="strTable"> 数据表名称 </param>
        /// <param name="dgv"> DataGridView控件的实例的名称 </param>
        private void BindDataGridView(string strSql, string strTable, DataGridView dgv)
        {
            try
            {
                dgv.DataSource = db.GetDataSet(strSql, strTable).Tables[strTable];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowsePRProduce_Load(object sender, EventArgs e)
        {
            string strSql = null;

            if (Owner.GetType() == typeof (FormProduceComplete))
            {
                formProduceComplete = (FormProduceComplete) Owner;
                strSql = "Select * From PRProduce Where IsFlag = '1'";
                Text = "浏览已审核生产单";
            }

            if (Owner.GetType() == typeof (FormPRInStore))
            {
                formPRInStore = (FormPRInStore) Owner;
                strSql = "Select * From PRProduce Where IsComplete = '1'"; //完工的，一定是审核的
                Text = "浏览完工生产单";
            }

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvPRProduceInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPRProduceInfo.Columns["DepartmentCode"], "DepartmentCode", "DepartmentName",
                                 "select DepartmentCode,DepartmentName from BSDepartment", "BSDepartment");
            commUse.BindComboBox(dgvPRProduceInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPRProduceInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPRProduceInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");
            commUse.BindComboBox(dgvPRProduceInfo.Columns["IsComplete"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            BindDataGridView(strSql, "PRProduce", dgvPRProduceInfo);
        }

        private void dgvPRProduceInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPRProduceInfo.RowCount > 0)
            {
                if (formProduceComplete != null)
                {
                    string strPRProduceCode =
                        dgvPRProduceInfo["PRProduceCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                    object objIsComplete = dgvPRProduceInfo["IsComplete", dgvPRProduceInfo.CurrentCell.RowIndex].Value;

                    formProduceComplete.txtPRProduceCode.Text = strPRProduceCode;
                    formProduceComplete.dtpPRProduceDate.Value =
                        Convert.ToDateTime(
                            dgvPRProduceInfo["PRProduceDate", dgvPRProduceInfo.CurrentCell.RowIndex].Value);
                    formProduceComplete.cbxOperatorCode.SelectedValue =
                        dgvPRProduceInfo["OperatorCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value;
                    formProduceComplete.txtPRPlanCode.Text =
                        dgvPRProduceInfo["PRPlanCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                    formProduceComplete.cbxDepartmentCode.SelectedValue =
                        dgvPRProduceInfo["DepartmentCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value;
                    formProduceComplete.cbxInvenCode.SelectedValue =
                        dgvPRProduceInfo["InvenCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value;
                    formProduceComplete.txtQuantity.Text =
                        dgvPRProduceInfo["Quantity", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                    formProduceComplete.dtpStartDate.Value =
                        Convert.ToDateTime(dgvPRProduceInfo["StartDate", dgvPRProduceInfo.CurrentCell.RowIndex].Value);
                    formProduceComplete.dtpEndDate.Value =
                        Convert.ToDateTime(dgvPRProduceInfo["EndDate", dgvPRProduceInfo.CurrentCell.RowIndex].Value);
                    formProduceComplete.cbxIsComplete.SelectedValue = objIsComplete;

                    string strSql =
                        "Select PRProduceItem.Id, PRProduceItem.PRProduceCode,PRProduceItem.InvenCode, BSInven.InvenName, PRProduceItem.Quantity, PRProduceItem.GetQuantity, PRProduceItem.UseQuantity ";
                    strSql +=
                        "From PRProduceItem,BSInven Where PRProduceItem.InvenCode = BSInven.InvenCode and PRProduceItem.PRProduceCode = '" +
                        strPRProduceCode + "'";
                    BindDataGridView(strSql, "PRProduceItem", formProduceComplete.dgvPRProduceItemInfo);

                    if (objIsComplete.ToString() == "1")
                    {
                        formProduceComplete.dgvPRProduceItemInfo.Columns["UseQuantity"].ReadOnly = true;
                    }
                    else
                    {
                        formProduceComplete.dgvPRProduceItemInfo.Columns["UseQuantity"].ReadOnly = false;
                    }
                }

                if (formPRInStore != null)
                {
                    string strPRProduceCode =
                        dgvPRProduceInfo["PRProduceCode", dgvPRProduceInfo.CurrentRow.Index].Value.ToString();
                    DataGridViewRowCollection dgvrc = formPRInStore.dgvPRInStoreInfo.Rows;

                    foreach (DataGridViewRow dgvr in dgvrc)
                    {
                        //判断该笔生产单是否已生成相应的产品入库单
                        if (strPRProduceCode == dgvr.Cells["PRProduceCode"].Value.ToString())
                        {
                            MessageBox.Show("该生产单已生成相应的生产入库单！", "软件提示");
                            return;
                        }
                    }

                    formPRInStore.txtPRProduceCode.Text =
                        dgvPRProduceInfo["PRProduceCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                    formPRInStore.cbxInvenCode.SelectedValue =
                        dgvPRProduceInfo["InvenCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value;
                    formPRInStore.txtPRQuantity.Text =
                        dgvPRProduceInfo["Quantity", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                    formPRInStore.txtInQuantity.Text = formPRInStore.txtPRQuantity.Text;
                }

                Close();
            }
        }

        private void dgvPRProduceInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}