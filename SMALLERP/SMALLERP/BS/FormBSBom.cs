using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSBom : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBSBom()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件绑定数据源
        /// </summary>
        /// <param name="strInvenCode"> 母件代码 </param>
        private void BindDataGridView(string strInvenCode)
        {
            string strSql = null;

            strSql = "SELECT BSBom.MatInvenCode,BSInven.InvenName,BSInven.SpecsModel,BSInven.MeaUnit,BSBom.Quantity ";
            strSql += "FROM BSBom,BSInven ";
            strSql += "WHERE BSBom.MatInvenCode = BSInven.InvenCode and BSBom.ProInvenCode = '" + strInvenCode + "'";

            try
            {
                dgvStructInfo.DataSource = db.GetDataSet(strSql, "InvenBom").Tables["InvenBom"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBom_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);

            //TreeView绑定到数据源
            commUse.BuildTree(tvInven, imageList1, "母件", "V_BomStruct", "InvenCode", "InvenName");
        }

        private void tvInven_AfterSelect(object sender, TreeViewEventArgs e)
        {
            commUse.DataGridViewReset(dgvStructInfo); //清空DataGridView

            if (tvInven.SelectedNode != null)
            {
                if (tvInven.SelectedNode.Tag != null)
                {
                    BindDataGridView(tvInven.SelectedNode.Tag.ToString());
                }
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (tvInven.SelectedNode != null)
            {
                FormBSBomInput formBomInput = new FormBSBomInput();
                formBomInput.Tag = "Add"; //添加状态
                formBomInput.Owner = this;
                formBomInput.ShowDialog();
            }
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            if (tvInven.SelectedNode != null)
            {
                if (tvInven.SelectedNode.Tag != null)
                {
                    FormBSBomInput formBomInput = new FormBSBomInput();
                    formBomInput.Tag = "Edit"; //修改状态
                    formBomInput.Owner = this;
                    formBomInput.ShowDialog();
                }
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            string strProInvenCode = null; //母件代码
            string strMatInvenCode = null; //子件代码
            string strSql = null;

            if (dgvStructInfo.Rows.Count > 0 && tvInven.SelectedNode != null)
            {
                strProInvenCode = tvInven.SelectedNode.Tag.ToString();
                strMatInvenCode = dgvStructInfo[0, dgvStructInfo.CurrentRow.Index].Value.ToString();

                strSql = "DELETE FROM BSBom WHERE ProInvenCode = '" + strProInvenCode + "' AND  MatInvenCode = '" +
                         strMatInvenCode + "'";

                if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                    DialogResult.Yes)
                {
                    try
                    {
                        if (db.ExecDataBySql(strSql) > 0)
                        {
                            MessageBox.Show("删除成功！", "软件提示");
                            dgvStructInfo.Rows.RemoveAt(dgvStructInfo.CurrentRow.Index);
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

                    if (dgvStructInfo.Rows.Count > 0)
                    {
                        BindDataGridView(tvInven.SelectedNode.Tag.ToString());
                    }
                    else
                    {
                        commUse.BuildTree(tvInven, imageList1, "母件", "V_BomStruct", "InvenCode", "InvenName");
                        tvInven.SelectedNode = tvInven.Nodes[0];
                    }
                }
            }
        }

        private void toolreflush_Click(object sender, EventArgs e)
        {
            commUse.BuildTree(tvInven, imageList1, "母件", "V_BomStruct", "InvenCode", "InvenName");
            tvInven.SelectedNode = tvInven.Nodes[0]; //选中根节点
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}