using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSAccount : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSAccount()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   空间的状态切换
        /// </summary>
        private void ControlStatus()
        {
            //按钮切换状态及授权控制
            toolSave.Enabled = !toolSave.Enabled;
            toolCancel.Enabled = !toolCancel.Enabled;
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);

            //窗体控件状态切换
            txtAccountCode.ReadOnly = !txtAccountCode.ReadOnly;
            txtAccountName.ReadOnly = !txtAccountName.ReadOnly;
            txtBankAccount.ReadOnly = !txtBankAccount.ReadOnly;
            cbxAccSubject.Enabled = !cbxAccSubject.Enabled;
            txtAccMoney.ReadOnly = !txtAccMoney.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            txtAccountCode.Text = "";
            txtAccountName.Text = "";
            txtBankAccount.Text = "";
            cbxAccSubject.SelectedIndex = -1;
            txtAccMoney.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("帐户名称");
            cbxCondition.Items.Add("银行账号");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtAccountCode.Text = dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();
            txtAccountName.Text = dgvAccountInfo[1, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();
            txtBankAccount.Text = dgvAccountInfo[2, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();
            cbxAccSubject.SelectedValue = dgvAccountInfo[3, dgvAccountInfo.CurrentCell.RowIndex].Value;
            txtAccMoney.Text = dgvAccountInfo[4, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT AccountCode,AccountName,BankAccount,";
            strSql += "AccSubject,AccMoney ";
            strSql += " FROM BSAccount" + strWhere;
            ;

            try
            {
                dgvAccountInfo.DataSource = db.GetDataSet(strSql, "BSAccount").Tables["BSAccount"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void txtAccMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        /// <summary>
        ///   设置参数值
        /// </summary>
        private void ParametersAddValue()
        {
            db.Cmd.Parameters.Clear();
            db.Cmd.Parameters.AddWithValue("@AccountCode", txtAccountCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@BankAccount", txtBankAccount.Text.Trim());

            if (cbxAccSubject.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@AccSubject", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccSubject", cbxAccSubject.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtAccMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@AccMoney", 0); //设置账户的默认金额为0，保证帐户的初始金额不为空
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AccMoney", Decimal.Round(Convert.ToDecimal(txtAccMoney.Text.Trim()), 2));
                //初始帐户金额
            }
        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);

            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxAccSubject, "Code", "Name", "select * from INAccSubject", "INAccSubject");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvAccountInfo.Columns[3], "Code", "Name", "select * from INAccSubject", "INAccSubject");
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
            toolStrip1.Tag = "ADD"; //表示添加状态
            txtAccountCode.Enabled = true;
            txtAccountName.Enabled = true;
            cbxAccSubject.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //表示修改状态
            txtAccountCode.Enabled = false;
            txtAccountName.Enabled = true;
            cbxAccSubject.Enabled = true;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvAccountInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvAccountInfo.RowCount > 0)
                {
                    //对于基础类型帐户信息，不许修改帐户代码、帐户名称、会计科目
                    if (dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString() == "01"
                        || dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString() == "02")
                    {
                        txtAccountCode.Enabled = false;
                        txtAccountName.Enabled = false;
                        cbxAccSubject.Enabled = false;
                    }
                    else
                    {
                        txtAccountCode.Enabled = true;
                        txtAccountName.Enabled = true;
                        cbxAccSubject.Enabled = true;
                    }

                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSAccount",
                                                  dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString()))
                    {
                        txtAccountCode.Enabled = false;
                    }
                    else
                    {
                        txtAccountCode.Enabled = true;
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

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            SqlDataReader sdr = null;

            if (String.IsNullOrEmpty(txtAccountCode.Text.Trim()))
            {
                MessageBox.Show("帐户编号不许为空！", "软件提示");
                txtAccountCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtAccountName.Text.Trim()))
            {
                MessageBox.Show("帐户名称不许为空！", "软件提示");
                txtAccountName.Focus();
                return;
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSAccount where AccountCode = '" + txtAccountCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode = "INSERT INTO BSAccount(AccountCode,AccountName,BankAccount,AccSubject,AccMoney) ";
                        strCode += "VALUES(@AccountCode,@AccountName,@BankAccount,@AccSubject,@AccMoney)";

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
                        txtAccountCode.Focus();
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
                string strOldAccountCode = null; //未修改之前的帐户代码

                strOldAccountCode = dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();

                //若帐户代码被修改过
                if (strOldAccountCode != txtAccountCode.Text.Trim())
                {
                    strCode = "select * from BSAccount where AccountCode = '" + txtAccountCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtAccountCode.Focus();
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
                    strCode = "UPDATE BSAccount SET AccountCode = @AccountCode,AccountName = @AccountName,";
                    strCode += "BankAccount = @BankAccount,AccSubject = @AccSubject,AccMoney = @AccMoney";
                    strCode += " WHERE AccountCode = '" + strOldAccountCode + "'";

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
            string strAccountCode = null;
            string strSql = null;

            if (dgvAccountInfo.RowCount == 0)
            {
                return;
            }

            strAccountCode = dgvAccountInfo[0, dgvAccountInfo.CurrentCell.RowIndex].Value.ToString();

            if (strAccountCode == "01" || strAccountCode == "02")
            {
                MessageBox.Show("基础类型帐户，无法删除", "软件提示");
                return;
            }

            if (commUse.IsExistConstraint("BSAccount", strAccountCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSAccount WHERE AccountCode = '" + strAccountCode + "'";

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

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "帐户名称":

                    strWhere = " WHERE AccountName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "银行账号":

                    strWhere = " WHERE BankAccount LIKE '%" + txtKeyWord.Text.Trim() + "%'";
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
    }
}