using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSDepartment : Form
    {
        private CommonUse commUse = new CommonUse();

        public FormBSDepartment()
        {
            InitializeComponent();
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnAdd, this);
            commUse.CortrolButtonEnabled(btnAmend, this);
            commUse.CortrolButtonEnabled(btnDelete, this);
            commUse.BuildTree(tvDepartment, imageList1, "部门分类", "BSDepartment", "DepartmentCode", "DepartmentName");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormBSDepartmentInput formDepartmentInput = new FormBSDepartmentInput();
            formDepartmentInput.Tag = "Add"; //添加操作
            formDepartmentInput.Owner = this;
            formDepartmentInput.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tvDepartment.SelectedNode != null)
            {
                if (tvDepartment.SelectedNode.Tag != null)
                {
                    FormBSDepartmentInput formDepartmentInput = new FormBSDepartmentInput();
                    formDepartmentInput.Tag = "Edit"; //修改操作
                    formDepartmentInput.Owner = this;
                    formDepartmentInput.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = null;
            string strDepartmentCode = null;
            DataBase db = new DataBase();

            if (tvDepartment.SelectedNode != null)
            {
                if (tvDepartment.SelectedNode.Tag != null)
                {
                    strDepartmentCode = tvDepartment.SelectedNode.Tag.ToString();

                    //判断当前记录的主键值是否存在外键约束
                    if (commUse.IsExistConstraint("BSDepartment", strDepartmentCode))
                    {
                        MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                        return;
                    }

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        strSql = "DELETE FROM BSDepartment WHERE DepartmentCode = '" + strDepartmentCode + "'";

                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                                commUse = new CommonUse();
                                commUse.BuildTree(tvDepartment, imageList1, "部门分类", "BSDepartment", "DepartmentCode",
                                                  "DepartmentName");
                            }
                            else
                            {
                                MessageBox.Show("删除失败！", "软件提示");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "软件提示");
                        }
                    }
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}