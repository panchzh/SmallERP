using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.CU
{
    public partial class FormCustomerAnalyse : Form
    {
        private readonly CommonUse commUse = new CommonUse();
        private readonly DataBase db = new DataBase();
        private readonly IDictionary<int, object> dicKeyValue = new Dictionary<int, object>(); //实例化IDictionary泛型

        public FormCustomerAnalyse()
        {
            InitializeComponent();
        }

        private void FormCustomerAnalyse_Load(object sender, EventArgs e)
        {
            //权限
            commUse.CortrolButtonEnabled(toolQuery, this);

            try
            {
                DataTable dt = db.GetDataTable("Select Code,Name From INBaseType Where Code <> 'CUChance'", "INBaseType");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    toolcbxBaseType.Items.Insert(i, dt.Rows[i]["Name"]);
                    dicKeyValue.Add(i, dt.Rows[i]["Code"]); //使用IDictionary泛型封装“客户基础分类”信息
                }

                toolcbxBaseType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            if (toolcbxBaseType.SelectedItem != null)
            {
                DataRow dr = null;
                Chart chart = new Chart();
                int? intAmount = null;
                DataTable dtTemp = new DataTable();
                string strTableMeanings = toolcbxBaseType.Text; //某个类别表的名称(如：信用等级表、客户等级表等等)
                string strTable = dicKeyValue[toolcbxBaseType.SelectedIndex].ToString(); //某个具体的类别表(共有两个字段：*Code和*Name)

                try
                {
                    //添加“代码”“名称”“数量”三个列于内存表(dtTemp)
                    DataColumn dc1 = new DataColumn("Code", typeof (string));
                    dtTemp.Columns.Add(dc1);
                    DataColumn dc2 = new DataColumn("Name", typeof (string));
                    dtTemp.Columns.Add(dc2);
                    DataColumn dc3 = new DataColumn("Amount", typeof (Int32));
                    dtTemp.Columns.Add(dc3);

                    DataTable dtBaseType = db.GetDataTable("Select * From " + strTable, strTable);
                    string strCodeColumn = dtBaseType.Columns[0].ColumnName;
                    string strNamecolumn = dtBaseType.Columns[1].ColumnName;

                    foreach (DataRow row in dtBaseType.Rows)
                    {
                        dr = dtTemp.NewRow(); //得到与该DataTable具有相同结构的一个DataRow对象
                        dr["Code"] = row[strCodeColumn];
                        dr["Name"] = row[strNamecolumn];

                        intAmount =
                            db.GetSingleObject("Select Count(*) From BSCustomer Where " + strCodeColumn + " = '" +
                                               row[strCodeColumn] + "'") as int?;

                        if (!intAmount.HasValue)
                        {
                            intAmount = 0;
                        }

                        dr["Amount"] = intAmount.Value;

                        dtTemp.Rows.Add(dr);
                    }

                    //增加客户档案中未设置情况的信息
                    dr = dtTemp.NewRow();
                    dr["Code"] = DBNull.Value;
                    dr["Name"] = "未设定";
                    intAmount =
                        db.GetSingleObject("Select Count(*) From BSCustomer Where " + strCodeColumn + " is null ") as
                        int?;

                    if (!intAmount.HasValue)
                    {
                        intAmount = 0;
                    }

                    dr["Amount"] = intAmount.Value;
                    dtTemp.Rows.Add(dr);

                    //绘制饼形图
                    if (dtTemp.Rows.Count > 0)
                    {
                        picPie.Image = chart.CreatePieChart("类型分析", "——" + strTableMeanings, 679, 384, dtTemp, 2);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}