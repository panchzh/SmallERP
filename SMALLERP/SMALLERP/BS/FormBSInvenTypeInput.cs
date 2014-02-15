using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.BS
{
    public partial class FormBSInvenTypeInput : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private FormBSInvenType formInvenType;

        public FormBSInvenTypeInput()
        {
            InitializeComponent();
        }

        private void FormInvenTypeInput_Load(object sender, EventArgs e)
        {
            formInvenType = (FormBSInvenType) Owner;

            //在修改操作下打开FormInvenTypeInput窗体
            if (Tag.ToString() != "Add")
            {
                txtTypeCode.Text = formInvenType.tvInvenType.SelectedNode.Tag.ToString();
                txtTypeName.Text = formInvenType.tvInvenType.SelectedNode.Text;

                //判断是否存在外键约束
                if (commUse.IsExistConstraint("BSInvenType", formInvenType.tvInvenType.SelectedNode.Tag.ToString()))
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
                strCode = "select * from BSInvenType where InvenTypeCode = '" + txtTypeCode.Text.Trim() + "'";

                try
                {
                    sdr = db.GetDataReader(strCode);
                    sdr.Read();
                    if (!sdr.HasRows)
                    {
                        sdr.Close();
                        strCode = "INSERT INTO BSInvenType(InvenTypeCode,InvenTypeName) VALUES('" +
                                  txtTypeCode.Text.Trim() + "','" + txtTypeName.Text.Trim() + "')";

                        if (db.ExecDataBySql(strCode) > 0)
                        {
                            MessageBox.Show("保存成功！", "软件提示");
                            commUse = new CommonUse();
                            commUse.BuildTree(formInvenType.tvInvenType, formInvenType.imageList1, "存货分类", "BSInvenType",
                                              "InvenTypeCode", "InvenTypeName");
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
            else //修改
            {
                //存货类别代码被修改过
                if (formInvenType.tvInvenType.SelectedNode.Tag.ToString() != txtTypeCode.Text.Trim())
                {
                    strCode = "select * from BSInvenType where InvenTypeCode = '" + txtTypeCode.Text.Trim() + "'";

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
                    strCode = "UPDATE BSInvenType SET InvenTypeCode = '" + txtTypeCode.Text.Trim() +
                              "',InvenTypeName = '" + txtTypeName.Text.Trim() + "' WHERE InvenTypeCode = '" +
                              formInvenType.tvInvenType.SelectedNode.Tag + "'";
                    if (db.ExecDataBySql(strCode) > 0)
                    {
                        MessageBox.Show("保存成功！", "软件提示");
                        commUse = new CommonUse();
                        commUse.BuildTree(formInvenType.tvInvenType, formInvenType.imageList1, "存货分类", "BSInvenType",
                                          "InvenTypeCode", "InvenTypeName");
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