using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using NRatings.Client.Domain;

namespace NRatings.Client.GUI
{
    public partial class frmUserSettings : frmBase
    {
        private int nameColumnIndex = 0;
        private int pathColumnIndex = 1;
        private int browseColumnIndex = 2;
        private int defaultColumnIndex = 3;
        private bool currentDefaultValue;
        
        public frmUserSettings()
        {
            
            InitializeComponent();

            Task.Run(SetUserInfoAsync).Wait();

            this.bsUserSettings.DataSource = Program.UserSettings;

            string registryPath = this.ReadNR2003PathFromRegistry();

            if (registryPath != null && this.CheckNR2003PathIsConfigured(registryPath) == false && this.CheckNR2003PathValidity(registryPath) == true)
            {
                MessageBox.Show("NRatings has detected that NR2003 is installed in " + registryPath + ".\n\rThis path will automatically be added. You can still change its name.", "NR2003 detected", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NR2003Instance instance = new NR2003Instance();
                instance.Name = registryPath;
                instance.Path = registryPath;

                if (Program.UserSettings.NR2003Instances.Count == 0)
                    instance.IsDefault = true;
                else
                    instance.IsDefault = false;

                this.bsNR2003Instances.Add(instance);
            }

        }

        private async Task SetUserInfoAsync()
        {
            this.txtUserInfo.Text = await UserManager.GetUserInfoStringAsync(Environment.NewLine);

            if (await UserManager.IsLoggedInAsync())
            {
                this.butLogin.Enabled = false;
                this.butLogout.Enabled = true;
            }
            else
            {
                this.butLogin.Enabled = true;
                this.butLogout.Enabled = false;
            }
        }

        private string ReadNR2003PathFromRegistry()
        {
            string registryPath = null;
            //READ FROM REGISTRY LOGIC

            RegistryKey NR2003key = null;

            if (IntPtr.Size == 4) //32-bit
            {
                NR2003key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Papyrus\Nascar Racing 2003 Season");
                
                if(NR2003key == null)
                    NR2003key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Sierra\Nascar Racing 2003 Season");
            }
            else if (IntPtr.Size == 8) //64-bit
            {
                NR2003key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Papyrus\Nascar Racing 2003 Season");

                if (NR2003key == null)
                    NR2003key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Sierra\Nascar Racing 2003 Season");
            }

            if (NR2003key != null)
            {
                registryPath = NR2003key.GetValue("Directory") as string;
            }

            return registryPath;
        }

        private bool CheckNR2003PathIsConfigured(string path)
        {
            if (path != null)
            {
                var q = (from i in Program.UserSettings.NR2003Instances
                         where i.Path.Equals(path)
                         select i).Count();

                if (q > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private bool CheckNR2003PathValidity(string path)
        {
            if (File.Exists(path + @"\NR2003.exe"))
                return true;

            else
                return false;
        }

        private bool ValidateSettings()
        {
            List<string> messages = new List<string>();

            if (Program.UserSettings.NR2003Instances.Count() > 0)
            {
            
                var q = (from i in Program.UserSettings.NR2003Instances
                            where i.Name == null || i.Path == null
                            select i).Count();

                if (q > 0)
                {
                    messages.Add("You need to provide a name and a path for each NR2003 instance.");
                }

                var q2 = (from i in Program.UserSettings.NR2003Instances
                          select i.Name).Distinct();

                if (q2.Count() < Program.UserSettings.NR2003Instances.Count())
                {
                    messages.Add("Instances must have unique names.");
                }


                var q4 = (from i in Program.UserSettings.NR2003Instances
                            where i.IsDefault == true
                            select i).Count();

                if (q4 == 0)
                {
                    messages.Add("You need to flag one instance as default.");
                }



            }

            if (messages.Count > 0)
            {
                string message = string.Empty;

                foreach (string m in messages)
                {
                    message += m + "\n\r";
                }

                MessageBox.Show(message, "Error(s) during validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void dgNR2003Instances_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var q = (from i in Program.UserSettings.NR2003Instances
                     where i.IsDefault == true
                     select i).Count();

            if (q == 0)
            {
                this.dgNR2003Instances.Rows[e.RowIndex].Cells[defaultColumnIndex].Value = true;
            }
        }

        private void dgNR2003Instances_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == defaultColumnIndex && e.RowIndex != -1)
            {
                bool isDefault = (bool)this.dgNR2003Instances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (isDefault == true)
                {
                    foreach (DataGridViewRow dgvr in this.dgNR2003Instances.Rows)
                    {
                        if(dgvr.Index != e.RowIndex)
                            dgvr.Cells[defaultColumnIndex].Value = false;
                    }

                }
            }
        }

        private void dgNR2003Instances_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == defaultColumnIndex && e.RowIndex != -1)
            {
                if (this.dgNR2003Instances.IsCurrentCellInEditMode)
                    this.dgNR2003Instances.EndEdit();
            }
            else if (e.ColumnIndex == browseColumnIndex && e.RowIndex != -1)
            {
                DialogResult dres = this.fbDialog.ShowDialog();

                if (dres == DialogResult.OK)
                {
                    bool usePath = true;

                    if (!CheckNR2003PathValidity(this.fbDialog.SelectedPath))
                    {
                        DialogResult dresConfirm = MessageBox.Show("The selected path does not appear to be a valid NR2003 root path.\n\rMake sure you've pointed to the ROOT folder of your NR2003 install instead of to a mods folder.\n\rDo you wish to use this path anyway ?", "Invalid path", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dresConfirm == DialogResult.No)
                            usePath = false;
                    }

                    if (usePath)
                    {
                        this.dgNR2003Instances.Rows[e.RowIndex].Cells[pathColumnIndex].Value = this.fbDialog.SelectedPath;

                        if (this.dgNR2003Instances.Rows[e.RowIndex].Cells[nameColumnIndex].Value == null || this.dgNR2003Instances.Rows[e.RowIndex].Cells[nameColumnIndex].Value == string.Empty)
                        {
                            this.dgNR2003Instances.Rows[e.RowIndex].Cells[nameColumnIndex].Value = this.fbDialog.SelectedPath;
                        }
                    }
                }
            }
        }

        private void dgNR2003Instances_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == defaultColumnIndex && e.RowIndex != -1)
            {
                if (this.dgNR2003Instances.IsCurrentCellInEditMode)
                    this.dgNR2003Instances.EndEdit();
            }
        }

        private void dgNR2003Instances_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == defaultColumnIndex && e.RowIndex != -1)
            {
                this.currentDefaultValue = (bool)this.dgNR2003Instances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
        }

        private void dgNR2003Instances_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == defaultColumnIndex && e.RowIndex != -1)
            {
                if (this.currentDefaultValue == true)
                    this.dgNR2003Instances.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ValidateSettings())
            {
                Program.UserSettings.Save();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private async void butLogin_Click(object sender, EventArgs e)
        {
            var result = await UserManager.LoginAsync(this);
            if (!result.Succeeded)
            {
                MessageBox.Show(result.Error, "Login unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await SetUserInfoAsync();
        }

        private async void butLogout_Click(object sender, EventArgs e)
        {
            await UserManager.LogOutAsync(this);
            await SetUserInfoAsync();
        }
    }
}
