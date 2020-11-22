namespace NRatings.Client.GUI
{
    partial class frmDriverStats
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
            this.dgDriverStats = new System.Windows.Forms.DataGridView();
            this.bsDriverStats = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTrackTypeFilter = new System.Windows.Forms.ComboBox();
            this.bsTrackTypes = new System.Windows.Forms.BindingSource(this.components);
            this.lblFilterByTrackType = new System.Windows.Forms.Label();
            this.carNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgFinishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgFinishExcludingDnf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bestFinishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bestStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceStartsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percRaceStartsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgNumberOfStartersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.top5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.top10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadLapFinishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percLapsCompletedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percLapsLedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercLeadLapFinishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishCoefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartCoefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgGreenFlagPassesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgGreenFlagPassedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgQualityPassesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgFastestLapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgTop15LapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.racesInGarageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDriverStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDriverStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrackTypes)).BeginInit();
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
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRace.Location = new System.Drawing.Point(13, 25);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(104, 20);
            this.lblRace.TabIndex = 2;
            this.lblRace.Text = "Driver Stats";
            // 
            // dgDriverStats
            // 
            this.dgDriverStats.AllowUserToAddRows = false;
            this.dgDriverStats.AllowUserToDeleteRows = false;
            this.dgDriverStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDriverStats.AutoGenerateColumns = false;
            this.dgDriverStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgDriverStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDriverStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carNumberDataGridViewTextBoxColumn,
            this.driverDataGridViewTextBoxColumn,
            this.avgFinishDataGridViewTextBoxColumn,
            this.AvgFinishExcludingDnf,
            this.avgStartDataGridViewTextBoxColumn,
            this.bestFinishDataGridViewTextBoxColumn,
            this.bestStartDataGridViewTextBoxColumn,
            this.raceStartsDataGridViewTextBoxColumn,
            this.percRaceStartsDataGridViewTextBoxColumn,
            this.avgNumberOfStartersDataGridViewTextBoxColumn,
            this.winsDataGridViewTextBoxColumn,
            this.polesDataGridViewTextBoxColumn,
            this.top5DataGridViewTextBoxColumn,
            this.top10DataGridViewTextBoxColumn,
            this.LeadLapFinishes,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.percLapsCompletedDataGridViewTextBoxColumn,
            this.percLapsLedDataGridViewTextBoxColumn,
            this.PercLeadLapFinishes,
            this.FinishCoefficient,
            this.StartCoefficient,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.avgGreenFlagPassesDataGridViewTextBoxColumn,
            this.avgGreenFlagPassedDataGridViewTextBoxColumn,
            this.avgQualityPassesDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn20,
            this.avgFastestLapsDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn21,
            this.avgTop15LapsDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.racesInGarageDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn25});
            this.dgDriverStats.DataSource = this.bsDriverStats;
            this.dgDriverStats.Location = new System.Drawing.Point(17, 60);
            this.dgDriverStats.MultiSelect = false;
            this.dgDriverStats.Name = "dgDriverStats";
            this.dgDriverStats.ReadOnly = true;
            this.dgDriverStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDriverStats.Size = new System.Drawing.Size(955, 426);
            this.dgDriverStats.TabIndex = 6;
            // 
            // bsDriverStats
            // 
            this.bsDriverStats.DataSource = typeof(NRatings.Client.Domain.DriverStats);
            // 
            // cmbTrackTypeFilter
            // 
            this.cmbTrackTypeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTrackTypeFilter.DataSource = this.bsTrackTypes;
            this.cmbTrackTypeFilter.DisplayMember = "Name";
            this.cmbTrackTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrackTypeFilter.FormattingEnabled = true;
            this.cmbTrackTypeFilter.Location = new System.Drawing.Point(774, 27);
            this.cmbTrackTypeFilter.Name = "cmbTrackTypeFilter";
            this.cmbTrackTypeFilter.Size = new System.Drawing.Size(198, 21);
            this.cmbTrackTypeFilter.TabIndex = 7;
            this.cmbTrackTypeFilter.ValueMember = "Id";
            // 
            // bsTrackTypes
            // 
            this.bsTrackTypes.DataSource = typeof(NRatings.Client.Domain.TrackType);
            this.bsTrackTypes.CurrentChanged += new System.EventHandler(this.bsTrackTypes_CurrentChanged);
            // 
            // lblFilterByTrackType
            // 
            this.lblFilterByTrackType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterByTrackType.AutoSize = true;
            this.lblFilterByTrackType.Location = new System.Drawing.Point(666, 31);
            this.lblFilterByTrackType.Name = "lblFilterByTrackType";
            this.lblFilterByTrackType.Size = new System.Drawing.Size(102, 13);
            this.lblFilterByTrackType.TabIndex = 8;
            this.lblFilterByTrackType.Text = "Filter By TrackType:";
            // 
            // carNumberDataGridViewTextBoxColumn
            // 
            this.carNumberDataGridViewTextBoxColumn.DataPropertyName = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.HeaderText = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.Name = "carNumberDataGridViewTextBoxColumn";
            this.carNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.carNumberDataGridViewTextBoxColumn.Width = 85;
            // 
            // driverDataGridViewTextBoxColumn
            // 
            this.driverDataGridViewTextBoxColumn.DataPropertyName = "Driver";
            this.driverDataGridViewTextBoxColumn.HeaderText = "Driver";
            this.driverDataGridViewTextBoxColumn.Name = "driverDataGridViewTextBoxColumn";
            this.driverDataGridViewTextBoxColumn.ReadOnly = true;
            this.driverDataGridViewTextBoxColumn.Width = 60;
            // 
            // avgFinishDataGridViewTextBoxColumn
            // 
            this.avgFinishDataGridViewTextBoxColumn.DataPropertyName = "AvgFinish";
            this.avgFinishDataGridViewTextBoxColumn.HeaderText = "AvgFinish";
            this.avgFinishDataGridViewTextBoxColumn.Name = "avgFinishDataGridViewTextBoxColumn";
            this.avgFinishDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFinishDataGridViewTextBoxColumn.Width = 78;
            // 
            // AvgFinishExcludingDnf
            // 
            this.AvgFinishExcludingDnf.DataPropertyName = "AvgFinishExcludingDnf";
            this.AvgFinishExcludingDnf.HeaderText = "AvgFinishExcludingDnf";
            this.AvgFinishExcludingDnf.Name = "AvgFinishExcludingDnf";
            this.AvgFinishExcludingDnf.ReadOnly = true;
            this.AvgFinishExcludingDnf.Width = 141;
            // 
            // avgStartDataGridViewTextBoxColumn
            // 
            this.avgStartDataGridViewTextBoxColumn.DataPropertyName = "AvgStart";
            this.avgStartDataGridViewTextBoxColumn.HeaderText = "AvgStart";
            this.avgStartDataGridViewTextBoxColumn.Name = "avgStartDataGridViewTextBoxColumn";
            this.avgStartDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgStartDataGridViewTextBoxColumn.Width = 73;
            // 
            // bestFinishDataGridViewTextBoxColumn
            // 
            this.bestFinishDataGridViewTextBoxColumn.DataPropertyName = "BestFinish";
            this.bestFinishDataGridViewTextBoxColumn.HeaderText = "BestFinish";
            this.bestFinishDataGridViewTextBoxColumn.Name = "bestFinishDataGridViewTextBoxColumn";
            this.bestFinishDataGridViewTextBoxColumn.ReadOnly = true;
            this.bestFinishDataGridViewTextBoxColumn.Width = 80;
            // 
            // bestStartDataGridViewTextBoxColumn
            // 
            this.bestStartDataGridViewTextBoxColumn.DataPropertyName = "BestStart";
            this.bestStartDataGridViewTextBoxColumn.HeaderText = "BestStart";
            this.bestStartDataGridViewTextBoxColumn.Name = "bestStartDataGridViewTextBoxColumn";
            this.bestStartDataGridViewTextBoxColumn.ReadOnly = true;
            this.bestStartDataGridViewTextBoxColumn.Width = 75;
            // 
            // raceStartsDataGridViewTextBoxColumn
            // 
            this.raceStartsDataGridViewTextBoxColumn.DataPropertyName = "RaceStarts";
            this.raceStartsDataGridViewTextBoxColumn.HeaderText = "RaceStarts";
            this.raceStartsDataGridViewTextBoxColumn.Name = "raceStartsDataGridViewTextBoxColumn";
            this.raceStartsDataGridViewTextBoxColumn.ReadOnly = true;
            this.raceStartsDataGridViewTextBoxColumn.Width = 85;
            // 
            // percRaceStartsDataGridViewTextBoxColumn
            // 
            this.percRaceStartsDataGridViewTextBoxColumn.DataPropertyName = "PercRaceStarts";
            this.percRaceStartsDataGridViewTextBoxColumn.HeaderText = "PercRaceStarts";
            this.percRaceStartsDataGridViewTextBoxColumn.Name = "percRaceStartsDataGridViewTextBoxColumn";
            this.percRaceStartsDataGridViewTextBoxColumn.ReadOnly = true;
            this.percRaceStartsDataGridViewTextBoxColumn.Width = 107;
            // 
            // avgNumberOfStartersDataGridViewTextBoxColumn
            // 
            this.avgNumberOfStartersDataGridViewTextBoxColumn.DataPropertyName = "AvgNumberOfStarters";
            this.avgNumberOfStartersDataGridViewTextBoxColumn.HeaderText = "AvgNumberOfStarters";
            this.avgNumberOfStartersDataGridViewTextBoxColumn.Name = "avgNumberOfStartersDataGridViewTextBoxColumn";
            this.avgNumberOfStartersDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgNumberOfStartersDataGridViewTextBoxColumn.Width = 135;
            // 
            // winsDataGridViewTextBoxColumn
            // 
            this.winsDataGridViewTextBoxColumn.DataPropertyName = "Wins";
            this.winsDataGridViewTextBoxColumn.HeaderText = "Wins";
            this.winsDataGridViewTextBoxColumn.Name = "winsDataGridViewTextBoxColumn";
            this.winsDataGridViewTextBoxColumn.ReadOnly = true;
            this.winsDataGridViewTextBoxColumn.Width = 56;
            // 
            // polesDataGridViewTextBoxColumn
            // 
            this.polesDataGridViewTextBoxColumn.DataPropertyName = "Poles";
            this.polesDataGridViewTextBoxColumn.HeaderText = "Poles";
            this.polesDataGridViewTextBoxColumn.Name = "polesDataGridViewTextBoxColumn";
            this.polesDataGridViewTextBoxColumn.ReadOnly = true;
            this.polesDataGridViewTextBoxColumn.Width = 58;
            // 
            // top5DataGridViewTextBoxColumn
            // 
            this.top5DataGridViewTextBoxColumn.DataPropertyName = "Top5";
            this.top5DataGridViewTextBoxColumn.HeaderText = "Top5";
            this.top5DataGridViewTextBoxColumn.Name = "top5DataGridViewTextBoxColumn";
            this.top5DataGridViewTextBoxColumn.ReadOnly = true;
            this.top5DataGridViewTextBoxColumn.Width = 57;
            // 
            // top10DataGridViewTextBoxColumn
            // 
            this.top10DataGridViewTextBoxColumn.DataPropertyName = "Top10";
            this.top10DataGridViewTextBoxColumn.HeaderText = "Top10";
            this.top10DataGridViewTextBoxColumn.Name = "top10DataGridViewTextBoxColumn";
            this.top10DataGridViewTextBoxColumn.ReadOnly = true;
            this.top10DataGridViewTextBoxColumn.Width = 63;
            // 
            // LeadLapFinishes
            // 
            this.LeadLapFinishes.DataPropertyName = "LeadLapFinishes";
            this.LeadLapFinishes.HeaderText = "LeadLapFinishes";
            this.LeadLapFinishes.Name = "LeadLapFinishes";
            this.LeadLapFinishes.ReadOnly = true;
            this.LeadLapFinishes.Width = 112;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Dnf";
            this.dataGridViewTextBoxColumn12.HeaderText = "Dnf";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 49;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "DnfCrash";
            this.dataGridViewTextBoxColumn13.HeaderText = "DnfCrash";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 76;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "DnfMechanical";
            this.dataGridViewTextBoxColumn14.HeaderText = "DnfMechanical";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 104;
            // 
            // percLapsCompletedDataGridViewTextBoxColumn
            // 
            this.percLapsCompletedDataGridViewTextBoxColumn.DataPropertyName = "PercLapsCompleted";
            this.percLapsCompletedDataGridViewTextBoxColumn.HeaderText = "PercLapsCompleted";
            this.percLapsCompletedDataGridViewTextBoxColumn.Name = "percLapsCompletedDataGridViewTextBoxColumn";
            this.percLapsCompletedDataGridViewTextBoxColumn.ReadOnly = true;
            this.percLapsCompletedDataGridViewTextBoxColumn.Width = 127;
            // 
            // percLapsLedDataGridViewTextBoxColumn
            // 
            this.percLapsLedDataGridViewTextBoxColumn.DataPropertyName = "PercLapsLed";
            this.percLapsLedDataGridViewTextBoxColumn.HeaderText = "PercLapsLed";
            this.percLapsLedDataGridViewTextBoxColumn.Name = "percLapsLedDataGridViewTextBoxColumn";
            this.percLapsLedDataGridViewTextBoxColumn.ReadOnly = true;
            this.percLapsLedDataGridViewTextBoxColumn.Width = 95;
            // 
            // PercLeadLapFinishes
            // 
            this.PercLeadLapFinishes.DataPropertyName = "PercLeadLapFinishes";
            this.PercLeadLapFinishes.HeaderText = "PercLeadLapFinishes";
            this.PercLeadLapFinishes.Name = "PercLeadLapFinishes";
            this.PercLeadLapFinishes.ReadOnly = true;
            this.PercLeadLapFinishes.Width = 134;
            // 
            // FinishCoefficient
            // 
            this.FinishCoefficient.DataPropertyName = "FinishCoefficient";
            this.FinishCoefficient.HeaderText = "FinishCoefficient";
            this.FinishCoefficient.Name = "FinishCoefficient";
            this.FinishCoefficient.ReadOnly = true;
            this.FinishCoefficient.Width = 109;
            // 
            // StartCoefficient
            // 
            this.StartCoefficient.DataPropertyName = "StartCoefficient";
            this.StartCoefficient.HeaderText = "StartCoefficient";
            this.StartCoefficient.Name = "StartCoefficient";
            this.StartCoefficient.ReadOnly = true;
            this.StartCoefficient.Width = 104;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "AvgMidRacePosition";
            this.dataGridViewTextBoxColumn15.HeaderText = "AvgMidRacePosition";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 131;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "AvgHighestPosition";
            this.dataGridViewTextBoxColumn16.HeaderText = "AvgHighestPosition";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 124;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "AvgLowestPosition";
            this.dataGridViewTextBoxColumn17.HeaderText = "AvgLowestPosition";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 122;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "AvgPosition";
            this.dataGridViewTextBoxColumn18.HeaderText = "AvgPosition";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 88;
            // 
            // avgGreenFlagPassesDataGridViewTextBoxColumn
            // 
            this.avgGreenFlagPassesDataGridViewTextBoxColumn.DataPropertyName = "AvgGreenFlagPasses";
            this.avgGreenFlagPassesDataGridViewTextBoxColumn.HeaderText = "AvgGreenFlagPasses";
            this.avgGreenFlagPassesDataGridViewTextBoxColumn.Name = "avgGreenFlagPassesDataGridViewTextBoxColumn";
            this.avgGreenFlagPassesDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgGreenFlagPassesDataGridViewTextBoxColumn.Width = 134;
            // 
            // avgGreenFlagPassedDataGridViewTextBoxColumn
            // 
            this.avgGreenFlagPassedDataGridViewTextBoxColumn.DataPropertyName = "AvgGreenFlagPassed";
            this.avgGreenFlagPassedDataGridViewTextBoxColumn.HeaderText = "AvgGreenFlagPassed";
            this.avgGreenFlagPassedDataGridViewTextBoxColumn.Name = "avgGreenFlagPassedDataGridViewTextBoxColumn";
            this.avgGreenFlagPassedDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgGreenFlagPassedDataGridViewTextBoxColumn.Width = 135;
            // 
            // avgQualityPassesDataGridViewTextBoxColumn
            // 
            this.avgQualityPassesDataGridViewTextBoxColumn.DataPropertyName = "AvgQualityPasses";
            this.avgQualityPassesDataGridViewTextBoxColumn.HeaderText = "AvgQualityPasses";
            this.avgQualityPassesDataGridViewTextBoxColumn.Name = "avgQualityPassesDataGridViewTextBoxColumn";
            this.avgQualityPassesDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgQualityPassesDataGridViewTextBoxColumn.Width = 117;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "AvgPercQualityPasses";
            this.dataGridViewTextBoxColumn20.HeaderText = "AvgPercQualityPasses";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 139;
            // 
            // avgFastestLapsDataGridViewTextBoxColumn
            // 
            this.avgFastestLapsDataGridViewTextBoxColumn.DataPropertyName = "AvgFastestLaps";
            this.avgFastestLapsDataGridViewTextBoxColumn.HeaderText = "AvgFastestLaps";
            this.avgFastestLapsDataGridViewTextBoxColumn.Name = "avgFastestLapsDataGridViewTextBoxColumn";
            this.avgFastestLapsDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFastestLapsDataGridViewTextBoxColumn.Width = 108;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "AvgPercFastestLaps";
            this.dataGridViewTextBoxColumn21.HeaderText = "AvgPercFastestLaps";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 130;
            // 
            // avgTop15LapsDataGridViewTextBoxColumn
            // 
            this.avgTop15LapsDataGridViewTextBoxColumn.DataPropertyName = "AvgTop15Laps";
            this.avgTop15LapsDataGridViewTextBoxColumn.HeaderText = "AvgTop15Laps";
            this.avgTop15LapsDataGridViewTextBoxColumn.Name = "avgTop15LapsDataGridViewTextBoxColumn";
            this.avgTop15LapsDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgTop15LapsDataGridViewTextBoxColumn.Width = 105;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "AvgPercTop15Laps";
            this.dataGridViewTextBoxColumn22.HeaderText = "AvgPercTop15Laps";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 127;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "AvgRating";
            this.dataGridViewTextBoxColumn23.HeaderText = "AvgRating";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 82;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "AvgPitStopTimeRank";
            this.dataGridViewTextBoxColumn24.HeaderText = "AvgPitStopTimeRank";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 134;
            // 
            // racesInGarageDataGridViewTextBoxColumn
            // 
            this.racesInGarageDataGridViewTextBoxColumn.DataPropertyName = "RacesInGarage";
            this.racesInGarageDataGridViewTextBoxColumn.HeaderText = "RacesInGarage";
            this.racesInGarageDataGridViewTextBoxColumn.Name = "racesInGarageDataGridViewTextBoxColumn";
            this.racesInGarageDataGridViewTextBoxColumn.ReadOnly = true;
            this.racesInGarageDataGridViewTextBoxColumn.Width = 107;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "PercRacesInGarage";
            this.dataGridViewTextBoxColumn25.HeaderText = "PercRacesInGarage";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 129;
            // 
            // frmDriverStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 540);
            this.Controls.Add(this.lblFilterByTrackType);
            this.Controls.Add(this.cmbTrackTypeFilter);
            this.Controls.Add(this.dgDriverStats);
            this.Controls.Add(this.lblRace);
            this.Controls.Add(this.butClose);
            this.MinimizeBox = false;
            this.Name = "frmDriverStats";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driver Stats";
            this.Load += new System.EventHandler(this.frmDriverStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDriverStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDriverStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTrackTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.DataGridView dgDriverStats;
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
        private System.Windows.Forms.BindingSource bsDriverStats;
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
        private System.Windows.Forms.ComboBox cmbTrackTypeFilter;
        private System.Windows.Forms.Label lblFilterByTrackType;
        private System.Windows.Forms.BindingSource bsTrackTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn startsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFCrashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNFMechanicalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgFinishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgFinishExcludingDnf;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bestFinishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bestStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceStartsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percRaceStartsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgNumberOfStartersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn top5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn top10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadLapFinishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn percLapsCompletedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percLapsLedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercLeadLapFinishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishCoefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartCoefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgGreenFlagPassesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgGreenFlagPassedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgQualityPassesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgFastestLapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgTop15LapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn racesInGarageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
    }
}