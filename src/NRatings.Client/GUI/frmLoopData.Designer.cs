using LoopData = NRatings.Client.Domain.LoopData;

namespace NRatings.Client.GUI
{
    partial class frmLoopData
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
            this.lblRace = new System.Windows.Forms.Label();
            this.dgLoopData = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midRacePositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highestPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowestPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averagePositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.greenFlagPassesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.greenFlagPassedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualityPassesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastestLapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.top15LapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLoopData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoopData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoopData)).BeginInit();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(17, 437);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRace.Location = new System.Drawing.Point(13, 25);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(107, 20);
            this.lblRace.TabIndex = 2;
            this.lblRace.Text = "RaceDetails";
            // 
            // dgLoopData
            // 
            this.dgLoopData.AllowUserToAddRows = false;
            this.dgLoopData.AllowUserToDeleteRows = false;
            this.dgLoopData.AutoGenerateColumns = false;
            this.dgLoopData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLoopData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLoopData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.raceIdDataGridViewTextBoxColumn,
            this.driverIdDataGridViewTextBoxColumn,
            this.driverDataGridViewTextBoxColumn,
            this.midRacePositionDataGridViewTextBoxColumn,
            this.highestPositionDataGridViewTextBoxColumn,
            this.lowestPositionDataGridViewTextBoxColumn,
            this.averagePositionDataGridViewTextBoxColumn,
            this.greenFlagPassesDataGridViewTextBoxColumn,
            this.greenFlagPassedDataGridViewTextBoxColumn,
            this.qualityPassesDataGridViewTextBoxColumn,
            this.fastestLapsDataGridViewTextBoxColumn,
            this.top15LapsDataGridViewTextBoxColumn,
            this.ratingDataGridViewTextBoxColumn});
            this.dgLoopData.DataSource = this.bsLoopData;
            this.dgLoopData.Location = new System.Drawing.Point(17, 60);
            this.dgLoopData.MultiSelect = false;
            this.dgLoopData.Name = "dgLoopData";
            this.dgLoopData.ReadOnly = true;
            this.dgLoopData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLoopData.Size = new System.Drawing.Size(904, 359);
            this.dgLoopData.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // raceIdDataGridViewTextBoxColumn
            // 
            this.raceIdDataGridViewTextBoxColumn.DataPropertyName = "RaceId";
            this.raceIdDataGridViewTextBoxColumn.HeaderText = "RaceId";
            this.raceIdDataGridViewTextBoxColumn.Name = "raceIdDataGridViewTextBoxColumn";
            this.raceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.raceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // driverIdDataGridViewTextBoxColumn
            // 
            this.driverIdDataGridViewTextBoxColumn.DataPropertyName = "DriverId";
            this.driverIdDataGridViewTextBoxColumn.HeaderText = "DriverId";
            this.driverIdDataGridViewTextBoxColumn.Name = "driverIdDataGridViewTextBoxColumn";
            this.driverIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // driverDataGridViewTextBoxColumn
            // 
            this.driverDataGridViewTextBoxColumn.DataPropertyName = "Driver";
            this.driverDataGridViewTextBoxColumn.HeaderText = "Driver";
            this.driverDataGridViewTextBoxColumn.Name = "driverDataGridViewTextBoxColumn";
            this.driverDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // midRacePositionDataGridViewTextBoxColumn
            // 
            this.midRacePositionDataGridViewTextBoxColumn.DataPropertyName = "MidRacePosition";
            this.midRacePositionDataGridViewTextBoxColumn.HeaderText = "MidRacePos";
            this.midRacePositionDataGridViewTextBoxColumn.Name = "midRacePositionDataGridViewTextBoxColumn";
            this.midRacePositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // highestPositionDataGridViewTextBoxColumn
            // 
            this.highestPositionDataGridViewTextBoxColumn.DataPropertyName = "HighestPosition";
            this.highestPositionDataGridViewTextBoxColumn.HeaderText = "HighPos";
            this.highestPositionDataGridViewTextBoxColumn.Name = "highestPositionDataGridViewTextBoxColumn";
            this.highestPositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lowestPositionDataGridViewTextBoxColumn
            // 
            this.lowestPositionDataGridViewTextBoxColumn.DataPropertyName = "LowestPosition";
            this.lowestPositionDataGridViewTextBoxColumn.HeaderText = "LowPos";
            this.lowestPositionDataGridViewTextBoxColumn.Name = "lowestPositionDataGridViewTextBoxColumn";
            this.lowestPositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // averagePositionDataGridViewTextBoxColumn
            // 
            this.averagePositionDataGridViewTextBoxColumn.DataPropertyName = "AveragePosition";
            this.averagePositionDataGridViewTextBoxColumn.HeaderText = "AvgPos";
            this.averagePositionDataGridViewTextBoxColumn.Name = "averagePositionDataGridViewTextBoxColumn";
            this.averagePositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // greenFlagPassesDataGridViewTextBoxColumn
            // 
            this.greenFlagPassesDataGridViewTextBoxColumn.DataPropertyName = "GreenFlagPasses";
            this.greenFlagPassesDataGridViewTextBoxColumn.HeaderText = "GFPasses";
            this.greenFlagPassesDataGridViewTextBoxColumn.Name = "greenFlagPassesDataGridViewTextBoxColumn";
            this.greenFlagPassesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // greenFlagPassedDataGridViewTextBoxColumn
            // 
            this.greenFlagPassedDataGridViewTextBoxColumn.DataPropertyName = "GreenFlagPassed";
            this.greenFlagPassedDataGridViewTextBoxColumn.HeaderText = "GFPassed";
            this.greenFlagPassedDataGridViewTextBoxColumn.Name = "greenFlagPassedDataGridViewTextBoxColumn";
            this.greenFlagPassedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qualityPassesDataGridViewTextBoxColumn
            // 
            this.qualityPassesDataGridViewTextBoxColumn.DataPropertyName = "QualityPasses";
            this.qualityPassesDataGridViewTextBoxColumn.HeaderText = "QualPasses";
            this.qualityPassesDataGridViewTextBoxColumn.Name = "qualityPassesDataGridViewTextBoxColumn";
            this.qualityPassesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fastestLapsDataGridViewTextBoxColumn
            // 
            this.fastestLapsDataGridViewTextBoxColumn.DataPropertyName = "FastestLaps";
            this.fastestLapsDataGridViewTextBoxColumn.HeaderText = "FL";
            this.fastestLapsDataGridViewTextBoxColumn.Name = "fastestLapsDataGridViewTextBoxColumn";
            this.fastestLapsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // top15LapsDataGridViewTextBoxColumn
            // 
            this.top15LapsDataGridViewTextBoxColumn.DataPropertyName = "Top15Laps";
            this.top15LapsDataGridViewTextBoxColumn.HeaderText = "T15L";
            this.top15LapsDataGridViewTextBoxColumn.Name = "top15LapsDataGridViewTextBoxColumn";
            this.top15LapsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            this.ratingDataGridViewTextBoxColumn.DataPropertyName = "Rating";
            this.ratingDataGridViewTextBoxColumn.HeaderText = "Rating";
            this.ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            this.ratingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsLoopData
            // 
            this.bsLoopData.DataSource = typeof(LoopData);
            // 
            // frmLoopData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 472);
            this.Controls.Add(this.dgLoopData);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.butClose);
            this.MinimizeBox = false;
            this.Name = "frmLoopData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loop Data";
            this.Load += new System.EventHandler(this.frmLoopData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLoopData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoopData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.DataGridView dgLoopData;
        private System.Windows.Forms.BindingSource bsLoopData;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn midRacePositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highestPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowestPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averagePositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn greenFlagPassesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn greenFlagPassedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualityPassesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastestLapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn top15LapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
    }
}