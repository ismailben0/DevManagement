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

namespace DevManagement.Developer.Controls
{
    public partial class ctrlDeveloperCard : UserControl
    {
      
        public ctrlDeveloperCard()
        {
            InitializeComponent();
        }

        public void ResetDefault()
        {
            lblDeveloperID.Text = "";
            lblFirstName.Text = "";
            lblLastName.Text = "";
            lblEmail.Text = "";
        }

        public void LoadData(int developerID)
        {
            clsDeveloper developer = clsDeveloper.GetDeveloperByID(developerID);

            if (developer == null)
            {
                ResetDefault();
            }
            else
            {
                lblDeveloperID.Text = developer.DeveloperID.ToString();
                lblFirstName.Text = developer.FirstName;
                lblLastName.Text = developer.LastName;
                lblEmail.Text = developer.Email;
                lblHireDate.Text = developer.HireDate.ToShortDateString();
            }
        }

    }
}
