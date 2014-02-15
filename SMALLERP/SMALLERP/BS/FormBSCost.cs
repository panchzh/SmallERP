using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSCost : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSCost()
        {
            InitializeComponent();
        }

        private void ControlStatus()
        {
            //按工具栏钮状态切换
            toolSave.Enabled = !toolSave.Enabled;
            toolCancel.Enabled = !toolCancel.Enabled;
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);

            //窗体控件状态切换
            txtCostCode.ReadOnly = !txtCostCode.ReadOnly;
            txtCostName.ReadOnly = !txtCostName.ReadOnly;
            cbxCostTypeCode.Enabled = !cbxCostTypeCode.Enabled;
            rtbRemark.ReadOnly = !rtbRemark.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            txtCostCode.Text = "";
            txtCostName.Text = "";
            cbxCostTypeCode.SelectedIndex = -1;
            rtbRemark.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("费用名称");
            cbxCondition.Items.Add("备注");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtCostCode.Text = dgvCostInfo[0, dgvCostInfo.CurrentCell.RowIndex].Value.ToString();
            txtCostName.Text = dgvCostInfo[1, dgvCostInfo.CurrentCell.RowIndex].Value.ToString();
            cbxCostTypeCode.SelectedValue = dgvCostInfo[2, dgvCostInfo.CurrentCell.RowIndex].Value;
            rtbRemark.Text = dgvCostInfo[3, dgvCostInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView绑定数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT CostCode,CostName,";
            strSql += "CostTypeCode,Remark ";
            strSql += " FROM BSCost" + strWhere;
            ;

            try
            {
                dgvCostInfo.DataSource = db.GetDataSet(strSql, "BSCost").Tables["BSCost"];
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
            db.Cmd.Parameters.AddWithValue("@CostCode", txtCostCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@CostName", txtCostName.Text.Trim());

            if (cbxCostTypeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@CostTypeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CostTypeCode", cbxCostTypeCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@Remark", rtbRemark.Text.Trim());
        }

        private void FormCost_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxCostTypeCode, "CostTypeCode", "CostTypeName", "select * from BSCostType",
                                 "BSCostType");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvCostInfo.Columns[2], "CostTypeCode", "CostTypeName", "select * from BSCostType",
                                 "BSCostType");
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
            txtCostCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改状态
            txtCostCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvCostInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvCostInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSCost",
                                                  dgvCostInfo[0, dgvCostInfo.CurrentCell.RowIndex].Value.ToString()))
                    {
                        txtCostCode.Enabled = false;
                    }
                    else
                    {
                        txtCostCode.Enabled = true;
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
            ;
            SqlDataReader sdr = null;

            if (String.IsNullOrEmpty(txtCostCode.Text.Trim()))
            {
                MessageBox.Show("费用编号不许为空！", "软件提示");
                txtCostCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCostName.Text.Trim()))
            {
                MessageBox.Show("费用名称不许为空！", "软件提示");
                txtCostName.Focus();
                return;
            }

            if (cbxCostTypeCode.SelectedValue == null)
            {
                MessageBox.Show("费用类别不许为空！", "软件提示");
                cbxCostTypeCode.Focus();
                return;
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSCost where CostCode = '" + txtCostCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode = "INSERT INTO BSCost(CostCode,CostName,CostTypeCode,Remark) ";
                        strCode += "VALUES(@CostCode,@CostName,@CostTypeCode,@Remark)";

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
                        txtCostCode.Focus();
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
                string strOldCostCode = null;

                //未修改的费用代码
                strOldCostCode = dgvCostInfo[0, dgvCostInfo.CurrentCell.RowIndex].Value.ToString();

                //费用代码被修改过
                if (strOldCostCode != txtCostCode.Text.Trim())
                {
                    strCode = "select * from BSCost where CostCode = '" + txtCostCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtCostCode.Focus();
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
                    strCode = "UPDATE BSCost SET CostCode = @CostCode,CostName = @CostName,";
                    strCode += "CostTypeCode = @CostTypeCode,Remark = @Remark";
                    strCode += " WHERE CostCode = '" + strOldCostCode + "'";

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
            string strCostCode = null;
            string strSql = null;

            if (dgvCostInfo.RowCount == 0)
            {
                return;
            }

            strCostCode = dgvCostInfo[0, dgvCostInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSCost", strCostCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSCost WHERE CostCode = '" + strCostCode + "'";

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
                case "费用名称":

                    strWhere = " WHERE CostName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "备注":

                    strWhere = " WHERE Remark LIKE '%" + txtKeyWord.Text.Trim() + "%'";
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