using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;
//////更多大型项目源码http://yulei133.3322.org/
namespace SMALLERP.PR
{
    public partial class FormBrowsePRPlan : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormPRProduce formPRProduce;

        public FormBrowsePRPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PRPlan " + strWhere;

            try
            {
                dgvPRPlanInfo.DataSource = db.GetDataSet(strSql, "PRPlan").Tables["PRPlan"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBrowsePRPlan_Load(object sender, EventArgs e)
        {
            formPRProduce = (FormPRProduce) Owner;
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvPRPlanInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPRPlanInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPRPlanInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            BindDataGridView(" WHERE IsFlag = '1'");

            if (dgvPRPlanInfo.RowCount <= 0)
            {
                gbInfo.Text = "无已审核订单";
            }
        }

        private void dgvPRPlanInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPRPlanInfo.RowCount > 0)
            {
                string strPRPlanCode = dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentRow.Index].Value.ToString();
                DataGridViewRowCollection dgvrc = formPRProduce.dgvPRProduceInfo.Rows;

                //判断该笔主生产计划单是否已经制定了生产单
                foreach (DataGridViewRow dgvr in dgvrc)
                {
                    if (strPRPlanCode == dgvr.Cells["PRPlanCode"].Value.ToString())
                    {
                        MessageBox.Show("该主生产计划已制定相应的生产单！", "软件提示");
                        return;
                    }
                }

                formPRProduce.txtPRPlanCode.Text =
                    dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
                formPRProduce.cbxInvenCode.SelectedValue =
                    dgvPRPlanInfo["InvenCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value;
                formPRProduce.txtQuantity.Text =
                    dgvPRPlanInfo["Quantity", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
                formPRProduce.dtpEndDate.Value =
                    Convert.ToDateTime(dgvPRPlanInfo["FinishDate", dgvPRPlanInfo.CurrentCell.RowIndex].Value);
                Close();
            }
        }

        private void dgvPRPlanInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}