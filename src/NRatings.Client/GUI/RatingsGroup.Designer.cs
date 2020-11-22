namespace NRatings.Client.GUI
{
    partial class RatingsGroup
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
            this.grpRatings = new System.Windows.Forms.GroupBox();
            this.lblRatingsPitcrew = new System.Windows.Forms.Label();
            this.lblRatingsVehicle = new System.Windows.Forms.Label();
            this.lblRatingsMax = new System.Windows.Forms.Label();
            this.lblRatingsMin = new System.Windows.Forms.Label();
            this.lblRatingsDriver = new System.Windows.Forms.Label();
            this.riPitcrewStrategy = new RatingsItem();
            this.riPitcrewSpeed = new RatingsItem();
            this.riPitcrewConsistency = new RatingsItem();
            this.riVehicleReliability = new RatingsItem();
            this.riVehicleEngine = new RatingsItem();
            this.riVehicleChassis = new RatingsItem();
            this.riVehicleAero = new RatingsItem();
            this.riDriverSuperSpeedway = new RatingsItem();
            this.riDriverSpeedway = new RatingsItem();
            this.riDriverShortTrack = new RatingsItem();
            this.riDriverRoadCourse = new RatingsItem();
            this.riDriverQualifying = new RatingsItem();
            this.riDriverFinishing = new RatingsItem();
            this.riDriverConsistency = new RatingsItem();
            this.riDriverAggression = new RatingsItem();
            this.grpRatings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRatings
            // 
            this.grpRatings.Controls.Add(this.riPitcrewStrategy);
            this.grpRatings.Controls.Add(this.riPitcrewSpeed);
            this.grpRatings.Controls.Add(this.riPitcrewConsistency);
            this.grpRatings.Controls.Add(this.lblRatingsPitcrew);
            this.grpRatings.Controls.Add(this.riVehicleReliability);
            this.grpRatings.Controls.Add(this.riVehicleEngine);
            this.grpRatings.Controls.Add(this.riVehicleChassis);
            this.grpRatings.Controls.Add(this.riVehicleAero);
            this.grpRatings.Controls.Add(this.lblRatingsVehicle);
            this.grpRatings.Controls.Add(this.riDriverSuperSpeedway);
            this.grpRatings.Controls.Add(this.riDriverSpeedway);
            this.grpRatings.Controls.Add(this.riDriverShortTrack);
            this.grpRatings.Controls.Add(this.riDriverRoadCourse);
            this.grpRatings.Controls.Add(this.riDriverQualifying);
            this.grpRatings.Controls.Add(this.riDriverFinishing);
            this.grpRatings.Controls.Add(this.riDriverConsistency);
            this.grpRatings.Controls.Add(this.riDriverAggression);
            this.grpRatings.Controls.Add(this.lblRatingsMax);
            this.grpRatings.Controls.Add(this.lblRatingsMin);
            this.grpRatings.Controls.Add(this.lblRatingsDriver);
            this.grpRatings.Location = new System.Drawing.Point(3, 3);
            this.grpRatings.Name = "grpRatings";
            this.grpRatings.Size = new System.Drawing.Size(225, 482);
            this.grpRatings.TabIndex = 7;
            this.grpRatings.TabStop = false;
            this.grpRatings.Text = "Ratings";
            // 
            // lblRatingsPitcrew
            // 
            this.lblRatingsPitcrew.AutoSize = true;
            this.lblRatingsPitcrew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatingsPitcrew.Location = new System.Drawing.Point(6, 382);
            this.lblRatingsPitcrew.Name = "lblRatingsPitcrew";
            this.lblRatingsPitcrew.Size = new System.Drawing.Size(49, 13);
            this.lblRatingsPitcrew.TabIndex = 29;
            this.lblRatingsPitcrew.Text = "Pitcrew";
            // 
            // lblRatingsVehicle
            // 
            this.lblRatingsVehicle.AutoSize = true;
            this.lblRatingsVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatingsVehicle.Location = new System.Drawing.Point(6, 253);
            this.lblRatingsVehicle.Name = "lblRatingsVehicle";
            this.lblRatingsVehicle.Size = new System.Drawing.Size(49, 13);
            this.lblRatingsVehicle.TabIndex = 24;
            this.lblRatingsVehicle.Text = "Vehicle";
            // 
            // lblRatingsMax
            // 
            this.lblRatingsMax.AutoSize = true;
            this.lblRatingsMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatingsMax.Location = new System.Drawing.Point(171, 19);
            this.lblRatingsMax.Name = "lblRatingsMax";
            this.lblRatingsMax.Size = new System.Drawing.Size(30, 13);
            this.lblRatingsMax.TabIndex = 8;
            this.lblRatingsMax.Text = "Max";
            // 
            // lblRatingsMin
            // 
            this.lblRatingsMin.AutoSize = true;
            this.lblRatingsMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatingsMin.Location = new System.Drawing.Point(104, 19);
            this.lblRatingsMin.Name = "lblRatingsMin";
            this.lblRatingsMin.Size = new System.Drawing.Size(27, 13);
            this.lblRatingsMin.TabIndex = 7;
            this.lblRatingsMin.Text = "Min";
            // 
            // lblRatingsDriver
            // 
            this.lblRatingsDriver.AutoSize = true;
            this.lblRatingsDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatingsDriver.Location = new System.Drawing.Point(6, 22);
            this.lblRatingsDriver.Name = "lblRatingsDriver";
            this.lblRatingsDriver.Size = new System.Drawing.Size(41, 13);
            this.lblRatingsDriver.TabIndex = 0;
            this.lblRatingsDriver.Text = "Driver";
            // 
            // riPitcrewStrategy
            // 
            this.riPitcrewStrategy.LabelText = "Strategy";
            this.riPitcrewStrategy.Location = new System.Drawing.Point(9, 446);
            this.riPitcrewStrategy.Name = "riPitcrewStrategy";
            this.riPitcrewStrategy.Size = new System.Drawing.Size(214, 27);
            this.riPitcrewStrategy.TabIndex = 32;
            this.riPitcrewStrategy.TrackChanges = false;
            // 
            // riPitcrewSpeed
            // 
            this.riPitcrewSpeed.LabelText = "Speed";
            this.riPitcrewSpeed.Location = new System.Drawing.Point(9, 421);
            this.riPitcrewSpeed.Name = "riPitcrewSpeed";
            this.riPitcrewSpeed.Size = new System.Drawing.Size(214, 27);
            this.riPitcrewSpeed.TabIndex = 31;
            this.riPitcrewSpeed.TrackChanges = false;
            // 
            // riPitcrewConsistency
            // 
            this.riPitcrewConsistency.LabelText = "Consistency";
            this.riPitcrewConsistency.Location = new System.Drawing.Point(9, 396);
            this.riPitcrewConsistency.Name = "riPitcrewConsistency";
            this.riPitcrewConsistency.Size = new System.Drawing.Size(214, 27);
            this.riPitcrewConsistency.TabIndex = 30;
            this.riPitcrewConsistency.TrackChanges = false;
            // 
            // riVehicleReliability
            // 
            this.riVehicleReliability.LabelText = "Reliability";
            this.riVehicleReliability.Location = new System.Drawing.Point(9, 344);
            this.riVehicleReliability.Name = "riVehicleReliability";
            this.riVehicleReliability.Size = new System.Drawing.Size(214, 27);
            this.riVehicleReliability.TabIndex = 28;
            this.riVehicleReliability.TrackChanges = false;
            // 
            // riVehicleEngine
            // 
            this.riVehicleEngine.LabelText = "Engine";
            this.riVehicleEngine.Location = new System.Drawing.Point(9, 319);
            this.riVehicleEngine.Name = "riVehicleEngine";
            this.riVehicleEngine.Size = new System.Drawing.Size(214, 27);
            this.riVehicleEngine.TabIndex = 27;
            this.riVehicleEngine.TrackChanges = false;
            // 
            // riVehicleChassis
            // 
            this.riVehicleChassis.LabelText = "Chassis";
            this.riVehicleChassis.Location = new System.Drawing.Point(9, 294);
            this.riVehicleChassis.Name = "riVehicleChassis";
            this.riVehicleChassis.Size = new System.Drawing.Size(214, 27);
            this.riVehicleChassis.TabIndex = 26;
            this.riVehicleChassis.TrackChanges = false;
            // 
            // riVehicleAero
            // 
            this.riVehicleAero.LabelText = "Aerodynamics";
            this.riVehicleAero.Location = new System.Drawing.Point(9, 269);
            this.riVehicleAero.Name = "riVehicleAero";
            this.riVehicleAero.Size = new System.Drawing.Size(214, 27);
            this.riVehicleAero.TabIndex = 25;
            this.riVehicleAero.TrackChanges = false;
            // 
            // riDriverSuperSpeedway
            // 
            this.riDriverSuperSpeedway.LabelText = "Super Speedway";
            this.riDriverSuperSpeedway.Location = new System.Drawing.Point(9, 213);
            this.riDriverSuperSpeedway.Name = "riDriverSuperSpeedway";
            this.riDriverSuperSpeedway.Size = new System.Drawing.Size(214, 27);
            this.riDriverSuperSpeedway.TabIndex = 23;
            this.riDriverSuperSpeedway.TrackChanges = false;
            // 
            // riDriverSpeedway
            // 
            this.riDriverSpeedway.LabelText = "Speedway";
            this.riDriverSpeedway.Location = new System.Drawing.Point(9, 188);
            this.riDriverSpeedway.Name = "riDriverSpeedway";
            this.riDriverSpeedway.Size = new System.Drawing.Size(214, 27);
            this.riDriverSpeedway.TabIndex = 22;
            this.riDriverSpeedway.TrackChanges = false;
            // 
            // riDriverShortTrack
            // 
            this.riDriverShortTrack.LabelText = "Short Track";
            this.riDriverShortTrack.Location = new System.Drawing.Point(9, 163);
            this.riDriverShortTrack.Name = "riDriverShortTrack";
            this.riDriverShortTrack.Size = new System.Drawing.Size(214, 27);
            this.riDriverShortTrack.TabIndex = 21;
            this.riDriverShortTrack.TrackChanges = false;
            // 
            // riDriverRoadCourse
            // 
            this.riDriverRoadCourse.LabelText = "Road Course";
            this.riDriverRoadCourse.Location = new System.Drawing.Point(9, 138);
            this.riDriverRoadCourse.Name = "riDriverRoadCourse";
            this.riDriverRoadCourse.Size = new System.Drawing.Size(214, 27);
            this.riDriverRoadCourse.TabIndex = 20;
            this.riDriverRoadCourse.TrackChanges = false;
            // 
            // riDriverQualifying
            // 
            this.riDriverQualifying.LabelText = "Qualifying";
            this.riDriverQualifying.Location = new System.Drawing.Point(9, 113);
            this.riDriverQualifying.Name = "riDriverQualifying";
            this.riDriverQualifying.Size = new System.Drawing.Size(214, 27);
            this.riDriverQualifying.TabIndex = 19;
            this.riDriverQualifying.TrackChanges = false;
            // 
            // riDriverFinishing
            // 
            this.riDriverFinishing.LabelText = "Finishing";
            this.riDriverFinishing.Location = new System.Drawing.Point(9, 88);
            this.riDriverFinishing.Name = "riDriverFinishing";
            this.riDriverFinishing.Size = new System.Drawing.Size(214, 27);
            this.riDriverFinishing.TabIndex = 18;
            this.riDriverFinishing.TrackChanges = false;
            // 
            // riDriverConsistency
            // 
            this.riDriverConsistency.LabelText = "Consistency";
            this.riDriverConsistency.Location = new System.Drawing.Point(9, 63);
            this.riDriverConsistency.Name = "riDriverConsistency";
            this.riDriverConsistency.Size = new System.Drawing.Size(214, 27);
            this.riDriverConsistency.TabIndex = 17;
            this.riDriverConsistency.TrackChanges = false;
            // 
            // riDriverAggression
            // 
            this.riDriverAggression.LabelText = "Aggression";
            this.riDriverAggression.Location = new System.Drawing.Point(9, 38);
            this.riDriverAggression.Name = "riDriverAggression";
            this.riDriverAggression.Size = new System.Drawing.Size(214, 27);
            this.riDriverAggression.TabIndex = 9;
            this.riDriverAggression.TrackChanges = false;
            // 
            // RatingsGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRatings);
            this.Name = "RatingsGroup";
            this.Size = new System.Drawing.Size(239, 502);
            this.grpRatings.ResumeLayout(false);
            this.grpRatings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRatings;
        private RatingsItem riPitcrewStrategy;
        private RatingsItem riPitcrewSpeed;
        private RatingsItem riPitcrewConsistency;
        private System.Windows.Forms.Label lblRatingsPitcrew;
        private RatingsItem riVehicleReliability;
        private RatingsItem riVehicleEngine;
        private RatingsItem riVehicleChassis;
        private RatingsItem riVehicleAero;
        private System.Windows.Forms.Label lblRatingsVehicle;
        private RatingsItem riDriverSuperSpeedway;
        private RatingsItem riDriverSpeedway;
        private RatingsItem riDriverShortTrack;
        private RatingsItem riDriverRoadCourse;
        private RatingsItem riDriverQualifying;
        private RatingsItem riDriverFinishing;
        private RatingsItem riDriverConsistency;
        private RatingsItem riDriverAggression;
        private System.Windows.Forms.Label lblRatingsMax;
        private System.Windows.Forms.Label lblRatingsMin;
        private System.Windows.Forms.Label lblRatingsDriver;
    }
}
