using System;
using System.Diagnostics;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP
{   
    //////更多大型项目源码http://yulei133.3322.org/
    
    public partial class AppMain : Form
    {
        
        //panchzh
        //测试修改上传

        private DataBase db;

        public AppMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusLabelTime.Text = "当前时间：" + DateTime.Now.ToString();
        }

        private void AppMain_Load(object sender, EventArgs e)
        {
            db = new DataBase();
            timerTime.Start();
            statusLabelOperator.Text = "当前操作员：" + PropertyClass.OperatorName;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            CommonUse commUse = new CommonUse();
            commUse.ShowForm((ToolStripMenuItem) sender, this);
        }

        private void AppMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void AppMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Dispose();
        }

        private void 启动系统计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void 打开ExcelToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("excel.exe");
        }

        private void 打开WordToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("winword.exe");
        }

        private void 打开InternetToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("iexplore.exe");
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}