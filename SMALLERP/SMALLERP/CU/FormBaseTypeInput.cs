using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{
    public partial class FormBaseTypeInput : Form
    {
        private readonly DataBase db = new DataBase();
        private CommonUse commUse = new CommonUse();
        private FormBaseType formBaseType;

        public FormBaseTypeInput()
        {
            InitializeComponent();
        }

        private void FormBaseTypeInput_Load(object sender, EventArgs e)
        {
            formBaseType = (FormBaseType) Owner;
            Text = formBaseType.tvBaseType.SelectedNode.Text + "编辑";

            //在修改操作下打开formCUGradeInput窗体
            if (Tag.ToString() == "Edit")
            {
                txtCode.Text =
                    formBaseType.dgvBaseTypeInfo[0, formBaseType.dgvBaseTypeInfo.CurrentCell.RowIndex].Value.ToString();
                txtName.Text =
                    formBaseType.dgvBaseTypeInfo[1, formBaseType.dgvBaseTypeInfo.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strSql = null;
            string strOldCode = null;
            SqlDataReader sdr = null;
            string strTable = null; //用于表示数据表的名称
            string strCodeColumn = null; //用于表示代码列
            string strNameColumn = null; //用于表示名称列

            errorInfo.Clear();

            if (String.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                errorInfo.SetError(txtCode, "类别编码不许为空！");
                return;
            }

            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorInfo.SetError(txtName, "类别名称不许为空！");
                return;
            }

            strTable = formBaseType.tvBaseType.SelectedNode.Tag.ToString();
            strCodeColumn = formBaseType.dgvBaseTypeInfo.Columns[0].Name;
            strNameColumn = formBaseType.dgvBaseTypeInfo.Columns[1].Name;

            if (Tag.ToString() == "Add") //添加操作
            {
                strSql = "select * from " + strTable + " where " + strCodeColumn + " = '" + txtCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strSql);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();
                        strSql = "INSERT INTO " + strTable + "(" + strCodeColumn + "," + strNameColumn + ") VALUES('" +
                                 txtCode.Text.Trim() + "','" + txtName.Text.Trim() + "')";

                        if (db.ExecDataBySql(strSql) > 0)
                        {
                            MessageBox.Show("保存成功！", "软件提示");
                            formBaseType.BindDataGridView(strTable, strCodeColumn, strNameColumn);
                            btnQuit_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("保存失败！", "软件提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("编码重复，请重新设置", "软件提示");
                        txtCode.Focus();
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
            }
            else //修改操作
            {
                //未修改之前的代码
                strOldCode =
                    formBaseType.dgvBaseTypeInfo[0, formBaseType.dgvBaseTypeInfo.CurrentCell.RowIndex].Value.ToString();

                //代码被修改过
                if (strOldCode != txtCode.Text.Trim())
                {
                    strSql = "select * from " + strTable + " where " + strCodeColumn + " = '" + txtCode.Text.Trim() +
                             "'";

                    try
                    {
                        sdr = db.GetDataReader(strSql);
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtCode.Focus();
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
                }

                //更新数据库
                try
                {
                    strSql = "UPDATE " + strTable + " SET " + strCodeColumn + " = '" + txtCode.Text.Trim() + "'," +
                             strNameColumn + " = '" + txtName.Text.Trim() + "' WHERE " + strCodeColumn + " = '" +
                             strOldCode + "'";

                    if (db.ExecDataBySql(strSql) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        formBaseType.BindDataGridView(strTable, strCodeColumn, strNameColumn);
                        btnQuit_Click(sender, e);
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
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}