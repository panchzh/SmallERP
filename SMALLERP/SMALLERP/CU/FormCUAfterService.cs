using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{
    public partial class FormCUAfterService : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormCustomerCourse formCustomerCourse;

        public FormCUAfterService()
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

            db.Cmd.Parameters.AddWithValue("@SerDate", dtpSerDate.Value);

            if (cbxEmployeeCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@EmployeeCode", cbxEmployeeCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtLinkman.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Linkman", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Linkman", txtLinkman.Text.Trim());
            }

            if (String.IsNullOrEmpty(txtTelephoneCode.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@TelephoneCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@TelephoneCode", txtTelephoneCode.Text.Trim());
            }

            if (String.IsNullOrEmpty(txtSerDays.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@SerDays", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SerDays", Convert.ToInt32(txtSerDays.Text.Trim()));
            }

            if (String.IsNullOrEmpty(rtbSerContent.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@SerContent", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@SerContent", rtbSerContent.Text.Trim());
            }

            if (String.IsNullOrEmpty(rtbResolvent.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Resolvent", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Resolvent", rtbResolvent.Text.Trim());
            }
        }

        private void FormCUAfterService_Load(object sender, EventArgs e)
        {
            formCustomerCourse = (FormCustomerCourse) Owner;
            commUse.BindComboBox(cbxCustomerCode, "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(cbxEmployeeCode, "EmployeeCode", "EmployeeName",
                                 "select EmployeeCode,EmployeeName from BSEmployee", "BSEmployee");
            cbxCustomerCode.SelectedValue = formCustomerCourse.tvCustomer.SelectedNode.Tag;

            if (Tag.ToString() == "Add") //添加操作
            {
                cbxEmployeeCode.SelectedIndex = -1;
                dtpSerDate.Value = DateTime.Today;
            }

            if (Tag.ToString() == "Edit") //修改操作
            {
                dtpSerDate.Value =
                    Convert.ToDateTime(
                        formCustomerCourse.dgvAfter["SerDate", formCustomerCourse.dgvAfter.CurrentRow.Index].Value);
                cbxEmployeeCode.SelectedValue =
                    formCustomerCourse.dgvAfter["EmployeeCode", formCustomerCourse.dgvAfter.CurrentRow.Index].Value;
                txtLinkman.Text =
                    formCustomerCourse.dgvAfter["Linkman_After", formCustomerCourse.dgvAfter.CurrentRow.Index].Value.
                        ToString();
                txtTelephoneCode.Text =
                    formCustomerCourse.dgvAfter["TelephoneCode_After", formCustomerCourse.dgvAfter.CurrentRow.Index].
                        Value.ToString();
                txtSerDays.Text =
                    formCustomerCourse.dgvAfter["SerDays", formCustomerCourse.dgvAfter.CurrentRow.Index].Value.ToString();
                rtbSerContent.Text =
                    formCustomerCourse.dgvAfter["SerContent", formCustomerCourse.dgvAfter.CurrentRow.Index].Value.
                        ToString();
                rtbResolvent.Text =
                    formCustomerCourse.dgvAfter["Resolvent", formCustomerCourse.dgvAfter.CurrentRow.Index].Value.
                        ToString();
            }
        }

        private void txtSerDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intAfterId;
            string strCode = null;

            if (cbxEmployeeCode.SelectedValue == null)
            {
                MessageBox.Show("服务人员不许为空！", "软件提示");
                cbxEmployeeCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtSerDays.Text.Trim()))
            {
                MessageBox.Show("服务天数不许为空！", "软件提示");
                txtSerDays.Focus();
                return;
            }
            else
            {
                if (Convert.ToInt32(txtSerDays.Text.Trim()) == 0)
                {
                    MessageBox.Show("服务天数不许为零！", "软件提示");
                    txtSerDays.Focus();
                    return;
                }
            }

            if (String.IsNullOrEmpty(rtbSerContent.Text.Trim()))
            {
                MessageBox.Show("服务内容不许为空！", "软件提示");
                rtbSerContent.Focus();
                return;
            }

            if (String.IsNullOrEmpty(rtbResolvent.Text.Trim()))
            {
                MessageBox.Show("解决方案不许为空！", "软件提示");
                rtbResolvent.Focus();
                return;
            }

            if (Tag.ToString() == "Add")
            {
                //添加参数
                ParametersAddValue();

                strCode =
                    "INSERT INTO CUAfterService(CustomerCode,SerDate,EmployeeCode,Linkman,TelephoneCode,SerDays,SerContent,Resolvent) ";
                strCode +=
                    "VALUES(@CustomerCode,@SerDate,@EmployeeCode,@Linkman,@TelephoneCode,@SerDays,@SerContent,@Resolvent)";

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
                //取出主键
                intAfterId =
                    Convert.ToInt32(
                        formCustomerCourse.dgvAfter["AfterId", formCustomerCourse.dgvAfter.CurrentRow.Index].Value);
                //添加参数
                ParametersAddValue();

                strCode =
                    "UPDATE CUAfterService SET CustomerCode=@CustomerCode,SerDate=@SerDate,EmployeeCode = @EmployeeCode,Linkman = @Linkman,TelephoneCode = @TelephoneCode,SerDays = @SerDays,SerContent = @SerContent,Resolvent = @Resolvent ";
                strCode += "WHERE AfterId = " + intAfterId;

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            //重新绑定数据
            formCustomerCourse.BindDataGridView(formCustomerCourse.tvCustomer.SelectedNode.Tag.ToString(),
                                                "CUAfterService", formCustomerCourse.dgvAfter);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}