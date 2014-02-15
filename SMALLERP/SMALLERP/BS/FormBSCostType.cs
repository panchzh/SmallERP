using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSCostType : Form
    {
        private CommonUse commUse = new CommonUse();

        public FormBSCostType()
        {
            InitializeComponent();
        }

        private void FormCostType_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnAdd, this);
            commUse.CortrolButtonEnabled(btnAmend, this);
            commUse.CortrolButtonEnabled(btnDelete, this);
            //TreeView绑定到数据源
            commUse.BuildTree(tvCostType, imageList1, "费用类别", "BSCostType", "CostTypeCode", "CostTypeName");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormBSCostTypeInput formCostTypeInput = new FormBSCostTypeInput();
            formCostTypeInput.Tag = "Add"; //添加状态
            formCostTypeInput.Owner = this;
            formCostTypeInput.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tvCostType.SelectedNode != null)
            {
                if (tvCostType.SelectedNode.Tag != null)
                {
                    FormBSCostTypeInput formCostTypeInput = new FormBSCostTypeInput();
                    formCostTypeInput.Tag = "Edit"; //编辑状态
                    formCostTypeInput.Owner = this;
                    formCostTypeInput.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = null;
            string strCostTypeCode = null;
            DataBase db = new DataBase();

            if (tvCostType.SelectedNode != null)
            {
                if (tvCostType.SelectedNode.Tag != null)
                {
                    strCostTypeCode = tvCostType.SelectedNode.Tag.ToString();

                    if (commUse.IsExistConstraint("BSCostType", strCostTypeCode))
                    {
                        MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                        return;
                    }

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        strSql = "DELETE FROM BSCostType WHERE CostTypeCode = '" + strCostTypeCode + "'";

                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                                commUse = new CommonUse();
                                commUse.BuildTree(tvCostType, imageList1, "费用类别", "BSCostType", "CostTypeCode",
                                                  "CostTypeName");
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

        private void tvCostType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            commUse.CortrolButtonEnabled(btnAmend, this);
            commUse.CortrolButtonEnabled(btnDelete, this);

            if (tvCostType.SelectedNode != null)
            {
                if (tvCostType.SelectedNode.Tag != null)
                {
                    //基础费用类型，禁止修改和删除
                    if (tvCostType.SelectedNode.Tag.ToString() == "01" || tvCostType.SelectedNode.Tag.ToString() == "02")
                    {
                        btnAmend.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
        }
    }
}