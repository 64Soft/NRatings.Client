using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class frmUserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserSettings));
            this.bsNR2003Instances = new System.Windows.Forms.BindingSource(this.components);
            this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.butOK = new System.Windows.Forms.Button();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.grpInstances = new System.Windows.Forms.GroupBox();
            this.bnNR2003Instances = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgNR2003Instances = new System.Windows.Forms.DataGridView();
            this.browseDataGridViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.butLogin = new System.Windows.Forms.Button();
            this.butLogout = new System.Windows.Forms.Button();
            this.bsUserSettings = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDefaultDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsNR2003Instances)).BeginInit();
            this.grpUserInfo.SuspendLayout();
            this.grpInstances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnNR2003Instances)).BeginInit();
            this.bnNR2003Instances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNR2003Instances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // bsNR2003Instances
            // 
            this.bsNR2003Instances.DataMember = "NR2003Instances";
            this.bsNR2003Instances.DataSource = this.bsUserSettings;
            // 
            // fbDialog
            // 
            this.fbDialog.Description = "Select the path to your NR2003 folder";
            this.fbDialog.ShowNewFolderButton = false;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(555, 387);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUserInfo.Controls.Add(this.butLogout);
            this.grpUserInfo.Controls.Add(this.butLogin);
            this.grpUserInfo.Controls.Add(this.txtUserInfo);
            this.grpUserInfo.Location = new System.Drawing.Point(12, 12);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(621, 94);
            this.grpUserInfo.TabIndex = 3;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "User Information";
            // 
            // lblHelp
            // 
            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(16, 371);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(436, 39);
            this.lblHelp.TabIndex = 2;
            this.lblHelp.Text = resources.GetString("lblHelp.Text");
            // 
            // grpInstances
            // 
            this.grpInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInstances.Controls.Add(this.bnNR2003Instances);
            this.grpInstances.Controls.Add(this.dgNR2003Instances);
            this.grpInstances.Location = new System.Drawing.Point(12, 112);
            this.grpInstances.Name = "grpInstances";
            this.grpInstances.Size = new System.Drawing.Size(621, 256);
            this.grpInstances.TabIndex = 0;
            this.grpInstances.TabStop = false;
            this.grpInstances.Text = "NR2003 Instances";
            // 
            // bnNR2003Instances
            // 
            this.bnNR2003Instances.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bnNR2003Instances.BindingSource = this.bsNR2003Instances;
            this.bnNR2003Instances.CountItem = this.bindingNavigatorCountItem;
            this.bnNR2003Instances.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bnNR2003Instances.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnNR2003Instances.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bnNR2003Instances.Location = new System.Drawing.Point(3, 228);
            this.bnNR2003Instances.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnNR2003Instances.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnNR2003Instances.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnNR2003Instances.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnNR2003Instances.Name = "bnNR2003Instances";
            this.bnNR2003Instances.PositionItem = this.bindingNavigatorPositionItem;
            this.bnNR2003Instances.Size = new System.Drawing.Size(615, 25);
            this.bnNR2003Instances.TabIndex = 1;
            this.bnNR2003Instances.Text = "NR2003 Instances";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dgNR2003Instances
            // 
            this.dgNR2003Instances.AllowUserToAddRows = false;
            this.dgNR2003Instances.AllowUserToDeleteRows = false;
            this.dgNR2003Instances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNR2003Instances.AutoGenerateColumns = false;
            this.dgNR2003Instances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNR2003Instances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.browseDataGridViewButtonColumn,
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.isDefaultDataGridViewCheckBoxColumn});
            this.dgNR2003Instances.DataSource = this.bsNR2003Instances;
            this.dgNR2003Instances.Location = new System.Drawing.Point(7, 28);
            this.dgNR2003Instances.Name = "dgNR2003Instances";
            this.dgNR2003Instances.Size = new System.Drawing.Size(609, 197);
            this.dgNR2003Instances.TabIndex = 0;
            this.dgNR2003Instances.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgNR2003Instances_CellBeginEdit);
            this.dgNR2003Instances.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNR2003Instances_CellContentClick);
            this.dgNR2003Instances.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNR2003Instances_CellContentDoubleClick);
            this.dgNR2003Instances.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNR2003Instances_CellEndEdit);
            this.dgNR2003Instances.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNR2003Instances_CellValueChanged);
            this.dgNR2003Instances.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgNR2003Instances_RowsAdded);
            // 
            // browseDataGridViewButtonColumn
            // 
            this.browseDataGridViewButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.browseDataGridViewButtonColumn.HeaderText = "";
            this.browseDataGridViewButtonColumn.Name = "browseDataGridViewButtonColumn";
            this.browseDataGridViewButtonColumn.ReadOnly = true;
            this.browseDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.browseDataGridViewButtonColumn.Text = "...";
            this.browseDataGridViewButtonColumn.UseColumnTextForButtonValue = true;
            this.browseDataGridViewButtonColumn.Width = 30;
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUserInfo.Location = new System.Drawing.Point(7, 19);
            this.txtUserInfo.Multiline = true;
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.Size = new System.Drawing.Size(237, 69);
            this.txtUserInfo.TabIndex = 0;
            // 
            // butLogin
            // 
            this.butLogin.Enabled = false;
            this.butLogin.Location = new System.Drawing.Point(250, 19);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(102, 23);
            this.butLogin.TabIndex = 1;
            this.butLogin.Text = "Log In";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // butLogout
            // 
            this.butLogout.Enabled = false;
            this.butLogout.Location = new System.Drawing.Point(250, 48);
            this.butLogout.Name = "butLogout";
            this.butLogout.Size = new System.Drawing.Size(102, 23);
            this.butLogout.TabIndex = 2;
            this.butLogout.Text = "Log Out";
            this.butLogout.UseVisualStyleBackColor = true;
            this.butLogout.Click += new System.EventHandler(this.butLogout_Click);
            // 
            // bsUserSettings
            // 
            this.bsUserSettings.DataSource = typeof(NRatings.Client.Domain.UserSettings);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // isDefaultDataGridViewCheckBoxColumn
            // 
            this.isDefaultDataGridViewCheckBoxColumn.DataPropertyName = "IsDefault";
            this.isDefaultDataGridViewCheckBoxColumn.HeaderText = "IsDefault";
            this.isDefaultDataGridViewCheckBoxColumn.Name = "isDefaultDataGridViewCheckBoxColumn";
            // 
            // frmUserSettings
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 419);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.grpInstances);
            this.Name = "frmUserSettings";
            this.Text = "User Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUserSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bsNR2003Instances)).EndInit();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.grpInstances.ResumeLayout(false);
            this.grpInstances.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnNR2003Instances)).EndInit();
            this.bnNR2003Instances.ResumeLayout(false);
            this.bnNR2003Instances.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNR2003Instances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsUserSettings;
        private System.Windows.Forms.GroupBox grpInstances;
        private System.Windows.Forms.DataGridView dgNR2003Instances;
        private System.Windows.Forms.BindingSource bsNR2003Instances;
        private System.Windows.Forms.BindingNavigator bnNR2003Instances;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn browseDataGridViewButtonColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDefaultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.FolderBrowserDialog fbDialog;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Button butLogout;
    }
}