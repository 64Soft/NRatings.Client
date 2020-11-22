namespace NRatings.Client.GUI
{
    partial class frmGetRealData
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
            this.grpSelectRaces = new System.Windows.Forms.GroupBox();
            this.butPreviewRatings = new System.Windows.Forms.Button();
            this.butVariableInspector = new System.Windows.Forms.Button();
            this.chkSeasons = new NRatings.Client.GUI.cCheckedListBox();
            this.bsSeasons = new System.Windows.Forms.BindingSource(this.components);
            this.bsSeries = new System.Windows.Forms.BindingSource(this.components);
            this.rfsRatingsFormula = new NRatings.Client.GUI.RatingsFormulaSelection();
            this.chkRosterOnly = new System.Windows.Forms.CheckBox();
            this.butSelectNone = new System.Windows.Forms.Button();
            this.butSelectAll = new System.Windows.Forms.Button();
            this.lblRaces = new System.Windows.Forms.Label();
            this.dgRaces = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.raceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRaces = new System.Windows.Forms.BindingSource(this.components);
            this.lblSeasons = new System.Windows.Forms.Label();
            this.cmbSeries = new System.Windows.Forms.ComboBox();
            this.lblSeries = new System.Windows.Forms.Label();
            this.butApply = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpSelectRaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRaces)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelectRaces
            // 
            this.grpSelectRaces.Controls.Add(this.butPreviewRatings);
            this.grpSelectRaces.Controls.Add(this.butVariableInspector);
            this.grpSelectRaces.Controls.Add(this.chkSeasons);
            this.grpSelectRaces.Controls.Add(this.rfsRatingsFormula);
            this.grpSelectRaces.Controls.Add(this.chkRosterOnly);
            this.grpSelectRaces.Controls.Add(this.butSelectNone);
            this.grpSelectRaces.Controls.Add(this.butSelectAll);
            this.grpSelectRaces.Controls.Add(this.lblRaces);
            this.grpSelectRaces.Controls.Add(this.dgRaces);
            this.grpSelectRaces.Controls.Add(this.lblSeasons);
            this.grpSelectRaces.Controls.Add(this.cmbSeries);
            this.grpSelectRaces.Controls.Add(this.lblSeries);
            this.grpSelectRaces.Location = new System.Drawing.Point(12, 12);
            this.grpSelectRaces.Name = "grpSelectRaces";
            this.grpSelectRaces.Size = new System.Drawing.Size(833, 571);
            this.grpSelectRaces.TabIndex = 0;
            this.grpSelectRaces.TabStop = false;
            this.grpSelectRaces.Text = "Select Races";
            // 
            // butPreviewRatings
            // 
            this.butPreviewRatings.Enabled = false;
            this.butPreviewRatings.Location = new System.Drawing.Point(703, 385);
            this.butPreviewRatings.Name = "butPreviewRatings";
            this.butPreviewRatings.Size = new System.Drawing.Size(108, 23);
            this.butPreviewRatings.TabIndex = 19;
            this.butPreviewRatings.Text = "Preview Ratings";
            this.butPreviewRatings.UseVisualStyleBackColor = true;
            this.butPreviewRatings.Click += new System.EventHandler(this.butPreviewRatings_Click);
            // 
            // butVariableInspector
            // 
            this.butVariableInspector.Enabled = false;
            this.butVariableInspector.Location = new System.Drawing.Point(703, 356);
            this.butVariableInspector.Name = "butVariableInspector";
            this.butVariableInspector.Size = new System.Drawing.Size(108, 23);
            this.butVariableInspector.TabIndex = 18;
            this.butVariableInspector.Text = "Variable Inspector";
            this.butVariableInspector.UseVisualStyleBackColor = true;
            this.butVariableInspector.Click += new System.EventHandler(this.butVariableInspector_Click);
            // 
            // chkSeasons
            // 
            this.chkSeasons.CheckOnClick = true;
            this.chkSeasons.DataSource = this.bsSeasons;
            this.chkSeasons.DisplayMember = "Name";
            this.chkSeasons.FormattingEnabled = true;
            this.chkSeasons.Location = new System.Drawing.Point(487, 29);
            this.chkSeasons.Name = "chkSeasons";
            this.chkSeasons.Size = new System.Drawing.Size(140, 64);
            this.chkSeasons.TabIndex = 17;
            this.chkSeasons.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkSeasons_ItemCheck);
            this.chkSeasons.SelectedIndexChanged += new System.EventHandler(this.chkSeasons_SelectedIndexChanged);
            // 
            // bsSeasons
            // 
            this.bsSeasons.DataMember = "Seasons";
            this.bsSeasons.DataSource = this.bsSeries;
            this.bsSeasons.Sort = "";
            // 
            // bsSeries
            // 
            this.bsSeries.DataSource = typeof(NRatings.Client.Domain.Series);
            // 
            // rfsRatingsFormula
            // 
            this.rfsRatingsFormula.FormulaCollection = null;
            this.rfsRatingsFormula.Location = new System.Drawing.Point(197, 336);
            this.rfsRatingsFormula.Name = "rfsRatingsFormula";
            this.rfsRatingsFormula.SelectedFormula = null;
            this.rfsRatingsFormula.Size = new System.Drawing.Size(449, 227);
            this.rfsRatingsFormula.TabIndex = 16;
            // 
            // chkRosterOnly
            // 
            this.chkRosterOnly.AutoSize = true;
            this.chkRosterOnly.Location = new System.Drawing.Point(31, 531);
            this.chkRosterOnly.Name = "chkRosterOnly";
            this.chkRosterOnly.Size = new System.Drawing.Size(143, 30);
            this.chkRosterOnly.TabIndex = 13;
            this.chkRosterOnly.Text = "Do not calculate ratings,\r\nonly use for car selection\r\n";
            this.chkRosterOnly.UseVisualStyleBackColor = true;
            this.chkRosterOnly.CheckedChanged += new System.EventHandler(this.chkCarListOnly_CheckedChanged);
            // 
            // butSelectNone
            // 
            this.butSelectNone.Enabled = false;
            this.butSelectNone.Location = new System.Drawing.Point(31, 385);
            this.butSelectNone.Name = "butSelectNone";
            this.butSelectNone.Size = new System.Drawing.Size(75, 23);
            this.butSelectNone.TabIndex = 9;
            this.butSelectNone.Text = "Select None";
            this.butSelectNone.UseVisualStyleBackColor = true;
            this.butSelectNone.Click += new System.EventHandler(this.butSelectNone_Click);
            // 
            // butSelectAll
            // 
            this.butSelectAll.Enabled = false;
            this.butSelectAll.Location = new System.Drawing.Point(31, 356);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butSelectAll.TabIndex = 8;
            this.butSelectAll.Text = "Select All";
            this.butSelectAll.UseVisualStyleBackColor = true;
            this.butSelectAll.Click += new System.EventHandler(this.butSelectAll_Click);
            // 
            // lblRaces
            // 
            this.lblRaces.AutoSize = true;
            this.lblRaces.Location = new System.Drawing.Point(28, 71);
            this.lblRaces.Name = "lblRaces";
            this.lblRaces.Size = new System.Drawing.Size(332, 26);
            this.lblRaces.TabIndex = 7;
            this.lblRaces.Text = "Select one or more races (stats will be averaged over selected races)\r\nDouble cli" +
    "ck on a row header to see race results";
            // 
            // dgRaces
            // 
            this.dgRaces.AllowUserToAddRows = false;
            this.dgRaces.AllowUserToDeleteRows = false;
            this.dgRaces.AutoGenerateColumns = false;
            this.dgRaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.raceDateDataGridViewTextBoxColumn,
            this.raceNameDataGridViewTextBoxColumn,
            this.trackDataGridViewTextBoxColumn});
            this.dgRaces.DataSource = this.bsRaces;
            this.dgRaces.Location = new System.Drawing.Point(31, 106);
            this.dgRaces.MultiSelect = false;
            this.dgRaces.Name = "dgRaces";
            this.dgRaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRaces.Size = new System.Drawing.Size(780, 220);
            this.dgRaces.TabIndex = 6;
            this.dgRaces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRaces_CellContentClick);
            this.dgRaces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRaces_CellDoubleClick);
            this.dgRaces.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRaces_CellValueChanged);
            this.dgRaces.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRaces_RowHeaderMouseDoubleClick);
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 43;
            // 
            // raceDateDataGridViewTextBoxColumn
            // 
            this.raceDateDataGridViewTextBoxColumn.DataPropertyName = "RaceDate";
            this.raceDateDataGridViewTextBoxColumn.HeaderText = "RaceDate";
            this.raceDateDataGridViewTextBoxColumn.Name = "raceDateDataGridViewTextBoxColumn";
            this.raceDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // raceNameDataGridViewTextBoxColumn
            // 
            this.raceNameDataGridViewTextBoxColumn.DataPropertyName = "RaceName";
            this.raceNameDataGridViewTextBoxColumn.HeaderText = "RaceName";
            this.raceNameDataGridViewTextBoxColumn.Name = "raceNameDataGridViewTextBoxColumn";
            this.raceNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trackDataGridViewTextBoxColumn
            // 
            this.trackDataGridViewTextBoxColumn.DataPropertyName = "Track";
            this.trackDataGridViewTextBoxColumn.HeaderText = "Track";
            this.trackDataGridViewTextBoxColumn.Name = "trackDataGridViewTextBoxColumn";
            this.trackDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsRaces
            // 
            this.bsRaces.DataSource = typeof(NRatings.Client.Domain.Race);
            // 
            // lblSeasons
            // 
            this.lblSeasons.AutoSize = true;
            this.lblSeasons.Location = new System.Drawing.Point(433, 29);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(48, 13);
            this.lblSeasons.TabIndex = 2;
            this.lblSeasons.Text = "Seasons";
            // 
            // cmbSeries
            // 
            this.cmbSeries.DataSource = this.bsSeries;
            this.cmbSeries.DisplayMember = "Name";
            this.cmbSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeries.FormattingEnabled = true;
            this.cmbSeries.Location = new System.Drawing.Point(70, 26);
            this.cmbSeries.Name = "cmbSeries";
            this.cmbSeries.Size = new System.Drawing.Size(325, 21);
            this.cmbSeries.TabIndex = 1;
            this.cmbSeries.SelectedIndexChanged += new System.EventHandler(this.cmbSeries_SelectedIndexChanged);
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Location = new System.Drawing.Point(28, 30);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(36, 13);
            this.lblSeries.TabIndex = 0;
            this.lblSeries.Text = "Series";
            // 
            // butApply
            // 
            this.butApply.Enabled = false;
            this.butApply.Location = new System.Drawing.Point(43, 595);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 11;
            this.butApply.Text = "Apply";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(124, 595);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 639);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(857, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 13;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // frmGetRealData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 661);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butApply);
            this.Controls.Add(this.grpSelectRaces);
            this.Name = "frmGetRealData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Get Ratings from Real-Life Data";
            this.Load += new System.EventHandler(this.frmGetRealData_Load);
            this.grpSelectRaces.ResumeLayout(false);
            this.grpSelectRaces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRaces)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectRaces;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.ComboBox cmbSeries;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblRaces;
        private System.Windows.Forms.DataGridView dgRaces;
        private System.Windows.Forms.Button butSelectAll;
        private System.Windows.Forms.Button butSelectNone;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.CheckBox chkRosterOnly;
        private RatingsFormulaSelection rfsRatingsFormula;
        private cCheckedListBox chkSeasons;
        private System.Windows.Forms.BindingSource bsSeries;
        private System.Windows.Forms.BindingSource bsSeasons;
        private System.Windows.Forms.BindingSource bsRaces;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nR2003TrackTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button butVariableInspector;
        private System.Windows.Forms.Button butPreviewRatings;
    }
}