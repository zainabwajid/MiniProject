namespace ProjectB
{
    partial class frmRubricLevel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbRubricId = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.projectBDataSet6 = new ProjectB.ProjectBDataSet6();
            this.rubricBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rubricTableAdapter = new ProjectB.ProjectBDataSet6TableAdapters.RubricTableAdapter();
            this.txtMeasurementLevel = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvRubricLevel = new System.Windows.Forms.DataGridView();
            this.projectBDataSet7 = new ProjectB.ProjectBDataSet7();
            this.rubricLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rubricLevelTableAdapter = new ProjectB.ProjectBDataSet7TableAdapters.RubricLevelTableAdapter();
            this.rubricIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measurementLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricLevelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rubric Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Measurement Level";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(23, 220);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Home";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmbRubricId
            // 
            this.cmbRubricId.DataSource = this.rubricBindingSource;
            this.cmbRubricId.DisplayMember = "Id";
            this.cmbRubricId.FormattingEnabled = true;
            this.cmbRubricId.Location = new System.Drawing.Point(122, 28);
            this.cmbRubricId.Name = "cmbRubricId";
            this.cmbRubricId.Size = new System.Drawing.Size(121, 21);
            this.cmbRubricId.TabIndex = 4;
            this.cmbRubricId.ValueMember = "Id";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(122, 59);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(121, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // projectBDataSet6
            // 
            this.projectBDataSet6.DataSetName = "ProjectBDataSet6";
            this.projectBDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rubricBindingSource
            // 
            this.rubricBindingSource.DataMember = "Rubric";
            this.rubricBindingSource.DataSource = this.projectBDataSet6;
            // 
            // rubricTableAdapter
            // 
            this.rubricTableAdapter.ClearBeforeFill = true;
            // 
            // txtMeasurementLevel
            // 
            this.txtMeasurementLevel.Location = new System.Drawing.Point(122, 171);
            this.txtMeasurementLevel.Name = "txtMeasurementLevel";
            this.txtMeasurementLevel.Size = new System.Drawing.Size(100, 20);
            this.txtMeasurementLevel.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(122, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvRubricLevel
            // 
            this.dgvRubricLevel.AllowUserToAddRows = false;
            this.dgvRubricLevel.AllowUserToDeleteRows = false;
            this.dgvRubricLevel.AutoGenerateColumns = false;
            this.dgvRubricLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubricLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rubricIdDataGridViewTextBoxColumn,
            this.detailsDataGridViewTextBoxColumn,
            this.measurementLevelDataGridViewTextBoxColumn});
            this.dgvRubricLevel.DataSource = this.rubricLevelBindingSource;
            this.dgvRubricLevel.Location = new System.Drawing.Point(301, 28);
            this.dgvRubricLevel.Name = "dgvRubricLevel";
            this.dgvRubricLevel.ReadOnly = true;
            this.dgvRubricLevel.Size = new System.Drawing.Size(344, 150);
            this.dgvRubricLevel.TabIndex = 8;
            this.dgvRubricLevel.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRubricLevel_RowHeaderMouseClick);
            // 
            // projectBDataSet7
            // 
            this.projectBDataSet7.DataSetName = "ProjectBDataSet7";
            this.projectBDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rubricLevelBindingSource
            // 
            this.rubricLevelBindingSource.DataMember = "RubricLevel";
            this.rubricLevelBindingSource.DataSource = this.projectBDataSet7;
            // 
            // rubricLevelTableAdapter
            // 
            this.rubricLevelTableAdapter.ClearBeforeFill = true;
            // 
            // rubricIdDataGridViewTextBoxColumn
            // 
            this.rubricIdDataGridViewTextBoxColumn.DataPropertyName = "RubricId";
            this.rubricIdDataGridViewTextBoxColumn.HeaderText = "RubricId";
            this.rubricIdDataGridViewTextBoxColumn.Name = "rubricIdDataGridViewTextBoxColumn";
            this.rubricIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detailsDataGridViewTextBoxColumn
            // 
            this.detailsDataGridViewTextBoxColumn.DataPropertyName = "Details";
            this.detailsDataGridViewTextBoxColumn.HeaderText = "Details";
            this.detailsDataGridViewTextBoxColumn.Name = "detailsDataGridViewTextBoxColumn";
            this.detailsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // measurementLevelDataGridViewTextBoxColumn
            // 
            this.measurementLevelDataGridViewTextBoxColumn.DataPropertyName = "MeasurementLevel";
            this.measurementLevelDataGridViewTextBoxColumn.HeaderText = "MeasurementLevel";
            this.measurementLevelDataGridViewTextBoxColumn.Name = "measurementLevelDataGridViewTextBoxColumn";
            this.measurementLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(349, 210);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(499, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmRubricLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 306);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvRubricLevel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMeasurementLevel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmbRubricId);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRubricLevel";
            this.Text = "RubricLevel";
            this.Load += new System.EventHandler(this.frmRubricLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubricLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricLevelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cmbRubricId;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private ProjectBDataSet6 projectBDataSet6;
        private System.Windows.Forms.BindingSource rubricBindingSource;
        private ProjectBDataSet6TableAdapters.RubricTableAdapter rubricTableAdapter;
        private System.Windows.Forms.TextBox txtMeasurementLevel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvRubricLevel;
        private ProjectBDataSet7 projectBDataSet7;
        private System.Windows.Forms.BindingSource rubricLevelBindingSource;
        private ProjectBDataSet7TableAdapters.RubricLevelTableAdapter rubricLevelTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubricIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measurementLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}