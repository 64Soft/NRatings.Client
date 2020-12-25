using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NRatings.Client.Auxiliary;
using NRatings.Client.Domain;
using NRatings.Client.Domain.Collections;

namespace NRatings.Client.GUI
{
    public partial class RatingsFormulaSelection : UserControl
    {
        public RatingsFormulaCollection FormulaCollection
        {
            get { return (RatingsFormulaCollection)this.cmbFormula.DataSource; }
            set 
            {
                this.cmbFormula.DataSource = value; 
            }
        }

        public RatingsFormula SelectedFormula
        {
            get { return (RatingsFormula)this.cmbFormula.SelectedItem; }
            set
            {
                this.cmbFormula.SelectedItem = value;
            }
        }

        public RatingsFormulaSelection()
        {
            InitializeComponent();

            this.LoadMappingMethods();
            this.ManageOptions();
        }

        private void cmbFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            RatingsFormula previousFormula = this.bsSelectedFormula.DataSource as RatingsFormula;

            if(previousFormula != null)
                previousFormula.Options.SetToDefaults();

            this.bsSelectedFormula.DataSource = (RatingsFormula)this.cmbFormula.SelectedItem;
            this.chkFOUseDefault.Checked = true;
        }

        
        private void LoadMappingMethods()
        {
            List<CarMappingMethod> mappingMethods = new List<CarMappingMethod>((CarMappingMethod[])Enum.GetValues(typeof(CarMappingMethod)));
            
            var q = from mappingMethod in mappingMethods
                    select new EnumListItem() 
                    { 
                        Value = mappingMethod,
                        Display = Helper.GetEnumDescription(mappingMethod)
                    };

            this.cmbMappingMethod.DataSource = q.ToList();
            this.cmbMappingMethod.ValueMember = "Value";
            this.cmbMappingMethod.DisplayMember = "Display";

        }

        private void ManageOptions()
        {
            this.chkUseNR2003TrackType.Enabled = !this.chkFOUseDefault.Checked;
            this.lblMappingMethod.Enabled = !this.chkFOUseDefault.Checked;
            this.cmbMappingMethod.Enabled = !this.chkFOUseDefault.Checked;
        }

        private void ReloadDefaultOptions()
        {
            this.SelectedFormula.Options.SetToDefaults();
        }


        private void ShowDescription()
        {
            this.rtxtDescription.Clear();

            if (this.SelectedFormula != null)
            {
                if (this.SelectedFormula.Author != null && this.SelectedFormula.Author != "")
                {
                    this.rtxtDescription.Text = "Author: " + this.SelectedFormula.Author + Environment.NewLine + Environment.NewLine;
                }

                this.rtxtDescription.Text += this.SelectedFormula.Description;
            }
        }

        private void butSetDefault_Click(object sender, EventArgs e)
        {
            Program.UserSettings.DefaultFormula = this.SelectedFormula.FileName;
            Program.UserSettings.Save();

            MessageBox.Show("Default formula set to " + this.SelectedFormula.Name, "Default set", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.SelectedFormula.SaveToFile(RatingsFormula.FileType.BINARY);
            //this.SelectedFormula.SaveToFile(RatingsFormula.FileType.XML);
        }

        private void chkFOUseDefault_CheckedChanged(object sender, EventArgs e)
        {
            this.ManageOptions();
            
            if (this.chkFOUseDefault.Checked == true)
                this.ReloadDefaultOptions();

            this.bsSelectedFormulaOptions.ResetBindings(false);
        }

        
   
    }

    


}
