using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class frmNR2003Ratings
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
            this.lblInstance = new System.Windows.Forms.Label();
            this.cmbMod = new System.Windows.Forms.ComboBox();
            this.bsMods = new System.Windows.Forms.BindingSource(this.components);
            this.bsNR2003Instances = new System.Windows.Forms.BindingSource(this.components);
            this.lblMod = new System.Windows.Forms.Label();
            this.dgCars = new System.Windows.Forms.DataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mappedToRealDriverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsRealDrivers = new System.Windows.Forms.BindingSource(this.components);
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsCars = new System.Windows.Forms.BindingSource(this.components);
            this.butSaveModifiedCars = new System.Windows.Forms.Button();
            this.butImportRatings = new System.Windows.Forms.Button();
            this.mnMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.visitProjectHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizeAllNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butDiscard = new System.Windows.Forms.Button();
            this.butCreateRoster = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblChooseRoster = new System.Windows.Forms.Label();
            this.cmbRoster = new System.Windows.Forms.ComboBox();
            this.bsRosters = new System.Windows.Forms.BindingSource(this.components);
            this.lblCountCars = new System.Windows.Forms.Label();
            this.lbLog = new NRatings.Client.GUI.LogBox();
            this.grpRatings = new NRatings.Client.GUI.RatingsGroup();
            this.butModifyRatings = new System.Windows.Forms.Button();
            this.butSelectModifiedCars = new System.Windows.Forms.Button();
            this.butSelectAllCars = new System.Windows.Forms.Button();
            this.butSelectNoCars = new System.Windows.Forms.Button();
            this.cmbNR2003Instance = new System.Windows.Forms.ComboBox();
            this.ctxMenuStripCars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteRatingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertNameOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertRatingsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertCompletelyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkDonate = new System.Windows.Forms.LinkLabel();
            this.lblLikingNRatings = new System.Windows.Forms.Label();
            this.lnkTwitch = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bsMods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNR2003Instances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRealDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCars)).BeginInit();
            this.mnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRosters)).BeginInit();
            this.ctxMenuStripCars.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstance
            // 
            this.lblInstance.AutoSize = true;
            this.lblInstance.Location = new System.Drawing.Point(12, 41);
            this.lblInstance.Name = "lblInstance";
            this.lblInstance.Size = new System.Drawing.Size(91, 13);
            this.lblInstance.TabIndex = 1;
            this.lblInstance.Text = "NR2003 Instance";
            // 
            // cmbMod
            // 
            this.cmbMod.DataSource = this.bsMods;
            this.cmbMod.DisplayMember = "Name";
            this.cmbMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMod.FormattingEnabled = true;
            this.cmbMod.Location = new System.Drawing.Point(123, 65);
            this.cmbMod.Name = "cmbMod";
            this.cmbMod.Size = new System.Drawing.Size(121, 21);
            this.cmbMod.TabIndex = 3;
            this.cmbMod.SelectedIndexChanged += new System.EventHandler(this.cmbMod_SelectedIndexChanged);
            // 
            // bsMods
            // 
            this.bsMods.DataMember = "Mods";
            this.bsMods.DataSource = this.bsNR2003Instances;
            this.bsMods.CurrentChanged += new System.EventHandler(this.bsMods_CurrentChanged);
            // 
            // bsNR2003Instances
            // 
            this.bsNR2003Instances.DataSource = typeof(NRatings.Client.Domain.NR2003Instance);
            this.bsNR2003Instances.CurrentChanged += new System.EventHandler(this.bsNR2003Instances_CurrentChanged);
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.Location = new System.Drawing.Point(12, 69);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(67, 13);
            this.lblMod.TabIndex = 4;
            this.lblMod.Text = "Choose Mod";
            // 
            // dgCars
            // 
            this.dgCars.AllowUserToAddRows = false;
            this.dgCars.AllowUserToDeleteRows = false;
            this.dgCars.AutoGenerateColumns = false;
            this.dgCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.driverFirstNameDataGridViewTextBoxColumn,
            this.driverLastNameDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.mappedToRealDriverDataGridViewComboBoxColumn,
            this.selectedDataGridViewCheckBoxColumn});
            this.dgCars.DataSource = this.bsCars;
            this.dgCars.Location = new System.Drawing.Point(15, 120);
            this.dgCars.MultiSelect = false;
            this.dgCars.Name = "dgCars";
            this.dgCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCars.Size = new System.Drawing.Size(705, 470);
            this.dgCars.TabIndex = 5;
            this.dgCars.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgCars_CurrentCellDirtyStateChanged);
            this.dgCars.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgCars_DataError);
            this.dgCars.SelectionChanged += new System.EventHandler(this.dgCars_SelectionChanged);
            this.dgCars.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgCars_MouseDown);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 69;
            // 
            // driverFirstNameDataGridViewTextBoxColumn
            // 
            this.driverFirstNameDataGridViewTextBoxColumn.DataPropertyName = "DriverFirstName";
            this.driverFirstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.driverFirstNameDataGridViewTextBoxColumn.MaxInputLength = 15;
            this.driverFirstNameDataGridViewTextBoxColumn.Name = "driverFirstNameDataGridViewTextBoxColumn";
            // 
            // driverLastNameDataGridViewTextBoxColumn
            // 
            this.driverLastNameDataGridViewTextBoxColumn.DataPropertyName = "DriverLastName";
            this.driverLastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.driverLastNameDataGridViewTextBoxColumn.MaxInputLength = 15;
            this.driverLastNameDataGridViewTextBoxColumn.Name = "driverLastNameDataGridViewTextBoxColumn";
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "File";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mappedToRealDriverDataGridViewComboBoxColumn
            // 
            this.mappedToRealDriverDataGridViewComboBoxColumn.DataPropertyName = "MappedToRealDriver";
            this.mappedToRealDriverDataGridViewComboBoxColumn.DataSource = this.bsRealDrivers;
            this.mappedToRealDriverDataGridViewComboBoxColumn.DisplayMember = "DisplayString";
            this.mappedToRealDriverDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.mappedToRealDriverDataGridViewComboBoxColumn.HeaderText = "Maps To";
            this.mappedToRealDriverDataGridViewComboBoxColumn.Name = "mappedToRealDriverDataGridViewComboBoxColumn";
            this.mappedToRealDriverDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mappedToRealDriverDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.mappedToRealDriverDataGridViewComboBoxColumn.ValueMember = "Self";
            // 
            // bsRealDrivers
            // 
            this.bsRealDrivers.AllowNew = true;
            this.bsRealDrivers.DataSource = typeof(NRatings.Client.Domain.RealDriver);
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "Selected";
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            this.selectedDataGridViewCheckBoxColumn.Width = 55;
            // 
            // bsCars
            // 
            this.bsCars.DataSource = typeof(NRatings.Client.Domain.NR2003Car);
            // 
            // butSaveModifiedCars
            // 
            this.butSaveModifiedCars.Enabled = false;
            this.butSaveModifiedCars.Location = new System.Drawing.Point(15, 605);
            this.butSaveModifiedCars.Name = "butSaveModifiedCars";
            this.butSaveModifiedCars.Size = new System.Drawing.Size(112, 27);
            this.butSaveModifiedCars.TabIndex = 7;
            this.butSaveModifiedCars.Text = "Save Modified Cars";
            this.butSaveModifiedCars.UseVisualStyleBackColor = true;
            this.butSaveModifiedCars.Click += new System.EventHandler(this.butSaveModifiedCars_Click);
            // 
            // butImportRatings
            // 
            this.butImportRatings.Enabled = false;
            this.butImportRatings.Location = new System.Drawing.Point(746, 12);
            this.butImportRatings.Name = "butImportRatings";
            this.butImportRatings.Size = new System.Drawing.Size(190, 27);
            this.butImportRatings.TabIndex = 8;
            this.butImportRatings.Text = "Import Ratings from Real Life Data";
            this.butImportRatings.UseVisualStyleBackColor = true;
            this.butImportRatings.Click += new System.EventHandler(this.butImportRatings_Click);
            // 
            // mnMenu
            // 
            this.mnMenu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mnMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.devToolStripMenuItem});
            this.mnMenu.Location = new System.Drawing.Point(0, 0);
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnMenu.Size = new System.Drawing.Size(984, 24);
            this.mnMenu.TabIndex = 9;
            this.mnMenu.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.visitProjectHomeToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(169, 6);
            // 
            // visitProjectHomeToolStripMenuItem
            // 
            this.visitProjectHomeToolStripMenuItem.Name = "visitProjectHomeToolStripMenuItem";
            this.visitProjectHomeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.visitProjectHomeToolStripMenuItem.Text = "Visit Project Home";
            this.visitProjectHomeToolStripMenuItem.Click += new System.EventHandler(this.visitProjectHomeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // devToolStripMenuItem
            // 
            this.devToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomizeAllNamesToolStripMenuItem});
            this.devToolStripMenuItem.Name = "devToolStripMenuItem";
            this.devToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.devToolStripMenuItem.Text = "Dev";
            // 
            // randomizeAllNamesToolStripMenuItem
            // 
            this.randomizeAllNamesToolStripMenuItem.Name = "randomizeAllNamesToolStripMenuItem";
            this.randomizeAllNamesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.randomizeAllNamesToolStripMenuItem.Text = "Randomize All Names";
            this.randomizeAllNamesToolStripMenuItem.Click += new System.EventHandler(this.randomizeAllNamesToolStripMenuItem_Click);
            // 
            // butDiscard
            // 
            this.butDiscard.Enabled = false;
            this.butDiscard.Location = new System.Drawing.Point(15, 642);
            this.butDiscard.Name = "butDiscard";
            this.butDiscard.Size = new System.Drawing.Size(112, 27);
            this.butDiscard.TabIndex = 11;
            this.butDiscard.Text = "Discard All Changes";
            this.butDiscard.UseVisualStyleBackColor = true;
            this.butDiscard.Click += new System.EventHandler(this.butDiscard_Click);
            // 
            // butCreateRoster
            // 
            this.butCreateRoster.Enabled = false;
            this.butCreateRoster.Location = new System.Drawing.Point(149, 642);
            this.butCreateRoster.Name = "butCreateRoster";
            this.butCreateRoster.Size = new System.Drawing.Size(184, 27);
            this.butCreateRoster.TabIndex = 12;
            this.butCreateRoster.Text = "Create Roster from Selected Cars";
            this.butCreateRoster.UseVisualStyleBackColor = true;
            this.butCreateRoster.Click += new System.EventHandler(this.butCreateRoster_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(726, 567);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(231, 23);
            this.pbProgress.TabIndex = 13;
            // 
            // lblChooseRoster
            // 
            this.lblChooseRoster.AutoSize = true;
            this.lblChooseRoster.Location = new System.Drawing.Point(12, 97);
            this.lblChooseRoster.Name = "lblChooseRoster";
            this.lblChooseRoster.Size = new System.Drawing.Size(77, 13);
            this.lblChooseRoster.TabIndex = 15;
            this.lblChooseRoster.Text = "Choose Roster";
            // 
            // cmbRoster
            // 
            this.cmbRoster.DataSource = this.bsRosters;
            this.cmbRoster.DisplayMember = "Name";
            this.cmbRoster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoster.FormattingEnabled = true;
            this.cmbRoster.Location = new System.Drawing.Point(123, 93);
            this.cmbRoster.Name = "cmbRoster";
            this.cmbRoster.Size = new System.Drawing.Size(121, 21);
            this.cmbRoster.TabIndex = 14;
            this.cmbRoster.SelectedIndexChanged += new System.EventHandler(this.cmbRoster_SelectedIndexChanged);
            // 
            // bsRosters
            // 
            this.bsRosters.DataMember = "Rosters";
            this.bsRosters.DataSource = this.bsMods;
            this.bsRosters.CurrentChanged += new System.EventHandler(this.bsRosters_CurrentChanged);
            // 
            // lblCountCars
            // 
            this.lblCountCars.AutoSize = true;
            this.lblCountCars.Location = new System.Drawing.Point(146, 605);
            this.lblCountCars.Name = "lblCountCars";
            this.lblCountCars.Size = new System.Drawing.Size(71, 13);
            this.lblCountCars.TabIndex = 16;
            this.lblCountCars.Text = "Cars in grid: 0";
            // 
            // lbLog
            // 
            this.lbLog.Location = new System.Drawing.Point(339, 596);
            this.lbLog.Name = "lbLog";
            this.lbLog.ScrollToLast = false;
            this.lbLog.Size = new System.Drawing.Size(618, 73);
            this.lbLog.TabIndex = 10;
            // 
            // grpRatings
            // 
            this.grpRatings.Location = new System.Drawing.Point(726, 77);
            this.grpRatings.Name = "grpRatings";
            this.grpRatings.Ratings = null;
            this.grpRatings.Size = new System.Drawing.Size(231, 499);
            this.grpRatings.TabIndex = 6;
            // 
            // butModifyRatings
            // 
            this.butModifyRatings.Enabled = false;
            this.butModifyRatings.Location = new System.Drawing.Point(746, 45);
            this.butModifyRatings.Name = "butModifyRatings";
            this.butModifyRatings.Size = new System.Drawing.Size(190, 27);
            this.butModifyRatings.TabIndex = 17;
            this.butModifyRatings.Text = "Bulk Modify Ratings Manually";
            this.butModifyRatings.UseVisualStyleBackColor = true;
            this.butModifyRatings.Click += new System.EventHandler(this.butModifyRatings_Click);
            // 
            // butSelectModifiedCars
            // 
            this.butSelectModifiedCars.Enabled = false;
            this.butSelectModifiedCars.Location = new System.Drawing.Point(556, 87);
            this.butSelectModifiedCars.Name = "butSelectModifiedCars";
            this.butSelectModifiedCars.Size = new System.Drawing.Size(164, 27);
            this.butSelectModifiedCars.TabIndex = 18;
            this.butSelectModifiedCars.Text = "Select Modified (0)";
            this.butSelectModifiedCars.UseVisualStyleBackColor = true;
            this.butSelectModifiedCars.Click += new System.EventHandler(this.butSelectModifiedCars_Click);
            // 
            // butSelectAllCars
            // 
            this.butSelectAllCars.Enabled = false;
            this.butSelectAllCars.Location = new System.Drawing.Point(556, 55);
            this.butSelectAllCars.Name = "butSelectAllCars";
            this.butSelectAllCars.Size = new System.Drawing.Size(79, 27);
            this.butSelectAllCars.TabIndex = 19;
            this.butSelectAllCars.Text = "Select All";
            this.butSelectAllCars.UseVisualStyleBackColor = true;
            this.butSelectAllCars.Click += new System.EventHandler(this.butSelectAllCars_Click);
            // 
            // butSelectNoCars
            // 
            this.butSelectNoCars.Enabled = false;
            this.butSelectNoCars.Location = new System.Drawing.Point(641, 55);
            this.butSelectNoCars.Name = "butSelectNoCars";
            this.butSelectNoCars.Size = new System.Drawing.Size(79, 27);
            this.butSelectNoCars.TabIndex = 20;
            this.butSelectNoCars.Text = "Select None";
            this.butSelectNoCars.UseVisualStyleBackColor = true;
            this.butSelectNoCars.Click += new System.EventHandler(this.butSelectNoCars_Click);
            // 
            // cmbNR2003Instance
            // 
            this.cmbNR2003Instance.DataSource = this.bsNR2003Instances;
            this.cmbNR2003Instance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNR2003Instance.FormattingEnabled = true;
            this.cmbNR2003Instance.Location = new System.Drawing.Point(123, 37);
            this.cmbNR2003Instance.Name = "cmbNR2003Instance";
            this.cmbNR2003Instance.Size = new System.Drawing.Size(278, 21);
            this.cmbNR2003Instance.TabIndex = 23;
            this.cmbNR2003Instance.SelectedIndexChanged += new System.EventHandler(this.cmbNR2003Instance_SelectedIndexChanged);
            // 
            // ctxMenuStripCars
            // 
            this.ctxMenuStripCars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyRatingsToolStripMenuItem,
            this.pasteRatingsToolStripMenuItem,
            this.revertToolStripMenuItem});
            this.ctxMenuStripCars.Name = "ctxMenuStripCars";
            this.ctxMenuStripCars.Size = new System.Drawing.Size(165, 70);
            // 
            // copyRatingsToolStripMenuItem
            // 
            this.copyRatingsToolStripMenuItem.Name = "copyRatingsToolStripMenuItem";
            this.copyRatingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyRatingsToolStripMenuItem.Text = "Copy Ratings";
            this.copyRatingsToolStripMenuItem.Click += new System.EventHandler(this.copyRatingsToolStripMenuItem_Click);
            // 
            // pasteRatingsToolStripMenuItem
            // 
            this.pasteRatingsToolStripMenuItem.Name = "pasteRatingsToolStripMenuItem";
            this.pasteRatingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pasteRatingsToolStripMenuItem.Text = "Paste Ratings";
            this.pasteRatingsToolStripMenuItem.Click += new System.EventHandler(this.pasteRatingsToolStripMenuItem_Click);
            // 
            // revertToolStripMenuItem
            // 
            this.revertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revertNameOnlyToolStripMenuItem,
            this.revertRatingsOnlyToolStripMenuItem,
            this.revertCompletelyToolStripMenuItem});
            this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
            this.revertToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.revertToolStripMenuItem.Text = "Revert to original";
            // 
            // revertNameOnlyToolStripMenuItem
            // 
            this.revertNameOnlyToolStripMenuItem.Name = "revertNameOnlyToolStripMenuItem";
            this.revertNameOnlyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.revertNameOnlyToolStripMenuItem.Text = "Name only";
            this.revertNameOnlyToolStripMenuItem.Click += new System.EventHandler(this.revertNameOnlyToolStripMenuItem_Click);
            // 
            // revertRatingsOnlyToolStripMenuItem
            // 
            this.revertRatingsOnlyToolStripMenuItem.Name = "revertRatingsOnlyToolStripMenuItem";
            this.revertRatingsOnlyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.revertRatingsOnlyToolStripMenuItem.Text = "Ratings only";
            this.revertRatingsOnlyToolStripMenuItem.Click += new System.EventHandler(this.revertRatingsOnlyToolStripMenuItem_Click);
            // 
            // revertCompletelyToolStripMenuItem
            // 
            this.revertCompletelyToolStripMenuItem.Name = "revertCompletelyToolStripMenuItem";
            this.revertCompletelyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.revertCompletelyToolStripMenuItem.Text = "Completely";
            this.revertCompletelyToolStripMenuItem.Click += new System.EventHandler(this.revertCompletelyToolStripMenuItem_Click);
            // 
            // lnkDonate
            // 
            this.lnkDonate.AutoSize = true;
            this.lnkDonate.Location = new System.Drawing.Point(106, 689);
            this.lnkDonate.Name = "lnkDonate";
            this.lnkDonate.Size = new System.Drawing.Size(42, 13);
            this.lnkDonate.TabIndex = 24;
            this.lnkDonate.TabStop = true;
            this.lnkDonate.Text = "Donate";
            this.lnkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDonate_LinkClicked);
            // 
            // lblLikingNRatings
            // 
            this.lblLikingNRatings.AutoSize = true;
            this.lblLikingNRatings.Location = new System.Drawing.Point(12, 689);
            this.lblLikingNRatings.Name = "lblLikingNRatings";
            this.lblLikingNRatings.Size = new System.Drawing.Size(88, 13);
            this.lblLikingNRatings.TabIndex = 25;
            this.lblLikingNRatings.Text = "Liking NRatings?";
            // 
            // lnkTwitch
            // 
            this.lnkTwitch.AutoSize = true;
            this.lnkTwitch.Location = new System.Drawing.Point(154, 689);
            this.lnkTwitch.Name = "lnkTwitch";
            this.lnkTwitch.Size = new System.Drawing.Size(141, 13);
            this.lnkTwitch.TabIndex = 26;
            this.lnkTwitch.TabStop = true;
            this.lnkTwitch.Text = "Come and join me on Twitch";
            this.lnkTwitch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTwitch_LinkClicked);
            // 
            // frmNR2003Ratings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.lnkTwitch);
            this.Controls.Add(this.lblLikingNRatings);
            this.Controls.Add(this.lnkDonate);
            this.Controls.Add(this.cmbNR2003Instance);
            this.Controls.Add(this.butSelectNoCars);
            this.Controls.Add(this.butSelectAllCars);
            this.Controls.Add(this.butSelectModifiedCars);
            this.Controls.Add(this.butModifyRatings);
            this.Controls.Add(this.lblCountCars);
            this.Controls.Add(this.lblChooseRoster);
            this.Controls.Add(this.cmbRoster);
            this.Controls.Add(this.butCreateRoster);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.butDiscard);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.butImportRatings);
            this.Controls.Add(this.butSaveModifiedCars);
            this.Controls.Add(this.grpRatings);
            this.Controls.Add(this.dgCars);
            this.Controls.Add(this.lblMod);
            this.Controls.Add(this.cmbMod);
            this.Controls.Add(this.lblInstance);
            this.Controls.Add(this.mnMenu);
            this.MainMenuStrip = this.mnMenu;
            this.Name = "frmNR2003Ratings";
            this.Text = "NRatings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNR2003Ratings_FormClosing);
            this.Load += new System.EventHandler(this.frmNR2003Ratings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNR2003Instances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRealDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCars)).EndInit();
            this.mnMenu.ResumeLayout(false);
            this.mnMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRosters)).EndInit();
            this.ctxMenuStripCars.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstance;
        private System.Windows.Forms.ComboBox cmbMod;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.DataGridView dgCars;
        private RatingsGroup grpRatings;
        private System.Windows.Forms.Button butSaveModifiedCars;
        private System.Windows.Forms.Button butImportRatings;
        private System.Windows.Forms.MenuStrip mnMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private LogBox lbLog;
        private System.Windows.Forms.Button butDiscard;
        private System.Windows.Forms.Button butCreateRoster;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblChooseRoster;
        private System.Windows.Forms.ComboBox cmbRoster;
        private System.Windows.Forms.Label lblCountCars;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button butModifyRatings;
        private System.Windows.Forms.Button butSelectModifiedCars;
        private System.Windows.Forms.Button butSelectAllCars;
        private System.Windows.Forms.Button butSelectNoCars;
        private System.Windows.Forms.ToolStripMenuItem devToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeAllNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitProjectHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbNR2003Instance;
        private System.Windows.Forms.BindingSource bsNR2003Instances;
        private System.Windows.Forms.BindingSource bsMods;
        private System.Windows.Forms.BindingSource bsRosters;
        private System.Windows.Forms.BindingSource bsCars;
        private System.Windows.Forms.BindingSource bsRealDrivers;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn mappedToRealDriverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ContextMenuStrip ctxMenuStripCars;
        private System.Windows.Forms.ToolStripMenuItem revertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertNameOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertRatingsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertCompletelyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRatingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteRatingsToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkDonate;
        private System.Windows.Forms.Label lblLikingNRatings;
        private System.Windows.Forms.LinkLabel lnkTwitch;
    }
}

