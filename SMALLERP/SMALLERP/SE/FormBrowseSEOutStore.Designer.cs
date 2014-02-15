namespace SMALLERP.SE
{
    partial class FormBrowseSEOutStore
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
            this.dgvSEOutStoreInfo = new System.Windows.Forms.DataGridView();
            this.SEOutCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SEOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StoreCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSEOutStoreInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvSEOutStoreInfo);
            this.gbInfo.Location = new System.Drawing.Point(8, 5);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(560, 217);
            this.gbInfo.TabIndex = 12;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "已审核出库单记录";
            // 
            // dgvSEOutStoreInfo
            // 
            this.dgvSEOutStoreInfo.AllowUserToAddRows = false;
            this.dgvSEOutStoreInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSEOutStoreInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SEOutCode,
            this.SEOutDate,
            this.OperatorCode,
            this.SEOrderCode,
            this.CustomerCode,
            this.StoreCode,
            this.InvenCode,
            this.UnitPrice,
            this.SellPrice,
            this.Quantity,
            this.SEMoney,
            this.EmployeeCode,
            this.IsFlag});
            this.dgvSEOutStoreInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvSEOutStoreInfo.Name = "dgvSEOutStoreInfo";
            this.dgvSEOutStoreInfo.RowTemplate.Height = 23;
            this.dgvSEOutStoreInfo.Size = new System.Drawing.Size(544, 194);
            this.dgvSEOutStoreInfo.TabIndex = 0;
            this.dgvSEOutStoreInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSEOutStoreInfo_CellDoubleClick);
            this.dgvSEOutStoreInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSEOutStoreInfo_DataError);
            // 
            // SEOutCode
            // 
            this.SEOutCode.DataPropertyName = "SEOutCode";
            this.SEOutCode.HeaderText = "单据编号";
            this.SEOutCode.Name = "SEOutCode";
            this.SEOutCode.ReadOnly = true;
            // 
            // SEOutDate
            // 
            this.SEOutDate.DataPropertyName = "SEOutDate";
            this.SEOutDate.HeaderText = "单据日期";
            this.SEOutDate.Name = "SEOutDate";
            this.SEOutDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操作员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            // 
            // SEOrderCode
            // 
            this.SEOrderCode.DataPropertyName = "SEOrderCode";
            this.SEOrderCode.HeaderText = "订单编号";
            this.SEOrderCode.Name = "SEOrderCode";
            this.SEOrderCode.ReadOnly = true;
            // 
            // CustomerCode
            // 
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "客    户";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
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
            this.UnitPrice.HeaderText = "出库时的即时成本价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Visible = false;
            // 
            // SellPrice
            // 
            this.SellPrice.DataPropertyName = "SellPrice";
            this.SellPrice.HeaderText = "销售单价";
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "销售数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // SEMoney
            // 
            this.SEMoney.DataPropertyName = "SEMoney";
            this.SEMoney.HeaderText = "销售金额";
            this.SEMoney.Name = "SEMoney";
            this.SEMoney.ReadOnly = true;
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
            // FormBrowseSEOutStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 232);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowseSEOutStore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览已审核的销售出库单";
            this.Load += new System.EventHandler(this.FormBrowseSEOutStore_Load);
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSEOutStoreInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridView dgvSEOutStoreInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOutCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOutDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOrderCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn StoreCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEMoney;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
    }
}