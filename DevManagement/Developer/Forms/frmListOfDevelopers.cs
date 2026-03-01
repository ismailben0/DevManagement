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
    public partial class frmListOfDevelopers : Form
    {
        public frmListOfDevelopers()
        {
            InitializeComponent();
        }

        DataTable _dtAllDevelopers;

        public void _LoadDevelopers()
        {
            _dtAllDevelopers = clsDeveloper.GetAll();

            dgvDevelopers.DataSource = _dtAllDevelopers;

            if(dgvDevelopers.Rows.Count > 0)
            {
                dgvDevelopers.Columns["DeveloperID"].HeaderText = "Developer ID";
                dgvDevelopers.Columns["DeveloperID"].Width = 100;

                dgvDevelopers.Columns["FirstName"].HeaderText = "First Name";
                dgvDevelopers.Columns["FirstName"].Width = 150;

                dgvDevelopers.Columns["LastName"].HeaderText = "Last Name";
                dgvDevelopers.Columns["LastName"].Width = 150;

                dgvDevelopers.Columns["Email"].HeaderText = "Email";
                dgvDevelopers.Columns["Email"].Width = 200;

            }

            lblTotal.Text = $"{dgvDevelopers.Rows.Count}";

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DeveloperID = Convert.ToInt32(dgvDevelopers.CurrentRow.Cells["DeveloperID"].Value);
            frmAddEditDeveloper frmAddEdit = new frmAddEditDeveloper(DeveloperID);
            frmAddEdit.ShowDialog();
            frmListOfDevelopers_Load(null, null);
        }

        private void showMoreInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeveloperCard developerCard = new frmDeveloperCard(Convert.ToInt32(dgvDevelopers.CurrentRow.Cells["DeveloperID"].Value));
            developerCard.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DeveloperID = Convert.ToInt32(dgvDevelopers.CurrentRow.Cells["DeveloperID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this developer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool isDeleted = clsDeveloper.DeleteByID(DeveloperID);
                if (isDeleted)
                {
                    MessageBox.Show("Developer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListOfDevelopers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Delete operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditDeveloper frmAddEdit = new frmAddEditDeveloper();
            frmAddEdit.ShowDialog();
            frmListOfDevelopers_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = cbFilterBy.Text != "None";
            txtFilterBy.Text = "";
            txtFilterBy.Focus();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmListOfDevelopers_Load(object sender, EventArgs e)
        {
            this.Text = "List of Developers";
            _LoadDevelopers();

            cbFilterBy.SelectedIndex = 0;
        }
    }
}
