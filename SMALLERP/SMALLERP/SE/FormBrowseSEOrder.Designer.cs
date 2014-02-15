namespace SMALLERP.SE
{
    partial class FormBrowseSEOrder
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
            this.dgvSEOrderInfo = new System.Windows.Forms.DataGridView();
            this.SEOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StoreCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenInvenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSEOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvSEOrderInfo);
            this.gbInfo.Location = new System.Drawing.Point(8, 5);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(560, 217);
            this.gbInfo.TabIndex = 11;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "订单记录";
            // 
            // dgvSEOrderInfo
            // 
            this.dgvSEOrderInfo.AllowUserToAddRows = false;
            this.dgvSEOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSEOrderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SEOrderCode,
            this.SEOrderDate,
            this.OperatorCode,
            this.CustomerCode,
            this.StoreCode,
            this.InvenCode,
            this.SellPrice,
            this.Quantity,
            this.SEMoney,
            this.SenInvenDate,
            this.EmployeeCode,
            this.IsFlag});
            this.dgvSEOrderInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvSEOrderInfo.Name = "dgvSEOrderInfo";
            this.dgvSEOrderInfo.RowTemplate.Height = 23;
            this.dgvSEOrderInfo.Size = new System.Drawing.Size(544, 194);
            this.dgvSEOrderInfo.TabIndex = 0;
            this.dgvSEOrderInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSEOrderInfo_CellDoubleClick);
            this.dgvSEOrderInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSEOrderInfo_DataError);
            // 
            // SEOrderCode
            // 
            this.SEOrderCode.DataPropertyName = "SEOrderCode";
            this.SEOrderCode.HeaderText = "单据编号";
            this.SEOrderCode.Name = "SEOrderCode";
            this.SEOrderCode.ReadOnly = true;
            // 
            // SEOrderDate
            // 
            this.SEOrderDate.DataPropertyName = "SEOrderDate";
            this.SEOrderDate.HeaderText = "单据日期";
            this.SEOrderDate.Name = "SEOrderDate";
            this.SEOrderDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操 作 员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
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
            this.StoreCode.HeaderText = "发货仓库";
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
            // SenInvenDate
            // 
            this.SenInvenDate.DataPropertyName = "SenInvenDate";
            this.SenInvenDate.HeaderText = "发货日期";
            this.SenInvenDate.Name = "SenInvenDate";
            this.SenInvenDate.ReadOnly = true;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.HeaderText = "销 售 员";
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
            // FormBrowseSEOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 232);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowseSEOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览已审核的销售订单";
            this.Load += new System.EventHandler(this.FormBrowseSEOrder_Load);
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSEOrderInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridView dgvSEOrderInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOrderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOrderDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn StoreCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenInvenDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
    }
}