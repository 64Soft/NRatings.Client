namespace NRatings.Client.GUI
{
    partial class frmModifyRatings
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
            this.grpSelections = new System.Windows.Forms.GroupBox();
            this.butClose = new System.Windows.Forms.Button();
            this.butApply = new System.Windows.Forms.Button();
            this.grpSelectAction = new System.Windows.Forms.GroupBox();
            this.txtRandomizeTo = new System.Windows.Forms.TextBox();
            this.lblRandomizeTo = new System.Windows.Forms.Label();
            this.txtRandomizeFrom = new System.Windows.Forms.TextBox();
            this.lblRandomizeFrom = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtActionValue = new System.Windows.Forms.TextBox();
            this.rbActionSet = new System.Windows.Forms.RadioButton();
            this.rbActionMultiply = new System.Windows.Forms.RadioButton();
            this.rbActionAdd = new System.Windows.Forms.RadioButton();
            this.rbActionRandomize = new System.Windows.Forms.RadioButton();
            this.grpSelectCars = new System.Windows.Forms.GroupBox();
            this.grpGroupModifications = new System.Windows.Forms.GroupBox();
            this.chkGroupByName = new System.Windows.Forms.CheckBox();
            this.chkGroupByNumber = new System.Windows.Forms.CheckBox();
            this.rbAllCars = new System.Windows.Forms.RadioButton();
            this.rbSelectedCars = new System.Windows.Forms.RadioButton();
            this.rbCurrentCar = new System.Windows.Forms.RadioButton();
            this.grpSelectRatings = new System.Windows.Forms.GroupBox();
            this.rbRatingsBoth = new System.Windows.Forms.RadioButton();
            this.rbRatingsMax = new System.Windows.Forms.RadioButton();
            this.rbRatingsMin = new System.Windows.Forms.RadioButton();
            this.chkSelectAllRatings = new System.Windows.Forms.CheckBox();
            this.chkRatings = new cCheckedListBox();
            this.grpSelections.SuspendLayout();
            this.grpSelectAction.SuspendLayout();
            this.grpSelectCars.SuspendLayout();
            this.grpGroupModifications.SuspendLayout();
            this.grpSelectRatings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelections
            // 
            this.grpSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelections.Controls.Add(this.grpGroupModifications);
            this.grpSelections.Controls.Add(this.butClose);
            this.grpSelections.Controls.Add(this.butApply);
            this.grpSelections.Controls.Add(this.grpSelectAction);
            this.grpSelections.Controls.Add(this.grpSelectCars);
            this.grpSelections.Controls.Add(this.grpSelectRatings);
            this.grpSelections.Location = new System.Drawing.Point(12, 12);
            this.grpSelections.Name = "grpSelections";
            this.grpSelections.Size = new System.Drawing.Size(644, 483);
            this.grpSelections.TabIndex = 0;
            this.grpSelections.TabStop = false;
            this.grpSelections.Text = "Make Your Selections";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(552, 437);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(73, 23);
            this.butClose.TabIndex = 4;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butApply
            // 
            this.butApply.Location = new System.Drawing.Point(471, 437);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 3;
            this.butApply.Text = "Apply";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // grpSelectAction
            // 
            this.grpSelectAction.Controls.Add(this.txtRandomizeTo);
            this.grpSelectAction.Controls.Add(this.lblRandomizeTo);
            this.grpSelectAction.Controls.Add(this.txtRandomizeFrom);
            this.grpSelectAction.Controls.Add(this.lblRandomizeFrom);
            this.grpSelectAction.Controls.Add(this.lblValue);
            this.grpSelectAction.Controls.Add(this.txtActionValue);
            this.grpSelectAction.Controls.Add(this.rbActionSet);
            this.grpSelectAction.Controls.Add(this.rbActionMultiply);
            this.grpSelectAction.Controls.Add(this.rbActionAdd);
            this.grpSelectAction.Controls.Add(this.rbActionRandomize);
            this.grpSelectAction.Location = new System.Drawing.Point(267, 174);
            this.grpSelectAction.Name = "grpSelectAction";
            this.grpSelectAction.Size = new System.Drawing.Size(358, 206);
            this.grpSelectAction.TabIndex = 2;
            this.grpSelectAction.TabStop = false;
            this.grpSelectAction.Text = "3. Select the action to perform";
            // 
            // txtRandomizeTo
            // 
            this.txtRandomizeTo.Location = new System.Drawing.Point(239, 28);
            this.txtRandomizeTo.Name = "txtRandomizeTo";
            this.txtRandomizeTo.Size = new System.Drawing.Size(51, 20);
            this.txtRandomizeTo.TabIndex = 9;
            this.txtRandomizeTo.Text = "100";
            this.txtRandomizeTo.TextChanged += new System.EventHandler(this.txtValueBox_TextChanged);
            // 
            // lblRandomizeTo
            // 
            this.lblRandomizeTo.AutoSize = true;
            this.lblRandomizeTo.Location = new System.Drawing.Point(211, 32);
            this.lblRandomizeTo.Name = "lblRandomizeTo";
            this.lblRandomizeTo.Size = new System.Drawing.Size(25, 13);
            this.lblRandomizeTo.TabIndex = 8;
            this.lblRandomizeTo.Text = "and";
            // 
            // txtRandomizeFrom
            // 
            this.txtRandomizeFrom.Location = new System.Drawing.Point(157, 28);
            this.txtRandomizeFrom.Name = "txtRandomizeFrom";
            this.txtRandomizeFrom.Size = new System.Drawing.Size(51, 20);
            this.txtRandomizeFrom.TabIndex = 7;
            this.txtRandomizeFrom.Text = "0";
            this.txtRandomizeFrom.TextChanged += new System.EventHandler(this.txtValueBox_TextChanged);
            // 
            // lblRandomizeFrom
            // 
            this.lblRandomizeFrom.AutoSize = true;
            this.lblRandomizeFrom.Location = new System.Drawing.Point(106, 32);
            this.lblRandomizeFrom.Name = "lblRandomizeFrom";
            this.lblRandomizeFrom.Size = new System.Drawing.Size(48, 13);
            this.lblRandomizeFrom.TabIndex = 6;
            this.lblRandomizeFrom.Text = "between";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(25, 139);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "Value:";
            // 
            // txtActionValue
            // 
            this.txtActionValue.Location = new System.Drawing.Point(25, 158);
            this.txtActionValue.Name = "txtActionValue";
            this.txtActionValue.Size = new System.Drawing.Size(51, 20);
            this.txtActionValue.TabIndex = 4;
            this.txtActionValue.TextChanged += new System.EventHandler(this.txtValueBox_TextChanged);
            // 
            // rbActionSet
            // 
            this.rbActionSet.AutoSize = true;
            this.rbActionSet.Location = new System.Drawing.Point(25, 99);
            this.rbActionSet.Name = "rbActionSet";
            this.rbActionSet.Size = new System.Drawing.Size(87, 17);
            this.rbActionSet.TabIndex = 3;
            this.rbActionSet.Text = "Set To Value";
            this.rbActionSet.UseVisualStyleBackColor = true;
            this.rbActionSet.CheckedChanged += new System.EventHandler(this.rbAction_CheckedChanged);
            // 
            // rbActionMultiply
            // 
            this.rbActionMultiply.AutoSize = true;
            this.rbActionMultiply.Location = new System.Drawing.Point(25, 76);
            this.rbActionMultiply.Name = "rbActionMultiply";
            this.rbActionMultiply.Size = new System.Drawing.Size(105, 17);
            this.rbActionMultiply.TabIndex = 2;
            this.rbActionMultiply.Text = "Multiply By Value";
            this.rbActionMultiply.UseVisualStyleBackColor = true;
            this.rbActionMultiply.CheckedChanged += new System.EventHandler(this.rbAction_CheckedChanged);
            // 
            // rbActionAdd
            // 
            this.rbActionAdd.AutoSize = true;
            this.rbActionAdd.Location = new System.Drawing.Point(25, 53);
            this.rbActionAdd.Name = "rbActionAdd";
            this.rbActionAdd.Size = new System.Drawing.Size(74, 17);
            this.rbActionAdd.TabIndex = 1;
            this.rbActionAdd.Text = "Add Value";
            this.rbActionAdd.UseVisualStyleBackColor = true;
            this.rbActionAdd.CheckedChanged += new System.EventHandler(this.rbAction_CheckedChanged);
            // 
            // rbActionRandomize
            // 
            this.rbActionRandomize.AutoSize = true;
            this.rbActionRandomize.Checked = true;
            this.rbActionRandomize.Location = new System.Drawing.Point(25, 30);
            this.rbActionRandomize.Name = "rbActionRandomize";
            this.rbActionRandomize.Size = new System.Drawing.Size(78, 17);
            this.rbActionRandomize.TabIndex = 0;
            this.rbActionRandomize.TabStop = true;
            this.rbActionRandomize.Text = "Randomize";
            this.rbActionRandomize.UseVisualStyleBackColor = true;
            this.rbActionRandomize.CheckedChanged += new System.EventHandler(this.rbAction_CheckedChanged);
            // 
            // grpSelectCars
            // 
            this.grpSelectCars.Controls.Add(this.rbAllCars);
            this.grpSelectCars.Controls.Add(this.rbSelectedCars);
            this.grpSelectCars.Controls.Add(this.rbCurrentCar);
            this.grpSelectCars.Location = new System.Drawing.Point(267, 29);
            this.grpSelectCars.Name = "grpSelectCars";
            this.grpSelectCars.Size = new System.Drawing.Size(358, 129);
            this.grpSelectCars.TabIndex = 1;
            this.grpSelectCars.TabStop = false;
            this.grpSelectCars.Text = "2. Select the cars you want to change";
            // 
            // grpGroupModifications
            // 
            this.grpGroupModifications.Controls.Add(this.chkGroupByName);
            this.grpGroupModifications.Controls.Add(this.chkGroupByNumber);
            this.grpGroupModifications.Location = new System.Drawing.Point(267, 389);
            this.grpGroupModifications.Name = "grpGroupModifications";
            this.grpGroupModifications.Size = new System.Drawing.Size(198, 71);
            this.grpGroupModifications.TabIndex = 3;
            this.grpGroupModifications.TabStop = false;
            this.grpGroupModifications.Text = "4. Group modifications by (optional)";
            // 
            // chkGroupByName
            // 
            this.chkGroupByName.AutoSize = true;
            this.chkGroupByName.Location = new System.Drawing.Point(16, 46);
            this.chkGroupByName.Name = "chkGroupByName";
            this.chkGroupByName.Size = new System.Drawing.Size(54, 17);
            this.chkGroupByName.TabIndex = 1;
            this.chkGroupByName.Text = "Name";
            this.chkGroupByName.UseVisualStyleBackColor = true;
            // 
            // chkGroupByNumber
            // 
            this.chkGroupByNumber.AutoSize = true;
            this.chkGroupByNumber.Location = new System.Drawing.Point(16, 23);
            this.chkGroupByNumber.Name = "chkGroupByNumber";
            this.chkGroupByNumber.Size = new System.Drawing.Size(63, 17);
            this.chkGroupByNumber.TabIndex = 0;
            this.chkGroupByNumber.Text = "Number";
            this.chkGroupByNumber.UseVisualStyleBackColor = true;
            // 
            // rbAllCars
            // 
            this.rbAllCars.AutoSize = true;
            this.rbAllCars.Location = new System.Drawing.Point(22, 76);
            this.rbAllCars.Name = "rbAllCars";
            this.rbAllCars.Size = new System.Drawing.Size(36, 17);
            this.rbAllCars.TabIndex = 2;
            this.rbAllCars.Text = "All";
            this.rbAllCars.UseVisualStyleBackColor = true;
            this.rbAllCars.CheckedChanged += new System.EventHandler(this.rbCarSelection_CheckedChanged);
            // 
            // rbSelectedCars
            // 
            this.rbSelectedCars.AutoSize = true;
            this.rbSelectedCars.Location = new System.Drawing.Point(22, 53);
            this.rbSelectedCars.Name = "rbSelectedCars";
            this.rbSelectedCars.Size = new System.Drawing.Size(67, 17);
            this.rbSelectedCars.TabIndex = 1;
            this.rbSelectedCars.Text = "Selected";
            this.rbSelectedCars.UseVisualStyleBackColor = true;
            this.rbSelectedCars.CheckedChanged += new System.EventHandler(this.rbCarSelection_CheckedChanged);
            // 
            // rbCurrentCar
            // 
            this.rbCurrentCar.AutoSize = true;
            this.rbCurrentCar.Checked = true;
            this.rbCurrentCar.Location = new System.Drawing.Point(22, 29);
            this.rbCurrentCar.Name = "rbCurrentCar";
            this.rbCurrentCar.Size = new System.Drawing.Size(59, 17);
            this.rbCurrentCar.TabIndex = 0;
            this.rbCurrentCar.TabStop = true;
            this.rbCurrentCar.Text = "Current";
            this.rbCurrentCar.UseVisualStyleBackColor = true;
            this.rbCurrentCar.CheckedChanged += new System.EventHandler(this.rbCarSelection_CheckedChanged);
            // 
            // grpSelectRatings
            // 
            this.grpSelectRatings.Controls.Add(this.rbRatingsBoth);
            this.grpSelectRatings.Controls.Add(this.rbRatingsMax);
            this.grpSelectRatings.Controls.Add(this.rbRatingsMin);
            this.grpSelectRatings.Controls.Add(this.chkSelectAllRatings);
            this.grpSelectRatings.Controls.Add(this.chkRatings);
            this.grpSelectRatings.Location = new System.Drawing.Point(15, 29);
            this.grpSelectRatings.Name = "grpSelectRatings";
            this.grpSelectRatings.Size = new System.Drawing.Size(220, 448);
            this.grpSelectRatings.TabIndex = 0;
            this.grpSelectRatings.TabStop = false;
            this.grpSelectRatings.Text = "1. Select the ratings you want to change";
            // 
            // rbRatingsBoth
            // 
            this.rbRatingsBoth.AutoSize = true;
            this.rbRatingsBoth.Checked = true;
            this.rbRatingsBoth.Location = new System.Drawing.Point(19, 380);
            this.rbRatingsBoth.Name = "rbRatingsBoth";
            this.rbRatingsBoth.Size = new System.Drawing.Size(47, 17);
            this.rbRatingsBoth.TabIndex = 4;
            this.rbRatingsBoth.TabStop = true;
            this.rbRatingsBoth.Text = "Both";
            this.rbRatingsBoth.UseVisualStyleBackColor = true;
            this.rbRatingsBoth.CheckedChanged += new System.EventHandler(this.rbRatingsType_CheckedChanged);
            // 
            // rbRatingsMax
            // 
            this.rbRatingsMax.AutoSize = true;
            this.rbRatingsMax.Location = new System.Drawing.Point(18, 357);
            this.rbRatingsMax.Name = "rbRatingsMax";
            this.rbRatingsMax.Size = new System.Drawing.Size(69, 17);
            this.rbRatingsMax.TabIndex = 3;
            this.rbRatingsMax.Text = "Max Only";
            this.rbRatingsMax.UseVisualStyleBackColor = true;
            this.rbRatingsMax.CheckedChanged += new System.EventHandler(this.rbRatingsType_CheckedChanged);
            // 
            // rbRatingsMin
            // 
            this.rbRatingsMin.AutoSize = true;
            this.rbRatingsMin.Location = new System.Drawing.Point(18, 334);
            this.rbRatingsMin.Name = "rbRatingsMin";
            this.rbRatingsMin.Size = new System.Drawing.Size(66, 17);
            this.rbRatingsMin.TabIndex = 2;
            this.rbRatingsMin.Text = "Min Only";
            this.rbRatingsMin.UseVisualStyleBackColor = true;
            this.rbRatingsMin.CheckedChanged += new System.EventHandler(this.rbRatingsType_CheckedChanged);
            // 
            // chkSelectAllRatings
            // 
            this.chkSelectAllRatings.AutoSize = true;
            this.chkSelectAllRatings.Location = new System.Drawing.Point(18, 30);
            this.chkSelectAllRatings.Name = "chkSelectAllRatings";
            this.chkSelectAllRatings.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAllRatings.TabIndex = 1;
            this.chkSelectAllRatings.Text = "Select All";
            this.chkSelectAllRatings.UseVisualStyleBackColor = true;
            this.chkSelectAllRatings.CheckedChanged += new System.EventHandler(this.chkSelectAllRatings_CheckedChanged);
            // 
            // chkRatings
            // 
            this.chkRatings.CheckOnClick = true;
            this.chkRatings.DataSource = null;
            this.chkRatings.FormattingEnabled = true;
            this.chkRatings.Location = new System.Drawing.Point(18, 53);
            this.chkRatings.Name = "chkRatings";
            this.chkRatings.Size = new System.Drawing.Size(183, 259);
            this.chkRatings.TabIndex = 0;
            this.chkRatings.SelectedIndexChanged += new System.EventHandler(this.chkRatings_SelectedIndexChanged);
            // 
            // frmModifyRatings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 507);
            this.Controls.Add(this.grpSelections);
            this.Name = "frmModifyRatings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Selected Ratings";
            this.Load += new System.EventHandler(this.frmModifyRatings_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModifyRatings_FormClosing);
            this.grpSelections.ResumeLayout(false);
            this.grpSelectAction.ResumeLayout(false);
            this.grpSelectAction.PerformLayout();
            this.grpSelectCars.ResumeLayout(false);
            this.grpSelectCars.PerformLayout();
            this.grpGroupModifications.ResumeLayout(false);
            this.grpGroupModifications.PerformLayout();
            this.grpSelectRatings.ResumeLayout(false);
            this.grpSelectRatings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelections;
        private System.Windows.Forms.GroupBox grpSelectRatings;
        private cCheckedListBox chkRatings;
        private System.Windows.Forms.CheckBox chkSelectAllRatings;
        private System.Windows.Forms.GroupBox grpSelectCars;
        private System.Windows.Forms.RadioButton rbAllCars;
        private System.Windows.Forms.RadioButton rbSelectedCars;
        private System.Windows.Forms.RadioButton rbCurrentCar;
        private System.Windows.Forms.GroupBox grpSelectAction;
        private System.Windows.Forms.RadioButton rbActionRandomize;
        private System.Windows.Forms.RadioButton rbActionMultiply;
        private System.Windows.Forms.RadioButton rbActionAdd;
        private System.Windows.Forms.RadioButton rbActionSet;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtActionValue;
        private System.Windows.Forms.Label lblRandomizeFrom;
        private System.Windows.Forms.TextBox txtRandomizeTo;
        private System.Windows.Forms.Label lblRandomizeTo;
        private System.Windows.Forms.TextBox txtRandomizeFrom;
        private System.Windows.Forms.RadioButton rbRatingsBoth;
        private System.Windows.Forms.RadioButton rbRatingsMax;
        private System.Windows.Forms.RadioButton rbRatingsMin;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.GroupBox grpGroupModifications;
        private System.Windows.Forms.CheckBox chkGroupByName;
        private System.Windows.Forms.CheckBox chkGroupByNumber;


    }
}