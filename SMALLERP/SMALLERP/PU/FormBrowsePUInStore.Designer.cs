namespace SMALLERP.PU
{
    partial class FormBrowsePUInStore
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
            this.dgvPUInStoreInfo = new System.Windows.Forms.DataGridView();
            this.PUInCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SupplierCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StoreCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPUInStoreInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvPUInStoreInfo);
            this.gbInfo.Location = new System.Drawing.Point(8, 5);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(560, 217);
            this.gbInfo.TabIndex = 11;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "已审核入库单";
            // 
            // dgvPUInStoreInfo
            // 
            this.dgvPUInStoreInfo.AllowUserToAddRows = false;
            this.dgvPUInStoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPUInStoreInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PUInCode,
            this.PUInDate,
            this.OperatorCode,
            this.SupplierCode,
            this.StoreCode,
            this.InvenCode,
            this.UnitPrice,
            this.Quantity,
            this.PUMoney,
            this.PUOrderCode,
            this.EmployeeCode,
            this.IsFlag});
            this.dgvPUInStoreInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvPUInStoreInfo.Name = "dgvPUInStoreInfo";
            this.dgvPUInStoreInfo.RowTemplate.Height = 23;
            this.dgvPUInStoreInfo.Size = new System.Drawing.Size(544, 194);
            this.dgvPUInStoreInfo.TabIndex = 1;
            this.dgvPUInStoreInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPUInStoreInfo_CellDoubleClick);
            this.dgvPUInStoreInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPUInStoreInfo_DataError);
            // 
            // PUInCode
            // 
            this.PUInCode.DataPropertyName = "PUInCode";
            this.PUInCode.HeaderText = "单据编号";
            this.PUInCode.Name = "PUInCode";
            this.PUInCode.ReadOnly = true;
            // 
            // PUInDate
            // 
            this.PUInDate.DataPropertyName = "PUInDate";
            this.PUInDate.HeaderText = "单据日期";
            this.PUInDate.Name = "PUInDate";
            this.PUInDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操作员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "供 应 商";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
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
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "采购单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "采购数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // PUMoney
            // 
            this.PUMoney.DataPropertyName = "PUMoney";
            this.PUMoney.HeaderText = "采购金额";
            this.PUMoney.Name = "PUMoney";
            this.PUMoney.ReadOnly = true;
            // 
            // PUOrderCode
            // 
            this.PUOrderCode.DataPropertyName = "PUOrderCode";
            this.PUOrderCode.HeaderText = "订单编号";
            this.PUOrderCode.Name = "PUOrderCode";
            this.PUOrderCode.ReadOnly = true;
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
            // FormBrowsePUInStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 232);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowsePUInStore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览已审核的采购入库单";
            this.Load += new System.EventHandler(this.FormBrowsePUInStore_Load);
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPUInStoreInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridView dgvPUInStoreInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUInCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUInDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn StoreCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUOrderCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
    }
}