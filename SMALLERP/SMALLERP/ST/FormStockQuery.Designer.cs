namespace SMALLERP.ST
{
    partial class FormStockQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockQuery));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolExport = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxInvenCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxStoreCode = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStockQueryInfo = new System.Windows.Forms.DataGridView();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecsModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeaUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LossQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LossMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockQueryInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolQuery,
            this.toolCancel,
            this.toolExport,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolQuery
            // 
            this.toolQuery.Enabled = false;
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(49, 22);
            this.toolQuery.Text = "查询";
            this.toolQuery.Click += new System.EventHandler(this.toolQuery_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(49, 22);
            this.toolCancel.Text = "取消";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolExport
            // 
            this.toolExport.Image = ((System.Drawing.Image)(resources.GetObject("toolExport.Image")));
            this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExport.Name = "toolExport";
            this.toolExport.Size = new System.Drawing.Size(49, 22);
            this.toolExport.Text = "导出";
            this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbxInvenCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxStoreCode);
            this.groupBox1.Location = new System.Drawing.Point(8, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 71);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置查询条件";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 99;
            this.label10.Text = "仓    库";
            // 
            // cbxInvenCode
            // 
            this.cbxInvenCode.Location = new System.Drawing.Point(301, 29);
            this.cbxInvenCode.Name = "cbxInvenCode";
            this.cbxInvenCode.Size = new System.Drawing.Size(126, 20);
            this.cbxInvenCode.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "存货名称";
            // 
            // cbxStoreCode
            // 
            this.cbxStoreCode.Location = new System.Drawing.Point(71, 29);
            this.cbxStoreCode.Name = "cbxStoreCode";
            this.cbxStoreCode.Size = new System.Drawing.Size(126, 20);
            this.cbxStoreCode.TabIndex = 91;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStockQueryInfo);
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 301);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果";
            // 
            // dgvStockQueryInfo
            // 
            this.dgvStockQueryInfo.AllowUserToAddRows = false;
            this.dgvStockQueryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockQueryInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreName,
            this.InvenTypeName,
            this.InvenCode,
            this.InvenName,
            this.SpecsModel,
            this.MeaUnit,
            this.Quantity,
            this.AvePrice,
            this.STMoney,
            this.LossQuantity,
            this.LossMoney});
            this.dgvStockQueryInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvStockQueryInfo.Name = "dgvStockQueryInfo";
            this.dgvStockQueryInfo.RowTemplate.Height = 23;
            this.dgvStockQueryInfo.Size = new System.Drawing.Size(655, 278);
            this.dgvStockQueryInfo.TabIndex = 1;
            this.dgvStockQueryInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStockQueryInfo_DataError);
            // 
            // StoreName
            // 
            this.StoreName.DataPropertyName = "StoreName";
            this.StoreName.HeaderText = "仓    库";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // InvenTypeName
            // 
            this.InvenTypeName.DataPropertyName = "InvenTypeName";
            this.InvenTypeName.HeaderText = "存货类别";
            this.InvenTypeName.Name = "InvenTypeName";
            this.InvenTypeName.ReadOnly = true;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "存货代码";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            this.InvenCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvenCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvenName
            // 
            this.InvenName.DataPropertyName = "InvenName";
            this.InvenName.HeaderText = "存货名称";
            this.InvenName.Name = "InvenName";
            this.InvenName.ReadOnly = true;
            // 
            // SpecsModel
            // 
            this.SpecsModel.DataPropertyName = "SpecsModel";
            this.SpecsModel.HeaderText = "规格型号";
            this.SpecsModel.Name = "SpecsModel";
            this.SpecsModel.ReadOnly = true;
            this.SpecsModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SpecsModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MeaUnit
            // 
            this.MeaUnit.DataPropertyName = "MeaUnit";
            this.MeaUnit.HeaderText = "计量单位";
            this.MeaUnit.Name = "MeaUnit";
            this.MeaUnit.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "库 存 量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // AvePrice
            // 
            this.AvePrice.DataPropertyName = "AvePrice";
            this.AvePrice.HeaderText = "成 本 价";
            this.AvePrice.Name = "AvePrice";
            this.AvePrice.ReadOnly = true;
            // 
            // STMoney
            // 
            this.STMoney.DataPropertyName = "STMoney";
            this.STMoney.HeaderText = "库存金额";
            this.STMoney.Name = "STMoney";
            this.STMoney.ReadOnly = true;
            this.STMoney.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LossQuantity
            // 
            this.LossQuantity.DataPropertyName = "LossQuantity";
            this.LossQuantity.HeaderText = "损失数量";
            this.LossQuantity.Name = "LossQuantity";
            this.LossQuantity.ReadOnly = true;
            this.LossQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LossQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LossMoney
            // 
            this.LossMoney.DataPropertyName = "LossMoney";
            this.LossMoney.HeaderText = "损失金额";
            this.LossMoney.Name = "LossMoney";
            this.LossMoney.ReadOnly = true;
            // 
            // FormStockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormStockQuery";
            this.Text = "库存清单";
            this.Load += new System.EventHandler(this.FormStockQuery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockQueryInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.ToolStripButton toolExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStockQueryInfo;
        private System.Windows.Forms.ToolStripButton toolQuery;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvenTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecsModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeaUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn STMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn LossQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LossMoney;
        private System.Windows.Forms.ComboBox cbxStoreCode;
        private System.Windows.Forms.ComboBox cbxInvenCode;

    }
}