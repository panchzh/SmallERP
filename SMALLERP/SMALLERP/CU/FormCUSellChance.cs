using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{
    public partial class FormCUSellChance : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormCustomerCourse formCustomerCourse;

        public FormCUSellChance()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   设置参数值
        /// </summary>
        private void ParametersAddValue()
        {
            db.Cmd.Parameters.Clear();

            if (cbxCustomerCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@CustomerCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CustomerCode", cbxCustomerCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtTheme.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Theme", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Theme", txtTheme.Text.Trim());
            }

            db.Cmd.Parameters.AddWithValue("@RegDate", dtpRegDate.Value);

            if (cbxChanceCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@ChanceCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@ChanceCode", cbxChanceCode.SelectedValue.ToString());
            }

            db.Cmd.Parameters.AddWithValue("@ForeDate", dtpForeDate.Value);

            if (cbxInvenCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@InvenCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@InvenCode", cbxInvenCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@UnitPrice", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
            }

            if (String.IsNullOrEmpty(txtCUMoney.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@CUMoney", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@CUMoney", Convert.ToDecimal(txtCUMoney.Text.Trim()));
            }

            if (String.IsNullOrEmpty(rtbRemark.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Remark", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Remark", rtbRemark.Text.Trim());
            }
        }

        /// <summary>
        ///   计算预计金额
        /// </summary>
        private void ComputeMoney()
        {
            int int_Quantity;
            decimal dec_UnitPrice;

            if (!String.IsNullOrEmpty(txtQuantity.Text.Trim()) && !String.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                int_Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                dec_UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                txtCUMoney.Text = Decimal.Round(int_Quantity*dec_UnitPrice, 2).ToString();
            }
        }

        private void FormCUSellChance_Load(object sender, EventArgs e)
        {
            formCustomerCourse = (FormCustomerCourse) Owner;
            commUse.BindComboBox(cbxCustomerCode, "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(cbxChanceCode, "ChanceCode", "ChanceName", "select ChanceCode,ChanceName from CUChance",
                                 "CUChance");
            commUse.BindComboBox(cbxInvenCode, "InvenCode", "InvenName", "select InvenCode,InvenName from BSInven",
                                 "BSInven");
            cbxCustomerCode.SelectedValue = formCustomerCourse.tvCustomer.SelectedNode.Tag;

            if (Tag.ToString() == "Add") //添加操作
            {
                cbxChanceCode.SelectedIndex = -1;
                cbxInvenCode.SelectedIndex = -1;
                dtpRegDate.Value = DateTime.Today;
                dtpForeDate.Value = DateTime.Today;
            }

            if (Tag.ToString() == "Edit") //编辑操作
            {
                txtTheme.Text =
                    formCustomerCourse.dgvSell["Theme", formCustomerCourse.dgvSell.CurrentRow.Index].Value.ToString();
                dtpRegDate.Value =
                    Convert.ToDateTime(
                        formCustomerCourse.dgvSell["RegDate", formCustomerCourse.dgvSell.CurrentRow.Index].Value);
                cbxChanceCode.SelectedValue =
                    formCustomerCourse.dgvSell["ChanceCode", formCustomerCourse.dgvSell.CurrentRow.Index].Value;
                dtpForeDate.Value =
                    Convert.ToDateTime(
                        formCustomerCourse.dgvSell["ForeDate", formCustomerCourse.dgvSell.CurrentRow.Index].Value);
                cbxInvenCode.SelectedValue =
                    formCustomerCourse.dgvSell["InvenCode", formCustomerCourse.dgvSell.CurrentRow.Index].Value;
                txtUnitPrice.Text =
                    formCustomerCourse.dgvSell["UnitPrice", formCustomerCourse.dgvSell.CurrentRow.Index].Value.ToString();
                txtQuantity.Text =
                    formCustomerCourse.dgvSell["Quantity", formCustomerCourse.dgvSell.CurrentRow.Index].Value.ToString();
                txtCUMoney.Text =
                    formCustomerCourse.dgvSell["CUMoney", formCustomerCourse.dgvSell.CurrentRow.Index].Value.ToString();
                rtbRemark.Text =
                    formCustomerCourse.dgvSell["Remark", formCustomerCourse.dgvSell.CurrentRow.Index].Value.ToString();
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputNumeric(e, sender as Control);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            ComputeMoney();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intSellId;
            string strCode = null;

            if (String.IsNullOrEmpty(txtTheme.Text.Trim()))
            {
                MessageBox.Show("标题不许为空！", "软件提示");
                txtTheme.Focus();
                return;
            }

            if (cbxChanceCode.SelectedValue == null)
            {
                MessageBox.Show("机会等级不许为空！", "软件提示");
                cbxChanceCode.Focus();
                return;
            }

            if (cbxInvenCode.SelectedIndex == -1)
            {
                MessageBox.Show("预售产品不许为空！", "软件提示");
                cbxInvenCode.Focus();
                return;
            }

            if (Tag.ToString() == "Add")
            {
                //添加参数
                ParametersAddValue();

                strCode =
                    "INSERT INTO CUSellChance(CustomerCode,Theme,RegDate,ChanceCode,ForeDate,InvenCode,UnitPrice,Quantity,CUMoney,Remark) ";
                strCode +=
                    "VALUES(@CustomerCode,@Theme,@RegDate,@ChanceCode,@ForeDate,@InvenCode,@UnitPrice,@Quantity,@CUMoney,@Remark)";

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            if (Tag.ToString() == "Edit")
            {
                intSellId =
                    Convert.ToInt32(
                        formCustomerCourse.dgvSell["SellId", formCustomerCourse.dgvSell.CurrentRow.Index].Value);

                //添加参数
                ParametersAddValue();

                strCode =
                    "UPDATE CUSellChance SET CustomerCode=@CustomerCode,Theme=@Theme,RegDate = @RegDate,ChanceCode = @ChanceCode,ForeDate = @ForeDate,InvenCode = @InvenCode,UnitPrice = @UnitPrice,Quantity = @Quantity,CUMoney = @CUMoney,Remark= @Remark ";
                strCode += " WHERE SellId = " + intSellId;

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            formCustomerCourse.BindDataGridView(formCustomerCourse.tvCustomer.SelectedNode.Tag.ToString(),
                                                "CUSellChance", formCustomerCourse.dgvSell);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}