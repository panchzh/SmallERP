using System;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;

namespace SMALLERP.SY
{
    public partial class FormPassWord : Form
    {
        private readonly DataBase db = new DataBase();

        public FormPassWord()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strSql = null;

            if (String.IsNullOrEmpty(txtOldPassWord.Text))
            {
                MessageBox.Show("原密码不许为空！", "软件提示");
                txtOldPassWord.Focus();
                return;
            }

            if (txtOldPassWord.Text != PropertyClass.PassWord)
            {
                MessageBox.Show("原密码不正确！", "软件提示");
                txtOldPassWord.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("新密码不许为空！", "软件提示");
                txtPassWord.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtAgainPassWord.Text))
            {
                MessageBox.Show("确认密码不许为空！", "软件提示");
                txtAgainPassWord.Focus();
                return;
            }

            if (txtPassWord.Text != txtAgainPassWord.Text)
            {
                MessageBox.Show("两次输入的密码不相同！", "软件提示");
                txtPassWord.Focus();
                return;
            }

            strSql = "Update SYOperator Set PassWord = '" + txtPassWord.Text + "' Where OperatorCode = '" +
                     PropertyClass.OperatorCode + "'";

            try
            {
                if (db.ExecDataBySql(strSql) > 0)
                {
                    MessageBox.Show("密码修改成功！", "软体提示");
                }
                else
                {
                    MessageBox.Show("密码修改失败！", "软体提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软体提示");
                throw ex;
            }

            Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}