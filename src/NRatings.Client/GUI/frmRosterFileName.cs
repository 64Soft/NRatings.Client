using System;
using System.Windows.Forms;

namespace NRatings.Client.GUI
{
    public partial class frmRosterFileName : frmBase
    {
        private string mFileName;

        public string FileName
        {
            get { return this.mFileName; }
        }
        
        public frmRosterFileName()
        {
            InitializeComponent();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if(this.txtFileName.Text == "")
            {
                frmNR2003Ratings.ShowError("Please enter a filename");
            }
            else
            {
                this.mFileName = this.txtFileName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}