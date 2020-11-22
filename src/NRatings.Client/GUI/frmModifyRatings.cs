using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using NRatings.Client.Business;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;

namespace NRatings.Client.GUI
{
    public partial class frmModifyRatings : frmBase
    {
        private RatingsModifier mRMod;
        private bool mIsDirty;
        private bool mTrackIsDirty;


        public frmModifyRatings(CarCollection carCol, NR2003Car currentCar)
        {
            InitializeComponent();
            this.mRMod = new RatingsModifier();
            this.mRMod.CarCollection = carCol;
            this.mRMod.CurrentCar = currentCar;

            this.mIsDirty = false;
            this.mTrackIsDirty = false;
        }

        private void frmModifyRatings_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.LoadRatingsList();

            this.chkSelectAllRatings.Checked = true;   

            this.SetControlsAccessibility();

            this.mTrackIsDirty = true;

        }

        private void SetControlsAccessibility()
        {

            if (this.mRMod.CurrentCar != null)
                this.rbCurrentCar.Text = "Current (" + this.mRMod.CurrentCar.FileName + ")";

            int countSelectedCars = this.mRMod.GetSelectedCarCount();
            if (countSelectedCars == 0)
            {
                this.rbSelectedCars.Checked = false;
                this.rbSelectedCars.Enabled = false;
            }
            else
                this.rbSelectedCars.Text = "Selected (" + countSelectedCars.ToString() + ")";


            if (this.rbActionRandomize.Checked)
            {
                this.txtActionValue.Enabled = false;
                this.txtRandomizeFrom.Enabled = true;
                this.txtRandomizeTo.Enabled = true;
            }
            else if (this.rbActionAdd.Checked || this.rbActionMultiply.Checked || this.rbActionSet.Checked)
            {
                this.txtActionValue.Enabled = true;
                this.txtRandomizeFrom.Enabled = false;
                this.txtRandomizeTo.Enabled = false;
            }
        }

        private void SetDirty(bool dirty)
        {
            if(this.mTrackIsDirty)
                this.mIsDirty = dirty;
        }

       

        private void LoadRatingsList()
        {
            DataTable dtRatings = new DataTable("ratings");
            dtRatings.Columns.Add("key", typeof(System.String));
            dtRatings.Columns.Add("value", typeof(System.String));

            Dictionary<string, Rating> ratingsList = Ratings.GetRatingsList();
            foreach (KeyValuePair<string, Rating> kvp in ratingsList)
            {
                DataRow row = dtRatings.NewRow();
                row["key"] = kvp.Key;
                row["value"] = kvp.Value.Group + " - " + kvp.Value.Name;

                dtRatings.Rows.Add(row);
            }

            this.chkRatings.DataSource = dtRatings;
            this.chkRatings.DisplayMember = "value";
            this.chkRatings.ValueMember = "key";

        }

        private void chkSelectAllRatings_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < this.chkRatings.Items.Count; i++)
            {
                this.chkRatings.SetItemChecked(i, this.chkSelectAllRatings.Checked);
            }
            
        }

        private string ValidateForm()
        {
            List<string> messages = new List<string>();
            string message = null;

            string decsep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            string strRandomizeFrom = this.txtRandomizeFrom.Text.Replace(".", decsep).Replace(",",decsep);
            string strRandomizeTo = this.txtRandomizeTo.Text.Replace(".", decsep).Replace(",", decsep);
            string strValue = this.txtActionValue.Text.Replace(".", decsep).Replace(",", decsep);

            int minValue;
            int maxValue;
            decimal value;

            if (this.rbActionRandomize.Checked)
            {
                if (strRandomizeFrom.Equals("") || strRandomizeTo.Equals("") || !Int32.TryParse(strRandomizeFrom, out minValue) || !Int32.TryParse(strRandomizeTo, out maxValue))
                    messages.Add("Randomization requires a valid upper and lower limit integer value");
                
            }
            else
            {
                if(strValue.Equals("") || !Decimal.TryParse(strValue, out value))
                    messages.Add("Value must be a valid decimal value");
            }

            if (messages.Count > 0)
            {
                foreach (string s in messages)
                    message += s + ". ";
            }

            return message;
        }

        private void butApply_Click(object sender, EventArgs e)
        {
            string errorMessage = this.ValidateForm();

            if (errorMessage != null)
            {
                MessageBox.Show("Error on validating form: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                this.UseWaitCursor = true;
                this.EnableAllControls(false, null);
                
                //SET TARGET RATINGS KEYS
                List<string> targetRatingsKeys = new List<string>();
                foreach (object o in this.chkRatings.CheckedItems)
                {
                    DataRowView drv = o as DataRowView;
                    if (drv != null)
                    {
                        targetRatingsKeys.Add(drv["key"] as string);
                    }
                }

                this.mRMod.SetTargetRatings(targetRatingsKeys);

                //SET TARGET RATINGS TYPE
                if (this.rbRatingsMin.Checked)
                    this.mRMod.SetTargetRatingsType(RatingsModifier.RatingsTypeToModify.Min);
                else if (this.rbRatingsMax.Checked)
                    this.mRMod.SetTargetRatingsType(RatingsModifier.RatingsTypeToModify.Max);
                else if (this.rbRatingsBoth.Checked)
                    this.mRMod.SetTargetRatingsType(RatingsModifier.RatingsTypeToModify.Both);

                //SET TARGET CARS
                if (this.rbCurrentCar.Checked)
                    this.mRMod.SetTargetCars(RatingsModifier.CarsToModify.Current);
                else if (this.rbSelectedCars.Checked)
                    this.mRMod.SetTargetCars(RatingsModifier.CarsToModify.Selected);
                else if (this.rbAllCars.Checked)
                    this.mRMod.SetTargetCars(RatingsModifier.CarsToModify.All);

                //SET TARGET ACTION
                if (this.rbActionRandomize.Checked)
                    this.mRMod.SetTargetAction(RatingsModifier.ActionToPerform.Randomize);
                else if (this.rbActionAdd.Checked)
                    this.mRMod.SetTargetAction(RatingsModifier.ActionToPerform.Add);
                else if (this.rbActionMultiply.Checked)
                    this.mRMod.SetTargetAction(RatingsModifier.ActionToPerform.Multiply);
                else if (this.rbActionSet.Checked)
                    this.mRMod.SetTargetAction(RatingsModifier.ActionToPerform.Set);

                //SET GROUPING OPTIONS
                this.mRMod.SetGroupingOptions(this.chkGroupByNumber.Checked, this.chkGroupByName.Checked);

                //SET VARIABLES
                int? minValue = null;
                int? maxValue = null;
                decimal? value = null;

                string decsep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

                try { minValue = Int32.Parse(this.txtRandomizeFrom.Text.Replace(".", decsep).Replace(",", decsep)); }
                catch { }

                try { maxValue = Int32.Parse(this.txtRandomizeTo.Text.Replace(".", decsep).Replace(",", decsep)); }
                catch { }

                try { value = Decimal.Parse(this.txtActionValue.Text.Replace(".", decsep).Replace(",", decsep)); }
                catch { }

                this.mRMod.SetVariables(minValue, maxValue, value);

                //FINALLY, APPLY THE ACTION IN A SEPARATE THREAD
                BackgroundWorker backWorker = new BackgroundWorker();
                backWorker.DoWork += new DoWorkEventHandler(backWorker_DoWork);
                backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorker_RunWorkerCompleted);
                backWorker.RunWorkerAsync();

                
                this.mIsDirty = false;
            }
        }

        private void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.EnableAllControls(true, null);
            this.SetControlsAccessibility();
            this.UseWaitCursor = false;
        }

        private void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.mRMod.ApplyModifications();
        }

        private void EnableAllControls(bool enable, Control control)
        {
            
            if(control == null)
                control = this;

            foreach (Control c in control.Controls)
            {

                c.Enabled = enable;

                if (c.HasChildren)
                {
                    this.EnableAllControls(enable, c);
                }
            }

        }

        private void rbAction_CheckedChanged(object sender, EventArgs e)
        {
            this.SetDirty(true);
            this.SetControlsAccessibility();
        }

        private void chkRatings_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDirty(true);
        }

        private void rbRatingsType_CheckedChanged(object sender, EventArgs e)
        {
            this.SetDirty(true);
        }

        private void rbCarSelection_CheckedChanged(object sender, EventArgs e)
        {
            this.SetDirty(true);
        }

        private void txtValueBox_TextChanged(object sender, EventArgs e)
        {
            this.SetDirty(true);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (this.MayCloseForm())
            {
                this.Close();
                this.Dispose();
            }
        }

        private void frmModifyRatings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.MayCloseForm())
            {
                e.Cancel = true;
            }
            else
                this.Dispose();
        }

        private bool MayCloseForm()
        {
            bool mayClose = true;

            if (this.mIsDirty)
            {
                DialogResult res = MessageBox.Show("You have unapplied changes pending. Are you sure you wish to close this form ?", "Close without applying ?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (res == DialogResult.No)
                    mayClose = false;
                else
                    this.mIsDirty = false;


            }

            return mayClose;
        } 

    }
}
