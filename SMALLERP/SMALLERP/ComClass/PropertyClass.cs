namespace SMALLERP.ComClass
{
    /// <summary>
    ///   表示若干属性的类
    /// </summary>
    public class PropertyClass
    {
        private static string m_OperatorCode;

        private static string m_OperatorName;

        private static string m_PassWord;

        private static string m_IsAdmin;

        private string m_InvenCode;

        private string m_InvenName;
        private string m_MatInvenCode;
        private string m_ProInvenCode;

        private string m_SpecsModel;

        /// <summary>
        ///   操作员代码
        /// </summary>
        public static string OperatorCode
        {
            get { return m_OperatorCode; }
            set { m_OperatorCode = value; }
        }

        /// <summary>
        ///   操作员名称
        /// </summary>
        public static string OperatorName
        {
            get { return m_OperatorName; }
            set { m_OperatorName = value; }
        }

        /// <summary>
        ///   操作员密码
        /// </summary>
        public static string PassWord
        {
            get { return m_PassWord; }
            set { m_PassWord = value; }
        }

        /// <summary>
        ///   是否系统管理员标记
        /// </summary>
        public static string IsAdmin
        {
            get { return m_IsAdmin; }
            set { m_IsAdmin = value; }
        }

        /// <summary>
        ///   存货代码
        /// </summary>
        public string InvenCode
        {
            get { return m_InvenCode; }
            set { m_InvenCode = value; }
        }

        /// <summary>
        ///   存货名称
        /// </summary>
        public string InvenName
        {
            get { return m_InvenName; }
            set { m_InvenName = value; }
        }

        /// <summary>
        ///   规格型号
        /// </summary>
        public string SpecsModel
        {
            get { return m_SpecsModel; }
            set { m_SpecsModel = value; }
        }

        /// <summary>
        ///   Bom中母件的代码
        /// </summary>
        public string ProInvenCode
        {
            get { return m_ProInvenCode; }
            set { m_ProInvenCode = value; }
        }

        /// <summary>
        ///   Bom中子件的代码
        /// </summary>
        public string MatInvenCode
        {
            get { return m_MatInvenCode; }
            set { m_MatInvenCode = value; }
        }
    }
}