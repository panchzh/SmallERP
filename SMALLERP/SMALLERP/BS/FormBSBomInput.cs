using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

//引入PropertyInfo类

namespace SMALLERP.BS
{
    public partial class FormBSBomInput : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();

        private FormBSBom formBom; //物料清单窗体的引用
        private int intNodeIndex;

        private List<PropertyClass> propBoms; //属性类的List泛型引用
        private List<PropertyClass> propInvens; //属性类的List泛型引用

        public FormBSBomInput()
        {
            InitializeComponent();
        }

        /// <summary>
        ///   加载存货信息(存货代码、存货名称)到List泛型
        /// </summary>
        /// <returns> 包含存货信息的List泛型列表 </returns>
        private List<PropertyClass> LoadInven()
        {
            PropertyClass proCla = new PropertyClass(); //实例化PropertyClass类
            Type elemnetType = proCla.GetType(); //获取proCla的Type
            PropertyInfo[] publicProperties = elemnetType.GetProperties(); //得到实例proCla的Type所拥有的所有公共属性
            //得到存货信息，该存货信息为DataTable类型
            DataTable dt =
                db.GetDataSet("select InvenCode,InvenName ,SpecsModel from BSInven", "BSInven").Tables["BSInven"];
            List<PropertyClass> tempProperties = new List<PropertyClass>(); //实例化List<PropertyClass>泛型类
            //逐行读取得到的存货信息
            foreach (DataRow row in dt.Rows)
            {
                //循环数据源dt中的所有列
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //循环实例proCla的Type拥有的所有公共属性
                    for (int j = 0; j < publicProperties.Length; j++)
                    {
                        //如果数据源dt中指定的列名称与某个公共属性的名称相同
                        if (dt.Columns[i].ColumnName == publicProperties[j].Name)
                        {
                            if (Convert.IsDBNull(row[i])) //如果数据源dt中的当前数据项为null
                            {
                                continue; //则终止本次循环，进入下一次循环
                            }
                            publicProperties[j].SetValue(proCla, row[i], null); //为当前实例proCla中的某个属性赋值，该值为row[i]
                        }
                    }
                }

                tempProperties.Add(proCla); //向泛型列表tempProperties中添加PropertyClass类型的元素，即PropertyClass类的实例proCla
                proCla = new PropertyClass(); //重新创建PropertyClass类的实例
            }

            return tempProperties; //返回包含存货信息的List泛型列表
        }

        /// <summary>
        ///   加载Bom信息(物料清单)到List泛型(使用List泛型封装Bom信息)
        /// </summary>
        /// <returns> 包含Bom信息的List泛型列表 </returns>
        private List<PropertyClass> LoadBom()
        {
            List<PropertyClass> temps = new List<PropertyClass>(); //实例化List<PropertyClass>泛型类
            //得到Bom信息，该Bom信息为DataTable类型
            DataTable dt = db.GetDataSet("select ProInvenCode,MatInvenCode from BSBom", "BSBom").Tables["BSBom"];
            //逐行读取得到的Bom信息
            foreach (DataRow row in dt.Rows)
            {
                //创建PropertyClass类的实例temp
                PropertyClass temp = new PropertyClass();
                //给实例temp的属性赋值
                temp.ProInvenCode = row["ProInvenCode"].ToString();
                temp.MatInvenCode = row["MatInvenCode"].ToString();
                //向泛型列表temps中添加PropertyClass类型的元素，即PropertyClass类的实例temp
                temps.Add(temp);
            }
            return temps;
        }

        /// <summary>
        ///   设置参数值
        /// </summary>
        private void ParametersAddValue()
        {
            db.Cmd.Parameters.Clear();

            if (cbxProInvenCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@ProInvenCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@ProInvenCode", cbxProInvenCode.SelectedValue.ToString());
            }

            if (cbxMatInvenCode.SelectedValue == null)
            {
                db.Cmd.Parameters.AddWithValue("@MatInvenCode", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@MatInvenCode", cbxMatInvenCode.SelectedValue.ToString());
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            }
            else
            {
                db.Cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
            }
        }

        private void FormBomInput_Load(object sender, EventArgs e)
        {
            formBom = (FormBSBom) Owner;
            intNodeIndex = formBom.tvInven.SelectedNode.Index;
            propInvens = LoadInven();
            propBoms = LoadBom();
            commUse.BindComboBox(cbxProInvenCode, "InvenCode", "InvenName",
                                 "select InvenCode,InvenName ,SpecsModel from BSInven", "BSInven");
            commUse.BindComboBox(cbxMatInvenCode, "InvenCode", "InvenName",
                                 "select InvenCode,InvenName ,SpecsModel from BSInven", "BSInven");

            //在添加操作下打开FormBomInput窗体
            if (Tag.ToString() == "Add")
            {
                if (formBom.tvInven.SelectedNode.Tag == null)
                {
                    cbxProInvenCode.SelectedIndex = -1;
                    cbxMatInvenCode.SelectedIndex = -1;
                }
                else
                {
                    cbxProInvenCode.SelectedValue = formBom.tvInven.SelectedNode.Tag;
                    cbxMatInvenCode.SelectedIndex = -1;
                }
            }

            //在修改操作下打开FormBomInput窗体
            if (Tag.ToString() == "Edit")
            {
                cbxProInvenCode.SelectedValue = formBom.tvInven.SelectedNode.Tag;
                cbxProInvenCode.Enabled = false;
                cbxMatInvenCode.SelectedValue = formBom.dgvStructInfo[0, formBom.dgvStructInfo.CurrentRow.Index].Value;
                txtQuantity.Text = formBom.dgvStructInfo[4, formBom.dgvStructInfo.CurrentRow.Index].Value.ToString();
            }
        }

        private void cbxProInvenCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strItemValue;

            if (cbxProInvenCode.SelectedIndex != -1) //没有选中任何“Item”
            {
                strItemValue = cbxProInvenCode.SelectedValue.ToString();

                foreach (PropertyClass item in propInvens)
                {
                    if (item.InvenCode == strItemValue) //通过判断母件代码得到母件的规格型号
                    {
                        txtSpecsModel1.Text = item.SpecsModel;
                    }
                }
            }
        }

        private void cbxMatInvenCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strItemValue;

            if (cbxMatInvenCode.SelectedIndex != -1)
            {
                strItemValue = cbxMatInvenCode.SelectedValue.ToString();

                foreach (PropertyClass item in propInvens) //通过判断子件代码得到子件的规格型号
                {
                    if (item.InvenCode == strItemValue)
                    {
                        txtSpecsModel2.Text = item.SpecsModel;
                    }
                }
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            commUse.InputInteger(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strProInvenCode = null; //母件代码
            string strMatInvenCode = null; //子件代码
            string strOldMatInvenCode = null; //未修改的子件代码
            string strCode = null;

            if (cbxProInvenCode.SelectedIndex == -1)
            {
                MessageBox.Show("请选择母件！", "软件提示");
                cbxProInvenCode.Focus();
                return;
            }

            if (cbxMatInvenCode.SelectedIndex == -1)
            {
                MessageBox.Show("请选择子件！", "软件提示");
                cbxMatInvenCode.Focus();
                return;
            }

            if (cbxMatInvenCode.SelectedValue.ToString() == cbxProInvenCode.SelectedValue.ToString())
            {
                MessageBox.Show("母件与子件不许相同！", "软件提示");
                cbxProInvenCode.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("组成数量不许为空！", "软件提示");
                txtQuantity.Focus();
                return;
            }

            if (Convert.ToInt32(txtQuantity.Text.Trim()) == 0)
            {
                MessageBox.Show("组成数量不许为零！", "软件提示");
                txtQuantity.Focus();
                return;
            }

            //当前的母件代码
            strProInvenCode = cbxProInvenCode.SelectedValue.ToString();
            //当前的子件代码
            strMatInvenCode = cbxMatInvenCode.SelectedValue.ToString();

            //添加操作
            if (Tag.ToString() == "Add")
            {
                foreach (PropertyClass item in propBoms)
                {
                    if (item.ProInvenCode == strProInvenCode && item.MatInvenCode == strMatInvenCode)
                    {
                        MessageBox.Show("子件不许重复！", "软件提示");
                        return;
                    }
                }

                //设置参数
                ParametersAddValue();

                strCode = "INSERT INTO BSBom(ProInvenCode,MatInvenCode,Quantity) ";
                strCode += "VALUES(@ProInvenCode,@MatInvenCode,@Quantity)";

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            //修改操作
            if (Tag.ToString() == "Edit")
            {
                //获取修改之前的子件代码
                strOldMatInvenCode = formBom.dgvStructInfo[0, formBom.dgvStructInfo.CurrentRow.Index].Value.ToString();

                //如果修改了子件代码，则需要判断该母件是否存在重复子件
                if (strMatInvenCode != strOldMatInvenCode)
                {
                    foreach (PropertyClass item in propBoms)
                    {
                        if (item.ProInvenCode == strProInvenCode && item.MatInvenCode == strMatInvenCode)
                        {
                            MessageBox.Show("子件不许重复！", "软件提示");
                            return;
                        }
                    }
                }

                //设置参数
                ParametersAddValue();

                strCode = "UPDATE BSBom SET ProInvenCode=@ProInvenCode,MatInvenCode=@MatInvenCode,Quantity = @Quantity ";
                strCode += " WHERE ProInvenCode = '" + strProInvenCode + "' AND MatInvenCode = '" + strOldMatInvenCode +
                           "'";

                if (db.ExecDataBySql(strCode) > 0)
                {
                    MessageBox.Show("保存成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }

            commUse.BuildTree(formBom.tvInven, formBom.imageList1, "母件", "V_BomStruct", "InvenCode", "InvenName");
            formBom.tvInven.SelectedNode = formBom.tvInven.Nodes[0].Nodes[intNodeIndex];

            Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}