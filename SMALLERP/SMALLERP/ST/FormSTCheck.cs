using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.ST
{
    public partial class FormSTCheck : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormSTCheck()
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
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtCheckQuantity.ReadOnly = !txtCheckQuantity.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtSTCheckCode.Text = "";
            dtpSTCheckDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtAccQuantity.Text = "";
            txtCheckQuantity.Text = "";
            txtBalQuantity.Text = "";
            txtAvePrice.Text = "";
            txtBalMoney.Text = "";
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
            txtSTCheckCode.Text = dgvSTCheckInfo["STCheckCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            dtpSTCheckDate.Value =
                Convert.ToDateTime(dgvSTCheckInfo["STCheckDate", dgvSTCheckInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvSTCheckInfo["OperatorCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value;
            cbxStoreCode.SelectedValue = dgvSTCheckInfo["StoreCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvSTCheckInfo["InvenCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value;
            txtAccQuantity.Text = dgvSTCheckInfo["AccQuantity", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            txtCheckQuantity.Text =
                dgvSTCheckInfo["CheckQuantity", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            txtBalQuantity.Text = dgvSTCheckInfo["BalQuantity", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            txtAvePrice.Text = dgvSTCheckInfo["AvePrice", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            txtBalMoney.Text = dgvSTCheckInfo["BalMoney", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue = dgvSTCheckInfo["EmployeeCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvSTCheckInfo["IsFlag", dgvSTCheckInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM STCheck " + strWhere;
            ;

            try
            {
                dgvSTCheckInfo.DataSource = db.GetDataSet(strSql, "STCheck").Tables["STCheck"];
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
            db.Cmd.Parameters.AddWithValue("@STCheckCode", txtSTCheckCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@STCheckDate", dtpSTCheckDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            if (cbxStoreCode.SelectedValue == null)
            {
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

            if (String.IsNullOrEmpty(txtAccQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@AccQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccQuantity", Convert.ToInt32(txtAccQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtCheckQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@CheckQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CheckQuantity", Convert.ToInt32(txtCheckQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtBalQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@BalQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@BalQuantity", Convert.ToInt32(txtBalQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtAvePrice.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@AvePrice", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AvePrice", Convert.ToDecimal(txtAvePrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtBalMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@BalMoney", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@BalMoney", Convert.ToDecimal(txtBalMoney.Text.Trim()));
            }

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

        private void FormSTCheck_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvSTCheckInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSTCheckInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSTCheckInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSTCheckInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSTCheckInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            //DataGridView绑定数据源
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

            dtpSTCheckDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            cbxIsFlag.SelectedValue = "0";

            txtSTCheckCode.Text = commUse.BuildBillCode("STCheck", "STCheckCode", "STCheckDate", dtpSTCheckDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvSTCheckInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvSTCheckInfo.RowCount > 0)
            {
                if (dgvSTCheckInfo["IsFlag", dgvSTCheckInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void cbxStoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStoreCode.SelectedIndex != -1)
            {
                commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName",
                                     "SELECT InvenCode, InvenName FROM BSInven WHERE (InvenCode IN (SELECT InvenCode FROM STStock WHERE (StoreCode = '" +
                                     cbxStoreCode.SelectedValue + "')))", "BSInven");
            }
        }

        private void cbxInvenCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSql = null;
            SqlDataReader sdr = null;

            if (cbxInvenCode.SelectedIndex == -1)
            {
                return;
            }

            strSql = "Select AvePrice,Quantity From STStock Where StoreCode = '" + cbxStoreCode.SelectedValue +
                     "' and InvenCode = '" + cbxInvenCode.SelectedValue + "'";

            try
            {
                sdr = db.GetDataReader(strSql);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("库存数据异常!", "软件提示");
                    sdr.Close();
                    return;
                }

                txtAvePrice.Text = sdr.GetDecimal(0).ToString();
                txtAccQuantity.Text = sdr.GetInt32(1).ToString();
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
        }

        private void txtCheckQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAccQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtCheckQuantity.Text.Trim()))
            {
                txtBalQuantity.Text =
                    (Convert.ToInt32(txtCheckQuantity.Text.Trim()) - Convert.ToInt32(txtAccQuantity.Text.Trim())).
                        ToString();
            }
        }

        private void txtBalQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBalQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtAvePrice.Text.Trim()))
            {
                txtBalMoney.Text =
                    Decimal.Round(
                        Convert.ToInt32(txtBalQuantity.Text.Trim())*Convert.ToDecimal(txtAvePrice.Text.Trim()), 2).
                        ToString();
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtSTCheckCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtSTCheckCode.Focus();
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

            if (String.IsNullOrEmpty(txtCheckQuantity.Text.Trim()))
            {
                MessageBox.Show("实盘数量不许为空！", "软件提示");
                txtCheckQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtCheckQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("实盘数量不能等于零", "软件提示");
                    txtCheckQuantity.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO STCheck(STCheckCode,STCheckDate,OperatorCode,StoreCode,InvenCode,AccQuantity,CheckQuantity,BalQuantity,AvePrice,BalMoney,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@STCheckCode,@STCheckDate,@OperatorCode,@StoreCode,@InvenCode,@AccQuantity,@CheckQuantity,@BalQuantity,@AvePrice,@BalMoney,@EmployeeCode,@IsFlag)";

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
                string strSTCheckCode = txtSTCheckCode.Text.Trim();

                //更新数据库
                try
                {
                    strCode =
                        "UPDATE STCheck SET STCheckCode = @STCheckCode,STCheckDate = @STCheckDate,OperatorCode = @OperatorCode, StoreCode = @StoreCode,InvenCode = @InvenCode,";
                    strCode +=
                        "AccQuantity = @AccQuantity,CheckQuantity = @CheckQuantity,BalQuantity = @BalQuantity,AvePrice = @AvePrice,BalMoney = @BalMoney,EmployeeCode = @EmployeeCode,IsFlag = @IsFlag ";
                    strCode += "WHERE STCheckCode = '" + strSTCheckCode + "'";

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
            string strSTCheckCode = null; //单据编号
            string strSql = null;
            string strIsFlag = null; //审核标记

            if (dgvSTCheckInfo.RowCount <= 0)
            {
                return;
            }

            strSTCheckCode = dgvSTCheckInfo["STCheckCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTCheckInfo["IsFlag", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM STCheck WHERE STCheckCode = '" + strSTCheckCode + "'";

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
            string strSTCheckCode = null; //单据编码
            string strIsFlag = null; //审核标记

            string strSTCheckSql = null; //表示提交STCheck表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码

            int intBalQuantity; //盈亏数量
            decimal decBalMoney; //盈亏金额

            int intQuantity; //库存数量
            decimal decMoney; //库存金额

            if (dgvSTCheckInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvSTCheckInfo["StoreCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTCheckInfo["InvenCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strSTCheckCode = dgvSTCheckInfo["STCheckCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTCheckInfo["IsFlag", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();

            intBalQuantity = Convert.ToInt32(dgvSTCheckInfo["BalQuantity", dgvSTCheckInfo.CurrentCell.RowIndex].Value);
            decBalMoney = Convert.ToDecimal(dgvSTCheckInfo["BalMoney", dgvSTCheckInfo.CurrentCell.RowIndex].Value);

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney,LossQuantity,LossMoney FROM STStock WHERE StoreCode = '" +
                      strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("库存数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                intQuantity = sdr.GetInt32(0) + intBalQuantity; //平衡后的库存数量
                decMoney = sdr.GetDecimal(2) + decBalMoney; //平衡后的库存金额

                if (intQuantity < 0 || decMoney < 0)
                {
                    MessageBox.Show("库存数据异常(平衡后库存数量或库存金额为负数)，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }
                //库存表
                strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",STMoney = " + decMoney + " ";
                strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                //盘点表
                strSTCheckSql = "UPDATE STCheck SET IsFlag = '1' WHERE STCheckCode = '" + strSTCheckCode + "'";
                //关闭连接
                sdr.Close();
                //泛型添加对象
                strSqls.Add(strSTStockSql);
                strSqls.Add(strSTCheckSql);
                //同时执行多条Sql更新语句
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
            string strSTCheckCode = null; //单据编码
            string strIsFlag = null; //审核标记

            string strSTCheckSql = null; //表示提交STCheck表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码

            int intBalQuantity; //盈亏数量
            decimal decBalMoney; //盈亏金额

            int intQuantity; //库存数量
            decimal decMoney; //库存金额

            if (dgvSTCheckInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvSTCheckInfo["StoreCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTCheckInfo["InvenCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strSTCheckCode = dgvSTCheckInfo["STCheckCode", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTCheckInfo["IsFlag", dgvSTCheckInfo.CurrentCell.RowIndex].Value.ToString();

            intBalQuantity = Convert.ToInt32(dgvSTCheckInfo["BalQuantity", dgvSTCheckInfo.CurrentCell.RowIndex].Value);
            decBalMoney = Convert.ToDecimal(dgvSTCheckInfo["BalMoney", dgvSTCheckInfo.CurrentCell.RowIndex].Value);

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审时！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney,LossQuantity,LossMoney FROM STStock WHERE StoreCode = '" +
                      strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("库存数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                intQuantity = sdr.GetInt32(0) - intBalQuantity; //平衡后的库存数量
                decMoney = sdr.GetDecimal(2) - decBalMoney; //平衡后的库存金额

                if (intQuantity < 0 || decMoney < 0)
                {
                    MessageBox.Show("库存数据异常(弃审后库存数量或库存金额将变为负数)，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }
                //库存表
                strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",STMoney = " + decMoney + " ";
                strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                //盘点表
                strSTCheckSql = "UPDATE STCheck SET IsFlag = '0' WHERE STCheckCode = '" + strSTCheckCode + "'";
                //关闭连接
                sdr.Close();
                //泛型添加对象
                strSqls.Add(strSTStockSql);
                strSqls.Add(strSTCheckSql);
                //同时执行多条Sql更新语句
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

                    strWhere = " WHERE STCheckCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),STCheckDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }
    }
}