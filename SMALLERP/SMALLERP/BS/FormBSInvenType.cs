using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSInvenType : Form
    {
        private CommonUse commUse = new CommonUse();

        public FormBSInvenType()
        {
            InitializeComponent();
        }

        private void FormInvenType_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(btnAdd, this);
            commUse.CortrolButtonEnabled(btnAmend, this);
            commUse.CortrolButtonEnabled(btnDelete, this);
            //TreeView绑定到数据源
            commUse.BuildTree(tvInvenType, imageList1, "存货分类", "BSInvenType", "InvenTypeCode", "InvenTypeName");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormBSInvenTypeInput formInvenTypeInput = new FormBSInvenTypeInput();
            formInvenTypeInput.Tag = "Add"; //添加操作
            formInvenTypeInput.Owner = this;
            formInvenTypeInput.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tvInvenType.SelectedNode != null)
            {
                if (tvInvenType.SelectedNode.Tag != null)
                {
                    FormBSInvenTypeInput formInvenTypeInput = new FormBSInvenTypeInput();
                    formInvenTypeInput.Tag = "Edit"; //修改操作
                    formInvenTypeInput.Owner = this;
                    formInvenTypeInput.ShowDialog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strSql = null;
            string strInvenTypeCode = null;
            DataBase db = new DataBase();

            if (tvInvenType.SelectedNode != null)
            {
                if (tvInvenType.SelectedNode.Tag != null)
                {
                    strInvenTypeCode = tvInvenType.SelectedNode.Tag.ToString();

                    //判断是否存在外键约束
                    if (commUse.IsExistConstraint("BSInvenType", strInvenTypeCode))
                    {
                        MessageBox.Show("已发生业务关系，无法删除", "软件提示");
                        return;
                    }

                    if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                    {
                        strSql = "DELETE FROM BSInvenType WHERE InvenTypeCode = '" + strInvenTypeCode + "'";

                        try
                        {
                            if (db.ExecDataBySql(strSql) > 0)
                            {
                                MessageBox.Show("删除成功！", "软件提示");
                                commUse = new CommonUse();
                                commUse.BuildTree(tvInvenType, imageList1, "存货分类", "BSInvenType", "InvenTypeCode",
                                                  "InvenTypeName");
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

        private void tvInvenType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            commUse.CortrolButtonEnabled(btnAmend, this);
            commUse.CortrolButtonEnabled(btnDelete, this);

            if (tvInvenType.SelectedNode != null)
            {
                if (tvInvenType.SelectedNode.Tag != null)
                {
                    //基础存货分类，不许修改和删除
                    if (tvInvenType.SelectedNode.Tag.ToString() == "01" ||
                        tvInvenType.SelectedNode.Tag.ToString() == "02")
                    {
                        btnAmend.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
        }
    }
}