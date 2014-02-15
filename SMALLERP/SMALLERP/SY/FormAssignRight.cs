using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.SY
{   /////更多大型项目源码http://yulei133.3322.org/
    public partial class FormAssignRight : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private DataTable dt;
        private SqlDataAdapter sda;

        public FormAssignRight()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   在DataGridView控件中插入某个模块具有的操作功能及授权信息
        /// </summary>
        /// <param name="strModuleTag"> 模块标识 </param>
        private void InsertOperation(string strModuleTag)
        {
            DataGridViewRow dgvr = null;

            if (strModuleTag.Substring(0, 1) == "1" || strModuleTag == "610" || strModuleTag == "620" ||
                strModuleTag == "910")
            {
                //添
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Add";
                dgvr.Cells["IsRight"].Value = "0";
                //改
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Amend";
                dgvr.Cells["IsRight"].Value = "0";
                //删
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Delete";
                dgvr.Cells["IsRight"].Value = "0";
            }

            if (strModuleTag.Substring(0, 1) == "2" || strModuleTag.Substring(0, 1) == "3" ||
                (strModuleTag.Substring(0, 1) == "4" && strModuleTag != "450") ||
                (strModuleTag.Substring(0, 1) == "5" && strModuleTag != "530") || strModuleTag.Substring(0, 1) == "7")
            {
                //添
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Add";
                dgvr.Cells["IsRight"].Value = "0";
                //改
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Amend";
                dgvr.Cells["IsRight"].Value = "0";
                //删
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Delete";
                dgvr.Cells["IsRight"].Value = "0";
                //审
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Check";
                dgvr.Cells["IsRight"].Value = "0";
                //弃
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "UnCheck";
                dgvr.Cells["IsRight"].Value = "0";
            }

            if (strModuleTag == "450" || strModuleTag == "630" || strModuleTag.Substring(0, 1) == "8")
            {
                //查
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Query";
                dgvr.Cells["IsRight"].Value = "0";
            }

            if (strModuleTag == "530")
            {
                //审
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Check";
                dgvr.Cells["IsRight"].Value = "0";
                //弃
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "UnCheck";
                dgvr.Cells["IsRight"].Value = "0";
            }

            if (strModuleTag == "930")
            {
                //存
                dgvr = commUse.DataGridViewInsertRowAtEnd(dgvINRightInfo, bsINRight, dt);
                dgvr.Cells["OperatorCode"].Value = tvOperator.SelectedNode.Tag;
                dgvr.Cells["ModuleTag"].Value = tvModule.SelectedNode.Tag;
                dgvr.Cells["RightTag"].Value = "Save";
                dgvr.Cells["IsRight"].Value = "0";
            }
        }

        private void FormAssignRight_Load(object sender, EventArgs e)
        {
            //权限控制
            commUse.CortrolButtonEnabled(toolSave, this);
            //绑定到数据源
            commUse.BuildTree(tvOperator, imageList1, "操作员", "SYOperator Where IsAdmin <> '1'", "OperatorCode",
                              "OperatorName");
            commUse.BuildTree(tvModule, imageList1, "功能模块", "INModule", "ModuleTag", "ModuleName");
            commUse.BindComboBox(dgvINRightInfo.Columns["RightTag"], "RightTag", "RightName",
                                 "Select RightTag,RightName From INRight", "INRight");
        }

        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            commUse.DataGridViewReset(dgvINRightInfo); //清空DataGridView

            if (tvOperator.SelectedNode != null)
            {
                if (tvOperator.SelectedNode.Tag != null)
                {
                    if (tvModule.SelectedNode != null)
                    {
                        if (tvModule.SelectedNode.Tag != null)
                        {
                            string strSql = "Select OperatorCode,ModuleTag,RightTag,IsRight From SYAssignRight ";
                            strSql += "Where OperatorCode = '" + tvOperator.SelectedNode.Tag + "' and ModuleTag = '" +
                                      tvModule.SelectedNode.Tag + "'";

                            try
                            {
                                sda = new SqlDataAdapter(strSql, db.Conn);
                                SqlCommandBuilder scb = new SqlCommandBuilder(sda);

                                dt = new DataTable();
                                sda.Fill(dt);
                                bsINRight.DataSource = dt; //BindingSource绑定数据源
                                dgvINRightInfo.DataSource = bsINRight; //DataGridView控件绑定数据源

                                if (dgvINRightInfo.RowCount == 0)
                                {
                                    InsertOperation(tvModule.SelectedNode.Tag.ToString()); //插入模块的操作权限
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "软件提示");
                                throw ex;
                            }
                        }
                    }
                }
            }
        }

        private void tvOperator_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvModule_AfterSelect(sender, e);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (tvOperator.SelectedNode != null)
            {
                if (tvOperator.SelectedNode.Tag != null)
                {
                    if (tvModule.SelectedNode != null)
                    {
                        if (tvModule.SelectedNode.Tag != null)
                        {
                            try
                            {
                                dgvINRightInfo.EndEdit(); //当前单元格结束编辑
                                bsINRight.EndEdit(); //将挂起的更改应用于基础数据源。

                                sda.Update(dt); //根据多态性可知，所有DbDataAdapter的非空子类引用都可以调用“Update(DataTable dataTable)”方法
                                MessageBox.Show("保存成功！", "软件提示");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("保存失败！(" + ex.Message + ")", "软件提示");
                            }
                        }
                    }
                }
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}