using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SMALLERP.ComClass;
using SMALLERP.DataClass;
//////更多大型项目源码http://yulei133.3322.org/
namespace SMALLERP
{
    public partial class Login : Form
    {
        private readonly DataBase db = new DataBase();
        private SqlDataReader sdr;

        public Login()
        {
            InitializeComponent();
        }

        //登录用户文本框敲回车键
        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
            }
        }

        //登录密码文本框敲回车键
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picLogin_Click(sender, e);
            }
        }

        //登录
        private void picLogin_Click(object sender, EventArgs e)
        {
            errInfo.Clear();

            if (String.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                try
                {
                    errInfo.SetError(txtCode, "用户编码不能为空！");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
                finally
                {
                }
            }

            if (String.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                try
                {
                    errInfo.SetError(txtPwd, "用户密码不能为空！");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "软件提示");
                    throw ex;
                }
                finally
                {
                }
            }

            string strSql = "select * from SYOperator where OperatorCode = '" + txtCode.Text.Trim() +
                            "' and PassWord = '" + txtPwd.Text.Trim() + "'";

            try
            {
                sdr = db.GetDataReader(strSql);
                sdr.Read();
                if (sdr.HasRows)
                {
                    AppMain AppForm = new AppMain();
                    Hide();
                    PropertyClass.OperatorCode = sdr["OperatorCode"].ToString();
                    PropertyClass.OperatorName = sdr["OperatorName"].ToString();
                    PropertyClass.PassWord = sdr["PassWord"].ToString();
                    PropertyClass.IsAdmin = sdr["IsAdmin"].ToString();
                    AppForm.Show();
                }
                else
                {
                    MessageBox.Show("用户编码或用户密码不正确！", "软件提示");
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

        //重置
        private void picReset_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtPwd.Text = "";
        }

        //退出
        private void picQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}