using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    partial class RatingsFormulaSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpSelectFormulaSet = new System.Windows.Forms.GroupBox();
            this.butSetDefault = new System.Windows.Forms.Button();
            this.cmbFormula = new System.Windows.Forms.ComboBox();
            this.grpFormulaOptions = new System.Windows.Forms.GroupBox();
            this.lblMappingMethod = new System.Windows.Forms.Label();
            this.cmbMappingMethod = new System.Windows.Forms.ComboBox();
            this.bsSelectedFormulaOptions = new System.Windows.Forms.BindingSource(this.components);
            this.bsSelectedFormula = new System.Windows.Forms.BindingSource(this.components);
            this.chkUseNR2003TrackType = new System.Windows.Forms.CheckBox();
            this.chkFOUseDefault = new System.Windows.Forms.CheckBox();
            this.grpDescription = new System.Windows.Forms.GroupBox();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.grpSelectFormulaSet.SuspendLayout();
            this.grpFormulaOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectedFormulaOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectedFormula)).BeginInit();
            this.grpDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelectFormulaSet
            // 
            this.grpSelectFormulaSet.Controls.Add(this.butSetDefault);
            this.grpSelectFormulaSet.Controls.Add(this.cmbFormula);
            this.grpSelectFormulaSet.Location = new System.Drawing.Point(3, 3);
            this.grpSelectFormulaSet.Name = "grpSelectFormulaSet";
            this.grpSelectFormulaSet.Size = new System.Drawing.Size(217, 112);
            this.grpSelectFormulaSet.TabIndex = 13;
            this.grpSelectFormulaSet.TabStop = false;
            this.grpSelectFormulaSet.Text = "Formula set to apply";
            // 
            // butSetDefault
            // 
            this.butSetDefault.Location = new System.Drawing.Point(6, 49);
            this.butSetDefault.Name = "butSetDefault";
            this.butSetDefault.Size = new System.Drawing.Size(94, 23);
            this.butSetDefault.TabIndex = 1;
            this.butSetDefault.Text = "Set As Default";
            this.butSetDefault.UseVisualStyleBackColor = true;
            this.butSetDefault.Click += new System.EventHandler(this.butSetDefault_Click);
            // 
            // cmbFormula
            // 
            this.cmbFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormula.FormattingEnabled = true;
            this.cmbFormula.Location = new System.Drawing.Point(6, 19);
            this.cmbFormula.Name = "cmbFormula";
            this.cmbFormula.Size = new System.Drawing.Size(178, 21);
            this.cmbFormula.TabIndex = 0;
            this.cmbFormula.SelectedIndexChanged += new System.EventHandler(this.cmbFormula_SelectedIndexChanged);
            // 
            // grpFormulaOptions
            // 
            this.grpFormulaOptions.Controls.Add(this.lblMappingMethod);
            this.grpFormulaOptions.Controls.Add(this.cmbMappingMethod);
            this.grpFormulaOptions.Controls.Add(this.chkUseNR2003TrackType);
            this.grpFormulaOptions.Controls.Add(this.chkFOUseDefault);
            this.grpFormulaOptions.Location = new System.Drawing.Point(226, 3);
            this.grpFormulaOptions.Name = "grpFormulaOptions";
            this.grpFormulaOptions.Size = new System.Drawing.Size(211, 112);
            this.grpFormulaOptions.TabIndex = 14;
            this.grpFormulaOptions.TabStop = false;
            this.grpFormulaOptions.Text = "Formula options";
            // 
            // lblMappingMethod
            // 
            this.lblMappingMethod.AutoSize = true;
            this.lblMappingMethod.Location = new System.Drawing.Point(6, 59);
            this.lblMappingMethod.Name = "lblMappingMethod";
            this.lblMappingMethod.Size = new System.Drawing.Size(109, 13);
            this.lblMappingMethod.TabIndex = 6;
            this.lblMappingMethod.Text = "Car Mapping Method:";
            // 
            // cmbMappingMethod
            // 
            this.cmbMappingMethod.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsSelectedFormulaOptions, "MappingMethod", true));
            this.cmbMappingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMappingMethod.FormattingEnabled = true;
            this.cmbMappingMethod.Location = new System.Drawing.Point(6, 75);
            this.cmbMappingMethod.Name = "cmbMappingMethod";
            this.cmbMappingMethod.Size = new System.Drawing.Size(199, 21);
            this.cmbMappingMethod.TabIndex = 5;
            // 
            // bsSelectedFormulaOptions
            // 
            this.bsSelectedFormulaOptions.DataMember = "Options";
            this.bsSelectedFormulaOptions.DataSource = this.bsSelectedFormula;
            // 
            // bsSelectedFormula
            // 
            this.bsSelectedFormula.DataSource = typeof(RatingsFormula);
            // 
            // chkUseNR2003TrackType
            // 
            this.chkUseNR2003TrackType.AutoSize = true;
            this.chkUseNR2003TrackType.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsSelectedFormulaOptions, "UseNr2003TrackTypes", true));
            this.chkUseNR2003TrackType.Location = new System.Drawing.Point(7, 37);
            this.chkUseNR2003TrackType.Name = "chkUseNR2003TrackType";
            this.chkUseNR2003TrackType.Size = new System.Drawing.Size(143, 17);
            this.chkUseNR2003TrackType.TabIndex = 4;
            this.chkUseNR2003TrackType.Text = "Use NR2003 TrackType";
            this.chkUseNR2003TrackType.UseVisualStyleBackColor = true;
            // 
            // chkFOUseDefault
            // 
            this.chkFOUseDefault.AutoSize = true;
            this.chkFOUseDefault.Checked = true;
            this.chkFOUseDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFOUseDefault.Location = new System.Drawing.Point(151, 9);
            this.chkFOUseDefault.Name = "chkFOUseDefault";
            this.chkFOUseDefault.Size = new System.Drawing.Size(60, 17);
            this.chkFOUseDefault.TabIndex = 3;
            this.chkFOUseDefault.Text = "Default";
            this.chkFOUseDefault.UseVisualStyleBackColor = true;
            this.chkFOUseDefault.CheckedChanged += new System.EventHandler(this.chkFOUseDefault_CheckedChanged);
            // 
            // grpDescription
            // 
            this.grpDescription.Controls.Add(this.rtxtDescription);
            this.grpDescription.Location = new System.Drawing.Point(3, 121);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(440, 97);
            this.grpDescription.TabIndex = 15;
            this.grpDescription.TabStop = false;
            this.grpDescription.Text = "Description";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSelectedFormula, "FullDescription", true));
            this.rtxtDescription.Location = new System.Drawing.Point(6, 19);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.ReadOnly = true;
            this.rtxtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDescription.Size = new System.Drawing.Size(428, 62);
            this.rtxtDescription.TabIndex = 0;
            this.rtxtDescription.Text = "";
            // 
            // RatingsFormulaSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDescription);
            this.Controls.Add(this.grpFormulaOptions);
            this.Controls.Add(this.grpSelectFormulaSet);
            this.Name = "RatingsFormulaSelection";
            this.Size = new System.Drawing.Size(459, 236);
            this.grpSelectFormulaSet.ResumeLayout(false);
            this.grpFormulaOptions.ResumeLayout(false);
            this.grpFormulaOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectedFormulaOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectedFormula)).EndInit();
            this.grpDescription.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectFormulaSet;
        private System.Windows.Forms.ComboBox cmbFormula;
        private System.Windows.Forms.GroupBox grpFormulaOptions;
        private System.Windows.Forms.CheckBox chkFOUseDefault;
        private System.Windows.Forms.GroupBox grpDescription;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Button butSetDefault;
        private System.Windows.Forms.BindingSource bsSelectedFormula;
        private System.Windows.Forms.BindingSource bsSelectedFormulaOptions;
        private System.Windows.Forms.CheckBox chkUseNR2003TrackType;
        private System.Windows.Forms.ComboBox cmbMappingMethod;
        private System.Windows.Forms.Label lblMappingMethod;
    }
}
