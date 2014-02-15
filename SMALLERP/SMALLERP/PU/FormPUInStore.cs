using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PU
{
    public partial class FormPUInStore : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormPUInStore()
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
            //this.txtPUOrderCode.ReadOnly = !this.txtPUOrderCode.ReadOnly;
            cbxSupplierCode.Enabled = !cbxSupplierCode.Enabled;
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtUnitPrice.ReadOnly = !txtUnitPrice.ReadOnly;
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            btnChoice.Enabled = !btnChoice.Enabled;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtPUInCode.Text = "";
            dtpPUInDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxSupplierCode.SelectedIndex = -1;
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtPUMoney.Text = "";
            txtPUOrderCode.Text = "";
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
            txtPUInCode.Text = dgvPUInStoreInfo[0, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            dtpPUInDate.Value = Convert.ToDateTime(dgvPUInStoreInfo[1, dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvPUInStoreInfo[2, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
            cbxSupplierCode.SelectedValue = dgvPUInStoreInfo[3, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
            cbxStoreCode.SelectedValue = dgvPUInStoreInfo[4, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvPUInStoreInfo[5, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
            txtUnitPrice.Text = dgvPUInStoreInfo[6, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtQuantity.Text = dgvPUInStoreInfo[7, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtPUMoney.Text = dgvPUInStoreInfo[8, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtPUOrderCode.Text = dgvPUInStoreInfo[9, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue = dgvPUInStoreInfo[10, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvPUInStoreInfo[11, dgvPUInStoreInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PUInStore " + strWhere;
            ;

            try
            {
                dgvPUInStoreInfo.DataSource = db.GetDataSet(strSql, "PUInStore").Tables["PUInStore"];
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
            db.Cmd.Parameters.AddWithValue("@PUInCode", txtPUInCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PUInDate", dtpPUInDate.Value);

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
                //把null对象化为DBNull
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

            db.Cmd.Parameters.AddWithValue("@PUOrderCode", txtPUOrderCode.Text.Trim());

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

        private void FormPUInStore_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[2], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[3], "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[4], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[5], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[10], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPUInStoreInfo.Columns[11], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");
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

            dtpPUInDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            txtQuantity.Text = "1";
            cbxIsFlag.SelectedValue = "0";

            txtPUInCode.Text = commUse.BuildBillCode("PUInStore", "PUInCode", "PUInDate", dtpPUInDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvPUInStoreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvPUInStoreInfo.RowCount > 0)
            {
                if (dgvPUInStoreInfo[11, dgvPUInStoreInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void btnChoice_Click(object sender, EventArgs e)
        {
            FormBrowsePUOrder formBrowsePUOrder = new FormBrowsePUOrder();
            formBrowsePUOrder.Owner = this;
            formBrowsePUOrder.ShowDialog();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtPUInCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtPUInCode.Focus();
                return;
            }

            if (cbxSupplierCode.SelectedValue == null)
            {
                MessageBox.Show("供应商不许为空！", "软件提示");
                cbxSupplierCode.Focus();
                return;
            }

            if (cbxStoreCode.SelectedValue == null)
            {
                MessageBox.Show("仓库不许为空！", "软件提示");
                cbxStoreCode.Focus();
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
                        "INSERT INTO PUInStore(PUInCode,PUInDate,OperatorCode,SupplierCode,StoreCode,InvenCode,UnitPrice,Quantity,PUMoney,PUOrderCode,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@PUInCode,@PUInDate,@OperatorCode,@SupplierCode,@StoreCode,@InvenCode,@UnitPrice,@Quantity,@PUMoney,@PUOrderCode,@EmployeeCode,@IsFlag)";

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
                string strPUInCode = txtPUInCode.Text.Trim();
                //更新数据库
                try
                {
                    strCode =
                        "UPDATE PUInStore SET PUInCode = @PUInCode,PUInDate = @PUInDate,OperatorCode = @OperatorCode, SupplierCode = @SupplierCode,StoreCode = @StoreCode,";
                    strCode += "InvenCode = @InvenCode,UnitPrice = @UnitPrice,Quantity = @Quantity,";
                    strCode +=
                        "PUMoney = @PUMoney,PUOrderCode = @PUOrderCode,EmployeeCode = @EmployeeCode,IsFlag = @IsFlag";
                    strCode += " WHERE PUInCode = '" + strPUInCode + "'";

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
            string strPUInCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvPUInStoreInfo.RowCount <= 0)
            {
                return;
            }

            strPUInCode = dgvPUInStoreInfo[0, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPUInStoreInfo[11, dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM PUInStore WHERE PUInCode = '" + strPUInCode + "'";

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
            List<string> strSqls = new List<string>();
            SqlDataReader sdr = null;
            string strCode = null;
            string strPUInCode = null; //单据编号
            string strIsFlag = null; //审核标记

            string strPUInStoreSql = null; //表示提交PUInStore表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //采购商品的代码

            int intQuantity; //采购数量
            decimal decPrice; //采购单价
            decimal decMoney; //采购金额

            if (dgvPUInStoreInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvPUInStoreInfo["StoreCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvPUInStoreInfo["InvenCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strPUInCode = dgvPUInStoreInfo["PUInCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvPUInStoreInfo["IsFlag", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            intQuantity = Convert.ToInt32(dgvPUInStoreInfo["Quantity", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            //本次的采购数量
            decPrice = Convert.ToDecimal(dgvPUInStoreInfo["UnitPrice", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            //本次的采购单价
            decMoney = Convert.ToDecimal(dgvPUInStoreInfo["PUMoney", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            //本次的采购金额

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                //库存中是否存在被采购的商品
                if (sdr.HasRows)
                {
                    intQuantity = intQuantity + sdr.GetInt32(0); //合计数量
                    decMoney = decMoney + sdr.GetDecimal(2); //合计金额
                    decPrice = Decimal.Round(decMoney/intQuantity, 2); //平均价格

                    strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",AvePrice = " + decPrice +
                                    ",STMoney = " + decMoney + " ";
                    strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                }
                else
                {
                    strSTStockSql = "INSERT INTO STStock(StoreCode,InvenCode,Quantity,AvePrice,STMoney) ";
                    strSTStockSql += "VALUES('" + strStoreCode + "','" + strInvenCode + "'," + intQuantity + "," +
                                     decPrice + "," + decMoney + ")";
                }

                strPUInStoreSql = "UPDATE PUInStore SET IsFlag = '1' WHERE PUInCode = '" + strPUInCode + "'";

                sdr.Close();
                strSqls.Add(strSTStockSql);
                strSqls.Add(strPUInStoreSql);
                if (db.ExecDataBySqls(strSqls))
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
                sdr.Close();
                throw ex;
            }

            BindDataGridView("");
        }

        private void toolUnCheck_Click(object sender, EventArgs e)
        {
            List<string> strSqls = new List<string>();
            SqlDataReader sdr = null;
            string strCode = null;
            string strPUInCode = null; //单据编号
            string strIsFlag = null; //审核标记

            string strPUInStoreSql = null; //表示提交PUInStore表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //采购商品的代码

            int intQuantity;
            decimal decPrice;
            decimal decMoney;

            if (dgvPUInStoreInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvPUInStoreInfo["StoreCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvPUInStoreInfo["InvenCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strPUInCode = dgvPUInStoreInfo["PUInCode", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvPUInStoreInfo["IsFlag", dgvPUInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            intQuantity = Convert.ToInt32(dgvPUInStoreInfo["Quantity", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            decPrice = Convert.ToDecimal(dgvPUInStoreInfo["UnitPrice", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);
            decMoney = Convert.ToDecimal(dgvPUInStoreInfo["PUMoney", dgvPUInStoreInfo.CurrentCell.RowIndex].Value);

            strCode = "select * from PUPay where  PUInCode = '" + strPUInCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                //该采购商品已经付款了，不许弃审
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

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();
                if (sdr.HasRows)
                {
                    if (sdr.GetInt32(0) < intQuantity) //该种商品的库存量已经不足以用于弃审，所以给与“无法弃审”的提示
                    {
                        MessageBox.Show("该笔入库且经审核的存货，已经发生了相关业务，无法弃审！", "软件提示");
                        sdr.Close();
                        return;
                    }

                    intQuantity = sdr.GetInt32(0) - intQuantity; //弃审后的剩余数量
                    decMoney = sdr.GetDecimal(2) - decMoney; //弃审后的剩余金额

                    if (intQuantity == 0)
                    {
                        decPrice = 0;
                        decMoney = 0;
                    }
                    else
                    {
                        decPrice = Decimal.Round(decMoney/intQuantity, 2); //计算平均价格
                    }

                    strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",AvePrice = " + decPrice +
                                    ",STMoney = " + decMoney + " ";
                    strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                }
                else
                {
                    MessageBox.Show("库存数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                //取消审核，打弃审标记
                strPUInStoreSql = "UPDATE PUInStore SET IsFlag = '0' WHERE PUInCode = '" + strPUInCode + "'";

                sdr.Close();
                strSqls.Add(strSTStockSql);
                strSqls.Add(strPUInStoreSql);

                if (db.ExecDataBySqls(strSqls))
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
                sdr.Close();
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

                    strWhere = " WHERE PUInCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),PUInDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvPUInStoreInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}