using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSCostTypeInput : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormBSCostType formCostType;

        public FormBSCostTypeInput()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCostTypeInput_Load(object sender, EventArgs e)
        {
            formCostType = (FormBSCostType) Owner;

            //在修改操作下打开FormBSCostTypeInput窗体
            if (Tag.ToString() != "Add")
            {
                txtTypeCode.Text = formCostType.tvCostType.SelectedNode.Tag.ToString();
                txtTypeName.Text = formCostType.tvCostType.SelectedNode.Text;

                //判断是否存在外键约束
                if (commUse.IsExistConstraint("BSCostType", formCostType.tvCostType.SelectedNode.Tag.ToString()))
                {
                    txtTypeCode.Enabled = false;
                }
                else
                {
                    txtTypeCode.Enabled = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strCode = null;
            SqlDataReader sdr = null;
            CommonUse commUse = null;

            errorInfo.Clear();

            if (String.IsNullOrEmpty(txtTypeCode.Text.Trim()))
            {
                errorInfo.SetError(txtTypeCode, "类别编码不许为空！");
                return;
            }

            if (String.IsNullOrEmpty(txtTypeName.Text.Trim()))
            {
                errorInfo.SetError(txtTypeName, "类别名称不许为空！");
                return;
            }

            if (Tag.ToString() == "Add") //添加操作
            {
                strCode = "select * from BSCostType where CostTypeCode = '" + txtTypeCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();

                    if (!sdr.HasRows)
                    {
                        sdr.Close();
                        strCode = "INSERT INTO BSCostType(CostTypeCode,CostTypeName) VALUES('" + txtTypeCode.Text.Trim() +
                                  "','" + txtTypeName.Text.Trim() + "')";

                        if (db.ExecDataBySql(strCode) > 0)
                        {
                            MessageBox.Show("保存成功！", "软件提示");
                            commUse = new CommonUse();
                            commUse.BuildTree(formCostType.tvCostType, formCostType.imageList1, "费用分类", "BSCostType",
                                              "CostTypeCode", "CostTypeName");
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
                        txtTypeCode.Focus();
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
                //类别代码被修改过
                if (formCostType.tvCostType.SelectedNode.Tag.ToString() != txtTypeCode.Text.Trim())
                {
                    strCode = "select * from BSCostType where CostTypeCode = '" + txtTypeCode.Text.Trim() + "'";

                    try
                    {
                        sdr = db.GetDataReader(strCode);
                        sdr.Read();

                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码重复，请重新设置", "软件提示");
                            txtTypeCode.Focus();
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
                    strCode = "UPDATE BSCostType SET CostTypeCode = '" + txtTypeCode.Text.Trim() + "',CostTypeName = '" +
                              txtTypeName.Text.Trim() + "' WHERE CostTypeCode = '" +
                              formCostType.tvCostType.SelectedNode.Tag + "'";
                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        commUse = new CommonUse();
                        commUse.BuildTree(formCostType.tvCostType, formCostType.imageList1, "费用分类", "BSCostType",
                                          "CostTypeCode", "CostTypeName");
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
    }
}