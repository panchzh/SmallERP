using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.SY
{
    public partial class FormSYOperator : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormSYOperator()
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
            txtOperatorCode.ReadOnly = !txtOperatorCode.ReadOnly;
            txtOperatorName.ReadOnly = !txtOperatorName.ReadOnly;
            txtPassWord.ReadOnly = !txtPassWord.ReadOnly;
            txtAgainPassWord.ReadOnly = !txtAgainPassWord.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            txtOperatorCode.Text = "";
            txtOperatorName.Text = "";
            txtPassWord.Text = "";
            txtAgainPassWord.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("用户编码");
            cbxCondition.Items.Add("用户名称");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtOperatorCode.Text =
                dgvSYOperatorInfo["OperatorCode", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            txtOperatorName.Text =
                dgvSYOperatorInfo["OperatorName", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            txtPassWord.Text = dgvSYOperatorInfo["PassWord", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
            txtAgainPassWord.Text =
                dgvSYOperatorInfo["PassWord", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += " FROM SYOperator" + strWhere;
            ;

            try
            {
                dgvSYOperatorInfo.DataSource = db.GetDataSet(strSql, "SYOperator").Tables["SYOperator"];
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
            db.Cmd.Parameters.AddWithValue("@OperatorCode", txtOperatorCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@OperatorName", txtOperatorName.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PassWord", txtPassWord.Text);
            db.Cmd.Parameters.AddWithValue("@IsAdmin", "0");
        }

        private void FormSYOperator_Load(object sender, EventArgs e)
        {
            //设置权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //绑定到数据源
            commUse.BindComboBox(dgvSYOperatorInfo.Columns["IsAdmin"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");
            BindDataGridView("");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD";
            txtOperatorCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            txtPassWord.ReadOnly = true;
            txtAgainPassWord.ReadOnly = true;
            toolStrip1.Tag = "EDIT";
            txtOperatorCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvSYOperatorInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvSYOperatorInfo.RowCount > 0)
                {
                    string strIsAdmin =
                        dgvSYOperatorInfo["IsAdmin", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();

                    //系统管理员不许编辑
                    if (strIsAdmin == "1")
                    {
                        MessageBox.Show("系统管理员，不许编辑！", "软件提示");
                        return;
                    }

                    //判断当前记录的主键值是否存在外键约束,若存在不许修改该操作员的编码
                    if (commUse.IsExistConstraint("SYOperator",
                                                  dgvSYOperatorInfo[
                                                      "OperatorCode", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.
                                                      ToString()))
                    {
                        txtOperatorCode.Enabled = false;
                    }
                    else
                    {
                        txtOperatorCode.Enabled = true;
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

            if (String.IsNullOrEmpty(txtOperatorCode.Text.Trim()))
            {
                MessageBox.Show("用户编码不许为空！", "软件提示");
                txtOperatorCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtOperatorName.Text.Trim()))
            {
                MessageBox.Show("用户名称不许为空！", "软件提示");
                txtOperatorName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("密码不许为空！", "软件提示");
                txtPassWord.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtAgainPassWord.Text))
            {
                MessageBox.Show("确认密码不许为空！", "软件提示");
                txtAgainPassWord.Focus();
                return;
            }

            if (txtPassWord.Text != txtAgainPassWord.Text)
            {
                MessageBox.Show("两次输入的密码不相同！", "软件提示");
                txtPassWord.Focus();
                return;
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from SYOperator where OperatorCode = '" + txtOperatorCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode = "INSERT INTO SYOperator(OperatorCode,OperatorName,PassWord,IsAdmin) ";
                        strCode += "VALUES(@OperatorCode,@OperatorName,@PassWord,@IsAdmin)";

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
                        txtOperatorCode.Focus();
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
                string strOldOperatorCode = null; //未修改之前的用户编码

                strOldOperatorCode =
                    dgvSYOperatorInfo["OperatorCode", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();

                //用户编码被修改过
                if (strOldOperatorCode != txtOperatorCode.Text.Trim())
                {
                    strCode = "select * from SYOperator where OperatorCode = '" + txtOperatorCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("用户编码重复，请重新设置", "软件提示");
                            txtOperatorCode.Focus();
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
                    strCode = "UPDATE SYOperator SET OperatorCode = @OperatorCode,OperatorName = @OperatorName ";
                    strCode += "WHERE OperatorCode = '" + strOldOperatorCode + "'";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        BindDataGridView("");
                        ControlStatus();
                        txtAgainPassWord.ReadOnly = true;
                        txtPassWord.ReadOnly = true;
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
            string strIsAdmin = null; //系统管理员标识
            string strOperatorCode = null; //操作员代码
            string strSYOperatorSql = null; //表示提交SYOperator表的SQL语句
            string strSYAssignRightSql = null; //表示提交SYAssignRight表的SQL语句
            List<string> strSqls = new List<string>();

            if (dgvSYOperatorInfo.RowCount == 0)
            {
                return;
            }

            strIsAdmin = dgvSYOperatorInfo["IsAdmin", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsAdmin == "1")
            {
                MessageBox.Show("系统管理员，不许删除！", "软件提示");
                return;
            }

            strOperatorCode = dgvSYOperatorInfo["OperatorCode", dgvSYOperatorInfo.CurrentCell.RowIndex].Value.ToString();

            if (strOperatorCode == PropertyClass.OperatorCode)
            {
                MessageBox.Show("操作员不许删除自己！", "软件提示");
                return;
            }

            //判断当前记录的主键值是否存在外键约束,若存在，则不允许删除该记录
            if (commUse.IsExistConstraint("SYOperator", strOperatorCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSYOperatorSql = "DELETE FROM SYOperator WHERE OperatorCode = '" + strOperatorCode + "'";
            strSqls.Add(strSYOperatorSql);

            strSYAssignRightSql = "Delete From SYAssignRight Where OperatorCode = '" + strOperatorCode + "'";
            strSqls.Add(strSYAssignRightSql);

            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                DialogResult.Yes)
            {
                try
                {
                    //提交多条SQL语句
                    if (db.ExecDataBySqls(strSqls))
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
                case "用户名称":

                    strWhere = " WHERE OperatorName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "用户编码":

                    strWhere = " WHERE OperatorCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
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