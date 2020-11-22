using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class frmDriverRatings
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
            this.butClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgRealDrivers = new System.Windows.Forms.DataGridView();
            this.bsRealDrivers = new System.Windows.Forms.BindingSource(this.components);
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgRealDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRealDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butClose.Location = new System.Drawing.Point(12, 505);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Driver Ratings Preview";
            // 
            // dgRealDrivers
            // 
            this.dgRealDrivers.AllowUserToAddRows = false;
            this.dgRealDrivers.AllowUserToDeleteRows = false;
            this.dgRealDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRealDrivers.AutoGenerateColumns = false;
            this.dgRealDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgRealDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRealDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
            this.dgRealDrivers.DataSource = this.bsRealDrivers;
            this.dgRealDrivers.Location = new System.Drawing.Point(17, 60);
            this.dgRealDrivers.MultiSelect = false;
            this.dgRealDrivers.Name = "dgRealDrivers";
            this.dgRealDrivers.ReadOnly = true;
            this.dgRealDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRealDrivers.Size = new System.Drawing.Size(955, 426);
            this.dgRealDrivers.TabIndex = 6;
            this.dgRealDrivers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgRealDrivers_DataBindingComplete);
            // 
            // bsRealDrivers
            // 
            this.bsRealDrivers.DataSource = typeof(RealDriver);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 69;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // frmDriverRatings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 540);
            this.Controls.Add(this.dgRealDrivers);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.butClose);
            this.MinimizeBox = false;
            this.Name = "frmDriverRatings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driver Ratings Preview";
            this.Load += new System.EventHandler(this.frmDriverRatings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRealDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRealDrivers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgRealDrivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgMidRacePositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgHighestPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgLowestPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgGreenFlagPassingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgPercQualityPassesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgPercFastestLapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgPercTop15LapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgPitStopTimeRankDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percRacesInGarageDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsRealDrivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn startsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFCrashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFMechanicalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
    }
}