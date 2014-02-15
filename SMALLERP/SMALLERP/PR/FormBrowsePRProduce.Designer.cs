namespace SMALLERP.PR
{
    partial class FormBrowsePRProduce
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.dgvPRProduceInfo = new System.Windows.Forms.DataGridView();
            this.PRProduceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRProduceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PRPlanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsComplete = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRProduceInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvPRProduceInfo);
            this.gbInfo.Location = new System.Drawing.Point(6, 3);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(565, 261);
            this.gbInfo.TabIndex = 14;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "生产单记录";
            // 
            // dgvPRProduceInfo
            // 
            this.dgvPRProduceInfo.AllowUserToAddRows = false;
            this.dgvPRProduceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRProduceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRProduceCode,
            this.PRProduceDate,
            this.OperatorCode,
            this.PRPlanCode,
            this.DepartmentCode,
            this.InvenCode,
            this.Quantity,
            this.StartDate,
            this.EndDate,
            this.EmployeeCode,
            this.IsFlag,
            this.IsComplete});
            this.dgvPRProduceInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvPRProduceInfo.Name = "dgvPRProduceInfo";
            this.dgvPRProduceInfo.RowTemplate.Height = 23;
            this.dgvPRProduceInfo.Size = new System.Drawing.Size(548, 239);
            this.dgvPRProduceInfo.TabIndex = 0;
            this.dgvPRProduceInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRProduceInfo_CellDoubleClick);
            this.dgvPRProduceInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPRProduceInfo_DataError);
            // 
            // PRProduceCode
            // 
            this.PRProduceCode.DataPropertyName = "PRProduceCode";
            this.PRProduceCode.HeaderText = "单据编号";
            this.PRProduceCode.Name = "PRProduceCode";
            this.PRProduceCode.ReadOnly = true;
            // 
            // PRProduceDate
            // 
            this.PRProduceDate.DataPropertyName = "PRProduceDate";
            this.PRProduceDate.HeaderText = "单据日期";
            this.PRProduceDate.Name = "PRProduceDate";
            this.PRProduceDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操 作 员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            // 
            // PRPlanCode
            // 
            this.PRPlanCode.DataPropertyName = "PRPlanCode";
            this.PRPlanCode.HeaderText = "主生产计划号";
            this.PRPlanCode.Name = "PRPlanCode";
            this.PRPlanCode.ReadOnly = true;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.DataPropertyName = "DepartmentCode";
            this.DepartmentCode.HeaderText = "生产车间";
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.ReadOnly = true;
            this.DepartmentCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DepartmentCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "存货名称";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "数    量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "开始日期";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "结束日期";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.HeaderText = "库 管 员";
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
            // IsComplete
            // 
            this.IsComplete.DataPropertyName = "IsComplete";
            this.IsComplete.HeaderText = "是否完工";
            this.IsComplete.Name = "IsComplete";
            this.IsComplete.ReadOnly = true;
            this.IsComplete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsComplete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormBrowsePRProduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 272);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowsePRProduce";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "（完工或入库）浏览生产单";
            this.Load += new System.EventHandler(this.FormBrowsePRProduce_Load);
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRProduceInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridView dgvPRProduceInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRProduceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRProduceDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRPlanCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn DepartmentCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsComplete;
    }
}