using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;
using SMALLERP.SE;

namespace SMALLERP.PR
{
    public partial class FormPRPlan : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormPRPlan()
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
            btnChoice.Enabled = !btnChoice.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            dtpFinishDate.Enabled = ! dtpFinishDate.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtPRPlanCode.Text = "";
            dtpPRPlanDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            txtSEOrderCode.Text = "";
            cbxInvenCode.SelectedIndex = -1;
            txtQuantity.Text = "";
            dtpFinishDate.Value = Convert.ToDateTime("1900-01-01");
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
            txtPRPlanCode.Text = dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            dtpPRPlanDate.Value =
                Convert.ToDateTime(dgvPRPlanInfo["PRPlanDate", dgvPRPlanInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue = dgvPRPlanInfo["OperatorCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value;
            txtSEOrderCode.Text = dgvPRPlanInfo["SEOrderCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            cbxInvenCode.SelectedValue = dgvPRPlanInfo["InvenCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value;
            txtQuantity.Text = dgvPRPlanInfo["Quantity", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            dtpFinishDate.Value =
                Convert.ToDateTime(dgvPRPlanInfo["FinishDate", dgvPRPlanInfo.CurrentCell.RowIndex].Value);
            cbxIsFlag.SelectedValue = dgvPRPlanInfo["IsFlag", dgvPRPlanInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PRPlan " + strWhere;
            ;

            try
            {
                dgvPRPlanInfo.DataSource = db.GetDataSet(strSql, "PRPlan").Tables["PRPlan"];
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
            db.Cmd.Parameters.AddWithValue("@PRPlanCode", txtPRPlanCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PRPlanDate", dtpPRPlanDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtSEOrderCode.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@SEOrderCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SEOrderCode", txtSEOrderCode.Text.Trim());
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

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
            }

            db.Cmd.Parameters.AddWithValue("@FinishDate", dtpFinishDate.Value);

            if (cbxIsFlag.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", cbxIsFlag.SelectedValue.ToString());
            }
        }

        private void FormPRPlan_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "Select InvenCode,InvenName From BSInven",
                                 "BSInven");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvPRPlanInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPRPlanInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPRPlanInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
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

            dtpPRPlanDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            txtQuantity.Text = "1";
            dtpFinishDate.Value = DateTime.Today;
            cbxIsFlag.SelectedValue = "0";

            txtPRPlanCode.Text = commUse.BuildBillCode("PRPlan", "PRPlanCode", "PRPlanDate", dtpPRPlanDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvPRPlanInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvPRPlanInfo.RowCount > 0)
            {
                if (dgvPRPlanInfo["IsFlag", dgvPRPlanInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void btnChoice_Click(object sender, EventArgs e)
        {
            FormBrowseSEOrder formBrowseSEOrder = new FormBrowseSEOrder();
            formBrowseSEOrder.Owner = this;
            formBrowseSEOrder.ShowDialog();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            SqlDataReader sdr = null;

            if (String.IsNullOrEmpty(txtPRPlanCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtPRPlanCode.Focus();
                return;
            }

            if (cbxInvenCode.SelectedValue == null)
            {
                MessageBox.Show("产品名称不许为空！", "软件提示");
                cbxInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("计划产量不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("计划产量不能等于零", "软件提示");
                    txtQuantity.Focus();
                    return;
                }
            }

            if (dtpFinishDate.Value < dtpPRPlanDate.Value)
            {
                MessageBox.Show("完工日期不许小于单据日期！", "软件提示");
                dtpFinishDate.Focus();
                return;
            }

            //判断该存货是否具有物料清单
            strCode = "Select * From BSBom Where ProInvenCode = '" + cbxInvenCode.SelectedValue + "'";
            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();
                if (!sdr.HasRows)
                {
                    MessageBox.Show("该产品没有物料清单，无法制定主生产计划！", "软件提示");
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

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO PRPlan(PRPlanCode,PRPlanDate,OperatorCode,SEOrderCode,InvenCode,Quantity,FinishDate,IsFlag) ";
                    strCode +=
                        "VALUES(@PRPlanCode,@PRPlanDate,@OperatorCode,@SEOrderCode,@InvenCode,@Quantity,@FinishDate,@IsFlag)";

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
                string strPRPlanCode = txtPRPlanCode.Text.Trim();

                //更新数据库
                try
                {
                    strCode =
                        "UPDATE PRPlan SET PRPlanCode = @PRPlanCode,PRPlanDate = @PRPlanDate,OperatorCode = @OperatorCode, SEOrderCode = @SEOrderCode,";
                    strCode += "InvenCode = @InvenCode,Quantity = @Quantity,";
                    strCode += "FinishDate = @FinishDate,IsFlag = @IsFlag";
                    strCode += " WHERE PRPlanCode = '" + strPRPlanCode + "'";

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
            string strPRPlanCode = null; //主生产计划号
            string strSql = null;
            string strFlag = null;

            if (dgvPRPlanInfo.RowCount <= 0)
            {
                return;
            }

            strPRPlanCode = dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPRPlanInfo["IsFlag", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM PRPlan WHERE PRPlanCode = '" + strPRPlanCode + "'";

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
            string strPRPlanCode = null; //主生产计划号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvPRPlanInfo.RowCount == 0)
            {
                return;
            }

            strPRPlanCode = dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPRPlanInfo["IsFlag", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strSql = "UPDATE PRPlan SET IsFlag = '1' WHERE PRPlanCode = '" + strPRPlanCode + "'";

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
            string strPRPlanCode = null; //主生产计划号
            string strSql = null;
            string strFlag = null; //审核标记
            SqlDataReader sdr = null;

            if (dgvPRPlanInfo.RowCount == 0)
            {
                return;
            }

            strPRPlanCode = dgvPRPlanInfo["PRPlanCode", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPRPlanInfo["IsFlag", dgvPRPlanInfo.CurrentCell.RowIndex].Value.ToString();
            strSql = "select * from PRProduce where  PRPlanCode = '" + strPRPlanCode + "'";

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

            strSql = "UPDATE PRPlan SET IsFlag = '0' WHERE PRPlanCode = '" + strPRPlanCode + "'";

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

                    strWhere = " WHERE PRPlanCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),PRPlanDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvPRPlanInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}