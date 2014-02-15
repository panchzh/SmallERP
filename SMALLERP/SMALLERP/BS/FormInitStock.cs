using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormInitStock : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormInitStock()
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
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            cbxInvenCode.Enabled = !cbxInvenCode.Enabled;
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            txtLossQuantity.ReadOnly = !txtLossMoney.ReadOnly;
            txtAvePrice.ReadOnly = !txtAvePrice.ReadOnly;
            txtLossMoney.ReadOnly = !txtLossMoney.ReadOnly;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            //窗体控件状态切换
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtLossQuantity.Text = "";
            txtAvePrice.Text = "";
            txtSTMoney.Text = "";
            txtLossMoney.Text = "";
        }

        /// <summary>
        ///   计算库存金额
        /// </summary>
        private void ComputeMoney()
        {
            int int_Quantity;
            decimal dec_AvePrice;

            if (!String.IsNullOrEmpty(txtQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtAvePrice.Text.Trim()))
            {
                int_Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                dec_AvePrice = Convert.ToDecimal(txtAvePrice.Text.Trim());
                txtSTMoney.Text = Decimal.Round(int_Quantity*dec_AvePrice, 2).ToString();
            }
        }

        /// <summary>
        ///   设置控件的显示值
        /// </summary>
        private void FillControls()
        {
            cbxStoreCode.SelectedValue = dgvStockInfo[0, dgvStockInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value;
            txtQuantity.Text = dgvStockInfo[2, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            txtLossQuantity.Text = dgvStockInfo[3, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            txtAvePrice.Text = dgvStockInfo[4, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            txtSTMoney.Text = dgvStockInfo[5, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            txtLossMoney.Text = dgvStockInfo[6, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM STStock" + strWhere;
            ;

            try
            {
                dgvStockInfo.DataSource = db.GetDataSet(strSql, "STStock").Tables["STStock"];
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

            if (cbxStoreCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@StoreCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@StoreCode", cbxStoreCode.SelectedValue.ToString());
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

            if (String.IsNullOrEmpty(txtLossQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@LossQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@LossQuantity", Convert.ToInt32(txtLossQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtAvePrice.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@AvePrice", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@AvePrice", Convert.ToDecimal(txtAvePrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtSTMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@STMoney", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@STMoney", Convert.ToDecimal(txtSTMoney.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtLossMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@LossMoney", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@LossMoney", Convert.ToDecimal(txtLossMoney.Text.Trim()));
            }
        }

        private void FormInitStock_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //ComboBox绑定到数据源
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvStockInfo.Columns[0], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvStockInfo.Columns[1], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            BindDataGridView("");
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加操作
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改操作
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            BindDataGridView("");
        }

        private void dgvStoreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                if (dgvStockInfo.RowCount > 0)
                {
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

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void txtLossQuantity_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void txtAvePrice_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;
            SqlDataReader sdr = null;
            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码

            if (cbxStoreCode.SelectedIndex == -1)
            {
                MessageBox.Show("请选择仓库！", "软件提示");
                cbxStoreCode.Focus();
                return;
            }

            if (cbxInvenCode.SelectedIndex == -1)
            {
                MessageBox.Show("请选择存货！", "软件提示");
                cbxInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("库存数量不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtAvePrice.Text.Trim()))
            {
                MessageBox.Show("成本价不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtLossQuantity.Text.Trim()))
            {
                MessageBox.Show("损失数量不许为空！", "软件提示");
                txtLossQuantity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtLossMoney.Text.Trim()))
            {
                MessageBox.Show("损失金额不许为空！", "软件提示");
                txtLossMoney.Focus();
                return;
            }

            //添加操作
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                strStoreCode = cbxStoreCode.SelectedValue.ToString(); //得到仓库代码
                strInvenCode = cbxInvenCode.SelectedValue.ToString(); //得到存货代码

                strCode = "select * from STStock where StoreCode = '" + strStoreCode + "' and InvenCode = '" +
                          strInvenCode + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();

                    if (!sdr.HasRows)
                    {
                        sdr.Close();

                        strCode =
                            "INSERT INTO STStock(StoreCode,InvenCode,Quantity,LossQuantity,AvePrice,STMoney,LossMoney) ";
                        strCode += "VALUES(@StoreCode,@InvenCode,@Quantity,@LossQuantity,@AvePrice,@STMoney,@LossMoney)";

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
                        MessageBox.Show("该存货的库存已经被初始化过！", "软件提示");
                        cbxInvenCode.Focus();
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
                string strOldStoreCode = null; //未修改之前的仓库代码
                string strOldInvenCode = null; //未修改之前的存货代码

                strOldStoreCode = dgvStockInfo[0, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
                strOldInvenCode = dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();

                strStoreCode = cbxStoreCode.SelectedValue.ToString(); //得到仓库代码
                strInvenCode = cbxInvenCode.SelectedValue.ToString(); //得到存货代码

                if (strOldStoreCode != cbxStoreCode.SelectedValue.ToString() ||
                    strOldInvenCode != cbxInvenCode.SelectedValue.ToString())
                {
                    strCode = "select * from STStock where StoreCode = '" + strStoreCode + "' and InvenCode = '" +
                              strInvenCode + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("该存货的库存已经被初始化过！", "软件提示");
                            cbxInvenCode.Focus();
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
                    strCode = "UPDATE STStock SET StoreCode = @StoreCode,InvenCode = @InvenCode,";
                    strCode += "Quantity = @Quantity,LossQuantity = @LossQuantity,AvePrice = @AvePrice,";
                    strCode += "STMoney = @STMoney,LossMoney = @LossMoney ";
                    strCode += "WHERE StoreCode = '" + strOldStoreCode + "' AND InvenCode = '" + strOldInvenCode + "'";

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

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码
            string strSql = null;

            if (dgvStockInfo.RowCount == 0)
            {
                return;
            }

            strStoreCode = dgvStockInfo[0, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value.ToString();
            strSql = "DELETE FROM STStock WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode +
                     "'";

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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtAvePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }
    }
}