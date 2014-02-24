using System;
using System.Windows.Forms;

namespace SMALLERP
{
    internal static class Program
    {
        /// <summary>
        ///   应用程序的主入口点。 //////更多大型项目源码http://yulei133.3322.org/
        /// </summary>
        [STAThread]
        private static void Main()
        {

            //panchzh
            //系统主函数
            //panchzh






            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

        }
    }
}