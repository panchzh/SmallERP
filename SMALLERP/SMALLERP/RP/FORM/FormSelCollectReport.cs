using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.RP.FORM
{
    public partial class FormSelCollectReport : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private DataBase db = new DataBase();

        public FormSelCollectReport()
        {
            InitializeComponent();
        }

        private void FormSelCollectReport_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnQuery, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxCustomerCode, "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            //
            cbxCustomerCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strCondition = null;

            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("开始日期不许大于结束日期", "软件提示");
                return;
            }

            strCondition = "Select * From SEOutStore Where IsFlag = '1' ";

            //起始日期
            if (dtpStartDate.ShowCheckBox)
            {
                if (dtpStartDate.Checked)
                {
                    strCondition += " and SEOutDate >= '" + dtpStartDate.Value.ToString("yyyy-MM-dd") + "' ";
                }
            }

            //截止日期
            if (dtpEndDate.ShowCheckBox)
            {
                if (dtpEndDate.Checked)
                {
                    strCondition += " and SEOutDate <= '" + dtpEndDate.Value.ToString("yyyy-MM-dd") + "' ";
                }
            }

            //客户
            if (cbxCustomerCode.SelectedValue != null)
            {
                strCondition += " and CustomerCode = '" + cbxCustomerCode.SelectedValue + "' ";
            }

            //产品
            if (cbxInvenCode.SelectedValue != null)
            {
                strCondition += " and InvenCode = '" + cbxInvenCode.SelectedValue + "' ";
            }

            crySelCollectReport.ReportSource = commUse.CrystalReports("CrySelCollectReport.rpt", strCondition,
                                                                      "SEOutStore");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}