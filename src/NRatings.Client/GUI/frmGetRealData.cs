using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Business;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;
using Race = NRatings.Client.Domain.Race;
using Season = NRatings.Client.Domain.Season;
using Series = NRatings.Client.Domain.Series;

namespace NRatings.Client.GUI
{
    public partial class frmGetRealData : frmBase
    {
        private RealDataProcessor rdp;
        private GenericBackWorker genericBackWorker;
        
        private int maxSeasons = 0;
        private List<int> seasonIndicesToUncheck = new List<int>();

        public RealDriverCollection RealDrivers
        {
            get { return this.rdp.RealDrivers; }
        }

        public bool CarListOnly
        {
            get { return this.rdp.CarListOnly; }
        }

        public CarMappingMethod MappingMethod
        {
            get { return this.rfsRatingsFormula.SelectedFormula.Options.MappingMethod; }
        }


        public frmGetRealData()
        {
            InitializeComponent();

            this.rdp = new RealDataProcessor();

            //INITIALIZE THE BACKGROUNDWORKERS
            this.genericBackWorker = new GenericBackWorker();
            //END BACKGROUNDWORKERS

            //SET THE TYPE OF RACE BINDINGSOURCE DATASOURCE TO LIST
            this.bsRaces.DataSource = new List<Race>();

            //SUBSCRIBE TO THE SELECTEDRACES CHANGED EVENT
            this.rdp.SelectedRacesChanged += new EventHandler(rdp_SelectedRacesChanged);

            
        }
  
        private void rdp_SelectedRacesChanged(object sender, EventArgs e)
        {
            if (rdp.SelectedRaces.Count > 0)
            {
                this.butVariableInspector.Enabled = true;
                this.butPreviewRatings.Enabled = true;
                this.butApply.Enabled = true;
            }
            else
            {
                this.butVariableInspector.Enabled = false;
                this.butPreviewRatings.Enabled = false;
                this.butApply.Enabled = false;
            }
        }

                
        private void GetSeries()
        {
            IList<Series> seriesList = this.rdp.GetSeries();
            this.bsSeries.DataSource = seriesList;
        }

        private void GetFormulas()
        {
            RatingsFormulaCollection hardCodedRfc;
            RatingsFormulaCollection customRfc;
            RatingsFormulaCollection rfc = new RatingsFormulaCollection();
 
            //FORMULAS
            formulas = RatingsFormulaCollection.GetFormulas();

            rfc.AddRange(formulas);

            rfc.Sort(SortFormulas);

            this.rfsRatingsFormula.FormulaCollection = rfc;


            //SELECT THE DEFAULT FORMULA
            if (Program.userSettings.DefaultFormula != null)
            {
                bool defaultFound = false;
                foreach (RatingsFormula r in rfc)
                {
                    if (defaultFound == false)
                    {
                        if (r.FileName == Program.userSettings.DefaultFormula)
                        {
                            this.rfsRatingsFormula.SelectedFormula = r;
                            defaultFound = true;
                        }
                    }
                }
            }

        }

        private int SortFormulas(RatingsFormula a, RatingsFormula b)
        {
            return a.Name.CompareTo(b.Name);
        }

        private void CorrectRaceSelections()
        {
            foreach (DataGridViewRow dgr in this.dgRaces.Rows)
            {
                Race race = dgr.DataBoundItem as Race;

                if (race != null && this.rdp.SelectedRaces.Contains(race))
                    dgr.Cells["Select"].Value = true;
                else
                    dgr.Cells["Select"].Value = false;

            }
        }

        
        private void EnableRaceSelectionButtons(bool enable)
        {
            this.butSelectAll.Enabled = enable;
            this.butSelectNone.Enabled = enable;
        }

        
        private void CleanUpRaces()
        {
            this.bsRaces.Clear();
            this.rdp.ClearSelectedRaces();
            this.EnableRaceSelectionButtons(false);
        }

       
        private void SelectAllRaces(bool value)
        {
            if (this.dgRaces.DataSource != null)
            {
                foreach (DataGridViewRow dgr in this.dgRaces.Rows)
                {
                    dgr.Cells["Select"].Value = value;
                }

            }

        }

        
        private void EnableAllControls(bool enable)
        {
            
            foreach (Control c in this.Controls)
            {
                
                if(c.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType() != typeof(LogBox))
                            c2.Enabled = enable;
                    }
                        
                }
                else if (c.GetType() != typeof(System.Windows.Forms.StatusStrip))
                    c.Enabled = enable;
               
            }

        }
       
        private void ShowSingleRaceResults(Race race)
        {
            
            if (race != null)
            {
                frmRaceResults fRaceResults = new frmRaceResults(race);
                fRaceResults.ShowDialog();
            }
        }

           
        #region BackgroundWorker Handlers

        private void FetchAndCompute()
        {
            this.rdp.GetDriverRaceData();
            this.rdp.ComputeDriverStatsForEachTrackType();
        }

        private void FetchAndComputeAndCalculate()
        {
            this.FetchAndCompute();
            this.rdp.CalculateRatings();
        }

        private void UnlockUIAndShowDriverStats()
        {
            this.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;
            this.EnableAllControls(true);

            if (this.rdp.DataProcessingException == null)
            {
                frmDriverStats fDriverStats = new frmDriverStats(this.rdp.DriverStatsByType, this.rdp.TrackTypes);
                fDriverStats.ShowDialog();
            }
            else
            {
                Helper.ShowError(this.rdp.DataProcessingException);
            }
            
        }

        
        private void UnlockUIAndShowDriverRatings()
        {
            this.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;
            this.EnableAllControls(true);

            if (this.rdp.DataProcessingException == null)
            {
                frmDriverRatings fDriverRatings = new frmDriverRatings(this.RealDrivers);
                fDriverRatings.ShowDialog();
            }
            else
            {
                Helper.ShowError(this.rdp.DataProcessingException);
            }
        }

        private void ApplyCalculatedRatings() //THIS IS DONE BY CLOSING THE FORM AND RETURNING TO THE FRMNR2003RATINGS FORM
        {
            this.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;

            if (this.rdp.DataProcessingException == null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Helper.ShowError(this.rdp.DataProcessingException);

                this.EnableAllControls(true);

            }
        }

        
        #endregion


        #region Windows Forms Events


        private void frmGetRealData_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            this.dgRaces.AutoResizeColumns();


            this.maxSeasons = 5;

            //GET BASIC DATA
            this.GetSeries();
            this.GetFormulas();

        }

        private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CleanUpRaces();
        }

        private void chkSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in this.seasonIndicesToUncheck)
            {
                this.chkSeasons.SetItemChecked(i, false);
            }

            this.seasonIndicesToUncheck.Clear();
        }

        private void chkSeasons_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && this.chkSeasons.CheckedItems.Count >= maxSeasons)
            {
                MessageBox.Show("You have reached the maximum of " + maxSeasons.ToString() + " selected seasons. Uncheck another season first.", "Season limit reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (!this.seasonIndicesToUncheck.Contains(e.Index))
                    this.seasonIndicesToUncheck.Add(e.Index);
            }
            else
            {

                Season season = this.chkSeasons.Items[e.Index] as Season;

                if (season != null)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        IList<Race> seasonRaces = this.rdp.GetRaces(season);

                        if (seasonRaces != null)
                        {
                            foreach (Race race in seasonRaces)
                            {
                                this.bsRaces.Add(race);
                                this.dgRaces.Rows[this.bsRaces.IndexOf(race)].Cells["Select"].Value = false;
                            }
                        }

                    }
                    else
                    {
                        List<Race> racesToRemove = new List<Race>();

                        foreach (object o in bsRaces)
                        {
                            Race race = o as Race;

                            if (race != null)
                            {
                                if (race.Season.Id == season.Id)
                                    racesToRemove.Add(race);
                            }
                        }

                        foreach (Race race in racesToRemove)
                        {
                            this.bsRaces.Remove(race);
                            this.rdp.SelectRace(race, false);
                        }

                        if (this.chkSeasons.CheckedItems.Count == 0)
                        {
                            this.CleanUpRaces();
                        }
                    }


                    //SORT THE RACES BY DATE
                    List<Race> allRaces = this.bsRaces.DataSource as List<Race>;
                    if (allRaces != null)
                    {
                        allRaces.Sort();
                        this.dgRaces.Refresh();
                        this.CorrectRaceSelections();
                    }

                    //READJUST THE COLUMN WIDTHS
                    this.dgRaces.AutoResizeColumns();
                }

                if (this.bsRaces.Count > 0)
                    this.EnableRaceSelectionButtons(true);
                else
                    this.EnableRaceSelectionButtons(false);

            }

        }

        private void chkCarListOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.rdp.CarListOnly = this.chkRosterOnly.Checked;
        }


        private void dgRaces_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Race race = this.dgRaces.Rows[e.RowIndex].DataBoundItem as Race;
            this.ShowSingleRaceResults(race);
        }

        private void dgRaces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.RowIndex != -1)
            {
                Race race = this.dgRaces.Rows[e.RowIndex].DataBoundItem as Race;
                this.ShowSingleRaceResults(race);

            }
        }

        private void dgRaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                if (this.dgRaces.IsCurrentCellInEditMode)
                    this.dgRaces.EndEdit();
            }
        }


        private void dgRaces_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                bool selected = (bool)this.dgRaces.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                Race race = (Race)this.bsRaces[e.RowIndex];

                this.rdp.SelectRace(race, selected);
            }
        }


        private void butSelectAll_Click(object sender, EventArgs e)
        {
            this.SelectAllRaces(true);
        }

        private void butSelectNone_Click(object sender, EventArgs e)
        {
            this.SelectAllRaces(false);
        }

        private void butVariableInspector_Click(object sender, EventArgs e)
        {    
            this.UseWaitCursor = true;
            this.EnableAllControls(false);
                
            this.rdp.SelectedFormula = this.rfsRatingsFormula.SelectedFormula;

            this.genericBackWorker.StartWorker(this.FetchAndCompute, this.UnlockUIAndShowDriverStats); 
        }

        private void butPreviewRatings_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.EnableAllControls(false);

            this.rdp.SelectedFormula = this.rfsRatingsFormula.SelectedFormula;

            this.genericBackWorker.StartWorker(this.FetchAndComputeAndCalculate, this.UnlockUIAndShowDriverRatings);

        }

        private void butApply_Click(object sender, EventArgs e)
        {
            if (this.rdp.SelectedRaces.Count > 0 && this.rfsRatingsFormula.SelectedFormula != null)
            {

                this.UseWaitCursor = true;
                this.EnableAllControls(false);

                this.rdp.SelectedFormula = this.rfsRatingsFormula.SelectedFormula;

                this.genericBackWorker.StartWorker(this.FetchAndComputeAndCalculate, this.ApplyCalculatedRatings);
            }
            else
            {
                MessageBox.Show("No races or formula selected", "Missing selections", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        #endregion


        public RatingsFormulaCollection formulas { get; set; }
    }
}