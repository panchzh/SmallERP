using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.RP.FORM
{
    public partial class FormSelProfitCollectReport : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private DataBase db = new DataBase();

        public FormSelProfitCollectReport()
        {
            InitializeComponent();
        }

        private void FormSelProfitCollectReport_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnQuery, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            //
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

            strCondition = "Select * From SEOutStore Where SEOutStore.IsFlag = '1' ";

            //起始日期
            if (dtpStartDate.ShowCheckBox)
            {
                if (dtpStartDate.Checked)
                {
                    strCondition += " and  SEOutStore.SEOutDate >= '" + dtpStartDate.Value.ToString("yyyy-MM-dd") + "' ";
                }
            }

            //截止日期
            if (dtpEndDate.ShowCheckBox)
            {
                if (dtpEndDate.Checked)
                {
                    strCondition += " and SEOutStore.SEOutDate <= '" + dtpEndDate.Value.ToString("yyyy-MM-dd") + "' ";
                }
            }

            //产品
            if (cbxInvenCode.SelectedValue != null)
            {
                strCondition += " and SEOutStore.InvenCode  = '" + cbxInvenCode.SelectedValue + "' ";
            }

            crySelProfitCollectReport.ReportSource = commUse.CrystalReports("CrystalSelProfitCollectReport.rpt",
                                                                            strCondition, "SEOutStore");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}