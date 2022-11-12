using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nz43vh_gyak03_01
{
    public partial class Form1 : Form
    {
        
        private List<Country> countries = new List<Country>();
        public Form1()
        {

            InitializeComponent();
        }
        private void LoadData(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                var line =  sr.ReadLine().Split(';');
                var currentCountry = line[2];
                var search = (from x in countries
                              where x.Name.Equals(currentCountry)
                              select x);
                if (search == null)
                {
                    Country newcountry = new Country();
                    newcountry.ID = countries.Count;
                    newcountry.Name = currentCountry;
                    countries.Add(newcountry);
                    search = newcountry;
                }

            }
        }
    }
}
