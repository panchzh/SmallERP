namespace SMALLERP.PR
{
    partial class FormBrowsePRPlan
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
            this.dgvPRPlanInfo = new System.Windows.Forms.DataGridView();
            this.PRPlanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRPlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SEOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFlag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRPlanInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.dgvPRPlanInfo);
            this.gbInfo.Location = new System.Drawing.Point(8, 4);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(560, 217);
            this.gbInfo.TabIndex = 11;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "已审核主生产计划";
            // 
            // dgvPRPlanInfo
            // 
            this.dgvPRPlanInfo.AllowUserToAddRows = false;
            this.dgvPRPlanInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRPlanInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRPlanCode,
            this.PRPlanDate,
            this.OperatorCode,
            this.SEOrderCode,
            this.InvenCode,
            this.Quantity,
            this.FinishDate,
            this.IsFlag});
            this.dgvPRPlanInfo.Location = new System.Drawing.Point(8, 15);
            this.dgvPRPlanInfo.Name = "dgvPRPlanInfo";
            this.dgvPRPlanInfo.RowTemplate.Height = 23;
            this.dgvPRPlanInfo.Size = new System.Drawing.Size(544, 194);
            this.dgvPRPlanInfo.TabIndex = 1;
            this.dgvPRPlanInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPRPlanInfo_CellDoubleClick);
            this.dgvPRPlanInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPRPlanInfo_DataError);
            // 
            // PRPlanCode
            // 
            this.PRPlanCode.DataPropertyName = "PRPlanCode";
            this.PRPlanCode.HeaderText = "单据编号";
            this.PRPlanCode.Name = "PRPlanCode";
            this.PRPlanCode.ReadOnly = true;
            // 
            // PRPlanDate
            // 
            this.PRPlanDate.DataPropertyName = "PRPlanDate";
            this.PRPlanDate.HeaderText = "单据日期";
            this.PRPlanDate.Name = "PRPlanDate";
            this.PRPlanDate.ReadOnly = true;
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
            this.SEOrderCode.HeaderText = "销售订单";
            this.SEOrderCode.Name = "SEOrderCode";
            this.SEOrderCode.ReadOnly = true;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "产品名称";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "计划产量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // FinishDate
            // 
            this.FinishDate.DataPropertyName = "FinishDate";
            this.FinishDate.HeaderText = "计划完工";
            this.FinishDate.Name = "FinishDate";
            this.FinishDate.ReadOnly = true;
            // 
            // IsFlag
            // 
            this.IsFlag.DataPropertyName = "IsFlag";
            this.IsFlag.HeaderText = "审核状态";
            this.IsFlag.Name = "IsFlag";
            this.IsFlag.ReadOnly = true;
            this.IsFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FormBrowsePRPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 232);
            this.Controls.Add(this.gbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowsePRPlan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "浏览已审核的主生产计划";
            this.Load += new System.EventHandler(this.FormBrowsePRPlan_Load);
            this.gbInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRPlanInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.DataGridView dgvPRPlanInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRPlanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEOrderCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsFlag;
    }
}