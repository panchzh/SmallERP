using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{
    public partial class FormCustomerCourse : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormCustomerCourse()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strCustomerCode"> 客户代码 </param>
        /// <param name="strTable"> 数据表的名称 </param>
        /// <param name="dgv"> DataGridView控件的实例的名称 </param>
        public void BindDataGridView(string strCustomerCode, string strTable, DataGridView dgv)
        {
            string strSql = "Select * From " + strTable + " Where CustomerCode = '" + strCustomerCode + "'";

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

        private void FormCustomerCourse_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //dgvSell的DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvSell.Columns["CustomerCode_Sell"], "CustomerCode", "CustomerName",
                                 "Select CustomerCode,CustomerName From BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvSell.Columns["ChanceCode"], "ChanceCode", "ChanceName",
                                 "Select ChanceCode,ChanceName From CUChance", "CUChance");
            commUse.BindComboBox(dgvSell.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "Select InvenCode,InvenName From BSInven", "BSInven");
            //dgvRel的DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvRel.Columns["CustomerCode_Rel"], "CustomerCode", "CustomerName",
                                 "Select CustomerCode,CustomerName From BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvRel.Columns["RelManner"], "Code", "Name", "select Code,Name from INRelManner",
                                 "INRelManner");
            //dgvAfter的DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvAfter.Columns["CustomerCode_After"], "CustomerCode", "CustomerName",
                                 "Select CustomerCode,CustomerName From BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvAfter.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "Select EmployeeCode,EmployeeName From BSEmployee", "BSEmployee");
            //tvCustomer绑定到数据源
            commUse.BuildTree(tvCustomer, imageList1, "客户信息", "BSCustomer", "CustomerCode", "CustomerName");
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tvCustomer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            commUse.DataGridViewReset(dgvSell); //清空dgvSell
            commUse.DataGridViewReset(dgvRel); //清空dgvRel
            commUse.DataGridViewReset(dgvAfter); //清空dgvAfter

            if (tvCustomer.SelectedNode != null)
            {
                if (tvCustomer.SelectedNode.Tag != null)
                {
                    BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CUSellChance", dgvSell);
                    BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CURelRecord", dgvRel);
                    BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CUAfterService", dgvAfter);
                }
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (tvCustomer.SelectedNode != null)
            {
                if (tvCustomer.SelectedNode.Tag != null)
                {
                    if (tcMain.SelectedTab.Equals(tpSell)) //判断当前选择的选项卡
                    {
                        FormCUSellChance formCUSellChance = new FormCUSellChance();
                        formCUSellChance.Tag = "Add";
                        formCUSellChance.Owner = this;
                        formCUSellChance.ShowDialog();
                    }

                    if (tcMain.SelectedTab.Equals(tpRel)) //判断当前选择的选项卡
                    {
                        FormCURelRecord formCURelRecord = new FormCURelRecord();
                        formCURelRecord.Tag = "Add";
                        formCURelRecord.Owner = this;
                        formCURelRecord.ShowDialog();
                    }

                    if (tcMain.SelectedTab.Equals(tpAfter)) //判断当前选择的选项卡
                    {
                        FormCUAfterService formCUAfterService = new FormCUAfterService();
                        formCUAfterService.Tag = "Add";
                        formCUAfterService.Owner = this;
                        formCUAfterService.ShowDialog();
                    }
                }
            }
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            if (tvCustomer.SelectedNode != null)
            {
                if (tvCustomer.SelectedNode.Tag != null)
                {
                    if (tcMain.SelectedTab.Equals(tpSell)) //判断当前选择的选项卡
                    {
                        if (dgvSell.RowCount > 0)
                        {
                            FormCUSellChance formCUSellChance = new FormCUSellChance();
                            formCUSellChance.Tag = "Edit";
                            formCUSellChance.Owner = this;
                            formCUSellChance.ShowDialog();
                        }
                    }

                    if (tcMain.SelectedTab.Equals(tpRel)) //判断当前选择的选项卡
                    {
                        if (dgvRel.RowCount > 0)
                        {
                            FormCURelRecord formCURelRecord = new FormCURelRecord();
                            formCURelRecord.Tag = "Edit";
                            formCURelRecord.Owner = this;
                            formCURelRecord.ShowDialog();
                        }
                    }

                    if (tcMain.SelectedTab.Equals(tpAfter)) //判断当前选择的选项卡
                    {
                        if (dgvAfter.RowCount > 0)
                        {
                            FormCUAfterService formCUAfterService = new FormCUAfterService();
                            formCUAfterService.Tag = "Edit";
                            formCUAfterService.Owner = this;
                            formCUAfterService.ShowDialog();
                        }
                    }
                }
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            //销售机会档案
            if (tcMain.SelectedTab.Equals(tpSell)) //判断当前选择的选项卡
            {
                if (dgvSell.RowCount > 0)
                {
                    int intSellId;
                    string strSql = null;

                    intSellId = Convert.ToInt32(dgvSell["SellId", dgvSell.CurrentCell.RowIndex].Value);
                    strSql = "DELETE FROM CUSellChance WHERE SellId = " + intSellId;

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                            }
                            else
                            {
                                MessageBox.Show("删除失败！", "软件提示");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "软件提示");
                            throw ex;
                        }

                        BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CUSellChance", dgvSell);
                    }
                }
            }

            //联系记录档案
            if (tcMain.SelectedTab.Equals(tpRel)) //判断当前选择的选项卡
            {
                if (dgvRel.RowCount > 0)
                {
                    int intRelId;
                    string strSql = null;

                    intRelId = Convert.ToInt32(dgvRel["RelId", dgvRel.CurrentCell.RowIndex].Value);
                    strSql = "DELETE FROM CURelRecord WHERE RelId = " + intRelId;

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                            }
                            else
                            {
                                MessageBox.Show("删除失败！", "软件提示");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "软件提示");
                            throw ex;
                        }

                        BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CURelRecord", dgvRel);
                    }
                }
            }

            //售后服务档案
            if (tcMain.SelectedTab.Equals(tpAfter)) //判断当前选择的选项卡
            {
                if (dgvAfter.RowCount > 0)
                {
                    int intAfterId;
                    string strSql = null;

                    intAfterId = Convert.ToInt32(dgvAfter["AfterId", dgvAfter.CurrentCell.RowIndex].Value);
                    strSql = "DELETE FROM CUAfterService WHERE AfterId = " + intAfterId;

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                            }
                            else
                            {
                                MessageBox.Show("删除失败！", "软件提示");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "软件提示");
                            throw ex;
                        }

                        BindDataGridView(tvCustomer.SelectedNode.Tag.ToString(), "CUAfterService", dgvAfter);
                    }
                }
            }
        }
    }
}