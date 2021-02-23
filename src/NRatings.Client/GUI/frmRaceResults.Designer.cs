using RaceResult = NRatings.Client.Domain.RaceResult;

namespace NRatings.Client.GUI
{
    partial class frmRaceResults
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
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapsLedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRaceResults = new System.Windows.Forms.BindingSource(this.components);
            this.butLoopData = new System.Windows.Forms.Button();
            this.butPitStopData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRaceResults)).BeginInit();
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
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AutoGenerateColumns = false;
            this.dgResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.finishPositionDataGridViewTextBoxColumn,
            this.carNumberDataGridViewTextBoxColumn,
            this.driverDataGridViewTextBoxColumn,
            this.startPositionDataGridViewTextBoxColumn,
            this.lapsDataGridViewTextBoxColumn,
            this.lapsLedDataGridViewTextBoxColumn,
            this.carDataGridViewTextBoxColumn,
            this.raceStateDataGridViewTextBoxColumn});
            this.dgResults.DataSource = this.bsRaceResults;
            this.dgResults.Location = new System.Drawing.Point(17, 60);
            this.dgResults.MultiSelect = false;
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResults.Size = new System.Drawing.Size(904, 359);
            this.dgResults.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // finishPositionDataGridViewTextBoxColumn
            // 
            this.finishPositionDataGridViewTextBoxColumn.DataPropertyName = "FinishPosition";
            this.finishPositionDataGridViewTextBoxColumn.HeaderText = "FinishPosition";
            this.finishPositionDataGridViewTextBoxColumn.Name = "finishPositionDataGridViewTextBoxColumn";
            this.finishPositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // carNumberDataGridViewTextBoxColumn
            // 
            this.carNumberDataGridViewTextBoxColumn.DataPropertyName = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.HeaderText = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.Name = "carNumberDataGridViewTextBoxColumn";
            this.carNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // driverDataGridViewTextBoxColumn
            // 
            this.driverDataGridViewTextBoxColumn.DataPropertyName = "Driver";
            this.driverDataGridViewTextBoxColumn.HeaderText = "Driver";
            this.driverDataGridViewTextBoxColumn.Name = "driverDataGridViewTextBoxColumn";
            this.driverDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startPositionDataGridViewTextBoxColumn
            // 
            this.startPositionDataGridViewTextBoxColumn.DataPropertyName = "StartPosition";
            this.startPositionDataGridViewTextBoxColumn.HeaderText = "StartPosition";
            this.startPositionDataGridViewTextBoxColumn.Name = "startPositionDataGridViewTextBoxColumn";
            this.startPositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lapsDataGridViewTextBoxColumn
            // 
            this.lapsDataGridViewTextBoxColumn.DataPropertyName = "Laps";
            this.lapsDataGridViewTextBoxColumn.HeaderText = "Laps";
            this.lapsDataGridViewTextBoxColumn.Name = "lapsDataGridViewTextBoxColumn";
            this.lapsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lapsLedDataGridViewTextBoxColumn
            // 
            this.lapsLedDataGridViewTextBoxColumn.DataPropertyName = "LapsLed";
            this.lapsLedDataGridViewTextBoxColumn.HeaderText = "LapsLed";
            this.lapsLedDataGridViewTextBoxColumn.Name = "lapsLedDataGridViewTextBoxColumn";
            this.lapsLedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // carDataGridViewTextBoxColumn
            // 
            this.carDataGridViewTextBoxColumn.DataPropertyName = "Car";
            this.carDataGridViewTextBoxColumn.HeaderText = "Car";
            this.carDataGridViewTextBoxColumn.Name = "carDataGridViewTextBoxColumn";
            this.carDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // raceStateDataGridViewTextBoxColumn
            // 
            this.raceStateDataGridViewTextBoxColumn.DataPropertyName = "RaceState";
            this.raceStateDataGridViewTextBoxColumn.HeaderText = "RaceState";
            this.raceStateDataGridViewTextBoxColumn.Name = "raceStateDataGridViewTextBoxColumn";
            this.raceStateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsRaceResults
            // 
            this.bsRaceResults.DataSource = typeof(RaceResult);
            // 
            // butLoopData
            // 
            this.butLoopData.Location = new System.Drawing.Point(765, 22);
            this.butLoopData.Name = "butLoopData";
            this.butLoopData.Size = new System.Drawing.Size(75, 23);
            this.butLoopData.TabIndex = 7;
            this.butLoopData.Text = "LoopData";
            this.butLoopData.UseVisualStyleBackColor = true;
            this.butLoopData.Click += new System.EventHandler(this.butLoopData_Click);
            // 
            // butPitStopData
            // 
            this.butPitStopData.Location = new System.Drawing.Point(846, 22);
            this.butPitStopData.Name = "butPitStopData";
            this.butPitStopData.Size = new System.Drawing.Size(75, 23);
            this.butPitStopData.TabIndex = 8;
            this.butPitStopData.Text = "PitStop Data";
            this.butPitStopData.UseVisualStyleBackColor = true;
            this.butPitStopData.Click += new System.EventHandler(this.butPitStopData_Click);
            // 
            // frmRaceResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 472);
            this.Controls.Add(this.butPitStopData);
            this.Controls.Add(this.butLoopData);
            this.Controls.Add(this.dgResults);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.butClose);
            this.MinimizeBox = false;
            this.Name = "frmRaceResults";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Race Results";
            this.Load += new System.EventHandler(this.frmRaceResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRaceResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapsLedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsRaceResults;
        private System.Windows.Forms.Button butLoopData;
        private System.Windows.Forms.Button butPitStopData;
    }
}