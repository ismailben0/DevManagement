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
    public partial class frmDeveloperCard : Form
    {
        int _DeveloperID;

        public frmDeveloperCard(int developerID)
        {
            InitializeComponent();
            _DeveloperID = developerID;
        }

        private void frmDeveloperCard_Load(object sender, EventArgs e)
        {
            ctrlDeveloperCard1.LoadData(_DeveloperID);
        }
    }
}
