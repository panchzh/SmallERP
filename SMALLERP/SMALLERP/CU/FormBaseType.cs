using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{  //////更多大型项目源码http://yulei133.3322.org/
    public partial class FormBaseType : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        public FormBaseType()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   DataGridView控件动态添加列并绑定到数据源
        /// </summary>
        /// <param name="strTable"> 数据表的名称 </param>
        /// <param name="strCodeColumn"> 代码列 </param>
        /// <param name="strNameColumn"> 名称列 </param>
        public void BindDataGridView(string strTable, string strCodeColumn, string strNameColumn)
        {
            //清除现有列
            dgvBaseTypeInfo.Columns.Clear();
            //添加代码列
            dgvBaseTypeInfo.Columns.Add(strCodeColumn, tvBaseType.SelectedNode.Text + "代码");
            dgvBaseTypeInfo.Columns[strCodeColumn].DataPropertyName = strCodeColumn;
            dgvBaseTypeInfo.Columns[strCodeColumn].ReadOnly = true;
            //添加名称列
            dgvBaseTypeInfo.Columns.Add(strNameColumn, tvBaseType.SelectedNode.Text + "名称");
            dgvBaseTypeInfo.Columns[strNameColumn].DataPropertyName = strNameColumn;
            dgvBaseTypeInfo.Columns[strNameColumn].ReadOnly = true;
            //绑定数据
            string strSql = "Select " + strCodeColumn + "," + strNameColumn + " From " + strTable;

            try
            {
                dgvBaseTypeInfo.DataSource = db.GetDataSet(strSql, strTable).Tables[strTable];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void FormBaseType_Load(object sender, EventArgs e)
        {
            ////权限
            commUse.CortrolButtonEnabled(toolAdd, this);
            commUse.CortrolButtonEnabled(toolAmend, this);
            commUse.CortrolButtonEnabled(toolDelete, this);
            //TreeView绑定到数据源
            commUse.BuildTree(tvBaseType, imageList1, "基础分类", "INBaseType", "Code", "Name");
        }

        private void tvBaseType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgvBaseTypeInfo.Columns.Clear();

            if (tvBaseType.SelectedNode.Tag != null)
            {
                switch (tvBaseType.SelectedNode.Tag.ToString())
                {
                    case "CUGrade":

                        BindDataGridView("CUGrade", "GradeCode", "GradeName");
                        break;

                    case "CUCredit":

                        BindDataGridView("CUCredit", "CreditCode", "CreditName");
                        break;

                    case "CUState":

                        BindDataGridView("CUState", "StateCode", "StateName");
                        break;

                    case "CUTrade":

                        BindDataGridView("CUTrade", "TradeCode", "TradeName");
                        break;

                    case "CUChance":

                        BindDataGridView("CUChance", "ChanceCode", "ChanceName");
                        break;
                    default:

                        break;
                }
            }
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (tvBaseType.SelectedNode != null)
            {
                if (tvBaseType.SelectedNode.Tag.ToString() != "00")
                {
                    FormBaseTypeInput formBaseTypeInput = new FormBaseTypeInput();
                    formBaseTypeInput.Tag = "Add"; //添加操作
                    formBaseTypeInput.Owner = this;
                    formBaseTypeInput.ShowDialog();
                }
            }
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            if (tvBaseType.SelectedNode != null)
            {
                if (tvBaseType.SelectedNode.Tag.ToString() != "00")
                {
                    if (dgvBaseTypeInfo.RowCount > 0)
                    {
                        FormBaseTypeInput formBaseTypeInput = new FormBaseTypeInput();
                        formBaseTypeInput.Tag = "Edit"; //修改操作
                        formBaseTypeInput.Owner = this;
                        formBaseTypeInput.ShowDialog();
                    }
                }
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgvBaseTypeInfo.RowCount > 0)
            {
                string strCode = null;
                string strSql = null;
                string strCodeColumn = null; //用于表示代码列
                string strNameColumn = null; //用于表示名称列
                string strTable = null; //用户表示数据表名称

                strTable = tvBaseType.SelectedNode.Tag.ToString();
                strCodeColumn = dgvBaseTypeInfo.Columns[0].Name;
                strNameColumn = dgvBaseTypeInfo.Columns[1].Name;
                strCode = dgvBaseTypeInfo[strCodeColumn, dgvBaseTypeInfo.CurrentCell.RowIndex].Value.ToString();
                strSql = "DELETE FROM " + strTable + " WHERE " + strCodeColumn + " = '" + strCode + "'";

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
                }

                BindDataGridView(strTable, strCodeColumn, strNameColumn);
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}