using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.ST
{
    public partial class FormSTLoss : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormSTLoss()
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
            txtLossQuantity.ReadOnly = !txtLossQuantity.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
            txtRemark.ReadOnly = !txtRemark.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtSTLossCode.Text = "";
            dtpSTLossDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtLossQuantity.Text = "";
            cbxEmployeeCode.SelectedIndex = -1;
            txtRemark.Text = "";
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
            txtSTLossCode.Text = dgvSTLossInfo["STLossCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            dtpSTLossDate.Value =
                Convert.ToDateTime(dgvSTLossInfo["STLossDate", dgvSTLossInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvSTLossInfo["OperatorCode", dgvSTLossInfo.CurrentCell.RowIndex].Value;
            cbxStoreCode.SelectedValue = dgvSTLossInfo["StoreCode", dgvSTLossInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvSTLossInfo["InvenCode", dgvSTLossInfo.CurrentCell.RowIndex].Value;
            txtLossQuantity.Text = dgvSTLossInfo["LossQuantity", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue = dgvSTLossInfo[8, dgvSTLossInfo.CurrentCell.RowIndex].Value;
            txtRemark.Text = dgvSTLossInfo[9, dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            cbxIsFlag.SelectedValue = dgvSTLossInfo[10, dgvSTLossInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM STLoss " + strWhere;
            ;

            try
            {
                dgvSTLossInfo.DataSource = db.GetDataSet(strSql, "STLoss").Tables["STLoss"];
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
            db.Cmd.Parameters.AddWithValue("@STLossCode", txtSTLossCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@STLossDate", dtpSTLossDate.Value);

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

            if (String.IsNullOrEmpty(txtLossQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@LossQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@LossQuantity", Convert.ToInt32(txtLossQuantity.Text.Trim()));
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim());

            if (cbxIsFlag.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", cbxIsFlag.SelectedValue.ToString());
            }
        }

        private void FormSTLoss_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(dgvSTLossInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSTLossInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSTLossInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSTLossInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSTLossInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
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

            dtpSTLossDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            cbxIsFlag.SelectedValue = "0";

            txtSTLossCode.Text = commUse.BuildBillCode("STLoss", "STLossCode", "STLossDate", dtpSTLossDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvSTLossInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvSTLossInfo.RowCount > 0)
            {
                if (dgvSTLossInfo[10, dgvSTLossInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void txtLossQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtSTLossCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtSTLossCode.Focus();
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

            if (String.IsNullOrEmpty(txtLossQuantity.Text.Trim()))
            {
                MessageBox.Show("数量不许为空！", "软件提示");
                txtLossQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtLossQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("数量不能等于零", "软件提示");
                    txtLossQuantity.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO STLoss(STLossCode,STLossDate,OperatorCode,StoreCode,InvenCode,LossQuantity,EmployeeCode,Remark,IsFlag) ";
                    strCode +=
                        "VALUES(@STLossCode,@STLossDate,@OperatorCode,@StoreCode,@InvenCode,@LossQuantity,@EmployeeCode,@Remark,@IsFlag)";

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
                string strSTLossCode = txtSTLossCode.Text.Trim();
                //更新数据库
                try
                {
                    strCode =
                        "UPDATE STLoss SET STLossCode = @STLossCode,STLossDate = @STLossDate,OperatorCode = @OperatorCode, StoreCode = @StoreCode,InvenCode = @InvenCode,";
                    strCode +=
                        "LossQuantity = @LossQuantity,EmployeeCode = @EmployeeCode,Remark = @Remark,IsFlag = @IsFlag ";
                    strCode += "WHERE STLossCode = '" + strSTLossCode + "'";

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
            string strSTLossCode = null; //单据编号
            string strSql = null;
            string strIsFlag = null; //审核标记

            if (dgvSTLossInfo.RowCount <= 0)
            {
                return;
            }

            strSTLossCode = dgvSTLossInfo["STLossCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTLossInfo["IsFlag", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM STLoss WHERE STLossCode = '" + strSTLossCode + "'";

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
            string strSTLossCode = null; //单据编号
            string strIsFlag = null; //审核标记

            string strSTLossSql = null; //表示提交STLoss表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码

            int intLossQuantity; //损失量
            int intQuantity; //库存量
            decimal decLossMoney;
            decimal decMoney;
            decimal decUnitPrice;

            if (dgvSTLossInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvSTLossInfo["StoreCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTLossInfo["InvenCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strSTLossCode = dgvSTLossInfo["STLossCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTLossInfo["IsFlag", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();

            intLossQuantity = Convert.ToInt32(dgvSTLossInfo["LossQuantity", dgvSTLossInfo.CurrentCell.RowIndex].Value);

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

                if (sdr.GetInt32(0) < intLossQuantity)
                {
                    MessageBox.Show("报损数量不许大于现有库存量！", "软件提示");
                    sdr.Close();
                    return;
                }
                //损失表
                decUnitPrice = sdr.GetDecimal(1);
                strSTLossSql = "UPDATE STLoss SET IsFlag = '1',UnitPrice = " + decUnitPrice + ",LossMoney = " +
                               Decimal.Round(intLossQuantity*decUnitPrice, 2) + " WHERE STLossCode = '" + strSTLossCode +
                               "'";
                //库存表
                intQuantity = sdr.GetInt32(0) - intLossQuantity; //“剩余”的库存数量
                decMoney = sdr.GetDecimal(2) - Decimal.Round(intLossQuantity*decUnitPrice, 2);
                decLossMoney = sdr.GetDecimal(4) + Decimal.Round(intLossQuantity*decUnitPrice, 2);
                intLossQuantity = sdr.GetInt32(3) + intLossQuantity;
                strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",STMoney = " + decMoney +
                                ",LossQuantity = " + intLossQuantity + ",LossMoney = " + decLossMoney + " ";
                strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                //关闭连接
                sdr.Close();
                //泛型添加对象
                strSqls.Add(strSTStockSql);
                strSqls.Add(strSTLossSql);
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
            string strSTLossCode = null; //单据编号
            string strIsFlag = null; //审核标记

            string strSTLossSql = null; //表示提交STLoss表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码

            int intLossQuantity; //损失量
            int intQuantity; //正常库存量
            decimal decLossMoney;
            decimal decMoney;
            decimal decAvePrice;
            decimal decUnitPrice;

            if (dgvSTLossInfo.RowCount == 0)
            {
                return;
            }

            strIsFlag = dgvSTLossInfo["IsFlag", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            strStoreCode = dgvSTLossInfo["StoreCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTLossInfo["InvenCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();
            strSTLossCode = dgvSTLossInfo["STLossCode", dgvSTLossInfo.CurrentCell.RowIndex].Value.ToString();

            intLossQuantity = Convert.ToInt32(dgvSTLossInfo["LossQuantity", dgvSTLossInfo.CurrentCell.RowIndex].Value);
            decLossMoney = Convert.ToDecimal(dgvSTLossInfo["LossMoney", dgvSTLossInfo.CurrentCell.RowIndex].Value);
            decUnitPrice = Convert.ToDecimal(dgvSTLossInfo["UnitPrice", dgvSTLossInfo.CurrentCell.RowIndex].Value);

            strCode = "SELECT Quantity,AvePrice,STMoney,LossQuantity,LossMoney FROM STStock WHERE StoreCode = '" +
                      strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("库存数据异常（该存货的库存未初始化），无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                if (sdr.GetInt32(3) < intLossQuantity)
                {
                    MessageBox.Show("库存数据异常（累计报损数量小于本次弃审数量），无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                if (sdr.GetDecimal(4) < decLossMoney)
                {
                    MessageBox.Show("库存数据异常（累计报损金额小于本次弃审金额），无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                //正常存货的信息
                intQuantity = sdr.GetInt32(0) + intLossQuantity; //“剩余”的库存数量
                decMoney = sdr.GetDecimal(2) + decLossMoney;
                decAvePrice = Decimal.Round(decMoney/intQuantity, 2);
                //报损存货的信息
                intLossQuantity = sdr.GetInt32(3) - intLossQuantity;
                decLossMoney = sdr.GetDecimal(4) - decLossMoney;
                //
                strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",STMoney = " + decMoney + ",";
                strSTStockSql += "LossQuantity = " + intLossQuantity + ",LossMoney = " + decLossMoney + ",AvePrice = " +
                                 decAvePrice + " ";
                strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";

                strSTLossSql = "UPDATE STLoss SET IsFlag = '0',UnitPrice = null,LossMoney = null WHERE STLossCode = '" +
                               strSTLossCode + "'";

                sdr.Close();

                strSqls.Add(strSTStockSql);
                strSqls.Add(strSTLossSql);

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

                    strWhere = " WHERE STLossCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),STLossDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvSTLossInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}