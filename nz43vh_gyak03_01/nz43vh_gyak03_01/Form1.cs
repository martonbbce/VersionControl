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
        private List<Ramen> ramens = new List<Ramen>();
        
        public Form1()
        {
            
            InitializeComponent();
            LoadData("ramen.csv");
            
            GetCountries();
            
        }

        private void LoadData(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                var line =  sr.ReadLine().Split(';');
                var currentCountry = line[2];
                Country resultcountry = AddCountry(currentCountry);
                Ramen currentRamen = new Ramen();
                currentRamen.ID = ramens.Count;
                currentRamen.CountryFK = resultcountry.ID;
                currentRamen.Country = resultcountry;
                currentRamen.Brand = line[0];
                currentRamen.Rating = Convert.ToDouble(line[3].ToString());
                currentRamen.Name = line[1];
                ramens.Add(currentRamen);
            }
        }

        private Country AddCountry(string inputcountry)
        {
            var search = (from x in countries
                              where x.Name.Equals(inputcountry)
                              select x).FirstOrDefault();
            if (search == null)
            {
                search = new Country
                {
                    ID = countries.Count,
                    Name = inputcountry
                    // Console.WriteLine(search.Name)

                };
                countries.Add(search);


            }
            
                return search;
            
        }

        private void GetCountries()
        {
            var searchcountr = from x in countries
                               where x.Name.Contains(textBox1.Text)
                               orderby x.Name
                               select x;
                                
            listBox1.DataSource = searchcountr.ToList();
            listBox1.DisplayMember = "Name";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetCountries();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selected index changed");
            if(listBox1.SelectedItem == null) { return; } 
            Country selectedcountry = (Country)listBox1.SelectedItem;
            var contrRamens = from x in ramens where x.CountryFK == selectedcountry.ID select x;
            var orderedContrRamens = from x in contrRamens
                                     group x.Rating by x.Brand into f
                                     select new
                                     {
                                         BrandName = f.Key,
                                         Averagerating = Math.Round(f.Average(), 2)
                                     };
            var ered3 = from h in orderedContrRamens 
                        orderby h.Averagerating descending 
                        select h;
            dataGridView1.DataSource = ered3.ToList();
        }
    }
}
