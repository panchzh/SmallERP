using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSSupplier : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSSupplier()
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
            txtSupplierCode.ReadOnly = !txtSupplierCode.ReadOnly;
            txtSupplierName.ReadOnly = !txtSupplierName.ReadOnly;
            txtTelephoneCode.ReadOnly = !txtTelephoneCode.ReadOnly;
            txtEmail.ReadOnly = !txtEmail.ReadOnly;
            txtPostCode.ReadOnly = !txtPostCode.ReadOnly;
            txtLinkman.ReadOnly = !txtLinkman.ReadOnly;
            txtUrl.ReadOnly = !txtUrl.ReadOnly;
            txtAddress.ReadOnly = !txtAddress.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtTelephoneCode.Text = "";
            txtEmail.Text = "";
            txtPostCode.Text = "";
            txtLinkman.Text = "";
            txtUrl.Text = "";
            txtAddress.Text = "";
        }

        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("供应商名称");
            cbxCondition.Items.Add("联系人");
            cbxCondition.Items.Add("地址");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtSupplierCode.Text = dgvSupplierInfo[0, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtSupplierName.Text = dgvSupplierInfo[1, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtTelephoneCode.Text = dgvSupplierInfo[2, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtEmail.Text = dgvSupplierInfo[3, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtPostCode.Text = dgvSupplierInfo[4, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtLinkman.Text = dgvSupplierInfo[5, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtUrl.Text = dgvSupplierInfo[6, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
            txtAddress.Text = dgvSupplierInfo[7, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT SupplierCode as 供应商编码,SupplierName as 供应商名称,Linkman as 联系人,";
            strSql += "TelephoneCode as 联系电话,Email as 电子信箱,PostCode as 邮政编码,Url as 网址,";
            strSql += "Address as 地址 FROM BSSupplier " + strWhere;

            try
            {
                dgvSupplierInfo.DataSource = db.GetDataSet(strSql, "BSSupplier").Tables["BSSupplier"];

                foreach (DataGridViewColumn dgvc in dgvSupplierInfo.Columns)
                {
                    dgvc.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //
            BindDataGridView("");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            dgvSupplierInfo.Columns[0].Visible = false;
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加操作
            txtSupplierCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改操作
            txtSupplierCode.Enabled = false;
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvSupplierInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvSupplierInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSSupplier",
                                                  dgvSupplierInfo[0, dgvSupplierInfo.CurrentCell.RowIndex].Value.
                                                      ToString()))
                    {
                        txtSupplierCode.Enabled = false;
                    }
                    else
                    {
                        txtSupplierCode.Enabled = true;
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

            //添加操作
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSSupplier where SupplierCode = '" + txtSupplierCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();
                        strCode =
                            "INSERT INTO BSSupplier(SupplierCode,SupplierName,TelephoneCode,Email,PostCode,Linkman,Url,Address) VALUES('";
                        strCode += txtSupplierCode.Text.Trim() + "','" + txtSupplierName.Text.Trim() + "','" +
                                   txtTelephoneCode.Text.Trim() + "','";
                        strCode += txtEmail.Text.Trim() + "','" + txtPostCode.Text.Trim() + "','" +
                                   txtLinkman.Text.Trim() + "','" + txtUrl.Text.Trim() + "','";
                        strCode += txtAddress.Text.Trim() + "')";

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
                        txtSupplierCode.Focus();
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
                string strOldSupplierCode = null;

                //未修改之前的供应商代码
                strOldSupplierCode = dgvSupplierInfo[0, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();

                //供应商代码被修改过
                if (strOldSupplierCode != txtSupplierCode.Text.Trim())
                {
                    strCode = "select * from BSSupplier where SupplierCode = '" + txtSupplierCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtSupplierCode.Focus();
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
                    strCode = "UPDATE BSSupplier SET SupplierCode = '" + txtSupplierCode.Text.Trim() +
                              "',SupplierName = '" + txtSupplierName.Text.Trim() + "',";
                    strCode += "TelephoneCode = '" + txtTelephoneCode.Text.Trim() + "',Email = '" + txtEmail.Text.Trim() +
                               "',PostCode = '" + txtPostCode.Text.Trim() + "',";
                    strCode += "Linkman = '" + txtLinkman.Text.Trim() + "',Url = '" + txtUrl.Text.Trim() +
                               "',Address = '" + txtAddress.Text.Trim() + "' ";
                    strCode += "WHERE SupplierCode = '" + strOldSupplierCode + "'";
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
            string strSupplierCode = null;
            string strSql = null;

            if (dgvSupplierInfo.RowCount == 0)
            {
                return;
            }

            strSupplierCode = dgvSupplierInfo[0, dgvSupplierInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSSupplier", strSupplierCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSSupplier WHERE SupplierCode = '" + strSupplierCode + "'";

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
                case "供应商名称":

                    strWhere = " WHERE SupplierName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
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
    }
}