namespace NRatings.Client.GUI
{
    partial class RatingsItem
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
            this.udRatingsMax = new System.Windows.Forms.NumericUpDown();
            this.lblRatingsLabel = new System.Windows.Forms.Label();
            this.udRatingsMin = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.udRatingsMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRatingsMin)).BeginInit();
            this.SuspendLayout();
            // 
            // udRatingsMax
            // 
            this.udRatingsMax.Enabled = false;
            this.udRatingsMax.Location = new System.Drawing.Point(157, 3);
            this.udRatingsMax.Name = "udRatingsMax";
            this.udRatingsMax.Size = new System.Drawing.Size(45, 20);
            this.udRatingsMax.TabIndex = 14;
            this.udRatingsMax.ValueChanged += new System.EventHandler(this.udRatingsMax_ValueChanged);
            // 
            // lblRatingsLabel
            // 
            this.lblRatingsLabel.AutoSize = true;
            this.lblRatingsLabel.Location = new System.Drawing.Point(2, 10);
            this.lblRatingsLabel.Name = "lblRatingsLabel";
            this.lblRatingsLabel.Size = new System.Drawing.Size(69, 13);
            this.lblRatingsLabel.TabIndex = 13;
            this.lblRatingsLabel.Text = "RatingsLabel";
            // 
            // udRatingsMin
            // 
            this.udRatingsMin.Enabled = false;
            this.udRatingsMin.Location = new System.Drawing.Point(95, 3);
            this.udRatingsMin.Name = "udRatingsMin";
            this.udRatingsMin.Size = new System.Drawing.Size(45, 20);
            this.udRatingsMin.TabIndex = 12;
            this.udRatingsMin.ValueChanged += new System.EventHandler(this.udRatingsMin_ValueChanged);
            // 
            // RatingsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.udRatingsMax);
            this.Controls.Add(this.lblRatingsLabel);
            this.Controls.Add(this.udRatingsMin);
            this.Name = "RatingsItem";
            this.Size = new System.Drawing.Size(214, 27);
            ((System.ComponentModel.ISupportInitialize)(this.udRatingsMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRatingsMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown udRatingsMax;
        private System.Windows.Forms.Label lblRatingsLabel;
        private System.Windows.Forms.NumericUpDown udRatingsMin;
    }
}
