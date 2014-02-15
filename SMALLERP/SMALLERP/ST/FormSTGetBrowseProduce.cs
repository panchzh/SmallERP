using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.ST
{
    public partial class FormSTGetBrowseProduce : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormSTGetMaterial formSTGetMaterial;

        public FormSTGetBrowseProduce()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        /// <param name="strTable"> 数据表名称 </param>
        /// <param name="dgv"> DataGridView控件的实例的名称 </param>
        private void BindDataGridView(string strWhere, string strTable, DataGridView dgv)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM " + strTable + strWhere;

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

        private void FormSTGetBrowseProduce_Load(object sender, EventArgs e)
        {
            formSTGetMaterial = (FormSTGetMaterial) Owner;

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
            commUse.BindComboBox(dgvPRProduceItemInfo.Columns["InvenCode_Item"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");

            BindDataGridView(" WHERE IsFlag = '1' AND IsComplete = '0'", "PRProduce", dgvPRProduceInfo);

            if (dgvPRProduceInfo.RowCount > 0)
            {
                string strPRProduceCode = dgvPRProduceInfo["PRProduceCode", 0].Value.ToString();
                BindDataGridView(" WHERE PRProduceCode =  '" + strPRProduceCode + "'", "PRProduceItem",
                                 dgvPRProduceItemInfo);
            }
        }

        private void dgvPRProduceInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPRProduceInfo.RowCount > 0) //单击主表记录，检索子表记录信息
            {
                string strPRProduceCode =
                    dgvPRProduceInfo["PRProduceCode", dgvPRProduceInfo.CurrentCell.RowIndex].Value.ToString();
                BindDataGridView(" WHERE PRProduceCode =  '" + strPRProduceCode + "'", "PRProduceItem",
                                 dgvPRProduceItemInfo);
            }
        }

        private void dgvPRProduceItemInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPRProduceItemInfo.RowCount > 0) //双击子表记录
            {
                formSTGetMaterial.txtPRProduceCode.Text =
                    dgvPRProduceItemInfo["PRProduceCode_Item", dgvPRProduceItemInfo.CurrentCell.RowIndex].Value.ToString
                        ();
                formSTGetMaterial.cbxInvenCode.SelectedValue =
                    dgvPRProduceItemInfo["InvenCode_Item", dgvPRProduceItemInfo.CurrentCell.RowIndex].Value;
                formSTGetMaterial.txtQuantity.Text =
                    dgvPRProduceItemInfo["Quantity_Item", dgvPRProduceItemInfo.CurrentCell.RowIndex].Value.ToString();
                Close();
            }
        }

        private void dgvPRProduceInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvPRProduceItemInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}