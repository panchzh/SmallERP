using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSCustomer : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSCustomer()
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
            //窗体控件状态切换
            txtCustomerCode.ReadOnly = !txtCustomerCode.ReadOnly;
            txtCustomerName.ReadOnly = !txtCustomerName.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
            txtAtrMan.ReadOnly = !txtAtrMan.ReadOnly;
            txtTelephoneCode.ReadOnly = !txtTelephoneCode.ReadOnly;
            txtFaxCode.ReadOnly = !txtFaxCode.ReadOnly;
            txtPostCode.ReadOnly = !txtPostCode.ReadOnly;
            txtEmail.ReadOnly = !txtEmail.ReadOnly;
            txtLinkman.ReadOnly = !txtLinkman.ReadOnly;
            txtUrl.ReadOnly = !txtUrl.ReadOnly;
            txtAddress.ReadOnly = !txtAddress.ReadOnly;
            //
            cbxGradeCode.Enabled = !cbxGradeCode.Enabled;
            cbxStateCode.Enabled = !cbxStateCode.Enabled;
            cbxCreditCode.Enabled = !cbxCreditCode.Enabled;
            cbxTradeCode.Enabled = !cbxTradeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            cbxEmployeeCode.SelectedIndex = -1;
            txtAtrMan.Text = "";
            txtTelephoneCode.Text = "";
            txtFaxCode.Text = "";
            txtPostCode.Text = "";
            txtEmail.Text = "";
            txtLinkman.Text = "";
            txtUrl.Text = "";
            txtAddress.Text = "";
            cbxGradeCode.SelectedIndex = -1;
            cbxStateCode.SelectedIndex = -1;
            cbxCreditCode.SelectedIndex = -1;
            cbxTradeCode.SelectedIndex = -1;
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("客户名称");
            cbxCondition.Items.Add("联系人");
            cbxCondition.Items.Add("地址");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtCustomerCode.Text = dgvCustomerInfo[0, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtCustomerName.Text = dgvCustomerInfo[1, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue = dgvCustomerInfo[2, dgvCustomerInfo.CurrentCell.RowIndex].Value;
            txtAtrMan.Text = dgvCustomerInfo[3, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtTelephoneCode.Text = dgvCustomerInfo[4, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtFaxCode.Text = dgvCustomerInfo[5, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtPostCode.Text = dgvCustomerInfo[6, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtEmail.Text = dgvCustomerInfo[7, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtLinkman.Text = dgvCustomerInfo[8, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtUrl.Text = dgvCustomerInfo[9, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            txtAddress.Text = dgvCustomerInfo[10, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();
            cbxGradeCode.SelectedValue = dgvCustomerInfo[11, dgvCustomerInfo.CurrentCell.RowIndex].Value;
            cbxStateCode.SelectedValue = dgvCustomerInfo[12, dgvCustomerInfo.CurrentCell.RowIndex].Value;
            cbxCreditCode.SelectedValue = dgvCustomerInfo[13, dgvCustomerInfo.CurrentCell.RowIndex].Value;
            cbxTradeCode.SelectedValue = dgvCustomerInfo[14, dgvCustomerInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += " FROM BSCustomer" + strWhere;
            ;

            try
            {
                dgvCustomerInfo.DataSource = db.GetDataSet(strSql, "BSCustomer").Tables["BSCustomer"];
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
            db.Cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@AtrMan", txtAtrMan.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@TelephoneCode", txtTelephoneCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@FaxCode", txtFaxCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PostCode", txtPostCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@Linkman", txtLinkman.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@Url", txtUrl.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

            if (cbxGradeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@GradeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@GradeCode", cbxGradeCode.SelectedValue.ToString());
            }

            if (cbxStateCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@StateCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@StateCode", cbxStateCode.SelectedValue.ToString());
            }

            if (cbxCreditCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@CreditCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CreditCode", cbxCreditCode.SelectedValue.ToString());
            }

            if (cbxTradeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@TradeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@TradeCode", cbxTradeCode.SelectedValue.ToString());
            }
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode, EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxGradeCode, "GradeCode", "GradeName", "select GradeCode, GradeName from CUGrade",
                                 "CUGrade");
            commUse.BindComboBox(cbxStateCode, "StateCode", "StateName", "select StateCode, StateName from CUState",
                                 "CUState");
            commUse.BindComboBox(cbxCreditCode, "CreditCode", "CreditName",
                                 "select CreditCode, CreditName from CUCredit", "CUCredit");
            commUse.BindComboBox(cbxTradeCode, "TradeCode", "TradeName", "select TradeCode, TradeName from CUTrade",
                                 "CUTrade");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvCustomerInfo.Columns[2], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode, EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvCustomerInfo.Columns[11], "GradeCode", "GradeName",
                                 "select GradeCode, GradeName from CUGrade", "CUGrade");
            commUse.BindComboBox(dgvCustomerInfo.Columns[12], "StateCode", "StateName",
                                 "select StateCode, StateName from CUState", "CUState");
            commUse.BindComboBox(dgvCustomerInfo.Columns[13], "CreditCode", "CreditName",
                                 "select CreditCode, CreditName from CUCredit", "CUCredit");
            commUse.BindComboBox(dgvCustomerInfo.Columns[14], "TradeCode", "TradeName",
                                 "select TradeCode, TradeName from CUTrade", "CUTrade");
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
            toolStrip1.Tag = "ADD"; //添加状态
            txtCustomerCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //编辑状态
            txtCustomerCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvCustomerInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSCustomer",
                                                  dgvCustomerInfo[0, dgvCustomerInfo.CurrentCell.RowIndex].Value.
                                                      ToString()))
                    {
                        txtCustomerCode.Enabled = false;
                    }
                    else
                    {
                        txtCustomerCode.Enabled = true;
                    }

                    FillControls();
                }
            }
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "";
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "客户名称":

                    strWhere = " WHERE CustomerName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "联系人":

                    strWhere = " WHERE Linkman LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "地址":

                    strWhere = " WHERE Address LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strCustomerCode = null;
            string strSql = null;

            if (dgvCustomerInfo.RowCount == 0)
            {
                return;
            }

            strCustomerCode = dgvCustomerInfo[0, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSCustomer", strCustomerCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSCustomer WHERE CustomerCode = '" + strCustomerCode + "'";

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

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            ;
            SqlDataReader sdr = null;

            if (String.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                MessageBox.Show("客户编号不许为空！", "软件提示");
                txtCustomerCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCustomerName.Text.Trim()))
            {
                MessageBox.Show("客户名称不许为空！", "软件提示");
                txtCustomerName.Focus();
                return;
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSCustomer where CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode =
                            "INSERT INTO BSCustomer(CustomerCode,CustomerName,EmployeeCode,AtrMan,TelephoneCode,FaxCode,PostCode,Email,Linkman,Url,Address,GradeCode,StateCode,CreditCode,TradeCode) ";
                        strCode +=
                            "VALUES(@CustomerCode,@CustomerName,@EmployeeCode,@AtrMan,@TelephoneCode,@FaxCode,@PostCode,@Email,@Linkman,@Url,@Address,@GradeCode,@StateCode,@CreditCode,@TradeCode)";

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
                    else
                    {
                        MessageBox.Show("编码重复，请重新设置", "软件提示");
                        txtCustomerCode.Focus();
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
            }

            //修改
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strOldCustomerCode = null;

                //未修改之前的客户代码
                strOldCustomerCode = dgvCustomerInfo[0, dgvCustomerInfo.CurrentCell.RowIndex].Value.ToString();

                //客户代码被修改过
                if (strOldCustomerCode != txtCustomerCode.Text.Trim())
                {
                    strCode = "select * from BSCustomer where CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtCustomerCode.Focus();
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
                }

                //更新数据库
                try
                {
                    strCode = "UPDATE BSCustomer SET CustomerCode = @CustomerCode,CustomerName = @CustomerName,";
                    strCode += "EmployeeCode = @EmployeeCode,AtrMan = @AtrMan,TelephoneCode = @TelephoneCode,";
                    strCode += "FaxCode = @FaxCode,PostCode = @PostCode,Email = @Email,";
                    strCode += "Linkman = @Linkman,Url = @Url,Address = @Address,";
                    strCode += "GradeCode = @GradeCode,StateCode = @StateCode,CreditCode = @CreditCode,";
                    strCode += "TradeCode = @TradeCode ";
                    strCode += "WHERE CustomerCode = '" + strOldCustomerCode + "'";

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

        private void dgvCustomerInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}