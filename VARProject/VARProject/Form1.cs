using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VARProject.Entities;

namespace VARProject
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticklist;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        public Form1()
        {
            InitializeComponent();
            Ticklist = context.Tick.ToList();
            dataGridView1.DataSource = Ticklist;
            CreatePortfolio();

            // 06
            int elemszám = Portfolio.Count();


            decimal részvényekSzáma = (from x in Portfolio select x.Volume).Sum();
            MessageBox.Show(string.Format("Részvények száma: {0}", részvényekSzáma));

            DateTime minDátum = (from x in Ticklist select x.TradingDay).Min();
            DateTime maxDátum = (from x in Ticklist select x.TradingDay).Max();
            int elteltNapokSzáma = (maxDátum - minDátum).Days;
            DateTime optMinDátum = (from x in Ticklist where x.Index == "OTP" select x.TradingDay).Min();
            MessageBox.Show(optMinDátum.ToString());



        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
    }
}
