using System;
using System.Management.Automation;
using System.Windows.Forms;

namespace Get_Driver_Tool
{
    public partial class Form1 : Form
    {
        string manufacturer = "";
        string model = "";
        public Form1()
        {
            InitializeComponent();
            getDetails();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Export-WindowsDriver -Online -Destination "full_path_to_export_folder"
            //dism /online /export-driver /destination:"full_path_to_export_folder"

            if (txtDriveLetter.Text == "")
            {
                return;
            }
            try {
                Cursor.Current = Cursors.WaitCursor;
                string script = "Export-WindowsDriver -Online -Destination \"" + txtDriveLetter.Text + ":\\" + manufacturer + "\\" + model + "\"";
                PowerShell ps = PowerShell.Create();
                ps.AddScript(script);
                ps.Invoke();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Export completed!");

            } catch (Exception error) {
                MessageBox.Show(error.Message);
            };
        }

        void getDetails()
        {
            manufacturer = WMICTools.getManufacturer();
            model = WMICTools.getModelName();
            txtDetails.Text = "Manufacturer:\r\n" + manufacturer + "\r\n\r\nModel:\r\n" + model;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
