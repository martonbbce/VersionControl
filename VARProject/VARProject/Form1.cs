﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VARProject
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticklist;
        public Form1()
        {
            InitializeComponent();
            Ticklist = context.Tick.ToList();
            dataGridView1.DataSource = Ticklist;
        }
    }
}