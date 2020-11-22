using PitStopData = NRatings.Client.Domain.PitStopData;

namespace NRatings.Client.GUI
{
    partial class frmPitStopData
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
            this.dgPitStopData = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrOfStopsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inGarageDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.raceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPitStopData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgPitStopData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPitStopData)).BeginInit();
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
            // dgPitStopData
            // 
            this.dgPitStopData.AllowUserToAddRows = false;
            this.dgPitStopData.AllowUserToDeleteRows = false;
            this.dgPitStopData.AutoGenerateColumns = false;
            this.dgPitStopData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPitStopData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPitStopData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.raceIdDataGridViewTextBoxColumn,
            this.driverIdDataGridViewTextBoxColumn,
            this.driverDataGridViewTextBoxColumn,
            this.nrOfStopsDataGridViewTextBoxColumn,
            this.totalTimeDataGridViewTextBoxColumn,
            this.averageTimeDataGridViewTextBoxColumn,
            this.inGarageDataGridViewCheckBoxColumn,
            this.raceDataGridViewTextBoxColumn});
            this.dgPitStopData.DataSource = this.bsPitStopData;
            this.dgPitStopData.Location = new System.Drawing.Point(17, 60);
            this.dgPitStopData.MultiSelect = false;
            this.dgPitStopData.Name = "dgPitStopData";
            this.dgPitStopData.ReadOnly = true;
            this.dgPitStopData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPitStopData.Size = new System.Drawing.Size(904, 359);
            this.dgPitStopData.TabIndex = 6;
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
            // nrOfStopsDataGridViewTextBoxColumn
            // 
            this.nrOfStopsDataGridViewTextBoxColumn.DataPropertyName = "NrOfStops";
            this.nrOfStopsDataGridViewTextBoxColumn.HeaderText = "NrOfStops";
            this.nrOfStopsDataGridViewTextBoxColumn.Name = "nrOfStopsDataGridViewTextBoxColumn";
            this.nrOfStopsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalTimeDataGridViewTextBoxColumn
            // 
            this.totalTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalTime";
            this.totalTimeDataGridViewTextBoxColumn.HeaderText = "TotalTimeInPits";
            this.totalTimeDataGridViewTextBoxColumn.Name = "totalTimeDataGridViewTextBoxColumn";
            this.totalTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // averageTimeDataGridViewTextBoxColumn
            // 
            this.averageTimeDataGridViewTextBoxColumn.DataPropertyName = "AverageTime";
            this.averageTimeDataGridViewTextBoxColumn.HeaderText = "AvgTimeInPits";
            this.averageTimeDataGridViewTextBoxColumn.Name = "averageTimeDataGridViewTextBoxColumn";
            this.averageTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inGarageDataGridViewCheckBoxColumn
            // 
            this.inGarageDataGridViewCheckBoxColumn.DataPropertyName = "InGarage";
            this.inGarageDataGridViewCheckBoxColumn.HeaderText = "BeenToGarage";
            this.inGarageDataGridViewCheckBoxColumn.Name = "inGarageDataGridViewCheckBoxColumn";
            this.inGarageDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // raceDataGridViewTextBoxColumn
            // 
            this.raceDataGridViewTextBoxColumn.DataPropertyName = "Race";
            this.raceDataGridViewTextBoxColumn.HeaderText = "Race";
            this.raceDataGridViewTextBoxColumn.Name = "raceDataGridViewTextBoxColumn";
            this.raceDataGridViewTextBoxColumn.ReadOnly = true;
            this.raceDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsPitStopData
            // 
            this.bsPitStopData.DataSource = typeof(PitStopData);
            // 
            // frmPitStopData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 472);
            this.Controls.Add(this.dgPitStopData);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.butClose);
            this.MinimizeBox = false;
            this.Name = "frmPitStopData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PitStop Data";
            this.Load += new System.EventHandler(this.frmPitStopData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPitStopData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPitStopData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.DataGridView dgPitStopData;
        private System.Windows.Forms.BindingSource bsPitStopData;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrOfStopsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inGarageDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceDataGridViewTextBoxColumn;
    }
}