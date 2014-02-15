using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.FI
{
    public partial class FormFIPurCost : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormFIPurCost()
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
            cbxAccountCode.Enabled = !cbxAccountCode.Enabled;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
            cbxCostCode.Enabled = !cbxCostCode.Enabled;
            txtFIMoney.ReadOnly = !txtFIMoney.ReadOnly;
            txtRemark.ReadOnly = !txtRemark.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtFIPurCode.Text = "";
            dtpFIPurDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            cbxSupplierCode.SelectedIndex = -1;
            cbxAccountCode.SelectedIndex = -1;
            cbxEmployeeCode.SelectedIndex = -1;
            cbxCostCode.SelectedIndex = -1;
            txtFIMoney.Text = "";
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
            txtFIPurCode.Text = dgvFIPurCostInfo["FIPurCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            dtpFIPurDate.Value =
                Convert.ToDateTime(dgvFIPurCostInfo["FIPurDate", dgvFIPurCostInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue =
                dgvFIPurCostInfo["OperatorCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
            cbxSupplierCode.SelectedValue =
                dgvFIPurCostInfo["SupplierCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
            cbxAccountCode.SelectedValue = dgvFIPurCostInfo["AccountCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
            cbxEmployeeCode.SelectedValue =
                dgvFIPurCostInfo["EmployeeCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
            cbxCostCode.SelectedValue = dgvFIPurCostInfo["CostCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
            txtFIMoney.Text = dgvFIPurCostInfo["FIMoney", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            txtRemark.Text = dgvFIPurCostInfo["Remark", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            cbxIsFlag.SelectedValue = dgvFIPurCostInfo["IsFlag", dgvFIPurCostInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void DataGridViewBindSource(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM FIPurCost " + strWhere;
            ;

            try
            {
                dgvFIPurCostInfo.DataSource = db.GetDataSet(strSql, "FIPurCost").Tables["FIPurCost"];
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
            db.Cmd.Parameters.AddWithValue("@FIPurCode", txtFIPurCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@FIPurDate", dtpFIPurDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            if (cbxSupplierCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@SupplierCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SupplierCode", cbxSupplierCode.SelectedValue.ToString());
            }

            if (cbxAccountCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@AccountCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccountCode", cbxAccountCode.SelectedValue.ToString());
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            if (cbxCostCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@CostCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CostCode", cbxCostCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtFIMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@FIMoney", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@FIMoney", Convert.ToDecimal(txtFIMoney.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtRemark.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Remark", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim());
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

        private void FormFIPurCost_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(cbxAccountCode, "AccountCode", "AccountName",
                                 "select AccountCode,AccountName from BSAccount", "BSAccount");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxCostCode, "CostCode", "CostName",
                                 "select CostCode,CostName from BSCost Where CostTypeCode = '01'", "BSCost");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["SupplierCode"], "SupplierCode", "SupplierName",
                                 "select SupplierCode,SupplierName from BSSupplier", "BSSupplier");
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["AccountCode"], "AccountCode", "AccountName",
                                 "select AccountCode,AccountName from BSAccount", "BSAccount");
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["CostCode"], "CostCode", "CostName",
                                 "select CostCode,CostName from BSCost Where CostTypeCode = '01'", "BSCost");
            commUse.BindComboBox(dgvFIPurCostInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

            //DataGridView绑定到数据源
            DataGridViewBindSource("");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加标识

            dtpFIPurDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            cbxIsFlag.SelectedValue = "0";
            txtFIPurCode.Text = commUse.BuildBillCode("FIPurCost", "FIPurCode", "FIPurDate", dtpFIPurDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvFIPurCostInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvFIPurCostInfo.RowCount > 0)
            {
                if (dgvFIPurCostInfo["IsFlag", dgvFIPurCostInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void txtFIMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtFIPurCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtFIPurCode.Focus();
                return;
            }

            if (cbxAccountCode.SelectedValue == null)
            {
                MessageBox.Show("结算帐户不许为空！", "软件提示");
                cbxAccountCode.Focus();
                return;
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                MessageBox.Show("报销人不许为空！", "软件提示");
                cbxEmployeeCode.Focus();
                return;
            }

            if (cbxCostCode.SelectedValue == null)
            {
                MessageBox.Show("费用名称不许为空！", "软件提示");
                cbxCostCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtFIMoney.Text.Trim()))
            {
                MessageBox.Show("费用金额不许为空！", "软件提示");
                txtFIMoney.Focus();
                return;
            }
            else
            {
                if (Convert.ToDecimal(txtFIMoney.Text.Trim()) == 0)
                {
                    MessageBox.Show("费用金额不能等于零！", "软件提示");
                    txtFIMoney.Focus();
                    return;
                }
            }

            //添加操作
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO FIPurCost(FIPurCode,FIPurDate,OperatorCode,SupplierCode,AccountCode,EmployeeCode,CostCode,FIMoney,Remark,IsFlag) ";
                    strCode +=
                        "VALUES(@FIPurCode,@FIPurDate,@OperatorCode,@SupplierCode,@AccountCode,@EmployeeCode,@CostCode,@FIMoney,@Remark,@IsFlag)";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        DataGridViewBindSource("");
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

            //修改操作
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strFIPurCode = txtFIPurCode.Text.Trim();

                //更新数据库
                try
                {
                    strCode = "UPDATE FIPurCost SET FIPurCode = @FIPurCode,FIPurDate = @FIPurDate,";
                    strCode += "OperatorCode = @OperatorCode,SupplierCode = @SupplierCode,AccountCode = @AccountCode,";
                    strCode +=
                        "EmployeeCode = @EmployeeCode,CostCode = @CostCode,FIMoney = @FIMoney,Remark = @Remark,IsFlag = @IsFlag ";
                    strCode += "WHERE FIPurCode = '" + strFIPurCode + "'";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        DataGridViewBindSource("");
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
            string strFIPurCode = null; //数据表FIPurCost的主键
            string strSql = null;
            string strFlag = null;

            if (dgvFIPurCostInfo.RowCount == 0)
            {
                return;
            }

            strFIPurCode = dgvFIPurCostInfo["FIPurCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvFIPurCostInfo["IsFlag", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM FIPurCost WHERE FIPurCode = '" + strFIPurCode + "'";

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

                DataGridViewBindSource("");
            }
        }

        private void toolCheck_Click(object sender, EventArgs e)
        {
            SqlDataReader sdr = null;
            string strCode = null;
            List<string> strSqls = new List<string>();

            string strFIPurCostSql = null; //表示提交FIPurCost表的SQL语句
            string strBSAccountSql = null; //表示提交BSAccount表的SQL语句

            string strIsFlag = null; //审核标记
            string strAccountCode = null; //帐户代码
            string strFIPurCode = null; //单据编号(数据表FIPurCost的主键)
            decimal decFIMoney; //费用金额

            if (dgvFIPurCostInfo.RowCount == 0)
            {
                return;
            }

            strAccountCode = dgvFIPurCostInfo["AccountCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            strFIPurCode = dgvFIPurCostInfo["FIPurCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            decFIMoney = Convert.ToDecimal(dgvFIPurCostInfo["FIMoney", dgvFIPurCostInfo.CurrentCell.RowIndex].Value);
            strIsFlag = dgvFIPurCostInfo["IsFlag", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strCode = "Select AccMoney From BSAccount Where AccountCode = '" + strAccountCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read(); //只有一条记录

                if (sdr.GetDecimal(0) < decFIMoney)
                {
                    MessageBox.Show("帐户金额不足，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }
                //关闭sdr对象
                sdr.Close();
                //
                strBSAccountSql = "Update BSAccount Set AccMoney = AccMoney - " + decFIMoney + " Where AccountCode = '" +
                                  strAccountCode + "'";
                strSqls.Add(strBSAccountSql);
                //打审核标记
                strFIPurCostSql = "Update FIPurCost Set IsFlag = '1' Where FIPurCode = '" + strFIPurCode + "'";
                strSqls.Add(strFIPurCostSql);
                //更新数据
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
                throw ex;
            }

            DataGridViewBindSource("");
        }

        private void toolUnCheck_Click(object sender, EventArgs e)
        {
            List<string> strSqls = new List<string>();

            string strFIPurCostSql = null; //表示提交FIPurCost表的SQL语句
            string strBSAccountSql = null; //表示提交BSAccount表的SQL语句

            string strIsFlag = null; //表示审核标记
            string strAccountCode = null; //表示帐户代码
            string strFIPurCode = null; //表示单据编号
            decimal decFIMoney;

            if (dgvFIPurCostInfo.RowCount == 0)
            {
                return;
            }

            strAccountCode = dgvFIPurCostInfo["AccountCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            strFIPurCode = dgvFIPurCostInfo["FIPurCode", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();
            decFIMoney = Convert.ToDecimal(dgvFIPurCostInfo["FIMoney", dgvFIPurCostInfo.CurrentCell.RowIndex].Value);
            strIsFlag = dgvFIPurCostInfo["IsFlag", dgvFIPurCostInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            try
            {
                //处理帐户金额
                strBSAccountSql = "Update BSAccount Set AccMoney = AccMoney + " + decFIMoney + " Where AccountCode = '" +
                                  strAccountCode + "'";
                strSqls.Add(strBSAccountSql);
                //打弃审标记
                strFIPurCostSql = "Update FIPurCost Set IsFlag = '0' Where FIPurCode = '" + strFIPurCode + "'";
                strSqls.Add(strFIPurCostSql);
                //更新数据
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
                throw ex;
            }

            DataGridViewBindSource("");
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "单据编号":

                    strWhere = " WHERE FIPurCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    DataGridViewBindSource(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),FIPurDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    DataGridViewBindSource(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvFIPurCostInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}