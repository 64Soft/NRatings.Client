using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Business;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;
using NRatings.Client.EventHandling;
using Message = NRatings.Client.Validation.Message;

//TODO: Bind ratingsgroup control to the bsCars bindingsource instead of manually maintaining the binding

namespace NRatings.Client.GUI
{
    partial class frmNR2003Ratings : frmBase
    {
        private MainProcessor mainProc;
      
        private Ratings CopiedRatings;
        private NR2003Instance selectedNR2003Instance;
        private Mod selectedMod;
        private Roster selectedRoster;
        private CarCollection colCars;
        private BackgroundWorker carListWorker;

        private bool isExiting = false;

        //DELEGATES FOR CROSS-THREAD OPERATIONS
        private delegate void SetSelectModifiedButtonTextDelegate();
        private delegate void EnableControlsIfDirtyCarCollectionDelegate(bool enable);
        //END DELEGATES

        public frmNR2003Ratings()
        {
            InitializeComponent();

            //HIDE THE DEV TOOLSTRIP IN RELEASE MODE
#if !DEBUG
            this.devToolStripMenuItem.Visible = false;
#endif
            this.mainProc = new MainProcessor();

            this.carListWorker = new BackgroundWorker();
            this.carListWorker.WorkerReportsProgress = true;
            this.carListWorker.DoWork += new DoWorkEventHandler(carListWorker_DoWork);
            this.carListWorker.ProgressChanged += new ProgressChangedEventHandler(carListWorker_ProgressChanged);
            this.carListWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(carListWorker_RunWorkerCompleted);

            this.mainProc.RealDriverCollectionChanged += new EventHandler(mainProc_RealDriverCollectionChanged);
            this.mainProc.MessageRaised += new EventHandler<EventArgs<Message>>(mainProc_MessageRaised);

            this.LoadNR2003Instances();

        }

        private void mainProc_MessageRaised(object sender, EventArgs<Message> e)
        {
            switch(e.ArgObject.Type)
            {
                case Message.MessageType.Info:
                    ShowMessage(e.ArgObject.Text, "Info");
                    break;
                case Message.MessageType.Error:
                    ShowError(e.ArgObject.Text);
                    break;
            }
           
        }

        
        private void mainProc_RealDriverCollectionChanged(object sender, EventArgs e)
        {        
            this.bsRealDrivers.DataSource = this.mainProc.RealDrivers;

            if (this.dgCars != null)
            {
                this.dgCars.AutoResizeColumns();
            }
        }

        
        private void frmNR2003Ratings_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
      
            string version = "v" + Application.ProductVersion.Trim();
            string platform = "(unknown platform)";

            if (IntPtr.Size == 4)
                platform = "";
            else if (IntPtr.Size == 8)
                platform = "(64-bit)";

            this.Text = this.Text + " " + version  + "   " + platform;

            if (Program.userSettings.NR2003Instances == null || Program.userSettings.NR2003Instances.Count == 0)
            {
                MessageBox.Show("There are no NR2003 instances defined. You should go to \"Tools - Options\" and add at least one NR2003 instance.", "No NR2003 instances found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmNR2003Ratings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isExiting)
            {
                if (ConfirmExit() == false)
                    e.Cancel = true;
                else
                {
                    this.isExiting = true;
                    Application.Exit();
                }
            }
        }

        
        private bool ConfirmExit()
        {

            if (this.colCars != null && this.colCars.IsDirty == true)
            {
                DialogResult sure = MessageBox.Show("You have unsaved changes in your carlist. Are you sure you want to exit the application ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sure == DialogResult.No)
                    return false;
                else
                    return true;

            }
            else
                return true;
        }


        public static void ShowError(String text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessage(String text, String caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        
        private void LoadNR2003Instances()
        {
            
            if (this.ConfirmCarLoading())
            {

                this.selectedNR2003Instance = null;
                this.selectedMod = null;
                this.selectedRoster = null;
                

                this.bsNR2003Instances.Clear();


                this.bsNR2003Instances.DataSource = Program.userSettings.NR2003Instances;

                if (Program.userSettings.NR2003Instances != null && Program.userSettings.NR2003Instances.Count > 0)
                {

                    NR2003Instance defaultInstance;

                    var q = (from i in Program.userSettings.NR2003Instances
                             where i.IsDefault == true
                             select i).First();


                    if (q != null)
                        defaultInstance = q;
                    else
                        defaultInstance = Program.userSettings.NR2003Instances.First();


                    this.cmbNR2003Instance.SelectedItem = defaultInstance;

                    
                }

                this.LoadCarList();
            }
            
        }

        private void LoadMods()
        {
            if (this.selectedNR2003Instance != null)
            {
                this.selectedNR2003Instance.LoadMods();
            }
        }

        private void LoadRosters()
        {
            if (this.selectedMod != null)
            {
                this.selectedMod.LoadRosters();
            }
        }

        private void bsNR2003Instances_CurrentChanged(object sender, EventArgs e)
        {
            NR2003Instance instance = this.cmbNR2003Instance.SelectedItem as NR2003Instance;

            if (instance != this.selectedNR2003Instance)
            {
                this.selectedNR2003Instance = instance;

                if (this.cmbMod.Items.Count > 0)
                {
                    this.cmbMod.SelectedIndex = 0;
                }

                this.LoadMods();
              
            }

        }

        private void bsMods_CurrentChanged(object sender, EventArgs e)
        {
            
            Mod mod = this.bsMods.Current as Mod;

            if (mod != this.selectedMod)
            {
                this.selectedMod = mod;

                if (this.cmbRoster.Items.Count > 0)
                {
                    this.cmbRoster.SelectedIndex = 0;
                }

                if (mod != null)
                {
                    Console.WriteLine("--mod: *" + mod.Name + "* from instance: *" + mod.NR2003Instance.Name + "*");
                    this.LoadRosters();
                }
                else
                    Console.WriteLine("--mod is null");
            }
 
        }

        private void bsRosters_CurrentChanged(object sender, EventArgs e)
        {
            Roster roster = this.bsRosters.Current as Roster;

            if (roster != this.selectedRoster)
            {
                this.selectedRoster = roster;

                if (roster != null)
                {
                    Console.WriteLine("---roster: *" + roster.Name + "* from mod: *" + roster.Mod.Name + "*");
                }
                else
                    Console.WriteLine("---roster is null");

                Console.WriteLine("---LOADING CARLIST");
                this.LoadCarList();
            }

        }

        private void cmbNR2003Instance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isExiting)
            {
                if (this.cmbNR2003Instance.SelectedItem != this.selectedNR2003Instance)
                {
                    if (this.ConfirmCarLoading() == false)
                    {
                        this.cmbNR2003Instance.SelectedItem = this.selectedNR2003Instance;
                    }
                }
            }
            
        }

        private void cmbMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isExiting)
            {
                if (this.cmbMod.SelectedItem != this.selectedMod)
                {
                    if (this.ConfirmCarLoading() == false)
                    {
                        this.cmbMod.SelectedItem = this.selectedMod;
                    }
                }
            }
            
        }

        private void cmbRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isExiting)
            {
                if (this.cmbRoster.SelectedItem != this.selectedRoster)
                {
                    if (this.ConfirmCarLoading() == false)
                    {
                        this.cmbRoster.SelectedItem = this.selectedRoster;
                    }
                }
            }
            
        }

        private bool ConfirmCarLoading()
        {
            bool doLoad = true;

            if (this.colCars != null && this.colCars.IsDirty == true)
            {
                DialogResult sure = MessageBox.Show("You have unsaved changes in your carlist. Your chosen action will discard these changes. Are you sure you want to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sure == DialogResult.No)
                {
                    doLoad = false;
                }
                else
                {
                    //SET CAR COLLECTION TO NOT DIRTY
                    this.colCars.IsDirty = false;
                }

            }

            return doLoad;
        }

        
        private void LoadCarList()
        {
            if (this.selectedMod != null)
            {

                this.UseWaitCursor = true;

                this.EnableControlsIfDirtyCarCollection(false);

                this.lbLog.ClearLog();

                carListWorker.RunWorkerAsync();

                //while (carListWorker.IsBusy)
                //{
                //    // Keep UI messages moving, so the form remains 
                //    // responsive during the asynchronous operation.
                //    Application.DoEvents();
                //}
            }

          
        }
       
       
        private void CarIsDirtyChanged(object sender, EventArgs<bool> e)
        {
            this.SetSelectModifiedButtonText();

            try
            {
                int carIndex = -1;
                NR2003Car car = (NR2003Car)sender;

                CarCollection colCars = (CarCollection)this.bsCars.DataSource;
                carIndex = colCars.IndexOf(car);

                if (carIndex != -1)
                {
                    if (e.ArgObject == true)
                        this.dgCars.Rows[carIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    else
                        this.dgCars.Rows[carIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void colCars_IsDirtyChanged(object sender, EventArgs<bool> e)
        {
            this.EnableControlsIfDirtyCarCollection(e.ArgObject);
        }

        private void EnableControlsIfDirtyCarCollection(bool enable)
        {
            /* CHECK IF THE CALLING THREAD IS ALLOWED TO UPDATE THE CONTROL
             * IF IT'S NOT ALLOWED, USE THE DELEGATE TO EXECUTE THE METHOD AGAIN
            */
            if (this.butSelectModifiedCars.InvokeRequired || this.butDiscard.InvokeRequired || this.butSelectModifiedCars.InvokeRequired)
            {
                EnableControlsIfDirtyCarCollectionDelegate d = new EnableControlsIfDirtyCarCollectionDelegate(EnableControlsIfDirtyCarCollection);
                this.Invoke(d, new object[] { enable });
            }
            else
            {
                this.butSaveModifiedCars.Enabled = enable;
                this.butDiscard.Enabled = enable;
                this.butSelectModifiedCars.Enabled = enable;
            }
        }

        private void SetSelectModifiedButtonText()
        {
            /* CHECK IF THE CALLING THREAD IS ALLOWED TO UPDATE THE CONTROL
             * IF IT'S NOT ALLOWED, USE THE DELEGATE TO EXECUTE THE METHOD AGAIN
            */
            if (this.butSelectModifiedCars.InvokeRequired) 
            {
                SetSelectModifiedButtonTextDelegate d = new SetSelectModifiedButtonTextDelegate(SetSelectModifiedButtonText);
                this.Invoke(d);
            }
            else
            {

                string selectModified = "Select Modified";

                if (this.colCars != null)
                {
                    selectModified += " (" + this.colCars.GetModifiedCount().ToString() + ")";
                }

                this.butSelectModifiedCars.Text = selectModified;
            }
        }
      
       

        private void CreateCarRoster()
        {
            try
            {

                if (this.bsCars.DataSource != null)
                {
                    Mod mod = (Mod)this.cmbMod.SelectedValue;
                    CarCollection colCars = (CarCollection)this.bsCars.DataSource;

                    List<String> selectedCars = new List<String>();

                    foreach (NR2003Car c in colCars)
                    {
                        if (c.Selected == true)
                            selectedCars.Add(@"+" + c.FileName);
                    }

                    if (selectedCars.Count > 0)
                    {

                        frmRosterFileName fFileName = new frmRosterFileName();
                        DialogResult dRes = fFileName.ShowDialog();

                        if (dRes == DialogResult.OK)
                        {
                            string filename = fFileName.FileName.Trim();

                            if (filename.EndsWith(".lst"))
                                filename = filename.Remove(filename.LastIndexOf("."));

                            filename = filename + ".lst";

                            string[] arrCars = selectedCars.ToArray();
                            File.WriteAllLines(mod.Path + @"\cars\" + filename, arrCars, Encoding.Default);

                            frmNR2003Ratings.ShowMessage("Roster " + filename + " successfully created, containing " + selectedCars.Count.ToString() + " car(s). Reload the mod from the dropdown to see your new roster.", "Save ok");

                        }

                    }
                    else
                        frmNR2003Ratings.ShowMessage("You did not select any cars", "No cars selected");
                }
            }
            catch (Exception ex)
            {
                frmNR2003Ratings.ShowError("Error in creating car list: " + ex.ToString());
            }

        }

        private RealDriverCollection MapRealDataToCars(RealDriverCollection RealDrivers, CarMappingMethod mappingMethod)
        {
            if (this.bsCars.DataSource != null)
            {
                CarCollection colCars = (CarCollection)this.bsCars.DataSource;

                foreach (NR2003Car c in colCars)
                {
                    RealDriver foundDriver = null;

                    switch (mappingMethod)
                    {
                        case CarMappingMethod.NAME:
                            foundDriver = RealDrivers.FindByName(c.DriverFirstName, c.DriverLastName);
                            break;
                        case CarMappingMethod.NUMBER:
                            foundDriver = RealDrivers.FindByNumber(c.Number);
                            break;
                        case CarMappingMethod.NUMBER_AND_NAME:
                            foundDriver = RealDrivers.FindByNumberAndName(c.Number, c.DriverFirstName, c.DriverLastName);
                            break;
                    }

                    
                    if (foundDriver != null)
                    {
                        c.MappedToRealDriver = foundDriver;

                        c.Selected = true;

                        foundDriver.MatchFound = true;

                    }
                }

                return RealDrivers;
            }
            else
                return null;

        }

       
        private void LogUnmappedDrivers()
        {
            this.lbLog.ClearLog();

            if (this.mainProc.RealDrivers != null)
            {
                this.lbLog.WriteToLog("Following real life drivers did not map to a carfile:", false);

                foreach (RealDriver rd in this.mainProc.RealDrivers)
                {
                    if (rd.MatchFound == false)
                    {
                        this.lbLog.WriteToLog(rd.DisplayString, false);

                    }

                }
            }
        }

        private void RandomizeDriverNames()
        {
            if (this.colCars != null && this.colCars.Count > 0)
            {
                foreach (NR2003Car c in this.colCars)
                {
                    int firstNameLength = Helper.GetRandomNumber(3, 15);
                    int lastNameLength = Helper.GetRandomNumber(5, 15);

                    c.DriverFirstName = Helper.GetRandomString(firstNameLength);
                    c.DriverLastName = Helper.GetRandomString(lastNameLength);
                }
            }
            else
                frmNR2003Ratings.ShowError("No items to randomize");

        }


        #region CarsSaving_BackgroundThread


        private void SaveCarsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList param = e.Argument as ArrayList;

            BackgroundWorker backWorker = (BackgroundWorker)param[0];
            List<NR2003Car> targetCars = (List<NR2003Car>)param[1];

            double progress = 0.0;

            int counter = 0;
            int numCarFiles = targetCars.Count;
            
            foreach (NR2003Car c in targetCars)
            {
                counter++;

                Dictionary<NR2003Car, bool> carSaveResult = new Dictionary<NR2003Car, bool>();

                bool saveOk = c.SaveCarToFile();
                if (saveOk)
                {        
                    carSaveResult.Add(c, true);
                    c.IsDirty = false;                  
                }
                else
                {

                    carSaveResult.Add(c, false);              
                }

                progress = ((double)(counter) / (double)(numCarFiles)) * 100.0;

                backWorker.ReportProgress((int)(Math.Round(progress, 0)), carSaveResult);               
            }
        }

        private void SaveCarsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
                this.pbProgress.Value = e.ProgressPercentage;

            if (e.UserState != null)
            {
                Dictionary<NR2003Car, bool> carSaveResult = e.UserState as Dictionary<NR2003Car, bool>;

                foreach (KeyValuePair<NR2003Car, bool> kvp in carSaveResult) //NORMALLY WILL CONTAIN ONLY ONE ITEM
                {
                    NR2003Car c = kvp.Key;
                    bool success = kvp.Value;

                    int carIndex = this.colCars.IndexOf(c);
                    this.bsCars.Position = carIndex;

                    if (success)
                    {
                        this.dgCars.Rows[carIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        this.lbLog.WriteToLog(String.Format("Save successful: {0}", c.ToString()), false);
                    }
                    else
                    {
                        this.dgCars.Rows[carIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        this.lbLog.WriteToLog(String.Format("Save NOT successful: {0}", c.ToString()), false);
                    }
                }
                
            }
        }

        private void SaveCarsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lbLog.ScrollToLast = false;

            this.colCars.IsDirty = false;

            this.UseWaitCursor = false;

            Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y); //workaround code for the fact that the wait-cursor doesn't change until the cursor is moved.

            this.pbProgress.Value = 0;

            
        }

        

        #endregion

        #region CarList_BackgroundThread

        private void carListWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.colCars != null)
            {
                if (this.colCars.Count > 0)
                {

                    this.colCars.Sort();
                    this.colCars.IsDirty = false;
                    this.bsCars.DataSource = this.colCars;


                    foreach (DataGridViewRow dvr in this.dgCars.Rows)
                    {
                        dvr.ContextMenuStrip = this.ctxMenuStripCars;
                    }


                    this.butSelectAllCars.Enabled = true;
                    this.butSelectNoCars.Enabled = true;
                    this.butImportRatings.Enabled = true;
                    this.butModifyRatings.Enabled = true;
                    this.butCreateRoster.Enabled = true;

                }
                else
                {
                    this.bsCars.DataSource = null;
                    this.butSelectAllCars.Enabled = false;
                    this.butSelectNoCars.Enabled = false;
                    this.butImportRatings.Enabled = false;
                    this.butModifyRatings.Enabled = false;
                    this.butCreateRoster.Enabled = false;
                }

                this.lblCountCars.Text = "Cars in grid: " + this.colCars.Count;
            }
            else
            {
                this.bsCars.DataSource = null;
                this.butSelectAllCars.Enabled = false;
                this.butSelectNoCars.Enabled = false;
                this.butImportRatings.Enabled = false;
                this.butModifyRatings.Enabled = false;
                this.butCreateRoster.Enabled = false;

                this.lblCountCars.Text = "Cars in grid: 0";
            }

            this.dgCars.AutoResizeColumns();

            this.UseWaitCursor = false;

            this.pbProgress.Value = 0;
        }

        private void carListWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string text = Convert.ToString(e.UserState);
            int progress = e.ProgressPercentage;

            if (text != "")
                this.lbLog.WriteToLog(text, false);

            if (progress != -1)
                this.pbProgress.Value = progress;
        }

        private void carListWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            bool errorsOnRead = false;
            double progress = 0.0;

            if (this.selectedMod.Path != null)
            {
                String carPath = this.selectedMod.Path + @"\cars";

                if (Directory.Exists(carPath))
                {
                    string rosterContents = null;
                    if (this.selectedRoster != null && this.selectedRoster.FullPath != null)
                    {
                        try
                        {
                            rosterContents = this.selectedRoster.GetRosterContents();
                        }
                        catch (Exception ex)
                        {
                            carListWorker.ReportProgress(-1, "Error reading roster " + this.selectedRoster.Name + ": " + ex.ToString());
                            errorsOnRead = true;
                        }
                    }



                    String[] carFiles = Directory.GetFiles(carPath, "*.car");
                    int numCarFiles = carFiles.Length;
                    int counter = 0;

                    this.colCars = new CarCollection();
                    foreach (String carFile in carFiles)
                    {
                        counter++;

                        string carFileName = carFile.Substring(carFile.LastIndexOf(@"\") + 1);

                        NR2003Car c = new NR2003Car(carPath, carFileName);
                      
                        try
                        {
                            c.ReadCarInfo();

                            c.IsDirtyChanged +=new EventHandler<EventArgs<bool>>(CarIsDirtyChanged);
                            
                            if (rosterContents != null)
                            {
                                if (rosterContents.Contains(@"+" + c.FileName))
                                    this.colCars.Add(c);
                            }
                            else
                                this.colCars.Add(c);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            carListWorker.ReportProgress(-1, "Not allowed to access carfile " + c.FileName + ". Make sure the file is not set to readonly !");
                            errorsOnRead = true;
                        }
                        catch (Exception ex)
                        {
                            errorsOnRead = true;
                            carListWorker.ReportProgress(-1, "There was an error reading carfile " + c.FileName + ": " + ex.Message);
                        }

                        progress = ((double)(counter) / (double)(numCarFiles)) * 100.0;
                        carListWorker.ReportProgress((int)(Math.Round(progress, 0)));


                    }

                    this.colCars.IsDirtyChanged += new EventHandler<EventArgs<bool>>(colCars_IsDirtyChanged);


                    if (errorsOnRead == true)
                        frmNR2003Ratings.ShowError("There were errors while reading the carfiles. Check the logbox at the bottom of the screen !");
                }
                else
                {
                    frmNR2003Ratings.ShowError(@"Cannot load cars: series does not contain a \cars subfolder !");
                    this.colCars = null;
                }

            }
            else
            {
                this.colCars = null;
            }
        }


        #endregion

        #region DataGrid_Events

        private void dgCars_MouseDown(object sender, MouseEventArgs e)
        {
            //On right mouseclick, make sure the car at the cursor is selected, to allow correct functioning of contextmenustrip

            DataGridView.HitTestInfo Hti;

            if (e.Button == MouseButtons.Right)
            {
                Hti = this.dgCars.HitTest(e.X, e.Y);

                this.bsCars.Position = Hti.RowIndex;

                NR2003Car c = this.bsCars.Current as NR2003Car;

                if(c != null)
                {
                    if (c.IsDirty == false)
                        this.ctxMenuStripCars.Items["revertToolStripMenuItem"].Enabled = false;
                    else
                        this.ctxMenuStripCars.Items["revertToolStripMenuItem"].Enabled = true;

                    if (this.CopiedRatings == null)
                        this.ctxMenuStripCars.Items["pasteRatingsToolStripMenuItem"].Enabled = false;
                    else
                        this.ctxMenuStripCars.Items["pasteRatingsToolStripMenuItem"].Enabled = true;
                }

            }
        }

        private void dgCars_SelectionChanged(object sender, EventArgs e)
        {
            //this.grpRatings.TrackChanges(false);

            if(this.bsCars != null && this.bsCars.Count > 0)
            {

                NR2003Car c = (NR2003Car)this.bsCars.Current;
                this.grpRatings.Ratings = c.Ratings;
                //this.grpRatings.TrackChanges(true);
                this.grpRatings.EnableControls(true);

                Console.WriteLine("Current car: " + c.ToString());

            }
            else
                this.grpRatings.EnableControls(false);
        }

        private void dgCars_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgCars.CurrentCell.OwningColumn.Name == "mappedToRealDriverDataGridViewComboBoxColumn")
            {
                this.dgCars.EndEdit();

                NR2003Car c = this.bsCars.Current as NR2003Car;

                if (c != null)
                {
                    this.grpRatings.Ratings = c.Ratings;
                }
            }
        }

        private void dgCars_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.ToString());
        }

        #endregion

        #region Buttons

       
        private void butSaveModifiedCars_Click(object sender, EventArgs e)
        {
            if (this.bsCars.DataSource != null)
            {
                if (MessageBox.Show("You are about to save the changes to your carfiles. This is irreversible. Continue ?", "Are you sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.UseWaitCursor = true;
                    this.EnableControlsIfDirtyCarCollection(false);

                    this.lbLog.ClearLog();
                    this.lbLog.ScrollToLast = true;
                    CarCollection colCars = (CarCollection)this.bsCars.DataSource;

                    BackgroundWorker SaveCarsWorker = new BackgroundWorker();
                    SaveCarsWorker.WorkerReportsProgress = true;
                    SaveCarsWorker.DoWork += new DoWorkEventHandler(SaveCarsWorker_DoWork);
                    SaveCarsWorker.ProgressChanged += new ProgressChangedEventHandler(SaveCarsWorker_ProgressChanged);
                    SaveCarsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SaveCarsWorker_RunWorkerCompleted);

                    ArrayList param = new ArrayList();
                    List<NR2003Car> targetCars = this.colCars.GetModifiedCars();

                    param.Add(SaveCarsWorker);
                    param.Add(targetCars);

                    SaveCarsWorker.RunWorkerAsync(param);

                }
            }


        }
      
        private void butDiscard_Click(object sender, EventArgs e)
        {
            DialogResult sure = MessageBox.Show("This will discard all the unsaved changes you've made. Are you sure you want to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (sure == DialogResult.Yes)
            {

                if (this.colCars != null)
                {
                    this.colCars.RevertToOriginal();
                    this.dgCars.Refresh();

                    this.dgCars_SelectionChanged(null, null);
                }
            }
        }

        private async void butImportRatings_Click(object sender, EventArgs e)
        {
            bool showImportDialog = true;

            if (this.colCars.IsDirty == true)
            {
                DialogResult sure = MessageBox.Show("You have unsaved changes in your carlist. If you import ratings from real life data, you may possibly overwrite these changes. Are you sure you want to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sure == DialogResult.No)
                    showImportDialog = false;
            }


            if (showImportDialog == true)
            {
                frmGetRealData fRealData = new frmGetRealData();
                DialogResult dres = fRealData.ShowDialog();
                if (dres == DialogResult.OK)
                {
                    ////START FROM A BLANK CARLIST
                    //this.colCars.IsDirty = false; //set to false to avoid confirmation dialog
                    //this.LoadCarList();


                    RealDriverCollection RealDrivers = fRealData.RealDrivers;

                    CarMappingMethod mappingMethod = fRealData.MappingMethod;
                    bool rosterOnly = fRealData.CarListOnly;

                    //IF THE "ROSTER ONLY" CHECKBOX WAS CHECKED, DON'T ALLOW TO MANUALLY REMAP TO ANOTHER REAL LIFE DRIVER (THERE'S NO SENSE ANYWAY)
                    if (rosterOnly == true)
                        this.dgCars.Columns["mappedToRealDriverDataGridViewComboBoxColumn"].ReadOnly = true;
                    else
                        this.dgCars.Columns["mappedToRealDriverDataGridViewComboBoxColumn"].ReadOnly = false;


                    if (RealDrivers != null)
                    {
                        this.mainProc.RealDrivers = this.MapRealDataToCars(RealDrivers, mappingMethod);
                        this.LogUnmappedDrivers();
                    }

                    this.dgCars.Focus();
                    this.dgCars.Refresh();

                    if (this.dgCars.Rows.Count > 0)
                    {
                        this.dgCars.Rows[0].Selected = true;
                        this.dgCars_SelectionChanged(null, null);
                    }


                }

            }
        }

        private void butModifyRatings_Click(object sender, EventArgs e)
        {
            bool showModifyDialog = true;
            int currentRow = 0;

            if (this.colCars.IsDirty == true)
            {
                DialogResult sure = MessageBox.Show("You have unsaved changes in your carlist. If you bulk modify the ratings, you may possibly overwrite these changes. Are you sure you want to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sure == DialogResult.No)
                    showModifyDialog = false;
            }

            if (showModifyDialog)
            {
                
                DataGridViewSelectedRowCollection dgvRows = this.dgCars.SelectedRows;

                NR2003Car currentCar = null;
                if (dgvRows != null && dgvRows.Count > 0)
                {
                    currentCar = (NR2003Car)dgvRows[0].DataBoundItem;
                    currentRow = dgvRows[0].Index;
                }

                frmModifyRatings fModifyRatings = new frmModifyRatings(this.colCars, currentCar);
                fModifyRatings.ShowDialog();


                this.dgCars.Focus();
                this.dgCars.Refresh();

                if (this.dgCars.Rows.Count > 0)
                {
                    this.dgCars.Rows[currentRow].Selected = true;
                    this.dgCars_SelectionChanged(null, null);
                }

                if (this.colCars.IsDirty)
                    this.EnableControlsIfDirtyCarCollection(true);

            }
        }

        private void butCreateRoster_Click(object sender, EventArgs e)
        {
            this.CreateCarRoster();
        }

        private void butSelectModifiedCars_Click(object sender, EventArgs e)
        {
            if (this.colCars != null)
            {
                foreach (NR2003Car c in this.colCars.GetModifiedCars())
                    c.Selected = true;

                this.dgCars.Refresh();
            }
        }

        private void butSelectAllCars_Click(object sender, EventArgs e)
        {
            if (this.colCars != null)
            {

                foreach (NR2003Car c in this.colCars)
                {
                    c.Selected = true;
                }

                this.dgCars.Refresh();
            }
        }

        private void butSelectNoCars_Click(object sender, EventArgs e)
        {
            if (this.colCars != null)
            {

                foreach (NR2003Car c in this.colCars)
                {
                    c.Selected = false;
                }

                this.dgCars.Refresh();
            }
        }

        #endregion

        #region MenuCommands

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettings userSettings = (UserSettings)Program.userSettings.Clone();
            frmUserSettings fUserSettings = new frmUserSettings(userSettings);
            DialogResult dres = fUserSettings.ShowDialog();
        
            if (dres == DialogResult.OK)
            {
                Program.userSettings = fUserSettings.UserSettings;
                this.LoadNR2003Instances();
            }
        }

        private void visitProjectHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Constants.ProjectHomeURL);
            }
            catch (Exception ex)
            {
                frmNR2003Ratings.ShowError("Error while trying to access website: " + ex.ToString());
            }
        }

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox fAbout = new AboutBox();
            fAbout.ShowDialog();
        }

        private void randomizeAllNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RandomizeDriverNames();
            this.dgCars.Refresh();
        }

        #endregion

        #region CarsContextMenu

        private void copyRatingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colCars != null)
            {
                NR2003Car c = this.bsCars.Current as NR2003Car;

                if (c != null)
                {
                    this.CopiedRatings = (Ratings)c.Ratings.Clone();
                }

            }
        }

        private void pasteRatingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colCars != null)
            {
                NR2003Car c = this.bsCars.Current as NR2003Car;

                if (c != null && this.CopiedRatings != null)
                {
                    c.Ratings = (Ratings)this.CopiedRatings.Clone();
                    c.MappedToRealDriver = null;

                    //this.grpRatings.TrackChanges(false);
                    this.grpRatings.Ratings = c.Ratings;
                    //this.grpRatings.TrackChanges(true);
                }

            }
        }

        private void revertNameOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NR2003Car c = this.bsCars.Current as NR2003Car;

            if (c != null)
            {
                c.RevertToOriginal(NR2003Car.RevertType.NameOnly);

                //this.grpRatings.TrackChanges(false);
                this.grpRatings.Ratings = c.Ratings;
                //this.grpRatings.TrackChanges(true);
            }
        }

        private void revertRatingsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NR2003Car c = this.bsCars.Current as NR2003Car;

            if (c != null)
            {
                c.RevertToOriginal(NR2003Car.RevertType.RatingsOnly);

                //this.grpRatings.TrackChanges(false);
                this.grpRatings.Ratings = c.Ratings;
                //this.grpRatings.TrackChanges(true);
            }
        }

        private void revertCompletelyToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            NR2003Car c = this.bsCars.Current as NR2003Car;

            if (c != null)
            {
                c.RevertToOriginal(NR2003Car.RevertType.Completely);

                //this.grpRatings.TrackChanges(false);
                this.grpRatings.Ratings = c.Ratings;
                //this.grpRatings.TrackChanges(true);
            }
        }


        #endregion

        
    }
}