using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSStore : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSStore()
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
            txtStoreCode.ReadOnly = !txtStoreCode.ReadOnly;
            txtStoreName.ReadOnly = !txtStoreName.ReadOnly;
            txtArea.ReadOnly = !txtArea.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
            rtbRemark.ReadOnly = !rtbRemark.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            txtStoreCode.Text = "";
            txtStoreName.Text = "";
            txtArea.Text = "";
            cbxEmployeeCode.SelectedIndex = -1;
            rtbRemark.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("仓库名称");
            cbxCondition.Items.Add("备注");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtStoreCode.Text = dgvStoreInfo[0, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtStoreName.Text = dgvStoreInfo[1, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtArea.Text = dgvStoreInfo[2, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue = dgvStoreInfo[3, dgvStoreInfo.CurrentCell.RowIndex].Value;
            rtbRemark.Text = dgvStoreInfo[4, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT StoreCode,StoreName,Area,";
            strSql += "EmployeeCode,Remark ";
            strSql += "FROM BSStore" + strWhere;
            ;

            try
            {
                dgvStoreInfo.DataSource = db.GetDataSet(strSql, "BSStore").Tables["BSStore"];
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
            db.Cmd.Parameters.AddWithValue("@StoreCode", txtStoreCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@StoreName", txtStoreName.Text.Trim());

            if (String.IsNullOrEmpty(txtArea.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@Area", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Area", Convert.ToDecimal(txtArea.Text.Trim()));
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@Remark", rtbRemark.Text.Trim());
        }

        private void FormStore_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvStoreInfo.Columns[3], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
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
            toolStrip1.Tag = "ADD"; //添加操作
            txtStoreCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改操作
            txtStoreCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvStoreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvStoreInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSStore",
                                                  dgvStoreInfo[0, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString()))
                    {
                        txtStoreCode.Enabled = false;
                    }
                    else
                    {
                        txtStoreCode.Enabled = true;
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

            if (String.IsNullOrEmpty(txtStoreCode.Text.Trim()))
            {
                MessageBox.Show("仓库编号不许为空！", "软件提示");
                txtStoreCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtStoreName.Text.Trim()))
            {
                MessageBox.Show("仓库名称不许为空！", "软件提示");
                txtStoreName.Focus();
                return;
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                MessageBox.Show("管理员不许为空！", "软件提示");
                cbxEmployeeCode.Focus();
                return;
            }

            //添加操作
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSStore where StoreCode = '" + txtStoreCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode = "INSERT INTO BSStore(StoreCode,StoreName,Area,EmployeeCode,Remark) ";
                        strCode += "VALUES(@StoreCode,@StoreName,@Area,@EmployeeCode,@Remark)";

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
                        txtStoreCode.Focus();
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

            //修改操作
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strOldStoreCode = null;

                //未修改之前的仓库代码
                strOldStoreCode = dgvStoreInfo[0, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();

                //仓库代码被修改过
                if (strOldStoreCode != txtStoreCode.Text.Trim())
                {
                    strCode = "select * from BSStore where StoreCode = '" + txtStoreCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtStoreCode.Focus();
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
                    strCode = "UPDATE BSStore SET StoreCode = @StoreCode,StoreName = @StoreName,";
                    strCode += "Area = @Area,EmployeeCode = @EmployeeCode,Remark = @Remark";
                    strCode += " WHERE StoreCode = '" + strOldStoreCode + "'";

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
            string strStoreCode = null;
            string strSql = null;

            if (dgvStoreInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvStoreInfo[0, dgvStoreInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSStore", strStoreCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSStore WHERE StoreCode = '" + strStoreCode + "'";

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
                case "仓库名称":

                    strWhere = " WHERE StoreName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
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

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }
    }
}