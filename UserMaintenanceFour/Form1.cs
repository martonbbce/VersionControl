using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenanceFour.Properties;

namespace UserMaintenanceFour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            lblFirstName.Text = Resources1.FirstName;
            lblLastName.Text = Resources1.LastName;
            btnAdd.Text = Resource2.Add;

        }
    }
}
