namespace SMALLERP.ST
{
    partial class FormSTCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSTCheck));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolCheck = new System.Windows.Forms.ToolStripButton();
            this.toolUnCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labCondation = new System.Windows.Forms.ToolStripLabel();
            this.cbxCondition = new System.Windows.Forms.ToolStripComboBox();
            this.txtKeyWord = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtOK = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSTCheckInfo = new System.Windows.Forms.DataGridView();
            this.STCheckCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STCheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StoreCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AccQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCheckQuantity = new System.Windows.Forms.TextBox();
            this.lblCheckQuantity = new System.Windows.Forms.Label();
            this.txtAccQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxIsFlag = new System.Windows.Forms.ComboBox();
            this.cbxEmployeeCode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBalMoney = new System.Windows.Forms.TextBox();
            this.txtBalQuantity = new System.Windows.Forms.TextBox();
            this.txtAvePrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxInvenCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxStoreCode = new System.Windows.Forms.ComboBox();
            this.lblBalQuantity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOperatorCode = new System.Windows.Forms.ComboBox();
            this.dtpSTCheckDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSTCheckCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTCheckInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolCheck,
            this.toolUnCheck,
            this.toolStripSeparator1,
            this.labCondation,
            this.cbxCondition,
            this.txtKeyWord,
            this.toolStripSeparator2,
            this.txtOK,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(933, 25);
            this.toolStrip1.TabIndex = 69;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Enabled = false;
            this.toolSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(51, 22);
            this.toolSave.Tag = "1";
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Enabled = false;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(51, 22);
            this.toolCancel.Tag = "2";
            this.toolCancel.Text = "取消";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.Enabled = false;
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(51, 22);
            this.toolAdd.Tag = "3";
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolAmend
            // 
            this.toolAmend.Enabled = false;
            this.toolAmend.Image = ((System.Drawing.Image)(resources.GetObject("toolAmend.Image")));
            this.toolAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAmend.Name = "toolAmend";
            this.toolAmend.Size = new System.Drawing.Size(51, 22);
            this.toolAmend.Tag = "4";
            this.toolAmend.Text = "修改";
            this.toolAmend.Click += new System.EventHandler(this.toolAmend_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Enabled = false;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(51, 22);
            this.toolDelete.Tag = "5";
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolCheck
            // 
            this.toolCheck.Enabled = false;
            this.toolCheck.Image = ((System.Drawing.Image)(resources.GetObject("toolCheck.Image")));
            this.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheck.Name = "toolCheck";
            this.toolCheck.Size = new System.Drawing.Size(51, 22);
            this.toolCheck.Text = "审核";
            this.toolCheck.Click += new System.EventHandler(this.toolCheck_Click);
            // 
            // toolUnCheck
            // 
            this.toolUnCheck.Enabled = false;
            this.toolUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("toolUnCheck.Image")));
            this.toolUnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUnCheck.Name = "toolUnCheck";
            this.toolUnCheck.Size = new System.Drawing.Size(51, 22);
            this.toolUnCheck.Text = "弃审";
            this.toolUnCheck.Click += new System.EventHandler(this.toolUnCheck_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // labCondation
            // 
            this.labCondation.Name = "labCondation";
            this.labCondation.Size = new System.Drawing.Size(58, 22);
            this.labCondation.Text = "查询条件:";
            // 
            // cbxCondition
            // 
            this.cbxCondition.DropDownWidth = 90;
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(75, 25);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtOK
            // 
            this.txtOK.Image = ((System.Drawing.Image)(resources.GetObject("txtOK.Image")));
            this.txtOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtOK.Name = "txtOK";
            this.txtOK.Size = new System.Drawing.Size(51, 22);
            this.txtOK.Tag = "6";
            this.txtOK.Text = "查找";
            this.txtOK.Click += new System.EventHandler(this.txtOK_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(51, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSTCheckInfo);
            this.groupBox2.Location = new System.Drawing.Point(8, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(914, 317);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存盘点记录";
            // 
            // dgvSTCheckInfo
            // 
            this.dgvSTCheckInfo.AllowUserToAddRows = false;
            this.dgvSTCheckInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSTCheckInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STCheckCode,
            this.STCheckDate,
            this.OperatorCode,
            this.StoreCode,
            this.InvenCode,
            this.AccQuantity,
            this.CheckQuantity,
            this.BalQuantity,
            this.AvePrice,
            this.BalMoney,
            this.EmployeeCode,
            this.IsFlag});
            this.dgvSTCheckInfo.Location = new System.Drawing.Point(6, 20);
            this.dgvSTCheckInfo.Name = "dgvSTCheckInfo";
            this.dgvSTCheckInfo.RowTemplate.Height = 23;
            this.dgvSTCheckInfo.Size = new System.Drawing.Size(902, 291);
            this.dgvSTCheckInfo.TabIndex = 0;
            this.dgvSTCheckInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSTCheckInfo_CellClick);
            // 
            // STCheckCode
            // 
            this.STCheckCode.DataPropertyName = "STCheckCode";
            this.STCheckCode.HeaderText = "单据编号";
            this.STCheckCode.Name = "STCheckCode";
            this.STCheckCode.ReadOnly = true;
            // 
            // STCheckDate
            // 
            this.STCheckDate.DataPropertyName = "STCheckDate";
            this.STCheckDate.HeaderText = "单据日期";
            this.STCheckDate.Name = "STCheckDate";
            this.STCheckDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操作员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            // 
            // StoreCode
            // 
            this.StoreCode.DataPropertyName = "StoreCode";
            this.StoreCode.HeaderText = "订货仓库";
            this.StoreCode.Name = "StoreCode";
            this.StoreCode.ReadOnly = true;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "存货名称";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            // 
            // AccQuantity
            // 
            this.AccQuantity.DataPropertyName = "AccQuantity";
            this.AccQuantity.HeaderText = "账面数量";
            this.AccQuantity.Name = "AccQuantity";
            this.AccQuantity.ReadOnly = true;
            // 
            // CheckQuantity
            // 
            this.CheckQuantity.DataPropertyName = "CheckQuantity";
            this.CheckQuantity.HeaderText = "实盘数量";
            this.CheckQuantity.Name = "CheckQuantity";
            this.CheckQuantity.ReadOnly = true;
            this.CheckQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BalQuantity
            // 
            this.BalQuantity.DataPropertyName = "BalQuantity";
            this.BalQuantity.HeaderText = "盈亏数量";
            this.BalQuantity.Name = "BalQuantity";
            this.BalQuantity.ReadOnly = true;
            // 
            // AvePrice
            // 
            this.AvePrice.DataPropertyName = "AvePrice";
            this.AvePrice.HeaderText = "成 本 价";
            this.AvePrice.Name = "AvePrice";
            this.AvePrice.ReadOnly = true;
            // 
            // BalMoney
            // 
            this.BalMoney.DataPropertyName = "BalMoney";
            this.BalMoney.HeaderText = "盈亏金额";
            this.BalMoney.Name = "BalMoney";
            this.BalMoney.ReadOnly = true;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.HeaderText = "盘 点 人";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.ReadOnly = true;
            // 
            // IsFlag
            // 
            this.IsFlag.DataPropertyName = "IsFlag";
            this.IsFlag.HeaderText = "审核状态";
            this.IsFlag.Name = "IsFlag";
            this.IsFlag.ReadOnly = true;
            this.IsFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCheckQuantity);
            this.groupBox1.Controls.Add(this.lblCheckQuantity);
            this.groupBox1.Controls.Add(this.txtAccQuantity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxIsFlag);
            this.groupBox1.Controls.Add(this.cbxEmployeeCode);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBalMoney);
            this.groupBox1.Controls.Add(this.txtBalQuantity);
            this.groupBox1.Controls.Add(this.txtAvePrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxInvenCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxStoreCode);
            this.groupBox1.Controls.Add(this.lblBalQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxOperatorCode);
            this.groupBox1.Controls.Add(this.dtpSTCheckDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSTCheckCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 129);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "库存盘点信息";
            // 
            // txtCheckQuantity
            // 
            this.txtCheckQuantity.Location = new System.Drawing.Point(530, 52);
            this.txtCheckQuantity.MaxLength = 9;
            this.txtCheckQuantity.Name = "txtCheckQuantity";
            this.txtCheckQuantity.ReadOnly = true;
            this.txtCheckQuantity.Size = new System.Drawing.Size(126, 21);
            this.txtCheckQuantity.TabIndex = 108;
            this.txtCheckQuantity.TextChanged += new System.EventHandler(this.txtCheckQuantity_TextChanged);
            this.txtCheckQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblCheckQuantity
            // 
            this.lblCheckQuantity.AutoSize = true;
            this.lblCheckQuantity.Location = new System.Drawing.Point(471, 56);
            this.lblCheckQuantity.Name = "lblCheckQuantity";
            this.lblCheckQuantity.Size = new System.Drawing.Size(53, 12);
            this.lblCheckQuantity.TabIndex = 107;
            this.lblCheckQuantity.Text = "实盘数量";
            // 
            // txtAccQuantity
            // 
            this.txtAccQuantity.Location = new System.Drawing.Point(303, 51);
            this.txtAccQuantity.MaxLength = 9;
            this.txtAccQuantity.Name = "txtAccQuantity";
            this.txtAccQuantity.ReadOnly = true;
            this.txtAccQuantity.Size = new System.Drawing.Size(126, 21);
            this.txtAccQuantity.TabIndex = 106;
            this.txtAccQuantity.TextChanged += new System.EventHandler(this.txtCheckQuantity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 105;
            this.label4.Text = "账面数量";
            // 
            // cbxIsFlag
            // 
            this.cbxIsFlag.Enabled = false;
            this.cbxIsFlag.FormattingEnabled = true;
            this.cbxIsFlag.Location = new System.Drawing.Point(761, 93);
            this.cbxIsFlag.Name = "cbxIsFlag";
            this.cbxIsFlag.Size = new System.Drawing.Size(126, 20);
            this.cbxIsFlag.TabIndex = 104;
            // 
            // cbxEmployeeCode
            // 
            this.cbxEmployeeCode.Enabled = false;
            this.cbxEmployeeCode.FormattingEnabled = true;
            this.cbxEmployeeCode.Location = new System.Drawing.Point(530, 93);
            this.cbxEmployeeCode.Name = "cbxEmployeeCode";
            this.cbxEmployeeCode.Size = new System.Drawing.Size(126, 20);
            this.cbxEmployeeCode.TabIndex = 103;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(705, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 101;
            this.label12.Text = "审核状态";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(471, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 100;
            this.label11.Text = "盘 点 人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(705, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 99;
            this.label10.Text = "仓    库";
            // 
            // txtBalMoney
            // 
            this.txtBalMoney.Location = new System.Drawing.Point(303, 93);
            this.txtBalMoney.MaxLength = 9;
            this.txtBalMoney.Name = "txtBalMoney";
            this.txtBalMoney.ReadOnly = true;
            this.txtBalMoney.Size = new System.Drawing.Size(126, 21);
            this.txtBalMoney.TabIndex = 98;
            // 
            // txtBalQuantity
            // 
            this.txtBalQuantity.Location = new System.Drawing.Point(761, 51);
            this.txtBalQuantity.MaxLength = 9;
            this.txtBalQuantity.Name = "txtBalQuantity";
            this.txtBalQuantity.ReadOnly = true;
            this.txtBalQuantity.Size = new System.Drawing.Size(126, 21);
            this.txtBalQuantity.TabIndex = 97;
            this.txtBalQuantity.TextChanged += new System.EventHandler(this.txtBalQuantity_TextChanged);
            // 
            // txtAvePrice
            // 
            this.txtAvePrice.Location = new System.Drawing.Point(72, 93);
            this.txtAvePrice.MaxLength = 9;
            this.txtAvePrice.Name = "txtAvePrice";
            this.txtAvePrice.ReadOnly = true;
            this.txtAvePrice.Size = new System.Drawing.Size(126, 21);
            this.txtAvePrice.TabIndex = 96;
            this.txtAvePrice.TextChanged += new System.EventHandler(this.txtBalQuantity_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 95;
            this.label8.Text = "盈亏金额";
            // 
            // cbxInvenCode
            // 
            this.cbxInvenCode.Enabled = false;
            this.cbxInvenCode.FormattingEnabled = true;
            this.cbxInvenCode.Location = new System.Drawing.Point(72, 52);
            this.cbxInvenCode.Name = "cbxInvenCode";
            this.cbxInvenCode.Size = new System.Drawing.Size(126, 20);
            this.cbxInvenCode.TabIndex = 94;
            this.cbxInvenCode.SelectedIndexChanged += new System.EventHandler(this.cbxInvenCode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "存货名称";
            // 
            // cbxStoreCode
            // 
            this.cbxStoreCode.Enabled = false;
            this.cbxStoreCode.FormattingEnabled = true;
            this.cbxStoreCode.Location = new System.Drawing.Point(761, 15);
            this.cbxStoreCode.Name = "cbxStoreCode";
            this.cbxStoreCode.Size = new System.Drawing.Size(126, 20);
            this.cbxStoreCode.TabIndex = 91;
            this.cbxStoreCode.SelectedIndexChanged += new System.EventHandler(this.cbxStoreCode_SelectedIndexChanged);
            // 
            // lblBalQuantity
            // 
            this.lblBalQuantity.AutoSize = true;
            this.lblBalQuantity.Location = new System.Drawing.Point(705, 56);
            this.lblBalQuantity.Name = "lblBalQuantity";
            this.lblBalQuantity.Size = new System.Drawing.Size(53, 12);
            this.lblBalQuantity.TabIndex = 90;
            this.lblBalQuantity.Text = "盈亏数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 89;
            this.label2.Text = "成 本 价";
            // 
            // cbxOperatorCode
            // 
            this.cbxOperatorCode.Enabled = false;
            this.cbxOperatorCode.FormattingEnabled = true;
            this.cbxOperatorCode.Location = new System.Drawing.Point(530, 15);
            this.cbxOperatorCode.Name = "cbxOperatorCode";
            this.cbxOperatorCode.Size = new System.Drawing.Size(126, 20);
            this.cbxOperatorCode.TabIndex = 82;
            // 
            // dtpSTCheckDate
            // 
            this.dtpSTCheckDate.Enabled = false;
            this.dtpSTCheckDate.Location = new System.Drawing.Point(303, 15);
            this.dtpSTCheckDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpSTCheckDate.Name = "dtpSTCheckDate";
            this.dtpSTCheckDate.Size = new System.Drawing.Size(126, 21);
            this.dtpSTCheckDate.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 70;
            this.label3.Text = "操 作 员";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "单据日期";
            // 
            // txtSTCheckCode
            // 
            this.txtSTCheckCode.Location = new System.Drawing.Point(72, 15);
            this.txtSTCheckCode.MaxLength = 10;
            this.txtSTCheckCode.Name = "txtSTCheckCode";
            this.txtSTCheckCode.ReadOnly = true;
            this.txtSTCheckCode.Size = new System.Drawing.Size(126, 21);
            this.txtSTCheckCode.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "单据编号";
            // 
            // FormSTCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormSTCheck";
            this.Text = "库存盘点";
            this.Load += new System.EventHandler(this.FormSTCheck_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTCheckInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolCheck;
        private System.Windows.Forms.ToolStripButton toolUnCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labCondation;
        private System.Windows.Forms.ToolStripComboBox cbxCondition;
        private System.Windows.Forms.ToolStripTextBox txtKeyWord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton txtOK;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSTCheckInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxIsFlag;
        public System.Windows.Forms.ComboBox cbxEmployeeCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtBalMoney;
        public System.Windows.Forms.TextBox txtBalQuantity;
        public System.Windows.Forms.TextBox txtAvePrice;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cbxInvenCode;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbxStoreCode;
        private System.Windows.Forms.Label lblBalQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOperatorCode;
        private System.Windows.Forms.DateTimePicker dtpSTCheckDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSTCheckCode;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtAccQuantity;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtCheckQuantity;
        private System.Windows.Forms.Label lblCheckQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn STCheckCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn STCheckDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn StoreCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalMoney;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
    }
}