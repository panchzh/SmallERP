using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSInven : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSInven()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   用于切换控件状态
        /// </summary>
        private void ControlStatus()
        {
            //工具栏按钮状态切换
            toolSave.Enabled = !toolSave.Enabled;
            toolCancel.Enabled = !toolCancel.Enabled;
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //窗体控件状态切换
            txtInvenCode.ReadOnly = !txtInvenCode.ReadOnly;
            txtInvenName.ReadOnly = !txtInvenName.ReadOnly;
            cbxInvenTypeCode.Enabled = !cbxInvenTypeCode.Enabled;
            txtSpecsModel.ReadOnly = !txtSpecsModel.ReadOnly;
            txtMeaUnit.ReadOnly = !txtMeaUnit.ReadOnly;
            txtSelPrice.ReadOnly = !txtSelPrice.ReadOnly;
            txtPurPrice.ReadOnly = !txtPurPrice.ReadOnly;
            txtSmallStockNum.ReadOnly = !txtSmallStockNum.ReadOnly;
            txtBigStockNum.ReadOnly = !txtBigStockNum.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtInvenCode.Text = "";
            txtInvenName.Text = "";
            cbxInvenTypeCode.SelectedIndex = -1;
            txtSpecsModel.Text = "";
            txtMeaUnit.Text = "";
            txtSelPrice.Text = "";
            txtPurPrice.Text = "";
            txtSmallStockNum.Text = "";
            txtBigStockNum.Text = "";
        }

        /// <summary>
        ///   用于设置查询字段
        /// </summary>
        private void BindToolStripComboBox()
        {
            cbxCondition.Items.Add("存货名称");
            cbxCondition.Items.Add("规格型号");
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            txtInvenCode.Text = dgvInvenInfo[0, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtInvenName.Text = dgvInvenInfo[1, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            cbxInvenTypeCode.SelectedValue = dgvInvenInfo[2, dgvInvenInfo.CurrentCell.RowIndex].Value;
            txtSpecsModel.Text = dgvInvenInfo[3, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtMeaUnit.Text = dgvInvenInfo[4, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtSelPrice.Text = dgvInvenInfo[5, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtPurPrice.Text = dgvInvenInfo[6, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtSmallStockNum.Text = dgvInvenInfo[7, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
            txtBigStockNum.Text = dgvInvenInfo[8, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * FROM BSInven " + strWhere;

            try
            {
                dgvInvenInfo.DataSource = db.GetDataSet(strSql, "BSInven").Tables["BSInven"];
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
            db.Cmd.Parameters.AddWithValue("@InvenCode", txtInvenCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@InvenName", txtInvenName.Text.Trim());

            if (cbxInvenTypeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@InvenTypeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@InvenTypeCode", cbxInvenTypeCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@SpecsModel", txtSpecsModel.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@MeaUnit", txtMeaUnit.Text.Trim());

            if (String.IsNullOrEmpty(txtSelPrice.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@SelPrice", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SelPrice", Convert.ToDecimal(txtSelPrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtPurPrice.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@PurPrice", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@PurPrice", Convert.ToDecimal(txtPurPrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtSmallStockNum.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@SmallStockNum", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SmallStockNum", Convert.ToInt32(txtSmallStockNum.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtBigStockNum.Text.Trim()))
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@BigStockNum", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@BigStockNum", Convert.ToInt32(txtBigStockNum.Text.Trim()));
            }
        }

        private void FormInven_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxInvenTypeCode, "InvenTypeCode", "InvenTypeName", " Select * From BSInvenType",
                                 "BSInvenType");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvInvenInfo.Columns[2], "InvenTypeCode", "InvenTypeName", " Select * From BSInvenType",
                                 "BSInvenType");
            //
            BindDataGridView("");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";
        }

        private void txtSelPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void txtPurPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void txtSmallStockNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtBigStockNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加状态
            txtInvenCode.Enabled = true;
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改状态
            txtInvenCode.Enabled = false;
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "";
        }

        private void dgvInvenInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvInvenInfo.RowCount > 0)
                {
                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSInven",
                                                  dgvInvenInfo[0, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString()))
                    {
                        txtInvenCode.Enabled = false;
                    }
                    else
                    {
                        txtInvenCode.Enabled = true;
                    }

                    FillControls();
                }
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            SqlDataReader sdr = null;

            if (String.IsNullOrEmpty(txtInvenCode.Text.Trim()))
            {
                MessageBox.Show("存货编号不许为空！", "软件提示");
                txtInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtInvenName.Text.Trim()))
            {
                MessageBox.Show("存货名称不许为空！", "软件提示");
                txtInvenName.Focus();
                return;
            }

            if (cbxInvenTypeCode.SelectedValue == null)
            {
                MessageBox.Show("存货类别不许为空！", "软件提示");
                cbxInvenTypeCode.Focus();
                return;
            }

            if (!String.IsNullOrEmpty(txtBigStockNum.Text.Trim()) && !String.IsNullOrEmpty(txtSmallStockNum.Text.Trim()))
            {
                if (Convert.ToInt32(txtSmallStockNum.Text.Trim()) > Convert.ToInt32(txtBigStockNum.Text.Trim()))
                {
                    MessageBox.Show("最低库存不许大于最高库存！", "软件提示");
                    txtSmallStockNum.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strCode = "select * from BSInven where InvenCode = '" + txtInvenCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode =
                            "INSERT INTO BSInven(InvenCode,InvenName,InvenTypeCode,SpecsModel,MeaUnit,SelPrice,PurPrice,SmallStockNum,BigStockNum) ";
                        strCode +=
                            "VALUES(@InvenCode,@InvenName,@InvenTypeCode,@SpecsModel,@MeaUnit,@SelPrice,@PurPrice,@SmallStockNum,@BigStockNum)";

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
                        txtInvenCode.Focus();
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
                string strOldInvenCode = null;

                //未修改之前的存货代码
                strOldInvenCode = dgvInvenInfo[0, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();

                //存货代码被修改过
                if (strOldInvenCode != txtInvenCode.Text.Trim())
                {
                    strCode = "select * from BSInven where InvenCode = '" + txtInvenCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtInvenCode.Focus();
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
                    strCode = "UPDATE BSInven SET InvenCode = @InvenCode,InvenName = @InvenName,";
                    strCode += "InvenTypeCode = @InvenTypeCode,SpecsModel = @SpecsModel,MeaUnit = @MeaUnit,";
                    strCode +=
                        "SelPrice = @SelPrice,PurPrice = @PurPrice,SmallStockNum = @SmallStockNum,BigStockNum = @BigStockNum ";
                    strCode += "WHERE InvenCode = '" + strOldInvenCode + "'";

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
            string strInvenCode = null;
            string strSql = null;

            if (dgvInvenInfo.RowCount == 0)
            {
                return;
            }

            strInvenCode = dgvInvenInfo[0, dgvInvenInfo.CurrentCell.RowIndex].Value.ToString();

            //判断当前记录的主键值是否存在外键约束
            if (commUse.IsExistConstraint("BSInven", strInvenCode))
            {
                MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                return;
            }

            strSql = "DELETE FROM BSInven WHERE InvenCode = '" + strInvenCode + "'";

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
                case "存货名称":

                    strWhere = " WHERE InvenName LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "规格型号":

                    strWhere = " WHERE SpecsModel LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}