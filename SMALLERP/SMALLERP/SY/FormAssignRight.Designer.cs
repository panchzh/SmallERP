namespace SMALLERP.SY
{
    partial class FormAssignRight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAssignRight));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tvOperator = new System.Windows.Forms.TreeView();
            this.dgvINRightInfo = new System.Windows.Forms.DataGridView();
            this.OperatorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightTag = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsRight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsINRight = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvINRightInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsINRight)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(687, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Enabled = false;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(49, 22);
            this.toolSave.Tag = "3";
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "open.ico");
            this.imageList1.Images.SetKeyName(1, "close.ico");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.89544F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.10456F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 311F));
            this.tableLayoutPanel1.Controls.Add(this.tvModule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvOperator, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvINRightInfo, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(685, 391);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tvModule
            // 
            this.tvModule.Location = new System.Drawing.Point(163, 3);
            this.tvModule.Name = "tvModule";
            this.tvModule.Size = new System.Drawing.Size(207, 385);
            this.tvModule.TabIndex = 12;
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            // 
            // tvOperator
            // 
            this.tvOperator.Location = new System.Drawing.Point(3, 3);
            this.tvOperator.Name = "tvOperator";
            this.tvOperator.Size = new System.Drawing.Size(154, 385);
            this.tvOperator.TabIndex = 11;
            this.tvOperator.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOperator_AfterSelect);
            // 
            // dgvINRightInfo
            // 
            this.dgvINRightInfo.AllowUserToAddRows = false;
            this.dgvINRightInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvINRightInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperatorCode,
            this.ModuleTag,
            this.RightTag,
            this.IsRight});
            this.dgvINRightInfo.Location = new System.Drawing.Point(376, 3);
            this.dgvINRightInfo.Name = "dgvINRightInfo";
            this.dgvINRightInfo.RowTemplate.Height = 23;
            this.dgvINRightInfo.Size = new System.Drawing.Size(306, 385);
            this.dgvINRightInfo.TabIndex = 13;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操作员代码";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            this.OperatorCode.Visible = false;
            // 
            // ModuleTag
            // 
            this.ModuleTag.DataPropertyName = "ModuleTag";
            this.ModuleTag.HeaderText = "模块标识";
            this.ModuleTag.Name = "ModuleTag";
            this.ModuleTag.ReadOnly = true;
            this.ModuleTag.Visible = false;
            // 
            // RightTag
            // 
            this.RightTag.DataPropertyName = "RightTag";
            this.RightTag.HeaderText = "操作权限";
            this.RightTag.Name = "RightTag";
            this.RightTag.ReadOnly = true;
            this.RightTag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RightTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsRight
            // 
            this.IsRight.DataPropertyName = "IsRight";
            this.IsRight.FalseValue = "0";
            this.IsRight.HeaderText = "授    权";
            this.IsRight.Name = "IsRight";
            this.IsRight.TrueValue = "1";
            // 
            // FormAssignRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 416);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "FormAssignRight";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "操作权限";
            this.Load += new System.EventHandler(this.FormAssignRight_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvINRightInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsINRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvINRightInfo;
        private System.Windows.Forms.BindingSource bsINRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleTag;
        private System.Windows.Forms.DataGridViewComboBoxColumn RightTag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRight;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.TreeView tvOperator;
        private System.Windows.Forms.ImageList imageList1;
    }
}