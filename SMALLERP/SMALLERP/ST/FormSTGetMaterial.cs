using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.ST
{
    public partial class FormSTGetMaterial : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormSTGetMaterial()
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
            txtQuantity.ReadOnly = !txtQuantity.ReadOnly;
            cbxEmployeeCode.Enabled = !cbxEmployeeCode.Enabled;
        }

        /// <summary>
        ///   将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtSTGetCode.Text = "";
            dtpSTGetDate.Value = Convert.ToDateTime("1900-01-01");
            cbxOperatorCode.SelectedIndex = -1;
            txtPRProduceCode.Text = "";
            cbxStoreCode.SelectedIndex = -1;
            cbxInvenCode.SelectedIndex = -1;
            txtQuantity.Text = "";
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
            txtSTGetCode.Text =
                dgvSTGetMaterialInfo["STGetCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            dtpSTGetDate.Value =
                Convert.ToDateTime(dgvSTGetMaterialInfo["STGetDate", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value);
            cbxOperatorCode.SelectedValue =
                dgvSTGetMaterialInfo["OperatorCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value;
            txtPRProduceCode.Text =
                dgvSTGetMaterialInfo["PRProduceCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            cbxStoreCode.SelectedValue =
                dgvSTGetMaterialInfo["StoreCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value;
            cbxInvenCode.SelectedValue =
                dgvSTGetMaterialInfo["InvenCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value;
            txtQuantity.Text =
                dgvSTGetMaterialInfo["Quantity", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            cbxEmployeeCode.SelectedValue =
                dgvSTGetMaterialInfo["EmployeeCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value;
            cbxIsFlag.SelectedValue = dgvSTGetMaterialInfo["IsFlag", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value;
        }

        /// <summary>
        ///   DataGridView控件绑定到数据源
        /// </summary>
        /// <param name="strWhere"> Where条件子句 </param>
        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "SELECT * ";
            strSql += "FROM STGetMaterial " + strWhere;
            ;

            try
            {
                dgvSTGetMaterialInfo.DataSource = db.GetDataSet(strSql, "STGetMaterial").Tables["STGetMaterial"];
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
            db.Cmd.Parameters.AddWithValue("@STGetCode", txtSTGetCode.Text.Trim());
            db.Cmd.Parameters.AddWithValue("@STGetDate", dtpSTGetDate.Value);

            if (cbxOperatorCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@OperatorCode", DBNull.Value);
            }
            else
            {
                //把null对象化为DBNull
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

            db.Cmd.Parameters.AddWithValue("@BillType", "1"); //领料单

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

        private void FormSTGetMaterial_Load(object sender, EventArgs e)
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
            commUse.BindComboBox(dgvSTGetMaterialInfo.Columns["OperatorCode"], "OperatorCode", "OperatorName",
                                 "select OperatorCode,OperatorName from SYOperator", "SYOperator");
            commUse.BindComboBox(dgvSTGetMaterialInfo.Columns["StoreCode"], "StoreCode", "StoreName",
                                 "select StoreCode,StoreName from BSStore", "BSStore");
            commUse.BindComboBox(dgvSTGetMaterialInfo.Columns["InvenCode"], "InvenCode", "InvenName",
                                 "select InvenCode,InvenName from BSInven", "BSInven");
            commUse.BindComboBox(dgvSTGetMaterialInfo.Columns["EmployeeCode"], "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            commUse.BindComboBox(dgvSTGetMaterialInfo.Columns["IsFlag"], "Code", "Name", "select * from INCheckFlag",
                                 "INCheckFlag");
            //
            BindDataGridView("Where BillType = '1'");
            BindToolStripComboBox();
            cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "ADD"; //添加标记

            dtpSTGetDate.Value = DateTime.Today;
            cbxOperatorCode.SelectedValue = PropertyClass.OperatorCode;
            cbxIsFlag.SelectedValue = "0";

            txtSTGetCode.Text = commUse.BuildBillCode("STGetMaterial", "STGetCode", "STGetDate", dtpSTGetDate.Value);
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            ControlStatus();
            ClearControls();
            toolStrip1.Tag = "EDIT"; //修改标记
        }

        private void dgvSTGetMaterialInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "EDIT" && dgvSTGetMaterialInfo.RowCount > 0)
            {
                if (dgvSTGetMaterialInfo["IsFlag", dgvSTGetMaterialInfo.CurrentRow.Index].Value.ToString() == "1")
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

        private void btnChoice_Click(object sender, EventArgs e)
        {
            FormSTGetBrowseProduce formBrowseProduce = new FormSTGetBrowseProduce();
            formBrowseProduce.Owner = this;
            formBrowseProduce.ShowDialog();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            string strCode = null;

            if (String.IsNullOrEmpty(txtSTGetCode.Text.Trim()))
            {
                MessageBox.Show("单据编号不许为空！", "软件提示");
                txtSTGetCode.Focus();
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

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("数量不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtQuantity.Text.Trim()) == 0)
                {
                    MessageBox.Show("数量不能等于零", "软件提示");
                    txtQuantity.Focus();
                    return;
                }
            }

            //添加
            if (toolStrip1.Tag.ToString() == "ADD")
            {
                try
                {
                    strCode =
                        "INSERT INTO STGetMaterial(STGetCode,STGetDate,OperatorCode,PRProduceCode,StoreCode,InvenCode,Quantity,BillType,EmployeeCode,IsFlag) ";
                    strCode +=
                        "VALUES(@STGetCode,@STGetDate,@OperatorCode,@PRProduceCode,@StoreCode,@InvenCode,@Quantity,@BillType,@EmployeeCode,@IsFlag)";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        BindDataGridView(" Where BillType = '1'");
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

            if (toolStrip1.Tag.ToString() == "EDIT")
            {
                string strSTGetCode = txtSTGetCode.Text.Trim();
                //更新数据库
                try
                {
                    strCode =
                        "UPDATE STGetMaterial SET STGetCode = @STGetCode,STGetDate = @STGetDate,OperatorCode = @OperatorCode,PRProduceCode = @PRProduceCode,StoreCode = @StoreCode,";
                    strCode += "InvenCode = @InvenCode,Quantity = @Quantity,";
                    strCode += "EmployeeCode = @EmployeeCode,IsFlag = @IsFlag";
                    strCode += " WHERE STGetCode = '" + strSTGetCode + "'";

                    ParametersAddValue();

                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        BindDataGridView(" Where BillType = '1'");
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
            string strSTGetCode = null; //单据编号
            string strSql = null;
            string strFlag = null; //审核标记

            if (dgvSTGetMaterialInfo.RowCount <= 0)
            {
                return;
            }

            strSTGetCode = dgvSTGetMaterialInfo["STGetCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strFlag = dgvSTGetMaterialInfo["IsFlag", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();

            if (strFlag == "1")
            {
                MessageBox.Show("该单据已审核，不许删除！", "软件提示");
                return;
            }

            strSql = "DELETE FROM STGetMaterial WHERE STGetCode = '" + strSTGetCode + "'";

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

                BindDataGridView(" Where BillType = '1'");
            }
        }

        private void toolCheck_Click(object sender, EventArgs e)
        {
            List<string> strSqls = new List<string>();
            SqlDataReader sdr = null;
            string strCode = null;

            string strSTGetMaterialSql = null; //表示提交STGetMaterial表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句
            string strPRProduceItemSql = null; //表示提交PRProduceItem表的SQL语句

            string strSTGetCode = null; //单据编号
            string strPRProduceCode = null; //生产单号
            string strStoreCode = null; //仓库编号
            string strInvenCode = null; //存货编号
            string strIsFlag = null; //审核标记

            int intQuantity; //原材料的本次领用量
            decimal decUnitPrice; //单价
            decimal decMoney; //金额

            int intGetQuantity; //原材料的总计领用量
            int intStockQuantity; //库存剩余数量

            if (dgvSTGetMaterialInfo.RowCount == 0)
            {
                return;
            }

            strSTGetCode = dgvSTGetMaterialInfo["STGetCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strPRProduceCode =
                dgvSTGetMaterialInfo["PRProduceCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strStoreCode = dgvSTGetMaterialInfo["StoreCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTGetMaterialInfo["InvenCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strIsFlag = dgvSTGetMaterialInfo["IsFlag", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();

            intQuantity =
                Convert.ToInt32(dgvSTGetMaterialInfo["Quantity", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value);

            if (strIsFlag == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }

            //处理库存
            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("该存货无库存，无法审核！", "软件提示");
                    sdr.Close();
                    return;
                }

                if (sdr.GetInt32(0) < intQuantity)
                {
                    MessageBox.Show("库存不足，无法审核！", "软件提示");
                    sdr.Close();
                    return;
                }
                else
                {
                    decUnitPrice = sdr.GetDecimal(1); //获取该原材料的库存单价，作为领料单数据表中的原材料单价

                    intStockQuantity = sdr.GetInt32(0) - intQuantity; //库存剩余数量
                    decMoney = Decimal.Round(sdr.GetDecimal(1)*intStockQuantity, 2);
                }

                strSTStockSql = "UPDATE STStock SET Quantity = " + intStockQuantity + ",STMoney = " + decMoney + " ";
                strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                sdr.Close();

                //生产单的子表
                strCode = "SELECT GetQuantity FROM PRProduceItem WHERE PRProduceCode = '" + strPRProduceCode +
                          "' AND InvenCode = '" + strInvenCode + "'";
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("生产单数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                if (Convert.IsDBNull(sdr.GetValue(0)))
                {
                    intGetQuantity = 0;
                }
                else
                {
                    intGetQuantity = sdr.GetInt32(0);
                }

                intGetQuantity = intGetQuantity + intQuantity; //原材料的总计领用量
                strPRProduceItemSql = "Update PRProduceItem Set GetQuantity = " + intGetQuantity +
                                      " Where PRProduceCode = '" + strPRProduceCode + "' AND InvenCode = '" +
                                      strInvenCode + "'";
                sdr.Close();

                strSTGetMaterialSql = "UPDATE STGetMaterial SET UnitPrice = " + decUnitPrice +
                                      ",IsFlag = '1' WHERE STGetCode = '" + strSTGetCode + "'";

                strSqls.Add(strSTStockSql);
                strSqls.Add(strPRProduceItemSql);
                strSqls.Add(strSTGetMaterialSql);

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
                sdr.Close();
                throw ex;
            }

            BindDataGridView(" Where BillType = '1'");
        }

        private void toolUnCheck_Click(object sender, EventArgs e)
        {
            List<string> strSqls = new List<string>();
            SqlDataReader sdr = null;
            string strCode = null;

            string strSTGetMaterialSql = null; //表示提交STGetMaterial表的SQL语句
            string strSTStockSql = null; //表示提交STStock表的SQL语句
            string strPRProduceItemSql = null; //表示提交PRProduceItem表的SQL语句

            string strSTGetCode = null; //单据编号
            string strPRProduceCode = null; //生产单号
            string strStoreCode = null; //仓库代码
            string strInvenCode = null; //存货代码
            string strIsFlag = null; //审核标记

            int intQuantity; //领料单中的数量
            decimal decUnitPrice; //领料单中的单价

            decimal decAvePrice; //库存单价
            decimal decMoney; //金额

            int intGetQuantity; //原材料的总计领用量
            int intStockQuantity; //库存剩余数量

            if (dgvSTGetMaterialInfo.RowCount == 0)
            {
                return;
            }

            strIsFlag = dgvSTGetMaterialInfo["IsFlag", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();

            if (strIsFlag == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }

            strSTGetCode = dgvSTGetMaterialInfo["STGetCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strPRProduceCode =
                dgvSTGetMaterialInfo["PRProduceCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strStoreCode = dgvSTGetMaterialInfo["StoreCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();
            strInvenCode = dgvSTGetMaterialInfo["InvenCode", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value.ToString();

            intQuantity =
                Convert.ToInt32(dgvSTGetMaterialInfo["Quantity", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value);
            decUnitPrice =
                Convert.ToDecimal(dgvSTGetMaterialInfo["UnitPrice", dgvSTGetMaterialInfo.CurrentCell.RowIndex].Value);

            strCode = "select * from PRProduce where IsComplete = '1' and PRProduceCode = '" + strPRProduceCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (sdr.HasRows)
                {
                    MessageBox.Show("该领料单对应的生产单已经完工，无法弃审！", "软件提示");
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

            //处理库存
            strCode = "SELECT Quantity,AvePrice,STMoney FROM STStock WHERE StoreCode = '" + strStoreCode +
                      "' AND InvenCode = '" + strInvenCode + "'";

            try
            {
                sdr = db.GetDataReader(strCode);
                sdr.Read();
                if (sdr.HasRows)
                {
                    decMoney = sdr.GetDecimal(2) + decimal.Round(intQuantity*decUnitPrice, 2);
                    intStockQuantity = sdr.GetInt32(0) + intQuantity;
                    decAvePrice = Decimal.Round(decMoney/intStockQuantity, 2);

                    strSTStockSql = "UPDATE STStock SET Quantity = " + intStockQuantity + ",STMoney = " + decMoney +
                                    ",AvePrice = " + decAvePrice + " ";
                    strSTStockSql += "WHERE StoreCode = '" + strStoreCode + "' AND InvenCode = '" + strInvenCode + "'";
                    sdr.Close();
                }
                else
                {
                    MessageBox.Show("库存数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                //生产单的子表
                strCode = "SELECT GetQuantity FROM PRProduceItem WHERE PRProduceCode = '" + strPRProduceCode +
                          "' AND InvenCode = '" + strInvenCode + "'";
                sdr = db.GetDataReader(strCode);
                sdr.Read();

                if (!sdr.HasRows)
                {
                    MessageBox.Show("生产单数据异常，无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                if (sdr.GetInt32(0) < intQuantity)
                {
                    MessageBox.Show("生产单数据异常（生产单中的累计领用量小于该笔领料单的领用量），无法处理！", "软件提示");
                    sdr.Close();
                    return;
                }

                strPRProduceItemSql = "Update PRProduceItem Set GetQuantity = @GetQuantity Where PRProduceCode = '" +
                                      strPRProduceCode + "' AND InvenCode = '" + strInvenCode + "'";
                intGetQuantity = sdr.GetInt32(0) - intQuantity;
                db.Cmd.Parameters.Clear();

                if (intGetQuantity == 0)
                {
                    db.Cmd.Parameters.AddWithValue("@GetQuantity", DBNull.Value);
                }
                else
                {
                    db.Cmd.Parameters.AddWithValue("@GetQuantity", intGetQuantity);
                }
                //关闭SqlDataReader对象
                sdr.Close();
                //修改领料单表
                strSTGetMaterialSql = "UPDATE STGetMaterial SET IsFlag = '0' WHERE STGetCode = '" + strSTGetCode + "'";
                //向泛型对象中添加更新SQL语句
                strSqls.Add(strSTStockSql);
                strSqls.Add(strPRProduceItemSql);
                strSqls.Add(strSTGetMaterialSql);
                //提交执行
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
                sdr.Close();
                throw ex;
            }

            BindDataGridView("Where BillType = '1'");
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = cbxCondition.Items[cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "单据编号":

                    strWhere = " WHERE BillType = '1' AND STGetCode LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                case "单据日期":

                    strWhere = " WHERE BillType = '1' AND SUBSTRING(CONVERT(VARCHAR(20),STGetDate,20),1,10) LIKE '%" +
                               txtKeyWord.Text.Trim() + "%'";
                    BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        private void dgvSTGetMaterialInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}