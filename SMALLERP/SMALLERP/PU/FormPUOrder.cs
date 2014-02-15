using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PU
{
    public partial class FormPUOrder : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormPUOrder()
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
            cbxSupplierCode.Enabled = !cbxSupplierCode.Enabled;
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtUnitPrice.ReadOnly = !txtUnitPrice.ReadOnly;
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            dtpRecInvenDate.Enabled = !dtpRecInvenDate.Enabled;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtPUOrderCode.Text = "";
            dtpPUOrderDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxSupplierCode.SelectedIndex = -1;
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtPUMoney.Text = "";
            dtpRecInvenDate.Value = Convert.ToDateTime("1900-01-01");
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
            txtPUOrderCode.Text = dgvPUOrderInfo[0, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            dtpPUOrderDate.Value = Convert.ToDateTime(dgvPUOrderInfo[1, dgvPUOrderInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvPUOrderInfo[2, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
            cbxSupplierCode.SelectedValue = dgvPUOrderInfo[3, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
            cbxStoreCode.SelectedValue = dgvPUOrderInfo[4, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvPUOrderInfo[5, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
            txtUnitPrice.Text = dgvPUOrderInfo[6, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            txtQuantity.Text = dgvPUOrderInfo[7, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            txtPUMoney.Text = dgvPUOrderInfo[8, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            dtpRecInvenDate.Value = Convert.ToDateTime(dgvPUOrderInfo[9, dgvPUOrderInfo.CurrentCell.RowIndex].Value);
            cbxEmployeeCode.SelectedValue = dgvPUOrderInfo[10, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvPUOrderInfo[11, dgvPUOrderInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PUOrder " + strWhere;
            ;

            try
            {
                dgvPUOrderInfo.DataSource = db.GetDataSet(strSql, "PUOrder").Tables["PUOrder"];
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
            db.Cmd.Parameters.AddWithValue("@PUOrderCode", txtPUOrderCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PUOrderDate", dtpPUOrderDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            if (cbxSupplierCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@SupplierCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SupplierCode", cbxSupplierCode.SelectedValue.ToString());
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
                db.Cmd.Parameters.AddWithValue("@InvenCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@InvenCode", cbxInvenCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@UnitPrice", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtPUMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@PUMoney", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@PUMoney", Convert.ToDecimal(txtPUMoney.Text.Trim()));
            }

            db.Cmd.Parameters.AddWithValue("@RecInvenDate", dtpRecInvenDate.Value);

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
        ///   计算采购金额
        /// </summary>
        private void ComputeMoney()
        {
            int int_Quantity;
            decimal dec_UnitPrice;

            if (!String.IsNullOrEmpty(txtQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                int_Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                dec_UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                txtPUMoney.Text = Decimal.Round(int_Quantity*dec_UnitPrice, 2).ToString();
            }
        }

        private void FormPUOrder_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(cbxSupplierCode, "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvPUOrderInfo.Columns[2], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[3], "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[4], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[5], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[10], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPUOrderInfo.Columns[11], "Code", "Name", "select * from INCheckFlag", "INCheckFlag");
            //
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

            dtpPUOrderDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            txtQuantity.Text = "1";
            dtpRecInvenDate.Value = DateTime.Today;
            cbxIsFlag.SelectedValue = "0";
            txtPUOrderCode.Text = commUse.BuildBillCode("PUOrder", "PUOrderCode", "PUOrderDate", dtpPUOrderDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvPUOrderInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvPUOrderInfo.RowCount > 0)
            {
                if (dgvPUOrderInfo[11, dgvPUOrderInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtPUOrderCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtPUOrderCode.Focus();
                return;
            }

            if (cbxSupplierCode.SelectedValue == null)
            {
                MessageBox.Show("供应商不许为空！", "软件提示");
                cbxSupplierCode.Focus();
                return;
            }

            if (cbxInvenCode.SelectedValue == null)
            {
                MessageBox.Show("存货不许为空！", "软件提示");
                cbxInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                MessageBox.Show("单价不许为空！", "软件提示");
                txtUnitPrice.Focus();
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
                        "INSERT INTO PUOrder(PUOrderCode,PUOrderDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,RecInvenDate,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@PUOrderCode,@PUOrderDate,@OperatorCode,@SupplierCode,@StoreCode,@InvenCode,@UnitPrice,@Quantity,@PUMoney,@RecInvenDate,@EmployeeCode,@IsFlag)";

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
                string strPUOrderCode = txtPUOrderCode.Text.Trim();
                //更新数据库
                try
                {
                    strCode =
                        "UPDATE PUOrder SET PUOrderCode = @PUOrderCode,PUOrderDate = @PUOrderDate,OperatorCode = @OperatorCode, SupplierCode = @SupplierCode,StoreCode = @StoreCode,";
                    strCode += "InvenCode = @InvenCode,UnitPrice = @UnitPrice,Quantity = @Quantity,";
                    strCode +=
                        "PUMoney = @PUMoney,RecInvenDate = @RecInvenDate,EmployeeCode = @EmployeeCode,IsFlag = @IsFlag";
                    strCode += " WHERE PUOrderCode = '" + strPUOrderCode + "'";

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
            string strPUOrderCode = null; //订单编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvPUOrderInfo.RowCount <= 0)
            {
                return;
            }

            strPUOrderCode = dgvPUOrderInfo[0, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPUOrderInfo[11, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM PUOrder WHERE PUOrderCode = '" + strPUOrderCode + "'";

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
            string strPUOrderCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvPUOrderInfo.RowCount == 0)
            {
                return;
            }

            strPUOrderCode = dgvPUOrderInfo[0, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPUOrderInfo[11, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strSql = "UPDATE PUOrder SET IsFlag = '1' WHERE PUOrderCode = '" + strPUOrderCode + "'";

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
            string strPUOrderCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记
            SqlDataReader sdr = null;

            if (dgvPUOrderInfo.RowCount == 0)
            {
                return;
            }

            strPUOrderCode = dgvPUOrderInfo[0, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPUOrderInfo[11, dgvPUOrderInfo.CurrentCell.RowIndex].Value.ToString();
            strSql = "select * from PUInStore where  PUOrderCode = '" + strPUOrderCode + "'";

            try
            {
                sdr = db.GetDataReader(strSql);
                sdr.Read();

                //该订单已经存在对应的采购入库单，不许弃审
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

            //打上弃审标记
            strSql = "UPDATE PUOrder SET IsFlag = '0' WHERE PUOrderCode = '" + strPUOrderCode + "'";

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

                    strWhere = " WHERE PUOrderCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),PUOrderDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvPUOrderInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}