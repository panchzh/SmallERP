namespace SMALLERP.PU
{
    partial class FormBrowsePUOrder
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
            this.dgvPUOrderInfo = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPUOrderInfo)).BeginInit();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPUOrderInfo
            // 
            this.dgvPUOrderInfo.AllowUserToAddRows = false;
            this.dgvPUOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPUOrderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column1});
            this.dgvPUOrderInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvPUOrderInfo.Name = "dgvPUOrderInfo";
            this.dgvPUOrderInfo.RowTemplate.Height = 23;
            this.dgvPUOrderInfo.Size = new System.Drawing.Size(544, 194);
            this.dgvPUOrderInfo.TabIndex = 0;
            this.dgvPUOrderInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPUOrderInfo_CellDoubleClick);
            this.dgvPUOrderInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPUOrderInfo_DataError);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PUOrderCode";
            this.Column2.HeaderText = "单据编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PUOrderDate";
            this.Column3.HeaderText = "单据日期";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OperatorCode";
            this.Column4.HeaderText = "操作员";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SupplierCode";
            this.Column5.HeaderText = "供 应 商";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "StoreCode";
            this.Column6.HeaderText = "订货仓库";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "InvenCode";
            this.Column7.HeaderText = "存货名称";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "UnitPrice";
            this.Column8.HeaderText = "采购单价";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Quantity";
            this.Column9.HeaderText = "采购数量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "PUMoney";
            this.Column10.HeaderText = "采购金额";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "RecInvenDate";
            this.Column11.HeaderText = "收货日期";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "EmployeeCode";
            this.Column12.HeaderText = "采 购 员";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IsFlag";
            this.Column1.HeaderText = "审核状态";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvPUOrderInfo);
            this.gbInfo.Location = new System.Drawing.Point(8, 2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(560, 217);
            this.gbInfo.TabIndex = 10;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "已审核订单";
            // 
            // FormBrowsePUOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 232);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowsePUOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览已审核的采购订单";
            this.Load += new System.EventHandler(this.FormBrowsePUOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPUOrderInfo)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPUOrderInfo;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column12;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;


    }
}