using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.SE
{
    public partial class FormSEOrder : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormSEOrder()
        {
            InitializeComponent();
        }

        private void ControlStatus()
        {
            //工具栏按钮状态切换
            toolSave.Enabled = !toolSave.Enabled;
            toolCancel.Enabled = !toolCancel.Enabled;
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            commUse.CortrolButtonEnabled(toolCheck, this);
            commUse.CortrolButtonEnabled(toolUnCheck, this);

            //窗体控件状态切换
            cbxCustomerCode.Enabled = !cbxCustomerCode.Enabled;
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtSellPrice.ReadOnly = !txtSellPrice.ReadOnly;
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            dtpSenInvenDate.Enabled = !dtpSenInvenDate.Enabled;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtSEOrderCode.Text = "";
            dtpSEOrderDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxCustomerCode.SelectedIndex = -1;
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtSellPrice.Text = "";
            txtQuantity.Text = "";
            txtSEMoney.Text = "";
            dtpSenInvenDate.Value = Convert.ToDateTime("1900-01-01");
            cbxEmployeeCode.SelectedIndex = -1;
            cbxIsFlag.SelectedIndex = -1;
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("单据编号");
            cbxCondition.Items.Add("单据日期");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtSEOrderCode.Text = dgvSEOrderInfo[0, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            dtpSEOrderDate.Value = Convert.ToDateTime(dgvSEOrderInfo[1, dgvSEOrderInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvSEOrderInfo[2, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
            cbxCustomerCode.SelectedValue = dgvSEOrderInfo[3, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
            cbxStoreCode.SelectedValue = dgvSEOrderInfo[4, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvSEOrderInfo[5, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
            txtSellPrice.Text = dgvSEOrderInfo[6, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            txtQuantity.Text = dgvSEOrderInfo[7, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            txtSEMoney.Text = dgvSEOrderInfo[8, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            dtpSenInvenDate.Value = Convert.ToDateTime(dgvSEOrderInfo[9, dgvSEOrderInfo.CurrentCell.RowIndex].Value);
            cbxEmployeeCode.SelectedValue = dgvSEOrderInfo[10, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvSEOrderInfo[11, dgvSEOrderInfo.CurrentCell.RowIndex].Value;
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
            ;

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

        /// <summary>
        ///   设置参数值
        /// </summary>
        private void ParametersAddValue()
        {
            db.Cmd.Parameters.Clear();
            db.Cmd.Parameters.AddWithValue("@SEOrderCode", txtSEOrderCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@SEOrderDate", dtpSEOrderDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            if (cbxCustomerCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@CustomerCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CustomerCode", cbxCustomerCode.SelectedValue.ToString());
            }

            if (cbxStoreCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@StoreCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@StoreCode", cbxStoreCode.SelectedValue.ToString());
            }

            if (cbxInvenCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@InvenCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@InvenCode", cbxInvenCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtSellPrice.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@SellPrice", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SellPrice", Convert.ToDecimal(txtSellPrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtSEMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@SEMoney", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SEMoney", Convert.ToDecimal(txtSEMoney.Text.Trim()));
            }

            db.Cmd.Parameters.AddWithValue("@SenInvenDate", dtpSenInvenDate.Value);

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            if (cbxIsFlag.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", cbxIsFlag.SelectedValue.ToString());
            }
        }

        /// <summary>
        ///   计算销售金额
        /// </summary>
        private void ComputeMoney()
        {
            int int_Quantity;
            decimal dec_SellPrice;

            if (!String.IsNullOrEmpty(txtQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtSellPrice.Text.Trim()))
            {
                int_Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                dec_SellPrice = Convert.ToDecimal(txtSellPrice.Text.Trim());
                txtSEMoney.Text = Decimal.Round(int_Quantity*dec_SellPrice, 2).ToString();
            }
        }

        private void FormSEOrder_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            commUse.CortrolButtonEnabled(toolCheck, this);
            commUse.CortrolButtonEnabled(toolUnCheck, this);

            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxOperatorCode, "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(cbxCustomerCode, "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvSEOrderInfo.Columns[2], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSEOrderInfo.Columns[3], "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(dgvSEOrderInfo.Columns[4], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSEOrderInfo.Columns[5], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSEOrderInfo.Columns[10], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSEOrderInfo.Columns[11], "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            BindDataGridView("");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加标识

            dtpSEOrderDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            txtQuantity.Text = "1";
            dtpSenInvenDate.Value = DateTime.Today;
            cbxIsFlag.SelectedValue = "0";
            txtSEOrderCode.Text = commUse.BuildBillCode("SEOrder", "SEOrderCode", "SEOrderDate", dtpSEOrderDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvSEOrderInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvSEOrderInfo.RowCount > 0)
            {
                if (dgvSEOrderInfo[11, dgvSEOrderInfo.CurrentRow.Index].Value.ToString() == "1")
                {
                    MessageBox.Show("该记录已审核，不允许编辑！", "软件提示");
                    return;
                }

                FillControls();
            }
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "";
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtSEOrderCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtSEOrderCode.Focus();
                return;
            }

            if (cbxCustomerCode.SelectedValue == null)
            {
                MessageBox.Show("客户不许为空！", "软件提示");
                cbxCustomerCode.Focus();
                return;
            }

            if (cbxInvenCode.SelectedValue == null)
            {
                MessageBox.Show("存货不许为空！", "软件提示");
                cbxInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtSellPrice.Text.Trim()))
            {
                MessageBox.Show("单价不许为空！", "软件提示");
                txtSellPrice.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("数量不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("数量不能等于零", "软件提示");
                    txtQuantity.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO SEOrder(SEOrderCode,SEOrderDate,OperatorCode,CustomerCode,StoreCode,InvenCode,SellPrice,Quantity,SEMoney,SenInvenDate,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@SEOrderCode,@SEOrderDate,@OperatorCode,@CustomerCode,@StoreCode,@InvenCode,@SellPrice,@Quantity,@SEMoney,@SenInvenDate,@EmployeeCode,@IsFlag)";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        BindDataGridView("");
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "软件提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
            }

            //修改
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strSEOrderCode = txtSEOrderCode.Text.Trim();
                //更新数据库
                try
                {
                    strCode =
                        "UPDATE SEOrder SET SEOrderCode = @SEOrderCode,SEOrderDate = @SEOrderDate,OperatorCode = @OperatorCode, CustomerCode = @CustomerCode,StoreCode = @StoreCode,";
                    strCode += "InvenCode = @InvenCode,SellPrice = @SellPrice,Quantity = @Quantity,";
                    strCode +=
                        "SEMoney = @SEMoney,SenInvenDate = @SenInvenDate,EmployeeCode = @EmployeeCode,IsFlag = @IsFlag";
                    strCode += " WHERE SEOrderCode = '" + strSEOrderCode + "'";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        BindDataGridView("");
                        ControlStatus();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "软件提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
            }

            toolStrip1.Tag = "";
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strSEOrderCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvSEOrderInfo.RowCount <= 0)
            {
                return;
            }

            strSEOrderCode = dgvSEOrderInfo[0, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvSEOrderInfo[11, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM SEOrder WHERE SEOrderCode = '" + strSEOrderCode + "'";

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

                BindDataGridView("");
            }
        }

        private void toolCheck_Click(object sender, EventArgs e)
        {
            string strSEOrderCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvSEOrderInfo.RowCount == 0)
            {
                return;
            }

            strSEOrderCode = dgvSEOrderInfo[0, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvSEOrderInfo[11, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strSql = "UPDATE SEOrder SET IsFlag = '1' WHERE SEOrderCode = '" + strSEOrderCode + "'";

            try
            {
                if (db.ExecDataBySql(strSql) > 0)
                {
                    MessageBox.Show("审核成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("审核失败！", "软件提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

            BindDataGridView("");
        }

        private void toolUnCheck_Click(object sender, EventArgs e)
        {
            string strSEOrderCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记
            SqlDataReader sdr = null;

            if (dgvSEOrderInfo.RowCount == 0)
            {
                return;
            }

            strSEOrderCode = dgvSEOrderInfo[0, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvSEOrderInfo[11, dgvSEOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strSql = "select * from SEOutStore where  SEOrderCode = '" + strSEOrderCode + "'";

            try
            {
                sdr = db.GetDataReader(strSql);
                sdr.Read();

                if (sdr.HasRows)
                {
                    MessageBox.Show("该单据已发生业务关系，无法弃审！", "软件提示");
                    sdr.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            finally
            {
                sdr.Close();
            }

            if (strFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            strSql = "UPDATE SEOrder SET IsFlag = '0' WHERE SEOrderCode = '" + strSEOrderCode + "'";

            try
            {
                if (db.ExecDataBySql(strSql) > 0)
                {
                    MessageBox.Show("弃审成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("弃审失败！", "软件提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

            BindDataGridView("");
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "单据编号":

                    strWhere = " WHERE SEOrderCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),SEOrderDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvSEOrderInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}