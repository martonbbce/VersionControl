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
using UserMaintenanceFour.Entities;

namespace UserMaintenanceFour
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>;
        public Form1()
        {
            
            InitializeComponent();
            lblFirstName.Text = Resources1.FirstName;
            lblLastName.Text = Resources1.LastName;
            btnAdd.Text = Resource2.Add;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }
    }
}
