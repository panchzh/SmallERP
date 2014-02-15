namespace SMALLERP.CU
{
    partial class FormCustomerCourse
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerCourse));
            this.tvCustomer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpSell = new System.Windows.Forms.TabPage();
            this.dgvSell = new System.Windows.Forms.DataGridView();
            this.tpRel = new System.Windows.Forms.TabPage();
            this.dgvRel = new System.Windows.Forms.DataGridView();
            this.RelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode_Rel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelManner = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Linkman_Rel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelephoneCode_Rel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAfter = new System.Windows.Forms.TabPage();
            this.dgvAfter = new System.Windows.Forms.DataGridView();
            this.AfterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode_After = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Linkman_After = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelephoneCode_After = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resolvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode_Sell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Theme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanceCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ForeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpSell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).BeginInit();
            this.tpRel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRel)).BeginInit();
            this.tpAfter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // tvCustomer
            // 
            this.tvCustomer.Location = new System.Drawing.Point(3, 27);
            this.tvCustomer.Name = "tvCustomer";
            this.tvCustomer.Size = new System.Drawing.Size(147, 386);
            this.tvCustomer.TabIndex = 7;
            this.tvCustomer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomer_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "open.ico");
            this.imageList1.Images.SetKeyName(1, "close.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Enabled = false;
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(49, 22);
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
            this.toolAmend.Size = new System.Drawing.Size(49, 22);
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
            this.toolDelete.Size = new System.Drawing.Size(49, 22);
            this.toolDelete.Tag = "5";
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(49, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpSell);
            this.tcMain.Controls.Add(this.tpRel);
            this.tcMain.Controls.Add(this.tpAfter);
            this.tcMain.Location = new System.Drawing.Point(153, 27);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(533, 388);
            this.tcMain.TabIndex = 9;
            // 
            // tpSell
            // 
            this.tpSell.Controls.Add(this.dgvSell);
            this.tpSell.Location = new System.Drawing.Point(4, 21);
            this.tpSell.Name = "tpSell";
            this.tpSell.Padding = new System.Windows.Forms.Padding(3);
            this.tpSell.Size = new System.Drawing.Size(525, 363);
            this.tpSell.TabIndex = 0;
            this.tpSell.Text = "销售机会档案";
            this.tpSell.UseVisualStyleBackColor = true;
            // 
            // dgvSell
            // 
            this.dgvSell.AllowUserToAddRows = false;
            this.dgvSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSell.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SellId,
            this.CustomerCode_Sell,
            this.Theme,
            this.RegDate,
            this.ChanceCode,
            this.ForeDate,
            this.InvenCode,
            this.UnitPrice,
            this.Quantity,
            this.CUMoney,
            this.Remark});
            this.dgvSell.Location = new System.Drawing.Point(1, 4);
            this.dgvSell.Name = "dgvSell";
            this.dgvSell.RowTemplate.Height = 23;
            this.dgvSell.Size = new System.Drawing.Size(521, 355);
            this.dgvSell.TabIndex = 0;
            // 
            // tpRel
            // 
            this.tpRel.Controls.Add(this.dgvRel);
            this.tpRel.Location = new System.Drawing.Point(4, 21);
            this.tpRel.Name = "tpRel";
            this.tpRel.Padding = new System.Windows.Forms.Padding(3);
            this.tpRel.Size = new System.Drawing.Size(525, 363);
            this.tpRel.TabIndex = 1;
            this.tpRel.Text = "联系记录档案";
            this.tpRel.UseVisualStyleBackColor = true;
            // 
            // dgvRel
            // 
            this.dgvRel.AllowUserToAddRows = false;
            this.dgvRel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelId,
            this.CustomerCode_Rel,
            this.RelDate,
            this.RelManner,
            this.Linkman_Rel,
            this.TelephoneCode_Rel,
            this.RelContent,
            this.FeeInfo,
            this.NextDate});
            this.dgvRel.Location = new System.Drawing.Point(1, 4);
            this.dgvRel.Name = "dgvRel";
            this.dgvRel.RowTemplate.Height = 23;
            this.dgvRel.Size = new System.Drawing.Size(521, 355);
            this.dgvRel.TabIndex = 1;
            // 
            // RelId
            // 
            this.RelId.DataPropertyName = "RelId";
            this.RelId.HeaderText = "自增量";
            this.RelId.Name = "RelId";
            this.RelId.ReadOnly = true;
            this.RelId.Visible = false;
            // 
            // CustomerCode_Rel
            // 
            this.CustomerCode_Rel.DataPropertyName = "CustomerCode";
            this.CustomerCode_Rel.HeaderText = "客户名称";
            this.CustomerCode_Rel.Name = "CustomerCode_Rel";
            this.CustomerCode_Rel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerCode_Rel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RelDate
            // 
            this.RelDate.DataPropertyName = "RelDate";
            this.RelDate.HeaderText = "联系日期";
            this.RelDate.Name = "RelDate";
            this.RelDate.ReadOnly = true;
            // 
            // RelManner
            // 
            this.RelManner.DataPropertyName = "RelManner";
            this.RelManner.HeaderText = "联系方式";
            this.RelManner.Name = "RelManner";
            this.RelManner.ReadOnly = true;
            // 
            // Linkman_Rel
            // 
            this.Linkman_Rel.DataPropertyName = "Linkman";
            this.Linkman_Rel.HeaderText = "联系人";
            this.Linkman_Rel.Name = "Linkman_Rel";
            this.Linkman_Rel.ReadOnly = true;
            // 
            // TelephoneCode_Rel
            // 
            this.TelephoneCode_Rel.DataPropertyName = "TelephoneCode";
            this.TelephoneCode_Rel.HeaderText = "联系电话";
            this.TelephoneCode_Rel.Name = "TelephoneCode_Rel";
            this.TelephoneCode_Rel.ReadOnly = true;
            // 
            // RelContent
            // 
            this.RelContent.DataPropertyName = "RelContent";
            this.RelContent.HeaderText = "联系内容";
            this.RelContent.Name = "RelContent";
            this.RelContent.ReadOnly = true;
            // 
            // FeeInfo
            // 
            this.FeeInfo.DataPropertyName = "FeeInfo";
            this.FeeInfo.HeaderText = "反馈信息";
            this.FeeInfo.Name = "FeeInfo";
            this.FeeInfo.ReadOnly = true;
            // 
            // NextDate
            // 
            this.NextDate.DataPropertyName = "NextDate";
            this.NextDate.HeaderText = "下次预约";
            this.NextDate.Name = "NextDate";
            this.NextDate.ReadOnly = true;
            // 
            // tpAfter
            // 
            this.tpAfter.Controls.Add(this.dgvAfter);
            this.tpAfter.Location = new System.Drawing.Point(4, 21);
            this.tpAfter.Name = "tpAfter";
            this.tpAfter.Padding = new System.Windows.Forms.Padding(3);
            this.tpAfter.Size = new System.Drawing.Size(525, 363);
            this.tpAfter.TabIndex = 2;
            this.tpAfter.Text = "售后服务档案";
            this.tpAfter.UseVisualStyleBackColor = true;
            // 
            // dgvAfter
            // 
            this.dgvAfter.AllowUserToAddRows = false;
            this.dgvAfter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AfterId,
            this.CustomerCode_After,
            this.SerDate,
            this.EmployeeCode,
            this.Linkman_After,
            this.SerDays,
            this.TelephoneCode_After,
            this.SerContent,
            this.Resolvent});
            this.dgvAfter.Location = new System.Drawing.Point(1, 4);
            this.dgvAfter.Name = "dgvAfter";
            this.dgvAfter.RowTemplate.Height = 23;
            this.dgvAfter.Size = new System.Drawing.Size(521, 355);
            this.dgvAfter.TabIndex = 1;
            // 
            // AfterId
            // 
            this.AfterId.DataPropertyName = "AfterId";
            this.AfterId.HeaderText = "自增Id";
            this.AfterId.Name = "AfterId";
            this.AfterId.ReadOnly = true;
            this.AfterId.Visible = false;
            // 
            // CustomerCode_After
            // 
            this.CustomerCode_After.DataPropertyName = "CustomerCode";
            this.CustomerCode_After.HeaderText = "客    户";
            this.CustomerCode_After.Name = "CustomerCode_After";
            this.CustomerCode_After.ReadOnly = true;
            // 
            // SerDate
            // 
            this.SerDate.DataPropertyName = "SerDate";
            this.SerDate.HeaderText = "服务日期";
            this.SerDate.Name = "SerDate";
            this.SerDate.ReadOnly = true;
            this.SerDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SerDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.HeaderText = "服务人员";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.ReadOnly = true;
            this.EmployeeCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Linkman_After
            // 
            this.Linkman_After.DataPropertyName = "Linkman";
            this.Linkman_After.HeaderText = "联 系 人";
            this.Linkman_After.Name = "Linkman_After";
            this.Linkman_After.ReadOnly = true;
            // 
            // SerDays
            // 
            this.SerDays.DataPropertyName = "SerDays";
            this.SerDays.HeaderText = "服务天数";
            this.SerDays.Name = "SerDays";
            this.SerDays.ReadOnly = true;
            // 
            // TelephoneCode_After
            // 
            this.TelephoneCode_After.DataPropertyName = "TelephoneCode";
            this.TelephoneCode_After.HeaderText = "联系电话";
            this.TelephoneCode_After.Name = "TelephoneCode_After";
            this.TelephoneCode_After.ReadOnly = true;
            // 
            // SerContent
            // 
            this.SerContent.DataPropertyName = "SerContent";
            this.SerContent.HeaderText = "服务内容";
            this.SerContent.Name = "SerContent";
            this.SerContent.ReadOnly = true;
            // 
            // Resolvent
            // 
            this.Resolvent.DataPropertyName = "Resolvent";
            this.Resolvent.HeaderText = "解决办法";
            this.Resolvent.Name = "Resolvent";
            this.Resolvent.ReadOnly = true;
            // 
            // SellId
            // 
            this.SellId.DataPropertyName = "SellId";
            this.SellId.HeaderText = "自增量";
            this.SellId.Name = "SellId";
            this.SellId.ReadOnly = true;
            this.SellId.Visible = false;
            // 
            // CustomerCode_Sell
            // 
            this.CustomerCode_Sell.DataPropertyName = "CustomerCode";
            this.CustomerCode_Sell.HeaderText = "客    户";
            this.CustomerCode_Sell.Name = "CustomerCode_Sell";
            this.CustomerCode_Sell.ReadOnly = true;
            // 
            // Theme
            // 
            this.Theme.DataPropertyName = "Theme";
            this.Theme.HeaderText = "标    题";
            this.Theme.Name = "Theme";
            this.Theme.ReadOnly = true;
            // 
            // RegDate
            // 
            this.RegDate.DataPropertyName = "RegDate";
            this.RegDate.HeaderText = "登记日期";
            this.RegDate.Name = "RegDate";
            this.RegDate.ReadOnly = true;
            // 
            // ChanceCode
            // 
            this.ChanceCode.DataPropertyName = "ChanceCode";
            this.ChanceCode.HeaderText = "机会等级";
            this.ChanceCode.Name = "ChanceCode";
            this.ChanceCode.ReadOnly = true;
            // 
            // ForeDate
            // 
            this.ForeDate.DataPropertyName = "ForeDate";
            this.ForeDate.HeaderText = "预计日期";
            this.ForeDate.Name = "ForeDate";
            this.ForeDate.ReadOnly = true;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "预售产品";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "预计售价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "预计数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // CUMoney
            // 
            this.CUMoney.DataPropertyName = "CUMoney";
            this.CUMoney.HeaderText = "预计金额";
            this.CUMoney.Name = "CUMoney";
            this.CUMoney.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备    注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // FormCustomerCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 416);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tvCustomer);
            this.MaximizeBox = false;
            this.Name = "FormCustomerCourse";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "客户进程";
            this.Load += new System.EventHandler(this.FormCustomerCourse_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpSell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSell)).EndInit();
            this.tpRel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRel)).EndInit();
            this.tpAfter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView tvCustomer;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpSell;
        private System.Windows.Forms.TabPage tpRel;
        private System.Windows.Forms.TabPage tpAfter;
        public System.Windows.Forms.DataGridView dgvSell;
        public System.Windows.Forms.DataGridView dgvRel;
        public System.Windows.Forms.DataGridView dgvAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelId;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerCode_Rel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn RelManner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linkman_Rel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelephoneCode_Rel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfterId;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerCode_After;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linkman_After;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelephoneCode_After;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resolvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellId;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerCode_Sell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theme;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ChanceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForeDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}