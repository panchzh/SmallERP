using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.PR
{
    public partial class FormPRInStore : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormPRInStore()
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
            cbxStoreCode.Enabled = !cbxStoreCode.Enabled;
            txtInQuantity.ReadOnly = !txtInQuantity.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtPRInCode.Text = "";
            dtpPRInDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            txtPRProduceCode.Text = "";
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtPRQuantity.Text = "";
            txtInQuantity.Text = "";
            cbxEmployeeCode.SelectedIndex = -1;
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
            txtPRInCode.Text = dgvPRInStoreInfo["PRInCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            dtpPRInDate.Value =
                Convert.ToDateTime(dgvPRInStoreInfo["PRInDate", dgvPRInStoreInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue =
                dgvPRInStoreInfo["OperatorCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value;
            txtPRProduceCode.Text =
                dgvPRInStoreInfo["PRProduceCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            cbxStoreCode.SelectedValue = dgvPRInStoreInfo["StoreCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue = dgvPRInStoreInfo["InvenCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value;
            txtPRQuantity.Text = dgvPRInStoreInfo["PRQuantity", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            txtInQuantity.Text = dgvPRInStoreInfo["InQuantity", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue =
                dgvPRInStoreInfo["EmployeeCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvPRInStoreInfo["IsFlag", dgvPRInStoreInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM PRInStore " + strWhere;
            ;

            try
            {
                dgvPRInStoreInfo.DataSource = db.GetDataSet(strSql, "PRInStore").Tables["PRInStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        /// <summary>
        ///   计算产品的成本
        /// </summary>
        /// <param name="strPRProduceCode"> 生产单编号 </param>
        /// <returns> 产品的成本 </returns>
        private decimal ComputeMaterialCost(string strPRProduceCode)
        {
            string strSql = null;
            DataTable dt = null;
            decimal decAvePrice;
            decimal decMaterialCost = 0;

            strSql = "Select InvenCode,UseQuantity From PRProduceItem Where PRProduceCode = '" + strPRProduceCode + "'";

            try
            {
                dt = db.GetDataTable(strSql, "PRProduceItem");

                foreach (DataRow dr in dt.Rows)
                {
                    decAvePrice = commUse.GetAvePriceBySTGetMaterial(strPRProduceCode, dr["InvenCode"].ToString());
                    decMaterialCost += (decAvePrice*Convert.ToInt32(dr["UseQuantity"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

            return decMaterialCost;
        }

        /// <summary>
        ///   设置参数值
        /// </summary>
        private void ParametersAddValue()
        {
            db.Cmd.Parameters.Clear();
            db.Cmd.Parameters.AddWithValue("@PRInCode", txtPRInCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@PRInDate", dtpPRInDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                //把null对象化为DBNull
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", cbxOperatorCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@PRProduceCode", txtPRProduceCode.Text.Trim());

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

            if (String.IsNullOrEmpty(txtPRQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@PRQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@PRQuantity", Convert.ToInt32(txtPRQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtInQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@InQuantity", 0);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@InQuantity", Convert.ToInt32(txtInQuantity.Text.Trim()));
            }

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            if (cbxIsFlag.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@IsFlag", cbxIsFlag.SelectedValue.ToString());
            }
        }

        private void FormPRInStore_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(cbxStoreCode, "StoreCode", "StoreName", "select StoreCode,StoreName from BSStore",
                                 "BSStore");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(cbxIsFlag, "Code", "Name", "select * from INCheckFlag", "INCheckFlag");

            //DataGridViewComboBoxColumn绑定到数据源
            commUse.BindComboBox(dgvPRInStoreInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvPRInStoreInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvPRInStoreInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvPRInStoreInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvPRInStoreInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");

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
            toolStrip1.Tag = "ADD"; //添加标识

            dtpPRInDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            cbxIsFlag.SelectedValue = "0";

            txtPRInCode.Text = commUse.BuildBillCode("PRInStore", "PRInCode", "PRInDate", dtpPRInDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标识
        }

        private void dgvPRInStoreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvPRInStoreInfo.RowCount > 0)
            {
                if (dgvPRInStoreInfo["IsFlag", dgvPRInStoreInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void txtInQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            FormBrowsePRProduce formBrowsePRProduce = new FormBrowsePRProduce();
            formBrowsePRProduce.Owner = this;
            formBrowsePRProduce.ShowDialog();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtPRInCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtPRInCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPRProduceCode.Text.Trim()))
            {
                MessageBox.Show("生产单号不许为空！", "软件提示");
                txtPRProduceCode.Focus();
                return;
            }

            if (cbxStoreCode.SelectedValue == null)
            {
                MessageBox.Show("仓库不许为空！", "软件提示");
                cbxStoreCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtInQuantity.Text.Trim()))
            {
                MessageBox.Show("入库数量不许为空！", "软件提示");
                txtInQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtInQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("入库数量不能等于零", "软件提示");
                    txtInQuantity.Focus();
                    return;
                }

                if (Convert.ToInt32(txtInQuantity.Text.Trim()) > Convert.ToInt32(txtPRQuantity.Text.Trim()))
                {
                    MessageBox.Show("入库数量不许大于生产数量", "软件提示");
                    txtInQuantity.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO PRInStore(PRInCode,PRInDate,OperatorCode,PRProduceCode,StoreCode,InvenCode,PRQuantity,InQuantity,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@PRInCode,@PRInDate,@OperatorCode,@PRProduceCode,@StoreCode,@InvenCode,@PRQuantity,@InQuantity,@EmployeeCode,@IsFlag)";

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
                string strPRInCode = txtPRInCode.Text.Trim();

                //更新数据库
                try
                {
                    strCode = "UPDATE PRInStore SET PRProduceCode = @PRProduceCode,StoreCode = @StoreCode,";
                    strCode += "InvenCode = @InvenCode,PRQuantity = @PRQuantity,InQuantity = @InQuantity,";
                    strCode += "EmployeeCode = @EmployeeCode ";
                    strCode += "WHERE PRInCode = '" + strPRInCode + "'";

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
            string strPRInCode = null; //单据编号
            string strSql = null;
            string strFlag = null;

            if (dgvPRInStoreInfo.RowCount <= 0)
            {
                return;
            }

            strPRInCode = dgvPRInStoreInfo["PRInCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvPRInStoreInfo["IsFlag", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM PRInStore WHERE PRInCode = '" + strPRInCode + "'";

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
            List<string> strSqls = new List<string>();
            DataTable dt = null;
            string strCode = null;
            string strPRInCode = null; //单据编码 
            string strPRProduceCode = null; //生产单号
            string strIsFlag = null; //审核标记

            string strPRInStoreSql = null; //表示提交PRInStore表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //产品代码

            int intInQuantity; //入库数量
            int intQuantity; //产品的库存数量
            decimal decPrice; //库存单价 
            decimal decMoney; //库存金额
            decimal decMaterialCost; //产品的原材料成本

            if (dgvPRInStoreInfo.RowCount <= 0)
            {
                return;
            }

            strStoreCode = dgvPRInStoreInfo["StoreCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvPRInStoreInfo["InvenCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strPRInCode = dgvPRInStoreInfo["PRInCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvPRInStoreInfo["IsFlag", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            intInQuantity = Convert.ToInt32(dgvPRInStoreInfo["InQuantity", dgvPRInStoreInfo.CurrentCell.RowIndex].Value);
            strPRProduceCode = dgvPRInStoreInfo["PRProduceCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                dt = db.GetDataTable(strCode, "STStock");

                if (dt.Rows.Count > 0)
                {
                    //计算生产产品所使用原材料的成本
                    decMaterialCost = ComputeMaterialCost(strPRProduceCode);
                    //计算库存所需要的数据
                    intQuantity = intInQuantity + Convert.ToInt32(dt.Rows[0]["Quantity"]); //库存数量
                    decMoney = decMaterialCost + Convert.ToDecimal(dt.Rows[0]["STMoney"]); //库存金额
                    decPrice = Decimal.Round(decMoney/intQuantity, 2); //库存单价

                    strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",AvePrice = " + decPrice +
                                    ",STMoney = " + decMoney + " ";
                    strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                }
                else
                {
                    //计算生产产品所使用原材料的成本
                    decMaterialCost = ComputeMaterialCost(strPRProduceCode);
                    //计算库存所需要的数据
                    intQuantity = intInQuantity;
                    decMoney = decMaterialCost;
                    decPrice = Decimal.Round(decMoney/intQuantity, 2); //平均价格
                    strSTStockSql = "INSERT INTO STStock(StoreCode,InvenCode,Quantity,AvePrice,STMoney) ";
                    strSTStockSql += "VALUES('" + strStoreCode + "','" + strInvenCode + "'," + intQuantity + "," +
                                     decPrice + "," + decMoney + ")";
                }

                strPRInStoreSql = "UPDATE PRInStore SET IsFlag = '1' WHERE PRInCode = '" + strPRInCode + "'";

                strSqls.Add(strSTStockSql);
                strSqls.Add(strPRInStoreSql);

                if (db.ExecDataBySqls(strSqls))
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
            List<string> strSqls = new List<string>();
            DataTable dt = null;
            string strCode = null;
            string strPRInCode = null; //单据的编号
            string strIsFlag = null; //审核标记
            string strPRProduceCode = null; //生产单号

            string strPRInStoreSql = null; //表示提交PRInStore表的SQL语
            string strSTStockSql = null; //表示提交STStock表的SQL语

            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //产品代码

            int intQuantity; //产品的库存数量
            int intInQuantity; //入库数量
            decimal decPrice; //库存单价
            decimal decMoney; //库存金额
            decimal decMaterialCost; //产品的原材料成本

            if (dgvPRInStoreInfo.RowCount <= 0)
            {
                return;
            }

            strStoreCode = dgvPRInStoreInfo["StoreCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvPRInStoreInfo["InvenCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strPRInCode = dgvPRInStoreInfo["PRInCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvPRInStoreInfo["IsFlag", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();
            intInQuantity = Convert.ToInt32(dgvPRInStoreInfo["InQuantity", dgvPRInStoreInfo.CurrentCell.RowIndex].Value);
            strPRProduceCode = dgvPRInStoreInfo["PRProduceCode", dgvPRInStoreInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                dt = db.GetDataTable(strCode, "STStock");

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["Quantity"]) < intInQuantity)
                    {
                        MessageBox.Show("该笔入库的产品，已经发生了相关业务，无法弃审！", "软件提示");
                        return;
                    }

                    //计算产品的原材料直接成本
                    decMaterialCost = ComputeMaterialCost(strPRProduceCode);
                    //计算库存所需要的数据
                    intQuantity = Convert.ToInt32(dt.Rows[0]["Quantity"]) - intInQuantity;
                    decMoney = Convert.ToDecimal(dt.Rows[0]["STMoney"]) - decMaterialCost;

                    //计算单价
                    if (intQuantity == 0)
                    {
                        decPrice = 0;
                        decMoney = 0;
                    }
                    else
                    {
                        decPrice = Decimal.Round(decMoney/intQuantity, 2); //平均价格
                    }

                    strSTStockSql = "UPDATE STStock SET Quantity = " + intQuantity + ",AvePrice = " + decPrice +
                                    ",STMoney = " + decMoney + " ";
                    strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                }
                else
                {
                    MessageBox.Show("库存数据异常，无法处理！", "软件提示");
                    return;
                }

                strPRInStoreSql = "UPDATE PRInStore SET IsFlag = '0' WHERE PRInCode = '" + strPRInCode + "'";

                strSqls.Add(strSTStockSql);
                strSqls.Add(strPRInStoreSql);

                if (db.ExecDataBySqls(strSqls))
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

                    strWhere = " WHERE PRInCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE SUBSTRING(CONVERT(VARCHAR(20),PRInDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvPRInStoreInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}