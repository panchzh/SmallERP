using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSEmployee : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSEmployee()
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
            txtEmployeeCode.ReadOnly = !txtEmployeeCode.ReadOnly;
            txtEmployeeName.ReadOnly = !txtEmployeeName.ReadOnly;
            cbxDepartmentCode.Enabled = !cbxDepartmentCode.Enabled;
            txtAge.ReadOnly = !txtAge.ReadOnly;
            cbxSex.Enabled = !cbxSex.Enabled;
            cbxEduLevel.Enabled = !cbxEduLevel.Enabled;
            txtJob.ReadOnly = !txtJob.ReadOnly;
            dtpJoinDate.Enabled = !dtpJoinDate.Enabled;
            txtTelephoneCode.ReadOnly = !txtTelephoneCode.ReadOnly;
            rtbRemark.ReadOnly = !rtbRemark.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtEmployeeCode.Text = "";
            txtEmployeeName.Text = "";
            cbxDepartmentCode.SelectedIndex = -1;
            txtAge.Text = "";
            cbxSex.SelectedIndex = -1;
            cbxEduLevel.SelectedIndex = -1;
            txtJob.Text = "";
            dtpJoinDate.Value = Convert.ToDateTime("1900-01-01"); //DateTime.Today;
            txtTelephoneCode.Text = "";
            rtbRemark.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("员工名称");
            cbxCondition.Items.Add("职位");
        }

        ///<summary>
        ///  设置控件的显示值
        ///</summary>
        private void FillControls()
        {
            txtEmployeeCode.Text = dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
            txtEmployeeName.Text = dgvEmployeeInfo[1, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
            cbxDepartmentCode.SelectedValue = dgvEmployeeInfo[2, dgvEmployeeInfo.CurrentCell.RowIndex].Value;
            txtAge.Text = dgvEmployeeInfo[3, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
            cbxSex.SelectedValue = dgvEmployeeInfo[4, dgvEmployeeInfo.CurrentCell.RowIndex].Value;
            cbxEduLevel.SelectedValue = dgvEmployeeInfo[5, dgvEmployeeInfo.CurrentCell.RowIndex].Value;
            txtJob.Text = dgvEmployeeInfo[6, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
            dtpJoinDate.Value = Convert.ToDateTime(dgvEmployeeInfo[7, dgvEmployeeInfo.CurrentCell.RowIndex].Value);
            txtTelephoneCode.Text = dgvEmployeeInfo[8, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
            rtbRemark.Text = dgvEmployeeInfo[9, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM BSEmployee" + strWhere;
            ;

            try
            {
                dgvEmployeeInfo.DataSource = db.GetDataSet(strSql, "BSEmployee").Tables["BSEmployee"];
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
            db.Cmd.Parameters.AddWithValue("@EmployeeCode", txtEmployeeCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text.Trim());

            if (cbxDepartmentCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@DepartmentCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@DepartmentCode", cbxDepartmentCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@Age", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text.Trim()));
            }

            if (cbxSex.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@Sex", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Sex", cbxSex.SelectedValue.ToString());
            }

            if (cbxEduLevel.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EduLevel", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EduLevel", cbxEduLevel.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@Job", txtJob.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value);
            db.Cmd.Parameters.AddWithValue("@TelephoneCode", txtTelephoneCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@Remark", rtbRemark.Text.Trim());
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxDepartmentCode, "DepartmentCode", "DepartmentName",
                                 "select DepartmentCode,DepartmentName from BSDepartment", "BSDepartment");
            commUse.BindComboBox(cbxSex, "Code", "Name", "select * from INSex", "INSex");
            commUse.BindComboBox(cbxEduLevel, "Code", "Name", "select * from INEduLevel", "INEduLevel");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvEmployeeInfo.Columns[2], "DepartmentCode", "DepartmentName",
                                 "select DepartmentCode,DepartmentName from BSDepartment", "BSDepartment");
            commUse.BindComboBox(dgvEmployeeInfo.Columns[4], "Code", "Name", "select * from INSex", "INSex");
            commUse.BindComboBox(dgvEmployeeInfo.Columns[5], "Code", "Name", "select * from INEduLevel", "INEduLevel");
            //DataGridView绑定到数据源
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
            txtEmployeeCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //表示是修改状态
            txtEmployeeCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvStoreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvEmployeeInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSEmployee",
                                                  dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value.
                                                      ToString()))
                    {
                        txtEmployeeCode.Enabled = false;
                    }
                    else
                    {
                        txtEmployeeCode.Enabled = true;
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

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "员工名称":

                    strWhere = " WHERE EmployeeName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "职位":

                    strWhere = " WHERE Job LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strEmployeeCode = null;
            string strSql = null;

            if (dgvEmployeeInfo.RowCount == 0)
            {
                return;
            }

            strEmployeeCode = dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSEmployee", strEmployeeCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSEmployee WHERE EmployeeCode = '" + strEmployeeCode + "'";

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

            if (String.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
            {
                MessageBox.Show("员工编号不许为空！", "软件提示");
                txtEmployeeCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtEmployeeName.Text.Trim()))
            {
                MessageBox.Show("员工名称不许为空！", "软件提示");
                txtEmployeeName.Focus();
                return;
            }

            if (cbxDepartmentCode.SelectedValue == null)
            {
                MessageBox.Show("所在部门不许为空！", "软件提示");
                cbxDepartmentCode.Focus();
                return;
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSEmployee where EmployeeCode = '" + txtEmployeeCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode =
                            "INSERT INTO BSEmployee(EmployeeCode,EmployeeName,DepartmentCode,Age,Sex,EduLevel,Job,JoinDate,TelephoneCode,Remark) ";
                        strCode +=
                            "VALUES(@EmployeeCode,@EmployeeName,@DepartmentCode,@Age,@Sex,@EduLevel,@Job,@JoinDate,@TelephoneCode,@Remark)";

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
                        txtEmployeeCode.Focus();
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
                string strOldEmployeeCode = null;

                //未修改之前的员工代码
                strOldEmployeeCode = dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value.ToString();

                //员工代码被修改过
                if (strOldEmployeeCode != txtEmployeeCode.Text.Trim())
                {
                    strCode = "select * from BSEmployee where StoreCode = '" + txtEmployeeCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtEmployeeCode.Focus();
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
                    strCode = "UPDATE BSEmployee SET EmployeeCode = @EmployeeCode,EmployeeName = @EmployeeName,";
                    strCode += "DepartmentCode = @DepartmentCode,Age = @Age,Sex = @Sex,";
                    strCode +=
                        "EduLevel = @EduLevel,Job = @Job,JoinDate = @JoinDate,TelephoneCode = @TelephoneCode,Remark = @Remark ";
                    strCode += " WHERE EmployeeCode = '" + strOldEmployeeCode + "'";

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

        private void dgvEmployeeInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}