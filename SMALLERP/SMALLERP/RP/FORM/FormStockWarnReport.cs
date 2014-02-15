using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.RP.FORM
{
    public partial class FormStockWarnReport : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private DataBase db = new DataBase();

        public FormStockWarnReport()
        {
            InitializeComponent();
        }

        private void FormStockWarnReport_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnQuery, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            //
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strCondition = null;
            strCondition =
                "( {STStock.Quantity} < {BSInven.SmallStockNum} or {STStock.Quantity} > {BSInven.BigStockNum} )";

            //存货
            if (cbxStoreCode.SelectedValue != null)
            {
                strCondition += " and {STStock.StoreCode} = '" + cbxStoreCode.SelectedValue + "' ";
            }

            //仓库
            if (cbxInvenCode.SelectedValue != null)
            {
                strCondition += " and {STStock.InvenCode} = '" + cbxInvenCode.SelectedValue + "' ";
            }

            cryStockWarnReport.ReportSource = commUse.CrystalReports("CryStockWarnReport.rpt", strCondition);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}