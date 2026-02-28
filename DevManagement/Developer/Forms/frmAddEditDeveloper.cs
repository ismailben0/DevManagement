using Dev_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevManagement.Developer.Forms
{
    public partial class frmAddEditDeveloper : Form
    {
        enum enMode { AddNew ,Update}
        enMode Mode;

        int _DeveloperID;
        clsDeveloper _Developer;

        public frmAddEditDeveloper()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
        }

        public frmAddEditDeveloper(int DeveloperID)
        {
            InitializeComponent();

            _DeveloperID = DeveloperID;

            Mode = enMode.Update;
        }

        void _ResetDefault()
        {

            if(Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Developer";
                _Developer = new clsDeveloper();
                this.Text = "Add New Developer";
            }
            else if(Mode == enMode.Update)
            {
                lblTitle.Text = "Update Developer";
                this.Text = "Update Developer";
            }

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
        }

        void _LoadDeveloper()
        {
            if (Mode == enMode.Update)
            {
                _Developer = clsDeveloper.GetDeveloperByID(_DeveloperID);
                if (_Developer == null)
                {
                    MessageBox.Show("Developer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtFirstName.Text = _Developer.FirstName;
                txtLastName.Text = _Developer.LastName;
                txtEmail.Text = _Developer.Email;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Developer.FirstName = txtFirstName.Text.Trim();
            _Developer.LastName = txtLastName.Text.Trim();
            _Developer.Email = txtEmail.Text.Trim();

            if (_Developer.Save())
            {
                if(Mode == enMode.AddNew)
                {
                    lblDeveloperID.Text = "#" + _Developer.DeveloperID.ToString() + "000";
                    Mode = enMode.Update;
                    lblTitle.Text = "Update Developer";
                    this.Text = "Update Developer";
                    MessageBox.Show("Developer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Mode == enMode.Update)
                {
                    MessageBox.Show("Developer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Failed to save developer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddEditDeveloper_Load(object sender, EventArgs e)
        {
            _ResetDefault();
            if (Mode == enMode.Update)
            {
                _LoadDeveloper();
            }
        }
    }
}
