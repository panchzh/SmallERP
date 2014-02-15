using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;
/////////更多大型项目源码http://yulei133.3322.org/
namespace SMALLERP.CU
{
    public partial class FormCURelRecord : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormCustomerCourse formCustomerCourse;

        public FormCURelRecord()
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

            db.Cmd.Parameters.AddWithValue("@RelDate", dtpRelDate.Value);

            if (cbxRelManner.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@RelManner", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@RelManner", cbxRelManner.SelectedValue.ToString());
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

            db.Cmd.Parameters.AddWithValue("@NextDate", dtpNextDate.Value);

            if (String.IsNullOrEmpty(rtbRelContent.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@RelContent", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@RelContent", rtbRelContent.Text.Trim());
            }

            if (String.IsNullOrEmpty(rtbFeeInfo.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@FeeInfo", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@FeeInfo", rtbFeeInfo.Text.Trim());
            }
        }

        private void FormCURelRecord_Load(object sender, EventArgs e)
        {
            formCustomerCourse = (FormCustomerCourse) Owner;
            commUse.BindComboBox(cbxCustomerCode, "CustomerCode", "CustomerName",
                                 "select CustomerCode,CustomerName from BSCustomer", "BSCustomer");
            commUse.BindComboBox(cbxRelManner, "Code", "Name", "select Code,Name from INRelManner", "INRelManner");
            cbxCustomerCode.SelectedValue = formCustomerCourse.tvCustomer.SelectedNode.Tag;

            //添加操作
            if (Tag.ToString() == "Add")
            {
                cbxRelManner.SelectedIndex = -1;
                dtpRelDate.Value = DateTime.Today;
                dtpNextDate.Value = DateTime.Today;
            }

            //修改操作
            if (Tag.ToString() == "Edit")
            {
                dtpRelDate.Value =
                    Convert.ToDateTime(
                        formCustomerCourse.dgvRel["RelDate", formCustomerCourse.dgvRel.CurrentRow.Index].Value);
                cbxRelManner.SelectedValue =
                    formCustomerCourse.dgvRel["RelManner", formCustomerCourse.dgvRel.CurrentRow.Index].Value;
                txtLinkman.Text =
                    formCustomerCourse.dgvRel["Linkman_Rel", formCustomerCourse.dgvRel.CurrentRow.Index].Value.ToString();
                txtTelephoneCode.Text =
                    formCustomerCourse.dgvRel["TelephoneCode_Rel", formCustomerCourse.dgvRel.CurrentRow.Index].Value.
                        ToString();
                dtpNextDate.Value =
                    Convert.ToDateTime(
                        formCustomerCourse.dgvRel["NextDate", formCustomerCourse.dgvRel.CurrentRow.Index].Value);
                rtbRelContent.Text =
                    formCustomerCourse.dgvRel["RelContent", formCustomerCourse.dgvRel.CurrentRow.Index].Value.ToString();
                rtbFeeInfo.Text =
                    formCustomerCourse.dgvRel["FeeInfo", formCustomerCourse.dgvRel.CurrentRow.Index].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intRelId;
            string strCode = null;

            if (cbxRelManner.SelectedValue == null)
            {
                MessageBox.Show("联系方式不许为空！", "软件提示");
                cbxRelManner.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtLinkman.Text.Trim()))
            {
                MessageBox.Show("联系人不许为空！", "软件提示");
                txtLinkman.Focus();
                return;
            }

            if (String.IsNullOrEmpty(rtbRelContent.Text.Trim()))
            {
                MessageBox.Show("联系内容不许为空！", "软件提示");
                rtbRelContent.Focus();
                return;
            }

            if (Tag.ToString() == "Add")
            {
                //添加参数
                ParametersAddValue();

                strCode =
                    "INSERT INTO CURelRecord(CustomerCode,RelDate,RelManner,Linkman,TelephoneCode,NextDate,RelContent,FeeInfo) ";
                strCode +=
                    "VALUES(@CustomerCode,@RelDate,@RelManner,@Linkman,@TelephoneCode,@NextDate,@RelContent,@FeeInfo)";

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
                intRelId =
                    Convert.ToInt32(formCustomerCourse.dgvRel["RelId", formCustomerCourse.dgvRel.CurrentRow.Index].Value);

                //添加参数
                ParametersAddValue();

                strCode =
                    "UPDATE CURelRecord SET CustomerCode=@CustomerCode,RelDate=@RelDate,RelManner = @RelManner,Linkman = @Linkman,TelephoneCode = @TelephoneCode,NextDate = @NextDate,RelContent = @RelContent,FeeInfo = @FeeInfo ";
                strCode += "WHERE RelId = " + intRelId;

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            formCustomerCourse.BindDataGridView(formCustomerCourse.tvCustomer.SelectedNode.Tag.ToString(), "CURelRecord",
                                                formCustomerCourse.dgvRel);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}